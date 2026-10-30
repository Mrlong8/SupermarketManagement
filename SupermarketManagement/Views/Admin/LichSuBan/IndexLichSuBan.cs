using SupermarketManagement.Models.Repositories;
using SupermarketManagement.Views.Admin.HoaDon;
//using SupermarketManagement.Views.Admin.HoaDon;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.LichSuBan
{
    public partial class IndexLichSuBan : Form
    {
        private LichSuMuaRepository _repo = new LichSuMuaRepository();

        public IndexLichSuBan()
        {
            InitializeComponent();
        }

        private void IndexLichSuBan_Load(object sender, EventArgs e)
        {
            GetDataHD();
            ConfigComboBoxAutoComplete();
            LoadComboBoxData();
        }

        public void GetDataHD()
        {
            dgvListHoaDonMua.DataSource = _repo.GetDanhSachHD();
        }

        private void dgvListHoaDonMua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListHoaDonMua.Rows[e.RowIndex];
                string mahd = row.Cells["MaHD"].Value?.ToString();
                dgvChiTiet.DataSource = _repo.GetChiTietHD(mahd);
            }
        }

    

        private void btnReset_Click(object sender, EventArgs e)
        {
    

            // Hủy đăng ký sự kiện tạm thời để tránh tự kích hoạt khi gán SelectedIndex = -1
            cbNhanVien.SelectedIndexChanged -= cbNhanVien_SelectedIndexChanged;
            cbKhachHang.SelectedIndexChanged -= cbKhachHang_SelectedIndexChanged;
            dtpNgayMua.ValueChanged -= dtpNgayMua_ValueChanged;

            cbNhanVien.SelectedIndex = -1;
            cbKhachHang.SelectedIndex = -1;
            dtpNgayMua.Value = DateTime.Now;

            // Đăng ký lại sự kiện
            cbNhanVien.SelectedIndexChanged += cbNhanVien_SelectedIndexChanged;
            cbKhachHang.SelectedIndexChanged += cbKhachHang_SelectedIndexChanged;
            dtpNgayMua.ValueChanged += dtpNgayMua_ValueChanged;

            GetDataHD();
            if (dgvChiTiet.DataSource != null)
            {
                ((DataTable)dgvChiTiet.DataSource).Clear();
            }

        }

        private void ConfigComboBoxAutoComplete()
        {
            cbNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadComboBoxData()
        {
            DataTable dtNV = _repo.GetNhanVienList();
            cbNhanVien.DataSource = dtNV;
            cbNhanVien.DisplayMember = "HoTen";
            cbNhanVien.ValueMember = "MaNV";
            cbNhanVien.SelectedIndex = -1;

            DataTable dtKH = _repo.GetKhachHangList();
            cbKhachHang.DataSource = dtKH;
            cbKhachHang.DisplayMember = "HoTen";
            cbKhachHang.ValueMember = "MaKH";
            cbKhachHang.SelectedIndex = -1;
        }

        // 1. Sự kiện Lọc riêng theo Nhân Viên
        private void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.Focused && cbNhanVien.SelectedValue != null)
            {
                string maNV = cbNhanVien.SelectedValue.ToString();
                DataTable dtResult = _repo.LocTheoNhanVien(maNV);
                dgvListHoaDonMua.DataSource = dtResult;

                if (dtResult.Rows.Count == 0 && dgvChiTiet.DataSource != null)
                {
                    ((DataTable)dgvChiTiet.DataSource).Clear();
                }
            }
        }

        // 2. Sự kiện Lọc riêng theo Khách Hàng
        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhachHang.Focused && cbKhachHang.SelectedValue != null)
            {
                string maKH = cbKhachHang.SelectedValue.ToString();
                DataTable dtResult = _repo.LocTheoKhachHang(maKH);
                dgvListHoaDonMua.DataSource = dtResult;

                if (dtResult.Rows.Count == 0 && dgvChiTiet.DataSource != null)
                {
                    ((DataTable)dgvChiTiet.DataSource).Clear();
                }
            }
        }

        // 3. Sự kiện Lọc riêng theo Ngày Bán
        private void dtpNgayMua_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayBan = dtpNgayMua.Value.Date;
            DataTable dtResult = _repo.LocTheoNgayBan(ngayBan);
            dgvListHoaDonMua.DataSource = dtResult;

            if (dtResult.Rows.Count == 0 && dgvChiTiet.DataSource != null)
            {
                ((DataTable)dgvChiTiet.DataSource).Clear();
            }
        }

        private void btnXemTruocHD_Click(object sender, EventArgs e)
        {
            if (dgvListHoaDonMua.SelectedRows.Count > 0)
            {
                string maHD = dgvListHoaDonMua.SelectedRows[0].Cells["MaHD"].Value?.ToString();

                if (!string.IsNullOrEmpty(maHD))
                {
                    // Mở Form Xem & Xuất Hóa Đơn dạng Popup Modal
                    FrmHoaDonPrint frmPrint = new FrmHoaDonPrint(maHD);
                    frmPrint.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn trong danh sách để xem chi tiết!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra người dùng đã chọn dòng hóa đơn nào chưa
            DataGridViewRow selectedRow = null;

            if (dgvListHoaDonMua.SelectedRows.Count > 0)
            {
                selectedRow = dgvListHoaDonMua.SelectedRows[0];
            }
            else if (dgvListHoaDonMua.CurrentRow != null)
            {
                selectedRow = dgvListHoaDonMua.CurrentRow;
            }

            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn trong danh sách để xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHD = selectedRow.Cells["MaHD"].Value?.ToString();

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Không tìm thấy mã hóa đơn cần xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hộp thoại xác nhận trước khi xóa
            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hóa đơn '{maHD}' không?\n\nLưu ý: Số lượng sản phẩm trong hóa đơn này sẽ được hoàn trả lại vào kho hàng!",
                "Xác nhận xóa hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    bool result = _repo.XoaHoaDon(maHD);

                    if (result)
                    {
                        MessageBox.Show("Xóa hóa đơn thành công và đã hoàn lại số lượng sản phẩm vào kho!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại danh sách hóa đơn
                        GetDataHD();

                        // Xóa sạch bảng chi tiết hóa đơn bên dưới
                        if (dgvChiTiet.DataSource != null)
                        {
                            ((DataTable)dgvChiTiet.DataSource).Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}