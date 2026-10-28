namespace SupermarketManagement.Views.Admin.QuanLyKhoHang
{
    partial class IndexQuanLyKhoHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvStyleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyleRow = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyleAltRow = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyleHeader2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyleRow2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyleAltRow2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyleHeader3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyleRow3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyleAltRow3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            
            // Tab 1: Lập phiếu nhập
            this.tabNhapHang = new System.Windows.Forms.TabPage();
            this.tlpNhapHang = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeftNhap = new System.Windows.Forms.Panel();
            this.grpThongTinPhieu = new System.Windows.Forms.GroupBox();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.btnThemNCC = new System.Windows.Forms.Button();
            this.lblNguoiNhap = new System.Windows.Forms.Label();
            this.cboNguoiNhap = new System.Windows.Forms.ComboBox();
            this.grpChonHang = new System.Windows.Forms.GroupBox();
            this.lblMatHang = new System.Windows.Forms.Label();
            this.cboMatHang = new System.Windows.Forms.ComboBox();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.cboDonViTinh = new System.Windows.Forms.ComboBox();
            this.lblSoLuongNhap = new System.Windows.Forms.Label();
            this.nudSoLuongNhap = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongQuyDoi = new System.Windows.Forms.Label();
            this.nudSoLuongQuyDoi = new System.Windows.Forms.NumericUpDown();
            this.pnlQuyDoi = new System.Windows.Forms.Panel();
            this.lblQuyDoiPreview = new System.Windows.Forms.Label();
            this.lblDonGiaNhapItem = new System.Windows.Forms.Label();
            this.txtDonGiaNhapItem = new System.Windows.Forms.TextBox();
            this.lblThanhTienItem = new System.Windows.Forms.Label();
            this.txtThanhTienItem = new System.Windows.Forms.TextBox();
            this.chkCoHSD = new System.Windows.Forms.CheckBox();
            this.lblNSX = new System.Windows.Forms.Label();
            this.dtpNSX = new System.Windows.Forms.DateTimePicker();
            this.lblHSD = new System.Windows.Forms.Label();
            this.dtpHSD = new System.Windows.Forms.DateTimePicker();
            this.btnThemChiTiet = new System.Windows.Forms.Button();
            this.btnXoaChiTiet = new System.Windows.Forms.Button();
            this.btnLamMoiChiTiet = new System.Windows.Forms.Button();
            this.pnlRightNhap = new System.Windows.Forms.Panel();
            this.grpDanhSachHang = new System.Windows.Forms.GroupBox();
            this.dgvChiTietNhap = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongQuyDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongQuyDoiKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTongKetNhap = new System.Windows.Forms.Panel();
            this.lblTongSoMatHang = new System.Windows.Forms.Label();
            this.lblTongSLQuyDoiKho = new System.Windows.Forms.Label();
            this.lblTongTienHD = new System.Windows.Forms.Label();
            this.btnLuuHD = new System.Windows.Forms.Button();
            this.btnLamMoiHD = new System.Windows.Forms.Button();
            this.btnHuyHD = new System.Windows.Forms.Button();

            // Tab 2: Lịch sử phiếu nhập
            this.tabLichSu = new System.Windows.Forms.TabPage();
            this.pnlTopLichSu = new System.Windows.Forms.Panel();
            this.lblTimKiemPNH = new System.Windows.Forms.Label();
            this.txtTimKiemPNH = new System.Windows.Forms.TextBox();
            this.lblLocNCC = new System.Windows.Forms.Label();
            this.cboLocNCC = new System.Windows.Forms.ComboBox();
            this.btnLamMoiLichSu = new System.Windows.Forms.Button();
            this.btnXoaHD = new System.Windows.Forms.Button();
            this.tlpLichSu = new System.Windows.Forms.TableLayoutPanel();
            this.grpDSHoaDon = new System.Windows.Forms.GroupBox();
            this.dgvHoaDonNhap = new System.Windows.Forms.DataGridView();
            this.grpChiTietPhieuCu = new System.Windows.Forms.GroupBox();
            this.dgvChiTietPhieuCu = new System.Windows.Forms.DataGridView();

            // Tab 3: Quản lý hàng hóa
            this.tabHangHoa = new System.Windows.Forms.TabPage();
            this.grpHangHoa = new System.Windows.Forms.GroupBox();
            this.lblMaHangHoa = new System.Windows.Forms.Label();
            this.txtMaHangHoa = new System.Windows.Forms.TextBox();
            this.lblTenHangHoa = new System.Windows.Forms.Label();
            this.txtTenHangHoa = new System.Windows.Forms.TextBox();
            this.lblDanhMucHH = new System.Windows.Forms.Label();
            this.cboDanhMucHH = new System.Windows.Forms.ComboBox();
            this.BtnMoQLDM = new System.Windows.Forms.Button();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblDonGiaNhap = new System.Windows.Forms.Label();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.lblDonGiaBan = new System.Windows.Forms.Label();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.lblMoTaHH = new System.Windows.Forms.Label();
            this.txtMoTaHH = new System.Windows.Forms.TextBox();
            this.btnThemHH = new System.Windows.Forms.Button();
            this.btnSuaHH = new System.Windows.Forms.Button();
            this.btnXoaHH = new System.Windows.Forms.Button();
            this.btnLamMoiHH = new System.Windows.Forms.Button();
            this.lblTimKiemHH = new System.Windows.Forms.Label();
            this.txtTimKiemHH = new System.Windows.Forms.TextBox();
            this.lblLocDanhMuc = new System.Windows.Forms.Label();
            this.cboLocDanhMuc = new System.Windows.Forms.ComboBox();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();

            // Group quản lý danh mục (modal / ẩn)
            this.grpDanhMuc = new System.Windows.Forms.GroupBox();
            this.lblMaDanhMuc = new System.Windows.Forms.Label();
            this.txtMaDanhMuc = new System.Windows.Forms.TextBox();
            this.lblTenDanhMuc = new System.Windows.Forms.Label();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.lblMoTaDM = new System.Windows.Forms.Label();
            this.txtMoTaDM = new System.Windows.Forms.TextBox();
            this.btnThemDM = new System.Windows.Forms.Button();
            this.btnSuaDM = new System.Windows.Forms.Button();
            this.btnXoaDM = new System.Windows.Forms.Button();
            this.btnLamMoiDM = new System.Windows.Forms.Button();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabNhapHang.SuspendLayout();
            this.tlpNhapHang.SuspendLayout();
            this.pnlLeftNhap.SuspendLayout();
            this.grpThongTinPhieu.SuspendLayout();
            this.grpChonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongQuyDoi)).BeginInit();
            this.pnlQuyDoi.SuspendLayout();
            this.pnlRightNhap.SuspendLayout();
            this.grpDanhSachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).BeginInit();
            this.pnlTongKetNhap.SuspendLayout();
            this.tabLichSu.SuspendLayout();
            this.pnlTopLichSu.SuspendLayout();
            this.tlpLichSu.SuspendLayout();
            this.grpDSHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).BeginInit();
            this.grpChiTietPhieuCu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuCu)).BeginInit();
            this.tabHangHoa.SuspendLayout();
            this.grpHangHoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.grpDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 52);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblHeaderTitle.Size = new System.Drawing.Size(1280, 52);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "QUẢN LÝ KHO HÀNG & NHẬP HÀNG TỪ NHÀ CUNG CẤP";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabNhapHang);
            this.tabMain.Controls.Add(this.tabLichSu);
            this.tabMain.Controls.Add(this.tabHangHoa);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabMain.ItemSize = new System.Drawing.Size(220, 35);
            this.tabMain.Location = new System.Drawing.Point(0, 52);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(15, 4);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1280, 668);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 1;

            // ==========================================
            // TAB 1: LẬP PHIẾU NHẬP HÀNG
            // ==========================================
            this.tabNhapHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.tabNhapHang.Controls.Add(this.tlpNhapHang);
            this.tabNhapHang.Location = new System.Drawing.Point(4, 39);
            this.tabNhapHang.Name = "tabNhapHang";
            this.tabNhapHang.Padding = new System.Windows.Forms.Padding(8);
            this.tabNhapHang.Size = new System.Drawing.Size(1272, 625);
            this.tabNhapHang.TabIndex = 0;
            this.tabNhapHang.Text = "📦 Lập Phiếu Nhập Hàng";

            // tlpNhapHang
            this.tlpNhapHang.ColumnCount = 2;
            this.tlpNhapHang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 455F));
            this.tlpNhapHang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNhapHang.Controls.Add(this.pnlLeftNhap, 0, 0);
            this.tlpNhapHang.Controls.Add(this.pnlRightNhap, 1, 0);
            this.tlpNhapHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNhapHang.Location = new System.Drawing.Point(8, 8);
            this.tlpNhapHang.Name = "tlpNhapHang";
            this.tlpNhapHang.RowCount = 1;
            this.tlpNhapHang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNhapHang.Size = new System.Drawing.Size(1256, 609);
            this.tlpNhapHang.TabIndex = 0;

            // pnlLeftNhap
            this.pnlLeftNhap.AutoScroll = true;
            this.pnlLeftNhap.Controls.Add(this.grpChonHang);
            this.pnlLeftNhap.Controls.Add(this.grpThongTinPhieu);
            this.pnlLeftNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftNhap.Location = new System.Drawing.Point(3, 3);
            this.pnlLeftNhap.Name = "pnlLeftNhap";
            this.pnlLeftNhap.Size = new System.Drawing.Size(449, 603);
            this.pnlLeftNhap.TabIndex = 0;

            // grpThongTinPhieu
            this.grpThongTinPhieu.BackColor = System.Drawing.Color.White;
            this.grpThongTinPhieu.Controls.Add(this.lblMaHoaDon);
            this.grpThongTinPhieu.Controls.Add(this.txtMaHoaDon);
            this.grpThongTinPhieu.Controls.Add(this.lblNgayNhap);
            this.grpThongTinPhieu.Controls.Add(this.dtpNgayNhap);
            this.grpThongTinPhieu.Controls.Add(this.lblNhaCungCap);
            this.grpThongTinPhieu.Controls.Add(this.cboNhaCungCap);
            this.grpThongTinPhieu.Controls.Add(this.btnThemNCC);
            this.grpThongTinPhieu.Controls.Add(this.lblNguoiNhap);
            this.grpThongTinPhieu.Controls.Add(this.cboNguoiNhap);
            this.grpThongTinPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTinPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpThongTinPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpThongTinPhieu.Location = new System.Drawing.Point(0, 0);
            this.grpThongTinPhieu.Name = "grpThongTinPhieu";
            this.grpThongTinPhieu.Size = new System.Drawing.Size(449, 168);
            this.grpThongTinPhieu.TabIndex = 0;
            this.grpThongTinPhieu.TabStop = false;
            this.grpThongTinPhieu.Text = "1. THÔNG TIN PHIẾU NHẬP & NHÀ CUNG CẤP";

            // lblMaHoaDon & txtMaHoaDon
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaHoaDon.Location = new System.Drawing.Point(12, 32);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(73, 20);
            this.lblMaHoaDon.TabIndex = 0;
            this.lblMaHoaDon.Text = "Mã Phiếu:";
            this.txtMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtMaHoaDon.Location = new System.Drawing.Point(100, 28);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.ReadOnly = true;
            this.txtMaHoaDon.Size = new System.Drawing.Size(115, 27);
            this.txtMaHoaDon.TabIndex = 1;

            // lblNgayNhap & dtpNgayNhap
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayNhap.Location = new System.Drawing.Point(225, 32);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(47, 20);
            this.lblNgayNhap.TabIndex = 2;
            this.lblNgayNhap.Text = "Ngày:";
            this.dtpNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(278, 28);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(155, 27);
            this.dtpNgayNhap.TabIndex = 3;

            // lblNhaCungCap & cboNhaCungCap & btnThemNCC
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNhaCungCap.Location = new System.Drawing.Point(12, 75);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(70, 20);
            this.lblNhaCungCap.TabIndex = 4;
            this.lblNhaCungCap.Text = "Nhà C/C:";
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(100, 71);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(225, 28);
            this.cboNhaCungCap.TabIndex = 5;

            this.btnThemNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(135)))), ((int)(((byte)(55)))));
            this.btnThemNCC.FlatAppearance.BorderSize = 0;
            this.btnThemNCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNCC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemNCC.ForeColor = System.Drawing.Color.White;
            this.btnThemNCC.Location = new System.Drawing.Point(331, 70);
            this.btnThemNCC.Name = "btnThemNCC";
            this.btnThemNCC.Size = new System.Drawing.Size(102, 30);
            this.btnThemNCC.TabIndex = 6;
            this.btnThemNCC.Text = "+ Thêm NCC";
            this.btnThemNCC.UseVisualStyleBackColor = false;
            this.btnThemNCC.Click += new System.EventHandler(this.btnThemNCC_Click);

            // lblNguoiNhap & cboNguoiNhap
            this.lblNguoiNhap.AutoSize = true;
            this.lblNguoiNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNguoiNhap.Location = new System.Drawing.Point(12, 120);
            this.lblNguoiNhap.Name = "lblNguoiNhap";
            this.lblNguoiNhap.Size = new System.Drawing.Size(82, 20);
            this.lblNguoiNhap.TabIndex = 7;
            this.lblNguoiNhap.Text = "Thủ Kho:";
            this.cboNguoiNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguoiNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNguoiNhap.FormattingEnabled = true;
            this.cboNguoiNhap.Location = new System.Drawing.Point(100, 116);
            this.cboNguoiNhap.Name = "cboNguoiNhap";
            this.cboNguoiNhap.Size = new System.Drawing.Size(333, 28);
            this.cboNguoiNhap.TabIndex = 8;

            // grpChonHang
            this.grpChonHang.BackColor = System.Drawing.Color.White;
            this.grpChonHang.Controls.Add(this.lblMatHang);
            this.grpChonHang.Controls.Add(this.cboMatHang);
            this.grpChonHang.Controls.Add(this.lblDonViTinh);
            this.grpChonHang.Controls.Add(this.cboDonViTinh);
            this.grpChonHang.Controls.Add(this.lblSoLuongNhap);
            this.grpChonHang.Controls.Add(this.nudSoLuongNhap);
            this.grpChonHang.Controls.Add(this.lblSoLuongQuyDoi);
            this.grpChonHang.Controls.Add(this.nudSoLuongQuyDoi);
            this.grpChonHang.Controls.Add(this.pnlQuyDoi);
            this.grpChonHang.Controls.Add(this.lblDonGiaNhapItem);
            this.grpChonHang.Controls.Add(this.txtDonGiaNhapItem);
            this.grpChonHang.Controls.Add(this.lblThanhTienItem);
            this.grpChonHang.Controls.Add(this.txtThanhTienItem);
            this.grpChonHang.Controls.Add(this.chkCoHSD);
            this.grpChonHang.Controls.Add(this.lblNSX);
            this.grpChonHang.Controls.Add(this.dtpNSX);
            this.grpChonHang.Controls.Add(this.lblHSD);
            this.grpChonHang.Controls.Add(this.dtpHSD);
            this.grpChonHang.Controls.Add(this.btnThemChiTiet);
            this.grpChonHang.Controls.Add(this.btnXoaChiTiet);
            this.grpChonHang.Controls.Add(this.btnLamMoiChiTiet);
            this.grpChonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChonHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpChonHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpChonHang.Location = new System.Drawing.Point(0, 168);
            this.grpChonHang.Name = "grpChonHang";
            this.grpChonHang.Size = new System.Drawing.Size(449, 435);
            this.grpChonHang.TabIndex = 1;
            this.grpChonHang.TabStop = false;
            this.grpChonHang.Text = "2. CHỌN MẶT HÀNG & QUY ĐỔI ĐƠN VỊ";

            // Mặt hàng
            this.lblMatHang.AutoSize = true;
            this.lblMatHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMatHang.Location = new System.Drawing.Point(12, 30);
            this.lblMatHang.Name = "lblMatHang";
            this.lblMatHang.Size = new System.Drawing.Size(78, 20);
            this.lblMatHang.TabIndex = 0;
            this.lblMatHang.Text = "Sản Phẩm:";
            this.cboMatHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMatHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMatHang.FormattingEnabled = true;
            this.cboMatHang.Location = new System.Drawing.Point(100, 26);
            this.cboMatHang.Name = "cboMatHang";
            this.cboMatHang.Size = new System.Drawing.Size(333, 28);
            this.cboMatHang.TabIndex = 1;
            this.cboMatHang.SelectedIndexChanged += new System.EventHandler(this.cboMatHang_SelectedIndexChanged);

            // ĐVT & Hệ số quy đổi
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonViTinh.Location = new System.Drawing.Point(12, 70);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(79, 20);
            this.lblDonViTinh.TabIndex = 2;
            this.lblDonViTinh.Text = "Đ/Vị Nhập:";
            this.cboDonViTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDonViTinh.FormattingEnabled = true;
            this.cboDonViTinh.Location = new System.Drawing.Point(100, 66);
            this.cboDonViTinh.Name = "cboDonViTinh";
            this.cboDonViTinh.Size = new System.Drawing.Size(120, 28);
            this.cboDonViTinh.TabIndex = 3;
            this.cboDonViTinh.SelectedIndexChanged += new System.EventHandler(this.cboDonViTinh_SelectedIndexChanged);

            this.lblSoLuongQuyDoi.AutoSize = true;
            this.lblSoLuongQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuongQuyDoi.Location = new System.Drawing.Point(232, 70);
            this.lblSoLuongQuyDoi.Name = "lblSoLuongQuyDoi";
            this.lblSoLuongQuyDoi.Size = new System.Drawing.Size(65, 20);
            this.lblSoLuongQuyDoi.TabIndex = 4;
            this.lblSoLuongQuyDoi.Text = "Quy Đổi:";
            this.nudSoLuongQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudSoLuongQuyDoi.Location = new System.Drawing.Point(305, 66);
            this.nudSoLuongQuyDoi.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudSoLuongQuyDoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuongQuyDoi.Name = "nudSoLuongQuyDoi";
            this.nudSoLuongQuyDoi.Size = new System.Drawing.Size(128, 27);
            this.nudSoLuongQuyDoi.TabIndex = 5;
            this.nudSoLuongQuyDoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuongQuyDoi.ValueChanged += new System.EventHandler(this.nudSoLuongQuyDoi_ValueChanged);

            // Số lượng nhập
            this.lblSoLuongNhap.AutoSize = true;
            this.lblSoLuongNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuongNhap.Location = new System.Drawing.Point(12, 110);
            this.lblSoLuongNhap.Name = "lblSoLuongNhap";
            this.lblSoLuongNhap.Size = new System.Drawing.Size(69, 20);
            this.lblSoLuongNhap.TabIndex = 6;
            this.lblSoLuongNhap.Text = "SL Nhập:";
            this.nudSoLuongNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudSoLuongNhap.Location = new System.Drawing.Point(100, 106);
            this.nudSoLuongNhap.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudSoLuongNhap.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuongNhap.Name = "nudSoLuongNhap";
            this.nudSoLuongNhap.Size = new System.Drawing.Size(120, 27);
            this.nudSoLuongNhap.TabIndex = 7;
            this.nudSoLuongNhap.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuongNhap.ValueChanged += new System.EventHandler(this.nudSoLuongNhap_ValueChanged);

            // Panel hiển thị quy đổi trực quan
            this.pnlQuyDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlQuyDoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuyDoi.Controls.Add(this.lblQuyDoiPreview);
            this.pnlQuyDoi.Location = new System.Drawing.Point(16, 145);
            this.pnlQuyDoi.Name = "pnlQuyDoi";
            this.pnlQuyDoi.Size = new System.Drawing.Size(417, 34);
            this.pnlQuyDoi.TabIndex = 8;

            this.lblQuyDoiPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuyDoiPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuyDoiPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblQuyDoiPreview.Location = new System.Drawing.Point(0, 0);
            this.lblQuyDoiPreview.Name = "lblQuyDoiPreview";
            this.lblQuyDoiPreview.Size = new System.Drawing.Size(415, 32);
            this.lblQuyDoiPreview.TabIndex = 0;
            this.lblQuyDoiPreview.Text = "👉 Quy đổi vào kho: 1 x 1 = 1 (Cái)";
            this.lblQuyDoiPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Đơn giá nhập & Thành tiền
            this.lblDonGiaNhapItem.AutoSize = true;
            this.lblDonGiaNhapItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGiaNhapItem.Location = new System.Drawing.Point(12, 195);
            this.lblDonGiaNhapItem.Name = "lblDonGiaNhapItem";
            this.lblDonGiaNhapItem.Size = new System.Drawing.Size(73, 20);
            this.lblDonGiaNhapItem.TabIndex = 9;
            this.lblDonGiaNhapItem.Text = "Giá Nhập:";
            this.txtDonGiaNhapItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDonGiaNhapItem.Location = new System.Drawing.Point(100, 191);
            this.txtDonGiaNhapItem.Name = "txtDonGiaNhapItem";
            this.txtDonGiaNhapItem.Size = new System.Drawing.Size(120, 27);
            this.txtDonGiaNhapItem.TabIndex = 10;
            this.txtDonGiaNhapItem.Text = "0";
            this.txtDonGiaNhapItem.TextChanged += new System.EventHandler(this.txtDonGiaNhapItem_TextChanged);

            this.lblThanhTienItem.AutoSize = true;
            this.lblThanhTienItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThanhTienItem.Location = new System.Drawing.Point(232, 195);
            this.lblThanhTienItem.Name = "lblThanhTienItem";
            this.lblThanhTienItem.Size = new System.Drawing.Size(76, 20);
            this.lblThanhTienItem.TabIndex = 11;
            this.lblThanhTienItem.Text = "Tiền Món:";
            this.txtThanhTienItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.txtThanhTienItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtThanhTienItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtThanhTienItem.Location = new System.Drawing.Point(308, 191);
            this.txtThanhTienItem.Name = "txtThanhTienItem";
            this.txtThanhTienItem.ReadOnly = true;
            this.txtThanhTienItem.Size = new System.Drawing.Size(125, 27);
            this.txtThanhTienItem.TabIndex = 12;
            this.txtThanhTienItem.Text = "0";

            // Hạn sử dụng
            this.chkCoHSD.AutoSize = true;
            this.chkCoHSD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkCoHSD.Location = new System.Drawing.Point(16, 235);
            this.chkCoHSD.Name = "chkCoHSD";
            this.chkCoHSD.Size = new System.Drawing.Size(193, 24);
            this.chkCoHSD.TabIndex = 13;
            this.chkCoHSD.Text = "Theo dõi Hạn Dùng / NSX";
            this.chkCoHSD.UseVisualStyleBackColor = true;
            this.chkCoHSD.CheckedChanged += new System.EventHandler(this.chkCoHSD_CheckedChanged);

            this.lblNSX.AutoSize = true;
            this.lblNSX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNSX.Location = new System.Drawing.Point(12, 270);
            this.lblNSX.Name = "lblNSX";
            this.lblNSX.Size = new System.Drawing.Size(42, 20);
            this.lblNSX.TabIndex = 14;
            this.lblNSX.Text = "NSX:";
            this.dtpNSX.Enabled = false;
            this.dtpNSX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNSX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNSX.Location = new System.Drawing.Point(100, 266);
            this.dtpNSX.Name = "dtpNSX";
            this.dtpNSX.Size = new System.Drawing.Size(120, 27);
            this.dtpNSX.TabIndex = 15;

            this.lblHSD.AutoSize = true;
            this.lblHSD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHSD.Location = new System.Drawing.Point(232, 270);
            this.lblHSD.Name = "lblHSD";
            this.lblHSD.Size = new System.Drawing.Size(43, 20);
            this.lblHSD.TabIndex = 16;
            this.lblHSD.Text = "HSD:";
            this.dtpHSD.Enabled = false;
            this.dtpHSD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHSD.Location = new System.Drawing.Point(308, 266);
            this.dtpHSD.Name = "dtpHSD";
            this.dtpHSD.Size = new System.Drawing.Size(125, 27);
            this.dtpHSD.TabIndex = 17;

            // Nút thao tác chi tiết
            this.btnThemChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(135)))), ((int)(((byte)(55)))));
            this.btnThemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnThemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnThemChiTiet.Location = new System.Drawing.Point(16, 315);
            this.btnThemChiTiet.Name = "btnThemChiTiet";
            this.btnThemChiTiet.Size = new System.Drawing.Size(140, 36);
            this.btnThemChiTiet.TabIndex = 18;
            this.btnThemChiTiet.Text = "+ Thêm Vào Phiếu";
            this.btnThemChiTiet.UseVisualStyleBackColor = false;
            this.btnThemChiTiet.Click += new System.EventHandler(this.btnThemChiTiet_Click);

            this.btnXoaChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXoaChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXoaChiTiet.Location = new System.Drawing.Point(165, 315);
            this.btnXoaChiTiet.Name = "btnXoaChiTiet";
            this.btnXoaChiTiet.Size = new System.Drawing.Size(130, 36);
            this.btnXoaChiTiet.TabIndex = 19;
            this.btnXoaChiTiet.Text = "Xóa Mặt Hàng";
            this.btnXoaChiTiet.UseVisualStyleBackColor = false;
            this.btnXoaChiTiet.Click += new System.EventHandler(this.btnXoaChiTiet_Click);

            this.btnLamMoiChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnLamMoiChiTiet.FlatAppearance.BorderSize = 0;
            this.btnLamMoiChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLamMoiChiTiet.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoiChiTiet.Location = new System.Drawing.Point(305, 315);
            this.btnLamMoiChiTiet.Name = "btnLamMoiChiTiet";
            this.btnLamMoiChiTiet.Size = new System.Drawing.Size(128, 36);
            this.btnLamMoiChiTiet.TabIndex = 20;
            this.btnLamMoiChiTiet.Text = "Làm Mới Ô";
            this.btnLamMoiChiTiet.UseVisualStyleBackColor = false;
            this.btnLamMoiChiTiet.Click += new System.EventHandler(this.btnLamMoiChiTiet_Click);

            // pnlRightNhap
            this.pnlRightNhap.Controls.Add(this.grpDanhSachHang);
            this.pnlRightNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightNhap.Location = new System.Drawing.Point(458, 3);
            this.pnlRightNhap.Name = "pnlRightNhap";
            this.pnlRightNhap.Size = new System.Drawing.Size(795, 603);
            this.pnlRightNhap.TabIndex = 1;

            // grpDanhSachHang
            this.grpDanhSachHang.BackColor = System.Drawing.Color.White;
            this.grpDanhSachHang.Controls.Add(this.dgvChiTietNhap);
            this.grpDanhSachHang.Controls.Add(this.pnlTongKetNhap);
            this.grpDanhSachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDanhSachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpDanhSachHang.Location = new System.Drawing.Point(0, 0);
            this.grpDanhSachHang.Name = "grpDanhSachHang";
            this.grpDanhSachHang.Size = new System.Drawing.Size(795, 603);
            this.grpDanhSachHang.TabIndex = 0;
            this.grpDanhSachHang.TabStop = false;
            this.grpDanhSachHang.Text = "3. DANH SÁCH MẶT HÀNG TRONG PHIẾU NHẬP (CHI TIẾT PHIẾU)";

            // dgvChiTietNhap
            this.dgvChiTietNhap.AllowUserToAddRows = false;
            this.dgvChiTietNhap.AllowUserToDeleteRows = false;
            this.dgvChiTietNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietNhap.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            dgvStyleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            dgvStyleHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvStyleHeader.ForeColor = System.Drawing.Color.White;
            dgvStyleHeader.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dgvStyleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            dgvStyleHeader.SelectionForeColor = System.Drawing.Color.White;
            dgvStyleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietNhap.ColumnHeadersDefaultCellStyle = dgvStyleHeader;
            this.dgvChiTietNhap.ColumnHeadersHeight = 35;
            this.dgvChiTietNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvStyleRow.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyleRow.BackColor = System.Drawing.Color.White;
            dgvStyleRow.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvStyleRow.ForeColor = System.Drawing.Color.Black;
            dgvStyleRow.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dgvStyleRow.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvChiTietNhap.DefaultCellStyle = dgvStyleRow;

            dgvStyleAltRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvChiTietNhap.AlternatingRowsDefaultCellStyle = dgvStyleAltRow;

            this.dgvChiTietNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colSTT,
                this.colMaSP,
                this.colTenSP,
                this.colMaDVT,
                this.colTenDV,
                this.colSoLuongNhap,
                this.colSoLuongQuyDoi,
                this.colSoLuongQuyDoiKho,
                this.colDonGiaNhap,
                this.colThanhTien,
                this.colNSX,
                this.colHSD
            });

            this.dgvChiTietNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietNhap.EnableHeadersVisualStyles = false;
            this.dgvChiTietNhap.Location = new System.Drawing.Point(3, 24);
            this.dgvChiTietNhap.MultiSelect = false;
            this.dgvChiTietNhap.Name = "dgvChiTietNhap";
            this.dgvChiTietNhap.ReadOnly = true;
            this.dgvChiTietNhap.RowHeadersVisible = false;
            this.dgvChiTietNhap.RowTemplate.Height = 28;
            this.dgvChiTietNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietNhap.Size = new System.Drawing.Size(789, 480);
            this.dgvChiTietNhap.TabIndex = 0;
            this.dgvChiTietNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietNhap_CellClick);

            // Cấu hình các cột của dgvChiTietNhap
            this.colSTT.HeaderText = "STT";
            this.colSTT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSTT.Width = 40;
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaSP.Width = 60;
            this.colTenSP.HeaderText = "Tên Hàng Hóa";
            this.colTenSP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTenSP.Width = 160;
            this.colMaDVT.HeaderText = "MaDVT";
            this.colMaDVT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaDVT.Visible = false;
            this.colTenDV.HeaderText = "ĐVT Nhập";
            this.colTenDV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTenDV.Width = 80;
            this.colSoLuongNhap.HeaderText = "SL Nhập";
            this.colSoLuongNhap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSoLuongNhap.Width = 70;
            this.colSoLuongQuyDoi.HeaderText = "Quy Đổi";
            this.colSoLuongQuyDoi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSoLuongQuyDoi.Width = 65;
            this.colSoLuongQuyDoiKho.HeaderText = "SL Vào Kho";
            this.colSoLuongQuyDoiKho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSoLuongQuyDoiKho.Width = 85;
            this.colDonGiaNhap.HeaderText = "Đơn Giá Nhập";
            this.colDonGiaNhap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDonGiaNhap.Width = 95;
            this.colThanhTien.HeaderText = "Thành Tiền";
            this.colThanhTien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colThanhTien.Width = 105;
            this.colNSX.HeaderText = "NSX";
            this.colNSX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNSX.Width = 80;
            this.colHSD.HeaderText = "HSD";
            this.colHSD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHSD.Width = 80;

            // pnlTongKetNhap
            this.pnlTongKetNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.pnlTongKetNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongKetNhap.Controls.Add(this.lblTongSoMatHang);
            this.pnlTongKetNhap.Controls.Add(this.lblTongSLQuyDoiKho);
            this.pnlTongKetNhap.Controls.Add(this.lblTongTienHD);
            this.pnlTongKetNhap.Controls.Add(this.btnLuuHD);
            this.pnlTongKetNhap.Controls.Add(this.btnLamMoiHD);
            this.pnlTongKetNhap.Controls.Add(this.btnHuyHD);
            this.pnlTongKetNhap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTongKetNhap.Location = new System.Drawing.Point(3, 504);
            this.pnlTongKetNhap.Name = "pnlTongKetNhap";
            this.pnlTongKetNhap.Size = new System.Drawing.Size(789, 96);
            this.pnlTongKetNhap.TabIndex = 1;

            this.lblTongSoMatHang.AutoSize = true;
            this.lblTongSoMatHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTongSoMatHang.Location = new System.Drawing.Point(12, 12);
            this.lblTongSoMatHang.Name = "lblTongSoMatHang";
            this.lblTongSoMatHang.Size = new System.Drawing.Size(146, 21);
            this.lblTongSoMatHang.TabIndex = 0;
            this.lblTongSoMatHang.Text = "Số mặt hàng: 0 món";

            this.lblTongSLQuyDoiKho.AutoSize = true;
            this.lblTongSLQuyDoiKho.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongSLQuyDoiKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTongSLQuyDoiKho.Location = new System.Drawing.Point(12, 38);
            this.lblTongSLQuyDoiKho.Name = "lblTongSLQuyDoiKho";
            this.lblTongSLQuyDoiKho.Size = new System.Drawing.Size(206, 21);
            this.lblTongSLQuyDoiKho.TabIndex = 1;
            this.lblTongSLQuyDoiKho.Text = "Tổng SL quy đổi vào kho: 0";

            this.lblTongTienHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienHD.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTongTienHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongTienHD.Location = new System.Drawing.Point(350, 10);
            this.lblTongTienHD.Name = "lblTongTienHD";
            this.lblTongTienHD.Size = new System.Drawing.Size(425, 32);
            this.lblTongTienHD.TabIndex = 2;
            this.lblTongTienHD.Text = "TỔNG TIỀN: 0 VNĐ";
            this.lblTongTienHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.btnLuuHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(135)))), ((int)(((byte)(55)))));
            this.btnLuuHD.FlatAppearance.BorderSize = 0;
            this.btnLuuHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuHD.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLuuHD.ForeColor = System.Drawing.Color.White;
            this.btnLuuHD.Location = new System.Drawing.Point(585, 48);
            this.btnLuuHD.Name = "btnLuuHD";
            this.btnLuuHD.Size = new System.Drawing.Size(190, 40);
            this.btnLuuHD.TabIndex = 3;
            this.btnLuuHD.Text = "💾 LƯU PHIẾU NHẬP";
            this.btnLuuHD.UseVisualStyleBackColor = false;
            this.btnLuuHD.Click += new System.EventHandler(this.btnLuuHD_Click);

            this.btnLamMoiHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoiHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLamMoiHD.FlatAppearance.BorderSize = 0;
            this.btnLamMoiHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiHD.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiHD.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiHD.Location = new System.Drawing.Point(440, 48);
            this.btnLamMoiHD.Name = "btnLamMoiHD";
            this.btnLamMoiHD.Size = new System.Drawing.Size(135, 40);
            this.btnLamMoiHD.TabIndex = 4;
            this.btnLamMoiHD.Text = "📄 Tạo Phiếu Mới";
            this.btnLamMoiHD.UseVisualStyleBackColor = false;
            this.btnLamMoiHD.Click += new System.EventHandler(this.btnLamMoiHD_Click);

            this.btnHuyHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnHuyHD.FlatAppearance.BorderSize = 0;
            this.btnHuyHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyHD.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHuyHD.ForeColor = System.Drawing.Color.Black;
            this.btnHuyHD.Location = new System.Drawing.Point(325, 48);
            this.btnHuyHD.Name = "btnHuyHD";
            this.btnHuyHD.Size = new System.Drawing.Size(105, 40);
            this.btnHuyHD.TabIndex = 5;
            this.btnHuyHD.Text = "Hủy Phiếu";
            this.btnHuyHD.UseVisualStyleBackColor = false;
            this.btnHuyHD.Click += new System.EventHandler(this.btnHuyHD_Click);

            // ==========================================
            // TAB 2: LỊCH SỬ & DANH SÁCH PHIẾU NHẬP
            // ==========================================
            this.tabLichSu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.tabLichSu.Controls.Add(this.tlpLichSu);
            this.tabLichSu.Controls.Add(this.pnlTopLichSu);
            this.tabLichSu.Location = new System.Drawing.Point(4, 39);
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.Padding = new System.Windows.Forms.Padding(8);
            this.tabLichSu.Size = new System.Drawing.Size(1272, 625);
            this.tabLichSu.TabIndex = 1;
            this.tabLichSu.Text = "📋 Danh Sách & Lịch Sử Phiếu Nhập";

            // pnlTopLichSu
            this.pnlTopLichSu.BackColor = System.Drawing.Color.White;
            this.pnlTopLichSu.Controls.Add(this.lblTimKiemPNH);
            this.pnlTopLichSu.Controls.Add(this.txtTimKiemPNH);
            this.pnlTopLichSu.Controls.Add(this.lblLocNCC);
            this.pnlTopLichSu.Controls.Add(this.cboLocNCC);
            this.pnlTopLichSu.Controls.Add(this.btnLamMoiLichSu);
            this.pnlTopLichSu.Controls.Add(this.btnXoaHD);
            this.pnlTopLichSu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopLichSu.Location = new System.Drawing.Point(8, 8);
            this.pnlTopLichSu.Name = "pnlTopLichSu";
            this.pnlTopLichSu.Size = new System.Drawing.Size(1256, 48);
            this.pnlTopLichSu.TabIndex = 0;

            this.lblTimKiemPNH.AutoSize = true;
            this.lblTimKiemPNH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiemPNH.Location = new System.Drawing.Point(12, 14);
            this.lblTimKiemPNH.Name = "lblTimKiemPNH";
            this.lblTimKiemPNH.Size = new System.Drawing.Size(117, 20);
            this.lblTimKiemPNH.TabIndex = 0;
            this.lblTimKiemPNH.Text = "Tìm theo Mã PN:";
            this.txtTimKiemPNH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiemPNH.Location = new System.Drawing.Point(135, 10);
            this.txtTimKiemPNH.Name = "txtTimKiemPNH";
            this.txtTimKiemPNH.Size = new System.Drawing.Size(160, 27);
            this.txtTimKiemPNH.TabIndex = 1;
            this.txtTimKiemPNH.TextChanged += new System.EventHandler(this.txtTimKiemPNH_TextChanged);

            this.lblLocNCC.AutoSize = true;
            this.lblLocNCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocNCC.Location = new System.Drawing.Point(315, 14);
            this.lblLocNCC.Name = "lblLocNCC";
            this.lblLocNCC.Size = new System.Drawing.Size(104, 20);
            this.lblLocNCC.TabIndex = 2;
            this.lblLocNCC.Text = "Lọc theo NCC:";
            this.cboLocNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocNCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLocNCC.FormattingEnabled = true;
            this.cboLocNCC.Location = new System.Drawing.Point(425, 10);
            this.cboLocNCC.Name = "cboLocNCC";
            this.cboLocNCC.Size = new System.Drawing.Size(220, 28);
            this.cboLocNCC.TabIndex = 3;
            this.cboLocNCC.SelectedIndexChanged += new System.EventHandler(this.cboLocNCC_SelectedIndexChanged);

            this.btnLamMoiLichSu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLamMoiLichSu.FlatAppearance.BorderSize = 0;
            this.btnLamMoiLichSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiLichSu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiLichSu.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiLichSu.Location = new System.Drawing.Point(660, 9);
            this.btnLamMoiLichSu.Name = "btnLamMoiLichSu";
            this.btnLamMoiLichSu.Size = new System.Drawing.Size(110, 30);
            this.btnLamMoiLichSu.TabIndex = 4;
            this.btnLamMoiLichSu.Text = "Tải Lại";
            this.btnLamMoiLichSu.UseVisualStyleBackColor = false;
            this.btnLamMoiLichSu.Click += new System.EventHandler(this.btnLamMoiLichSu_Click);

            this.btnXoaHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaHD.FlatAppearance.BorderSize = 0;
            this.btnXoaHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaHD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaHD.ForeColor = System.Drawing.Color.White;
            this.btnXoaHD.Location = new System.Drawing.Point(1100, 9);
            this.btnXoaHD.Name = "btnXoaHD";
            this.btnXoaHD.Size = new System.Drawing.Size(140, 30);
            this.btnXoaHD.TabIndex = 5;
            this.btnXoaHD.Text = "Xóa Phiếu Nhập";
            this.btnXoaHD.UseVisualStyleBackColor = false;
            this.btnXoaHD.Click += new System.EventHandler(this.btnXoaHD_Click);

            // tlpLichSu
            this.tlpLichSu.ColumnCount = 1;
            this.tlpLichSu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLichSu.Controls.Add(this.grpDSHoaDon, 0, 0);
            this.tlpLichSu.Controls.Add(this.grpChiTietPhieuCu, 0, 1);
            this.tlpLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLichSu.Location = new System.Drawing.Point(8, 56);
            this.tlpLichSu.Name = "tlpLichSu";
            this.tlpLichSu.RowCount = 2;
            this.tlpLichSu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpLichSu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpLichSu.Size = new System.Drawing.Size(1256, 561);
            this.tlpLichSu.TabIndex = 1;

            // grpDSHoaDon
            this.grpDSHoaDon.BackColor = System.Drawing.Color.White;
            this.grpDSHoaDon.Controls.Add(this.dgvHoaDonNhap);
            this.grpDSHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDSHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDSHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpDSHoaDon.Location = new System.Drawing.Point(3, 3);
            this.grpDSHoaDon.Name = "grpDSHoaDon";
            this.grpDSHoaDon.Size = new System.Drawing.Size(1250, 302);
            this.grpDSHoaDon.TabIndex = 0;
            this.grpDSHoaDon.TabStop = false;
            this.grpDSHoaDon.Text = "DANH SÁCH CÁC PHIẾU NHẬP HÀNG";

            // dgvHoaDonNhap
            this.dgvHoaDonNhap.AllowUserToAddRows = false;
            this.dgvHoaDonNhap.AllowUserToDeleteRows = false;
            this.dgvHoaDonNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDonNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoaDonNhap.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            dgvStyleHeader2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyleHeader2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            dgvStyleHeader2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvStyleHeader2.ForeColor = System.Drawing.Color.White;
            dgvStyleHeader2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            dgvStyleHeader2.SelectionForeColor = System.Drawing.Color.White;
            dgvStyleHeader2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoaDonNhap.ColumnHeadersDefaultCellStyle = dgvStyleHeader2;
            this.dgvHoaDonNhap.ColumnHeadersHeight = 35;
            this.dgvHoaDonNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvStyleRow2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyleRow2.BackColor = System.Drawing.Color.White;
            dgvStyleRow2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvStyleRow2.ForeColor = System.Drawing.Color.Black;
            dgvStyleRow2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dgvStyleRow2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvHoaDonNhap.DefaultCellStyle = dgvStyleRow2;

            dgvStyleAltRow2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvHoaDonNhap.AlternatingRowsDefaultCellStyle = dgvStyleAltRow2;

            this.dgvHoaDonNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDonNhap.EnableHeadersVisualStyles = false;
            this.dgvHoaDonNhap.Location = new System.Drawing.Point(3, 24);
            this.dgvHoaDonNhap.MultiSelect = false;
            this.dgvHoaDonNhap.Name = "dgvHoaDonNhap";
            this.dgvHoaDonNhap.ReadOnly = true;
            this.dgvHoaDonNhap.RowHeadersVisible = false;
            this.dgvHoaDonNhap.RowTemplate.Height = 28;
            this.dgvHoaDonNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDonNhap.Size = new System.Drawing.Size(1244, 275);
            this.dgvHoaDonNhap.TabIndex = 0;
            this.dgvHoaDonNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDonNhap_CellClick);

            // grpChiTietPhieuCu
            this.grpChiTietPhieuCu.BackColor = System.Drawing.Color.White;
            this.grpChiTietPhieuCu.Controls.Add(this.dgvChiTietPhieuCu);
            this.grpChiTietPhieuCu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTietPhieuCu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpChiTietPhieuCu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpChiTietPhieuCu.Location = new System.Drawing.Point(3, 311);
            this.grpChiTietPhieuCu.Name = "grpChiTietPhieuCu";
            this.grpChiTietPhieuCu.Size = new System.Drawing.Size(1250, 247);
            this.grpChiTietPhieuCu.TabIndex = 1;
            this.grpChiTietPhieuCu.TabStop = false;
            this.grpChiTietPhieuCu.Text = "CHI TIẾT MẶT HÀNG CỦA PHIẾU ĐANG CHỌN";

            // dgvChiTietPhieuCu
            this.dgvChiTietPhieuCu.AllowUserToAddRows = false;
            this.dgvChiTietPhieuCu.AllowUserToDeleteRows = false;
            this.dgvChiTietPhieuCu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieuCu.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietPhieuCu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietPhieuCu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            dgvStyleHeader3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyleHeader3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            dgvStyleHeader3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvStyleHeader3.ForeColor = System.Drawing.Color.White;
            dgvStyleHeader3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            dgvStyleHeader3.SelectionForeColor = System.Drawing.Color.White;
            dgvStyleHeader3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietPhieuCu.ColumnHeadersDefaultCellStyle = dgvStyleHeader3;
            this.dgvChiTietPhieuCu.ColumnHeadersHeight = 32;
            this.dgvChiTietPhieuCu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvStyleRow3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyleRow3.BackColor = System.Drawing.Color.White;
            dgvStyleRow3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvStyleRow3.ForeColor = System.Drawing.Color.Black;
            dgvStyleRow3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dgvStyleRow3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvChiTietPhieuCu.DefaultCellStyle = dgvStyleRow3;

            dgvStyleAltRow3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvChiTietPhieuCu.AlternatingRowsDefaultCellStyle = dgvStyleAltRow3;

            this.dgvChiTietPhieuCu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPhieuCu.EnableHeadersVisualStyles = false;
            this.dgvChiTietPhieuCu.Location = new System.Drawing.Point(3, 24);
            this.dgvChiTietPhieuCu.MultiSelect = false;
            this.dgvChiTietPhieuCu.Name = "dgvChiTietPhieuCu";
            this.dgvChiTietPhieuCu.ReadOnly = true;
            this.dgvChiTietPhieuCu.RowHeadersVisible = false;
            this.dgvChiTietPhieuCu.RowTemplate.Height = 28;
            this.dgvChiTietPhieuCu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhieuCu.Size = new System.Drawing.Size(1244, 220);
            this.dgvChiTietPhieuCu.TabIndex = 0;

            // ==========================================
            // TAB 3: QUẢN LÝ KHO HÀNG HÓA
            // ==========================================
            this.tabHangHoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.tabHangHoa.Controls.Add(this.grpHangHoa);
            this.tabHangHoa.Controls.Add(this.grpDanhMuc);
            this.tabHangHoa.Location = new System.Drawing.Point(4, 39);
            this.tabHangHoa.Name = "tabHangHoa";
            this.tabHangHoa.Padding = new System.Windows.Forms.Padding(8);
            this.tabHangHoa.Size = new System.Drawing.Size(1272, 625);
            this.tabHangHoa.TabIndex = 2;
            this.tabHangHoa.Text = "🏷️ Quản Lý Kho Hàng Hóa";

            // grpHangHoa
            this.grpHangHoa.BackColor = System.Drawing.Color.White;
            this.grpHangHoa.Controls.Add(this.lblMaHangHoa);
            this.grpHangHoa.Controls.Add(this.txtMaHangHoa);
            this.grpHangHoa.Controls.Add(this.lblTenHangHoa);
            this.grpHangHoa.Controls.Add(this.txtTenHangHoa);
            this.grpHangHoa.Controls.Add(this.lblDanhMucHH);
            this.grpHangHoa.Controls.Add(this.cboDanhMucHH);
            this.grpHangHoa.Controls.Add(this.BtnMoQLDM);
            this.grpHangHoa.Controls.Add(this.lblSoLuong);
            this.grpHangHoa.Controls.Add(this.txtSoLuong);
            this.grpHangHoa.Controls.Add(this.lblDonGiaNhap);
            this.grpHangHoa.Controls.Add(this.txtDonGiaNhap);
            this.grpHangHoa.Controls.Add(this.lblDonGiaBan);
            this.grpHangHoa.Controls.Add(this.txtDonGiaBan);
            this.grpHangHoa.Controls.Add(this.lblMoTaHH);
            this.grpHangHoa.Controls.Add(this.txtMoTaHH);
            this.grpHangHoa.Controls.Add(this.btnThemHH);
            this.grpHangHoa.Controls.Add(this.btnSuaHH);
            this.grpHangHoa.Controls.Add(this.btnXoaHH);
            this.grpHangHoa.Controls.Add(this.btnLamMoiHH);
            this.grpHangHoa.Controls.Add(this.lblTimKiemHH);
            this.grpHangHoa.Controls.Add(this.txtTimKiemHH);
            this.grpHangHoa.Controls.Add(this.lblLocDanhMuc);
            this.grpHangHoa.Controls.Add(this.cboLocDanhMuc);
            this.grpHangHoa.Controls.Add(this.dgvHangHoa);
            this.grpHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpHangHoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpHangHoa.Location = new System.Drawing.Point(8, 8);
            this.grpHangHoa.Name = "grpHangHoa";
            this.grpHangHoa.Size = new System.Drawing.Size(1256, 609);
            this.grpHangHoa.TabIndex = 0;
            this.grpHangHoa.TabStop = false;
            this.grpHangHoa.Text = "THÔNG TIN HÀNG HÓA VÀ TỒN KHO";

            // Mã HH
            this.lblMaHangHoa.AutoSize = true;
            this.lblMaHangHoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaHangHoa.Location = new System.Drawing.Point(20, 32);
            this.lblMaHangHoa.Name = "lblMaHangHoa";
            this.lblMaHangHoa.Size = new System.Drawing.Size(55, 20);
            this.lblMaHangHoa.TabIndex = 0;
            this.lblMaHangHoa.Text = "Mã SP:";
            this.txtMaHangHoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaHangHoa.Location = new System.Drawing.Point(100, 28);
            this.txtMaHangHoa.Name = "txtMaHangHoa";
            this.txtMaHangHoa.ReadOnly = true;
            this.txtMaHangHoa.Size = new System.Drawing.Size(100, 27);
            this.txtMaHangHoa.TabIndex = 1;

            // Tên HH
            this.lblTenHangHoa.AutoSize = true;
            this.lblTenHangHoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenHangHoa.Location = new System.Drawing.Point(220, 32);
            this.lblTenHangHoa.Name = "lblTenHangHoa";
            this.lblTenHangHoa.Size = new System.Drawing.Size(105, 20);
            this.lblTenHangHoa.TabIndex = 2;
            this.lblTenHangHoa.Text = "Tên Hàng Hóa:";
            this.txtTenHangHoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenHangHoa.Location = new System.Drawing.Point(335, 28);
            this.txtTenHangHoa.Name = "txtTenHangHoa";
            this.txtTenHangHoa.Size = new System.Drawing.Size(260, 27);
            this.txtTenHangHoa.TabIndex = 3;

            // Danh mục & Nút mở QLDM
            this.lblDanhMucHH.AutoSize = true;
            this.lblDanhMucHH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDanhMucHH.Location = new System.Drawing.Point(615, 32);
            this.lblDanhMucHH.Name = "lblDanhMucHH";
            this.lblDanhMucHH.Size = new System.Drawing.Size(79, 20);
            this.lblDanhMucHH.TabIndex = 4;
            this.lblDanhMucHH.Text = "Danh Mục:";
            this.cboDanhMucHH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMucHH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDanhMucHH.FormattingEnabled = true;
            this.cboDanhMucHH.Location = new System.Drawing.Point(705, 28);
            this.cboDanhMucHH.Name = "cboDanhMucHH";
            this.cboDanhMucHH.Size = new System.Drawing.Size(185, 28);
            this.cboDanhMucHH.TabIndex = 5;

            this.BtnMoQLDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(135)))), ((int)(((byte)(55)))));
            this.BtnMoQLDM.FlatAppearance.BorderSize = 0;
            this.BtnMoQLDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMoQLDM.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.BtnMoQLDM.ForeColor = System.Drawing.Color.White;
            this.BtnMoQLDM.Location = new System.Drawing.Point(900, 27);
            this.BtnMoQLDM.Name = "BtnMoQLDM";
            this.BtnMoQLDM.Size = new System.Drawing.Size(95, 30);
            this.BtnMoQLDM.TabIndex = 6;
            this.BtnMoQLDM.Text = "+ Danh Mục";
            this.BtnMoQLDM.UseVisualStyleBackColor = false;
            this.BtnMoQLDM.Click += new System.EventHandler(this.BtnMoQLDM_Click);

            // Số lượng tồn
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuong.Location = new System.Drawing.Point(20, 72);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(65, 20);
            this.lblSoLuong.TabIndex = 7;
            this.lblSoLuong.Text = "Tồn Kho:";
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoLuong.Location = new System.Drawing.Point(100, 68);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 27);
            this.txtSoLuong.TabIndex = 8;

            // Đơn giá nhập
            this.lblDonGiaNhap.AutoSize = true;
            this.lblDonGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGiaNhap.Location = new System.Drawing.Point(220, 72);
            this.lblDonGiaNhap.Name = "lblDonGiaNhap";
            this.lblDonGiaNhap.Size = new System.Drawing.Size(73, 20);
            this.lblDonGiaNhap.TabIndex = 9;
            this.lblDonGiaNhap.Text = "Giá Nhập:";
            this.txtDonGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDonGiaNhap.Location = new System.Drawing.Point(335, 68);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(120, 27);
            this.txtDonGiaNhap.TabIndex = 10;

            // Đơn giá bán
            this.lblDonGiaBan.AutoSize = true;
            this.lblDonGiaBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGiaBan.Location = new System.Drawing.Point(470, 72);
            this.lblDonGiaBan.Name = "lblDonGiaBan";
            this.lblDonGiaBan.Size = new System.Drawing.Size(63, 20);
            this.lblDonGiaBan.TabIndex = 11;
            this.lblDonGiaBan.Text = "Giá Bán:";
            this.txtDonGiaBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDonGiaBan.Location = new System.Drawing.Point(545, 68);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(120, 27);
            this.txtDonGiaBan.TabIndex = 12;

            // Mô tả
            this.lblMoTaHH.AutoSize = true;
            this.lblMoTaHH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMoTaHH.Location = new System.Drawing.Point(680, 72);
            this.lblMoTaHH.Name = "lblMoTaHH";
            this.lblMoTaHH.Size = new System.Drawing.Size(52, 20);
            this.lblMoTaHH.TabIndex = 13;
            this.lblMoTaHH.Text = "Mô Tả:";
            this.txtMoTaHH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMoTaHH.Location = new System.Drawing.Point(740, 68);
            this.txtMoTaHH.Name = "txtMoTaHH";
            this.txtMoTaHH.Size = new System.Drawing.Size(255, 27);
            this.txtMoTaHH.TabIndex = 14;

            // Các nút thao tác hàng hóa
            this.btnThemHH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(135)))), ((int)(((byte)(55)))));
            this.btnThemHH.FlatAppearance.BorderSize = 0;
            this.btnThemHH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemHH.ForeColor = System.Drawing.Color.White;
            this.btnThemHH.Location = new System.Drawing.Point(24, 112);
            this.btnThemHH.Name = "btnThemHH";
            this.btnThemHH.Size = new System.Drawing.Size(95, 32);
            this.btnThemHH.TabIndex = 15;
            this.btnThemHH.Text = "Thêm SP";
            this.btnThemHH.UseVisualStyleBackColor = false;
            this.btnThemHH.Click += new System.EventHandler(this.btnThemHH_Click);

            this.btnSuaHH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.btnSuaHH.FlatAppearance.BorderSize = 0;
            this.btnSuaHH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaHH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaHH.ForeColor = System.Drawing.Color.Black;
            this.btnSuaHH.Location = new System.Drawing.Point(125, 112);
            this.btnSuaHH.Name = "btnSuaHH";
            this.btnSuaHH.Size = new System.Drawing.Size(95, 32);
            this.btnSuaHH.TabIndex = 16;
            this.btnSuaHH.Text = "Sửa SP";
            this.btnSuaHH.UseVisualStyleBackColor = false;
            this.btnSuaHH.Click += new System.EventHandler(this.btnSuaHH_Click);

            this.btnXoaHH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaHH.FlatAppearance.BorderSize = 0;
            this.btnXoaHH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaHH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaHH.ForeColor = System.Drawing.Color.White;
            this.btnXoaHH.Location = new System.Drawing.Point(226, 112);
            this.btnXoaHH.Name = "btnXoaHH";
            this.btnXoaHH.Size = new System.Drawing.Size(95, 32);
            this.btnXoaHH.TabIndex = 17;
            this.btnXoaHH.Text = "Xóa SP";
            this.btnXoaHH.UseVisualStyleBackColor = false;
            this.btnXoaHH.Click += new System.EventHandler(this.btnXoaHH_Click);

            this.btnLamMoiHH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoiHH.FlatAppearance.BorderSize = 0;
            this.btnLamMoiHH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiHH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiHH.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiHH.Location = new System.Drawing.Point(327, 112);
            this.btnLamMoiHH.Name = "btnLamMoiHH";
            this.btnLamMoiHH.Size = new System.Drawing.Size(95, 32);
            this.btnLamMoiHH.TabIndex = 18;
            this.btnLamMoiHH.Text = "Làm Mới";
            this.btnLamMoiHH.UseVisualStyleBackColor = false;
            this.btnLamMoiHH.Click += new System.EventHandler(this.btnLamMoiHH_Click);

            // Tìm kiếm hàng hóa
            this.lblTimKiemHH.AutoSize = true;
            this.lblTimKiemHH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiemHH.Location = new System.Drawing.Point(440, 118);
            this.lblTimKiemHH.Name = "lblTimKiemHH";
            this.lblTimKiemHH.Size = new System.Drawing.Size(73, 20);
            this.lblTimKiemHH.TabIndex = 19;
            this.lblTimKiemHH.Text = "Tìm Kiếm:";
            this.txtTimKiemHH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiemHH.Location = new System.Drawing.Point(515, 114);
            this.txtTimKiemHH.Name = "txtTimKiemHH";
            this.txtTimKiemHH.Size = new System.Drawing.Size(200, 27);
            this.txtTimKiemHH.TabIndex = 20;
            this.txtTimKiemHH.TextChanged += new System.EventHandler(this.txtTimKiemHH_TextChanged);

            // Lọc danh mục hàng hóa
            this.lblLocDanhMuc.AutoSize = true;
            this.lblLocDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocDanhMuc.Location = new System.Drawing.Point(735, 118);
            this.lblLocDanhMuc.Name = "lblLocDanhMuc";
            this.lblLocDanhMuc.Size = new System.Drawing.Size(105, 20);
            this.lblLocDanhMuc.TabIndex = 21;
            this.lblLocDanhMuc.Text = "Lọc Danh Mục:";
            this.cboLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLocDanhMuc.FormattingEnabled = true;
            this.cboLocDanhMuc.Location = new System.Drawing.Point(845, 114);
            this.cboLocDanhMuc.Name = "cboLocDanhMuc";
            this.cboLocDanhMuc.Size = new System.Drawing.Size(190, 28);
            this.cboLocDanhMuc.TabIndex = 22;
            this.cboLocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboLocDanhMuc_SelectedIndexChanged);

            // dgvHangHoa
            this.dgvHangHoa.AllowUserToAddRows = false;
            this.dgvHangHoa.AllowUserToDeleteRows = false;
            this.dgvHangHoa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.BackgroundColor = System.Drawing.Color.White;
            this.dgvHangHoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHangHoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvHangHoa.ColumnHeadersDefaultCellStyle = dgvStyleHeader;
            this.dgvHangHoa.ColumnHeadersHeight = 35;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHangHoa.DefaultCellStyle = dgvStyleRow;
            this.dgvHangHoa.AlternatingRowsDefaultCellStyle = dgvStyleAltRow;

            this.dgvHangHoa.EnableHeadersVisualStyles = false;
            this.dgvHangHoa.Location = new System.Drawing.Point(20, 158);
            this.dgvHangHoa.MultiSelect = false;
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.ReadOnly = true;
            this.dgvHangHoa.RowHeadersVisible = false;
            this.dgvHangHoa.RowTemplate.Height = 28;
            this.dgvHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangHoa.Size = new System.Drawing.Size(1215, 435);
            this.dgvHangHoa.TabIndex = 20;
            this.dgvHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellClick);

            // grpDanhMuc (Quản lý danh mục modal)
            this.grpDanhMuc.BackColor = System.Drawing.Color.White;
            this.grpDanhMuc.Controls.Add(this.dgvDanhMuc);
            this.grpDanhMuc.Controls.Add(this.btnLamMoiDM);
            this.grpDanhMuc.Controls.Add(this.btnXoaDM);
            this.grpDanhMuc.Controls.Add(this.btnSuaDM);
            this.grpDanhMuc.Controls.Add(this.btnThemDM);
            this.grpDanhMuc.Controls.Add(this.txtMoTaDM);
            this.grpDanhMuc.Controls.Add(this.lblMoTaDM);
            this.grpDanhMuc.Controls.Add(this.txtTenDanhMuc);
            this.grpDanhMuc.Controls.Add(this.lblTenDanhMuc);
            this.grpDanhMuc.Controls.Add(this.txtMaDanhMuc);
            this.grpDanhMuc.Controls.Add(this.lblMaDanhMuc);
            this.grpDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDanhMuc.Location = new System.Drawing.Point(50, 50);
            this.grpDanhMuc.Name = "grpDanhMuc";
            this.grpDanhMuc.Size = new System.Drawing.Size(380, 480);
            this.grpDanhMuc.TabIndex = 1;
            this.grpDanhMuc.TabStop = false;
            this.grpDanhMuc.Text = "QUẢN LÝ DANH MỤC";
            this.grpDanhMuc.Visible = false;

            this.lblMaDanhMuc.AutoSize = true;
            this.lblMaDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaDanhMuc.Location = new System.Drawing.Point(15, 35);
            this.lblMaDanhMuc.Name = "lblMaDanhMuc";
            this.lblMaDanhMuc.Size = new System.Drawing.Size(61, 20);
            this.lblMaDanhMuc.TabIndex = 0;
            this.lblMaDanhMuc.Text = "Mã DM:";
            this.txtMaDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaDanhMuc.Location = new System.Drawing.Point(110, 31);
            this.txtMaDanhMuc.Name = "txtMaDanhMuc";
            this.txtMaDanhMuc.ReadOnly = true;
            this.txtMaDanhMuc.Size = new System.Drawing.Size(250, 27);
            this.txtMaDanhMuc.TabIndex = 1;

            this.lblTenDanhMuc.AutoSize = true;
            this.lblTenDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenDanhMuc.Location = new System.Drawing.Point(15, 75);
            this.lblTenDanhMuc.Name = "lblTenDanhMuc";
            this.lblTenDanhMuc.Size = new System.Drawing.Size(63, 20);
            this.lblTenDanhMuc.TabIndex = 2;
            this.lblTenDanhMuc.Text = "Tên DM:";
            this.txtTenDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenDanhMuc.Location = new System.Drawing.Point(110, 71);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(250, 27);
            this.txtTenDanhMuc.TabIndex = 3;

            this.lblMoTaDM.AutoSize = true;
            this.lblMoTaDM.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMoTaDM.Location = new System.Drawing.Point(15, 115);
            this.lblMoTaDM.Name = "lblMoTaDM";
            this.lblMoTaDM.Size = new System.Drawing.Size(52, 20);
            this.lblMoTaDM.TabIndex = 4;
            this.lblMoTaDM.Text = "Mô Tả:";
            this.txtMoTaDM.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMoTaDM.Location = new System.Drawing.Point(110, 111);
            this.txtMoTaDM.Multiline = true;
            this.txtMoTaDM.Name = "txtMoTaDM";
            this.txtMoTaDM.Size = new System.Drawing.Size(250, 50);
            this.txtMoTaDM.TabIndex = 5;

            this.btnThemDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(135)))), ((int)(((byte)(55)))));
            this.btnThemDM.FlatAppearance.BorderSize = 0;
            this.btnThemDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemDM.ForeColor = System.Drawing.Color.White;
            this.btnThemDM.Location = new System.Drawing.Point(15, 175);
            this.btnThemDM.Name = "btnThemDM";
            this.btnThemDM.Size = new System.Drawing.Size(80, 32);
            this.btnThemDM.TabIndex = 6;
            this.btnThemDM.Text = "Thêm";
            this.btnThemDM.UseVisualStyleBackColor = false;
            this.btnThemDM.Click += new System.EventHandler(this.btnThemDM_Click);

            this.btnSuaDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.btnSuaDM.FlatAppearance.BorderSize = 0;
            this.btnSuaDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaDM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaDM.ForeColor = System.Drawing.Color.Black;
            this.btnSuaDM.Location = new System.Drawing.Point(105, 175);
            this.btnSuaDM.Name = "btnSuaDM";
            this.btnSuaDM.Size = new System.Drawing.Size(80, 32);
            this.btnSuaDM.TabIndex = 7;
            this.btnSuaDM.Text = "Sửa";
            this.btnSuaDM.UseVisualStyleBackColor = false;
            this.btnSuaDM.Click += new System.EventHandler(this.btnSuaDM_Click);

            this.btnXoaDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaDM.FlatAppearance.BorderSize = 0;
            this.btnXoaDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaDM.ForeColor = System.Drawing.Color.White;
            this.btnXoaDM.Location = new System.Drawing.Point(195, 175);
            this.btnXoaDM.Name = "btnXoaDM";
            this.btnXoaDM.Size = new System.Drawing.Size(80, 32);
            this.btnXoaDM.TabIndex = 8;
            this.btnXoaDM.Text = "Xóa";
            this.btnXoaDM.UseVisualStyleBackColor = false;
            this.btnXoaDM.Click += new System.EventHandler(this.btnXoaDM_Click);

            this.btnLamMoiDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoiDM.FlatAppearance.BorderSize = 0;
            this.btnLamMoiDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiDM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiDM.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiDM.Location = new System.Drawing.Point(285, 175);
            this.btnLamMoiDM.Name = "btnLamMoiDM";
            this.btnLamMoiDM.Size = new System.Drawing.Size(80, 32);
            this.btnLamMoiDM.TabIndex = 9;
            this.btnLamMoiDM.Text = "Làm Mới";
            this.btnLamMoiDM.UseVisualStyleBackColor = false;
            this.btnLamMoiDM.Click += new System.EventHandler(this.btnLamMoiDM_Click);

            this.dgvDanhMuc.AllowUserToAddRows = false;
            this.dgvDanhMuc.AllowUserToDeleteRows = false;
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhMuc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhMuc.ColumnHeadersDefaultCellStyle = dgvStyleHeader;
            this.dgvDanhMuc.ColumnHeadersHeight = 32;
            this.dgvDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDanhMuc.DefaultCellStyle = dgvStyleRow;
            this.dgvDanhMuc.AlternatingRowsDefaultCellStyle = dgvStyleAltRow;
            this.dgvDanhMuc.EnableHeadersVisualStyles = false;
            this.dgvDanhMuc.Location = new System.Drawing.Point(15, 220);
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.RowTemplate.Height = 28;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(350, 240);
            this.dgvDanhMuc.TabIndex = 10;
            this.dgvDanhMuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhMuc_CellClick);

            // 
            // IndexQuanLyKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Name = "IndexQuanLyKhoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ KHO HÀNG";
            this.Load += new System.EventHandler(this.IndexQuanLyKhoHang_Load);

            this.pnlHeader.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabNhapHang.ResumeLayout(false);
            this.tlpNhapHang.ResumeLayout(false);
            this.pnlLeftNhap.ResumeLayout(false);
            this.grpThongTinPhieu.ResumeLayout(false);
            this.grpThongTinPhieu.PerformLayout();
            this.grpChonHang.ResumeLayout(false);
            this.grpChonHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongQuyDoi)).EndInit();
            this.pnlQuyDoi.ResumeLayout(false);
            this.pnlRightNhap.ResumeLayout(false);
            this.grpDanhSachHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).EndInit();
            this.pnlTongKetNhap.ResumeLayout(false);
            this.pnlTongKetNhap.PerformLayout();
            this.tabLichSu.ResumeLayout(false);
            this.pnlTopLichSu.ResumeLayout(false);
            this.pnlTopLichSu.PerformLayout();
            this.tlpLichSu.ResumeLayout(false);
            this.grpDSHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).EndInit();
            this.grpChiTietPhieuCu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuCu)).EndInit();
            this.tabHangHoa.ResumeLayout(false);
            this.grpHangHoa.ResumeLayout(false);
            this.grpHangHoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.grpDanhMuc.ResumeLayout(false);
            this.grpDanhMuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TabControl tabMain;

        // Tab 1: Nhập Hàng
        private System.Windows.Forms.TabPage tabNhapHang;
        private System.Windows.Forms.TableLayoutPanel tlpNhapHang;
        private System.Windows.Forms.Panel pnlLeftNhap;
        private System.Windows.Forms.GroupBox grpThongTinPhieu;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Button btnThemNCC;
        private System.Windows.Forms.Label lblNguoiNhap;
        private System.Windows.Forms.ComboBox cboNguoiNhap;
        private System.Windows.Forms.GroupBox grpChonHang;
        private System.Windows.Forms.Label lblMatHang;
        private System.Windows.Forms.ComboBox cboMatHang;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.ComboBox cboDonViTinh;
        private System.Windows.Forms.Label lblSoLuongNhap;
        private System.Windows.Forms.NumericUpDown nudSoLuongNhap;
        private System.Windows.Forms.Label lblSoLuongQuyDoi;
        private System.Windows.Forms.NumericUpDown nudSoLuongQuyDoi;
        private System.Windows.Forms.Panel pnlQuyDoi;
        private System.Windows.Forms.Label lblQuyDoiPreview;
        private System.Windows.Forms.Label lblDonGiaNhapItem;
        private System.Windows.Forms.TextBox txtDonGiaNhapItem;
        private System.Windows.Forms.Label lblThanhTienItem;
        private System.Windows.Forms.TextBox txtThanhTienItem;
        private System.Windows.Forms.CheckBox chkCoHSD;
        private System.Windows.Forms.Label lblNSX;
        private System.Windows.Forms.DateTimePicker dtpNSX;
        private System.Windows.Forms.Label lblHSD;
        private System.Windows.Forms.DateTimePicker dtpHSD;
        private System.Windows.Forms.Button btnThemChiTiet;
        private System.Windows.Forms.Button btnXoaChiTiet;
        private System.Windows.Forms.Button btnLamMoiChiTiet;
        private System.Windows.Forms.Panel pnlRightNhap;
        private System.Windows.Forms.GroupBox grpDanhSachHang;
        private System.Windows.Forms.DataGridView dgvChiTietNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongQuyDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongQuyDoiKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSD;
        private System.Windows.Forms.Panel pnlTongKetNhap;
        private System.Windows.Forms.Label lblTongSoMatHang;
        private System.Windows.Forms.Label lblTongSLQuyDoiKho;
        private System.Windows.Forms.Label lblTongTienHD;
        private System.Windows.Forms.Button btnLuuHD;
        private System.Windows.Forms.Button btnLamMoiHD;
        private System.Windows.Forms.Button btnHuyHD;

        // Tab 2: Lịch sử & danh sách phiếu nhập
        private System.Windows.Forms.TabPage tabLichSu;
        private System.Windows.Forms.Panel pnlTopLichSu;
        private System.Windows.Forms.Label lblTimKiemPNH;
        private System.Windows.Forms.TextBox txtTimKiemPNH;
        private System.Windows.Forms.Label lblLocNCC;
        private System.Windows.Forms.ComboBox cboLocNCC;
        private System.Windows.Forms.Button btnLamMoiLichSu;
        private System.Windows.Forms.Button btnXoaHD;
        private System.Windows.Forms.TableLayoutPanel tlpLichSu;
        private System.Windows.Forms.GroupBox grpDSHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDonNhap;
        private System.Windows.Forms.GroupBox grpChiTietPhieuCu;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuCu;

        // Tab 3: Hàng Hóa Kho
        private System.Windows.Forms.TabPage tabHangHoa;
        private System.Windows.Forms.GroupBox grpHangHoa;
        private System.Windows.Forms.Label lblMaHangHoa;
        private System.Windows.Forms.TextBox txtMaHangHoa;
        private System.Windows.Forms.Label lblTenHangHoa;
        private System.Windows.Forms.TextBox txtTenHangHoa;
        private System.Windows.Forms.Label lblDanhMucHH;
        private System.Windows.Forms.ComboBox cboDanhMucHH;
        private System.Windows.Forms.Button BtnMoQLDM;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblDonGiaNhap;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.Label lblDonGiaBan;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.Label lblMoTaHH;
        private System.Windows.Forms.TextBox txtMoTaHH;
        private System.Windows.Forms.Button btnThemHH;
        private System.Windows.Forms.Button btnSuaHH;
        private System.Windows.Forms.Button btnXoaHH;
        private System.Windows.Forms.Button btnLamMoiHH;
        private System.Windows.Forms.Label lblTimKiemHH;
        private System.Windows.Forms.TextBox txtTimKiemHH;
        private System.Windows.Forms.Label lblLocDanhMuc;
        private System.Windows.Forms.ComboBox cboLocDanhMuc;
        private System.Windows.Forms.DataGridView dgvHangHoa;

        // Modal Danh mục
        private System.Windows.Forms.GroupBox grpDanhMuc;
        private System.Windows.Forms.Label lblMaDanhMuc;
        private System.Windows.Forms.TextBox txtMaDanhMuc;
        private System.Windows.Forms.Label lblTenDanhMuc;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
        private System.Windows.Forms.Label lblMoTaDM;
        private System.Windows.Forms.TextBox txtMoTaDM;
        private System.Windows.Forms.Button btnThemDM;
        private System.Windows.Forms.Button btnSuaDM;
        private System.Windows.Forms.Button btnXoaDM;
        private System.Windows.Forms.Button btnLamMoiDM;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
    }
}
