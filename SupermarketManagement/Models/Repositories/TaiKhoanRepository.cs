using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Controllers.Repositories
{
    // Chỉ chứa câu SQL liên quan bảng TaiKhoan, KHÔNG chứa code giao diện
    public class TaiKhoanRepository
    {
        private readonly DbConection _db = new DbConection();

        // ===== CỦA NAM: Đăng nhập (dùng GetTable có @param của DbConection -> chống SQL Injection) =====
        // Trả về 1 dòng của bảng TaiKhoan nếu đúng tài khoản + mật khẩu (đã SHA256), ngược lại bảng rỗng
        public DataTable DangNhap(string userName, string passHash)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE UserName = @u AND [Password] = @p";
            return _db.GetTable(sql,
                new SqlParameter("@u", userName),
                new SqlParameter("@p", passHash));
        }

        // ===== CỦA NAM: lấy họ tên + chức vụ để hiển thị (nếu tên cột khác thì sửa ở câu SQL này) =====
        public DataTable GetHoTenChucVu(int maNV)
        {
            string sql = @"SELECT nv.HoTen, cv.TenChucVu
                           FROM NhanVien nv
                           LEFT JOIN ChucVu cv ON nv.MaCV = cv.MaCV
                           WHERE nv.MaNV = @nv";
            return _db.GetTable(sql, new SqlParameter("@nv", maNV));
        }


        // Long lấy thông tin TK

        public DataTable GetThongTinTK(string maNV)
        {
            string sql = $"Select * from TaiKhoan Where MaNV = '{maNV}'";
            DataTable dt = _db.GetListData(sql);

            return dt;
        }

        // Long cập nhật thông tin
        // Hàm cập nhật thông tin tài khoản theo MaNV (hoặc MaTK)
        public void UpdateTaiKhoan(string maNV, string userName, string sdt, string role)
        {
            string sql = $"UPDATE TaiKhoan " +
                  $"SET UserName = N'{userName}', " +
                  $"    SDT = '{sdt}', " +
                  $"    Role = N'{role}' " +
                  $"WHERE MaNV = '{maNV}'";

            _db.DataChange(sql);
        }

        // cập nhật ảnh
        public void UpdateImage(string maTK, string urlImage)
        {
            string sql = $"Update TaiKhoan SET UrlImage = N'{urlImage}' where MaTK = '{maTK}' ";
            _db.DataChange(sql);
        }
    }
}