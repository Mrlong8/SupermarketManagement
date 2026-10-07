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
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, sqlConnection);
            sqlDataAdapter.Fill(tblData);
            CloseConnection();
            return tblData;
        }

        // ===== PHẦN THÊM MỚI (có tham số @param để tránh SQL Injection) =====

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