using SupermarketManagement.Controllers;
using SupermarketManagement.Models.Entities;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.QuanLyKhoHang
{
    public partial class IndexQuanLyKhoHang : Form
    {
        private KhoHangController _controller = new KhoHangController();

        public IndexQuanLyKhoHang()
        {
            InitializeComponent();
        }

        // Sự kiện khi mở Form lên
        private void IndexQuanLyKhoHang_Load(object sender, EventArgs e)
        {
            if (cboTrangThaiHD.Items.Count > 0)
            {
                cboTrangThaiHD.SelectedIndex = 0;
            }

            LoadComboBoxData();
            LoadDanhSachDanhMuc();
            LoadDanhSachHangHoa();
            LoadDanhSachHoaDonNhap();
        }

        // Nạp dữ liệu vào các ComboBox
        private void LoadComboBoxData()
        {
            try
            {
                // 1. ComboBox Nhà Cung Cấp
                DataTable dtNCC = _controller.LoadNhaCungCap();
                cboNhaCungCap.DataSource = dtNCC;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";

                // 2. ComboBox Nhân Viên (Người Nhập)
                DataTable dtNV = _controller.LoadNhanVien();
                cboNguoiNhap.DataSource = dtNV;
                cboNguoiNhap.DisplayMember = "HoTen";
                cboNguoiNhap.ValueMember = "MaNV";

                // Nếu đã đăng nhập, tự động chọn nhân viên đang đăng nhập
                if (PhienDangNhap.MaNV > 0)
                {
                    cboNguoiNhap.SelectedValue = PhienDangNhap.MaNV;
                }

                // 3. ComboBox Danh Mục (ở phần Hàng Hóa)
                CapNhatComboBoxDanhMuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu danh mục chọn: " + ex.Message);
            }
        }

        private void CapNhatComboBoxDanhMuc()
        {
            DataTable dtDM = _controller.LoadDanhMuc();
            cboDanhMucHH.DataSource = dtDM;
            cboDanhMucHH.DisplayMember = "TenDanhMuc";
            cboDanhMucHH.ValueMember = "MaDM";
        }

        // =========================================================================
        // KHU VỰC 1: XỬ LÝ QUẢN LÝ HÓA ĐƠN NHẬP (PHIẾU NHẬP HÀNG)
        // =========================================================================

        private void LoadDanhSachHoaDonNhap()
        {
            try
            {
                dgvHoaDonNhap.DataSource = _controller.LoadPhieuNhapHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn nhập: " + ex.Message);
            }
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDonNhap.Rows[e.RowIndex];
                txtMaHoaDon.Text = row.Cells["MaPNH"].Value?.ToString();

                if (row.Cells["NgayNhap"].Value != null && row.Cells["NgayNhap"].Value != DBNull.Value)
                {
                    dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                }

                if (row.Cells["MaNCC"].Value != null && row.Cells["MaNCC"].Value != DBNull.Value)
                {
                    cboNhaCungCap.SelectedValue = row.Cells["MaNCC"].Value;
                }

                if (row.Cells["MaNV"].Value != null && row.Cells["MaNV"].Value != DBNull.Value)
                {
                    cboNguoiNhap.SelectedValue = row.Cells["MaNV"].Value;
                }

                txtTongTienHD.Text = row.Cells["TongTien"].Value?.ToString();
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            int maNV = cboNguoiNhap.SelectedValue != null ? Convert.ToInt32(cboNguoiNhap.SelectedValue) : 1;
            int maNCC = cboNhaCungCap.SelectedValue != null ? Convert.ToInt32(cboNhaCungCap.SelectedValue) : 1;

            string thongBao;
            if (_controller.ThemPhieuNhap(txtMaHoaDon.Text, dtpNgayNhap.Value, maNV, maNCC, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHoaDonNhap();
                LamMoiFormHoaDon();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            int maNV = cboNguoiNhap.SelectedValue != null ? Convert.ToInt32(cboNguoiNhap.SelectedValue) : 1;
            int maNCC = cboNhaCungCap.SelectedValue != null ? Convert.ToInt32(cboNhaCungCap.SelectedValue) : 1;

            string thongBao;
            if (_controller.SuaPhieuNhap(txtMaHoaDon.Text, dtpNgayNhap.Value, maNV, maNCC, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHoaDonNhap();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn nhập để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn nhập " + txtMaHoaDon.Text + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string thongBao;
                if (_controller.XoaPhieuNhap(txtMaHoaDon.Text, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDonNhap();
                    LamMoiFormHoaDon();
                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            // Nút Lưu hỗ trợ lưu nhanh (nếu mã đã tồn tại trong bảng thì cập nhật, chưa có thì thêm mới)
            bool daTonTai = false;
            foreach (DataGridViewRow row in dgvHoaDonNhap.Rows)
            {
                if (row.Cells["MaPNH"].Value != null &&
                    row.Cells["MaPNH"].Value.ToString().Equals(txtMaHoaDon.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    daTonTai = true;
                    break;
                }
            }

            if (daTonTai)
                btnSuaHD_Click(sender, e);
            else
                btnThemHD_Click(sender, e);
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            LamMoiFormHoaDon();
        }

        private void btnLamMoiHD_Click(object sender, EventArgs e)
        {
            LamMoiFormHoaDon();
            LoadDanhSachHoaDonNhap();
        }

        private void LamMoiFormHoaDon()
        {
            txtMaHoaDon.Clear();
            txtTongTienHD.Text = "0";
            dtpNgayNhap.Value = DateTime.Now;
            txtMaHoaDon.Focus();
        }

        // =========================================================================
        // KHU VỰC 2: XỬ LÝ QUẢN LÝ HÀNG HÓA (SẢN PHẨM)
        // =========================================================================

        private void LoadDanhSachHangHoa()
        {
            try
            {
                dgvHangHoa.DataSource = _controller.LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hàng hóa: " + ex.Message);
            }
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];
                txtMaHangHoa.Text = row.Cells["MaSP"].Value?.ToString();
                txtTenHangHoa.Text = row.Cells["TenSanPham"].Value?.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
                txtTrongLuong.Text = row.Cells["TrongLuong"].Value?.ToString();
                txtDonGiaNhap.Text = row.Cells["DonGiaNhap"].Value?.ToString();
                txtDonGiaBan.Text = row.Cells["DonGiaBan"].Value?.ToString();
                txtMoTaHH.Text = row.Cells["MoTa"].Value?.ToString();

                if (row.Cells["MaDM"].Value != null && row.Cells["MaDM"].Value != DBNull.Value)
                {
                    cboDanhMucHH.SelectedValue = row.Cells["MaDM"].Value;
                }
            }
        }

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            int maDM = cboDanhMucHH.SelectedValue != null ? Convert.ToInt32(cboDanhMucHH.SelectedValue) : 1;
            int maNV = PhienDangNhap.MaNV > 0 ? PhienDangNhap.MaNV : 1;

            string thongBao;
            if (_controller.ThemSanPham(txtTenHangHoa.Text, txtSoLuong.Text, txtTrongLuong.Text, txtDonGiaNhap.Text, txtDonGiaBan.Text, txtMoTaHH.Text, maDM, maNV, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHangHoa();
                LamMoiFormHangHoa();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaHH_Click(object sender, EventArgs e)
        {
            int maDM = cboDanhMucHH.SelectedValue != null ? Convert.ToInt32(cboDanhMucHH.SelectedValue) : 1;

            string thongBao;
            if (_controller.SuaSanPham(txtMaHangHoa.Text, txtTenHangHoa.Text, txtSoLuong.Text, txtTrongLuong.Text, txtDonGiaNhap.Text, txtDonGiaBan.Text, txtMoTaHH.Text, maDM, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHangHoa();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaHH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHangHoa.Text))
            {
                MessageBox.Show("Vui lòng chọn một hàng hóa từ bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string thongBao;
                if (_controller.XoaSanPham(txtMaHangHoa.Text, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHangHoa();
                    LamMoiFormHangHoa();
                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiemHH_TextChanged(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = _controller.TimKiemSanPham(txtTimKiemHH.Text);
        }

        private void LamMoiFormHangHoa()
        {
            txtMaHangHoa.Clear();
            txtTenHangHoa.Clear();
            txtSoLuong.Clear();
            txtTrongLuong.Clear();
            txtDonGiaNhap.Clear();
            txtDonGiaBan.Clear();
            txtMoTaHH.Clear();
        }

        // =========================================================================
        // KHU VỰC 3: XỬ LÝ QUẢN LÝ DANH MỤC
        // =========================================================================

        private void LoadDanhSachDanhMuc()
        {
            try
            {
                dgvDanhMuc.DataSource = _controller.LoadDanhMuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
                txtMaDanhMuc.Text = row.Cells["MaDM"].Value?.ToString();
                txtTenDanhMuc.Text = row.Cells["TenDanhMuc"].Value?.ToString();
            }
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            string thongBao;
            if (_controller.ThemDanhMuc(txtTenDanhMuc.Text, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDanhMuc();
                CapNhatComboBoxDanhMuc();
                LamMoiFormDanhMuc();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            string thongBao;
            if (_controller.SuaDanhMuc(txtMaDanhMuc.Text, txtTenDanhMuc.Text, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDanhMuc();
                CapNhatComboBoxDanhMuc();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn một danh mục để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string thongBao;
                if (_controller.XoaDanhMuc(txtMaDanhMuc.Text, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDanhMuc();
                    CapNhatComboBoxDanhMuc();
                    LamMoiFormDanhMuc();
                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LamMoiFormDanhMuc()
        {
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
            txtMoTaDM.Clear();
        }
    }
}