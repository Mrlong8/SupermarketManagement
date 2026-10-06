using SupermarketManagement.Views.Admin;
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
            Application.Run(new Frm_Admin()); // nếu muons chạy form khác thì đổi tên form ở đây của Long Hiện tại là Admin mọi người có thể conment và tuyệt đói không xóa của người khác nhé
            //Application.Run(new Frm_Admin()); test ở đây
        }
    }
}