namespace SupermarketManagement.Utils
{
    // Lưu thông tin người đang đăng nhập (dùng ở mọi form: UserSession.MaNV, UserSession.Role ...)
    public static class UserSession
    {
        public static int MaTK { get; set; }
        public static int MaNV { get; set; }
        public static string UserName { get; set; }
        public static string Role { get; set; }
        public static string HoTen { get; set; }
        public static string ChucVu { get; set; }

        public static bool LaAdmin
        {
            get { return Role == "Admin"; }
        }

        public static void Xoa()
        {
            MaTK = 0;
            MaNV = 0;
            UserName = null;
            Role = null;
            HoTen = null;
            ChucVu = null;
        }
    }
}