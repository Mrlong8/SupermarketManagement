using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;
using System.Globalization;

namespace SupermarketManagement.Models.Repositories
{
    public class LichSuNhapRepository
    {
        private DbConection _db = new DbConection();

        // ChiTietPhieuNhapHang vẫn giữ DonGiaNhap (giá tại thời điểm nhập, tính theo MaDVT của dòng đó)
        // nên phần tính tổng tiền không cần đổi.
        private const string SelectTongTien = @"
                SELECT 
                    pnh.MaPNH AS [Mã PNH],
                    pnh.NgayNhap AS [Ngày Nhập],
                    ncc.TenNCC AS [Nhà Cung Cấp],
                    nv.HoTen AS [Nhân Viên Nhập],
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS [Tổng Tiền]";

        private const string FromPhieuNhap = @"
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH";

        private const string GroupByPhieuNhap = @"
                GROUP BY pnh.MaPNH, pnh.NgayNhap, ncc.TenNCC, nv.HoTen";

        private static string Esc(string s)
        {
            return (s ?? "").Replace("'", "''");
        }

        // 1. Lấy toàn bộ danh sách Phiếu Nhập Hàng
        public DataTable GetDanhSachPNH()
        {
            string sql = SelectTongTien + FromPhieuNhap + GroupByPhieuNhap;
            return _db.GetListData(sql);
        }

        // 2. Lấy danh sách Nhân Viên Nhập Kho (MaCV = '3')
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

        // 4. Lấy Chi Tiết 1 Phiếu Nhập Hàng (thêm Đơn Vị Tính, NSX, HSD)
        public DataTable GetChiTietPNH(string maPNH)
        {
            string sql = $@"
                SELECT 
                    ct.MaSP AS [Mã SP],
                    sp.TenSanPham AS [Tên Sản Phẩm],
                    dv.TenDV AS [Đơn Vị Tính],
                    ct.SoLuongNhap AS [Số Lượng],
                    ct.DonGiaNhap AS [Đơn Giá],
                    (ct.SoLuongNhap * ct.DonGiaNhap) AS [Thành Tiền],
                    ct.NgaySanXuat AS [Ngày Sản Xuất],
                    ct.NgayHetHan AS [Ngày Hết Hạn]
                FROM ChiTietPhieuNhapHang ct
                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                INNER JOIN DonViTinh dv ON dv.MaDVT = ct.MaDVT
                WHERE ct.MaPNH = '{Esc(maPNH)}'";

            return _db.GetListData(sql);
        }

        // 5. Tìm kiếm Phiếu Nhập Hàng theo Mã PNH
        public DataTable TimKiemPhieuNhapByMa(string maPNH)
        {
            string sql = SelectTongTien + FromPhieuNhap + $@"
                WHERE pnh.MaPNH LIKE '%{Esc((maPNH ?? "").Trim())}%'" + GroupByPhieuNhap;

            return _db.GetListData(sql);
        }

        // 6. Lọc riêng theo Nhân Viên
        public DataTable LocTheoNhanVien(string maNV)
        {
            string sql = SelectTongTien + FromPhieuNhap + $@"
                WHERE pnh.MaNV = '{Esc(maNV)}'" + GroupByPhieuNhap;

            return _db.GetListData(sql);
        }

        // 7. Lọc riêng theo Nhà Cung Cấp
        public DataTable LocTheoNhaCungCap(string maNCC)
        {
            string sql = SelectTongTien + FromPhieuNhap + $@"
                WHERE pnh.MaNCC = '{Esc(maNCC)}'" + GroupByPhieuNhap;

            return _db.GetListData(sql);
        }

        // 8. Lọc riêng theo Ngày Nhập
        public DataTable LocTheoNgayNhap(DateTime ngayNhap)
        {
            string ngay = ngayNhap.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            string sql = SelectTongTien + FromPhieuNhap + $@"
                WHERE CAST(pnh.NgayNhap AS DATE) = '{ngay}'" + GroupByPhieuNhap;

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
                WHERE pnh.MaPNH = '{Esc(maPNH)}'
                GROUP BY pnh.MaPNH, pnh.NgayNhap, ncc.TenNCC, ncc.SDT, ncc.DiaChi, nv.HoTen";

            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        // 10. Xóa Phiếu Nhập Hàng (xóa chi tiết trước, rồi xóa phiếu)
        public void XoaPhieuNhap(string maPNH)
        {
            string ma = Esc(maPNH);
            string sql = $@"
                SET XACT_ABORT ON;
                BEGIN TRAN;

                -- Tổng số lượng cần trừ lại theo từng sản phẩm (quy đổi về đơn vị cơ bản)
                SELECT ct.MaSP, SUM(ct.SoLuongNhap * ISNULL(d.SoLuongQuyDoi, 1)) AS TongTru
                INTO #Tru
                FROM ChiTietPhieuNhapHang ct
                LEFT JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                WHERE ct.MaPNH = '{ma}'
                GROUP BY ct.MaSP;

                -- Không cho xóa nếu tồn kho hiện tại không đủ để hoàn trừ
                IF EXISTS (SELECT 1 FROM SanPham sp JOIN #Tru t ON t.MaSP = sp.MaSP
                           WHERE ISNULL(sp.SoLuongTong, 0) < t.TongTru)
                    THROW 50001, N'Không thể xóa: hàng của phiếu này đã được bán/xuất, tồn kho hiện tại không đủ để hoàn trừ.', 1;

                UPDATE sp
                SET sp.SoLuongTong = ISNULL(sp.SoLuongTong, 0) - t.TongTru
                FROM SanPham sp JOIN #Tru t ON t.MaSP = sp.MaSP;

                DELETE FROM ChiTietPhieuNhapHang WHERE MaPNH = '{ma}';
                DELETE FROM PhieuNhapHang WHERE MaPNH = '{ma}';

                COMMIT TRAN;";

            _db.DataChange(sql);
        }
    }
}