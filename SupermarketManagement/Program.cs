using SupermarketManagement.Utils;
using SupermarketManagement.Views.Admin;
using SupermarketManagement.Views.Auth;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SupermarketManagement
{


    // ================= lưu ý ở trong này chỉ gọi form thôi còn khai báo kết nối csdl thì không được ở trong này =================
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // [Của Long Hiện] chạy thẳng form Admin để test. Muốn test form riêng: bỏ comment dòng này và comment đoạn của Nam bên dưới
            //Application.Run(new Frm_Admin()); // nếu muons chạy form khác thì đổi tên form ở đây của Long Hiện tại là Admin mọi người có thể comment và tuyệt đói không xóa của người khác nhé
            //Application.Run(new Frm_Admin()); test ở đây
            //Application.Run(new POSForm()); // nếu muons chạy form khác thì đổi tên form ở đây của Long Hiện tại là Admin mọi người có thể comment và tuyệt đói không xóa của người khác nhé
            Application.Run(new Frm_Admin()); //test ở đây

            // ================= CỦA NAM: Đăng nhập -> kiểm tra Role -> vào form của Role đó -> Đăng xuất quay lại Đăng nhập =================
            while (true)
            {
                UserSession.Xoa();

                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK) break;   // bấm Thoát ở form đăng nhập
                }

                Form main = TaoFormTheoRole(UserSession.Role);
                if (main == null)
                {
                    MessageBox.Show("Tài khoản chưa được phân quyền hợp lệ (Role: " + UserSession.Role + ")!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;                                           // quay lại đăng nhập
                }

                Application.Run(main);
                main.Dispose();

                if (!UserSession.YeuCauDangXuat) break;                 // tắt form bằng nút X -> thoát chương trình
            }
        }

        // ===== CỦA NAM: Role nào mở form nấy. Muốn đổi form cho Role nào thì sửa ở đây =====
        static Form TaoFormTheoRole(string role)
        {
            switch ((role ?? "").Trim().ToLower())
            {
                case "admin": return new Frm_Admin();      // Admin  -> form Admin của Long Hiện
                case "manager": return new DashboardForm();  // Manager -> form tổng (có menu)
                case "cashier": return new POSForm();        // Cashier -> form bán hàng (POSForm nằm trong namespace SupermarketManagement nên không cần using)
                default: return null;
            }
        }
    }
}