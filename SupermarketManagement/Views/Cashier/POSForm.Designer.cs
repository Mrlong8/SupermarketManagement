namespace SupermarketManagement
{
    partial class POSForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpSanPham = new System.Windows.Forms.GroupBox();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.btnTimKiemSP = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.grpKhachHang = new System.Windows.Forms.GroupBox();
            this.txtDiemTichLuy = new System.Windows.Forms.TextBox();
            this.btnTaoMaKH = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnTimKiemKH = new System.Windows.Forms.Button();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblEmain = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoaSPKhoiHD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.lblDiemTichLuy = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDiemSuDung = new System.Windows.Forms.Label();
            this.txtDiemSuDung = new System.Windows.Forms.TextBox();
            this.txtTienGiamGia = new System.Windows.Forms.TextBox();
            this.txtDiemTichLuyHD = new System.Windows.Forms.TextBox();
            this.txtTienPhaiTra = new System.Windows.Forms.TextBox();
            this.btnThemHoaDon = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvDSSP = new System.Windows.Forms.DataGridView();
            this.colMaSP_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaBan_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.grpSanPham.SuspendLayout();
            this.grpKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.grpHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSP)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(510, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(167, 20);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ BÁN HÀNG";
            // 
            // grpSanPham
            // 
            this.grpSanPham.Controls.Add(this.btnSuaSP);
            this.grpSanPham.Controls.Add(this.btnTimKiemSP);
            this.grpSanPham.Controls.Add(this.txtSoLuong);
            this.grpSanPham.Controls.Add(this.txtDonGia);
            this.grpSanPham.Controls.Add(this.txtTenSP);
            this.grpSanPham.Controls.Add(this.lblSoLuong);
            this.grpSanPham.Controls.Add(this.txtMaSP);
            this.grpSanPham.Controls.Add(this.lblMaSP);
            this.grpSanPham.Controls.Add(this.lblTenSP);
            this.grpSanPham.Controls.Add(this.lblDonGia);
            this.grpSanPham.Location = new System.Drawing.Point(12, 64);
            this.grpSanPham.Name = "grpSanPham";
            this.grpSanPham.Size = new System.Drawing.Size(550, 264);
            this.grpSanPham.TabIndex = 1;
            this.grpSanPham.TabStop = false;
            this.grpSanPham.Text = "THÔNG TIN SẢN PHẨM";
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.BackColor = System.Drawing.Color.Yellow;
            this.btnSuaSP.Location = new System.Drawing.Point(102, 198);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(130, 60);
            this.btnSuaSP.TabIndex = 8;
            this.btnSuaSP.Text = "Sửa sản phẩm";
            this.btnSuaSP.UseVisualStyleBackColor = false;
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click);
            // 
            // btnTimKiemSP
            // 
            this.btnTimKiemSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTimKiemSP.Location = new System.Drawing.Point(323, 198);
            this.btnTimKiemSP.Name = "btnTimKiemSP";
            this.btnTimKiemSP.Size = new System.Drawing.Size(130, 60);
            this.btnTimKiemSP.TabIndex = 15;
            this.btnTimKiemSP.Text = "Tìm kiếm";
            this.btnTimKiemSP.UseVisualStyleBackColor = false;
            this.btnTimKiemSP.Click += new System.EventHandler(this.btnTimKiemSP_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(130, 155);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(122, 26);
            this.txtSoLuong.TabIndex = 6;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(130, 112);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(122, 26);
            this.txtDonGia.TabIndex = 5;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(130, 72);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.ReadOnly = true;
            this.txtTenSP.Size = new System.Drawing.Size(250, 26);
            this.txtTenSP.TabIndex = 4;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(20, 161);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(72, 20);
            this.lblSoLuong.TabIndex = 5;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(130, 32);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(150, 26);
            this.txtMaSP.TabIndex = 3;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(20, 35);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(105, 20);
            this.lblMaSP.TabIndex = 2;
            this.lblMaSP.Text = "Mã sản phẩm";
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(20, 75);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(110, 20);
            this.lblTenSP.TabIndex = 3;
            this.lblTenSP.Text = "Tên sản phẩm";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(20, 115);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(64, 20);
            this.lblDonGia.TabIndex = 4;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(23, 35);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(118, 20);
            this.lblMaKH.TabIndex = 6;
            this.lblMaKH.Text = "Mã khách hàng";
            // 
            // grpKhachHang
            // 
            this.grpKhachHang.Controls.Add(this.txtDiemTichLuy);
            this.grpKhachHang.Controls.Add(this.btnTaoMaKH);
            this.grpKhachHang.Controls.Add(this.txtEmail);
            this.grpKhachHang.Controls.Add(this.txtSDT);
            this.grpKhachHang.Controls.Add(this.btnTimKiemKH);
            this.grpKhachHang.Controls.Add(this.txtTenKH);
            this.grpKhachHang.Controls.Add(this.txtMaKH);
            this.grpKhachHang.Controls.Add(this.lblEmain);
            this.grpKhachHang.Controls.Add(this.lblSDT);
            this.grpKhachHang.Controls.Add(this.btnThemKH);
            this.grpKhachHang.Controls.Add(this.lblMaKH);
            this.grpKhachHang.Controls.Add(this.lblTenKH);
            this.grpKhachHang.Location = new System.Drawing.Point(606, 70);
            this.grpKhachHang.Name = "grpKhachHang";
            this.grpKhachHang.Size = new System.Drawing.Size(589, 264);
            this.grpKhachHang.TabIndex = 7;
            this.grpKhachHang.TabStop = false;
            this.grpKhachHang.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // txtDiemTichLuy
            // 
            this.txtDiemTichLuy.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiemTichLuy.Location = new System.Drawing.Point(425, 115);
            this.txtDiemTichLuy.Name = "txtDiemTichLuy";
            this.txtDiemTichLuy.ReadOnly = true;
            this.txtDiemTichLuy.Size = new System.Drawing.Size(130, 26);
            this.txtDiemTichLuy.TabIndex = 17;
            // 
            // btnTaoMaKH
            // 
            this.btnTaoMaKH.Location = new System.Drawing.Point(425, 31);
            this.btnTaoMaKH.Name = "btnTaoMaKH";
            this.btnTaoMaKH.Size = new System.Drawing.Size(130, 34);
            this.btnTaoMaKH.TabIndex = 17;
            this.btnTaoMaKH.Text = "Tạo Mã KH";
            this.btnTaoMaKH.UseVisualStyleBackColor = true;
            this.btnTaoMaKH.Click += new System.EventHandler(this.btnTaoMaKH_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(147, 158);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(202, 26);
            this.txtEmail.TabIndex = 11;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(147, 115);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(202, 26);
            this.txtSDT.TabIndex = 12;
            // 
            // btnTimKiemKH
            // 
            this.btnTimKiemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTimKiemKH.Location = new System.Drawing.Point(366, 198);
            this.btnTimKiemKH.Name = "btnTimKiemKH";
            this.btnTimKiemKH.Size = new System.Drawing.Size(130, 60);
            this.btnTimKiemKH.TabIndex = 16;
            this.btnTimKiemKH.Text = "Tìm kiếm";
            this.btnTimKiemKH.UseVisualStyleBackColor = false;
            this.btnTimKiemKH.Click += new System.EventHandler(this.btnTimKiemKH_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(147, 75);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(202, 26);
            this.txtTenKH.TabIndex = 13;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(147, 35);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(202, 26);
            this.txtMaKH.TabIndex = 14;
            // 
            // lblEmain
            // 
            this.lblEmain.AutoSize = true;
            this.lblEmain.Location = new System.Drawing.Point(23, 161);
            this.lblEmain.Name = "lblEmain";
            this.lblEmain.Size = new System.Drawing.Size(48, 20);
            this.lblEmain.TabIndex = 7;
            this.lblEmain.Text = "Email";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(23, 115);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(102, 20);
            this.lblSDT.TabIndex = 10;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.Lime;
            this.btnThemKH.Location = new System.Drawing.Point(124, 198);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(130, 60);
            this.btnThemKH.TabIndex = 11;
            this.btnThemKH.Text = "Thêm khách hàng";
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(23, 72);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(57, 20);
            this.lblTenKH.TabIndex = 9;
            this.lblTenKH.Text = "Họ tên";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            this.dgvChiTietHoaDon.AllowUserToResizeColumns = false;
            this.dgvChiTietHoaDon.AllowUserToResizeRows = false;
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvChiTietHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colTenSP,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.dgvChiTietHoaDon.GridColor = System.Drawing.Color.Silver;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(12, 635);
            this.dgvChiTietHoaDon.MultiSelect = false;
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersVisible = false;
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.RowTemplate.Height = 28;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(1183, 181);
            this.dgvChiTietHoaDon.TabIndex = 9;
            this.dgvChiTietHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietHoaDon_CellClick);
            // 
            // colMaSP
            // 
            this.colMaSP.DataPropertyName = "MaSP";
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.MinimumWidth = 8;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.ReadOnly = true;
            // 
            // colTenSP
            // 
            this.colTenSP.DataPropertyName = "TenSanPham";
            this.colTenSP.HeaderText = "Tên sản phẩm";
            this.colTenSP.MinimumWidth = 8;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 8;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGia";
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 8;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.DataPropertyName = "ThanhTien";
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 8;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // btnXoaSPKhoiHD
            // 
            this.btnXoaSPKhoiHD.BackColor = System.Drawing.Color.White;
            this.btnXoaSPKhoiHD.Location = new System.Drawing.Point(1060, 822);
            this.btnXoaSPKhoiHD.Name = "btnXoaSPKhoiHD";
            this.btnXoaSPKhoiHD.Size = new System.Drawing.Size(135, 60);
            this.btnXoaSPKhoiHD.TabIndex = 10;
            this.btnXoaSPKhoiHD.Text = "Xóa sản phẩm";
            this.btnXoaSPKhoiHD.UseVisualStyleBackColor = false;
            this.btnXoaSPKhoiHD.Click += new System.EventHandler(this.btnXoaSPKhoiHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 596);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // grpHoaDon
            // 
            this.grpHoaDon.Controls.Add(this.lblDiemTichLuy);
            this.grpHoaDon.Controls.Add(this.label5);
            this.grpHoaDon.Controls.Add(this.label4);
            this.grpHoaDon.Controls.Add(this.lblDiemSuDung);
            this.grpHoaDon.Controls.Add(this.txtDiemSuDung);
            this.grpHoaDon.Controls.Add(this.txtTienGiamGia);
            this.grpHoaDon.Controls.Add(this.txtDiemTichLuyHD);
            this.grpHoaDon.Controls.Add(this.txtTienPhaiTra);
            this.grpHoaDon.Controls.Add(this.btnThemHoaDon);
            this.grpHoaDon.Controls.Add(this.btnThoat);
            this.grpHoaDon.Controls.Add(this.btnTaoHoaDon);
            this.grpHoaDon.Controls.Add(this.btnXuatHoaDon);
            this.grpHoaDon.Controls.Add(this.txtMaHD);
            this.grpHoaDon.Controls.Add(this.btnLamMoi);
            this.grpHoaDon.Controls.Add(this.txtTongTien);
            this.grpHoaDon.Controls.Add(this.lblTongTien);
            this.grpHoaDon.Controls.Add(this.lblMaHD);
            this.grpHoaDon.Location = new System.Drawing.Point(12, 888);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Size = new System.Drawing.Size(1183, 221);
            this.grpHoaDon.TabIndex = 12;
            this.grpHoaDon.TabStop = false;
            this.grpHoaDon.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // lblDiemTichLuy
            // 
            this.lblDiemTichLuy.AutoSize = true;
            this.lblDiemTichLuy.Location = new System.Drawing.Point(20, 82);
            this.lblDiemTichLuy.Name = "lblDiemTichLuy";
            this.lblDiemTichLuy.Size = new System.Drawing.Size(98, 20);
            this.lblDiemTichLuy.TabIndex = 26;
            this.lblDiemTichLuy.Text = "Điểm tích lũy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(746, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tiền giảm giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(746, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Khách hàng trả";
            // 
            // lblDiemSuDung
            // 
            this.lblDiemSuDung.AutoSize = true;
            this.lblDiemSuDung.Location = new System.Drawing.Point(387, 85);
            this.lblDiemSuDung.Name = "lblDiemSuDung";
            this.lblDiemSuDung.Size = new System.Drawing.Size(107, 20);
            this.lblDiemSuDung.TabIndex = 23;
            this.lblDiemSuDung.Text = "Điểm sử dụng";
            // 
            // txtDiemSuDung
            // 
            this.txtDiemSuDung.Location = new System.Drawing.Point(508, 79);
            this.txtDiemSuDung.Name = "txtDiemSuDung";
            this.txtDiemSuDung.Size = new System.Drawing.Size(143, 26);
            this.txtDiemSuDung.TabIndex = 22;
            this.txtDiemSuDung.TextChanged += new System.EventHandler(this.txtDiemSuDung_TextChanged);
            // 
            // txtTienGiamGia
            // 
            this.txtTienGiamGia.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTienGiamGia.Location = new System.Drawing.Point(872, 42);
            this.txtTienGiamGia.Name = "txtTienGiamGia";
            this.txtTienGiamGia.ReadOnly = true;
            this.txtTienGiamGia.Size = new System.Drawing.Size(175, 26);
            this.txtTienGiamGia.TabIndex = 21;
            // 
            // txtDiemTichLuyHD
            // 
            this.txtDiemTichLuyHD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDiemTichLuyHD.Location = new System.Drawing.Point(124, 79);
            this.txtDiemTichLuyHD.Name = "txtDiemTichLuyHD";
            this.txtDiemTichLuyHD.ReadOnly = true;
            this.txtDiemTichLuyHD.Size = new System.Drawing.Size(140, 26);
            this.txtDiemTichLuyHD.TabIndex = 20;
            // 
            // txtTienPhaiTra
            // 
            this.txtTienPhaiTra.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTienPhaiTra.Location = new System.Drawing.Point(872, 79);
            this.txtTienPhaiTra.Name = "txtTienPhaiTra";
            this.txtTienPhaiTra.ReadOnly = true;
            this.txtTienPhaiTra.Size = new System.Drawing.Size(175, 26);
            this.txtTienPhaiTra.TabIndex = 19;
            // 
            // btnThemHoaDon
            // 
            this.btnThemHoaDon.BackColor = System.Drawing.Color.Lime;
            this.btnThemHoaDon.Location = new System.Drawing.Point(64, 141);
            this.btnThemHoaDon.Name = "btnThemHoaDon";
            this.btnThemHoaDon.Size = new System.Drawing.Size(130, 60);
            this.btnThemHoaDon.TabIndex = 18;
            this.btnThemHoaDon.Text = "Thêm hóa đơn";
            this.btnThemHoaDon.UseVisualStyleBackColor = false;
            this.btnThemHoaDon.Click += new System.EventHandler(this.btnThemHoaDon_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Yellow;
            this.btnThoat.Location = new System.Drawing.Point(1019, 141);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(130, 60);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTaoHoaDon.Location = new System.Drawing.Point(300, 141);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(130, 60);
            this.btnTaoHoaDon.TabIndex = 13;
            this.btnTaoHoaDon.Text = "Tạo hóa đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = false;
            this.btnTaoHoaDon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.BackColor = System.Drawing.Color.Fuchsia;
            this.btnXuatHoaDon.Location = new System.Drawing.Point(544, 141);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(130, 60);
            this.btnXuatHoaDon.TabIndex = 14;
            this.btnXuatHoaDon.Text = "Xuất hóa đơn";
            this.btnXuatHoaDon.UseVisualStyleBackColor = false;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMaHD.Location = new System.Drawing.Point(124, 36);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(195, 26);
            this.txtMaHD.TabIndex = 16;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Aqua;
            this.btnLamMoi.Location = new System.Drawing.Point(782, 141);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 60);
            this.btnLamMoi.TabIndex = 17;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTongTien.Location = new System.Drawing.Point(508, 39);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(174, 26);
            this.txtTongTien.TabIndex = 15;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(387, 45);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(115, 20);
            this.lblTongTien.TabIndex = 13;
            this.lblTongTien.Text = "Tổng tiền hàng";
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(20, 39);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(59, 20);
            this.lblMaHD.TabIndex = 14;
            this.lblMaHD.Text = "Mã HD";
            // 
            // dgvDSSP
            // 
            this.dgvDSSP.AllowUserToAddRows = false;
            this.dgvDSSP.AllowUserToDeleteRows = false;
            this.dgvDSSP.AllowUserToResizeColumns = false;
            this.dgvDSSP.AllowUserToResizeRows = false;
            this.dgvDSSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP_DSSP,
            this.colTenSP_DSSP,
            this.colSoLuong_DSSP,
            this.colDonGiaBan_DSSP});
            this.dgvDSSP.Location = new System.Drawing.Point(12, 387);
            this.dgvDSSP.MultiSelect = false;
            this.dgvDSSP.Name = "dgvDSSP";
            this.dgvDSSP.ReadOnly = true;
            this.dgvDSSP.RowHeadersVisible = false;
            this.dgvDSSP.RowHeadersWidth = 62;
            this.dgvDSSP.RowTemplate.Height = 28;
            this.dgvDSSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSSP.Size = new System.Drawing.Size(1183, 190);
            this.dgvDSSP.TabIndex = 13;
            this.dgvDSSP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSSP_CellDoubleClick);
            // 
            // colMaSP_DSSP
            // 
            this.colMaSP_DSSP.DataPropertyName = "MaSP";
            this.colMaSP_DSSP.HeaderText = "Mã SP";
            this.colMaSP_DSSP.MinimumWidth = 8;
            this.colMaSP_DSSP.Name = "colMaSP_DSSP";
            this.colMaSP_DSSP.ReadOnly = true;
            // 
            // colTenSP_DSSP
            // 
            this.colTenSP_DSSP.DataPropertyName = "TenSanPham";
            this.colTenSP_DSSP.HeaderText = "Tên sản phẩm";
            this.colTenSP_DSSP.MinimumWidth = 8;
            this.colTenSP_DSSP.Name = "colTenSP_DSSP";
            this.colTenSP_DSSP.ReadOnly = true;
            // 
            // colSoLuong_DSSP
            // 
            this.colSoLuong_DSSP.DataPropertyName = "SoLuong";
            this.colSoLuong_DSSP.HeaderText = "Số lượng";
            this.colSoLuong_DSSP.MinimumWidth = 8;
            this.colSoLuong_DSSP.Name = "colSoLuong_DSSP";
            this.colSoLuong_DSSP.ReadOnly = true;
            // 
            // colDonGiaBan_DSSP
            // 
            this.colDonGiaBan_DSSP.DataPropertyName = "DonGiaBan";
            this.colDonGiaBan_DSSP.HeaderText = "Đơn giá bán";
            this.colDonGiaBan_DSSP.MinimumWidth = 8;
            this.colDonGiaBan_DSSP.Name = "colDonGiaBan_DSSP";
            this.colDonGiaBan_DSSP.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Danh sách sản phẩm";
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(758, 38);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(61, 20);
            this.lblMaNV.TabIndex = 15;
            this.lblMaNV.Text = "Mã NV:";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Location = new System.Drawing.Point(952, 38);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(87, 20);
            this.lblTenNV.TabIndex = 16;
            this.lblTenNV.Text = "Nhân Viên:";
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1223, 1144);
            this.Controls.Add(this.lblTenNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDSSP);
            this.Controls.Add(this.grpHoaDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXoaSPKhoiHD);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.grpKhachHang);
            this.Controls.Add(this.grpSanPham);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "POSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ BÁN HÀNG";
            this.grpSanPham.ResumeLayout(false);
            this.grpSanPham.PerformLayout();
            this.grpKhachHang.ResumeLayout(false);
            this.grpKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.grpHoaDon.ResumeLayout(false);
            this.grpHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpSanPham;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.GroupBox grpKhachHang;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblEmain;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Button btnXoaSPKhoiHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpHoaDon;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.Button btnXuatHoaDon;
        private System.Windows.Forms.Button btnTimKiemSP;
        private System.Windows.Forms.Button btnTimKiemKH;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvDSSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP_DSSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP_DSSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong_DSSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaBan_DSSP;
        private System.Windows.Forms.Button btnThemHoaDon;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Button btnTaoMaKH;
        private System.Windows.Forms.TextBox txtDiemTichLuy;
        private System.Windows.Forms.TextBox txtDiemSuDung;
        private System.Windows.Forms.TextBox txtTienGiamGia;
        private System.Windows.Forms.TextBox txtDiemTichLuyHD;
        private System.Windows.Forms.TextBox txtTienPhaiTra;
        private System.Windows.Forms.Label lblDiemTichLuy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDiemSuDung;
    }
}