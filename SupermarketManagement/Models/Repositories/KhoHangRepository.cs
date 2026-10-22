using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Models.Repositories
{
    public class KhoHangRepository
    {
        private DbConection _db = new DbConection();

        //phần danh mục

        public DataTable GetDanhMuc()
        {
            string sql = "SELECT MaDM, TenDanhMuc FROM DanhMuc";
            return _db.GetListData(sql);
        }

        public void ThemDanhMuc(string maDM, string tenDanhMuc)
        {
            string sql = $"INSERT INTO DanhMuc (MaDM, TenDanhMuc) VALUES ({maDM}, N'{tenDanhMuc}')";
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

        // phần hàng háo

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
                LEFT JOIN DanhMuc dm ON sp.MaDM = dm.MaDM
                WHERE sp.TrangThai = 1";
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

        public void ThemSanPham(int maSP, string tenSP, int soLuong, double trongLuong, decimal giaNhap, decimal giaBan, string moTa, int maDM, int maNV)
        {

            // 1. Lệnh thêm Sản Phẩm
            string sql = $@"
        INSERT INTO SanPham (MaSP, TenSanPham, SoLuong, TrongLuong, DonGiaNhap, DonGiaBan, UrlImage, MoTa, MaDM, MaKM, MaNV)
        VALUES ({maSP}, N'{tenSP}', {soLuong}, {trongLuong}, {giaNhap}, {giaBan}, '', N'{moTa}', {maDM}, 1, {maNV});
    ";

            // 2. Xử lý tạo Hóa đơn nếu có nhập số lượng > 0
            if (soLuong > 0)
            {
                // TẠO MÃ PHIẾU TỰ ĐỘNG
                // Dùng ngày giờ (ví dụ: PNH2210262140) để làm mã tạm đảm bảo không bao giờ bị trùng
                string maPNHMoi = TaoMaPhieuNhapMoi();

                // Nối thêm lệnh INSERT có truyền rành mạch mã PNHMoi vào cả 2 bảng
                sql += $@"
            INSERT INTO PhieuNhapHang (MaPNH, NgayNhap, MaNV) 
            VALUES ('{maPNHMoi}', GETDATE(), {maNV});

            INSERT INTO ChiTietPhieuNhapHang (MaPNH, MaSP, SoLuongNhap, DonGiaNhap) 
            VALUES ('{maPNHMoi}', {maSP}, {soLuong}, {giaNhap});
        ";
            }

            // 3. Thực thi toàn bộ chuỗi
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
            string sql = $"UPDATE SanPham SET TrangThai = 0 WHERE MaSP = {maSP}";
            MessageBox.Show(sql);
            _db.DataChange(sql);
        }

        // phần hóa đơn nhập

        public DataTable GetPhieuNhapHang()
        {
            string sql = @"
               SELECT 
                    pn.MaPNH, 
                    pn.NgayNhap, 
                    sp.TenSanPham AS MatHang, 
                    ct.SoLuongNhap,       -- Lấy số lượng từ bảng Chi Tiết
                    ct.DonGiaNhap,    -- Lấy đơn giá từ bảng Chi Tiết
                    nv.HoTen AS NguoiNhap, 
                    (ct.SoLuongNhap * ct.DonGiaNhap) AS TongTien,
                    pn.MaNCC,
                    pn.MaNV
                FROM PhieuNhapHang pn
              
                INNER JOIN ChiTietPhieuNhapHang ct ON pn.MaPNH = ct.MaPNH
               
                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
              
                INNER JOIN NhanVien nv ON pn.MaNV = nv.MaNV
            ";

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

            string sqlChiTiet = $"DELETE FROM ChiTietPhieuNhapHang WHERE MaPNH = '{maPNH}'";
            _db.DataChange(sqlChiTiet);

            string sqlPhieu = $"DELETE FROM PhieuNhapHang WHERE MaPNH = '{maPNH}'";
            _db.DataChange(sqlPhieu);
        }

        public string GetMaPhieuNhapMoi()
        {

            string sql = "SELECT TOP 1 MaPNH FROM PhieuNhapHang ORDER BY MaPNH DESC";
            DataTable dt = _db.GetListData(sql);
            if (dt.Rows.Count > 0)
            {
                string maCu = dt.Rows[0][0].ToString();
                if (maCu.Length >= 6)
                {

                    int so = int.Parse(maCu.Substring(3)) + 1;
                    return "PNH" + so.ToString("D3");
                }
            }
            return "PNH001";
        }

        public string GetMaSanPhamMoi()
        {

            string sql = "SELECT ISNULL(MAX(CAST(MaSP AS INT)), 0) + 1 FROM SanPham";
            DataTable dt = _db.GetListData(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "1";
        }
        public string GetMaDanhMucMoi()
        {

            string sql = "SELECT ISNULL(MAX(MaDM), 0) + 1 FROM DanhMuc";
            DataTable dt = _db.GetListData(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "1";
        }
        public bool ThemHoaDonVaCapNhatKho(string maPNH, DateTime ngayNhap, int maNCC, int maNV, int maSP, int soLuong, decimal donGiaNhap, decimal tongTien)
        {
            try
            {
                string strDonGia = donGiaNhap.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string sql = $@"
            BEGIN TRAN;
            
            -- Đã xóa cột TongTien ra khỏi bảng PhieuNhapHang
            INSERT INTO PhieuNhapHang (MaPNH, NgayNhap, MaNCC, MaNV) 
            VALUES ('{maPNH}', '{ngayNhap:yyyy-MM-dd}', {maNCC}, {maNV});

            INSERT INTO ChiTietPhieuNhapHang (MaPNH, MaSP, SoLuongNhap, DonGiaNhap) 
            VALUES ('{maPNH}', {maSP}, {soLuong}, {strDonGia});

            UPDATE SanPham 
            SET SoLuong = SoLuong + {soLuong} 
            WHERE MaSP = {maSP};

            COMMIT TRAN;
        ";

                _db.DataChange(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi chi tiết từ SQL: " + ex.Message);
            }
        }
        private string TaoMaPhieuNhapMoi()
        {
            // Lấy mã phiếu nhập cuối cùng (lớn nhất) trong CSDL
            string sql = "SELECT TOP 1 MaPNH FROM PhieuNhapHang ORDER BY MaPNH DESC";

            // Giả sử hàm lấy dữ liệu của bạn trả về DataTable
            DataTable dt = _db.GetListData(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                string maCu = dt.Rows[0]["MaPNH"].ToString(); // Ví dụ lấy được: "PNH011"

                // Cắt bỏ 3 chữ cái đầu ("PNH"), giữ lại phần số ("011")
                string phanSoCu = maCu.Substring(3);

                if (int.TryParse(phanSoCu, out int soMoi))
                {
                    soMoi++; // Tăng lên 1 đơn vị thành 12
                             // D3 nghĩa là định dạng chuỗi luôn có 3 chữ số (012)
                    return "PNH" + soMoi.ToString("D3");
                }
            }

            // Nếu bảng PhieuNhapHang đang trống chưa có dòng nào
            return "PNH001";
        }
    }

}