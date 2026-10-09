using SupermarketManagement.Views.Admin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

// ===== CỦA NAM: muốn test luồng Đăng nhập thì bỏ comment 2 dòng using dưới đây =====
//using SupermarketManagement.Utils;
//using SupermarketManagement.Views.Auth;

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
            Application.Run(new POSForm()); // nếu muons chạy form khác thì đổi tên form ở đây của Long Hiện tại là Admin mọi người có thể comment và tuyệt đói không xóa của người khác nhé
            //Application.Run(new Frm_Admin()); test ở đây

            // ================= CỦA NAM: Đăng nhập -> Form tổng -> Đăng xuất =================
            // Cách test: comment dòng Application.Run(new Frm_Admin()) của Long Hiện ở trên,
            // bỏ comment 2 dòng using ở đầu file, rồi bỏ comment đoạn bên dưới.
            //while (true)
            //{
            //    using (LoginForm login = new LoginForm())
            //    {
            //        if (login.ShowDialog() != DialogResult.OK) break;   // bấm Thoát
            //    }
            //
            //    DashboardForm main = new DashboardForm();
            //    Application.Run(main);
            //    if (!main.DangXuat) break;                              // tắt chương trình
            //    UserSession.Xoa();
            //}
        }
    }
}