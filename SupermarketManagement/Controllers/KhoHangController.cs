using SupermarketManagement.Models.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Controllers
{
    public class KhoHangController
    {
        private KhoHangRepository _repo = new KhoHangRepository();

        #region Danh Mục

        public DataTable LoadDanhMuc()
        {
            return _repo.GetDanhMuc();
        }

        public bool ThemDanhMuc(string maDM, string tenDanhMuc, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(tenDanhMuc))
            {
                thongBao = "Vui lòng nhập tên danh mục!";
                return false;
            }

            try
            {
                _repo.ThemDanhMuc(maDM.Trim(), tenDanhMuc.Trim());
                thongBao = "Thêm danh mục thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi thêm danh mục: " + ex.Message;
                return false;
            }
        }

        public bool SuaDanhMuc(string maDM, string tenDanhMuc, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(maDM))
            {
                thongBao = "Vui lòng chọn một danh mục từ bảng để sửa!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(tenDanhMuc))
            {
                thongBao = "Tên danh mục không được để trống!";
                return false;
            }

            try
            {
                _repo.SuaDanhMuc(maDM.Trim(), tenDanhMuc.Trim());
                thongBao = "Cập nhật danh mục thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi sửa danh mục: " + ex.Message;
                return false;
            }
        }

        public bool XoaDanhMuc(string maDM, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(maDM))
            {
                thongBao = "Vui lòng chọn danh mục cần xóa!";
                return false;
            }

            try
            {
                _repo.XoaDanhMuc(maDM.Trim());
                thongBao = "Xóa danh mục thành công!";
                return true;
            }
            catch (Exception)
            {
                thongBao = "Không thể xóa danh mục này vì đang có hàng hóa thuộc danh mục!";
                return false;
            }
        }

        public string TaoMaDanhMucMoi()
        {
            return _repo.GetMaDanhMucMoi();
        }

        #endregion

        #region Hàng Hóa Sản Phẩm

        public DataTable LoadSanPham()
        {
            return _repo.GetSanPham();
        }

        public DataTable TimKiemSanPham(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return _repo.GetSanPham();
            }
            return _repo.TimKiemSanPham(tuKhoa);
        }

        public bool ThemSanPham(string maSPStr, string tenSP, string soLuongStr, string trongLuongStr, string giaNhapStr, string giaBanStr, string moTa, int maDM, int maNV, out string thongBao)
        {
            if (!int.TryParse(maSPStr, out int maSP))
            {
                thongBao = "Mã hàng hóa không hợp lệ!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(tenSP))
            {
                thongBao = "Vui lòng nhập tên hàng hóa!";
                return false;
            }

            int soLuong = 0;
            if (!int.TryParse(soLuongStr, out soLuong) || soLuong < 0)
            {
                thongBao = "Số lượng phải là số nguyên không âm!";
                return false;
            }

            double trongLuong = 0;
            if (!string.IsNullOrWhiteSpace(trongLuongStr) && (!double.TryParse(trongLuongStr, out trongLuong) || trongLuong < 0))
            {
                trongLuong = 0;
            }

            decimal giaNhap = 0;
            if (!decimal.TryParse(giaNhapStr.Replace(",", "").Replace(".", ""), out giaNhap) || giaNhap < 0)
            {
                giaNhap = 0;
            }

            decimal giaBan = 0;
            if (!decimal.TryParse(giaBanStr.Replace(",", "").Replace(".", ""), out giaBan) || giaBan < 0)
            {
                giaBan = 0;
            }

            try
            {
                if (maNV <= 0) maNV = 1;
                _repo.ThemSanPham(maSP, tenSP.Trim(), soLuong, trongLuong, giaNhap, giaBan, moTa?.Trim(), maDM, maNV);
                thongBao = "Thêm hàng hóa thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi thêm hàng hóa: " + ex.Message;
                return false;
            }
        }

        public bool SuaSanPham(string maSPStr, string tenSP, string soLuongStr, string trongLuongStr, string giaNhapStr, string giaBanStr, string moTa, int maDM, out string thongBao)
        {
            int maSP = 0;
            if (!int.TryParse(maSPStr, out maSP))
            {
                thongBao = "Vui lòng chọn một hàng hóa từ bảng để sửa!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(tenSP))
            {
                thongBao = "Tên hàng hóa không được để trống!";
                return false;
            }

            int soLuong = 0;
            int.TryParse(soLuongStr, out soLuong);

            double trongLuong = 0;
            double.TryParse(trongLuongStr, out trongLuong);

            decimal giaNhap = 0;
            decimal.TryParse(giaNhapStr.Replace(",", "").Replace(".", ""), out giaNhap);

            decimal giaBan = 0;
            decimal.TryParse(giaBanStr.Replace(",", "").Replace(".", ""), out giaBan);

            try
            {
                _repo.SuaSanPham(maSP, tenSP.Trim(), soLuong, trongLuong, giaNhap, giaBan, moTa?.Trim(), maDM);
                thongBao = "Cập nhật hàng hóa thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi sửa hàng hóa: " + ex.Message;
                return false;
            }
        }

        public bool XoaSanPham(string maSPStr, out string thongBao)
        {
            int maSP = 0;
            if (!int.TryParse(maSPStr, out maSP))
            {
                thongBao = "Vui lòng chọn hàng hóa cần xóa!";
                return false;
            }

            try
            {
                _repo.XoaSanPham(maSP);
                thongBao = "Xóa hàng hóa thành công!";
                return true;
            }
            catch (Exception)
            {
                thongBao = "Không thể xóa hàng hóa này vì đã phát sinh trong hóa đơn/phiếu nhập!";
                return false;
            }
        }

        public string TaoMaSanPhamMoi()
        {
            return _repo.GetMaSanPhamMoi();
        }

        #endregion

        #region Nhà Cung Cấp & Nhân Viên

        public DataTable LoadNhaCungCap()
        {
            return _repo.GetNhaCungCap();
        }

        public string TaoMaNhaCungCapMoi()
        {
            return _repo.GetMaNhaCungCapMoi();
        }

        public bool ThemNhaCungCap(string maNCC, string tenNCC, string diaChi, string sdt, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(tenNCC))
            {
                thongBao = "Tên Nhà Cung Cấp không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(maNCC))
            {
                maNCC = _repo.GetMaNhaCungCapMoi();
            }

            try
            {
                _repo.ThemNhaCungCap(maNCC, tenNCC, diaChi, sdt);
                thongBao = "Thêm Nhà Cung Cấp thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi thêm Nhà Cung Cấp: " + ex.Message;
                return false;
            }
        }

        public DataTable LoadNhanVien()
        {
            return _repo.GetNhanVien();
        }

        #endregion

        #region Đơn Vị Tính & Quy Đổi

        public DataTable LoadDonViTinhTheoSanPham(string maSP)
        {
            return _repo.GetDonViTinhTheoSanPham(maSP);
        }

        public DataTable LoadAllDonViTinh()
        {
            return _repo.GetAllDonViTinh();
        }

        #endregion

        #region Phiếu Nhập Hàng (Nhiều hàng từ 1 NCC, Quy đổi DVT)

        public DataTable LoadPhieuNhapHang()
        {
            return _repo.GetPhieuNhapHang();
        }

        public DataTable LoadChiTietPhieuNhap(string maPNH)
        {
            return _repo.GetChiTietPhieuNhap(maPNH);
        }

        public bool SuaPhieuNhap(string maPNH, DateTime ngayNhap, int maNV, int maNCC, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(maPNH))
            {
                thongBao = "Vui lòng chọn một hóa đơn nhập để sửa!";
                return false;
            }

            try
            {
                _repo.SuaPhieuNhap(maPNH.Trim(), ngayNhap, maNV, maNCC);
                thongBao = "Cập nhật hóa đơn nhập thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi sửa hóa đơn nhập: " + ex.Message;
                return false;
            }
        }

        public string TaoMaPhieuNhapMoi()
        {
            return _repo.GetMaPhieuNhapMoi();
        }

        /// <summary>
        /// Lưu phiếu nhập gồm nhiều mặt hàng từ 1 nhà cung cấp.
        /// </summary>
        public bool LuuPhieuNhap(string maPNH, DateTime ngayNhap, string maNCC, string maNV, DataTable dtChiTiet, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(maPNH))
            {
                thongBao = "Mã Phiếu Nhập Hàng không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(maNCC))
            {
                thongBao = "Vui lòng chọn Nhà Cung Cấp!";
                return false;
            }

            if (dtChiTiet == null || dtChiTiet.Rows.Count == 0)
            {
                thongBao = "Vui lòng thêm ít nhất một mặt hàng vào phiếu nhập trước khi lưu!";
                return false;
            }

            try
            {
                bool ok = _repo.LuuPhieuNhapVaChiTiet(maPNH, ngayNhap, maNCC, maNV, dtChiTiet);
                if (ok)
                {
                    thongBao = $"Lưu phiếu nhập '{maPNH}' thành công! Đã quy đổi và cập nhật tồn kho.";
                    return true;
                }
                else
                {
                    thongBao = "Lưu phiếu nhập thất bại (Rollback transaction)!";
                    return false;
                }
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi lưu phiếu nhập: " + ex.Message;
                return false;
            }
        }

        public bool XoaPhieuNhap(string maPNH, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(maPNH))
            {
                thongBao = "Vui lòng chọn hóa đơn nhập cần xóa!";
                return false;
            }

            try
            {
                _repo.XoaPhieuNhap(maPNH.Trim());
                thongBao = "Xóa hóa đơn nhập thành công và đã hoàn lại số lượng tồn kho!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi xóa hóa đơn nhập: " + ex.Message;
                return false;
            }
        }

        // Tương thích ngược nếu code cũ gọi ThemHoaDonMoi
        public bool ThemHoaDonMoi(string maPNH, DateTime ngayNhap, int maNCC, int maNV, string maSPStr, string soLuongStr, string tongTienStr, out string thongBao)
        {
            if (!int.TryParse(maSPStr, out int maSP))
            { thongBao = "Vui lòng chọn mặt hàng!"; return false; }

            if (!int.TryParse(soLuongStr, out int soLuong) || soLuong <= 0)
            { thongBao = "Số lượng nhập phải lớn hơn 0!"; return false; }

            decimal tongTien = 0;
            if (!string.IsNullOrWhiteSpace(tongTienStr))
            {
                decimal.TryParse(tongTienStr.Replace(",", "").Replace(".", ""), out tongTien);
            }

            decimal donGiaNhap = soLuong > 0 ? (tongTien / soLuong) : 0;

            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP", typeof(string));
            dt.Columns.Add("MaDVT", typeof(string));
            dt.Columns.Add("SoLuongNhap", typeof(int));
            dt.Columns.Add("SoLuongQuyDoi", typeof(int));
            dt.Columns.Add("DonGiaNhap", typeof(decimal));
            dt.Columns.Add("NgaySanXuat", typeof(object));
            dt.Columns.Add("NgayHetHan", typeof(object));

            dt.Rows.Add(maSP.ToString(), "DV01", soLuong, 1, donGiaNhap, DBNull.Value, DBNull.Value);

            return LuuPhieuNhap(maPNH, ngayNhap, maNCC.ToString(), maNV.ToString(), dt, out thongBao);
        }

        #endregion
    }
}
