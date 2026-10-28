using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketManagement.Models.Repositories
{
    public class KhoHangRepository
    {
        private DbConection _db = new DbConection();

        #region Quản lý Danh mục

        public DataTable GetDanhMuc()
        {
            string sql = "SELECT MaDM, TenDanhMuc FROM DanhMuc ORDER BY TRY_CAST(MaDM AS INT), MaDM";
            return _db.GetListData(sql);
        }

        public bool KiemTraMaDMTonTai(string maDM)
        {
            if (string.IsNullOrWhiteSpace(maDM)) return false;
            string sql = "SELECT COUNT(*) FROM DanhMuc WHERE MaDM = @MaDM";
            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDM", maDM.Trim());
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public bool KiemTraDanhMucCoSanPham(string maDM)
        {
            if (string.IsNullOrWhiteSpace(maDM)) return false;
            string sql = "SELECT COUNT(*) FROM SanPham WHERE MaDM = @MaDM AND TrangThai = 1";
            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDM", maDM.Trim());
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public void ThemDanhMuc(string maDM, string tenDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(maDM) || KiemTraMaDMTonTai(maDM))
            {
                maDM = GetMaDanhMucMoi();
            }

            string sql = "INSERT INTO DanhMuc (MaDM, TenDanhMuc) VALUES (@MaDM, @TenDM)";
            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDM", maDM.Trim());
                cmd.Parameters.AddWithValue("@TenDM", tenDanhMuc.Trim());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SuaDanhMuc(string maDM, string tenDanhMuc)
        {
            string sql = "UPDATE DanhMuc SET TenDanhMuc = @TenDM WHERE MaDM = @MaDM";
            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDM", maDM.Trim());
                cmd.Parameters.AddWithValue("@TenDM", tenDanhMuc.Trim());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void XoaDanhMuc(string maDM)
        {
            string sql = "DELETE FROM DanhMuc WHERE MaDM = @MaDM";
            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDM", maDM.Trim());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public string GetMaDanhMucMoi()
        {
            string sql = "SELECT ISNULL(MAX(TRY_CAST(MaDM AS INT)), 0) + 1 FROM DanhMuc";
            DataTable dt = _db.GetListData(sql);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return dt.Rows[0][0].ToString();
            }
            return "1";
        }

        #endregion

        #region Quản lý Sản phẩm / Hàng hóa kho

        public DataTable GetSanPham()
        {
            string sql = @"
                SELECT 
                    sp.MaSP, 
                    sp.TenSanPham, 
                    ISNULL(sp.SoLuongTong, 0) AS SoLuongTong, 
                    ISNULL(sp.SoLuongTong, 0) AS SoLuong,
                    ISNULL(u.TenDV, N'Cái') AS TenDV,
                    u.MaDVT,
                    ISNULL(u.DonGiaNhapLe, 0) AS DonGiaNhap, 
                    ISNULL(u.DonGiaBanLe, 0) AS DonGiaBan, 
                    sp.MoTa, 
                    sp.MaDM,
                    dm.TenDanhMuc,
                    sp.MaNCC,
                    ncc.TenNCC
                FROM SanPham sp
                LEFT JOIN DanhMuc dm ON sp.MaDM = dm.MaDM
                LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
                OUTER APPLY (
                    SELECT TOP 1 d.MaDVT, d.SoLuongQuyDoi, d.DonGiaNhapLe, d.DonGiaBanLe, dv.TenDV
                    FROM SanPham_DonViTinh d
                    JOIN DonViTinh dv ON dv.MaDVT = d.MaDVT
                    WHERE d.MaSP = sp.MaSP
                    ORDER BY d.SoLuongQuyDoi ASC, d.MaDVT
                ) u
                WHERE sp.TrangThai = 1
                ORDER BY TRY_CAST(sp.MaSP AS INT), sp.MaSP";
            return _db.GetListData(sql);
        }

        public DataTable TimKiemSanPham(string tuKhoa)
        {
            string tuKhoaEsc = (tuKhoa ?? "").Trim().Replace("'", "''");
            string sql = $@"
                SELECT 
                    sp.MaSP, 
                    sp.TenSanPham, 
                    ISNULL(sp.SoLuongTong, 0) AS SoLuongTong, 
                    ISNULL(sp.SoLuongTong, 0) AS SoLuong,
                    ISNULL(u.TenDV, N'Cái') AS TenDV,
                    u.MaDVT,
                    ISNULL(u.DonGiaNhapLe, 0) AS DonGiaNhap, 
                    ISNULL(u.DonGiaBanLe, 0) AS DonGiaBan, 
                    sp.MoTa, 
                    sp.MaDM,
                    dm.TenDanhMuc,
                    sp.MaNCC,
                    ncc.TenNCC
                FROM SanPham sp
                LEFT JOIN DanhMuc dm ON sp.MaDM = dm.MaDM
                LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
                OUTER APPLY (
                    SELECT TOP 1 d.MaDVT, d.SoLuongQuyDoi, d.DonGiaNhapLe, d.DonGiaBanLe, dv.TenDV
                    FROM SanPham_DonViTinh d
                    JOIN DonViTinh dv ON dv.MaDVT = d.MaDVT
                    WHERE d.MaSP = sp.MaSP
                    ORDER BY d.SoLuongQuyDoi ASC, d.MaDVT
                ) u
                WHERE sp.TrangThai = 1 
                  AND (sp.TenSanPham LIKE N'%{tuKhoaEsc}%' OR sp.MaSP LIKE '%{tuKhoaEsc}%')
                ORDER BY TRY_CAST(sp.MaSP AS INT), sp.MaSP";
            return _db.GetListData(sql);
        }

        public void ThemSanPham(int maSP, string tenSP, int soLuong, double trongLuong, decimal giaNhap, decimal giaBan, string moTa, int maDM, int maNV)
        {
            using (SqlConnection conn = _db.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert vào SanPham (dùng SoLuongTong)
                        string sqlSP = @"
                            INSERT INTO SanPham (MaSP, TenSanPham, SoLuongTong, UrlImage, MoTa, MaDM, MaKM, MaNV, TrangThai)
                            VALUES (@MaSP, @TenSP, @SoLuongTong, '', @MoTa, @MaDM, 1, @MaNV, 1)";
                        using (SqlCommand cmd = new SqlCommand(sqlSP, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP.ToString());
                            cmd.Parameters.AddWithValue("@TenSP", tenSP.Trim());
                            cmd.Parameters.AddWithValue("@SoLuongTong", soLuong);
                            cmd.Parameters.AddWithValue("@MoTa", (object)moTa ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaDM", maDM.ToString());
                            cmd.Parameters.AddWithValue("@MaNV", maNV.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Thêm đơn vị tính mặc định (DV01) vào SanPham_DonViTinh
                        string sqlDVT = @"
                            IF NOT EXISTS (SELECT 1 FROM SanPham_DonViTinh WHERE MaSP = @MaSP AND MaDVT = 'DV01')
                                INSERT INTO SanPham_DonViTinh (MaDVT, MaSP, SoLuongQuyDoi, DonGiaNhapLe, DonGiaBanLe)
                                VALUES ('DV01', @MaSP, 1, @GiaNhap, @GiaBan)
                            ELSE
                                UPDATE SanPham_DonViTinh SET DonGiaNhapLe = @GiaNhap, DonGiaBanLe = @GiaBan WHERE MaSP = @MaSP AND MaDVT = 'DV01'";
                        using (SqlCommand cmd = new SqlCommand(sqlDVT, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP.ToString());
                            cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
                            cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void SuaSanPham(int maSP, string tenSP, int soLuong, double trongLuong, decimal giaNhap, decimal giaBan, string moTa, int maDM)
        {
            using (SqlConnection conn = _db.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlSP = @"
                            UPDATE SanPham 
                            SET TenSanPham = @TenSP, 
                                SoLuongTong = @SoLuongTong, 
                                MoTa = @MoTa, 
                                MaDM = @MaDM
                            WHERE MaSP = @MaSP";
                        using (SqlCommand cmd = new SqlCommand(sqlSP, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP.ToString());
                            cmd.Parameters.AddWithValue("@TenSP", tenSP.Trim());
                            cmd.Parameters.AddWithValue("@SoLuongTong", soLuong);
                            cmd.Parameters.AddWithValue("@MoTa", (object)moTa ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaDM", maDM.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        // Cập nhật giá cho đơn vị tính cơ bản
                        string sqlDVT = @"
                            UPDATE SanPham_DonViTinh 
                            SET DonGiaNhapLe = @GiaNhap, DonGiaBanLe = @GiaBan 
                            WHERE MaSP = @MaSP AND SoLuongQuyDoi = (SELECT MIN(SoLuongQuyDoi) FROM SanPham_DonViTinh WHERE MaSP = @MaSP)";
                        using (SqlCommand cmd = new SqlCommand(sqlDVT, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP.ToString());
                            cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
                            cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void XoaSanPham(int maSP)
        {
            string sql = "UPDATE SanPham SET TrangThai = 0 WHERE MaSP = @MaSP";
            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSP", maSP.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public string GetMaSanPhamMoi()
        {
            string sql = "SELECT ISNULL(MAX(TRY_CAST(MaSP AS INT)), 0) + 1 FROM SanPham";
            DataTable dt = _db.GetListData(sql);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return dt.Rows[0][0].ToString();
            }
            return "1";
        }

        #endregion

        #region Nhà Cung Cấp & Nhân Viên

        public DataTable GetNhaCungCap()
        {
            string sql = "SELECT MaNCC, TenNCC, DiaChi, SDT FROM NhaCungCap ORDER BY TenNCC";
            return _db.GetListData(sql);
        }

        public string GetMaNhaCungCapMoi()
        {
            string sql = "SELECT ISNULL(MAX(TRY_CAST(MaNCC AS INT)), 0) + 1 FROM NhaCungCap";
            DataTable dt = _db.GetListData(sql);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                int maxInt = Convert.ToInt32(dt.Rows[0][0]);
                if (maxInt > 0) return maxInt.ToString();
            }
            return "1";
        }

        public void ThemNhaCungCap(string maNCC, string tenNCC, string diaChi, string sdt)
        {
            string sql = @"
                INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SDT)
                VALUES (@MaNCC, @TenNCC, @DiaChi, @SDT)";
            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaNCC", maNCC.Trim());
                cmd.Parameters.AddWithValue("@TenNCC", tenNCC.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", (object)diaChi?.Trim() ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SDT", (object)sdt?.Trim() ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetNhanVien()
        {
            string sql = "SELECT MaNV, HoTen FROM NhanVien ORDER BY HoTen";
            return _db.GetListData(sql);
        }

        #endregion

        #region Đơn Vị Tính & Quy Đổi

        public DataTable GetAllDonViTinh()
        {
            string sql = "SELECT MaDVT, TenDV, GhiChu FROM DonViTinh ORDER BY TenDV";
            return _db.GetListData(sql);
        }

        public DataTable GetDonViTinhTheoSanPham(string maSP)
        {
            string sql = @"
                SELECT d.MaDVT, dv.TenDV, d.SoLuongQuyDoi, 
                       ISNULL(d.DonGiaNhapLe, 0) AS DonGiaNhapLe, 
                       ISNULL(d.DonGiaBanLe, 0) AS DonGiaBanLe
                FROM SanPham_DonViTinh d
                JOIN DonViTinh dv ON dv.MaDVT = d.MaDVT
                WHERE d.MaSP = @MaSP
                ORDER BY d.SoLuongQuyDoi ASC";

            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSP", maSP.Trim());
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    // Fallback nếu sản phẩm chưa có DVT nào được cấu hình
                    DataTable dtFallback = new DataTable();
                    dtFallback.Columns.Add("MaDVT", typeof(string));
                    dtFallback.Columns.Add("TenDV", typeof(string));
                    dtFallback.Columns.Add("SoLuongQuyDoi", typeof(int));
                    dtFallback.Columns.Add("DonGiaNhapLe", typeof(decimal));
                    dtFallback.Columns.Add("DonGiaBanLe", typeof(decimal));

                    dtFallback.Rows.Add("DV01", "Cái", 1, 0, 0);
                    return dtFallback;
                }
                return dt;
            }
        }

        #endregion

        #region Quản lý Phiếu Nhập & Chi Tiết Nhập Hàng (Nhiều hàng từ 1 NCC, Quy đổi DVT)

        public void SuaPhieuNhap(string maPNH, DateTime ngayNhap, int maNV, int maNCC)
        {
            string sql = @"
                UPDATE PhieuNhapHang 
                SET NgayNhap = @NgayNhap, MaNV = @MaNV, MaNCC = @MaNCC 
                WHERE MaPNH = @MaPNH";
            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPNH", maPNH.Trim());
                cmd.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                cmd.Parameters.AddWithValue("@MaNV", maNV.ToString());
                cmd.Parameters.AddWithValue("@MaNCC", maNCC.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public string GetMaPhieuNhapMoi()
        {
            string sql = "SELECT TOP 1 MaPNH FROM PhieuNhapHang WHERE MaPNH LIKE 'PNH%' ORDER BY LEN(MaPNH) DESC, MaPNH DESC";
            DataTable dt = _db.GetListData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string maCu = dt.Rows[0]["MaPNH"].ToString();
                if (maCu.Length >= 6 && maCu.StartsWith("PNH"))
                {
                    string phanSo = maCu.Substring(3);
                    if (int.TryParse(phanSo, out int soMoi))
                    {
                        soMoi++;
                        return "PNH" + soMoi.ToString("D3");
                    }
                }
            }
            return "PNH001";
        }

        public DataTable GetPhieuNhapHang()
        {
            string sql = @"
                SELECT 
                    pnh.MaPNH,
                    pnh.NgayNhap,
                    pnh.MaNCC,
                    ISNULL(ncc.TenNCC, N'Chưa rõ') AS TenNCC,
                    pnh.MaNV,
                    ISNULL(nv.HoTen, N'Chưa rõ') AS NguoiNhap,
                    COUNT(ct.MaSP) AS SoMatHang,
                    ISNULL(SUM(ct.SoLuongNhap * ct.DonGiaNhap), 0) AS TongTien
                FROM PhieuNhapHang pnh
                LEFT JOIN NhaCungCap ncc ON pnh.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON pnh.MaNV = nv.MaNV
                LEFT JOIN ChiTietPhieuNhapHang ct ON pnh.MaPNH = ct.MaPNH
                GROUP BY pnh.MaPNH, pnh.NgayNhap, pnh.MaNCC, ncc.TenNCC, pnh.MaNV, nv.HoTen
                ORDER BY pnh.NgayNhap DESC, pnh.MaPNH DESC";
            return _db.GetListData(sql);
        }

        public DataTable GetChiTietPhieuNhap(string maPNH)
        {
            string sql = @"
                SELECT 
                    ct.MaPNH,
                    ct.MaSP,
                    sp.TenSanPham,
                    ct.MaDVT,
                    ISNULL(dv.TenDV, N'Cái') AS TenDV,
                    ct.SoLuongNhap,
                    ISNULL(d.SoLuongQuyDoi, 1) AS SoLuongQuyDoi,
                    (ct.SoLuongNhap * ISNULL(d.SoLuongQuyDoi, 1)) AS SoLuongQuyDoiKho,
                    ct.DonGiaNhap,
                    (ct.SoLuongNhap * ct.DonGiaNhap) AS ThanhTien,
                    ct.NgaySanXuat,
                    ct.NgayHetHan
                FROM ChiTietPhieuNhapHang ct
                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                LEFT JOIN DonViTinh dv ON ct.MaDVT = dv.MaDVT
                LEFT JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                WHERE ct.MaPNH = @MaPNH
                ORDER BY ct.MaSP";

            using (SqlConnection conn = _db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPNH", maPNH.Trim());
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lưu phiếu nhập hàng gồm nhiều sản phẩm từ 1 Nhà Cung Cấp.
        /// Quy đổi số lượng nhập thành đơn vị cơ bản (nhỏ nhất) trước khi lưu cộng vào SanPham.SoLuongTong.
        /// </summary>
        public bool LuuPhieuNhapVaChiTiet(string maPNH, DateTime ngayNhap, string maNCC, string maNV, DataTable dtChiTiet)
        {
            using (SqlConnection conn = _db.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Thêm Phiếu Nhập Hàng
                        string sqlPhieu = @"
                            INSERT INTO PhieuNhapHang (MaPNH, NgayNhap, MaNCC, MaNV)
                            VALUES (@MaPNH, @NgayNhap, @MaNCC, @MaNV)";
                        using (SqlCommand cmd = new SqlCommand(sqlPhieu, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaPNH", maPNH.Trim());
                            cmd.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                            cmd.Parameters.AddWithValue("@MaNCC", (object)maNCC?.Trim() ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaNV", (object)maNV?.Trim() ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Lặp qua từng mặt hàng trong danh sách chi tiết
                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            string maSP = row["MaSP"].ToString().Trim();
                            string maDVT = row["MaDVT"].ToString().Trim();
                            int soLuongNhap = Convert.ToInt32(row["SoLuongNhap"]);
                            int soLuongQuyDoi = Convert.ToInt32(row["SoLuongQuyDoi"]);
                            if (soLuongQuyDoi <= 0) soLuongQuyDoi = 1;

                            decimal donGiaNhap = Convert.ToDecimal(row["DonGiaNhap"]);

                            object nsx = row["NgaySanXuat"] == null || row["NgaySanXuat"] == DBNull.Value ? DBNull.Value : row["NgaySanXuat"];
                            object hsd = row["NgayHetHan"] == null || row["NgayHetHan"] == DBNull.Value ? DBNull.Value : row["NgayHetHan"];

                            // 2.1. Đảm bảo cấu hình đơn vị tính & giá nhập trong SanPham_DonViTinh TRƯỚC
                            // để thỏa mãn Foreign Key FK_CTPNH_SanPham_DonViTinh
                            string sqlDVT = @"
                                IF EXISTS (SELECT 1 FROM SanPham_DonViTinh WHERE MaSP = @MaSP AND MaDVT = @MaDVT)
                                    UPDATE SanPham_DonViTinh 
                                    SET SoLuongQuyDoi = @SoLuongQuyDoi, 
                                        DonGiaNhapLe = @DonGiaNhap
                                    WHERE MaSP = @MaSP AND MaDVT = @MaDVT
                                ELSE
                                    INSERT INTO SanPham_DonViTinh (MaDVT, MaSP, SoLuongQuyDoi, DonGiaNhapLe, DonGiaBanLe)
                                    VALUES (@MaDVT, @MaSP, @SoLuongQuyDoi, @DonGiaNhap, 0)";
                            using (SqlCommand cmd = new SqlCommand(sqlDVT, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@MaSP", maSP);
                                cmd.Parameters.AddWithValue("@MaDVT", maDVT);
                                cmd.Parameters.AddWithValue("@SoLuongQuyDoi", soLuongQuyDoi);
                                cmd.Parameters.AddWithValue("@DonGiaNhap", donGiaNhap);
                                cmd.ExecuteNonQuery();
                            }

                            // 2.2. Thêm vào bảng ChiTietPhieuNhapHang
                            string sqlChiTiet = @"
                                INSERT INTO ChiTietPhieuNhapHang (MaPNH, MaSP, SoLuongNhap, DonGiaNhap, MaDVT, NgaySanXuat, NgayHetHan)
                                VALUES (@MaPNH, @MaSP, @SoLuongNhap, @DonGiaNhap, @MaDVT, @NSX, @HSD)";
                            using (SqlCommand cmd = new SqlCommand(sqlChiTiet, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@MaPNH", maPNH.Trim());
                                cmd.Parameters.AddWithValue("@MaSP", maSP);
                                cmd.Parameters.AddWithValue("@SoLuongNhap", soLuongNhap);
                                cmd.Parameters.AddWithValue("@DonGiaNhap", donGiaNhap);
                                cmd.Parameters.AddWithValue("@MaDVT", maDVT);
                                cmd.Parameters.AddWithValue("@NSX", nsx);
                                cmd.Parameters.AddWithValue("@HSD", hsd);
                                cmd.ExecuteNonQuery();
                            }

                            // 2.3. CẬP NHẬT TỔNG SỐ LƯỢNG KHO:
                            // Quy đổi số lượng nhập thành đơn vị nhỏ hơn (đơn vị cơ sở) = soLuongNhap * soLuongQuyDoi
                            int soLuongQuyDoiKho = soLuongNhap * soLuongQuyDoi;
                            string sqlUpdateSP = @"
                                UPDATE SanPham 
                                SET SoLuongTong = ISNULL(SoLuongTong, 0) + @SoLuongQuyDoiKho
                                WHERE MaSP = @MaSP";
                            using (SqlCommand cmd = new SqlCommand(sqlUpdateSP, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@SoLuongQuyDoiKho", soLuongQuyDoiKho);
                                cmd.Parameters.AddWithValue("@MaSP", maSP);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void XoaPhieuNhap(string maPNH)
        {
            using (SqlConnection conn = _db.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Lấy danh sách hàng hóa trong phiếu để hoàn trừ lại số lượng quy đổi trong kho
                        string sqlGetItems = @"
                            SELECT ct.MaSP, ct.SoLuongNhap, ISNULL(d.SoLuongQuyDoi, 1) AS SoLuongQuyDoi
                            FROM ChiTietPhieuNhapHang ct
                            LEFT JOIN SanPham_DonViTinh d ON d.MaSP = ct.MaSP AND d.MaDVT = ct.MaDVT
                            WHERE ct.MaPNH = @MaPNH";

                        using (SqlCommand cmd = new SqlCommand(sqlGetItems, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaPNH", maPNH.Trim());
                            DataTable dt = new DataTable();
                            new SqlDataAdapter(cmd).Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                string maSP = row["MaSP"].ToString();
                                int slNhap = Convert.ToInt32(row["SoLuongNhap"]);
                                int quyDoi = Convert.ToInt32(row["SoLuongQuyDoi"]);
                                if (quyDoi <= 0) quyDoi = 1;
                                int tongTru = slNhap * quyDoi;

                                string sqlTru = @"
                                    UPDATE SanPham 
                                    SET SoLuongTong = CASE WHEN ISNULL(SoLuongTong, 0) >= @TongTru THEN SoLuongTong - @TongTru ELSE 0 END
                                    WHERE MaSP = @MaSP";
                                using (SqlCommand cmdTru = new SqlCommand(sqlTru, conn, trans))
                                {
                                    cmdTru.Parameters.AddWithValue("@TongTru", tongTru);
                                    cmdTru.Parameters.AddWithValue("@MaSP", maSP);
                                    cmdTru.ExecuteNonQuery();
                                }
                            }
                        }

                        // 2. Xóa chi tiết phiếu
                        string sqlDelCT = "DELETE FROM ChiTietPhieuNhapHang WHERE MaPNH = @MaPNH";
                        using (SqlCommand cmd = new SqlCommand(sqlDelCT, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaPNH", maPNH.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Xóa phiếu nhập
                        string sqlDelPhieu = "DELETE FROM PhieuNhapHang WHERE MaPNH = @MaPNH";
                        using (SqlCommand cmd = new SqlCommand(sqlDelPhieu, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaPNH", maPNH.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion
    }
}
