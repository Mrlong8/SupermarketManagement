using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class LichSuTraHangRepository
    {
        private DbConection _db = new DbConection();

        // Lấy danh sách tất cả phiếu trả hàng
        public DataTable GetDanhSachPhieuTra()
        {
            string sql = @"
                SELECT 
                    pth.MaPhieuTra AS [Mã Phiếu Trả],
                    pth.MaHD AS [Mã Hóa Đơn],
                    pth.NgayTra AS [Ngày Trả],
                    nv.HoTen AS [Nhân Viên Lập],
                    kh.HoTen AS [Khách Hàng],
                    pth.LyDo AS [Lý Do],
                    pth.TrangThai AS [Trạng Thái],
                    ISNULL(SUM(ct.SoLuongTra * ct.DonGiaHoan), 0) AS [Tổng Tiền Hoàn]
                FROM PhieuTraHang pth
                LEFT JOIN NhanVien nv ON pth.MaNV = nv.MaNV
                LEFT JOIN HoaDon hd ON pth.MaHD = hd.MaHD
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN ChiTietPhieuTraHang ct ON pth.MaPhieuTra = ct.MaPhieuTra
                GROUP BY pth.MaPhieuTra, pth.MaHD, pth.NgayTra, nv.HoTen, kh.HoTen, pth.LyDo, pth.TrangThai
                ORDER BY pth.NgayTra DESC";

            return _db.GetListData(sql);
        }

        // Lấy chi tiết của 1 phiếu trả hàng
        public DataTable GetChiTietPhieuTra(string maPhieuTra)
        {
            string sql = $@"
                SELECT 
                    sp.TenSanPham AS [Tên Sản Phẩm],
                    dvt.TenDV AS [Đơn Vị Tính],
                    ct.SoLuongTra AS [Số Lượng Trả],
                    ct.DonGiaHoan AS [Đơn Giá Hoàn],
                    (ct.SoLuongTra * ct.DonGiaHoan) AS [Thành Tiền]
                FROM ChiTietPhieuTraHang ct
                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                INNER JOIN DonViTinh dvt ON ct.MaDVT = dvt.MaDVT
                WHERE ct.MaPhieuTra = '{maPhieuTra}'";

            return _db.GetListData(sql);
        }

        // Lấy danh sách Nhân viên
        public DataTable GetNhanVienList()
        {
            string sql = "SELECT MaNV, HoTen FROM NhanVien";
            return _db.GetListData(sql);
        }

        // Lấy danh sách Khách hàng
        public DataTable GetKhachHangList()
        {
            string sql = "SELECT MaKH, HoTen FROM KhachHang";
            return _db.GetListData(sql);
        }

        // Lọc phiếu trả hàng theo Nhân viên
        public DataTable LocTheoNhanVien(string maNV)
        {
            string sql = $@"
                SELECT 
                    pth.MaPhieuTra AS [Mã Phiếu Trả],
                    pth.MaHD AS [Mã Hóa Đơn],
                    pth.NgayTra AS [Ngày Trả],
                    nv.HoTen AS [Nhân Viên Lập],
                    kh.HoTen AS [Khách Hàng],
                    pth.LyDo AS [Lý Do],
                    pth.TrangThai AS [Trạng Thái],
                    ISNULL(SUM(ct.SoLuongTra * ct.DonGiaHoan), 0) AS [Tổng Tiền Hoàn]
                FROM PhieuTraHang pth
                LEFT JOIN NhanVien nv ON pth.MaNV = nv.MaNV
                LEFT JOIN HoaDon hd ON pth.MaHD = hd.MaHD
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN ChiTietPhieuTraHang ct ON pth.MaPhieuTra = ct.MaPhieuTra
                WHERE pth.MaNV = '{maNV}'
                GROUP BY pth.MaPhieuTra, pth.MaHD, pth.NgayTra, nv.HoTen, kh.HoTen, pth.LyDo, pth.TrangThai
                ORDER BY pth.NgayTra DESC";

            return _db.GetListData(sql);
        }

        // Lọc phiếu trả hàng theo Khách hàng
        public DataTable LocTheoKhachHang(string maKH)
        {
            string sql = $@"
                SELECT 
                    pth.MaPhieuTra AS [Mã Phiếu Trả],
                    pth.MaHD AS [Mã Hóa Đơn],
                    pth.NgayTra AS [Ngày Trả],
                    nv.HoTen AS [Nhân Viên Lập],
                    kh.HoTen AS [Khách Hàng],
                    pth.LyDo AS [Lý Do],
                    pth.TrangThai AS [Trạng Thái],
                    ISNULL(SUM(ct.SoLuongTra * ct.DonGiaHoan), 0) AS [Tổng Tiền Hoàn]
                FROM PhieuTraHang pth
                LEFT JOIN NhanVien nv ON pth.MaNV = nv.MaNV
                LEFT JOIN HoaDon hd ON pth.MaHD = hd.MaHD
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN ChiTietPhieuTraHang ct ON pth.MaPhieuTra = ct.MaPhieuTra
                WHERE hd.MaKH = '{maKH}'
                GROUP BY pth.MaPhieuTra, pth.MaHD, pth.NgayTra, nv.HoTen, kh.HoTen, pth.LyDo, pth.TrangThai
                ORDER BY pth.NgayTra DESC";

            return _db.GetListData(sql);
        }

        // Lọc phiếu trả hàng theo Ngày
        public DataTable LocTheoNgayTra(DateTime ngayTra)
        {
            string sql = $@"
                SELECT 
                    pth.MaPhieuTra AS [Mã Phiếu Trả],
                    pth.MaHD AS [Mã Hóa Đơn],
                    pth.NgayTra AS [Ngày Trả],
                    nv.HoTen AS [Nhân Viên Lập],
                    kh.HoTen AS [Khách Hàng],
                    pth.LyDo AS [Lý Do],
                    pth.TrangThai AS [Trạng Thái],
                    ISNULL(SUM(ct.SoLuongTra * ct.DonGiaHoan), 0) AS [Tổng Tiền Hoàn]
                FROM PhieuTraHang pth
                LEFT JOIN NhanVien nv ON pth.MaNV = nv.MaNV
                LEFT JOIN HoaDon hd ON pth.MaHD = hd.MaHD
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN ChiTietPhieuTraHang ct ON pth.MaPhieuTra = ct.MaPhieuTra
                WHERE CAST(pth.NgayTra AS DATE) = '{ngayTra:yyyy-MM-dd}'
                GROUP BY pth.MaPhieuTra, pth.MaHD, pth.NgayTra, nv.HoTen, kh.HoTen, pth.LyDo, pth.TrangThai
                ORDER BY pth.NgayTra DESC";

            return _db.GetListData(sql);
        }

        // Xóa phiếu trả hàng và các chi tiết phiếu trả liên quan
        public void XoaPhieuTra(string maPhieuTra)
        {
            string sqlDeleteDetail = $"DELETE FROM ChiTietPhieuTraHang WHERE MaPhieuTra = '{maPhieuTra}'";
            string sqlDeleteHeader = $"DELETE FROM PhieuTraHang WHERE MaPhieuTra = '{maPhieuTra}'";

            _db.ExecuteNonQuery(sqlDeleteDetail);
            _db.ExecuteNonQuery(sqlDeleteHeader);
        }
    }
}