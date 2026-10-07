using SupermarketManagement.Utils;
using SupermarketManagement.Views.Admin;
using SupermarketManagement.Views.Auth;
using System;
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

            // Test form của mình: comment đoạn while bên dưới rồi mở dòng này (không xóa của người khác)
            // Application.Run(new Frm_Admin());

            // Luồng: Đăng nhập -> Form tổng -> (Đăng xuất) -> quay lại Đăng nhập
            while (true)
            {
                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK) break;   // bấm Thoát
                }

                DashboardForm main = new DashboardForm();
                Application.Run(main);
                if (!main.DangXuat) break;                              // tắt chương trình
                UserSession.Xoa();
            }
        }
    }
}