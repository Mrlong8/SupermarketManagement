using SupermarketManagement.Models.Repositories;
using System;
using System.Data;

namespace SupermarketManagement.Controllers
{
    public class KhoHangController
    {
        private KhoHangRepository _repo = new KhoHangRepository();

        //phần danh mục

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

        // phần hàng hóa sản phẩm

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
                thongBao = "Trọng lượng không hợp lệ!";
                return false;
            }

            decimal giaNhap = 0;
            if (!decimal.TryParse(giaNhapStr, out giaNhap) || giaNhap < 0)
            {
                thongBao = "Đơn giá nhập không hợp lệ!";
                return false;
            }

            decimal giaBan = 0;
            if (!decimal.TryParse(giaBanStr, out giaBan) || giaBan < 0)
            {
                thongBao = "Đơn giá bán không hợp lệ!";
                return false;
            }

            try
            {
                if (maNV <= 0) maNV = 1;
                _repo.ThemSanPham(maSP, tenSP.Trim(), soLuong, trongLuong, giaNhap, giaBan, moTa.Trim(), maDM, maNV);
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
            decimal.TryParse(giaNhapStr, out giaNhap);

            decimal giaBan = 0;
            decimal.TryParse(giaBanStr, out giaBan);

            try
            {
                _repo.SuaSanPham(maSP, tenSP.Trim(), soLuong, trongLuong, giaNhap, giaBan, moTa.Trim(), maDM);
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

        // Phần hóa đơn nhập hàng

        public DataTable LoadPhieuNhapHang()
        {
            return _repo.GetPhieuNhapHang();
        }

        public DataTable LoadNhaCungCap()
        {
            return _repo.GetNhaCungCap();
        }

        public DataTable LoadNhanVien()
        {
            return _repo.GetNhanVien();
        }

        public bool ThemPhieuNhap(string maPNH, DateTime ngayNhap, int maNV, int maNCC, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(maPNH))
            {
                thongBao = "Vui lòng nhập Mã Hóa Đơn Nhập (VD: PNH006)!";
                return false;
            }

            try
            {
                _repo.ThemPhieuNhap(maPNH.Trim(), ngayNhap, maNV, maNCC);
                thongBao = "Thêm hóa đơn nhập thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi thêm hóa đơn nhập (Có thể trùng Mã PNH): " + ex.Message;
                return false;
            }
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
                thongBao = "Xóa hóa đơn nhập thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi xóa hóa đơn nhập: " + ex.Message;
                return false;
            }
        }

        public string TaoMaPhieuNhapMoi()
        {
            return _repo.GetMaPhieuNhapMoi();
        }

        public string TaoMaSanPhamMoi()
        {
            return _repo.GetMaSanPhamMoi();
        }

        public string TaoMaDanhMucMoi()
        {
            return _repo.GetMaDanhMucMoi();
        }

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

            try
            {
                bool ketQua = _repo.ThemHoaDonVaCapNhatKho(maPNH, ngayNhap, maNCC, maNV, maSP, soLuong, donGiaNhap, tongTien);
                if (ketQua)
                {
                    thongBao = "Nhập hàng và cập nhật kho thành công!";
                    return true;
                }
                else
                {
                    thongBao = "Lỗi hệ thống khi lưu dữ liệu (Transaction Rollback)!";
                    return false;
                }
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi: " + ex.Message;
                return false;
            }
        }
    }
}