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
            UserSession.Role = r["Role"].ToString().Trim();
            UserSession.MaNV = r["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(r["MaNV"]);
            UserSession.UrlImage = dt.Columns.Contains("UrlImage") && r["UrlImage"] != DBNull.Value
                                   ? r["UrlImage"].ToString() : "";

            // Mặc định hiển thị UserName và Role; nếu lấy được họ tên + chức vụ thật thì thay vào
            UserSession.HoTen = UserSession.UserName;
            UserSession.ChucVu = UserSession.Role;
            try
            {
                DataTable info = repo.GetHoTenChucVu(UserSession.MaNV);
                if (info.Rows.Count > 0)
                {
                    if (info.Rows[0]["HoTen"] != DBNull.Value)
                        UserSession.HoTen = info.Rows[0]["HoTen"].ToString();
                    if (info.Rows[0]["TenChucVu"] != DBNull.Value)
                        UserSession.ChucVu = info.Rows[0]["TenChucVu"].ToString();
                }
            }
            catch
            {
                // Tên cột/bảng NhanVien, ChucVu khác -> bỏ qua, vẫn đăng nhập bình thường
            }
            return true;
        }
    }
}