using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class LichSuNhapRepository
    {
        private DbConection _db = new DbConection();

        // 1. Lấy toàn bộ danh sách Phiếu Nhập Hàng (Tính tổng tiền từ ChiTietPhieuNhapHang)
        public DataTable GetDanhSachPNH()
        {
            string sql = @"
                SELECT 
                    pnh.MaPNH AS [Mã PNH],
                    pnh.NgayNhap AS [Ngày Nhập],
                    ncc.TenNCC AS [Nhà Cung Cấp],
                    nv.HoTen AS [Nhân Viên Nhập],
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS [Tổng Tiền]
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH
                GROUP BY pnh.MaPNH, pnh.NgayNhap, ncc.TenNCC, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 2. Lấy danh sách Nhân Viên Nhập Kho (MaCV = '2')
        public DataTable GetNhanVienList()
        {
            string sql = "SELECT MaNV, HoTen FROM NhanVien WHERE MaCV = '3'";
            return _db.GetListData(sql);
        }

        // 3. Lấy danh sách Nhà Cung Cấp
        public DataTable GetNhaCungCapList()
        {
            string sql = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            return _db.GetListData(sql);
        }

        // 4. Lấy Chi Tiết 1 Phiếu Nhập Hàng theo MaPNH (Lấy DonGiaNhap từ ChiTietPhieuNhapHang)
        public DataTable GetChiTietPNH(string maPNH)
        {
            string sql = $@"
                SELECT 
                    ct.MaSP AS [Mã SP],
                    sp.TenSanPham AS [Tên Sản Phẩm],
                    ct.SoLuongNhap AS [Số Lượng],
                    ct.DonGiaNhap AS [Đơn Giá],
                    (ct.SoLuongNhap * ct.DonGiaNhap) AS [Thành Tiền]
                FROM ChiTietPhieuNhapHang ct
                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE ct.MaPNH = '{maPNH}'";

            return _db.GetListData(sql);
        }

        // 5. Tìm kiếm Phiếu Nhập Hàng theo Mã PNH
        public DataTable TimKiemPhieuNhapByMa(string maPNH)
        {
            string sql = $@"
                SELECT 
                    pnh.MaPNH AS [Mã PNH],
                    pnh.NgayNhap AS [Ngày Nhập],
                    ncc.TenNCC AS [Nhà Cung Cấp],
                    nv.HoTen AS [Nhân Viên Nhập],
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS [Tổng Tiền]
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH
                WHERE pnh.MaPNH LIKE '%{maPNH.Trim()}%'
                GROUP BY pnh.MaPNH, pnh.NgayNhap, ncc.TenNCC, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 6. Lọc riêng theo Nhân Viên
        public DataTable LocTheoNhanVien(string maNV)
        {
            string sql = $@"
                SELECT 
                    pnh.MaPNH AS [Mã PNH],
                    pnh.NgayNhap AS [Ngày Nhập],
                    ncc.TenNCC AS [Nhà Cung Cấp],
                    nv.HoTen AS [Nhân Viên Nhập],
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS [Tổng Tiền]
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH
                WHERE pnh.MaNV = '{maNV}'
                GROUP BY pnh.MaPNH, pnh.NgayNhap, ncc.TenNCC, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 7. Lọc riêng theo Nhà Cung Cấp
        public DataTable LocTheoNhaCungCap(string maNCC)
        {
            string sql = $@"
                SELECT 
                    pnh.MaPNH AS [Mã PNH],
                    pnh.NgayNhap AS [Ngày Nhập],
                    ncc.TenNCC AS [Nhà Cung Cấp],
                    nv.HoTen AS [Nhân Viên Nhập],
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS [Tổng Tiền]
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH
                WHERE pnh.MaNCC = '{maNCC}'
                GROUP BY pnh.MaPNH, pnh.NgayNhap, ncc.TenNCC, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 8. Lọc riêng theo Ngày Nhập
        public DataTable LocTheoNgayNhap(DateTime ngayNhap)
        {
            string sql = $@"
                SELECT 
                    pnh.MaPNH AS [Mã PNH],
                    pnh.NgayNhap AS [Ngày Nhập],
                    ncc.TenNCC AS [Nhà Cung Cấp],
                    nv.HoTen AS [Nhân Viên Nhập],
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS [Tổng Tiền]
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH
                WHERE CAST(pnh.NgayNhap AS DATE) = '{ngayNhap:yyyy-MM-dd}'
                GROUP BY pnh.MaPNH, pnh.NgayNhap, ncc.TenNCC, nv.HoTen";

            return _db.GetListData(sql);
        }

        // 9. Lấy thông tin chung của 1 Phiếu Nhập Hàng theo MaPNH (In / Xem chi tiết)
        public DataRow GetThongTinChungPhieuNhap(string maPNH)
        {
            string sql = $@"
                SELECT 
                    pnh.MaPNH,
                    pnh.NgayNhap,
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS TongGia,
                    ISNULL(ncc.TenNCC, N'Không xác định') AS TenNCC,
                    ISNULL(ncc.SDT, '') AS SDTNCC,
                    ISNULL(ncc.DiaChi, '') AS DiaChiNCC,
                    ISNULL(nv.HoTen, N'Hệ thống') AS TenNhanVien
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH
                WHERE pnh.MaPNH = '{maPNH}'
                GROUP BY pnh.MaPNH, pnh.NgayNhap, ncc.TenNCC, ncc.SDT, ncc.DiaChi, nv.HoTen";

            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}