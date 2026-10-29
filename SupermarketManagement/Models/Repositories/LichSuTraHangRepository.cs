
using System;
using System.Data;
using System.Data.SqlClient;
using SupermarketManagement.Controllers.Repositories;

namespace SupermarketManagement.Models.Repositories
{
    public class LichSuTraHangRepository
    {
        private readonly DbConection db = new DbConection();

        // 1. Lấy danh sách lịch sử phiếu trả hàng
        public DataTable GetDanhSachPhieuTra()
        {
            const string sql = @"
                SELECT
                    pt.MaPhieuTra AS [Mã Phiếu Trả],
                    pt.MaHD AS [Mã Hóa Đơn],
                    pt.NgayTra AS [Ngày Trả],
                    pt.MaNV AS MaNV,
                    h.MaKH AS MaKH,
                    nv.HoTen AS [Nhân Viên],
                    kh.HoTen AS [Khách Hàng],
                    pt.LyDo AS [Lý Do],
                    pt.TrangThai AS [Trạng Thái]
                FROM dbo.PhieuTraHang pt
                LEFT JOIN dbo.HoaDon h ON h.MaHD = pt.MaHD
                LEFT JOIN dbo.NhanVien nv ON nv.MaNV = pt.MaNV
                LEFT JOIN dbo.KhachHang kh ON kh.MaKH = h.MaKH
                ORDER BY pt.NgayTra DESC;";

            using (var conn = db.CreateConnection())
            using (var adapter = new SqlDataAdapter(sql, conn))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // 2. Lấy chi tiết sản phẩm của một phiếu trả
        public DataTable GetChiTietPhieuTra(string maPhieuTra)
        {
            const string sql = @"
                SELECT
                    ct.MaPhieuTra,
                    ct.MaSP,
                    sp.TenSanPham,
                    ct.MaDVT,
                    dv.TenDV,
                    ct.SoLuongTra,
                    ct.DonGiaHoan
                FROM dbo.ChiTietPhieuTraHang ct
                LEFT JOIN dbo.SanPham sp ON sp.MaSP = ct.MaSP
                LEFT JOIN dbo.DonViTinh dv ON dv.MaDVT = ct.MaDVT
                WHERE ct.MaPhieuTra = @MaPhieuTra;";

            using (var conn = db.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaPhieuTra", SqlDbType.VarChar, 30)
                    .Value = maPhieuTra;

                var dt = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
        }

        // 3. Danh sách nhân viên để lọc
        public DataTable GetNhanVienList()
        {
            const string sql = @"
                SELECT MaNV, HoTen
                FROM dbo.NhanVien
                ORDER BY HoTen;";

            using (var conn = db.CreateConnection())
            using (var adapter = new SqlDataAdapter(sql, conn))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // 4. Danh sách khách hàng để lọc
        public DataTable GetKhachHangList()
        {
            const string sql = @"
                SELECT MaKH, HoTen
                FROM dbo.KhachHang
                ORDER BY HoTen;";

            using (var conn = db.CreateConnection())
            using (var adapter = new SqlDataAdapter(sql, conn))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // 5. Lọc phiếu trả theo nhân viên
        public DataTable LocTheoNhanVien(string maNV)
        {
            const string sql = @"
                SELECT
                    pt.MaPhieuTra AS [Mã Phiếu Trả],
                    pt.MaHD AS [Mã Hóa Đơn],
                    pt.NgayTra AS [Ngày Trả],
                    pt.MaNV AS MaNV,
                    h.MaKH AS MaKH,
                    nv.HoTen AS [Nhân Viên],
                    kh.HoTen AS [Khách Hàng],
                    pt.LyDo AS [Lý Do],
                    pt.TrangThai AS [Trạng Thái]
                FROM dbo.PhieuTraHang pt
                LEFT JOIN dbo.HoaDon h ON h.MaHD = pt.MaHD
                LEFT JOIN dbo.NhanVien nv ON nv.MaNV = pt.MaNV
                LEFT JOIN dbo.KhachHang kh ON kh.MaKH = h.MaKH
                WHERE pt.MaNV = @MaNV
                ORDER BY pt.NgayTra DESC;";

            using (var conn = db.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 20).Value = maNV;

                var dt = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
        }

        // 6. Lọc phiếu trả theo khách hàng
        public DataTable LocTheoKhachHang(string maKH)
        {
            const string sql = @"
                SELECT
                    pt.MaPhieuTra AS [Mã Phiếu Trả],
                    pt.MaHD AS [Mã Hóa Đơn],
                    pt.NgayTra AS [Ngày Trả],
                    pt.MaNV AS MaNV,
                    h.MaKH AS MaKH,
                    nv.HoTen AS [Nhân Viên],
                    kh.HoTen AS [Khách Hàng],
                    pt.LyDo AS [Lý Do],
                    pt.TrangThai AS [Trạng Thái]
                FROM dbo.PhieuTraHang pt
                LEFT JOIN dbo.HoaDon h ON h.MaHD = pt.MaHD
                LEFT JOIN dbo.NhanVien nv ON nv.MaNV = pt.MaNV
                LEFT JOIN dbo.KhachHang kh ON kh.MaKH = h.MaKH
                WHERE h.MaKH = @MaKH
                ORDER BY pt.NgayTra DESC;";

            using (var conn = db.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20).Value = maKH;

                var dt = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
        }

        // 7. Lọc phiếu trả theo ngày
        public DataTable LocTheoNgayTra(DateTime ngayTra)
        {
            const string sql = @"
                SELECT
                    pt.MaPhieuTra AS [Mã Phiếu Trả],
                    pt.MaHD AS [Mã Hóa Đơn],
                    pt.NgayTra AS [Ngày Trả],
                    pt.MaNV AS MaNV,
                    h.MaKH AS MaKH,
                    nv.HoTen AS [Nhân Viên],
                    kh.HoTen AS [Khách Hàng],
                    pt.LyDo AS [Lý Do],
                    pt.TrangThai AS [Trạng Thái]
                FROM dbo.PhieuTraHang pt
                LEFT JOIN dbo.HoaDon h ON h.MaHD = pt.MaHD
                LEFT JOIN dbo.NhanVien nv ON nv.MaNV = pt.MaNV
                LEFT JOIN dbo.KhachHang kh ON kh.MaKH = h.MaKH
                WHERE pt.NgayTra >= @NgayTra
                  AND pt.NgayTra < DATEADD(day, 1, @NgayTra)
                ORDER BY pt.NgayTra DESC;";

            using (var conn = db.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@NgayTra", SqlDbType.Date).Value =
                    ngayTra.Date;

                var dt = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
        }

        // 8. Xóa phiếu trả và chi tiết trong một transaction
        public void XoaPhieuTra(string maPhieuTra)
        {
            using (var conn = db.CreateConnection())
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Khóa phiếu trả để tránh xóa đồng thời.
                        const string sqlCheck = @"
                            SELECT COUNT(1)
                            FROM dbo.PhieuTraHang WITH (UPDLOCK, HOLDLOCK)
                            WHERE MaPhieuTra = @MaPhieuTra;";

                        using (var cmd = new SqlCommand(
                            sqlCheck, conn, tran))
                        {
                            cmd.Parameters.Add("@MaPhieuTra",
                                SqlDbType.VarChar, 30).Value = maPhieuTra;

                            if (Convert.ToInt32(cmd.ExecuteScalar()) != 1)
                                throw new Exception("Phiếu trả hàng không tồn tại.");
                        }

                        // Trừ lại lượng hàng đã cộng khi trả hàng,
                        // chỉ áp dụng với phiếu đã xác nhận.
                        const string sqlHoanKho = @"
                            UPDATE sp
                            SET sp.SoLuongTong =
                                sp.SoLuongTong - ct.SoLuongTra * d.SoLuongQuyDoi
                            FROM dbo.SanPham sp
                            INNER JOIN dbo.ChiTietPhieuTraHang ct
                                ON ct.MaSP = sp.MaSP
                            INNER JOIN dbo.SanPham_DonViTinh d
                                ON d.MaSP = ct.MaSP
                               AND d.MaDVT = ct.MaDVT
                            INNER JOIN dbo.PhieuTraHang pt
                                ON pt.MaPhieuTra = ct.MaPhieuTra
                            WHERE ct.MaPhieuTra = @MaPhieuTra
                              AND pt.TrangThai = N'DaXacNhan';";

                        using (var cmd = new SqlCommand(
                            sqlHoanKho, conn, tran))
                        {
                            cmd.Parameters.Add("@MaPhieuTra",
                                SqlDbType.VarChar, 30).Value = maPhieuTra;
                            cmd.ExecuteNonQuery();
                        }

                        const string sqlXoaChiTiet = @"
                            DELETE FROM dbo.ChiTietPhieuTraHang
                            WHERE MaPhieuTra = @MaPhieuTra;";

                        using (var cmd = new SqlCommand(
                            sqlXoaChiTiet, conn, tran))
                        {
                            cmd.Parameters.Add("@MaPhieuTra",
                                SqlDbType.VarChar, 30).Value = maPhieuTra;
                            cmd.ExecuteNonQuery();
                        }

                        const string sqlXoaPhieu = @"
                            DELETE FROM dbo.PhieuTraHang
                            WHERE MaPhieuTra = @MaPhieuTra;";

                        using (var cmd = new SqlCommand(
                            sqlXoaPhieu, conn, tran))
                        {
                            cmd.Parameters.Add("@MaPhieuTra",
                                SqlDbType.VarChar, 30).Value = maPhieuTra;
                            cmd.ExecuteNonQuery();
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
    }
}
