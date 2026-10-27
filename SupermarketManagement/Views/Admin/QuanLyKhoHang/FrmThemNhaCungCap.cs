using SupermarketManagement.Controllers;
using System;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.QuanLyKhoHang
{
    public partial class FrmThemNhaCungCap : Form
    {
        private KhoHangController _controller = new KhoHangController();

        public string MaNCCMoi { get; private set; }

        public FrmThemNhaCungCap()
        {
            InitializeComponent();
        }

        private void FrmThemNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNCC.Text = _controller.TaoMaNhaCungCapMoi();
            txtTenNCC.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text.Trim();
            string tenNCC = txtTenNCC.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenNCC))
            {
                MessageBox.Show("Vui lòng nhập tên Nhà Cung Cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }

            string thongBao;
            if (_controller.ThemNhaCungCap(maNCC, tenNCC, diaChi, sdt, out thongBao))
            {
                MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MaNCCMoi = maNCC;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
