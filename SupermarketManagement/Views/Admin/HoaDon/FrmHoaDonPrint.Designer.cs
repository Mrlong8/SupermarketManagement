namespace SupermarketManagement.Views.Admin.HoaDon
{
    partial class FrmHoaDonPrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitleShop = new System.Windows.Forms.Label();
            this.lblTitleHeader = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblNgayMua = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.dgvChiTietHD = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnXuatPDF = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlHeader.Controls.Add(this.lblTitleShop);
            this.pnlHeader.Controls.Add(this.lblTitleHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(680, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitleShop
            // 
            this.lblTitleShop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleShop.ForeColor = System.Drawing.Color.White;
            this.lblTitleShop.Location = new System.Drawing.Point(12, 10);
            this.lblTitleShop.Name = "lblTitleShop";
            this.lblTitleShop.Size = new System.Drawing.Size(656, 30);
            this.lblTitleShop.TabIndex = 0;
            this.lblTitleShop.Text = "SIÊU THỊ SUPERMARKET MANAGEMENT";
            this.lblTitleShop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleHeader
            // 
            this.lblTitleHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblTitleHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleHeader.Location = new System.Drawing.Point(12, 42);
            this.lblTitleHeader.Name = "lblTitleHeader";
            this.lblTitleHeader.Size = new System.Drawing.Size(656, 25);
            this.lblTitleHeader.TabIndex = 1;
            this.lblTitleHeader.Text = "HÓA ĐƠN BÁN HÀNG";
            this.lblTitleHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.lblMaHD);
            this.grbThongTin.Controls.Add(this.lblNgayMua);
            this.grbThongTin.Controls.Add(this.lblKhachHang);
            this.grbThongTin.Controls.Add(this.lblNhanVien);
            this.grbThongTin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.grbThongTin.Location = new System.Drawing.Point(20, 95);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(640, 100);
            this.grbThongTin.TabIndex = 1;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông Tin Hóa Đơn";
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaHD.Location = new System.Drawing.Point(20, 30);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(99, 21);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã HĐ: HD001";
            // 
            // lblNgayMua
            // 
            this.lblNgayMua.AutoSize = true;
            this.lblNgayMua.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNgayMua.Location = new System.Drawing.Point(340, 30);
            this.lblNgayMua.Name = "lblNgayMua";
            this.lblNgayMua.Size = new System.Drawing.Size(147, 21);
            this.lblNgayMua.TabIndex = 1;
            this.lblNgayMua.Text = "Ngày bán: 11/10/2026";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKhachHang.Location = new System.Drawing.Point(20, 65);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(183, 21);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng: Nguyễn Văn A";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNhanVien.Location = new System.Drawing.Point(340, 65);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(133, 21);
            this.lblNhanVien.TabIndex = 3;
            this.lblNhanVien.Text = "Thu ngân: Admin";
            // 
            // dgvChiTietHD
            // 
            this.dgvChiTietHD.AllowUserToAddRows = false;
            this.dgvChiTietHD.AllowUserToDeleteRows = false;
            this.dgvChiTietHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietHD.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietHD.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTietHD.EnableHeadersVisualStyles = false;
            this.dgvChiTietHD.Location = new System.Drawing.Point(20, 205);
            this.dgvChiTietHD.MultiSelect = false;
            this.dgvChiTietHD.Name = "dgvChiTietHD";
            this.dgvChiTietHD.ReadOnly = true;
            this.dgvChiTietHD.RowHeadersVisible = false;
            this.dgvChiTietHD.RowHeadersWidth = 51;
            this.dgvChiTietHD.RowTemplate.Height = 28;
            this.dgvChiTietHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHD.Size = new System.Drawing.Size(640, 250);
            this.dgvChiTietHD.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(20, 465);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(640, 30);
            this.lblTongTien.TabIndex = 3;
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnXuatPDF
            // 
            this.btnXuatPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnXuatPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatPDF.FlatAppearance.BorderSize = 0;
            this.btnXuatPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatPDF.ForeColor = System.Drawing.Color.White;
            this.btnXuatPDF.Location = new System.Drawing.Point(380, 510);
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(150, 40);
            this.btnXuatPDF.TabIndex = 4;
            this.btnXuatPDF.Text = "Xuất File PDF";
            this.btnXuatPDF.UseVisualStyleBackColor = false;
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(545, 510);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(115, 40);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Đóng";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmHoaDonPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(680, 565);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXuatPDF);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.dgvChiTietHD);
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHoaDonPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết & In Hóa Đơn";
            this.Load += new System.EventHandler(this.FrmHoaDonPrint_Load);
            this.pnlHeader.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo lại toàn bộ các Control
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitleShop;
        private System.Windows.Forms.Label lblTitleHeader;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblNgayMua;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DataGridView dgvChiTietHD;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnXuatPDF;
        private System.Windows.Forms.Button btnThoat;
    }
}