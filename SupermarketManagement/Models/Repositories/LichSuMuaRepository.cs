using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;
using System.Globalization;

namespace SupermarketManagement.Models.Repositories
{
    public class LichSuMuaRepository
    {
        private DbConection _db = new DbConection();

        // CSDL mới: SanPham không còn DonGiaBan.
        // Giá nằm ở SanPham_DonViTinh (DonGiaBanLe), khóa theo (MaDVT, MaSP).
        // ChiTietHoaDon có MaDVT nên JOIN theo cả MaSP và MaDVT.
        private const string SelectTongTien = @"
                SELECT 
                    hd.MaHD,
                    hd.NgayMua AS [Ngày Bán],
                    kh.HoTen AS [Tên Khách Hàng],
                    nv.HoTen AS [Tên Nhân Viên],
                    ISNULL(SUM(ct.SoLuongBan * d.DonGiaBanLe), 0) AS [Tổng Tiền]";

        private const string FromHoaDon = @"
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT";

        private const string GroupByHoaDon = @"
                GROUP BY hd.MaHD, hd.NgayMua, kh.HoTen, nv.HoTen";

        private static string Esc(string s)
        {
            return (s ?? "").Replace("'", "''");
        }

        // 1. Lấy toàn bộ danh sách Hóa Đơn
        public DataTable GetDanhSachHD()
        {
            string sql = SelectTongTien + FromHoaDon + GroupByHoaDon;
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

        // 4. Lấy Chi Tiết 1 Hóa Đơn (có thêm cột Đơn Vị Tính, giá theo đơn vị đã bán)
        public DataTable GetChiTietHD(string maHD)
        {
            string sql = $@"
                SELECT 
                    ct.MaSP AS [Mã SP],
                    sp.TenSanPham AS [Tên Sản Phẩm],
                    dv.TenDV AS [Đơn Vị Tính],
                    ct.SoLuongBan AS [Số Lượng],
                    d.DonGiaBanLe AS [Đơn Giá],
                    (ct.SoLuongBan * d.DonGiaBanLe) AS [Thành Tiền]
                FROM ChiTietHoaDon ct
                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                INNER JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                INNER JOIN DonViTinh dv ON dv.MaDVT = ct.MaDVT
                WHERE ct.MaHD = '{Esc(maHD)}'";

            return _db.GetListData(sql);
        }

        // 5. Tìm kiếm Hóa Đơn theo Mã
        public DataTable TimKiemHoaDonByMa(string maHD)
        {
            string sql = SelectTongTien + FromHoaDon + $@"
                WHERE hd.MaHD LIKE '%{Esc((maHD ?? "").Trim())}%'" + GroupByHoaDon;

            return _db.GetListData(sql);
        }

        // 6. Lọc riêng theo Nhân Viên
        public DataTable LocTheoNhanVien(string maNV)
        {
            string sql = SelectTongTien + FromHoaDon + $@"
                WHERE hd.MaNV = '{Esc(maNV)}'" + GroupByHoaDon;

            return _db.GetListData(sql);
        }

        // 7. Lọc riêng theo Khách Hàng
        public DataTable LocTheoKhachHang(string maKH)
        {
            string sql = SelectTongTien + FromHoaDon + $@"
                WHERE hd.MaKH = '{Esc(maKH)}'" + GroupByHoaDon;

            return _db.GetListData(sql);
        }

        // 8. Lọc riêng theo Ngày Bán
        public DataTable LocTheoNgayBan(DateTime ngayBan)
        {
            string ngay = ngayBan.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            string sql = SelectTongTien + FromHoaDon + $@"
                WHERE CAST(hd.NgayMua AS DATE) = '{ngay}'" + GroupByHoaDon;

            return _db.GetListData(sql);
        }

        // 9. Lấy thông tin chung của 1 Hóa Đơn theo MaHD (Dùng cho Form In / Xem chi tiết)
        public DataRow GetThongTinChungHoaDon(string maHD)
        {
            string sql = $@"
                SELECT 
                    hd.MaHD,
                    hd.NgayMua,
                    ISNULL(SUM(ct.SoLuongBan * d.DonGiaBanLe), 0) AS TongTien,
                    ISNULL(kh.HoTen, N'Khách lẻ') AS TenKhachHang,
                    ISNULL(kh.SoDienthoai, '') AS SDTKhachHang,
                    ISNULL(nv.HoTen, N'Hệ thống') AS TenNhanVien
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                WHERE hd.MaHD = '{Esc(maHD)}'
                GROUP BY hd.MaHD, hd.NgayMua, kh.HoTen, kh.SoDienthoai, nv.HoTen";

            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        // 10. Xóa hóa đơn (Tự động hoàn trả số lượng vào kho, xóa ChiTietHoaDon và HoaDon)
        public bool XoaHoaDon(string maHD)
        {
            string sql = $@"
                SET XACT_ABORT ON;
                BEGIN TRAN;

                -- 1. Hoàn lại số lượng tồn kho cho các sản phẩm trong hóa đơn
                UPDATE sp
                SET sp.SoLuongTong = sp.SoLuongTong + (ct.SoLuongBan * ISNULL(d.SoLuongQuyDoi, 1))
                FROM SanPham sp
                INNER JOIN ChiTietHoaDon ct ON sp.MaSP = ct.MaSP
                LEFT JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                WHERE ct.MaHD = '{Esc(maHD)}';

                -- 2. Xóa dữ liệu trong bảng ChiTietHoaDon
                DELETE FROM ChiTietHoaDon WHERE MaHD = '{Esc(maHD)}';

                -- 3. Xóa bản ghi trong bảng HoaDon
                DELETE FROM HoaDon WHERE MaHD = '{Esc(maHD)}';

                COMMIT TRAN;";

            _db.DataChange(sql);
            return true;
        }
    }
}