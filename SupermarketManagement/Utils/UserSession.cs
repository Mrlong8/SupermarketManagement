using System.Windows.Forms;

namespace SupermarketManagement.Utils
{
    // Lưu thông tin người đang đăng nhập (dùng ở mọi form: UserSession.MaNV, UserSession.Role ...)
    public static class UserSession
    {
        public static string MaTK { get; set; }
        public static int  MaNV { get; set; }
        public static string UserName { get; set; }
        public static string Role { get; set; }       // Admin / Manager / Cashier
        public static string HoTen { get; set; }
        public static string ChucVu { get; set; }
        public static string UrlImage { get; set; }   // đường dẫn ảnh đại diện (cột UrlImage)

        // true khi người dùng bấm "Đăng xuất" -> Program.cs sẽ mở lại LoginForm
        public static bool YeuCauDangXuat { get; set; }

        public static bool LaAdmin { get { return Role == "Admin"; } }
        public static bool LaManager { get { return Role == "Manager"; } }
        public static bool LaCashier { get { return Role == "Cashier"; } }

        // GỌI HÀM NÀY Ở NÚT ĐĂNG XUẤT CỦA MỌI FORM: UserSession.DangXuat(this);
        // Dùng được cả khi form đang được nhúng làm form con (vd POSForm nằm trong Frm_Admin):
        // hàm tự tìm form ngoài cùng để đóng.
        public static void DangXuat(Form f)
        {
            YeuCauDangXuat = true;

            Form top = f;
            while (top.Parent != null)
            {
                Form next = top.Parent.FindForm();
                if (next == null || next == top) break;
                top = next;
            }
            if (top.MdiParent != null) top = top.MdiParent;

            top.Close();
        }

        public static void Xoa()
        {
            MaTK = null;
            MaNV = 0;
            UserName = null;
            Role = null;
            HoTen = null;
            ChucVu = null;
            UrlImage = null;
            YeuCauDangXuat = false;
        }
    }
}