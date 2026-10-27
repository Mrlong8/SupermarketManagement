using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace SupermarketManagement.Models.Repositories
{
    public class SanPhamRepositoryV2
    {
        private DbConection _db = new DbConection();

        public DataTable GetListSanPham()
        {
            string sql = "SELECT * FROM SanPham WHERE TrangThai = 1";
            return _db.GetListData(sql);
        }
        public DataTable GetListSanPhamV2()
        {
            string sql = "SELECT sp.MaSP, sp.TenSanPham, sp.SoLuong, sp.DonGiaBan FROM SanPham sp WHERE TrangThai = 1";
            return _db.GetListData(sql);
        }

        public DataTable GetDanhMuc()
        {
            string sql = "SELECT * FROM DanhMuc";
            return _db.GetListData(sql);
        }
        public DataTable TimKiemSanPhamTheoTen(string keyword)
        {
            // Bổ sung AND TrangThai = 1
            string sql = $"SELECT * FROM SanPham WHERE TenSanPham LIKE N'%{keyword.Trim()}%' AND TrangThai = 1";
            return _db.GetListData(sql);
        }
        // 1. Tìm kiếm riêng theo Tên sản phẩm
        public DataTable LocSanPhamTheoDanhMuc(string maDM)
        {
            string sql = $"SELECT * FROM SanPham WHERE MaDM = '{maDM}' AND TrangThai = 1";
            return _db.GetListData(sql);
        }

        // Bổ sung hàm Xóa mềm Sản phẩm
        public void Delete(string maSP)
        {
            string sql = $"UPDATE SanPham SET TrangThai = 0 WHERE MaSP = '{maSP}'";
            _db.DataChange(sql);
        }

        public DataTable GetSanPhamById(string maSP)
        {
            string sql = $"SELECT * FROM SanPham WHERE MaSP = '{maSP}'";
            DataTable dt = _db.GetListData(sql);
            return dt;
        }

        public void Update(string maSP, string tenSP, decimal giaNhap, decimal giaBan,
                     int soLuong, string maDM,string moTa)
        {
            var ci = CultureInfo.InvariantCulture;

            string sql = $@"UPDATE SanPham SET
                TenSanPham = N'{tenSP}',
                DonGiaNhap = {giaNhap.ToString(ci)},
                DonGiaBan  = {giaBan.ToString(ci)},
                SoLuong    = {soLuong},
                MaDM       = '{maDM}',
                MoTa       = '{moTa}'
            WHERE MaSP = '{maSP.Replace("'", "''")}'";

            _db.DataChange(sql);
        }

        public void UpdateImage(string maSP, string urlImage)
        {
            string sql = $"Update SanPham SET UrlImage = N'{urlImage}' where MaSP = '{maSP}' ";
            _db.DataChange(sql);
        }
        public bool CapNhatSoLuongKhiNhapHang(string maSP, int soLuongNhap)
        {
            string query = @"
                UPDATE SanPham 
                SET SoLuong = SoLuong + @SoLuongNhap 
                WHERE MaSP = @MaSP";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoLuongNhap", soLuongNhap),
                new SqlParameter("@MaSP", maSP)
            };

            int rowsAffected = DbConection.DBHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}