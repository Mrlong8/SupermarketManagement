using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class ThongKeRepository
    {
        private DbConection _db = new DbConection();

        // 1. Thống kê Doanh Thu theo từng ngày trong Tháng
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
                    ISNULL(SUM(ct.SoLuongBan * sp.DonGiaBan), 0) AS [DoanhThu]
                FROM NgayTrongThang ntt
                LEFT JOIN HoaDon hd ON CAST(hd.NgayMua AS DATE) = ntt.Ngay
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                GROUP BY ntt.Ngay
                ORDER BY ntt.Ngay ASC
                OPTION (MAXRECURSION 31)";

            return _db.GetListData(sql);
        }

        // 2. Thống kê Vốn Nhập Hàng theo từng ngày trong cùng Tháng
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
    }
}