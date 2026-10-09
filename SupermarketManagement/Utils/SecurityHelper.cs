using System;
using System.Security.Cryptography;
using System.Text;

namespace SupermarketManagement.Utils
{
    public static class SecurityHelper
    {
        // Mã hoá SHA256, trả về chuỗi hex IN HOA (khớp với HASHBYTES('SHA2_256') trong SQL + CONVERT(...,2))
        public static string Sha256(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] h = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(h).Replace("-", "");
            }
        }
    }
}