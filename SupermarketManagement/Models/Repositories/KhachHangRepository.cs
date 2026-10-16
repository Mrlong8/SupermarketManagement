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
    public class KhachHangRepository
    {
        private DbConection _db = new DbConection();

        public DataTable GetAll()
        {
            string sql = "SELECT * FROM KhachHang";
            return _db.GetListData(sql);
        }

        public bool CheckExists(string maKH)
        {
            string sql = $"Select count(*) from KhachHang where MaKH = '{maKH}'";
            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public void Insert(string maKH, string hoTen, string soDienThoai, string email, DateTime ngayDangKy, int diemTichLuy)
        {
            string sql = $"INSERT INTO KhachHang (MaKH, HoTen, SoDienThoai, Email, NgayDangKy, DiemTichLuy) " +
                         $"VALUES ('{maKH}', N'{hoTen}', '{soDienThoai}', '{email}', '{ngayDangKy:yyyy-MM-dd}', {diemTichLuy})";
            _db.DataChange(sql);
        }

        public void Update(string maKH, string hoTen, string soDienThoai, string email, DateTime ngayDangKy, int diemTichLuy)
        {
            string sql = $"UPDATE KhachHang SET HoTen = N'{hoTen}', SoDienThoai = '{soDienThoai}', " +
                         $"Email = '{email}', NgayDangKy = '{ngayDangKy:yyyy-MM-dd}', DiemTichLuy = {diemTichLuy} " +
                         $"WHERE MaKH = '{maKH}'";
            _db.DataChange(sql);
        }

        public void Delete(string maKH)
        {
            string sql = $"DELETE FROM KhachHang WHERE MaKH = '{maKH}'";
            _db.DataChange(sql);
        }

        public string RenderMaKhachHang()
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            string tiento = "KH" + ngay;

            string sql = $"select count(*) From KhachHang Where MaKH Like '{tiento}%'";
            DataTable dt = _db.GetListData(sql);
            int soLuong = Convert.ToInt32(dt.Rows[0][0]);

            int sttMoi = soLuong + 1;

            return tiento + sttMoi.ToString("D3");// hiện đủ 3 chữ số vd 3 -> 003
        }

        // 1. Tìm kiếm khách hàng theo Mã, Tên, SĐT hoặc Email
        public DataTable Search(string keyword)
        {
            string sql = "SELECT * FROM KhachHang " +
                         "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string safeKeyword = keyword.Replace("'", "''");

                sql += $"AND (MaKH LIKE N'%{safeKeyword}%' " +
                       $"OR HoTen LIKE N'%{safeKeyword}%' " +
                       $"OR SoDienThoai LIKE N'%{safeKeyword}%' " +
                       $"OR Email LIKE N'%{safeKeyword}%') ";
            }

            return _db.GetListData(sql);
        }

    }
}
