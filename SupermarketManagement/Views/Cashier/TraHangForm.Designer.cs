using System;
using System.Drawing;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Cashier
{
    partial class TraHangForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblSoLuongTra;
        private Button btnCapNhatSoLuong;
        private NumericUpDown numSoLuongTra;
        private ComboBox cboMaHD;
        private Panel pnlHeader;
        private Panel pnlInfo;
        private Panel pnlBottom;
        private Label lblTieuDe;
        private Label lblMaPhieu;
        private Label lblNgay;
        private Label lblMaHD;
        private Label lblLyDo;
        private TextBox txtLyDo;
        private Label lblKhachHang;
        private Button btnTim;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSanPham;
        private DataGridViewTextBoxColumn colTenDV;
        private DataGridViewTextBoxColumn colSoLuongDaMua;
        private DataGridViewTextBoxColumn colSoLuongDaTra;
        private DataGridViewTextBoxColumn colSoLuongTra;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
        private Button btnLuu;
        private Button btnDong;
        private Button btnLichSuTraHang;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.cboMaHD = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLichSuTraHang = new System.Windows.Forms.Button();
            this.lblSoLuongTra = new System.Windows.Forms.Label();
            this.numSoLuongTra = new System.Windows.Forms.NumericUpDown();
            this.btnCapNhatSoLuong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTra)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(180)))), ((int)(((byte)(217)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 58);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1200, 58);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "LẬP PHIẾU TRẢ HÀNG";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblMaPhieu);
            this.pnlInfo.Controls.Add(this.lblNgay);
            this.pnlInfo.Controls.Add(this.lblMaHD);
            this.pnlInfo.Controls.Add(this.cboMaHD);
            this.pnlInfo.Controls.Add(this.btnTim);
            this.pnlInfo.Controls.Add(this.lblKhachHang);
            this.pnlInfo.Controls.Add(this.lblLyDo);
            this.pnlInfo.Controls.Add(this.txtLyDo);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 58);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(15);
            this.pnlInfo.Size = new System.Drawing.Size(1200, 125);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaPhieu.Location = new System.Drawing.Point(15, 12);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(340, 25);
            this.lblMaPhieu.TabIndex = 0;
            // 
            // lblNgay
            // 
            this.lblNgay.Location = new System.Drawing.Point(370, 12);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(300, 25);
            this.lblNgay.TabIndex = 1;
            // 
            // lblMaHD
            // 
            this.lblMaHD.Location = new System.Drawing.Point(15, 53);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(125, 28);
            this.lblMaHD.TabIndex = 2;
            this.lblMaHD.Text = "Mã hóa đơn gốc:";
            this.lblMaHD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMaHD
            // 
            this.cboMaHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaHD.FormattingEnabled = true;
            this.cboMaHD.Location = new System.Drawing.Point(145, 53);
            this.cboMaHD.Name = "cboMaHD";
            this.cboMaHD.Size = new System.Drawing.Size(240, 33);
            this.cboMaHD.TabIndex = 3;
            this.cboMaHD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboMaHD_KeyDown);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(124)))), ((int)(((byte)(240)))));
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(395, 51);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(120, 32);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm hóa đơn";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.BtnTim_Click);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhachHang.Location = new System.Drawing.Point(535, 53);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(650, 28);
            this.lblKhachHang.TabIndex = 5;
            this.lblKhachHang.Text = "Khách hàng: chưa chọn hóa đơn";
            this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLyDo
            // 
            this.lblLyDo.Location = new System.Drawing.Point(15, 88);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(100, 23);
            this.lblLyDo.TabIndex = 6;
            this.lblLyDo.Text = "Lý do trả:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLyDo.Location = new System.Drawing.Point(145, 86);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(1790, 31);
            this.txtLyDo.TabIndex = 7;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeight = 34;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 183);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 62;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1200, 463);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.btnLuu);
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Controls.Add(this.btnLichSuTraHang);
            this.pnlBottom.Controls.Add(this.lblSoLuongTra);
            this.pnlBottom.Controls.Add(this.numSoLuongTra);
            this.pnlBottom.Controls.Add(this.btnCapNhatSoLuong);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 646);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(12);
            this.pnlBottom.Size = new System.Drawing.Size(1200, 104);
            this.pnlBottom.TabIndex = 1;
            this.pnlBottom.Resize += new System.EventHandler(this.pnlBottom_Resize);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(164)))), ((int)(((byte)(71)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(794, 13);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(130, 36);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lập phiếu trả";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(1083, 13);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 36);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLichSuTraHang
            // 
            this.btnLichSuTraHang.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLichSuTraHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichSuTraHang.ForeColor = System.Drawing.Color.White;
            this.btnLichSuTraHang.Location = new System.Drawing.Point(929, 13);
            this.btnLichSuTraHang.Name = "btnLichSuTraHang";
            this.btnLichSuTraHang.Size = new System.Drawing.Size(150, 36);
            this.btnLichSuTraHang.TabIndex = 10;
            this.btnLichSuTraHang.Text = "Lịch sử trả hàng";
            this.btnLichSuTraHang.UseVisualStyleBackColor = false;
            this.btnLichSuTraHang.Click += new System.EventHandler(this.btnLichSuTraHang_Click);
            // 
            // lblSoLuongTra
            // 
            this.lblSoLuongTra.AutoSize = true;
            this.lblSoLuongTra.Location = new System.Drawing.Point(305, 20);
            this.lblSoLuongTra.Name = "lblSoLuongTra";
            this.lblSoLuongTra.Size = new System.Drawing.Size(115, 25);
            this.lblSoLuongTra.TabIndex = 4;
            this.lblSoLuongTra.Text = "Số lượng trả:";
            // 
            // numSoLuongTra
            // 
            this.numSoLuongTra.Location = new System.Drawing.Point(424, 18);
            this.numSoLuongTra.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSoLuongTra.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuongTra.Name = "numSoLuongTra";
            this.numSoLuongTra.Size = new System.Drawing.Size(100, 31);
            this.numSoLuongTra.TabIndex = 5;
            this.numSoLuongTra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuongTra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numSoLuongTra_KeyDown);
            // 
            // btnCapNhatSoLuong
            // 
            this.btnCapNhatSoLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCapNhatSoLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatSoLuong.Location = new System.Drawing.Point(544, 13);
            this.btnCapNhatSoLuong.Name = "btnCapNhatSoLuong";
            this.btnCapNhatSoLuong.Size = new System.Drawing.Size(200, 36);
            this.btnCapNhatSoLuong.TabIndex = 6;
            this.btnCapNhatSoLuong.Text = "Cập nhật số lượng trả";
            this.btnCapNhatSoLuong.UseVisualStyleBackColor = false;
            this.btnCapNhatSoLuong.Click += new System.EventHandler(this.BtnCapNhatSoLuongTra_Click);
            // 
            // TraHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "TraHangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LẬP PHIẾU TRẢ HÀNG";
            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTra)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
