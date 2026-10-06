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
            this.lblMaSP = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuonh = new System.Windows.Forms.TextBox();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.grpKhachHang = new System.Windows.Forms.GroupBox();
            this.lblEmain = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.btnSuaKH = new System.Windows.Forms.Button();
            this.btnXoaKH = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoaSPKhoiHD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.btnTimKiemSP = new System.Windows.Forms.Button();
            this.btnTimKiemKH = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpSanPham.SuspendLayout();
            this.grpKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.grpHoaDon.SuspendLayout();
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
            this.grpSanPham.Controls.Add(this.btnThemSP);
            this.grpSanPham.Controls.Add(this.btnSuaSP);
            this.grpSanPham.Controls.Add(this.btnTimKiemSP);
            this.grpSanPham.Controls.Add(this.txtSoLuonh);
            this.grpSanPham.Controls.Add(this.txtDonGia);
            this.grpSanPham.Controls.Add(this.txtTenSP);
            this.grpSanPham.Controls.Add(this.lblSoLuong);
            this.grpSanPham.Controls.Add(this.txtMaSP);
            this.grpSanPham.Controls.Add(this.lblMaSP);
            this.grpSanPham.Controls.Add(this.lblTenSP);
            this.grpSanPham.Controls.Add(this.lblDonGia);
            this.grpSanPham.Location = new System.Drawing.Point(12, 48);
            this.grpSanPham.Name = "grpSanPham";
            this.grpSanPham.Size = new System.Drawing.Size(550, 264);
            this.grpSanPham.TabIndex = 1;
            this.grpSanPham.TabStop = false;
            this.grpSanPham.Text = "THÔNG TIN SẢN PHẨM";
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
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(20, 161);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(72, 20);
            this.lblSoLuong.TabIndex = 5;
            this.lblSoLuong.Text = "Số lượng";
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
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(130, 32);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(150, 26);
            this.txtMaSP.TabIndex = 3;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(130, 72);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(250, 26);
            this.txtTenSP.TabIndex = 4;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(130, 112);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(150, 26);
            this.txtDonGia.TabIndex = 5;
            // 
            // txtSoLuonh
            // 
            this.txtSoLuonh.Location = new System.Drawing.Point(130, 155);
            this.txtSoLuonh.Name = "txtSoLuonh";
            this.txtSoLuonh.Size = new System.Drawing.Size(100, 26);
            this.txtSoLuonh.TabIndex = 6;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Location = new System.Drawing.Point(56, 210);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(130, 48);
            this.btnThemSP.TabIndex = 7;
            this.btnThemSP.Text = "Thêm sản phẩm";
            this.btnThemSP.UseVisualStyleBackColor = true;
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.Location = new System.Drawing.Point(216, 210);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(130, 48);
            this.btnSuaSP.TabIndex = 8;
            this.btnSuaSP.Text = "Sửa sản phẩm";
            this.btnSuaSP.UseVisualStyleBackColor = true;
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
            this.grpKhachHang.Location = new System.Drawing.Point(606, 48);
            this.grpKhachHang.Name = "grpKhachHang";
            this.grpKhachHang.Size = new System.Drawing.Size(589, 264);
            this.grpKhachHang.TabIndex = 7;
            this.grpKhachHang.TabStop = false;
            this.grpKhachHang.Text = "THÔNG TIN KHÁCH HÀNG";
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
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(23, 72);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(57, 20);
            this.lblTenKH.TabIndex = 9;
            this.lblTenKH.Text = "Họ tên";
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
            this.btnThemKH.Location = new System.Drawing.Point(11, 210);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(130, 48);
            this.btnThemKH.TabIndex = 11;
            this.btnThemKH.Text = "Thêm khách hàng";
            this.btnThemKH.UseVisualStyleBackColor = true;
            // 
            // btnSuaKH
            // 
            this.btnSuaKH.Location = new System.Drawing.Point(156, 210);
            this.btnSuaKH.Name = "btnSuaKH";
            this.btnSuaKH.Size = new System.Drawing.Size(130, 48);
            this.btnSuaKH.TabIndex = 12;
            this.btnSuaKH.Text = "Sửa khách hàng";
            this.btnSuaKH.UseVisualStyleBackColor = true;
            // 
            // btnXoaKH
            // 
            this.btnXoaKH.Location = new System.Drawing.Point(304, 210);
            this.btnXoaKH.Name = "btnXoaKH";
            this.btnXoaKH.Size = new System.Drawing.Size(130, 48);
            this.btnXoaKH.TabIndex = 13;
            this.btnXoaKH.Text = "Xóa khách hàng";
            this.btnXoaKH.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(147, 158);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 26);
            this.txtEmail.TabIndex = 11;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(147, 115);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(185, 26);
            this.txtSDT.TabIndex = 12;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(147, 75);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(185, 26);
            this.txtTenKH.TabIndex = 13;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(147, 35);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(151, 26);
            this.txtMaKH.TabIndex = 14;
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colTenSP,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(12, 347);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.RowTemplate.Height = 28;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(1144, 129);
            this.dgvChiTietHoaDon.TabIndex = 9;
            this.dgvChiTietHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietHoaDon_CellContentClick);
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 8;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 150;
            // 
            // colDonGia
            // 
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 8;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 150;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 8;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Width = 150;
            // 
            // colTenSP
            // 
            this.colTenSP.HeaderText = "Tên sản phẩm";
            this.colTenSP.MinimumWidth = 8;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            this.colTenSP.Width = 150;
            // 
            // colMaSP
            // 
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.MinimumWidth = 8;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.ReadOnly = true;
            this.colMaSP.Width = 150;
            // 
            // btnXoaSPKhoiHD
            // 
            this.btnXoaSPKhoiHD.Location = new System.Drawing.Point(962, 412);
            this.btnXoaSPKhoiHD.Name = "btnXoaSPKhoiHD";
            this.btnXoaSPKhoiHD.Size = new System.Drawing.Size(130, 48);
            this.btnXoaSPKhoiHD.TabIndex = 10;
            this.btnXoaSPKhoiHD.Text = "Xóa sản phẩm";
            this.btnXoaSPKhoiHD.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "CHI TIẾT HÓA ĐƠN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // grpHoaDon
            // 
            this.grpHoaDon.Controls.Add(this.btnTaoHoaDon);
            this.grpHoaDon.Controls.Add(this.btnXuatHoaDon);
            this.grpHoaDon.Controls.Add(this.txtMaHD);
            this.grpHoaDon.Controls.Add(this.btnLamMoi);
            this.grpHoaDon.Controls.Add(this.txtTongTien);
            this.grpHoaDon.Controls.Add(this.lblTongTien);
            this.grpHoaDon.Controls.Add(this.lblMaHD);
            this.grpHoaDon.Location = new System.Drawing.Point(12, 504);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Size = new System.Drawing.Size(1144, 221);
            this.grpHoaDon.TabIndex = 12;
            this.grpHoaDon.TabStop = false;
            this.grpHoaDon.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(617, 39);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(75, 20);
            this.lblTongTien.TabIndex = 13;
            this.lblTongTien.Text = "Tổng tiền";
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
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTongTien.Location = new System.Drawing.Point(727, 38);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(179, 26);
            this.txtTongTien.TabIndex = 15;
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMaHD.Location = new System.Drawing.Point(117, 33);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(150, 26);
            this.txtMaHD.TabIndex = 16;
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Location = new System.Drawing.Point(173, 91);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(130, 60);
            this.btnTaoHoaDon.TabIndex = 13;
            this.btnTaoHoaDon.Text = "Tạo hóa đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.Location = new System.Drawing.Point(535, 91);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(130, 60);
            this.btnXuatHoaDon.TabIndex = 14;
            this.btnXuatHoaDon.Text = "Xuất hóa đơn";
            this.btnXuatHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnTimKiemSP
            // 
            this.btnTimKiemSP.Location = new System.Drawing.Point(374, 210);
            this.btnTimKiemSP.Name = "btnTimKiemSP";
            this.btnTimKiemSP.Size = new System.Drawing.Size(130, 48);
            this.btnTimKiemSP.TabIndex = 15;
            this.btnTimKiemSP.Text = "Tìm kiếm";
            this.btnTimKiemSP.UseVisualStyleBackColor = true;
            // 
            // btnTimKiemKH
            // 
            this.btnTimKiemKH.Location = new System.Drawing.Point(445, 210);
            this.btnTimKiemKH.Name = "btnTimKiemKH";
            this.btnTimKiemKH.Size = new System.Drawing.Size(130, 48);
            this.btnTimKiemKH.TabIndex = 16;
            this.btnTimKiemKH.Text = "Tìm kiếm";
            this.btnTimKiemKH.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(851, 91);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 60);
            this.btnLamMoi.TabIndex = 17;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 667);
            this.Controls.Add(this.grpHoaDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXoaSPKhoiHD);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.grpKhachHang);
            this.Controls.Add(this.grpSanPham);
            this.Controls.Add(this.lblTieuDe);
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
        private System.Windows.Forms.TextBox txtSoLuonh;
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
    }
}