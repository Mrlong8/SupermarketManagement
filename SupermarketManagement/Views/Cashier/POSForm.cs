using SupermarketManagement.Controllers.Repositories;
using SupermarketManagement.Models.Repositories;
using SupermarketManagement.Utils;
using System;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SupermarketManagement
{
    public partial class POSForm : Form
    {
        // ===== HẰNG SỐ NGHIỆP VỤ =====
        private const decimal TienTichMotDiem = 10000m; // mua 10.000đ được 1 điểm
        private const decimal GiaTriMotDiem = 1000m;    // Giữ hằng số cũ để không ảnh hưởng code khác

        // ===== DỮ LIỆU =====
        private readonly NhanVienRepository nhanVienRepository = new NhanVienRepository();
        private readonly KhachHangRepository khachHangRepository = new KhachHangRepository();
        private readonly HoaDonRepository hoaDonRepository = new HoaDonRepository();
        private readonly SanPhamRepositoryV2 sanPhamRepository = new SanPhamRepositoryV2();

        private DataTable dtSanPham;     // danh sách sản phẩm + tồn kho đang hiển thị
        private decimal tongTienHang;    // tổng tiền hàng của hóa đơn hiện tại
        private int diemHienCo;          // điểm tích lũy của khách đang chọn

        public POSForm()
        {
            InitializeComponent();

            lblNhanVien.Text = "   Nhân viên: " + UserSession.HoTen;

            TaiDanhSachSanPham();
            TaoMaHoaDonMoi();
            CapNhatTongTien();
        }

        // =====================================================================
        // HÀM TIỆN ÍCH
        // =====================================================================

        private static void HienThongBao(string noiDung, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, icon);
        }

        private static bool XacNhan(string noiDung)
        {
            return MessageBox.Show(noiDung, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // =====================================================================
        // DANH SÁCH SẢN PHẨM
        // =====================================================================

        private void TaiDanhSachSanPham()
        {
            try
            {
                dtSanPham = sanPhamRepository.GetListSanPhamV2();
                dgvDSSP.DataSource = dtSanPham;
                LocSanPham();
            }
            catch (Exception ex)
            {
                HienThongBao("Lỗi tải sản phẩm: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            LocSanPham();
        }

        // Lọc danh sách theo mã hoặc tên (không phân biệt hoa thường)
        private void LocSanPham()
        {
            if (dtSanPham == null)
                return;

            string tuKhoa = txtTimKiemSP.Text.Trim();

            if (tuKhoa.Length == 0)
            {
                dtSanPham.DefaultView.RowFilter = "";
                return;
            }

            string mau = ThoatKyTuLike(tuKhoa);
            dtSanPham.DefaultView.RowFilter =
                "Convert(MaSP, 'System.String') LIKE '%" + mau + "%' OR TenSanPham LIKE '%" + mau + "%'";
        }

        // Các ký tự ' [ ] % * có ý nghĩa đặc biệt trong RowFilter nên phải thoát
        private static string ThoatKyTuLike(string chuoi)
        {
            chuoi = chuoi.Replace("'", "''");
            return Regex.Replace(chuoi, @"[\[\]%*]", m => "[" + m.Value + "]");
        }

        // Tìm dòng sản phẩm trong DataTable (không phụ thuộc bộ lọc đang áp dụng)
        private DataRow TimSanPham(string maSP)
        {
            foreach (DataRow dong in dtSanPham.Rows)
            {
                if (Convert.ToString(dong["MaSP"]) == maSP)
                    return dong;
            }
            return null;
        }

        // =====================================================================
        // CHI TIẾT HÓA ĐƠN
        // =====================================================================

        private DataGridViewRow TimDongHoaDon(string maSP)
        {
            foreach (DataGridViewRow dong in dgvChiTietHoaDon.Rows)
            {
                if (Convert.ToString(dong.Cells["colMaSP"].Value) == maSP)
                    return dong;
            }
            return null;
        }

        private static void DatSoLuongDong(DataGridViewRow dong, int soLuong)
        {
            decimal donGia = Convert.ToDecimal(dong.Cells["colDonGia"].Value);
            dong.Cells["colSoLuong"].Value = soLuong;
            dong.Cells["colThanhTien"].Value = donGia * soLuong;
        }

        // Nhấp đúp vào sản phẩm: thêm 1 đơn vị vào hóa đơn và trừ 1 tồn kho trên giao diện
        private void dgvDSSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataRow sp = ((DataRowView)dgvDSSP.Rows[e.RowIndex].DataBoundItem).Row;

            int tonKho = Convert.ToInt32(sp["SoLuong"]);
            if (tonKho <= 0)
            {
                HienThongBao("Sản phẩm đã hết hàng!", MessageBoxIcon.Warning);
                return;
            }

            string maSP = Convert.ToString(sp["MaSP"]);
            DataGridViewRow dongHoaDon = TimDongHoaDon(maSP);

            if (dongHoaDon == null)
            {
                decimal donGia = Convert.ToDecimal(sp["DonGiaBan"]);

                int indexMoi = dgvChiTietHoaDon.Rows.Add(
                    maSP, sp["TenSanPham"], 1, donGia, donGia);

                dongHoaDon = dgvChiTietHoaDon.Rows[indexMoi];
            }
            else
            {
                int soLuongCu = Convert.ToInt32(
                    dongHoaDon.Cells["colSoLuong"].Value);

                DatSoLuongDong(dongHoaDon, soLuongCu + 1);
            }

            // Chọn đúng dòng sản phẩm vừa thêm hoặc vừa cập nhật
            dgvChiTietHoaDon.ClearSelection();
            dongHoaDon.Selected = true;

            int cotMaSP = dgvChiTietHoaDon.Columns["colMaSP"].Index;
            dgvChiTietHoaDon.CurrentCell = dongHoaDon.Cells[cotMaSP];

            // Cập nhật ô số lượng mới ngay lập tức
            CapNhatSoLuongMoiTheoDongDangChon();

            // Cập nhật tồn kho và tổng tiền như code cũ
            sp["SoLuong"] = tonKho - 1;
            CapNhatTongTien();
        }

        // Chọn dòng trong chi tiết hóa đơn: cập nhật số lượng hiện tại
        private void dgvChiTietHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            CapNhatSoLuongMoiTheoDongDangChon();
        }
        private void CapNhatSoLuongMoiTheoDongDangChon()
        {
            if (dgvChiTietHoaDon.CurrentRow == null ||
                dgvChiTietHoaDon.CurrentRow.IsNewRow)
            {
                return;
            }

            object giaTri = dgvChiTietHoaDon.CurrentRow
                .Cells["colSoLuong"].Value;

            if (giaTri == null || giaTri == DBNull.Value)
                return;

            if (int.TryParse(Convert.ToString(giaTri), out int soLuong))
            {
                decimal soLuongHienThi = Math.Max(
                    nudSoLuong.Minimum,
                    Math.Min(nudSoLuong.Maximum, soLuong));

                if (nudSoLuong.Value != soLuongHienThi)
                    nudSoLuong.Value = soLuongHienThi;
            }
        }
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            DataGridViewRow dong = dgvChiTietHoaDon.CurrentRow;
            if (dong == null)
            {
                HienThongBao("Vui lòng chọn sản phẩm trong chi tiết hóa đơn.", MessageBoxIcon.Warning);
                return;
            }

            string maSP = Convert.ToString(dong.Cells["colMaSP"].Value);
            int soLuongCu = Convert.ToInt32(dong.Cells["colSoLuong"].Value);
            int soLuongMoi = (int)nudSoLuong.Value;

            if (soLuongMoi == soLuongCu)
            {
                HienThongBao("Số lượng không thay đổi.");
                return;
            }

            DataRow sp = TimSanPham(maSP);
            if (sp == null)
            {
                HienThongBao("Không tìm thấy sản phẩm trong danh sách tồn kho.", MessageBoxIcon.Warning);
                return;
            }

            // Tồn kho khả dụng = tồn kho hiện tại + số lượng đang giữ trong hóa đơn
            int tonKhoKhaDung = Convert.ToInt32(sp["SoLuong"]) + soLuongCu;
            if (soLuongMoi > tonKhoKhaDung)
            {
                HienThongBao("Số lượng tồn kho không đủ! Tối đa: " + tonKhoKhaDung, MessageBoxIcon.Warning);
                return;
            }

            DatSoLuongDong(dong, soLuongMoi);
            sp["SoLuong"] = tonKhoKhaDung - soLuongMoi;
            CapNhatTongTien();
        }
        
        private void btnXoaSPKhoiHD_Click(object sender, EventArgs e)
        {
            DataGridViewRow dong = dgvChiTietHoaDon.CurrentRow;
            if (dong == null)
            {
                HienThongBao("Vui lòng chọn sản phẩm cần xóa.", MessageBoxIcon.Warning);
                return;
            }

            if (!XacNhan("Bạn có chắc chắn muốn xóa sản phẩm đã chọn?"))
                return;

            // Hoàn lại tồn kho trên giao diện
            string maSP = Convert.ToString(dong.Cells["colMaSP"].Value);
            int soLuong = Convert.ToInt32(dong.Cells["colSoLuong"].Value);

            DataRow sp = TimSanPham(maSP);
            if (sp != null)
                sp["SoLuong"] = Convert.ToInt32(sp["SoLuong"]) + soLuong;

            dgvChiTietHoaDon.Rows.Remove(dong);
            CapNhatTongTien();
        }

        // =====================================================================
        // TÍNH TIỀN
        // =====================================================================

        private void CapNhatTongTien()
        {
            tongTienHang = 0;

            foreach (DataGridViewRow dong in dgvChiTietHoaDon.Rows)
                tongTienHang += Convert.ToDecimal(dong.Cells["colThanhTien"].Value);

            txtTongTien.Text = tongTienHang.ToString("N0");
            TinhTienThanhToan();
        }

        // Số điểm tối đa được dùng: không vượt quá (điểm hiện có + điểm mới của hóa đơn)
        // và không làm tiền giảm giá lớn hơn tổng tiền hàng
        private int DiemToiDa()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                return 0;

            int diemMoi = (int)(tongTienHang / TienTichMotDiem);
            int diemTheoTien = (int)(tongTienHang / GiaTriMotDiem);

            return Math.Min(diemHienCo + diemMoi, diemTheoTien);
        }

        // Lấy phần trăm giảm giá từ 4 RadioButton trong grpGiamGia.
        private int LayPhanTramGiam()
        {
            if (rdoGiam5.Checked) return 5;
            if (rdoGiam10.Checked) return 10;
            if (rdoGiam20.Checked) return 20;
            if (rdoGiam30.Checked) return 30;
            return 0;
        }

        // 10 điểm đổi được 1% giảm giá.
        private int LayDiemCanDung()
        {
            return LayPhanTramGiam() * 10;
        }

        private void rdoGiamGia_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked)
                return;

            int phanTram = LayPhanTramGiam();
            int diemCanDung = phanTram * 10;

            if (phanTram > 0 && string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                HienThongBao("Vui lòng chọn khách hàng trước khi sử dụng điểm.", MessageBoxIcon.Warning);
                rb.Checked = false;
                TinhTienThanhToan();
                return;
            }

            if (diemHienCo < diemCanDung)
            {
                HienThongBao(
                    $"Cần {diemCanDung} điểm để giảm {phanTram}%.\n" +
                    $"Điểm hiện có: {diemHienCo} điểm.\n" +
                    $"Còn thiếu: {diemCanDung - diemHienCo} điểm.",
                    MessageBoxIcon.Warning);
                rb.Checked = false;
                TinhTienThanhToan();
                return;
            }

            TinhTienThanhToan();
        }

        private void TinhTienThanhToan()
        {
            int phanTram = LayPhanTramGiam();
            int diemCanDung = phanTram * 10;
            bool hopLe = phanTram == 0 ||
                (!string.IsNullOrWhiteSpace(txtMaKH.Text) && diemHienCo >= diemCanDung);

            decimal giamGia = (hopLe && phanTram > 0)
                ? tongTienHang * phanTram / 100m
                : 0m;

            txtTienGiamGia.Text = giamGia.ToString("N0");
            txtTienPhaiTra.Text = (tongTienHang - giamGia).ToString("N0");
        }

        // =====================================================================
        // HÓA ĐƠN
        // =====================================================================

        private void TaoMaHoaDonMoi()
        {
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        // Đưa form về trạng thái hóa đơn trống, tải lại tồn kho từ database
        private void BatDauHoaDonMoi()
        {
            dgvChiTietHoaDon.Rows.Clear();
            XoaThongTinKhachHang();
            // Bỏ lựa chọn giảm giá khi bắt đầu hóa đơn mới.
            rdoGiam5.Checked = false;
            rdoGiam10.Checked = false;
            rdoGiam20.Checked = false;
            rdoGiam30.Checked = false;
            txtTimKiemSP.Clear();

            TaiDanhSachSanPham();
            TaoMaHoaDonMoi();
            CapNhatTongTien();
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.Rows.Count > 0 &&
                !XacNhan("Hóa đơn hiện tại chưa lưu sẽ bị hủy. Bạn có muốn bắt đầu hóa đơn mới?"))
                return;

            BatDauHoaDonMoi();
        }


        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            // Mở form xem lịch sử hóa đơn
            using (var form = new SupermarketManagement.Views.Admin.LichSuBan.IndexLichSuBan())
            {
                form.ShowDialog(this);
            }
        }


        // Chuyển bảng chi tiết hóa đơn thành DataTable để repository lưu
        private DataTable LayChiTietHoaDon()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP", typeof(string));
            dt.Columns.Add("SoLuongBan", typeof(int));
            dt.Columns.Add("DonGiaBan", typeof(decimal));

            foreach (DataGridViewRow dong in dgvChiTietHoaDon.Rows)
            {
                dt.Rows.Add(
                    Convert.ToString(dong.Cells["colMaSP"].Value),
                    Convert.ToInt32(dong.Cells["colSoLuong"].Value),
                    Convert.ToDecimal(dong.Cells["colDonGia"].Value));
            }

            return dt;
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.Rows.Count == 0)
            {
                HienThongBao("Hóa đơn chưa có sản phẩm.", MessageBoxIcon.Warning);
                return;
            }

            string tenKH = string.IsNullOrWhiteSpace(txtTenKH.Text) ? "Khách lẻ" : txtTenKH.Text.Trim();
            // Lấy thông tin hóa đơn
            string maHD = txtMaHD.Text.Trim();
            string maKH = string.IsNullOrWhiteSpace(txtMaKH.Text)
                ? null
                : txtMaKH.Text.Trim();
            string maNV = Convert.ToString(UserSession.MaNV);
            string tenNV = Convert.ToString(UserSession.HoTen);
            int diemSuDung = LayDiemCanDung();

            // Lưu hóa đơn vào database
            hoaDonRepository.LuuHoaDon(
                maHD,
                tongTienHang,
                DateTime.Now,
                maKH,
                maNV,
                LayChiTietHoaDon(),
                diemSuDung);


            using (var form = new SupermarketManagement.Views.Cashier.InvoiceForm())
            {
                form.HienThiHoaDon(
                    txtMaHD.Text,
                    txtMaKH.Text,
                    tenKH,
                    tenNV,
                    DateTime.Now,
                    dgvChiTietHoaDon,
                    txtTongTien.Text,
                    txtTienGiamGia.Text,
                    LayDiemCanDung().ToString(),
                    txtTienPhaiTra.Text);

                form.ShowDialog(this);
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserSession.DangXuat(this);
            }
        }

        // =====================================================================
        // KHÁCH HÀNG
        // =====================================================================

        private void XoaThongTinKhachHang(bool giuSoDienThoai = false)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtEmail.Clear();
            txtDiemTichLuy.Clear();
            if (!giuSoDienThoai)
                txtSDT.Clear();

            diemHienCo = 0;
            TinhTienThanhToan();
        }

        private static bool LaEmailHopLe(string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool KiemTraThongTinKhachHang(string maKH, string tenKH, string sdt, string email)
        {
            if (maKH.Length == 0 || tenKH.Length == 0)
            {
                HienThongBao("Vui lòng tạo mã khách hàng và nhập họ tên.", MessageBoxIcon.Warning);
                return false;
            }

            if (sdt.Length == 0)
            {
                HienThongBao("Vui lòng nhập số điện thoại để tích điểm.", MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (!Regex.IsMatch(sdt, @"^0[0-9]{9}$") || sdt.Distinct().Count() == 1)
            {
                HienThongBao("Số điện thoại phải bắt đầu bằng 0, đủ 10 chữ số và không được gồm 10 số giống hệt nhau.",
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // Email không bắt buộc, chỉ kiểm tra định dạng nếu có nhập
            if (email.Length > 0 && !LaEmailHopLe(email))
            {
                HienThongBao("Email không đúng định dạng. Ví dụ: abc@gmail.com", MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void btnTaoMaKH_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaKH.Text = khachHangRepository.RenderMaKhachHang();
            }
            catch (Exception ex)
            {
                HienThongBao(
                    "Không tạo được mã khách hàng:\n" + ex.Message,
                    MessageBoxIcon.Error);
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (!KiemTraThongTinKhachHang(maKH, tenKH, sdt, email))
                return;

            try
            {
                if (khachHangRepository.CheckExists(maKH))
                {
                    HienThongBao("Mã khách hàng đã tồn tại.",
                        MessageBoxIcon.Warning);
                    return;
                }

                if (khachHangRepository.CheckPhoneExists(sdt))
                {
                    HienThongBao(
                        "Số điện thoại này đã được đăng ký. Vui lòng tìm khách hàng cũ để tích điểm.",
                        MessageBoxIcon.Warning);
                    return;
                }

                if (email.Length > 0 &&
                    khachHangRepository.CheckEmailExists(email))
                {
                    HienThongBao("Email đã được đăng ký.",
                        MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                khachHangRepository.InsertFromPOS(
                    maKH, tenKH, sdt, email);

                diemHienCo = 0;
                txtDiemTichLuy.Text = "0";
                TinhTienThanhToan();

                HienThongBao("Thêm khách hàng thành công.");
            }
            catch (Exception ex)
            {
                HienThongBao(
                    "Lỗi khi thêm khách hàng:\n" + ex.Message,
                    MessageBoxIcon.Error);
            }
        }
        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();

            if (sdt.Length == 0)
            {
                HienThongBao("Vui lòng nhập số điện thoại.",
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            try
            {
                DataTable dt = khachHangRepository.GetByPhone(sdt);

                if (dt.Rows.Count == 0)
                {
                    XoaThongTinKhachHang(giuSoDienThoai: true);
                    HienThongBao(
                        "Không tìm thấy khách hàng. Bạn có thể nhập thông tin để thêm mới.");
                    return;
                }

                if (dt.Rows.Count > 1)
                {
                    HienThongBao(
                        "Số điện thoại bị trùng trong database. Vui lòng kiểm tra dữ liệu.",
                        MessageBoxIcon.Warning);
                    return;
                }

                DataRow dong = dt.Rows[0];

                txtMaKH.Text = Convert.ToString(dong["MaKH"]);
                txtTenKH.Text = Convert.ToString(dong["HoTen"]);
                txtEmail.Text = dong["Email"] == DBNull.Value
                    ? ""
                    : Convert.ToString(dong["Email"]);

                diemHienCo = dong["DiemTichLuy"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(dong["DiemTichLuy"]);

                txtDiemTichLuy.Text = diemHienCo.ToString();

                TinhTienThanhToan();
            }
            catch (Exception ex)
            {
                HienThongBao(
                    "Lỗi tìm kiếm khách hàng:\n" + ex.Message,
                    MessageBoxIcon.Error);
            }
        }



        private void rdoGiam5_CheckedChanged(object sender, EventArgs e)
        {
            rdoGiamGia_CheckedChanged(sender, e);
        }

        private void rdoGiam10_CheckedChanged(object sender, EventArgs e)
        {
            rdoGiamGia_CheckedChanged(sender, e);
        }

        private void rdoGiam20_CheckedChanged(object sender, EventArgs e)
        {
            rdoGiamGia_CheckedChanged(sender, e);
        }

        private void rdoGiam30_CheckedChanged(object sender, EventArgs e)
        {
            rdoGiamGia_CheckedChanged(sender, e);
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiemKH.PerformClick();
            }
        }

        private void nudSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSuaSP.PerformClick();
            }
        }
    }
}