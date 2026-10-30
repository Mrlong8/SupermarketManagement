using System;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Controllers.Repositories
{
    // Chỉ chứa câu SQL liên quan bảng TaiKhoan, KHÔNG chứa code giao diện
    public class TaiKhoanRepository
    {
        private readonly DbConection _db = new DbConection();

        // ===== CỦA NAM: Đăng nhập (dùng GetTable có @param của DbConection -> chống SQL Injection) =====
        // Trả về 1 dòng của bảng TaiKhoan nếu đúng tài khoản + mật khẩu (đã SHA256), ngược lại bảng rỗng
        public DataTable DangNhap(string userName, string passHash)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE UserName = @u AND [Password] = @p";
            return _db.GetTable(sql,
                new SqlParameter("@u", userName),
                new SqlParameter("@p", passHash));
        }

        // ===== CỦA NAM: lấy họ tên + chức vụ để hiển thị (nếu tên cột khác thì sửa ở câu SQL này) =====
        public DataTable GetHoTenChucVu(string maNV)
        {
            string sql = @"SELECT nv.HoTen, cv.TenChucVu
                           FROM NhanVien nv
                           LEFT JOIN ChucVu cv ON nv.MaCV = cv.MaCV
                           WHERE CAST(nv.MaNV AS VARCHAR(50)) = @nv";
            return _db.GetTable(sql, new SqlParameter("@nv", SqlDbType.VarChar) { Value = (maNV ?? "").Trim() });
        }

        public DataTable GetHoTenChucVu(int maNV)
        {
            return GetHoTenChucVu(maNV.ToString());
        }


        // Long lấy thông tin TK

        public DataTable GetThongTinTK(string maNV)
        {
            string sql = $"Select * from TaiKhoan Where MaNV = '{maNV}'";
            DataTable dt = _db.GetListData(sql);

            return dt;
        }

        // Long cập nhật thông tin
        // Hàm cập nhật thông tin tài khoản theo MaNV (hoặc MaTK)
        public void UpdateTaiKhoan(string maNV, string userName, string sdt, string role)
        {
            string sql = $"UPDATE TaiKhoan " +
                  $"SET UserName = N'{userName}', " +
                  $"    SDT = '{sdt}', " +
                  $"    Role = N'{role}' " +
                  $"WHERE MaNV = '{maNV}'";

            _db.DataChange(sql);
        }

        // cập nhật ảnh
    
        public void UpdateImage(string maNV, string urlImage)
        {
            string sql = $"Update TaiKhoan SET UrlImage = N'{urlImage}' where MaNV = '{maNV}' ";
            _db.DataChange(sql);
        }
        // thêm tài khoản
        public void ThemTaiKhoanMoi(string maTK, string userName, string password, string sdt, string role,  string maNV)
        {
            string sql = $"INSERT INTO TaiKhoan (MaTK, MaNV, UserName, Password, SDT, Role) " +
                         $"VALUES ('{maTK}', '{maNV}', N'{userName}', '{password}', '{sdt}', N'{role}')";

            _db.DataChange(sql);
        }
        // sinh mã
        public string RenderMaTK()
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            string tiento = "TK" + ngay;
            string sql = $"SELECT TOP 1 MaTK FROM TaiKhoan WHERE MaTK LIKE '{tiento}%' ORDER BY MaTK DESC";
            DataTable dt = _db.GetListData(sql);

            int sttMoi = 1; 

            if (dt.Rows.Count > 0)
            {
                string maMax = dt.Rows[0][0].ToString();
                int soCuoi = Convert.ToInt32(maMax.Substring(maMax.Length - 3));
                sttMoi = soCuoi + 1;
            }

            return tiento + sttMoi.ToString("D3");
        }

        // kiểm tra trùng
        public bool CheckTrungUserName(string userName)
        {
            string sql = $"SELECT COUNT(*) FROM TaiKhoan WHERE UserName = N'{userName}'";
            DataTable dt = _db.GetListData(sql);

            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public bool DoiMatKhau(string maNV, string matKhauCuHash, string matKhauMoiHash)
        {
           
            string checkSql = $"SELECT COUNT(*) FROM TaiKhoan WHERE MaNV = '{maNV}' AND Password = '{matKhauCuHash}'";
            DataTable dt = _db.GetListData(checkSql);

            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                string updateSql = $"UPDATE TaiKhoan SET Password = '{matKhauMoiHash}' WHERE MaNV = '{maNV}'";
                _db.DataChange(updateSql);
                return true; 
            }
            return false; 
        }
        // Đặt lại mật khẩu tài khoản về mật khẩu mặc định theo mã nhân viên
        public bool ResetMatKhau(string maNV, string matKhauMoiHash)
        {
            string sql = $"UPDATE TaiKhoan SET Password = '{matKhauMoiHash}' WHERE MaNV = '{maNV}'";
            _db.DataChange(sql);
            return true;
        }
    }
}