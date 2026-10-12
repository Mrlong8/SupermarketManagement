using SupermarketManagement.Controllers.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            string sql = "SELECT * FROM NhanVien nv JOIN ChucVu cv ON nv.MaCV = cv.MaCV";
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

        public string RenderMaNhanVien()
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            string tiento = "NV" + ngay;

            string sql = $"select count(*) From NhanVien Where MaNV Like '{tiento}%'";
            DataTable dt = _db.GetListData(sql);
            int soLuong = Convert.ToInt32(dt.Rows[0][0]);

            int sttMoi = soLuong + 1;

            return tiento + sttMoi.ToString("D3");// hiện đủ 3 chữ số vd 3 -> 003

        }

        // 1. Tìm kiếm nhân viên theo Mã, Tên hoặc Email
        public DataTable Search(string keyword)
        {
            string sql = "SELECT * FROM NhanVien nv " +
                         "JOIN ChucVu cv ON nv.MaCV = cv.MaCV " +
                         "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string safeKeyword = keyword.Replace("'", "''");

                sql += $"AND (nv.MaNV LIKE N'%{safeKeyword}%' " +
                       $"OR nv.HoTen LIKE N'%{safeKeyword}%' " +
                       $"OR nv.Email LIKE N'%{safeKeyword}%') ";
            }

            return _db.GetListData(sql);
        }

        // 2. Lọc nhân viên theo Chức vụ
        public DataTable FilterByChucVu(string maCV)
        {
            string sql = "SELECT * FROM NhanVien nv " +
                         "JOIN ChucVu cv ON nv.MaCV = cv.MaCV ";

            if (!string.IsNullOrWhiteSpace(maCV) && maCV != "Tất cả")
            {
                string safeMaCV = maCV.Replace("'", "''");
                sql += $"WHERE nv.MaCV = '{safeMaCV}' ";
            }

            return _db.GetListData(sql);
        }

    }
}
