using SupermarketManagement.Controllers.Repositories;
using SupermarketManagement.Utils;
using System;
using System.Data;
using System.Windows.Forms;

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
            UserSession.MaTK = Convert.ToString(r["MaTK"]);
            UserSession.UserName = r["UserName"].ToString();
            UserSession.Role = r["Role"].ToString();
            UserSession.MaNV = r["MaNV"] == DBNull.Value ? null : Convert.ToString(r["MaNV"]);
            MessageBox.Show(
                "Tài khoản: " + UserSession.UserName +
                "\nMã nhân viên: " + UserSession.MaNV);
            UserSession.HoTen = r["HoTen"] == DBNull.Value ? userName : r["HoTen"].ToString();
            UserSession.ChucVu = r["TenChucVu"] == DBNull.Value ? "" : r["TenChucVu"].ToString();
            return true;
        }
    }
}