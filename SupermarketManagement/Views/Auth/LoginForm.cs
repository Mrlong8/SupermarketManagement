using System;
using System.Windows.Forms;
using SupermarketManagement.Controllers;

namespace SupermarketManagement.Views.Auth
{
    // File này chỉ chứa code SỰ KIỆN. Giao diện nằm ở LoginForm.Designer.cs (chỉnh bằng kéo thả)
    public partial class LoginForm : Form
    {
        private readonly AuthController auth = new AuthController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;

            if (user == "" || pass == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (auth.DangNhap(user, pass))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtPass.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkHienMK.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}