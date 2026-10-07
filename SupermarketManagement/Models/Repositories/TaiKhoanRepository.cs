using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Controllers.Repositories
{
    // Chỉ chứa câu SQL liên quan bảng TaiKhoan, KHÔNG chứa code giao diện
    public class TaiKhoanRepository
    {
        private readonly DbConection db = new DbConection();

        // Trả về 1 dòng (kèm họ tên + chức vụ) nếu đúng tài khoản, ngược lại bảng rỗng
        // Nếu tên cột trong CSDL của nhóm khác thì sửa ở câu SQL này
        public DataTable DangNhap(string userName, string passHash)
        {
            string sql = @"SELECT tk.MaTK, tk.UserName, tk.[Role], tk.MaNV, nv.HoTen, cv.TenChucVu
                           FROM TaiKhoan tk
                           LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                           LEFT JOIN ChucVu cv ON nv.MaCV = cv.MaCV
                           WHERE tk.UserName = @u AND tk.[Password] = @p";

            return db.GetTable(sql,
                new SqlParameter("@u", userName),
                new SqlParameter("@p", passHash));
        }
    }
}