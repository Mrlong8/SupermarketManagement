//using SupermarketManagement.Models.Entities;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Windows.Forms;

//namespace SupermarketManagement
//{
//    public class LoginForm : Form
//    {
//        private TextBox txtUser, txtPass;
//        private CheckBox chkHienMK;
//        private Button btnDangNhap, btnThoat;

//        private void InitializeComponent()
//        {
//            this.SuspendLayout();
//            // 
//            // LoginForm
//            // 
//            this.ClientSize = new System.Drawing.Size(334, 274);
//            this.Name = "LoginForm";
//            this.ResumeLayout(false);

//        }

//        public LoginForm()
//        {
//            // ---- Form ----
//            Text = "Đăng nhập hệ thống";
//            ClientSize = new Size(380, 290);
//            StartPosition = FormStartPosition.CenterScreen;
//            FormBorderStyle = FormBorderStyle.FixedDialog;
//            MaximizeBox = MinimizeBox = false;
//            Font = new Font("Segoe UI", 10F);

//            var lblTitle = new Label
//            {
//                Text = "ĐĂNG NHẬP",
//                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
//                ForeColor = Color.SteelBlue,
//                AutoSize = false,
//                TextAlign = ContentAlignment.MiddleCenter,
//                Bounds = new Rectangle(0, 20, 380, 45)
//            };

//            var lblUser = new Label { Text = "Tên đăng nhập:", Bounds = new Rectangle(30, 85, 110, 25) };
//            txtUser = new TextBox { Bounds = new Rectangle(145, 82, 195, 27) };

//            var lblPass = new Label { Text = "Mật khẩu:", Bounds = new Rectangle(30, 130, 110, 25) };
//            txtPass = new TextBox { Bounds = new Rectangle(145, 127, 195, 27), UseSystemPasswordChar = true };

//            chkHienMK = new CheckBox { Text = "Hiện mật khẩu", Bounds = new Rectangle(145, 160, 195, 25) };
//            chkHienMK.CheckedChanged += (s, e) => txtPass.UseSystemPasswordChar = !chkHienMK.Checked;

//            btnDangNhap = new Button
//            {
//                Text = "Đăng nhập",
//                Bounds = new Rectangle(60, 210, 120, 38),
//                BackColor = Color.SteelBlue,
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat
//            };
//            btnDangNhap.Click += BtnDangNhap_Click;

//            btnThoat = new Button { Text = "Thoát", Bounds = new Rectangle(200, 210, 120, 38) };
//            btnThoat.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

//            AcceptButton = btnDangNhap;   // Enter = đăng nhập
//            CancelButton = btnThoat;      // Esc = thoát

//            Controls.AddRange(new Control[] { lblTitle, lblUser, txtUser, lblPass, txtPass, chkHienMK, btnDangNhap, btnThoat });
//        }

//        private void BtnDangNhap_Click(object sender, EventArgs e)
//        {
//            string user = txtUser.Text.Trim();
//            string pass = txtPass.Text;

//            if (user == "" || pass == "")
//            {
//                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            try
//            {
//                string sql = @"SELECT tk.MaTK, tk.UserName, tk.[Role], tk.MaNV, nv.HoTen, cv.TenChucVu
//                               FROM TaiKhoan tk
//                               LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
//                               LEFT JOIN ChucVu cv ON nv.MaCV = cv.MaCV
//                               WHERE tk.UserName = @u AND tk.[Password] = @p";

//                DataTable dt = DBHelper.GetTable(sql,
//                    new SqlParameter("@u", user),
//                    new SqlParameter("@p", DBHelper.Sha256(pass)));

//                if (dt.Rows.Count == 0)
//                {
//                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    txtPass.Clear();
//                    txtPass.Focus();
//                    return;
//                }

//                DataRow r = dt.Rows[0];
//                PhienDangNhap.MaTK = Convert.ToInt32(r["MaTK"]);
//                PhienDangNhap.UserName = r["UserName"].ToString();
//                PhienDangNhap.Role = r["Role"].ToString();
//                PhienDangNhap.MaNV = r["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(r["MaNV"]);
//                PhienDangNhap.HoTen = r["HoTen"] == DBNull.Value ? user : r["HoTen"].ToString();
//                PhienDangNhap.ChucVu = r["TenChucVu"] == DBNull.Value ? "" : r["TenChucVu"].ToString();

//                DialogResult = DialogResult.OK;
//                Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Không kết nối được CSDL:\n" + ex.Message, "Lỗi",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}