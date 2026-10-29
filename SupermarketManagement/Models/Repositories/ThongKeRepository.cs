using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    // Thống kê doanh thu (đã trừ tiền trả hàng) và vốn nhập
    public class ThongKeRepository
    {
        private DbConection _db = new DbConection();

        // 1. Thống kê Doanh Thu thuần theo từng ngày trong Tháng (Đã trừ tiền trả hàng)
        public DataTable GetDoanhThuTheoNgayInThang(int thang, int nam)
        {
            string sql = $@"
                WITH NgayTrongThang AS (
                    SELECT CAST('{nam}-{thang:D2}-01' AS DATE) AS Ngay
                    UNION ALL
                    SELECT DATEADD(DAY, 1, Ngay)
                    FROM NgayTrongThang
                    WHERE DATEADD(DAY, 1, Ngay) <= EOMONTH('{nam}-{thang:D2}-01')
                ),
                DoanhThuBan AS (
                    SELECT 
                        CAST(hd.NgayMua AS DATE) AS Ngay,
                        SUM(ct.SoLuongBan * d.DonGiaBanLe) AS TongBan
                    FROM HoaDon hd
                    INNER JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                    INNER JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                    WHERE MONTH(hd.NgayMua) = {thang} AND YEAR(hd.NgayMua) = {nam}
                    GROUP BY CAST(hd.NgayMua AS DATE)
                ),
                TienTraHang AS (
                    SELECT 
                        CAST(pth.NgayTra AS DATE) AS Ngay,
                        SUM(ctpth.SoLuongTra * ctpth.DonGiaHoan) AS TongTra
                    FROM PhieuTraHang pth
                    INNER JOIN ChiTietPhieuTraHang ctpth ON pth.MaPhieuTra = ctpth.MaPhieuTra
                    WHERE MONTH(pth.NgayTra) = {thang} AND YEAR(pth.NgayTra) = {nam}
                    GROUP BY CAST(pth.NgayTra AS DATE)
                )
                SELECT 
                    DAY(ntt.Ngay) AS [Ngay],
                    ISNULL(dtb.TongBan, 0) - ISNULL(tth.TongTra, 0) AS [DoanhThu]
                FROM NgayTrongThang ntt
                LEFT JOIN DoanhThuBan dtb ON ntt.Ngay = dtb.Ngay
                LEFT JOIN TienTraHang tth ON ntt.Ngay = tth.Ngay
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
                WHERE MONTH(ntt.Ngay) = {thang} AND YEAR(ntt.Ngay) = {nam}
                GROUP BY ntt.Ngay
                ORDER BY ntt.Ngay ASC
                OPTION (MAXRECURSION 31)";

            return _db.GetListData(sql);
        }

        // 3. Tổng Doanh Thu cả năm (Đã trừ tiền trả hàng)
        public decimal GetTongDoanhThuNam(int nam)
        {
            string sql = $@"
                SELECT 
                    (
                        ISNULL((
                            SELECT SUM(ct.SoLuongBan * d.DonGiaBanLe)
                            FROM HoaDon hd
                            INNER JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                            INNER JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                            WHERE hd.NgayMua >= '{nam}-01-01' AND hd.NgayMua < '{nam + 1}-01-01'
                        ), 0)
                        -
                        ISNULL((
                            SELECT SUM(ctpth.SoLuongTra * ctpth.DonGiaHoan)
                            FROM PhieuTraHang pth
                            INNER JOIN ChiTietPhieuTraHang ctpth ON pth.MaPhieuTra = ctpth.MaPhieuTra
                            WHERE pth.NgayTra >= '{nam}-01-01' AND pth.NgayTra < '{nam + 1}-01-01'
                        ), 0)
                    ) AS TongDoanhThu";

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

        // 5. Thống kê Giá Trị Trả Hàng theo từng ngày trong Tháng
        public DataTable GetTienTraTheoNgayInThang(int thang, int nam)
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
            ISNULL(SUM(ctpth.SoLuongTra * ctpth.DonGiaHoan), 0) AS [TienTra]
        FROM NgayTrongThang ntt
        LEFT JOIN PhieuTraHang pth ON CAST(pth.NgayTra AS DATE) = ntt.Ngay
        LEFT JOIN ChiTietPhieuTraHang ctpth ON pth.MaPhieuTra = ctpth.MaPhieuTra
        WHERE MONTH(ntt.Ngay) = {thang} AND YEAR(ntt.Ngay) = {nam}
        GROUP BY ntt.Ngay
        ORDER BY ntt.Ngay ASC
        OPTION (MAXRECURSION 31)";

            return _db.GetListData(sql);
        }
    }
}