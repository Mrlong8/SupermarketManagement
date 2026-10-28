using System;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Models.Repositories
{
    internal class HoaDonRepository
    {
        private readonly string connectionString =
            @"Data Source=localhost;Initial Catalog=SupermarketManagement;Integrated Security=True";
        // Nếu SQL Server của bạn dùng SQLEXPRESS, đổi connectionString theo cấu hình đang hoạt động.

        /// <summary>
        /// Lưu hóa đơn, chi tiết hóa đơn, trừ tồn kho theo đơn vị quy đổi
        /// và cập nhật điểm khách hàng trong cùng một transaction.
        /// DataTable chiTiet cần có: MaSP, MaDVT, SoLuongBan.
        /// </summary>
        public void LuuHoaDon(
            string maHD,
            decimal tongTien,
            DateTime ngayMua,
            string maKH,
            string maNV,
            DataTable chiTiet,
            int diemSuDung)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                throw new ArgumentException("Mã hóa đơn không được để trống.");

            if (chiTiet == null || chiTiet.Rows.Count == 0)
                throw new ArgumentException("Hóa đơn phải có ít nhất một sản phẩm.");

            if (!chiTiet.Columns.Contains("MaSP") ||
                !chiTiet.Columns.Contains("MaDVT") ||
                !chiTiet.Columns.Contains("SoLuongBan"))
                throw new ArgumentException(
                    "Chi tiết hóa đơn phải có các cột MaSP, MaDVT và SoLuongBan.");

            if (tongTien < 0 || diemSuDung < 0)
                throw new ArgumentException("Tổng tiền và điểm sử dụng không hợp lệ.");

            int diemMoi = (int)(tongTien / 10000m);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Đọc điểm khách hàng và khóa dòng trong lúc thanh toán.
                        int diemCu = 0;
                        if (!string.IsNullOrWhiteSpace(maKH))
                        {
                            string sqlDiem = @"
                                SELECT DiemTichLuy
                                FROM dbo.KhachHang WITH (UPDLOCK, HOLDLOCK)
                                WHERE MaKH = @MaKH";

                            using (SqlCommand cmd = new SqlCommand(sqlDiem, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20).Value = maKH.Trim();
                                object ketQua = cmd.ExecuteScalar();

                                if (ketQua == null || ketQua == DBNull.Value)
                                    throw new Exception("Không tìm thấy khách hàng.");

                                diemCu = Convert.ToInt32(ketQua);
                            }
                        }
                        else if (diemSuDung > 0)
                        {
                            throw new Exception("Phải chọn khách hàng mới được sử dụng điểm.");
                        }

                        // 2. Kiểm tra mức giảm giá theo số điểm.
                        if (diemSuDung > diemCu)
                            throw new Exception(
                                $"Không đủ điểm. Điểm hiện có: {diemCu}, điểm cần dùng: {diemSuDung}.");

                        int phanTramGiam = diemSuDung / 10;
                        if (diemSuDung % 10 != 0 ||
                            (phanTramGiam != 0 && phanTramGiam != 5 &&
                             phanTramGiam != 10 && phanTramGiam != 20 &&
                             phanTramGiam != 30))
                            throw new Exception(
                                "Điểm sử dụng phải tương ứng với mức giảm 5%, 10%, 20% hoặc 30%.");

                        decimal tienGiamGia = tongTien * phanTramGiam / 100m;
                        if (tienGiamGia > tongTien)
                            throw new Exception("Tiền giảm giá vượt quá tổng tiền hàng.");

                        // 3. Gộp các dòng trùng cả sản phẩm VÀ đơn vị tính.
                        // Cùng sản phẩm nhưng khác đơn vị (Hộp/Thùng) phải là hai dòng riêng.
                        DataTable sanPhamBan = new DataTable();
                        sanPhamBan.Columns.Add("MaSP", typeof(string));
                        sanPhamBan.Columns.Add("MaDVT", typeof(string));
                        sanPhamBan.Columns.Add("SoLuongBan", typeof(int));

                        foreach (DataRow row in chiTiet.Rows)
                        {
                            string maSP = Convert.ToString(row["MaSP"]).Trim();
                            string maDVT = Convert.ToString(row["MaDVT"]).Trim();
                            int soLuong = Convert.ToInt32(row["SoLuongBan"]);

                            if (string.IsNullOrWhiteSpace(maSP))
                                throw new Exception("Mã sản phẩm không được để trống.");
                            if (string.IsNullOrWhiteSpace(maDVT))
                                throw new Exception("Đơn vị tính không được để trống.");
                            if (soLuong <= 0)
                                throw new Exception("Số lượng bán phải lớn hơn 0.");

                            DataRow dongCu = null;
                            foreach (DataRow dong in sanPhamBan.Rows)
                            {
                                if (Convert.ToString(dong["MaSP"]) == maSP &&
                                    Convert.ToString(dong["MaDVT"]) == maDVT)
                                {
                                    dongCu = dong;
                                    break;
                                }
                            }

                            if (dongCu == null)
                                sanPhamBan.Rows.Add(maSP, maDVT, soLuong);
                            else
                                dongCu["SoLuongBan"] =
                                    Convert.ToInt32(dongCu["SoLuongBan"]) + soLuong;
                        }

                        // 4. Trừ kho theo đơn vị cơ bản: SoLuongTong -= số lượng bán * hệ số quy đổi.
                        foreach (DataRow row in sanPhamBan.Rows)
                        {
                            string maSP = Convert.ToString(row["MaSP"]);
                            string maDVT = Convert.ToString(row["MaDVT"]);
                            int soLuong = Convert.ToInt32(row["SoLuongBan"]);

                            string sqlTruKho = @"
                                UPDATE sp
                                SET sp.SoLuongTong = sp.SoLuongTong - (@SoLuong * d.SoLuongQuyDoi)
                                FROM dbo.SanPham sp
                                INNER JOIN dbo.SanPham_DonViTinh d
                                    ON d.MaSP = sp.MaSP AND d.MaDVT = @MaDVT
                                WHERE sp.MaSP = @MaSP
                                  AND d.SoLuongQuyDoi > 0
                                  AND sp.SoLuongTong >= (@SoLuong * d.SoLuongQuyDoi)";

                            using (SqlCommand cmd = new SqlCommand(sqlTruKho, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 20).Value = maSP;
                                cmd.Parameters.Add("@MaDVT", SqlDbType.VarChar, 20).Value = maDVT;
                                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;

                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception(
                                        $"Sản phẩm {maSP} (đơn vị {maDVT}) không tồn tại, chưa cấu hình quy đổi hoặc không đủ hàng.");
                            }
                        }

                        // 5. Lưu hóa đơn (giữ nguyên cấu trúc bảng HoaDon hiện tại).
                        string sqlHoaDon = @"
                            INSERT INTO dbo.HoaDon (MaHD, NgayMua, MaKH, MaNV)
                            VALUES (@MaHD, @NgayMua, @MaKH, @MaNV)";

                        using (SqlCommand cmd = new SqlCommand(sqlHoaDon, conn, transaction))
                        {
                            cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20).Value = maHD.Trim();
                            cmd.Parameters.Add("@NgayMua", SqlDbType.DateTime).Value = ngayMua;
                            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20).Value =
                                string.IsNullOrWhiteSpace(maKH) ? (object)DBNull.Value : maKH.Trim();
                            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 20).Value =
                                string.IsNullOrWhiteSpace(maNV) ? (object)DBNull.Value : maNV.Trim();
                            cmd.ExecuteNonQuery();
                        }

                        // 6. Lưu MaDVT cùng số lượng đã bán theo đơn vị được chọn.
                        string sqlChiTiet = @"
                            INSERT INTO dbo.ChiTietHoaDon (MaHD, MaSP, MaDVT, SoLuongBan)
                            VALUES (@MaHD, @MaSP, @MaDVT, @SoLuongBan)";

                        foreach (DataRow row in sanPhamBan.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand(sqlChiTiet, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20).Value = maHD.Trim();
                                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 20).Value =
                                    Convert.ToString(row["MaSP"]);
                                cmd.Parameters.Add("@MaDVT", SqlDbType.VarChar, 20).Value =
                                    Convert.ToString(row["MaDVT"]);
                                cmd.Parameters.Add("@SoLuongBan", SqlDbType.Int).Value =
                                    Convert.ToInt32(row["SoLuongBan"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 7. Cập nhật điểm khách hàng: điểm cũ - điểm dùng + điểm kiếm được.
                        if (!string.IsNullOrWhiteSpace(maKH))
                        {
                            int diemSauThanhToan = diemCu - diemSuDung + diemMoi;
                            string sqlCapNhatDiem = @"
                                UPDATE dbo.KhachHang
                                SET DiemTichLuy = @DiemMoi
                                WHERE MaKH = @MaKH";

                            using (SqlCommand cmd = new SqlCommand(sqlCapNhatDiem, conn, transaction))
                            {
                                cmd.Parameters.Add("@DiemMoi", SqlDbType.Int).Value = diemSauThanhToan;
                                cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20).Value = maKH.Trim();

                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception("Không cập nhật được điểm khách hàng.");
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
