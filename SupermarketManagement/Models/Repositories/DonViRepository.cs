using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class DonViRepository
    {
        public DbConection _db = new DbConection();

        public DataTable GetAll()
        {
            return _db.GetListData("SELECT * FROM dbo.DonViTinh ORDER BY MaDVT");
        }

        public bool TonTai(string maDVT)
        {
            string sql = $"SELECT COUNT(*) FROM dbo.DonViTinh WHERE MaDVT = '{Escape(maDVT)}'";
            DataTable dt = _db.GetListData(sql);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public void Them(string maDVT, string tenDV, string ghiChu)
        {
            string sql = $@"INSERT INTO dbo.DonViTinh (MaDVT, TenDV, GhiChu)
                            VALUES ('{Escape(maDVT)}', N'{Escape(tenDV)}', N'{Escape(ghiChu)}')";
            _db.DataChange(sql);
        }
        private string Escape(string s)
        {
            return (s ?? "").Replace("'", "''");
        }
        // Tạo mã đơn vị tiếp theo: DVT001, DVT002, ...
        public string TaoMaTuDong()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaDVT, 4, 3) AS INT)), 0)
                   FROM dbo.DonViTinh
                   WHERE MaDVT LIKE 'DVT[0-9][0-9][0-9]'";

            DataTable dt = _db.GetListData(sql);
            int so = Convert.ToInt32(dt.Rows[0][0]) + 1;

            return "DVT" + so.ToString("D3");
        }
    }
}