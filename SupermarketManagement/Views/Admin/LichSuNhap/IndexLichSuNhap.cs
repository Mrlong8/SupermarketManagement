using SupermarketManagement.Models.Repositories;
using SupermarketManagement.Views.Admin.HoaDon;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.LichSuNhap
{
    public partial class IndexLichSuNhap : Form
    {
        private LichSuNhapRepository _repo = new LichSuNhapRepository();

        public IndexLichSuNhap()
        {
            InitializeComponent();
        }

        private void IndexLichSuNhap_Load(object sender, EventArgs e)
        {
            GetDataPH();
            ConfigComboBoxAutoComplete();
            LoadComboBoxData();
        }

        public void GetDataPH()
        {
            dgvListPhieuNhap.DataSource = _repo.GetDanhSachPNH();
        }

        private void dgvListPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListPhieuNhap.Rows[e.RowIndex];
                // Lấy mã phiếu nhập theo tên cột hoặc chỉ số 0
                string mapn = row.Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(mapn))
                {
                    dgvChiTietPhieuNhap.DataSource = _repo.GetChiTietPNH(mapn);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu nhập cần tìm!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
                return;
            }

            DataTable dtResult = _repo.TimKiemPhieuNhapByMa(keyword);
            dgvListPhieuNhap.DataSource = dtResult;

            if (dtResult.Rows.Count == 0 && dgvChiTietPhieuNhap.DataSource != null)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập nào khớp với mã đã nhập!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            // Hủy đăng ký sự kiện tạm thời
            cbNhanVien.SelectedIndexChanged -= cbNhanVien_SelectedIndexChanged;
            cbNhaCungCap.SelectedIndexChanged -= cbKhachHang_SelectedIndexChanged;
            dtpNgayNhap.ValueChanged -= dtpNgayMua_ValueChanged;

            cbNhanVien.SelectedIndex = -1;
            cbNhaCungCap.SelectedIndex = -1;
            dtpNgayNhap.Value = DateTime.Now;

            // Đăng ký lại sự kiện
            cbNhanVien.SelectedIndexChanged += cbNhanVien_SelectedIndexChanged;
            cbNhaCungCap.SelectedIndexChanged += cbKhachHang_SelectedIndexChanged;
            dtpNgayNhap.ValueChanged += dtpNgayMua_ValueChanged;

            GetDataPH();
            if (dgvChiTietPhieuNhap.DataSource != null)
            {
                ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
            }

            txtTimKiem.Focus();
        }

        private void ConfigComboBoxAutoComplete()
        {
            cbNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbNhaCungCap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbNhaCungCap.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadComboBoxData()
        {
            // 1. Load Nhân Viên
            DataTable dtNV = _repo.GetNhanVienList();
            cbNhanVien.DataSource = dtNV;
            cbNhanVien.DisplayMember = "HoTen";
            cbNhanVien.ValueMember = "MaNV";
            cbNhanVien.SelectedIndex = -1;

            // 2. Load Nhà Cung Cấp
            DataTable dtNCC = _repo.GetNhaCungCapList();
            cbNhaCungCap.DataSource = dtNCC;
            cbNhaCungCap.DisplayMember = "TenNCC";
            cbNhaCungCap.ValueMember = "MaNCC";
            cbNhaCungCap.SelectedIndex = -1;
        }

        // 1. Sự kiện Lọc riêng theo Nhân Viên
        private void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.Focused && cbNhanVien.SelectedValue != null)
            {
                string maNV = cbNhanVien.SelectedValue.ToString();
                DataTable dtResult = _repo.LocTheoNhanVien(maNV);
                dgvListPhieuNhap.DataSource = dtResult;

                if (dtResult.Rows.Count == 0 && dgvChiTietPhieuNhap.DataSource != null)
                {
                    ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
                }
            }
        }

        // 2. Sự kiện Lọc riêng theo Nhà Cung Cấp
        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhaCungCap.Focused && cbNhaCungCap.SelectedValue != null)
            {
                string maNCC = cbNhaCungCap.SelectedValue.ToString();
                DataTable dtResult = _repo.LocTheoNhaCungCap(maNCC);
                dgvListPhieuNhap.DataSource = dtResult;

                if (dtResult.Rows.Count == 0 && dgvChiTietPhieuNhap.DataSource != null)
                {
                    ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
                }
            }
        }

        // 3. Sự kiện Lọc riêng theo Ngày Nhập
        private void dtpNgayMua_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayNhap = dtpNgayNhap.Value.Date;
            DataTable dtResult = _repo.LocTheoNgayNhap(ngayNhap);
            dgvListPhieuNhap.DataSource = dtResult;

            if (dtResult.Rows.Count == 0 && dgvChiTietPhieuNhap.DataSource != null)
            {
                ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
            }
        }

        private void btnXemTruocHD_Click(object sender, EventArgs e)
        {
            if (dgvListPhieuNhap.SelectedRows.Count > 0)
            {
                string mapn = dgvListPhieuNhap.SelectedRows[0].Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(mapn))
                {
                    // Mở Form Xem & In Phiếu Nhập Hàng
                    SupermarketManagement.Views.Admin.PhieuNhapHang.IndexPhieuNhapHang frmPrint =
                        new SupermarketManagement.Views.Admin.PhieuNhapHang.IndexPhieuNhapHang(mapn);
                    frmPrint.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu nhập trong danh sách để xem chi tiết!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}