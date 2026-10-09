using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SupermarketManagement.Controllers.Repositories
{
    public class DbConection
    {


        // khai báo biết chuỗi kết nối đến cơ sở dữ liệu SQL Server
        private static  string str = @"Data Source=localhost;Initial Catalog=SupermarketManagement;Integrated Security=True";
        // csdl của ai thì đổi địa chỉ ở đây  nhớ copy ra òng khác và conment lại dòng này để tránh xung đột nhé
        SqlConnection sqlConnection = null;


        // phương thưc mở kết nối đến cơ sở dữ liệu SQL Server
        void OpenConnection()
        {
            sqlConnection = new SqlConnection(str);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        // phương thức đóng kết nối đến cơ sở dữ liệu SQL Server
        void CloseConnection()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        // phuiong thức lấy dữ liệu từ cơ sở dữ liệu SQL Server và trả về một DataTable
        public DataTable GetListData(string str)
        {
            DataTable tblData = new DataTable();
            OpenConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, sqlConnection);
            sqlDataAdapter.Fill(tblData);
            CloseConnection();
            return tblData;
        }
        // phương thức thực thi câu lệnh SQL dang INSERT, UPDATE, DELETE

        public void DataChange(string sql)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            CloseConnection();
        }


        public static class DBHelper
        {
            // Sửa Server cho đúng máy của bạn (vd: .\SQLEXPRESS hoặc (localdb)\MSSQLLocalDB)


            public static DataTable GetTable(string sql, params SqlParameter[] ps)
            {
                using (var conn = new SqlConnection(str))
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
                using (var conn = new SqlConnection(str))
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


         //================= CỦA NAM: 2 hàm có tham số @param(chống SQL Injection) =================
         //Đang comment để không đụng code chung.Cần dùng thì bỏ comment(nhớ báo nhóm trưởng).

        // SELECT có tham số. Ví dụ: GetTable("SELECT * FROM TaiKhoan WHERE UserName=@u", new SqlParameter("@u", "admin"))
        public DataTable GetTable(string sql, params SqlParameter[] ps)
        {
            DataTable tblData = new DataTable();
            OpenConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    if (ps != null) cmd.Parameters.AddRange(ps);
                    new SqlDataAdapter(cmd).Fill(tblData);
                }
            }
            finally
            {
                CloseConnection();
            }
            return tblData;
        }

        // INSERT / UPDATE / DELETE. Trả về số dòng bị ảnh hưởng
        public int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            OpenConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    if (ps != null) cmd.Parameters.AddRange(ps);
                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}