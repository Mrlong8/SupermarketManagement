
using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Models.Repositories
{
    public class KhachHangRepository
    {
        private readonly DbConection _db = new DbConection();

        // Chống lỗi dấu nháy đơn khi ghép chuỗi SQL.
        // Nếu DbConection hỗ trợ tham số SQL, nên chuyển sang truy vấn có tham số.
        private static string Escape(string value)
        {
            return (value ?? "").Replace("'", "''");
        }

        // Lấy danh sách khách hàng đang hoạt động.
        public DataTable GetAll()
        {
            string sql = @"
                SELECT *
                FROM dbo.KhachHang
                WHERE TrangThai = 1";

            return _db.GetListData(sql);
        }

        // Kiểm tra mã khách hàng đã tồn tại.
        public bool CheckExists(string maKH)
        {
            string sql = $@"
                SELECT COUNT(*)
                FROM dbo.KhachHang
                WHERE MaKH = N'{Escape(maKH)}'";

            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 &&
                   Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Kiểm tra số điện thoại đã tồn tại.
        public bool CheckPhoneExists(string soDienThoai)
        {
            string sql = $@"
                SELECT COUNT(*)
                FROM dbo.KhachHang
                WHERE SoDienThoai = N'{Escape(soDienThoai)}'";

            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 &&
                   Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Kiểm tra email đã tồn tại.
        public bool CheckEmailExists(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string sql = $@"
                SELECT COUNT(*)
                FROM dbo.KhachHang
                WHERE Email = N'{Escape(email)}'";

            DataTable dt = _db.GetListData(sql);
            return dt.Rows.Count > 0 &&
                   Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Tìm khách hàng theo số điện thoại.
        public DataTable GetByPhone(string soDienThoai)
        {
            string sql = $@"
                SELECT MaKH, HoTen, Email, DiemTichLuy
                FROM dbo.KhachHang
                WHERE SoDienThoai = N'{Escape(soDienThoai)}'
                  AND TrangThai = 1";

            return _db.GetListData(sql);
        }

        // Thêm khách hàng từ POS.
        public void InsertFromPOS(
            string maKH,
            string hoTen,
            string soDienThoai,
            string email)
        {
            string emailValue = string.IsNullOrWhiteSpace(email)
                ? "NULL"
                : $"N'{Escape(email)}'";

            string sql = $@"
                INSERT INTO dbo.KhachHang
                    (MaKH, HoTen, SoDienThoai, Email,
                     NgayDangKy, DiemTichLuy)
                VALUES
                    (N'{Escape(maKH)}',
                     N'{Escape(hoTen)}',
                     N'{Escape(soDienThoai)}',
                     {emailValue},
                     GETDATE(), 0)";

            _db.DataChange(sql);
        }

        // Giữ phương thức Insert cũ để không ảnh hưởng nơi đang sử dụng.
        public void Insert(
            string maKH,
            string hoTen,
            string soDienThoai,
            string email,
            DateTime ngayDangKy,
            int diemTichLuy)
        {
            string emailValue = string.IsNullOrWhiteSpace(email)
                ? "NULL"
                : $"N'{Escape(email)}'";

            string sql = $@"
                INSERT INTO dbo.KhachHang
                    (MaKH, HoTen, SoDienThoai, Email,
                     NgayDangKy, DiemTichLuy)
                VALUES
                    (N'{Escape(maKH)}',
                     N'{Escape(hoTen)}',
                     N'{Escape(soDienThoai)}',
                     {emailValue},
                     '{ngayDangKy:yyyy-MM-dd}',
                     {diemTichLuy})";

            _db.DataChange(sql);
        }

        // Cập nhật khách hàng.
        public void Update(
            string maKH,
            string hoTen,
            string soDienThoai,
            string email,
            DateTime ngayDangKy,
            int diemTichLuy)
        {
            string emailValue = string.IsNullOrWhiteSpace(email)
                ? "NULL"
                : $"N'{Escape(email)}'";

            string sql = $@"
                UPDATE dbo.KhachHang
                SET HoTen = N'{Escape(hoTen)}',
                    SoDienThoai = N'{Escape(soDienThoai)}',
                    Email = {emailValue},
                    NgayDangKy = '{ngayDangKy:yyyy-MM-dd}',
                    DiemTichLuy = {diemTichLuy}
                WHERE MaKH = N'{Escape(maKH)}'";

            _db.DataChange(sql);
        }

        // Xóa mềm khách hàng.
        public void Delete(string maKH)
        {
            string sql = $@"
                UPDATE dbo.KhachHang
                SET TrangThai = 0
                WHERE MaKH = N'{Escape(maKH)}'";

            _db.DataChange(sql);
        }

        // Tạo mã khách hàng theo ngày: KHyyyyMMdd001, 002...
        public string RenderMaKhachHang()
        {
            string tienTo = "KH" + DateTime.Now.ToString("yyyyMMdd");

            string sql = $@"
                SELECT TOP 1 MaKH
                FROM dbo.KhachHang
                WHERE MaKH LIKE '{tienTo}%'
                ORDER BY MaKH DESC";

            DataTable dt = _db.GetListData(sql);
            int sttMoi = 1;

            if (dt.Rows.Count > 0)
            {
                string maMax = Convert.ToString(dt.Rows[0]["MaKH"]);
                string phanSo = maMax.Substring(tienTo.Length);

                if (int.TryParse(phanSo, out int sttCu))
                    sttMoi = sttCu + 1;
            }

            return tienTo + sttMoi.ToString("D3");
        }

        // Tìm kiếm khách hàng theo mã, tên, số điện thoại hoặc email.
        public DataTable Search(string keyword)
        {
            string sql = @"
                SELECT *
                FROM dbo.KhachHang
                WHERE TrangThai = 1";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string key = Escape(keyword);

                sql += $@"
                    AND (
                        MaKH LIKE N'%{key}%'
                        OR HoTen LIKE N'%{key}%'
                        OR SoDienThoai LIKE N'%{key}%'
                        OR Email LIKE N'%{key}%'
                    )";
            }

            return _db.GetListData(sql);
        }
    }
}
