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
            this.btnThemSP = new System.Windows.Forms.Button();
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnTimKiemKH = new System.Windows.Forms.Button();
            this.btnXoaKH = new System.Windows.Forms.Button();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.btnSuaKH = new System.Windows.Forms.Button();
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
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpSanPham.SuspendLayout();
            this.grpKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.grpHoaDon.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(453, 7);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(138, 16);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ BÁN HÀNG";
            // 
            // grpSanPham
            // 
            this.grpSanPham.Controls.Add(this.btnThemSP);
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
            this.grpSanPham.Location = new System.Drawing.Point(11, 38);
            this.grpSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpSanPham.Name = "grpSanPham";
            this.grpSanPham.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpSanPham.Size = new System.Drawing.Size(489, 211);
            this.grpSanPham.TabIndex = 1;
            this.grpSanPham.TabStop = false;
            this.grpSanPham.Text = "THÔNG TIN SẢN PHẨM";
            // 
            // btnThemSP
            // 
            this.btnThemSP.Location = new System.Drawing.Point(50, 168);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(116, 38);
            this.btnThemSP.TabIndex = 7;
            this.btnThemSP.Text = "Thêm sản phẩm";
            this.btnThemSP.UseVisualStyleBackColor = true;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.Location = new System.Drawing.Point(192, 168);
            this.btnSuaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(116, 38);
            this.btnSuaSP.TabIndex = 8;
            this.btnSuaSP.Text = "Sửa sản phẩm";
            this.btnSuaSP.UseVisualStyleBackColor = true;
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click);
            // 
            // btnTimKiemSP
            // 
            this.btnTimKiemSP.Location = new System.Drawing.Point(332, 168);
            this.btnTimKiemSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiemSP.Name = "btnTimKiemSP";
            this.btnTimKiemSP.Size = new System.Drawing.Size(116, 38);
            this.btnTimKiemSP.TabIndex = 15;
            this.btnTimKiemSP.Text = "Tìm kiếm";
            this.btnTimKiemSP.UseVisualStyleBackColor = true;
            this.btnTimKiemSP.Click += new System.EventHandler(this.btnTimKiemSP_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuonh.Location = new System.Drawing.Point(116, 124);
            this.txtSoLuonh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuonh.Name = "txtSoLuonh";
            this.txtSoLuonh.Size = new System.Drawing.Size(89, 22);
            this.txtSoLuonh.TabIndex = 6;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(116, 90);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(134, 22);
            this.txtDonGia.TabIndex = 5;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(116, 58);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(223, 22);
            this.txtTenSP.TabIndex = 4;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(18, 129);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(60, 16);
            this.lblSoLuong.TabIndex = 5;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(116, 26);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(134, 22);
            this.txtMaSP.TabIndex = 3;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(18, 28);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(88, 16);
            this.lblMaSP.TabIndex = 2;
            this.lblMaSP.Text = "Mã sản phẩm";
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(18, 60);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(93, 16);
            this.lblTenSP.TabIndex = 3;
            this.lblTenSP.Text = "Tên sản phẩm";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(18, 92);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(53, 16);
            this.lblDonGia.TabIndex = 4;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 28);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(98, 16);
            this.lblMaKH.TabIndex = 6;
            this.lblMaKH.Text = "Mã khách hàng";
            // 
            // grpKhachHang
            // 
            this.grpKhachHang.Controls.Add(this.txtEmail);
            this.grpKhachHang.Controls.Add(this.txtSDT);
            this.grpKhachHang.Controls.Add(this.btnTimKiemKH);
            this.grpKhachHang.Controls.Add(this.btnXoaKH);
            this.grpKhachHang.Controls.Add(this.txtTenKH);
            this.grpKhachHang.Controls.Add(this.txtMaKH);
            this.grpKhachHang.Controls.Add(this.btnSuaKH);
            this.grpKhachHang.Controls.Add(this.lblEmain);
            this.grpKhachHang.Controls.Add(this.lblSDT);
            this.grpKhachHang.Controls.Add(this.btnThemKH);
            this.grpKhachHang.Controls.Add(this.lblMaKH);
            this.grpKhachHang.Controls.Add(this.lblTenKH);
            this.grpKhachHang.Location = new System.Drawing.Point(539, 38);
            this.grpKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpKhachHang.Name = "grpKhachHang";
            this.grpKhachHang.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpKhachHang.Size = new System.Drawing.Size(524, 211);
            this.grpKhachHang.TabIndex = 7;
            this.grpKhachHang.TabStop = false;
            this.grpKhachHang.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(131, 126);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(214, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(131, 92);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(165, 22);
            this.txtSDT.TabIndex = 12;
            // 
            // btnTimKiemKH
            // 
            this.btnTimKiemKH.Location = new System.Drawing.Point(396, 168);
            this.btnTimKiemKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiemKH.Name = "btnTimKiemKH";
            this.btnTimKiemKH.Size = new System.Drawing.Size(116, 38);
            this.btnTimKiemKH.TabIndex = 16;
            this.btnTimKiemKH.Text = "Tìm kiếm";
            this.btnTimKiemKH.UseVisualStyleBackColor = true;
            this.btnTimKiemKH.Click += new System.EventHandler(this.btnTimKiemKH_Click);
            // 
            // btnXoaKH
            // 
            this.btnXoaKH.Location = new System.Drawing.Point(270, 168);
            this.btnXoaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaKH.Name = "btnXoaKH";
            this.btnXoaKH.Size = new System.Drawing.Size(116, 38);
            this.btnXoaKH.TabIndex = 13;
            this.btnXoaKH.Text = "Xóa khách hàng";
            this.btnXoaKH.UseVisualStyleBackColor = true;
            this.btnXoaKH.Click += new System.EventHandler(this.btnXoaKH_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(131, 60);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(165, 22);
            this.txtTenKH.TabIndex = 13;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(131, 28);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(135, 22);
            this.txtMaKH.TabIndex = 14;
            // 
            // btnSuaKH
            // 
            this.btnSuaKH.Location = new System.Drawing.Point(139, 168);
            this.btnSuaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaKH.Name = "btnSuaKH";
            this.btnSuaKH.Size = new System.Drawing.Size(116, 38);
            this.btnSuaKH.TabIndex = 12;
            this.btnSuaKH.Text = "Sửa khách hàng";
            this.btnSuaKH.UseVisualStyleBackColor = true;
            this.btnSuaKH.Click += new System.EventHandler(this.btnSuaKH_Click);
            // 
            // lblEmain
            // 
            this.lblEmain.AutoSize = true;
            this.lblEmain.Location = new System.Drawing.Point(20, 129);
            this.lblEmain.Name = "lblEmain";
            this.lblEmain.Size = new System.Drawing.Size(41, 16);
            this.lblEmain.TabIndex = 7;
            this.lblEmain.Text = "Email";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(20, 92);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(85, 16);
            this.lblSDT.TabIndex = 10;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // btnThemKH
            // 
            this.btnThemKH.Location = new System.Drawing.Point(10, 168);
            this.btnThemKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(116, 38);
            this.btnThemKH.TabIndex = 11;
            this.btnThemKH.Text = "Thêm khách hàng";
            this.btnThemKH.UseVisualStyleBackColor = true;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(20, 58);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(46, 16);
            this.lblTenKH.TabIndex = 9;
            this.lblTenKH.Text = "Họ tên";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colTenSP,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(11, 278);
            this.dgvChiTietHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.RowTemplate.Height = 28;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(823, 120);
            this.dgvChiTietHoaDon.TabIndex = 9;
            // 
            // colMaSP
            // 
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.MinimumWidth = 8;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.ReadOnly = true;
            this.colMaSP.Width = 150;
            // 
            // colTenSP
            // 
            this.colTenSP.HeaderText = "Tên sản phẩm";
            this.colTenSP.MinimumWidth = 8;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            this.colTenSP.Width = 150;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 8;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Width = 150;
            // 
            // colDonGia
            // 
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 8;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 150;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 8;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 150;
            // 
            // btnXoaSPKhoiHD
            // 
            this.btnXoaSPKhoiHD.Location = new System.Drawing.Point(738, 284);
            this.btnXoaSPKhoiHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaSPKhoiHD.Name = "btnXoaSPKhoiHD";
            this.btnXoaSPKhoiHD.Size = new System.Drawing.Size(87, 106);
            this.btnXoaSPKhoiHD.TabIndex = 10;
            this.btnXoaSPKhoiHD.Text = "Xóa sản phẩm";
            this.btnXoaSPKhoiHD.UseVisualStyleBackColor = true;
            this.btnXoaSPKhoiHD.Click += new System.EventHandler(this.btnXoaSPKhoiHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // grpHoaDon
            // 
            this.grpHoaDon.Controls.Add(this.btnDangXuat);
            this.grpHoaDon.Controls.Add(this.btnTaoHoaDon);
            this.grpHoaDon.Controls.Add(this.btnXuatHoaDon);
            this.grpHoaDon.Controls.Add(this.txtMaHD);
            this.grpHoaDon.Controls.Add(this.btnLamMoi);
            this.grpHoaDon.Controls.Add(this.txtTongTien);
            this.grpHoaDon.Controls.Add(this.lblTongTien);
            this.grpHoaDon.Controls.Add(this.lblMaHD);
            this.grpHoaDon.Location = new System.Drawing.Point(11, 403);
            this.grpHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpHoaDon.Size = new System.Drawing.Size(1017, 177);
            this.grpHoaDon.TabIndex = 12;
            this.grpHoaDon.TabStop = false;
            this.grpHoaDon.Text = "THÔNG TIN HÓA ĐƠN";
            this.grpHoaDon.Enter += new System.EventHandler(this.grpHoaDon_Enter);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(832, 73);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(112, 46);
            this.btnDangXuat.TabIndex = 18;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(988, 107);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(130, 60);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Location = new System.Drawing.Point(154, 73);
            this.btnTaoHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(116, 48);
            this.btnTaoHoaDon.TabIndex = 13;
            this.btnTaoHoaDon.Text = "Tạo hóa đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            this.btnTaoHoaDon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.Location = new System.Drawing.Point(373, 73);
            this.btnXuatHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(116, 48);
            this.btnXuatHoaDon.TabIndex = 14;
            this.btnXuatHoaDon.Text = "Xuất hóa đơn";
            this.btnXuatHoaDon.UseVisualStyleBackColor = true;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMaHD.Location = new System.Drawing.Point(104, 26);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(134, 22);
            this.txtMaHD.TabIndex = 16;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(596, 73);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(116, 48);
            this.btnLamMoi.TabIndex = 17;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTongTien.Location = new System.Drawing.Point(646, 30);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(160, 22);
            this.txtTongTien.TabIndex = 15;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(548, 31);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(63, 16);
            this.lblTongTien.TabIndex = 13;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(18, 31);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(49, 16);
            this.lblMaHD.TabIndex = 14;
            this.lblMaHD.Text = "Mã HD";
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 534);
            this.Controls.Add(this.grpHoaDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXoaSPKhoiHD);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.grpKhachHang);
            this.Controls.Add(this.grpSanPham);
            this.Controls.Add(this.lblTieuDe);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "POSForm";
            this.Text = "QUẢN LÝ BÁN HÀNG";
            this.grpSanPham.ResumeLayout(false);
            this.grpSanPham.PerformLayout();
            this.grpKhachHang.ResumeLayout(false);
            this.grpKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.grpHoaDon.ResumeLayout(false);
            this.grpHoaDon.PerformLayout();
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
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.GroupBox grpKhachHang;
        private System.Windows.Forms.Button btnXoaKH;
        private System.Windows.Forms.Button btnSuaKH;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblEmain;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
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
        private System.Windows.Forms.Button btnDangXuat;
    }
}