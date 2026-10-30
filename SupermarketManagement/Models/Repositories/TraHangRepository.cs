using System;
using System.Data;
using System.Data.SqlClient;
using SupermarketManagement.Models.Repositories;
using SupermarketManagement.Controllers.Repositories;

namespace SupermarketManagement.Models.Repositories
{
    
    public class TraHangRepository
    {
        private readonly DbConection db = new DbConection();

        public TraHangRepository()
        {
        }

 

        public DataTable TimHoaDon(string maHD)
        {
            const string sql = @"
                SELECT ct.MaSP, sp.TenSanPham, ct.MaDVT, dv.TenDV,
                       ct.SoLuongBan AS SoLuongDaMua,
                       ISNULL((SELECT SUM(cpt.SoLuongTra)
                               FROM dbo.ChiTietPhieuTraHang cpt
                               INNER JOIN dbo.PhieuTraHang pt ON pt.MaPhieuTra = cpt.MaPhieuTra
                               WHERE pt.MaHD = ct.MaHD
                                 AND cpt.MaSP = ct.MaSP
                                 AND cpt.MaDVT = ct.MaDVT), 0) AS SoLuongDaTra,
                       d.DonGiaBanLe AS DonGia, ct.SoLuongBan * d.SoLuongQuyDoi AS SoLuongQuyDoi,d.SoLuongQuyDoi AS HeSoQuyDoi
                FROM dbo.ChiTietHoaDon ct
                INNER JOIN dbo.SanPham sp ON sp.MaSP = ct.MaSP
                INNER JOIN dbo.SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                INNER JOIN dbo.DonViTinh dv ON dv.MaDVT = ct.MaDVT
                WHERE ct.MaHD = @MaHD
                ORDER BY sp.TenSanPham;";

            using (var conn = db.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20).Value = maHD;
                var result = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd)) adapter.Fill(result);
                return result;
            }
        }

        public string LayTenKhachHang(string maHD)
        {
            const string sql = @"SELECT ISNULL(kh.HoTen, N'Khách lẻ')
                                 FROM dbo.HoaDon h
                                 LEFT JOIN dbo.KhachHang kh ON kh.MaKH = h.MaKH
                                 WHERE h.MaHD = @MaHD;";
            using (var conn = db.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20).Value = maHD;
                conn.Open();
                object value = cmd.ExecuteScalar();
                return value == null || value == DBNull.Value ? "Khách lẻ" : Convert.ToString(value);
            }
        }

        public DataTable LayDanhSachSanPhamDeChon()
        {
            const string sql = @"SELECT sp.MaSP, sp.TenSanPham, d.MaDVT, dv.TenDV,
                                        d.SoLuongQuyDoi, d.DonGiaBanLe
                                 FROM dbo.SanPham sp
                                 INNER JOIN dbo.SanPham_DonViTinh d ON d.MaSP = sp.MaSP
                                 INNER JOIN dbo.DonViTinh dv ON dv.MaDVT = d.MaDVT
                                 WHERE sp.TrangThai = 1
                                 ORDER BY sp.TenSanPham, d.SoLuongQuyDoi;";
            using (var conn = db.CreateConnection())
            using (var adapter = new SqlDataAdapter(sql, conn))
            {
                var result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }

        public void LuuPhieuTraHang(string maPhieu, string maHD, string maNV,
                                    string lyDo, DataTable chiTiet)
        {
            using (var conn = db.CreateConnection())  
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (var check = new SqlCommand(
                            "SELECT COUNT(1) FROM dbo.HoaDon WITH (UPDLOCK, HOLDLOCK) WHERE MaHD=@MaHD", conn, tran))
                        {
                            check.Parameters.Add("@MaHD", SqlDbType.VarChar, 20).Value = maHD;
                            if (Convert.ToInt32(check.ExecuteScalar()) != 1)
                                throw new Exception("Hóa đơn gốc không tồn tại.");
                        }

                        bool coSanPhamTra = false;
                        foreach (DataRow row in chiTiet.Rows)
                        {
                            int soLuongTra = Convert.ToInt32(row["SoLuongTra"]);
                            if (soLuongTra > 0) { coSanPhamTra = true; break; }
                        }
                        if (!coSanPhamTra)
                            throw new Exception("Bạn chưa nhập số lượng trả lớn hơn 0.");

                        const string sqlHeader = @"INSERT INTO dbo.PhieuTraHang
                            (MaPhieuTra, MaHD, NgayTra, MaNV, LyDo, TrangThai)
                            VALUES (@MaPhieuTra, @MaHD, GETDATE(), @MaNV, @LyDo, N'DaXacNhan');";
                        using (var cmd = new SqlCommand(sqlHeader, conn, tran))
                        {
                            cmd.Parameters.Add("@MaPhieuTra", SqlDbType.VarChar, 30).Value = maPhieu;
                            cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20).Value = maHD;
                            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 20).Value = string.IsNullOrWhiteSpace(maNV) ? (object)DBNull.Value : maNV;
                            cmd.Parameters.Add("@LyDo", SqlDbType.NVarChar, 500).Value = lyDo;
                            cmd.ExecuteNonQuery();
                        }

                        foreach (DataRow row in chiTiet.Rows)
                        {
                            int qty = Convert.ToInt32(row["SoLuongTra"]);
                            if (qty <= 0) continue;

                            string maSP = Convert.ToString(row["MaSP"]);
                            string maDVT = Convert.ToString(row["MaDVT"]);
                            int daMua;
                            int daTra;

                            // Kiểm tra lại số lượng trực tiếp trong database trong transaction.
                            const string sqlSoLuong = @"SELECT
                                ISNULL((SELECT SUM(ct.SoLuongBan) FROM dbo.ChiTietHoaDon ct
                                        WHERE ct.MaHD=@MaHD AND ct.MaSP=@MaSP AND ct.MaDVT=@MaDVT), 0) AS DaMua,
                                ISNULL((SELECT SUM(cpt.SoLuongTra)
                                        FROM dbo.ChiTietPhieuTraHang cpt
                                        INNER JOIN dbo.PhieuTraHang pt ON pt.MaPhieuTra=cpt.MaPhieuTra
                                        WHERE pt.MaHD=@MaHD AND cpt.MaSP=@MaSP AND cpt.MaDVT=@MaDVT), 0) AS DaTra;";
                            using (var checkQty = new SqlCommand(sqlSoLuong, conn, tran))
                            {
                                checkQty.Parameters.Add("@MaHD", SqlDbType.VarChar, 20).Value = maHD;
                                checkQty.Parameters.Add("@MaSP", SqlDbType.VarChar, 20).Value = maSP;
                                checkQty.Parameters.Add("@MaDVT", SqlDbType.VarChar, 20).Value = maDVT;
                                using (var reader = checkQty.ExecuteReader())
                                {
                                    if (!reader.Read()) throw new Exception("Không kiểm tra được số lượng sản phẩm " + maSP + ".");
                                    daMua = Convert.ToInt32(reader["DaMua"]);
                                    daTra = Convert.ToInt32(reader["DaTra"]);
                                }
                            }
                            if (qty > daMua - daTra)
                                throw new Exception($"Sản phẩm {row["TenSanPham"]}: chỉ còn được trả tối đa {daMua - daTra} {row["TenDV"]}.");

                            decimal donGia = Convert.ToDecimal(row["DonGia"]);
                            int quyDoi = Convert.ToInt32(row["HeSoQuyDoi"]);
                            using (var cmd = new SqlCommand(@"INSERT INTO dbo.ChiTietPhieuTraHang
                                (MaPhieuTra, MaSP, MaDVT, SoLuongTra, DonGiaHoan)
                                VALUES (@MaPhieuTra, @MaSP, @MaDVT, @SoLuongTra, @DonGia);", conn, tran))
                            {
                                cmd.Parameters.Add("@MaPhieuTra", SqlDbType.VarChar, 30).Value = maPhieu;
                                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 20).Value = maSP;
                                cmd.Parameters.Add("@MaDVT", SqlDbType.VarChar, 20).Value = maDVT;
                                cmd.Parameters.Add("@SoLuongTra", SqlDbType.Int).Value = qty;
                                var price = cmd.Parameters.Add("@DonGia", SqlDbType.Decimal);
                                price.Precision = 18; price.Scale = 2; price.Value = donGia;
                                cmd.ExecuteNonQuery();
                            }

                            // Hàng trả được cộng lại vào kho bán được, theo quy đổi đơn vị tính.
                            using (var cmd = new SqlCommand(@"UPDATE dbo.SanPham
                                SET SoLuongTong = SoLuongTong + (@Qty * @QuyDoi)
                                WHERE MaSP = @MaSP;", conn, tran))
                            {
                                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = qty;
                                cmd.Parameters.Add("@QuyDoi", SqlDbType.Int).Value = quyDoi;
                                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 20).Value = maSP;
                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception("Không cập nhật được tồn kho sản phẩm " + maSP + ".");
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        public DataTable LayDanhSachHoaDonTrongNgay()
        {
            string sql = @"
                SELECT DISTINCT MaHD
                FROM HoaDon
                WHERE NgayMua >= CAST(GETDATE() AS date)
                  AND NgayMua < DATEADD(day, 1, CAST(GETDATE() AS date))
                ORDER BY MaHD DESC;";

            using (var conn = db.CreateConnection())
            using (var adapter = new SqlDataAdapter(sql, conn))
            {
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }
    }
}
