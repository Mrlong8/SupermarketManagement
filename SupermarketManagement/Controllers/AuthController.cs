using System;
using System.Data;
using SupermarketManagement.Controllers.Repositories;
using SupermarketManagement.Utils;

namespace SupermarketManagement.Controllers
{
    // Điều khiển nghiệp vụ Đăng nhập (View chỉ gọi hàm này, không tự viết SQL)
    public class AuthController
    {
        private readonly TaiKhoanRepository repo = new TaiKhoanRepository();

        // true nếu đăng nhập đúng, đồng thời lưu thông tin vào UserSession
        public bool DangNhap(string userName, string password)
        {
            DataTable dt = repo.DangNhap(userName, SecurityHelper.Sha256(password));
            if (dt.Rows.Count == 0) return false;

            DataRow r = dt.Rows[0];
            UserSession.MaTK = Convert.ToInt32(r["MaTK"]);
            UserSession.UserName = r["UserName"].ToString();
            UserSession.Role = r["Role"].ToString().Trim();
            UserSession.MaNV = r["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(r["MaNV"]);
            UserSession.UrlImage = dt.Columns.Contains("UrlImage") && r["UrlImage"] != DBNull.Value
                                   ? r["UrlImage"].ToString() : "";

            // Chưa JOIN bảng NhanVien (chưa biết tên cột) nên tạm dùng UserName và Role để hiển thị
            UserSession.HoTen = UserSession.UserName;
            UserSession.ChucVu = UserSession.Role;
            return true;
        }
    }
}