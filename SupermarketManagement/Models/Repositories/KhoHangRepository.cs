using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class KhoHangRepository
    {
        private DbConection _db = new DbConection();

        // =================================================================
        // PHẦN 1: QUẢN LÝ DANH MỤC (Bảng DanhMuc: MaDM, TenDanhMuc)
        // =================================================================

        public DataTable GetDanhMuc()
        {
            string sql = "SELECT MaDM, TenDanhMuc FROM DanhMuc";
            return _db.GetListData(sql);
        }

        public void ThemDanhMuc(string tenDanhMuc)
        {
            // Nếu MaDM trong SQL của bạn là tự tăng (IDENTITY) thì chỉ cần truyền TenDanhMuc
            string sql = $"INSERT INTO DanhMuc (TenDanhMuc) VALUES (N'{tenDanhMuc}')";
            _db.DataChange(sql);
        }

        public void SuaDanhMuc(string maDM, string tenDanhMuc)
        {
            string sql = $"UPDATE DanhMuc SET TenDanhMuc = N'{tenDanhMuc}' WHERE MaDM = {maDM}";
            _db.DataChange(sql);
        }

        public void XoaDanhMuc(string maDM)
        {
            string sql = $"DELETE FROM DanhMuc WHERE MaDM = {maDM}";
            _db.DataChange(sql);
        }

        // =================================================================
        // PHẦN 2: QUẢN LÝ HÀNG HÓA (Bảng SanPham)
        // =================================================================

        public DataTable GetSanPham()
        {
            string sql = @"
                SELECT 
                    sp.MaSP, 
                    sp.TenSanPham, 
                    sp.SoLuong, 
                    sp.TrongLuong, 
                    sp.DonGiaNhap, 
                    sp.DonGiaBan, 
                    sp.MoTa, 
                    sp.MaDM,
                    dm.TenDanhMuc
                FROM SanPham sp
                LEFT JOIN DanhMuc dm ON sp.MaDM = dm.MaDM";
            return _db.GetListData(sql);
        }

        public DataTable TimKiemSanPham(string tuKhoa)
        {
            string sql = $@"
                SELECT 
                    sp.MaSP, 
                    sp.TenSanPham, 
                    sp.SoLuong, 
                    sp.TrongLuong, 
                    sp.DonGiaNhap, 
                    sp.DonGiaBan, 
                    sp.MoTa, 
                    sp.MaDM,
                    dm.TenDanhMuc
                FROM SanPham sp
                LEFT JOIN DanhMuc dm ON sp.MaDM = dm.MaDM
                WHERE sp.TenSanPham LIKE N'%{tuKhoa.Trim()}%'";
            return _db.GetListData(sql);
        }

        public void ThemSanPham(string tenSP, int soLuong, double trongLuong, decimal giaNhap, decimal giaBan, string moTa, int maDM, int maNV)
        {
            // Mặc định MaKM = 1 và UrlImage = '' để không bị lỗi thiếu cột khi thêm mới
            string sql = $@"
                INSERT INTO SanPham (TenSanPham, SoLuong, TrongLuong, DonGiaNhap, DonGiaBan, UrlImage, MoTa, MaDM, MaKM, MaNV)
                VALUES (N'{tenSP}', {soLuong}, {trongLuong}, {giaNhap}, {giaBan}, '', N'{moTa}', {maDM}, 1, {maNV})";
            _db.DataChange(sql);
        }

        public void SuaSanPham(int maSP, string tenSP, int soLuong, double trongLuong, decimal giaNhap, decimal giaBan, string moTa, int maDM)
        {
            string sql = $@"
                UPDATE SanPham 
                SET TenSanPham = N'{tenSP}', 
                    SoLuong = {soLuong}, 
                    TrongLuong = {trongLuong}, 
                    DonGiaNhap = {giaNhap}, 
                    DonGiaBan = {giaBan}, 
                    MoTa = N'{moTa}', 
                    MaDM = {maDM}
                WHERE MaSP = {maSP}";
            _db.DataChange(sql);
        }

        public void XoaSanPham(int maSP)
        {
            string sql = $"DELETE FROM SanPham WHERE MaSP = {maSP}";
            _db.DataChange(sql);
        }

        // =================================================================
        // PHẦN 3: QUẢN LÝ HÓA ĐƠN NHẬP (Bảng PhieuNhapHang)
        // =================================================================

        public DataTable GetPhieuNhapHang()
        {
            string sql = @"
                SELECT 
                    pnh.MaPNH,
                    pnh.NgayNhap,
                    pnh.MaNCC,
                    ncc.TenNCC,
                    pnh.MaNV,
                    nv.HoTen AS NguoiNhap,
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS TongTien
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH
                GROUP BY pnh.MaPNH, pnh.NgayNhap, pnh.MaNCC, ncc.TenNCC, pnh.MaNV, nv.HoTen";
            return _db.GetListData(sql);
        }

        public DataTable GetNhaCungCap()
        {
            string sql = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            return _db.GetListData(sql);
        }

        public DataTable GetNhanVien()
        {
            string sql = "SELECT MaNV, HoTen FROM NhanVien";
            return _db.GetListData(sql);
        }

        public void ThemPhieuNhap(string maPNH, DateTime ngayNhap, int maNV, int maNCC)
        {
            string ngayFormat = ngayNhap.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $@"
                INSERT INTO PhieuNhapHang (MaPNH, NgayNhap, MaNV, MaNCC) 
                VALUES ('{maPNH}', '{ngayFormat}', {maNV}, {maNCC})";
            _db.DataChange(sql);
        }

        public void SuaPhieuNhap(string maPNH, DateTime ngayNhap, int maNV, int maNCC)
        {
            string ngayFormat = ngayNhap.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $@"
                UPDATE PhieuNhapHang 
                SET NgayNhap = '{ngayFormat}', 
                    MaNV = {maNV}, 
                    MaNCC = {maNCC} 
                WHERE MaPNH = '{maPNH}'";
            _db.DataChange(sql);
        }

        public void XoaPhieuNhap(string maPNH)
        {
            // Xóa chi tiết phiếu nhập trước (nếu có) để tránh lỗi khóa ngoại, sau đó xóa phiếu nhập
            string sqlChiTiet = $"DELETE FROM ChiTietPhieuNhapHang WHERE MaPNH = '{maPNH}'";
            _db.DataChange(sqlChiTiet);

            string sqlPhieu = $"DELETE FROM PhieuNhapHang WHERE MaPNH = '{maPNH}'";
            _db.DataChange(sqlPhieu);
        }
    }
}