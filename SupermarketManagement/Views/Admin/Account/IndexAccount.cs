using SupermarketManagement.Controllers.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.Account
{
    public partial class IndexAccount : Form
    {
        private string maNV;
        private bool status;
        private TaiKhoanRepository _reppo = new TaiKhoanRepository();
        public IndexAccount(string maNV,bool status)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.status = status;
        }

     
        private void IndexAccount_Load(object sender, EventArgs e)
        {
            if (status == true)
            {
                GetThongTin();
                btnLuu.Text = "Lưu cập nhật";
            }
            else
            {
                TaoTaiKhoan();
                btnLuu.Text = "Tạo tài khoản";
            }
            GetRole();
        }

        public void TaoTaiKhoan()
        {
            txtUserName.Text = "";
            txtPassCu.Text = "";
            txtSDT.Text = "";
            cbRole.SelectedIndex = -1;
            picAvata.Image = null;

            string txtMaTK = _reppo.RenderMaTK();
            lblManv.Text = "Mã Nhân Viên : " + maNV;
            lblMaTK.Text = "Mã Tài Khoản : "+ txtMaTK;

            txtUserName.Enabled = true;
            txtPassCu.Enabled = true;
            txtSDT.Enabled = true;
            cbRole.Enabled = true;
            btnLuu.Enabled = true;
        }
        public void GetThongTin()
        {
            DataTable dt = _reppo.GetThongTinTK(maNV);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Gán dữ liệu lên giao diện
                txtUserName.Text = row["UserName"].ToString();
                txtPassCu.Text = "";
                txtSDT.Text = row["SDT"].ToString();
                lblManv.Text = "Mã Nhân Viên : " +  row["MaNV"].ToString();
                lblMaTK.Text = "Mã Tài Khoản : " +  row["MaTK"].ToString();
                string userRole = row["Role"]?.ToString();
                txtRole.Text = userRole;

                txtUserName.Enabled = false;
                txtPassCu.Enabled = false;
                txtSDT.Enabled = false;
                cbRole.Enabled = false;
                txtPasswordNew.Enabled = false;
                txtXacNhan.Enabled = false;
                btnLuu.Enabled = false;


                // hiển thi avat
                string imagePath = row["UrlImage"]?.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    imagePath = imagePath.TrimStart('/','\\');
                    string fullPath = Path.Combine(Application.StartupPath,imagePath);

                    if (File.Exists(fullPath))
                    {
                        picAvata.ImageLocation = fullPath;

                    }
                    else
                    {
                        picAvata.Image = null;
                    }
                }
                else
                {
                    picAvata.Image = null;
                }

            }

        }



        public void GetRole()
        {
            cbRole.Items.Clear();
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Manager");
            cbRole.Items.Add("Cashier");
            cbRole.Items.Add("Warehouse");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            txtUserName.Enabled = true;
            txtSDT.Enabled = true;
            cbRole.Enabled = true;
            btnLuu.Enabled = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string role = cbRole.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            try
            {
                if (status == true)
                {
                    _reppo.UpdateTaiKhoan(maNV, userName, sdt, role);
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetThongTin();
                }
                else
                {
                    string pass = txtPassCu.Text.Trim();
                    if (string.IsNullOrEmpty(pass))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu cho tài khoản mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassCu.Focus();
                        return;
                    }
                    if (_reppo.CheckTrungUserName(userName))
                    {
                        MessageBox.Show("Tên đăng nhập (UserName) này đã tồn tại. Vui lòng chọn tên khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUserName.Focus();
                        txtUserName.SelectAll();
                        return;
                    }
                    string passHash = SupermarketManagement.Utils.SecurityHelper.Sha256(pass);
                   

                    _reppo.ThemTaiKhoanMoi(_reppo.RenderMaTK(), userName, passHash, sdt, role,maNV);

                    MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    status = true;
                    btnLuu.Text = "Lưu cập nhật";

                    GetThongTin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThayAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "File ảnh |*.jpg;*.jpeg;*.png";
            openFile.Title = "Chọn ảnh đại diện";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string targetFoder = Path.Combine(Application.StartupPath, "Resources", "Avata");
                    if (!Directory.Exists(targetFoder))
                    {
                        Directory.CreateDirectory(targetFoder);
                    }

                    string fileName = maNV + "_" + Path.GetFileName(openFile.FileName);
                    string fullPath = Path.Combine(targetFoder,fileName);

                    string oldFullPath = "";
                    DataTable dt = _reppo.GetThongTinTK(maNV);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string oldRelativePath = dt.Rows[0]["UrlImage"]?.ToString();
                        if (!string.IsNullOrEmpty(oldRelativePath))
                        {
                            oldFullPath = Path.Combine(Application.StartupPath,oldRelativePath);

                        }
                    }

                    // dùng để copy ảng vào thư mục lưu trữ
                    File.Copy(openFile.FileName,fullPath,true);
                    // hiểm thị ảnh
                    picAvata.ImageLocation = fullPath;

                    // luwu leen csdl
                    string relativePath = Path.Combine("Resources", "Avata", fileName);

                    _reppo.UpdateImage(maNV, relativePath);

                    if (!string.IsNullOrEmpty(oldFullPath) && File.Exists(oldFullPath) && oldFullPath.ToLower() != fullPath.ToLower())
                    {
                        File.Delete(oldFullPath);
                    }
                    MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chọn ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {

            txtPasswordNew.Enabled = true;
            txtPassCu.Enabled = true;

            txtXacNhan.Enabled = true;
            string passCu = txtPassCu.Text.Trim();
            string passMoi = txtPasswordNew.Text.Trim();
            string xacNhan = txtXacNhan.Text.Trim();

        
            if (string.IsNullOrEmpty(passCu) || string.IsNullOrEmpty(passMoi) || string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (passMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhan.Focus();
                return;
            }
            string hashCu = SupermarketManagement.Utils.SecurityHelper.Sha256(passCu);
            string hashMoi = SupermarketManagement.Utils.SecurityHelper.Sha256(passMoi);

           
            bool isSuccess = _reppo.DoiMatKhau(maNV, hashCu, hashMoi);

            if (isSuccess)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

             
                txtPasswordNew.Clear();
                txtPassCu.Clear();
                txtXacNhan.Clear();
                GetThongTin();
              
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswordNew.Focus();
                txtPasswordNew.SelectAll();
            }
        }
    }
}
