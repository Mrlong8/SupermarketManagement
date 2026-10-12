using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class SanPhamRepositoryV2
    {
        private DbConection _db = new DbConection();

        public DataTable GetListSanPham()
        {
            string sql = "SELECT * FROM SanPham";
            return _db.GetListData(sql);
        }

        public DataTable GetDanhMuc()
        {
            string sql = "SELECT * FROM DanhMuc";
            return _db.GetListData(sql);
        }

        // 1. Tìm kiếm riêng theo Tên sản phẩm
        public DataTable TimKiemSanPhamTheoTen(string keyword)
        {
            string sql = $"SELECT * FROM SanPham WHERE TenSanPham LIKE N'%{keyword.Trim()}%'";
            return _db.GetListData(sql);
        }

        // 2. Lọc riêng theo Mã danh mục
        public DataTable LocSanPhamTheoDanhMuc(string maDM)
        {
            string sql = $"SELECT * FROM SanPham WHERE MaDM = '{maDM}'";
            return _db.GetListData(sql);
        }
    }
}