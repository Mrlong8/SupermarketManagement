using SupermarketManagement.Controllers.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.ChucVu
{
    public partial class IndexChucVu : Form
    {
        private readonly ChucVuRepository _repo = new ChucVuRepository();

        public IndexChucVu()
        {
            InitializeComponent();
        }

        private void CreateChucVu_Load(object sender, EventArgs e)
        {
            GetDataChucVu();
        }

        public void GetDataChucVu()
        {
            dgvListChucVu.DataSource = _repo.GetAll();
        }

        public void ClearData()
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
            txtHeSoLuong.Clear();
            rdbFullTime.Checked = false;
            rdbPartTime.Checked = false;
            txtMaCV.Enabled = true; 
        }

        // Hàm helper gom nhóm dữ liệu đầu vào từ Form
        private (string maCV, string tenCV, string heSoLuong, string caLamViec) GetFormData()
        {
            string maCV = txtMaCV.Text.Trim();
            string tenCV = txtTenCV.Text.Trim();
            string heSo = txtHeSoLuong.Text.Trim();
            string ca = rdbFullTime.Checked ? "Full-time" : (rdbPartTime.Checked ? "Part-time" : "");

            return (maCV, tenCV, heSo, ca);
        }

        // Validate dữ liệu đầu vào
        private bool ValidateForm(bool isEdit = false)
        {
            var data = GetFormData();

            if (string.IsNullOrWhiteSpace(data.maCV) || string.IsNullOrWhiteSpace(data.tenCV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(data.caLamViec))
            {
                MessageBox.Show("Vui lòng chọn Ca làm việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!isEdit && _repo.CheckExists(data.maCV))
            {
                MessageBox.Show("Mã chức vụ đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm(isEdit: false)) return;

            try
            {
                var d = GetFormData();
                _repo.Insert(d.maCV, d.tenCV, d.heSoLuong, d.caLamViec);
                MessageBox.Show("Thêm chức vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearData();
                GetDataChucVu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvListChucVu.CurrentRow == null || dgvListChucVu.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một chức vụ để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm(isEdit: true)) return;

            try
            {
                var d = GetFormData();
                _repo.Update(d.maCV, d.tenCV, d.heSoLuong, d.caLamViec);
                MessageBox.Show("Cập nhật chức vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearData();
                GetDataChucVu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvListChucVu.SelectedRows.Count == 0 || dgvListChucVu.SelectedRows[0].Cells["MaCV"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng chức vụ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maCV = dgvListChucVu.SelectedRows[0].Cells["MaCV"].Value.ToString();

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa chức vụ {maCV}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _repo.Delete(maCV);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearData();
                    GetDataChucVu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Click trên DataGridView hiển thị ngược lại
        private void dgvListChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListChucVu.Rows[e.RowIndex];

                txtMaCV.Text = row.Cells["MaCV"].Value?.ToString();
                txtTenCV.Text = row.Cells["TenChucVu"].Value?.ToString();
                txtHeSoLuong.Text = row.Cells["HeSoLuong"].Value?.ToString();

                string caLamViec = row.Cells["CaLamViec"].Value?.ToString();
                rdbFullTime.Checked = (caLamViec == "Full-time");
                rdbPartTime.Checked = (caLamViec == "Part-time");

                txtMaCV.Enabled = false; // Khi chọn dòng thì không cho sửa Mã
            }
        }

        private void rdbFullTime_CheckedChanged(object sender, EventArgs e) => txtHeSoLuong.Text = "1.7";
        private void rdbPartTime_CheckedChanged(object sender, EventArgs e) => txtHeSoLuong.Text = "1.2";
        private void btnThoat_Click(object sender, EventArgs e) => Close();
    }
}