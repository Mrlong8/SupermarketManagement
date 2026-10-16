using System;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Models.Repositories
{
    internal class HoaDonRepository
    {
        private readonly string connectionString =
           @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SupermarketManagement;Integrated Security=True";

        /// <summary>
        /// Lưu hóa đơn và các sản phẩm thuộc hóa đơn vào database.
        /// </summary>
        public void LuuHoaDon(
            string maHD,
            decimal tongTien,
            DateTime ngayMua,
            string maKH,
            string maNV,
            DataTable chiTiet)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                throw new ArgumentException("Mã hóa đơn không được để trống.");

            if (chiTiet == null || chiTiet.Rows.Count == 0)
                throw new ArgumentException("Hóa đơn phải có ít nhất một sản phẩm.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Lưu thông tin hóa đơn.
                        // Database mới không có cột TongTien trong kết quả cấu trúc.
                        string sqlHoaDon = @"
                            INSERT INTO dbo.HoaDon
                                (MaHD, NgayMua, MaKH, MaNV)
                            VALUES
                                (@MaHD, @NgayMua, @MaKH, @MaNV);";

                        using (SqlCommand cmd =
                            new SqlCommand(sqlHoaDon, conn, transaction))
                        {
                            cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20)
                                .Value = maHD.Trim();

                            cmd.Parameters.Add("@NgayMua", SqlDbType.DateTime)
                                .Value = ngayMua;

                            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20)
                                .Value = string.IsNullOrWhiteSpace(maKH)
                                    ? (object)DBNull.Value
                                    : maKH.Trim();

                            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 20)
                                .Value = string.IsNullOrWhiteSpace(maNV)
                                    ? (object)DBNull.Value
                                    : maNV.Trim();

                            cmd.ExecuteNonQuery();
                        }

                        // 2. Lưu chi tiết từng sản phẩm.
                        // Database mới chỉ có MaHD, MaSP và SoLuongBan
                        // trong kết quả cấu trúc bảng ChiTietHoaDon.
                        string sqlChiTiet = @"
                            INSERT INTO dbo.ChiTietHoaDon
                                (MaHD, MaSP, SoLuongBan)
                            VALUES
                                (@MaHD, @MaSP, @SoLuongBan);";

                        foreach (DataRow row in chiTiet.Rows)
                        {
                            string maSP = Convert.ToString(row["MaSP"]);

                            int soLuongBan = Convert.ToInt32(row["SoLuongBan"]);

                            if (string.IsNullOrWhiteSpace(maSP))
                                throw new ArgumentException(
                                    "Mã sản phẩm không được để trống.");

                            if (soLuongBan <= 0)
                                throw new ArgumentException(
                                    "Số lượng bán phải lớn hơn 0.");

                            using (SqlCommand cmd =
                                new SqlCommand(sqlChiTiet, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20)
                                    .Value = maHD.Trim();

                                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 20)
                                    .Value = maSP.Trim();

                                cmd.Parameters.Add("@SoLuongBan", SqlDbType.Int)
                                    .Value = soLuongBan;

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3. Chỉ xác nhận khi toàn bộ dữ liệu đã được lưu.
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