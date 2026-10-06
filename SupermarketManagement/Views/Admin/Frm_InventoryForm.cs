using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin
{
    public partial class Frm_InventoryForm : Form
    {
        // Khai báo các Controls chín
        private SplitContainer splitMain;
        private SplitContainer splitTop;
        private TableLayoutPanel layoutBottom;

        // Controls phần Danh mục
        private TreeView tvDanhMuc;
        private Button btnThemDM, btnSuaDM, btnXoaDM;

        // Controls phần Hàng hóa
        private ComboBox cboLocDanhMuc;
        private Button btnThemSP, btnSuaSP, btnXoaSP;
        private DataGridView dgvSanPham;

        // Controls phần Hóa đơn
        private DataGridView dgvHoaDonNhap;
        private Button btnThemHD, btnSuaHD, btnXoaHD;
        private DataGridView dgvChiTietHD;
        public Frm_InventoryForm()
        {
            InitializeComponent();
            InitializeUI();
        }
        public void InitializeUI()
        {
            this.Text = "QUẢN LÝ SIÊU THỊ MINI";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

   

            // 2. SplitContainer Chính (Chia trên/dưới)
            splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 350,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(splitMain);
            splitMain.BringToFront(); // Đưa lên trên để không bị đè bởi Menu

            // ==========================================
            // PHẦN TRÊN: QUẢN LÝ HÀNG HÓA & DANH MỤC
            // ==========================================
            splitTop = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 250,
                BorderStyle = BorderStyle.Fixed3D
            };
            splitMain.Panel1.Controls.Add(splitTop);

            // -- PANEL TRÁI: DANH MỤC --
            Label lblDanhMuc = new Label { Text = "Danh Mục Hàng Hóa", Dock = DockStyle.Top, Font = new Font("Arial", 10, FontStyle.Bold) };
            tvDanhMuc = new TreeView { Dock = DockStyle.Fill };
            tvDanhMuc.Nodes.Add("Hàng hóa"); // Giả lập node

            FlowLayoutPanel pnlBtnDM = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 100 };
            btnThemDM = new Button { Text = "Thêm danh mục", Width = 110, Height = 35 };
            btnSuaDM = new Button { Text = "Sửa danh mục", Width = 110, Height = 35 };
            btnXoaDM = new Button { Text = "Xóa danh mục", Width = 110, Height = 35 };
            pnlBtnDM.Controls.AddRange(new Control[] { btnThemDM, btnSuaDM, btnXoaDM });

            splitTop.Panel1.Controls.Add(tvDanhMuc);
            splitTop.Panel1.Controls.Add(lblDanhMuc);
            splitTop.Panel1.Controls.Add(pnlBtnDM);

            // -- PANEL PHẢI: HÀNG HÓA --
            Panel pnlHeaderSP = new Panel { Dock = DockStyle.Top, Height = 40 };
            Label lblSP = new Label { Text = "Danh mục: ", AutoSize = true, Location = new Point(10, 10) };
            cboLocDanhMuc = new ComboBox { Location = new Point(80, 7), Width = 150 };
            btnThemSP = new Button { Text = "Thêm Hàng Hóa", Location = new Point(250, 5), AutoSize = true };
            btnSuaSP = new Button { Text = "Sửa Hàng Hóa", Location = new Point(360, 5), AutoSize = true };
            btnXoaSP = new Button { Text = "Xóa Hàng Hóa", Location = new Point(470, 5), AutoSize = true };

            pnlHeaderSP.Controls.AddRange(new Control[] { lblSP, cboLocDanhMuc, btnThemSP, btnSuaSP, btnXoaSP });

            dgvSanPham = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White
            };
            // Thêm các cột cho Hàng Hóa
            dgvSanPham.Columns.Add("MaSP", "Mã SP");
            dgvSanPham.Columns.Add("TenSP", "Tên Sản Phẩm");
            dgvSanPham.Columns.Add("DanhMuc", "Danh Mục");
            dgvSanPham.Columns.Add("SoLuong", "Số Lượng Tồn");
            dgvSanPham.Columns.Add("DonGia", "Đơn Giá");
            dgvSanPham.Columns.Add("NCC", "Nhà Cung Cấp");

            splitTop.Panel2.Controls.Add(dgvSanPham);
            splitTop.Panel2.Controls.Add(pnlHeaderSP);


            // ==========================================
            // PHẦN DƯỚI: QUẢN LÝ HÓA ĐƠN NHẬP
            // ==========================================
            Label lblHDN = new Label { Text = "QUẢN LÝ HÓA ĐƠN NHẬP", Dock = DockStyle.Top, Font = new Font("Arial", 10, FontStyle.Bold), BackColor = Color.FromArgb(41, 57, 85), ForeColor = Color.White, Height = 25 };
            splitMain.Panel2.Controls.Add(lblHDN);

            layoutBottom = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1
            };
            layoutBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            layoutBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // Cột chứa nút bấm
            layoutBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));

            // Layout Hóa đơn bên trái
            Panel pnlHDNLeft = new Panel { Dock = DockStyle.Fill };
            Label lblTitleHD = new Label { Text = "Hóa Đơn Nhập Kho", Dock = DockStyle.Top };
            dgvHoaDonNhap = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = Color.White, AllowUserToAddRows = false };
            dgvHoaDonNhap.Columns.Add("MaHDN", "Mã HDN");
            dgvHoaDonNhap.Columns.Add("NgayNhap", "Ngày Nhập");
            dgvHoaDonNhap.Columns.Add("NCC", "Nhà Cung Cấp");
            dgvHoaDonNhap.Columns.Add("TongTien", "Tổng Tiền");
            dgvHoaDonNhap.Columns.Add("NguoiNhap", "Người Nhập");
            pnlHDNLeft.Controls.Add(dgvHoaDonNhap);
            pnlHDNLeft.Controls.Add(lblTitleHD);

            // Layout Nút bấm ở giữa
            FlowLayoutPanel pnlBtnHD = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(15, 30, 0, 0) };
            btnThemHD = new Button { Text = "Thêm hóa đơn nhập", Width = 120, Height = 35, Margin = new Padding(0, 0, 0, 10) };
            btnSuaHD = new Button { Text = "Sửa hóa đơn", Width = 120, Height = 35, Margin = new Padding(0, 0, 0, 10) };
            btnXoaHD = new Button { Text = "Xóa hóa đơn", Width = 120, Height = 35 };
            pnlBtnHD.Controls.AddRange(new Control[] { btnThemHD, btnSuaHD, btnXoaHD });

            // Layout Chi tiết hóa đơn bên phải
            Panel pnlHDNRight = new Panel { Dock = DockStyle.Fill };
            Label lblTitleCT = new Label { Text = "Chi Tiết Hóa Đơn Nhập", Dock = DockStyle.Top };
            dgvChiTietHD = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = Color.White, AllowUserToAddRows = false };
            dgvChiTietHD.Columns.Add("MaSP", "Mã SP");
            dgvChiTietHD.Columns.Add("TenSP", "Tên Sản Phẩm");
            dgvChiTietHD.Columns.Add("SL", "Số Lượng");
            dgvChiTietHD.Columns.Add("DonGia", "Đơn Giá");
            pnlHDNRight.Controls.Add(dgvChiTietHD);
            pnlHDNRight.Controls.Add(lblTitleCT);

            // Gắn vào TableLayoutPanel
            layoutBottom.Controls.Add(pnlHDNLeft, 0, 0);
            layoutBottom.Controls.Add(pnlBtnHD, 1, 0);
            layoutBottom.Controls.Add(pnlHDNRight, 2, 0);

            // Đưa Layout dưới vào Panel2
            Panel pnlBottomContent = new Panel { Dock = DockStyle.Fill };
            pnlBottomContent.Controls.Add(layoutBottom);
            splitMain.Panel2.Controls.Add(pnlBottomContent);
            pnlBottomContent.BringToFront();
        }
    }
}
