using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagement.Models.Entities
{
    public class PhienDangNhap
    {
        public static int MaTK { get; set; }
        public static int MaNV { get; set; }
        public static string UserName { get; set; }
        public static string Role { get; set; }
        public static string HoTen { get; set; }
        public static string ChucVu { get; set; }

        public static bool LaAdmin => Role == "Admin";

        public static void Xoa()
        {
            MaTK = MaNV = 0;
            UserName = Role = HoTen = ChucVu = null;
        }
    }
}
