using System;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Controllers.Repositories
{
    public class ChucVuRepository
    {
        private readonly DbConection _db = new DbConection();

        public DataTable GetAll()
        {
            return _db.GetListData("SELECT * FROM ChucVu");
        }

        public bool CheckExists(string maCV)
        {
            string sql = $"SELECT COUNT(*) FROM ChucVu WHERE MaCV = '{maCV}'";
            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public void Insert(string maCV, string tenCV, string heSoLuong, string caLamViec)
        {
            string sql = $"INSERT INTO ChucVu (MaCV, TenChucVu, HeSoLuong, CaLamViec) " +
                         $"VALUES ('{maCV}', N'{tenCV}', '{heSoLuong}', N'{caLamViec}')";
            _db.DataChange(sql);
        }

        public void Update(string maCV, string tenCV, string heSoLuong, string caLamViec)
        {
            string sql = $"UPDATE ChucVu SET TenChucVu = N'{tenCV}', HeSoLuong = '{heSoLuong}', CaLamViec = N'{caLamViec}' " +
                         $"WHERE MaCV = '{maCV}'";
            _db.DataChange(sql);
        }

        public void Delete(string maCV)
        {
            string sql = $"DELETE FROM ChucVu WHERE MaCV = '{maCV}'";
            _db.DataChange(sql);
        }
    }
}