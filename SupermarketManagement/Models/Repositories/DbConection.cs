using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagement.Controllers.Repositories
{
    public class DbConection
    {

        
        // khai báo biết chuỗi kết nối đến cơ sở dữ liệu SQL Server
        string str = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SupermarketManagement;Integrated Security=True";
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

        public DataTable GetListData(string str)
        {
            DataTable tblData = new DataTable();
            OpenConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str,sqlConnection);
            sqlDataAdapter.Fill(tblData);
            CloseConnection();
            return tblData;
        }



        //public static class DBHelper
        //{
        //    // Sửa Server cho đúng máy của bạn (vd: .\SQLEXPRESS hoặc (localdb)\MSSQLLocalDB)


        //    public static DataTable GetTable(string sql, params SqlParameter[] ps)
        //    {
        //        using (var conn = new SqlConnection(str))
        //        using (var cmd = new SqlCommand(sql, conn))
        //        {
        //            if (ps != null) cmd.Parameters.AddRange(ps);
        //            var dt = new DataTable();
        //            new SqlDataAdapter(cmd).Fill(dt);
        //            return dt;
        //        }
        //    }

        //    public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        //    {
        //        using (var conn = new SqlConnection(str))
        //        using (var cmd = new SqlCommand(sql, conn))
        //        {
        //            if (ps != null) cmd.Parameters.AddRange(ps);
        //            conn.Open();
        //            return cmd.ExecuteNonQuery();
        //        }
        //    }

        //    public static string Sha256(string input)
        //    {
        //        using (var sha = SHA256.Create())
        //        {
        //            byte[] h = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        //            return BitConverter.ToString(h).Replace("-", ""); // hex in hoa, khớp với SQL
        //        }
        //    }
        //}

    }
}
