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
        private TaiKhoanRepository _reppo = new TaiKhoanRepository();
        public IndexAccount(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

     
        private void IndexAccount_Load(object sender, EventArgs e)
        {
            GetThongTin();
            GetRole();
        }
        public void GetThongTin()
        {
            DataTable dt = _reppo.GetThongTinTK(maNV);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Gán dữ liệu lên giao diện
                txtUserName.Text = row["UserName"].ToString();
                txtPassword.Text = row["Password"].ToString();
                txtSDT.Text = row["SDT"].ToString();
                lblManv.Text = "Mã Nhân Viên : " +  row["MaNV"].ToString();
                lblMaTK.Text = "Mã Tài Khoản : " +  row["MaTK"].ToString();
                string userRole = row["Role"]?.ToString();
                txtRole.Text = userRole;

                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtSDT.Enabled = false;
                cbRole.Enabled = false;

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
                _reppo.UpdateTaiKhoan(maNV, userName, sdt, role);

                MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetThongTin();
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
    }
}
