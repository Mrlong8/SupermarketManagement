using SupermarketManagement.Controllers.Repositories;
using SupermarketManagement.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.KhachHang
{
    public partial class IndexKhachHang : Form
    {
        
        private KhachHangRepository _repo = new KhachHangRepository();

        private bool isLoading = true;

        public IndexKhachHang()
        {
            InitializeComponent();
        }

        private void IndexKhachHang_Load(object sender, EventArgs e)
        {
            isLoading = true;
            GetDataKhachHang();
            isLoading = false;
        }

        // Lấy danh sách khách hàng từ cơ sở dữ liệu và hiển thị trong DataGridView
        public void GetDataKhachHang()
        {
            dgvListKhachHang.DataSource = _repo.GetAll();
            TrangThaiBanDau();
        }

        // Xóa dữ liệu trong các TextBox và thiết lập giá trị mặc định
        public void ClearData()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            dtpNgayDangKy.Value = DateTime.Now;
            txtDiemTichLuy.Text = "0";
            txtMaKH.Enabled = true;

            TrangThaiBanDau();
        }

        // Gom dữ liệu từ các điều khiển nhập liệu
        private (string maKH, string hoTen, string soDienThoai, string email, DateTime ngayDangKy, int diemTichLuy) GetFormData()
        {
            string maKH = txtMaKH.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime ngayDangKy = dtpNgayDangKy.Value;
            int diemTichLuy = 0;
            int.TryParse(txtDiemTichLuy.Text.Trim(), out diemTichLuy);

            return (maKH, hoTen, soDienThoai, email, ngayDangKy, diemTichLuy);
        }

        // Validate dữ liệu đầu vào
        private bool ValidateForm(bool isEdit = false)
        {
            var data = GetFormData();
            if (string.IsNullOrWhiteSpace(data.maKH) ||
                string.IsNullOrWhiteSpace(data.hoTen) ||
                string.IsNullOrWhiteSpace(data.soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!isEdit && _repo.CheckExists(data.maKH))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsValidEmail(data.email))
            {
                MessageBox.Show("Định dạng email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Chỉ cho phép nhập số
        private void ChiNhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Thêm mới khách hàng
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateForm(isEdit: false)) return;

            try
            {
                var d = GetFormData();
                _repo.Insert(d.maKH, d.hoTen, d.soDienThoai, d.email, d.ngayDangKy, d.diemTichLuy);
                MessageBox.Show("Thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                GetDataKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa khách hàng
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvListKhachHang.CurrentRow == null || dgvListKhachHang.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 khách hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm(isEdit: true)) return;

            try
            {
                var d = GetFormData();
                _repo.Update(d.maKH, d.hoTen, d.soDienThoai, d.email, d.ngayDangKy, d.diemTichLuy);
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                GetDataKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa khách hàng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvListKhachHang.CurrentRow == null || dgvListKhachHang.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = dgvListKhachHang.CurrentRow.Cells["MaKH"].Value?.ToString();

            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _repo.Delete(maKH);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    GetDataKhachHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Click trên DataGridView
        private void dgvListKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListKhachHang.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells["MaKH"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();

                if (row.Cells["NgayDangKy"].Value != null && DateTime.TryParse(row.Cells["NgayDangKy"].Value.ToString(), out DateTime dt))
                {
                    dtpNgayDangKy.Value = dt;
                }
                else
                {
                    dtpNgayDangKy.Value = DateTime.Now;
                }

                txtDiemTichLuy.Text = row.Cells["DiemTichLuy"].Value?.ToString() ?? "0";

                txtMaKH.Enabled = false;
                TrangThaiChonDeSua();
            }
        }

        // Nút thêm mới - tạo mã tự động
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ClearData();
            txtMaKH.Text = _repo.RenderMaKhachHang();
            txtMaKH.Enabled = false;
            txtHoTen.Focus();
            TrangThaiThemMoi();
        }

        // Hỗ trợ phím Enter để chuyển ô nhập liệu tiếp theo
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Control currentControl = this.ActiveControl;
                if (currentControl is Button)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                this.SelectNextControl(currentControl, true, true, true, true);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TrangThaiBanDau()
        {
            btnLuu.Enabled = false;
            btnEdit.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void TrangThaiThemMoi()
        {
            btnLuu.Enabled = true;
            btnEdit.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void TrangThaiChonDeSua()
        {
            btnLuu.Enabled = false;
            btnEdit.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Tìm kiếm khách hàng theo từ khóa
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (isLoading) return;
            string keyword = txtTimKiem.Text.Trim();

            DataTable dt = _repo.Search(keyword);
            dgvListKhachHang.DataSource = dt;

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy khách hàng nào phù hợp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // Làm mới dữ liệu
        private void btnReset_Click(object sender, EventArgs e)
        {
            GetDataKhachHang();
            ClearData();
            txtTimKiem.Clear();
        }
    }
}
