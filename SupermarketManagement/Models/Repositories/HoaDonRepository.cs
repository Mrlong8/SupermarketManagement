
using System;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Models.Repositories
{
    internal class HoaDonRepository
    {
        //phần lưu hóa đơn vào database của diễn
        private readonly string connectionString =
            @"Data Source=localhost;Initial Catalog=SupermarketManagement;Integrated Security=True";

        public void LuuHoaDon(
            string maHD,
            decimal tongTien,
            DateTime ngayMua,
            string maKH,
            string maNV,
            DataTable chiTiet)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction =
                    conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHoaDon = @"
                            INSERT INTO HoaDon
                                (MaHD, TongTien, NgayMua, MaKH, MaNV)
                            VALUES
                                (@MaHD, @TongTien, @NgayMua, @MaKH, @MaNV)";

                        using (SqlCommand cmd =
                            new SqlCommand(sqlHoaDon, conn, transaction))
                        {
                            cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20)
                                .Value = maHD;

                            SqlParameter pTongTien =
                                cmd.Parameters.Add("@TongTien", SqlDbType.Decimal);
                            pTongTien.Precision = 18;
                            pTongTien.Scale = 2;
                            pTongTien.Value = tongTien;

                            cmd.Parameters.Add("@NgayMua", SqlDbType.DateTime)
                                .Value = ngayMua;
                            //chưa có mã khách hàng thật
                            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20).Value =
                                string.IsNullOrWhiteSpace(maKH)
                                ? (object)DBNull.Value
                                : maKH.Trim();

                            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 20)
                                .Value = string.IsNullOrWhiteSpace(maNV)
                                    ? (object)DBNull.Value : maNV;

                            cmd.ExecuteNonQuery();
                        }

                        string sqlChiTiet = @"
                            INSERT INTO ChiTietHoaDon
                                (MaHD, MaSP, SoLuongBan, DonGiaBan)
                            VALUES
                                (@MaHD, @MaSP, @SoLuongBan, @DonGiaBan)";

                        foreach (DataRow row in chiTiet.Rows)
                        {
                            using (SqlCommand cmd =
                                new SqlCommand(sqlChiTiet, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20)
                                    .Value = maHD;

                                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 20)
                                    .Value = Convert.ToString(row["MaSP"]);

                                cmd.Parameters.Add("@SoLuongBan", SqlDbType.Int)
                                    .Value = Convert.ToInt32(row["SoLuongBan"]);

                                SqlParameter pDonGia =
                                    cmd.Parameters.Add("@DonGiaBan", SqlDbType.Decimal);
                                pDonGia.Precision = 18;
                                pDonGia.Scale = 2;
                                pDonGia.Value = Convert.ToDecimal(row["DonGiaBan"]);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}