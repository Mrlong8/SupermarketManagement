using System;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Models.Repositories
{
    internal class HoaDonRepository
    {
        private readonly string connectionString =
           @"Data Source=localhost;Initial Catalog=SupermarketManagement_New;Integrated Security=True";
        //private readonly string connectionString =
        //    @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SupermarketManagement;Integrated Security=True";

        //private static string str = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SupermarketManagement;Integrated Security=True"; ///của Long


        /// <summary>
        /// Lưu hóa đơn và các sản phẩm thuộc hóa đơn vào database.
        /// </summary>


        public void LuuHoaDon(
            string maHD,
            decimal tongTien,
            DateTime ngayMua,
            string maKH,
            string maNV,
            DataTable chiTiet,
            int diemSuDung)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                throw new ArgumentException("Mã hóa đơn không được để trống.");

            if (chiTiet == null || chiTiet.Rows.Count == 0)
                throw new ArgumentException("Hóa đơn phải có ít nhất một sản phẩm.");

            if (tongTien < 0 || diemSuDung < 0)
                throw new ArgumentException("Tổng tiền và điểm sử dụng không hợp lệ.");

            int diemMoi = (int)(tongTien / 10000m);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra điểm khách hàng.
                        int diemCu = 0;

                        if (!string.IsNullOrWhiteSpace(maKH))
                        {
                            string sqlDiem = @"
                        SELECT DiemTichLuy
                        FROM dbo.KhachHang WITH (UPDLOCK, HOLDLOCK)
                        WHERE MaKH = @MaKH";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlDiem, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20)
                                    .Value = maKH.Trim();

                                object ketQua = cmd.ExecuteScalar();

                                if (ketQua == null || ketQua == DBNull.Value)
                                    throw new Exception("Không tìm thấy khách hàng.");

                                diemCu = Convert.ToInt32(ketQua);
                            }
                        }
                        else if (diemSuDung > 0)
                        {
                            throw new Exception(
                                "Phải chọn khách hàng mới được sử dụng điểm.");
                        }


                        // 2. Kiểm tra điểm sử dụng theo quy tắc mới:
                        // 10 điểm = 1% giảm giá.
                        if (diemSuDung > diemCu)
                            throw new Exception(
                                $"Không đủ điểm. Điểm hiện có: {diemCu}, " +
                                $"điểm cần dùng: {diemSuDung}.");

                        int phanTramGiam = diemSuDung / 10;

                        if (diemSuDung % 10 != 0)
                            throw new Exception(
                                "Điểm sử dụng phải tương ứng với mức giảm 5%, 10%, 20% hoặc 30%.");

                        if (phanTramGiam != 0 &&
                            phanTramGiam != 5 &&
                            phanTramGiam != 10 &&
                            phanTramGiam != 20 &&
                            phanTramGiam != 30)
                            throw new Exception("Mức giảm giá không hợp lệ.");

                        decimal tienGiamGia = tongTien * phanTramGiam / 100m;

                        if (tienGiamGia > tongTien)
                            throw new Exception(
                                "Tiền giảm giá vượt quá tổng tiền hàng.");


                        // 3. Gộp số lượng nếu cùng một sản phẩm xuất hiện nhiều dòng.
                        DataTable sanPhamBan = new DataTable();
                        sanPhamBan.Columns.Add("MaSP", typeof(string));
                        sanPhamBan.Columns.Add("SoLuongBan", typeof(int));

                        foreach (DataRow row in chiTiet.Rows)
                        {
                            string maSP = Convert.ToString(row["MaSP"]);

                            if (string.IsNullOrWhiteSpace(maSP))
                                throw new Exception("Mã sản phẩm không được để trống.");

                            int soLuong = Convert.ToInt32(row["SoLuongBan"]);

                            if (soLuong <= 0)
                                throw new Exception("Số lượng bán phải lớn hơn 0.");

                            DataRow dongCu = null;

                            foreach (DataRow dong in sanPhamBan.Rows)
                            {
                                if (Convert.ToString(dong["MaSP"]) == maSP.Trim())
                                {
                                    dongCu = dong;
                                    break;
                                }
                            }

                            if (dongCu == null)
                                sanPhamBan.Rows.Add(maSP.Trim(), soLuong);
                            else
                                dongCu["SoLuongBan"] =
                                    Convert.ToInt32(dongCu["SoLuongBan"]) + soLuong;
                        }

                        // 4. Kiểm tra tồn kho và trừ kho trong transaction.
                        foreach (DataRow row in sanPhamBan.Rows)
                        {
                            string maSP = Convert.ToString(row["MaSP"]);
                            int soLuong = Convert.ToInt32(row["SoLuongBan"]);

                            string sqlTruKho = @"
                                UPDATE dbo.SanPham
                                SET SoLuong = SoLuong - @SoLuong
                                WHERE MaSP = @MaSP
                                  AND SoLuong >= @SoLuong";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlTruKho, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 20)
                                    .Value = maSP;

                                cmd.Parameters.Add("@SoLuong", SqlDbType.Int)
                                    .Value = soLuong;

                                if (cmd.ExecuteNonQuery() != 1)
                                {
                                    throw new Exception(
                                        "Sản phẩm mã " + maSP +
                                        " không tồn tại hoặc không đủ hàng trong kho.");
                                }
                            }
                        }

                        // 5. Lưu hóa đơn.
                        string sqlHoaDon = @"
                            INSERT INTO dbo.HoaDon
                                (MaHD, NgayMua, MaKH, MaNV)
                            VALUES
                                (@MaHD, @NgayMua, @MaKH, @MaNV)";

                        using (SqlCommand cmd =
                            new SqlCommand(sqlHoaDon, conn, transaction))
                        {
                            cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20)
                                .Value = maHD.Trim();

                            cmd.Parameters.Add("@NgayMua", SqlDbType.DateTime)
                                .Value = ngayMua;

                            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20)
                                .Value = string.IsNullOrWhiteSpace(maKH)
                                    ? (object)DBNull.Value : maKH.Trim();

                            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 20)
                                .Value = string.IsNullOrWhiteSpace(maNV)
                                    ? (object)DBNull.Value : maNV.Trim();

                            cmd.ExecuteNonQuery();
                        }

                        // 6. Lưu chi tiết hóa đơn.
                        string sqlChiTiet = @"
                            INSERT INTO dbo.ChiTietHoaDon
                                (MaHD, MaSP, SoLuongBan)
                            VALUES
                                (@MaHD, @MaSP, @SoLuongBan)";

                        foreach (DataRow row in chiTiet.Rows)
                        {
                            using (SqlCommand cmd =
                                new SqlCommand(sqlChiTiet, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 20)
                                    .Value = maHD.Trim();

                                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 20)
                                    .Value = Convert.ToString(row["MaSP"]).Trim();

                                cmd.Parameters.Add("@SoLuongBan", SqlDbType.Int)
                                    .Value = Convert.ToInt32(row["SoLuongBan"]);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 7. Cập nhật điểm khách hàng.
                        if (!string.IsNullOrWhiteSpace(maKH))
                        {
                            int diemSauThanhToan = diemCu - diemSuDung + diemMoi;

                            string sqlCapNhatDiem = @"
                                UPDATE dbo.KhachHang
                                SET DiemTichLuy = @DiemMoi
                                WHERE MaKH = @MaKH";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlCapNhatDiem, conn, transaction))
                            {
                                cmd.Parameters.Add("@DiemMoi", SqlDbType.Int)
                                    .Value = diemSauThanhToan;

                                cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 20)
                                    .Value = maKH.Trim();

                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception(
                                        "Không cập nhật được điểm khách hàng.");
                            }
                        }

                        // 8. Chỉ xác nhận khi tất cả thao tác thành công.
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