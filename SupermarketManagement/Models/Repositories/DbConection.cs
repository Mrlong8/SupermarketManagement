using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography; // Sửa lỗi CS0103: SHA256
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagement.Controllers.Repositories
{
    public class DbConection
    {
        // Thêm 'static' để biến str có thể dùng được trong lớp tĩnh DBHelper (Sửa lỗi CS0120)
        private static string str = @"Data Source=.;Initial Catalog=mauCsdlfinal;Integrated Security=True";

        private SqlConnection sqlConnection = null;

        // Phương thức mở kết nối đến cơ sở dữ liệu SQL Server
        private void OpenConnection()
        {
            sqlConnection = new SqlConnection(str);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        // Phương thức đóng kết nối đến cơ sở dữ liệu SQL Server
        private void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        public DataTable GetListData(string sqlQuery)
        {
            DataTable tblData = new DataTable();
            OpenConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            sqlDataAdapter.Fill(tblData);
            CloseConnection();
            return tblData;
        }

        // ================= CỦA NAM: Hàm có tham số (chống SQL Injection) =================
        public DataTable GetTableInstance(string sql, params SqlParameter[] ps)
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

        public int ExecuteNonQueryInstance(string sql, params SqlParameter[] ps)
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

        // ================= LỚP TĨNH HELPER =================
        public static class DBHelper
        {
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
                    return BitConverter.ToString(h).Replace("-", ""); // Hex in hoa, khớp với SQL
                }
            }
        }
    }
}