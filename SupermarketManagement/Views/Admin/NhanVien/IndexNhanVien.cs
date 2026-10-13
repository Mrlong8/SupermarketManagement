using SupermarketManagement.Controllers.Repositories;
using SupermarketManagement.Models.Repositories;
using SupermarketManagement.Views.Admin.Account;
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

        private bool isLoading = true;
        public IndexNhanVien()
        {
            InitializeComponent();
  
        }

        private void IndexControl_Load(object sender, EventArgs e)
        {
            isLoading = true;
            GetDataNhanVien();
            getChucVu();
            getChucVuTimKiem();
            isLoading = false;
        }
        // lấy danh sách nhân viên từ cơ sở dữ liệu và hiển thị trong DataGridView
        public void GetDataNhanVien()
        {
           
            dgvListAccount.DataSource = _repo.GetAll();
            Onbtn();

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
                DataRow dr = dt.NewRow();
                dr["MaCV"] = "Tất cả";
                dr["TenChucVu"] = "--- Tất cả chức vụ ---";
                dt.Rows.InsertAt(dr, 0); // Thêm vào dòng đầu tiên

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
            txtLuongCB.Clear();
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
        private void btnLuu_Click(object sender, EventArgs e)
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
                Onbtn();

            }
        }
        
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ClearData();
            txtMaNV.Text = _repo.RenderMaNhanVien();
            txtMaNV.Enabled = false;
            txtHoTenNV.Focus();
            Offbtn();
        }

        //private void IndexNhanVien_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && !(this.ActiveControl is Button))
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //        e.SuppressKeyPress = true;
        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                // 1. Lấy điều khiển đang active
                Control currentControl = this.ActiveControl;

                // 2. Nếu đang đứng ở Button thì cho phép Enter để bấm Button bình thường
                if (currentControl is Button)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                // 3. Nếu đang ở các ô nhập liệu (TextBox, ComboBox, DateTimePicker...)
                // Chuyển focus sang ô tiếp theo
                this.SelectNextControl(currentControl, true, true, true, true);

                return true; // Ngăn phím Enter kích hoạt Button mặc định và chặn tiếng "bíp"
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Offbtn()
        {
            btnEditAccount.Enabled = false;
            btnEdit.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void Onbtn()
        {
            btnEditAccount.Enabled = true;
            btnEdit.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {

            string SelectedmaNV = txtMaNV.Text;


            if (string.IsNullOrEmpty(SelectedmaNV))
            {
                MessageBox.Show("Vui Lòng chọn thông tin nhân viên trong danh sách để xem tài khoản",
                           "Cảnh báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            IndexAccount frm = new IndexAccount(SelectedmaNV);
            frm.ShowDialog();
        }


        private void btnTimKiemUser_Click(object sender, EventArgs e)
        {
            if (isLoading) return;
            string keyword = txtTimKiem.Text.Trim();

            DataTable dt = _repo.Search(keyword);
            dgvListAccount.DataSource = dt;

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy nhân viên nào phù hợp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void cbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isLoading) return;
            // Chưa có dữ liệu hoặc chưa chọn chức vụ thì không lọc
            if (cbChucVu.SelectedValue == null)
                return;

            string maCV = cbChucVu.SelectedValue.ToString();

            DataTable dt = _repo.FilterByChucVu(maCV);
            dgvListAccount.DataSource = dt;
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            GetDataNhanVien();
            getChucVu();
            getChucVuTimKiem();
            ClearData();
        }
    }
}
