using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class ThongKeRepository
    {
        private DbConection _db = new DbConection();

        // 1. Thống kê Doanh Thu theo từng ngày trong Tháng
        // Giá bán lấy theo đúng đơn vị tính đã bán (SanPham_DonViTinh.DonGiaBanLe),
        // vì SanPham không còn cột DonGiaBan.
        public DataTable GetDoanhThuTheoNgayInThang(int thang, int nam)
        {
            string sql = $@"
                WITH NgayTrongThang AS (
                    SELECT CAST('{nam}-{thang:D2}-01' AS DATE) AS Ngay
                    UNION ALL
                    SELECT DATEADD(DAY, 1, Ngay)
                    FROM NgayTrongThang
                    WHERE DATEADD(DAY, 1, Ngay) <= EOMONTH('{nam}-{thang:D2}-01')
                )
                SELECT 
                    DAY(ntt.Ngay) AS [Ngay],
                    ISNULL(SUM(ct.SoLuongBan * d.DonGiaBanLe), 0) AS [DoanhThu]
                FROM NgayTrongThang ntt
                LEFT JOIN HoaDon hd ON CAST(hd.NgayMua AS DATE) = ntt.Ngay
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                GROUP BY ntt.Ngay
                ORDER BY ntt.Ngay ASC
                OPTION (MAXRECURSION 31)";

            return _db.GetListData(sql);
        }

        // 2. Thống kê Vốn Nhập Hàng theo từng ngày trong cùng Tháng
        // DonGiaNhap trong ChiTietPhieuNhapHang là giá của 1 đơn vị nhập (VD: 1 thùng),
        // nên SoLuongNhap * DonGiaNhap vẫn đúng, không cần nhân quy đổi.
        public DataTable GetVonNhapTheoNgayInThang(int thang, int nam)
        {
            string sql = $@"
                WITH NgayTrongThang AS (
                    SELECT CAST('{nam}-{thang:D2}-01' AS DATE) AS Ngay
                    UNION ALL
                    SELECT DATEADD(DAY, 1, Ngay)
                    FROM NgayTrongThang
                    WHERE DATEADD(DAY, 1, Ngay) <= EOMONTH('{nam}-{thang:D2}-01')
                )
                SELECT 
                    DAY(ntt.Ngay) AS [Ngay],
                    ISNULL(SUM(ctpn.SoLuongNhap * ctpn.DonGiaNhap), 0) AS [VonNhap]
                FROM NgayTrongThang ntt
                LEFT JOIN PhieuNhapHang pn ON CAST(pn.NgayNhap AS DATE) = ntt.Ngay
                LEFT JOIN ChiTietPhieuNhapHang ctpn ON pn.MaPNH = ctpn.MaPNH
                GROUP BY ntt.Ngay
                ORDER BY ntt.Ngay ASC
                OPTION (MAXRECURSION 31)";

            return _db.GetListData(sql);
        }

        // 3. Tổng Doanh Thu cả năm
        public decimal GetTongDoanhThuNam(int nam)
        {
            string sql = $@"
                SELECT ISNULL(SUM(ct.SoLuongBan * d.DonGiaBanLe), 0) AS TongDoanhThu
                FROM HoaDon hd
                INNER JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                INNER JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                WHERE hd.NgayMua >= '{nam}-01-01' AND hd.NgayMua < '{nam + 1}-01-01'";

            return LayGiaTriDau(_db.GetListData(sql));
        }

        // 4. Tổng Vốn Nhập cả năm
        public decimal GetTongVonNhapNam(int nam)
        {
            string sql = $@"
                SELECT ISNULL(SUM(ctpn.SoLuongNhap * ctpn.DonGiaNhap), 0) AS TongVonNhap
                FROM PhieuNhapHang pn
                INNER JOIN ChiTietPhieuNhapHang ctpn ON pn.MaPNH = ctpn.MaPNH
                WHERE pn.NgayNhap >= '{nam}-01-01' AND pn.NgayNhap < '{nam + 1}-01-01'";

            return LayGiaTriDau(_db.GetListData(sql));
        }

        private static decimal LayGiaTriDau(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0 || dt.Rows[0][0] == DBNull.Value)
                return 0;
            return Convert.ToDecimal(dt.Rows[0][0]);
        }
    }
}