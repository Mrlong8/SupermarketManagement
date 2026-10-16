using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class LichSuMuaRepository
    {
        private DbConection _db = new DbConection();

        // 1. Lấy toàn bộ danh sách Hóa Đơn (Tính Tổng Tiền bằng SUM của ChiTietHoaDon * SanPham)
        public DataTable GetDanhSachHD()
        {
            string sql = @"
                SELECT 
                    hd.MaHD,
                    hd.NgayMua AS [Ngày Bán],
                    kh.HoTen AS [Tên Khách Hàng],
                    nv.HoTen AS [Tên Nhân Viên],
                    ISNULL(SUM(ct.SoLuongBan * sp.DonGiaBan), 0) AS [Tổng Tiền]
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                GROUP BY hd.MaHD, hd.NgayMua, kh.HoTen, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 2. Lấy danh sách Nhân Viên Bán Hàng (MaCV = '2')
        public DataTable GetNhanVienList()
        {
            string sql = "SELECT MaNV, HoTen FROM NhanVien WHERE MaCV = '2'";
            return _db.GetListData(sql);
        }

        // 3. Lấy danh sách Khách Hàng
        public DataTable GetKhachHangList()
        {
            string sql = "SELECT MaKH, HoTen FROM KhachHang";
            return _db.GetListData(sql);
        }

        // 4. Lấy Chi Tiết 1 Hóa Đơn (Lấy DonGiaBan từ bảng SanPham)
        public DataTable GetChiTietHD(string maHD)
        {
            string sql = $@"
                SELECT 
                    ct.MaSP AS [Mã SP],
                    sp.TenSanPham AS [Tên Sản Phẩm],
                    ct.SoLuongBan AS [Số Lượng],
                    sp.DonGiaBan AS [Đơn Giá],
                    (ct.SoLuongBan * sp.DonGiaBan) AS [Thành Tiền]
                FROM ChiTietHoaDon ct
                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE ct.MaHD = '{maHD}'";

            return _db.GetListData(sql);
        }

        // 5. Tìm kiếm Hóa Đơn theo Mã
        public DataTable TimKiemHoaDonByMa(string maHD)
        {
            string sql = $@"
                SELECT 
                    hd.MaHD,
                    hd.NgayMua AS [Ngày Bán],
                    kh.HoTen AS [Tên Khách Hàng],
                    nv.HoTen AS [Tên Nhân Viên],
                    ISNULL(SUM(ct.SoLuongBan * sp.DonGiaBan), 0) AS [Tổng Tiền]
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE hd.MaHD LIKE '%{maHD.Trim()}%'
                GROUP BY hd.MaHD, hd.NgayMua, kh.HoTen, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 6. Lọc riêng theo Nhân Viên
        public DataTable LocTheoNhanVien(string maNV)
        {
            string sql = $@"
                SELECT 
                    hd.MaHD,
                    hd.NgayMua AS [Ngày Bán],
                    kh.HoTen AS [Tên Khách Hàng],
                    nv.HoTen AS [Tên Nhân Viên],
                    ISNULL(SUM(ct.SoLuongBan * sp.DonGiaBan), 0) AS [Tổng Tiền]
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE hd.MaNV = '{maNV}'
                GROUP BY hd.MaHD, hd.NgayMua, kh.HoTen, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 7. Lọc riêng theo Khách Hàng
        public DataTable LocTheoKhachHang(string maKH)
        {
            string sql = $@"
                SELECT 
                    hd.MaHD,
                    hd.NgayMua AS [Ngày Bán],
                    kh.HoTen AS [Tên Khách Hàng],
                    nv.HoTen AS [Tên Nhân Viên],
                    ISNULL(SUM(ct.SoLuongBan * sp.DonGiaBan), 0) AS [Tổng Tiền]
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE hd.MaKH = '{maKH}'
                GROUP BY hd.MaHD, hd.NgayMua, kh.HoTen, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 8. Lọc riêng theo Ngày Bán
        public DataTable LocTheoNgayBan(DateTime ngayBan)
        {
            string sql = $@"
                SELECT 
                    hd.MaHD,
                    hd.NgayMua AS [Ngày Bán],
                    kh.HoTen AS [Tên Khách Hàng],
                    nv.HoTen AS [Tên Nhân Viên],
                    ISNULL(SUM(ct.SoLuongBan * sp.DonGiaBan), 0) AS [Tổng Tiền]
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE CAST(hd.NgayMua AS DATE) = '{ngayBan:yyyy-MM-dd}'
                GROUP BY hd.MaHD, hd.NgayMua, kh.HoTen, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 9. Lấy thông tin chung của 1 Hóa Đơn theo MaHD (Dùng cho Form In / Xem chi tiết)
        public DataRow GetThongTinChungHoaDon(string maHD)
        {
            string sql = $@"
                SELECT 
                    hd.MaHD,
                    hd.NgayMua,
                    ISNULL(SUM(ct.SoLuongBan * sp.DonGiaBan), 0) AS TongTien,
                    ISNULL(kh.HoTen, N'Khách lẻ') AS TenKhachHang,
                    ISNULL(kh.SoDienthoai, '') AS SDTKhachHang,
                    ISNULL(nv.HoTen, N'Hệ thống') AS TenNhanVien
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE hd.MaHD = '{maHD}'
                GROUP BY hd.MaHD, hd.NgayMua, kh.HoTen, kh.SoDienthoai, nv.HoTen";

            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}