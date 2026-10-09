using SupermarketManagement.Controllers.Repositories;
using SupermarketManagement.Models.Repositories;
using SupermarketManagement.Views.Admin.ChucVu;
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

namespace SupermarketManagement.Views.Account
{
    public partial class IndexNhanVien : UserControl
    {
        DbConection _db = new DbConection();
        private NhanVienRepository _repo = new NhanVienRepository();
        private ChucVuRepository _repoCV = new ChucVuRepository();
        public IndexNhanVien()
        {
            InitializeComponent();
  
        }

        private void IndexControl_Load(object sender, EventArgs e)
        {
            GetDataNhanVien();
            getChucVu();
            getChucVuTimKiem();
        }
        // lấy danh sách nhân viên từ cơ sở dữ liệu và hiển thị trong DataGridView
        public void GetDataNhanVien()
        {
           
            dgvListAccount.DataSource = _repo.GetAll();
        }

        // lấy mã chức vụ
        public void getChucVu()
        {
            DataTable dt = _repoCV.GetAll();
            if (dt != null && dt.Rows.Count > 0)
            {
                cbMaCV.DataSource = dt;
                cbMaCV.DisplayMember = "TenChucVu";
                cbMaCV.ValueMember = "MaCV";
            }
        }

        public void getChucVuTimKiem()
        {
            DataTable dt = _repoCV.GetAll();
            if (dt != null && dt.Rows.Count > 0)
            {
                cbChucVu.DataSource = dt;
                cbChucVu.DisplayMember = "TenChucVu";
                cbChucVu.ValueMember = "MaCV";
            }
        }
        // Xóa dữ liệu trong các TextBox và ComboBox
        public void ClearData()
        {
            txtMaNV.Clear();
            txtHoTenNV.Clear();
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            cbMaCV.SelectedIndex = -1;
            txtEmail.Clear();
            txtMaNV.Enabled = true;
        }
        // gom dữ liệu từ các TextBox và ComboBox
        private (string maNV, string hotenNV,string gioiTinh,string luongCB, DateTime ngaySinh, string diaChi, string maCV, string email) GetFormData()
        {
            string maNV = txtMaNV.Text.Trim();
            string hotenNV = txtHoTenNV.Text.Trim();
            string gioiTinh = rdbNam.Checked ? "Nam" : (rdbNu.Checked ? "Nữ" : "");
            string luongCB = txtLuongCB.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = txtDiaChi.Text.Trim();
            string maCV = cbMaCV.SelectedValue?.ToString();
            string email = txtEmail.Text.Trim();

            return (maNV, hotenNV, gioiTinh, luongCB, ngaySinh, diaChi, maCV, email);
        }
        // thêm chức vụ mới
        private void btnThemCV_Click(object sender, EventArgs e)
        {
            IndexChucVu form = new IndexChucVu();
            form.ShowDialog();

            getChucVu();
            getChucVuTimKiem();
            GetDataNhanVien();
        }
        // validate dữ liệu đầu vào
        private bool ValidateForm(bool isEdit = false)
        {
            var data = GetFormData();
            if (string.IsNullOrWhiteSpace(data.maNV) || 
                    string.IsNullOrWhiteSpace(data.hotenNV) || 
                    string.IsNullOrWhiteSpace(data.gioiTinh) || 
                    string.IsNullOrWhiteSpace(data.luongCB) || 
                    string.IsNullOrWhiteSpace(data.diaChi) || 
                    string.IsNullOrWhiteSpace(data.maCV) || 
                    string.IsNullOrWhiteSpace(data.email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // kiểm tra trùng ma
            if (!isEdit && _repo.CheckExists(data.maNV))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // kiểm tra định dạng email
            if (!IsValidEmail(data.email))
            {
                MessageBox.Show("Định dạng email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        // kiểm tra định dạng email
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
        // chỉ được điền số
        private void ChiNhapSo(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // thêm nhân viên mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm(isEdit: false)) return;

            try
            {
                var d = GetFormData();
                _repo.Insert(d.maNV, d.hotenNV, d.gioiTinh, d.luongCB, d.ngaySinh, d.diaChi, d.maCV, d.email);
                MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                GetDataNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhân viên: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // sửa nhân viên
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvListAccount.CurrentRow == null || dgvListAccount.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 nhân viên để sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm(isEdit: true)) return;

            try
            {
                var d = GetFormData();
                _repo.Update(d.maNV,d.hotenNV,d.gioiTinh,d.luongCB,d.ngaySinh,d.diaChi,d.maCV,d.email);
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                GetDataNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvListAccount.CurrentRow == null || dgvListAccount.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 nhân viên để xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = dgvListAccount.CurrentRow.Cells["MaNV"].Value?.ToString();

            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _repo.Delete(maNV);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    GetDataNhanVien();
                }catch(Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            }
        }


        // Click trên dvg
        private void dgvListAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                DataGridViewRow row = dgvListAccount.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                txtHoTenNV.Text = row.Cells["HoTen"].Value?.ToString();
                txtLuongCB.Text = row.Cells["LuongCoBan"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();

                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                rdbNam.Checked = (gioiTinh == "Nam");
                rdbNu.Checked = (gioiTinh == "Nữ" || gioiTinh == "Nu");
                txtMaNV.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }
    }
}
