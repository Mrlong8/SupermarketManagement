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

        // Khởi tạo dữ liệu, đăng ký sự kiện tìm kiếm tự động và nạp danh sách ban đầu
        private void IndexLichSuNhap_Load(object sender, EventArgs e)
        {
            GetDataPH();
            ConfigComboBoxAutoComplete();
            LoadComboBoxData();

        }

        // Lấy danh sách tất cả phiếu nhập hàng hiển thị lên DataGridView
        public void GetDataPH()
        {
            dgvListPhieuNhap.DataSource = _repo.GetDanhSachPNH();
        }

        // Hiển thị chi tiết phiếu nhập khi click vào một dòng trong danh sách phiếu nhập
        private void dgvListPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListPhieuNhap.Rows[e.RowIndex];
                string mapn = row.Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(mapn))
                {
                    dgvChiTietPhieuNhap.DataSource = _repo.GetChiTietPNH(mapn);
                }
            }
        }

        // Tự động lọc danh sách phiếu nhập ngay khi thay đổi ký tự trong ô tìm kiếm
   
        // Thực hiện tìm kiếm phiếu nhập khi người dùng nhấn nút Tìm kiếm
     
        // Đưa tất cả các ô nhập liệu và bộ lọc về trạng thái ban đầu
        private void btnReset_Click(object sender, EventArgs e)
        {

            cbNhanVien.SelectedIndexChanged -= cbNhanVien_SelectedIndexChanged;
            cbNhaCungCap.SelectedIndexChanged -= cbKhachHang_SelectedIndexChanged;
            dtpNgayNhap.ValueChanged -= dtpNgayMua_ValueChanged;

            cbNhanVien.SelectedIndex = -1;
            cbNhaCungCap.SelectedIndex = -1;
            dtpNgayNhap.Value = DateTime.Now;

            cbNhanVien.SelectedIndexChanged += cbNhanVien_SelectedIndexChanged;
            cbNhaCungCap.SelectedIndexChanged += cbKhachHang_SelectedIndexChanged;
            dtpNgayNhap.ValueChanged += dtpNgayMua_ValueChanged;

            GetDataPH();
            if (dgvChiTietPhieuNhap.DataSource != null)
            {
                ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
            }

        }

        // Thiết lập tính năng tự động gợi ý danh sách khi gõ chữ vào ComboBox
        private void ConfigComboBoxAutoComplete()
        {
            cbNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbNhaCungCap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbNhaCungCap.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // Nạp danh sách Nhân viên và Nhà cung cấp vào danh sách lựa chọn
        private void LoadComboBoxData()
        {
            DataTable dtNV = _repo.GetNhanVienList();
            cbNhanVien.DataSource = dtNV;
            cbNhanVien.DisplayMember = "HoTen";
            cbNhanVien.ValueMember = "MaNV";
            cbNhanVien.SelectedIndex = -1;

            DataTable dtNCC = _repo.GetNhaCungCapList();
            cbNhaCungCap.DataSource = dtNCC;
            cbNhaCungCap.DisplayMember = "TenNCC";
            cbNhaCungCap.ValueMember = "MaNCC";
            cbNhaCungCap.SelectedIndex = -1;
        }

        // Lọc danh sách phiếu nhập hàng theo nhân viên được chọn
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

        // Lọc danh sách phiếu nhập hàng theo nhà cung cấp được chọn
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

        // Lọc danh sách phiếu nhập hàng theo ngày chọn
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

        // Mở cửa sổ xem trước và thực hiện in phiếu nhập hàng đang chọn
        private void btnXemTruocHD_Click(object sender, EventArgs e)
        {
            if (dgvListPhieuNhap.SelectedRows.Count > 0)
            {
                string mapn = dgvListPhieuNhap.SelectedRows[0].Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(mapn))
                {
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

        // Thực hiện xóa phiếu nhập khỏi hệ thống
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvListPhieuNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPNH = dgvListPhieuNhap.CurrentRow.Cells["Mã PNH"].Value?.ToString();
            if (string.IsNullOrEmpty(maPNH)) return;

            DialogResult hoi = MessageBox.Show(
                $"Bạn có chắc muốn xóa phiếu nhập {maPNH}?\nToàn bộ chi tiết của phiếu cũng sẽ bị xóa và không thể khôi phục.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (hoi != DialogResult.Yes) return;

            try
            {
                _repo.XoaPhieuNhap(maPNH);

                MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataPH();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa phiếu nhập này!\nLỗi: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}