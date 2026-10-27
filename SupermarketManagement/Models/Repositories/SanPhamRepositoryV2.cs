using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Models.Repositories
{
    public class SanPhamRepositoryV2
    {
        private DbConection _db = new DbConection();

        // Đơn vị cơ bản của sản phẩm = đơn vị có SoLuongQuyDoi nhỏ nhất (thường là 1).
        // Giá nhập/giá bán hiển thị ở danh sách lấy theo đơn vị này.
        private const string BaseUnitApply = @"
            OUTER APPLY (
                SELECT TOP 1 d.MaDVT, d.SoLuongQuyDoi, d.DonGiaNhapLe, d.DonGiaBanLe, dv.TenDV
                FROM SanPham_DonViTinh d
                JOIN DonViTinh dv ON dv.MaDVT = d.MaDVT
                WHERE d.MaSP = sp.MaSP
                ORDER BY d.SoLuongQuyDoi ASC, d.MaDVT
            ) u";

        // Đặt alias SoLuong, DonGiaNhap, DonGiaBan để code giao diện cũ vẫn dùng được tên cột cũ.
        private const string SelectSanPham = @"
            SELECT sp.MaSP, sp.TenSanPham,
                   sp.SoLuongTong AS SoLuong,
                   sp.UrlImage, sp.MoTa, sp.MaDM, sp.MaKM, sp.MaNV, sp.MaNCC, sp.TrangThai,
                   u.MaDVT, u.TenDV,
                   u.DonGiaNhapLe AS DonGiaNhap,
                   u.DonGiaBanLe  AS DonGiaBan
            FROM SanPham sp" + BaseUnitApply;

        private static string Esc(string s)
        {
            return (s ?? "").Replace("'", "''");
        }

        public DataTable GetListSanPham()
        {
            string sql = SelectSanPham + " WHERE sp.TrangThai = 1";
            return _db.GetListData(sql);
        }

        public DataTable GetListSanPhamV2()
        {
            string sql = @"SELECT sp.MaSP, sp.TenSanPham, sp.SoLuongTong AS SoLuong, u.DonGiaBanLe AS DonGiaBan
                           FROM SanPham sp" + BaseUnitApply + " WHERE sp.TrangThai = 1";
            return _db.GetListData(sql);
        }

        // Dùng cho màn hình bán hàng / nhập hàng: mỗi sản phẩm một dòng cho MỖI đơn vị tính
        public DataTable GetListSanPhamTheoDonViTinh()
        {
            string sql = @"
                SELECT sp.MaSP, sp.TenSanPham, sp.SoLuongTong,
                       d.MaDVT, dv.TenDV, d.SoLuongQuyDoi,
                       d.DonGiaNhapLe, d.DonGiaBanLe,
                       sp.SoLuongTong / d.SoLuongQuyDoi AS SoLuongTonTheoDV
                FROM SanPham sp
                JOIN SanPham_DonViTinh d ON d.MaSP = sp.MaSP
                JOIN DonViTinh dv ON dv.MaDVT = d.MaDVT
                WHERE sp.TrangThai = 1
                ORDER BY sp.TenSanPham, d.SoLuongQuyDoi";
            return _db.GetListData(sql);
        }

        // Danh sách đơn vị tính của 1 sản phẩm (đổ vào ComboBox)
        public DataTable GetDonViTinhTheoSanPham(string maSP)
        {
            string sql = $@"
                SELECT d.MaDVT, dv.TenDV, d.SoLuongQuyDoi, d.DonGiaNhapLe, d.DonGiaBanLe
                FROM SanPham_DonViTinh d
                JOIN DonViTinh dv ON dv.MaDVT = d.MaDVT
                WHERE d.MaSP = '{Esc(maSP)}'
                ORDER BY d.SoLuongQuyDoi";
            return _db.GetListData(sql);
        }

        public DataTable GetListDonViTinh()
        {
            return _db.GetListData("SELECT MaDVT, TenDV, GhiChu FROM DonViTinh");
        }

        public DataTable GetDanhMuc()
        {
            string sql = "SELECT * FROM DanhMuc";
            return _db.GetListData(sql);
        }

        public DataTable TimKiemSanPhamTheoTen(string keyword)
        {
            string sql = SelectSanPham +
                         $" WHERE sp.TenSanPham LIKE N'%{Esc(keyword.Trim())}%' AND sp.TrangThai = 1";
            return _db.GetListData(sql);
        }

        public DataTable LocSanPhamTheoDanhMuc(string maDM)
        {
            string sql = SelectSanPham + $" WHERE sp.MaDM = '{Esc(maDM)}' AND sp.TrangThai = 1";
            return _db.GetListData(sql);
        }

        // Xóa mềm sản phẩm
        public void Delete(string maSP)
        {
            string sql = "UPDATE SanPham SET TrangThai = 0 WHERE MaSP = @MaSP";
            DbConection.DBHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@MaSP", maSP)
            });
        }

        public DataTable GetSanPhamById(string maSP)
        {
            string sql = SelectSanPham + $" WHERE sp.MaSP = '{Esc(maSP)}'";
            return _db.GetListData(sql);
        }

        // Giữ nguyên chữ ký cũ. giaNhap/giaBan được ghi vào đơn vị cơ bản (SoLuongQuyDoi nhỏ nhất).
        // soLuong ghi vào SoLuongTong (tính theo đơn vị nhỏ nhất).
        public void Update(string maSP, string tenSP, decimal giaNhap, decimal giaBan,
                           int soLuong, string maDM, string moTa)
        {
            string sql = @"
                SET XACT_ABORT ON;
                BEGIN TRAN;

                UPDATE SanPham SET
                    TenSanPham = @TenSP,
                    SoLuongTong = @SoLuong,
                    MaDM = @MaDM,
                    MoTa = @MoTa
                WHERE MaSP = @MaSP;

                UPDATE SanPham_DonViTinh SET
                    DonGiaNhapLe = @GiaNhap,
                    DonGiaBanLe  = @GiaBan
                WHERE MaSP = @MaSP
                  AND SoLuongQuyDoi = (SELECT MIN(SoLuongQuyDoi) FROM SanPham_DonViTinh WHERE MaSP = @MaSP);

                COMMIT;";

            DbConection.DBHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@TenSP", tenSP ?? (object)DBNull.Value),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@MaDM", (object)maDM ?? DBNull.Value),
                new SqlParameter("@MoTa", (object)moTa ?? DBNull.Value),
                new SqlParameter("@GiaNhap", giaNhap),
                new SqlParameter("@GiaBan", giaBan),
                new SqlParameter("@MaSP", maSP)
            });
        }

        // Cập nhật giá cho 1 đơn vị tính cụ thể (Thùng, Chai, ...)
        public bool UpdateGiaTheoDonVi(string maSP, string maDVT, decimal giaNhapLe, decimal giaBanLe)
        {
            string sql = @"UPDATE SanPham_DonViTinh
                           SET DonGiaNhapLe = @GiaNhap, DonGiaBanLe = @GiaBan
                           WHERE MaSP = @MaSP AND MaDVT = @MaDVT";
            int rows = DbConection.DBHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@GiaNhap", giaNhapLe),
                new SqlParameter("@GiaBan", giaBanLe),
                new SqlParameter("@MaSP", maSP),
                new SqlParameter("@MaDVT", maDVT)
            });
            return rows > 0;
        }

        // Thêm hoặc sửa quy đổi của 1 đơn vị cho 1 sản phẩm
        public bool LuuDonViTinhChoSanPham(string maSP, string maDVT, int soLuongQuyDoi,
                                           decimal giaNhapLe, decimal giaBanLe)
        {
            string sql = @"
                IF EXISTS (SELECT 1 FROM SanPham_DonViTinh WHERE MaSP = @MaSP AND MaDVT = @MaDVT)
                    UPDATE SanPham_DonViTinh
                    SET SoLuongQuyDoi = @QuyDoi, DonGiaNhapLe = @GiaNhap, DonGiaBanLe = @GiaBan
                    WHERE MaSP = @MaSP AND MaDVT = @MaDVT
                ELSE
                    INSERT INTO SanPham_DonViTinh (MaDVT, MaSP, SoLuongQuyDoi, DonGiaNhapLe, DonGiaBanLe)
                    VALUES (@MaDVT, @MaSP, @QuyDoi, @GiaNhap, @GiaBan)";
            int rows = DbConection.DBHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@MaSP", maSP),
                new SqlParameter("@MaDVT", maDVT),
                new SqlParameter("@QuyDoi", soLuongQuyDoi),
                new SqlParameter("@GiaNhap", giaNhapLe),
                new SqlParameter("@GiaBan", giaBanLe)
            });
            return rows > 0;
        }

        public void UpdateImage(string maSP, string urlImage)
        {
            string sql = "UPDATE SanPham SET UrlImage = @Url WHERE MaSP = @MaSP";
            DbConection.DBHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@Url", (object)urlImage ?? DBNull.Value),
                new SqlParameter("@MaSP", maSP)
            });
        }

        // Nhập hàng: SoLuongTong += SoLuongNhap * SoLuongQuyDoi của đơn vị đó
        // VD: nhập 10 Thùng (quy đổi 10) => +100
        public bool CapNhatSoLuongKhiNhapHang(string maSP, string maDVT, int soLuongNhap)
        {
            string query = @"
                UPDATE sp
                SET sp.SoLuongTong = sp.SoLuongTong + @SoLuongNhap * d.SoLuongQuyDoi
                FROM SanPham sp
                JOIN SanPham_DonViTinh d ON d.MaSP = sp.MaSP AND d.MaDVT = @MaDVT
                WHERE sp.MaSP = @MaSP";

            int rowsAffected = DbConection.DBHelper.ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@SoLuongNhap", soLuongNhap),
                new SqlParameter("@MaDVT", maDVT),
                new SqlParameter("@MaSP", maSP)
            });

            return rowsAffected > 0;
        }

        // Bán hàng: SoLuongTong -= SoLuongBan * SoLuongQuyDoi. Trả false nếu không đủ hàng.
        public bool TruSoLuongKhiBanHang(string maSP, string maDVT, int soLuongBan)
        {
            string query = @"
                UPDATE sp
                SET sp.SoLuongTong = sp.SoLuongTong - @SoLuongBan * d.SoLuongQuyDoi
                FROM SanPham sp
                JOIN SanPham_DonViTinh d ON d.MaSP = sp.MaSP AND d.MaDVT = @MaDVT
                WHERE sp.MaSP = @MaSP
                  AND sp.SoLuongTong >= @SoLuongBan * d.SoLuongQuyDoi";

            int rowsAffected = DbConection.DBHelper.ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@SoLuongBan", soLuongBan),
                new SqlParameter("@MaDVT", maDVT),
                new SqlParameter("@MaSP", maSP)
            });

            return rowsAffected > 0;
        }
    }
}