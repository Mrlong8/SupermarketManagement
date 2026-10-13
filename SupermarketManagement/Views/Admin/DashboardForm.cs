using System;
using System.Drawing;
using System.Windows.Forms;
using SupermarketManagement.Utils;

namespace SupermarketManagement.Views.Admin
{
    // File này chỉ chứa code SỰ KIỆN. Giao diện nằm ở DashboardForm.Designer.cs (chỉnh bằng kéo thả)
    public partial class DashboardForm : Form
    {
        public bool DangXuat = false;   // true: quay lại màn hình đăng nhập (Program.cs đọc biến này)

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = string.Format("Xin chào: {0}  |  Chức vụ: {1}  |  Quyền: {2}",
                UserSession.HoTen, UserSession.ChucVu, UserSession.Role);

            // Phân quyền: nhân viên thường không thấy Nhân sự và Nhập hàng
            mnuNhanSu.Visible = UserSession.LaAdmin;
            mnuNhapHang.Visible = UserSession.LaAdmin;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // ===== Tất cả menu chức năng dùng chung 1 hàm này =====
        // Khi có form thật, thay bằng: MoForm<TênForm>(); (xem hàm MoForm<T> bên dưới)
        private void mnuMoForm_Click(object sender, EventArgs e)
        {
            string tieuDe = ((ToolStripMenuItem)sender).Text;

            foreach (Form f in MdiChildren)
            {
                if (f.Text == tieuDe) { f.Activate(); return; }
            }

            Form child = new Form { Text = tieuDe, MdiParent = this, Size = new Size(800, 500) };
            child.Controls.Add(new Label
            {
                Text = "Chức năng \"" + tieuDe + "\" đang được phát triển...",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });
            child.Show();
        }

        // Mở form con thật, không mở trùng. Ví dụ: MoForm<ManageStaffForm>();
        private void MoForm<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T) { f.Activate(); return; }
            }
            new T { MdiParent = this }.Show();
        }

        // ===== Cửa sổ =====
        private void mnuXepChong_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuXepNgang_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuDongTatCa_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren) f.Close();
        }

        // ===== Đăng xuất / Thoát =====
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                DangXuat = true;
                Close();    // Program.cs sẽ mở lại LoginForm
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!DangXuat && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult kq = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.No) { e.Cancel = true; return; }
            }
            timer1.Stop();
        }
    }
}