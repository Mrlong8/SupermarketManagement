using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SupermarketManagement
{
    // ================= KẾT NỐI CSDL =================
    public static class DBHelper
    {
        // Sửa Server cho đúng máy của bạn (vd: .\SQLEXPRESS hoặc (localdb)\MSSQLLocalDB)
        public static readonly string ConnStr =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCuaHang;Integrated Security=True";

        public static DataTable GetTable(string sql, params SqlParameter[] ps)
        {
            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static string Sha256(string input)
        {
            using (var sha = SHA256.Create())
            {
                byte[] h = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(h).Replace("-", ""); // hex in hoa, khớp với SQL
            }
        }
    }

    // ================= THÔNG TIN NGƯỜI ĐANG ĐĂNG NHẬP =================
    public static class PhienDangNhap
    {
        public static int MaTK, MaNV;
        public static string UserName, Role, HoTen, ChucVu;

        public static bool LaAdmin { get { return Role == "Admin"; } }

        public static void Xoa()
        {
            MaTK = MaNV = 0;
            UserName = Role = HoTen = ChucVu = null;
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Vòng lặp: Đăng nhập -> Form chính -> (Đăng xuất) -> quay lại Đăng nhập
            while (true)
            {
                using (var dn = new LoginForm())
                {
                    if (dn.ShowDialog() != DialogResult.OK) break;   // bấm Thoát
                }

                var main = new DashboardForm();
                Application.Run(main);
                if (!main.DangXuat) break;                           // tắt chương trình
                PhienDangNhap.Xoa();
            }
        }
    }
}