using System;
using System.Drawing;
using System.Windows.Forms;

namespace SupermarketManagement
{
    public class DashboardForm : Form
    {
        public bool DangXuat = false;   // true: quay lại màn hình đăng nhập

        private MenuStrip menu;
        private StatusStrip status;
        private ToolStripStatusLabel lblUser, lblTime;
        private Timer timer;

        public DashboardForm()
        {
            Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG";
            WindowState = FormWindowState.Maximized;
            IsMdiContainer = true;
            Font = new Font("Segoe UI", 10F);

            TaoMenu();
            TaoStatusBar();
            PhanQuyen();

            FormClosing += FrmMain_FormClosing;
        }

        // ================= MENU =================
        private void TaoMenu()
        {
            menu = new MenuStrip();

            // --- Hệ thống ---
            var mnuHeThong = new ToolStripMenuItem("Hệ thống");
            mnuHeThong.DropDownItems.Add("Đổi mật khẩu", null, (s, e) => DoiMatKhau());
            mnuHeThong.DropDownItems.Add(new ToolStripSeparator());
            mnuHeThong.DropDownItems.Add("Đăng xuất", null, (s, e) => DangXuat_Click());
            mnuHeThong.DropDownItems.Add("Thoát", null, (s, e) => Close());

            // --- Quản lý hàng hoá ---
            var mnuHang = new ToolStripMenuItem("Hàng hoá");
            mnuHang.DropDownItems.Add("Sản phẩm", null, (s, e) => MoForm("Quản lý sản phẩm"));
            mnuHang.DropDownItems.Add("Danh mục", null, (s, e) => MoForm("Quản lý danh mục"));
            mnuHang.DropDownItems.Add("Khuyến mãi", null, (s, e) => MoForm("Quản lý khuyến mãi"));

            // --- Nhập hàng ---
            var mnuNhap = new ToolStripMenuItem("Nhập hàng") { Name = "mnuNhap" };
            mnuNhap.DropDownItems.Add("Phiếu nhập hàng", null, (s, e) => MoForm("Phiếu nhập hàng"));
            mnuNhap.DropDownItems.Add("Nhà cung cấp", null, (s, e) => MoForm("Quản lý nhà cung cấp"));

            // --- Bán hàng ---
            var mnuBan = new ToolStripMenuItem("Bán hàng");
            mnuBan.DropDownItems.Add("Hoá đơn", null, (s, e) => MoForm("Quản lý hoá đơn"));
            mnuBan.DropDownItems.Add("Khách hàng", null, (s, e) => MoForm("Quản lý khách hàng"));

            // --- Nhân sự (chỉ Admin) ---
            var mnuNhanSu = new ToolStripMenuItem("Nhân sự") { Name = "mnuNhanSu" };
            mnuNhanSu.DropDownItems.Add("Nhân viên", null, (s, e) => MoForm("Quản lý nhân viên"));
            mnuNhanSu.DropDownItems.Add("Chức vụ", null, (s, e) => MoForm("Quản lý chức vụ"));
            mnuNhanSu.DropDownItems.Add("Tài khoản", null, (s, e) => MoForm("Quản lý tài khoản"));

            // --- Cửa sổ ---
            var mnuCuaSo = new ToolStripMenuItem("Cửa sổ");
            mnuCuaSo.DropDownItems.Add("Xếp chồng", null, (s, e) => LayoutMdi(MdiLayout.Cascade));
            mnuCuaSo.DropDownItems.Add("Xếp ngang", null, (s, e) => LayoutMdi(MdiLayout.TileHorizontal));
            mnuCuaSo.DropDownItems.Add("Đóng tất cả", null, (s, e) =>
            {
                foreach (var f in MdiChildren) f.Close();
            });

            menu.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuHang, mnuNhap, mnuBan, mnuNhanSu, mnuCuaSo });
            MainMenuStrip = menu;
            Controls.Add(menu);
        }

        // ================= STATUS BAR =================
        private void TaoStatusBar()
        {
            status = new StatusStrip();
            lblUser = new ToolStripStatusLabel(
                string.Format("Xin chào: {0}  |  Chức vụ: {1}  |  Quyền: {2}",
                    PhienDangNhap.HoTen, PhienDangNhap.ChucVu, PhienDangNhap.Role));
            lblTime = new ToolStripStatusLabel { Spring = true, TextAlign = ContentAlignment.MiddleRight };

            status.Items.AddRange(new ToolStripItem[] { lblUser, lblTime });
            Controls.Add(status);

            timer = new Timer { Interval = 1000 };
            timer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer.Start();
        }

        // ================= PHÂN QUYỀN =================
        private void PhanQuyen()
        {
            // Nhân viên thường không được vào Nhân sự & Nhập hàng
            bool admin = PhienDangNhap.LaAdmin;
            menu.Items["mnuNhanSu"].Visible = admin;
            menu.Items["mnuNhap"].Visible = admin;
        }

        // ================= MỞ FORM CON =================
        // Tạm dùng form rỗng. Khi bạn/nhóm làm xong form thật, thay bằng:
        //   MoForm<FrmSanPham>();
        private void MoForm(string tieuDe)
        {
            // Nếu form đã mở thì kích hoạt lại, không mở trùng
            foreach (var f in MdiChildren)
            {
                if (f.Text == tieuDe) { f.Activate(); return; }
            }

            var child = new Form { Text = tieuDe, MdiParent = this, Size = new Size(800, 500) };
            child.Controls.Add(new Label
            {
                Text = "Chức năng \"" + tieuDe + "\" đang được phát triển...",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });
            child.Show();
        }

        // Dùng cho form thật: MoForm<FrmSanPham>();
        private void MoForm<T>() where T : Form, new()
        {
            foreach (var f in MdiChildren)
            {
                if (f is T) { f.Activate(); return; }
            }
            new T { MdiParent = this }.Show();
        }

        // ================= ĐỔI MẬT KHẨU =================
        private void DoiMatKhau()
        {
            using (var f = new Form())
            {
                f.Text = "Đổi mật khẩu";
                f.ClientSize = new Size(340, 190);
                f.StartPosition = FormStartPosition.CenterParent;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.MaximizeBox = f.MinimizeBox = false;

                var txtCu = new TextBox { Bounds = new Rectangle(140, 20, 180, 27), UseSystemPasswordChar = true };
                var txtMoi = new TextBox { Bounds = new Rectangle(140, 60, 180, 27), UseSystemPasswordChar = true };
                var txtNhapLai = new TextBox { Bounds = new Rectangle(140, 100, 180, 27), UseSystemPasswordChar = true };
                var btnOk = new Button { Text = "Lưu", Bounds = new Rectangle(140, 140, 85, 32) };

                btnOk.Click += (s, e) =>
                {
                    if (txtMoi.Text.Length < 4) { MessageBox.Show("Mật khẩu mới tối thiểu 4 ký tự!"); return; }
                    if (txtMoi.Text != txtNhapLai.Text) { MessageBox.Show("Mật khẩu nhập lại không khớp!"); return; }

                    var dt = DBHelper.GetTable(
                        "SELECT 1 FROM TaiKhoan WHERE MaTK=@id AND [Password]=@p",
                        new System.Data.SqlClient.SqlParameter("@id", PhienDangNhap.MaTK),
                        new System.Data.SqlClient.SqlParameter("@p", DBHelper.Sha256(txtCu.Text)));
                    if (dt.Rows.Count == 0) { MessageBox.Show("Mật khẩu cũ không đúng!"); return; }

                    DBHelper.ExecuteNonQuery("UPDATE TaiKhoan SET [Password]=@p WHERE MaTK=@id",
                        new System.Data.SqlClient.SqlParameter("@p", DBHelper.Sha256(txtMoi.Text)),
                        new System.Data.SqlClient.SqlParameter("@id", PhienDangNhap.MaTK));
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    f.Close();
                };

                f.Controls.AddRange(new Control[]
                {
                    new Label { Text = "Mật khẩu cũ:", Bounds = new Rectangle(20, 23, 115, 25) },
                    new Label { Text = "Mật khẩu mới:", Bounds = new Rectangle(20, 63, 115, 25) },
                    new Label { Text = "Nhập lại:", Bounds = new Rectangle(20, 103, 115, 25) },
                    txtCu, txtMoi, txtNhapLai, btnOk
                });
                f.ShowDialog(this);
            }
        }

        // ================= ĐĂNG XUẤT / THOÁT =================
        private void DangXuat_Click()
        {
            var kq = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                DangXuat = true;
                Close();   // Program.cs sẽ mở lại FrmDangNhap
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Đóng bằng nút X hoặc menu Thoát (không phải đăng xuất) -> xác nhận
            if (!DangXuat && e.CloseReason == CloseReason.UserClosing)
            {
                var kq = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.No) e.Cancel = true;
            }
            if (!e.Cancel) timer.Stop();
        }
    }
}