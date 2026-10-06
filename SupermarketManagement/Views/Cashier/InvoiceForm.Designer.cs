namespace SupermarketManagement.Views.Cashier
{
    partial class InvoiceForm
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
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblNgayMua = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInHD = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dtpNgayMua = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(412, 21);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(171, 20);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "HÓA ĐƠN BÁN HÀNG";
            this.lblTieuDe.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(26, 73);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(93, 20);
            this.lblMaHD.TabIndex = 1;
            this.lblMaHD.Text = "Mã hóa đơn";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(612, 136);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(94, 20);
            this.lblKhachHang.TabIndex = 3;
            this.lblKhachHang.Text = "Khách hàng";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(26, 197);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(79, 20);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(26, 136);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(118, 20);
            this.lblMaKH.TabIndex = 5;
            this.lblMaKH.Text = "Mã khách hàng";
            // 
            // lblNgayMua
            // 
            this.lblNgayMua.AutoSize = true;
            this.lblNgayMua.Location = new System.Drawing.Point(612, 73);
            this.lblNgayMua.Name = "lblNgayMua";
            this.lblNgayMua.Size = new System.Drawing.Size(80, 20);
            this.lblNgayMua.TabIndex = 6;
            this.lblNgayMua.Text = "Ngày mua";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(655, 538);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(75, 20);
            this.lblTongTien.TabIndex = 7;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(760, 532);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(200, 26);
            this.txtTongTien.TabIndex = 8;
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Location = new System.Drawing.Point(167, 191);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(195, 26);
            this.txtNhanVien.TabIndex = 9;
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.Location = new System.Drawing.Point(745, 136);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.Size = new System.Drawing.Size(206, 26);
            this.txtKhachHang.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(167, 73);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 26);
            this.textBox4.TabIndex = 11;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(167, 136);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(170, 26);
            this.txtMaHD.TabIndex = 13;
            // 
            // dgvInvoiceDetails
            // 
            this.dgvInvoiceDetails.AllowUserToAddRows = false;
            this.dgvInvoiceDetails.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaSP,
            this.colTenSP,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.dgvInvoiceDetails.Location = new System.Drawing.Point(12, 255);
            this.dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            this.dgvInvoiceDetails.RowHeadersWidth = 62;
            this.dgvInvoiceDetails.RowTemplate.Height = 28;
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(964, 242);
            this.dgvInvoiceDetails.TabIndex = 14;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 150;
            // 
            // colMaSP
            // 
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.MinimumWidth = 8;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.Width = 150;
            // 
            // colTenSP
            // 
            this.colTenSP.HeaderText = "Tên sản phẩm";
            this.colTenSP.MinimumWidth = 8;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.Width = 150;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 8;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Width = 150;
            // 
            // colDonGia
            // 
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 8;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.Width = 150;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 8;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.Width = 150;
            // 
            // btnInHD
            // 
            this.btnInHD.Location = new System.Drawing.Point(299, 591);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(130, 48);
            this.btnInHD.TabIndex = 16;
            this.btnInHD.Text = "In hóa đơn";
            this.btnInHD.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(585, 591);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(130, 48);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // dtpNgayMua
            // 
            this.dtpNgayMua.Location = new System.Drawing.Point(745, 68);
            this.dtpNgayMua.Name = "dtpNgayMua";
            this.dtpNgayMua.Size = new System.Drawing.Size(200, 26);
            this.dtpNgayMua.TabIndex = 18;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 641);
            this.Controls.Add(this.dtpNgayMua);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.dgvInvoiceDetails);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.txtKhachHang);
            this.Controls.Add(this.txtNhanVien);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblNgayMua);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.lblKhachHang);
            this.Controls.Add(this.lblMaHD);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "InvoiceForm";
            this.Text = "InvoiceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label lblNgayMua;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.TextBox txtKhachHang;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DateTimePicker dtpNgayMua;
    }
}