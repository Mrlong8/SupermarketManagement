using SupermarketManagement.Controllers.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagement.Models.Repositories
{
    public class NhanVienRepository
    {
        private DbConection _db = new DbConection();

        public DataTable GetAll()
        {
            string sql = "SELECT * FROM NhanVien";
            return _db.GetListData(sql);
        }

        public bool CheckExists(string maNV)
        {
            string sql = $"Select count(*) from NhanVien where MaNV = '{maNV}'";
            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public void Insert(string maNV, string tenNV, string gioiTinh,string luongCB ,DateTime ngaySinh, string diaChi, string maCV, string email)
        {
            string sql = $"INSERT INTO NhanVien (MaNV, HoTen, GioiTinh,LuongCoBan ,NgaySinh, DiaChi, MaCV, Email) " +
                         $"VALUES ('{maNV}', N'{tenNV}', N'{gioiTinh}', '{luongCB}', '{ngaySinh:yyyy-MM-dd}', N'{diaChi}', '{maCV}', '{email}')";
            _db.DataChange(sql);
        }

        public void Update(string maNV, string tenNV, string gioiTinh, string luongCB, DateTime ngaySinh, string diaChi, string maCV, string email)
        {
            // Đã bổ sung cập nhật cột Email
            string sql = $"UPDATE NhanVien SET HoTen = N'{tenNV}', GioiTinh = N'{gioiTinh}', LuongCoBan = '{luongCB}', " +
                         $"NgaySinh = '{ngaySinh:yyyy-MM-dd}', DiaChi = N'{diaChi}', MaCV = '{maCV}', Email = '{email}' " +
                         $"WHERE MaNV = '{maNV}'";
            _db.DataChange(sql);
        }

        public void Delete(string maNV)
        {
            string sql = $"DELETE FROM NhanVien WHERE MaNV = '{maNV}'";
            _db.DataChange(sql);
        }
    }
}
