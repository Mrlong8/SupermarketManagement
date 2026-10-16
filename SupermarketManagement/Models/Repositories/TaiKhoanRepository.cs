using System.Data;

namespace SupermarketManagement.Controllers.Repositories
{
    // Chỉ chứa câu SQL liên quan bảng TaiKhoan, KHÔNG chứa code giao diện
    // (của Nam) Dùng GetListData có sẵn của nhóm trưởng nên không cần sửa DbConection
    public class TaiKhoanRepository
    {
        private readonly DbConection db = new DbConection();

        // Trả về 1 dòng của bảng TaiKhoan nếu đúng tài khoản, ngược lại bảng rỗng
        public DataTable DangNhap(string userName, string passHash)
        {
            // GetListData không có tham số nên phải tự escape dấu ' để chống SQL Injection cơ bản
            // (passHash là chuỗi hex SHA256 nên an toàn)
            string u = userName.Replace("'", "''");

            string sql = "SELECT * FROM TaiKhoan WHERE UserName = N'" + u + "' AND [Password] = '" + passHash + "'";
            return db.GetListData(sql);
        }

        // Khi bỏ comment GetTable (có @param) trong DbConection thì đổi sang dạng:
        //   WHERE UserName = @u AND [Password] = @p
        //   return db.GetTable(sql, new SqlParameter("@u", userName), new SqlParameter("@p", passHash));
    }
}