namespace SupermarketManagement.Views.Admin.QuanLyKhoHang
{
    partial class FrmQuyDoiDonVi
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

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubTieuDe = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpDonViCoBan = new System.Windows.Forms.GroupBox();
            this.lblNoteCoBan = new System.Windows.Forms.Label();
            this.txtGiaBanCoBan = new System.Windows.Forms.TextBox();
            this.lblGiaBanCoBan = new System.Windows.Forms.Label();
            this.txtGiaNhapCoBan = new System.Windows.Forms.TextBox();
            this.lblGiaNhapCoBan = new System.Windows.Forms.Label();
            this.btnThemDVTCoBan = new System.Windows.Forms.Button();
            this.cboDonViCoBan = new System.Windows.Forms.ComboBox();
            this.lblDonViCoBan = new System.Windows.Forms.Label();
            this.grpDonViQuyDoi = new System.Windows.Forms.GroupBox();
            this.btnThemQuyDoi = new System.Windows.Forms.Button();
            this.txtGiaBanQuyDoi = new System.Windows.Forms.TextBox();
            this.lblGiaBanQuyDoi = new System.Windows.Forms.Label();
            this.txtGiaNhapQuyDoi = new System.Windows.Forms.TextBox();
            this.lblGiaNhapQuyDoi = new System.Windows.Forms.Label();
            this.lblCongThucLive = new System.Windows.Forms.Label();
            this.nudSoLuongQuyDoi = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongQuyDoi = new System.Windows.Forms.Label();
            this.btnThemDVTQuyDoi = new System.Windows.Forms.Button();
            this.cboDonViQuyDoi = new System.Windows.Forms.ComboBox();
            this.lblDonViQuyDoi = new System.Windows.Forms.Label();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvDonVi = new System.Windows.Forms.DataGridView();
            this.colMaDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongQuyDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCongThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpDonViCoBan.SuspendLayout();
            this.grpDonViQuyDoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongQuyDoi)).BeginInit();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonVi)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // dgvStyles
            // 
            dgvStyleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvStyleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            dgvStyleHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvStyleHeader.ForeColor = System.Drawing.Color.White;
            dgvStyleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            dgvStyleHeader.SelectionForeColor = System.Drawing.Color.White;
            dgvStyleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            dgvStyleRow.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyleRow.BackColor = System.Drawing.Color.White;
            dgvStyleRow.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvStyleRow.ForeColor = System.Drawing.Color.Black;
            dgvStyleRow.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dgvStyleRow.SelectionForeColor = System.Drawing.Color.Black;

            dgvStyleAltRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dgvStyleAltRow.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvStyleAltRow.ForeColor = System.Drawing.Color.Black;
            dgvStyleAltRow.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dgvStyleAltRow.SelectionForeColor = System.Drawing.Color.Black;

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(135)))), ((int)(((byte)(55)))));
            this.pnlHeader.Controls.Add(this.lblSubTieuDe);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(744, 62);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(744, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUY ĐỔI ĐƠN VỊ TÍNH CHO SẢN PHẨM";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSubTieuDe
            // 
            this.lblSubTieuDe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSubTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblSubTieuDe.Location = new System.Drawing.Point(0, 32);
            this.lblSubTieuDe.Name = "lblSubTieuDe";
            this.lblSubTieuDe.Size = new System.Drawing.Size(744, 30);
            this.lblSubTieuDe.TabIndex = 1;
            this.lblSubTieuDe.Text = "Sản phẩm: ...";
            this.lblSubTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // grpDonViCoBan
            // 
            this.grpDonViCoBan.Controls.Add(this.lblNoteCoBan);
            this.grpDonViCoBan.Controls.Add(this.txtGiaBanCoBan);
            this.grpDonViCoBan.Controls.Add(this.lblGiaBanCoBan);
            this.grpDonViCoBan.Controls.Add(this.txtGiaNhapCoBan);
            this.grpDonViCoBan.Controls.Add(this.lblGiaNhapCoBan);
            this.grpDonViCoBan.Controls.Add(this.btnThemDVTCoBan);
            this.grpDonViCoBan.Controls.Add(this.cboDonViCoBan);
            this.grpDonViCoBan.Controls.Add(this.lblDonViCoBan);
            this.grpDonViCoBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDonViCoBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpDonViCoBan.Location = new System.Drawing.Point(12, 70);
            this.grpDonViCoBan.Name = "grpDonViCoBan";
            this.grpDonViCoBan.Size = new System.Drawing.Size(720, 105);
            this.grpDonViCoBan.TabIndex = 1;
            this.grpDonViCoBan.TabStop = false;
            this.grpDonViCoBan.Text = "1. ĐƠN VỊ TÍNH CƠ BẢN (Đơn vị nhỏ nhất: Cái, Hộp, Gói, Chai, Kg...)";

            // 
            // lblDonViCoBan
            // 
            this.lblDonViCoBan.AutoSize = true;
            this.lblDonViCoBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonViCoBan.Location = new System.Drawing.Point(15, 30);
            this.lblDonViCoBan.Name = "lblDonViCoBan";
            this.lblDonViCoBan.Size = new System.Drawing.Size(117, 20);
            this.lblDonViCoBan.TabIndex = 0;
            this.lblDonViCoBan.Text = "Đơn vị cơ bản (*):";

            // 
            // cboDonViCoBan
            // 
            this.cboDonViCoBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonViCoBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDonViCoBan.FormattingEnabled = true;
            this.cboDonViCoBan.Location = new System.Drawing.Point(135, 27);
            this.cboDonViCoBan.Name = "cboDonViCoBan";
            this.cboDonViCoBan.Size = new System.Drawing.Size(125, 28);
            this.cboDonViCoBan.TabIndex = 1;
            this.cboDonViCoBan.SelectedIndexChanged += new System.EventHandler(this.cboDonViCoBan_SelectedIndexChanged);

            // 
            // btnThemDVTCoBan
            // 
            this.btnThemDVTCoBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btnThemDVTCoBan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.btnThemDVTCoBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDVTCoBan.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnThemDVTCoBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnThemDVTCoBan.Location = new System.Drawing.Point(265, 27);
            this.btnThemDVTCoBan.Name = "btnThemDVTCoBan";
            this.btnThemDVTCoBan.Size = new System.Drawing.Size(75, 28);
            this.btnThemDVTCoBan.TabIndex = 2;
            this.btnThemDVTCoBan.Text = "+ ĐVT Mới";
            this.btnThemDVTCoBan.UseVisualStyleBackColor = false;
            this.btnThemDVTCoBan.Click += new System.EventHandler(this.btnThemDVTCoBan_Click);

            // 
            // lblGiaNhapCoBan
            // 
            this.lblGiaNhapCoBan.AutoSize = true;
            this.lblGiaNhapCoBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGiaNhapCoBan.Location = new System.Drawing.Point(355, 30);
            this.lblGiaNhapCoBan.Name = "lblGiaNhapCoBan";
            this.lblGiaNhapCoBan.Size = new System.Drawing.Size(73, 20);
            this.lblGiaNhapCoBan.TabIndex = 3;
            this.lblGiaNhapCoBan.Text = "Giá Nhập:";

            // 
            // txtGiaNhapCoBan
            // 
            this.txtGiaNhapCoBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaNhapCoBan.Location = new System.Drawing.Point(430, 27);
            this.txtGiaNhapCoBan.Name = "txtGiaNhapCoBan";
            this.txtGiaNhapCoBan.Size = new System.Drawing.Size(100, 27);
            this.txtGiaNhapCoBan.TabIndex = 4;
            this.txtGiaNhapCoBan.TextChanged += new System.EventHandler(this.txtGiaCoBan_TextChanged);

            // 
            // lblGiaBanCoBan
            // 
            this.lblGiaBanCoBan.AutoSize = true;
            this.lblGiaBanCoBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGiaBanCoBan.Location = new System.Drawing.Point(540, 30);
            this.lblGiaBanCoBan.Name = "lblGiaBanCoBan";
            this.lblGiaBanCoBan.Size = new System.Drawing.Size(63, 20);
            this.lblGiaBanCoBan.TabIndex = 5;
            this.lblGiaBanCoBan.Text = "Giá Bán:";

            // 
            // txtGiaBanCoBan
            // 
            this.txtGiaBanCoBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaBanCoBan.Location = new System.Drawing.Point(605, 27);
            this.txtGiaBanCoBan.Name = "txtGiaBanCoBan";
            this.txtGiaBanCoBan.Size = new System.Drawing.Size(100, 27);
            this.txtGiaBanCoBan.TabIndex = 6;
            this.txtGiaBanCoBan.TextChanged += new System.EventHandler(this.txtGiaCoBan_TextChanged);

            // 
            // lblNoteCoBan
            // 
            this.lblNoteCoBan.AutoSize = true;
            this.lblNoteCoBan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNoteCoBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblNoteCoBan.Location = new System.Drawing.Point(135, 68);
            this.lblNoteCoBan.Name = "lblNoteCoBan";
            this.lblNoteCoBan.Size = new System.Drawing.Size(490, 19);
            this.lblNoteCoBan.TabIndex = 7;
            this.lblNoteCoBan.Text = "ℹ Đơn vị cơ bản có tỉ lệ quy đổi mặc định = 1, là đơn vị dùng để quản lý tổng tồn kho.";

            // 
            // grpDonViQuyDoi
            // 
            this.grpDonViQuyDoi.Controls.Add(this.btnThemQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.txtGiaBanQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.lblGiaBanQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.txtGiaNhapQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.lblGiaNhapQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.lblCongThucLive);
            this.grpDonViQuyDoi.Controls.Add(this.nudSoLuongQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.lblSoLuongQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.btnThemDVTQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.cboDonViQuyDoi);
            this.grpDonViQuyDoi.Controls.Add(this.lblDonViQuyDoi);
            this.grpDonViQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDonViQuyDoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpDonViQuyDoi.Location = new System.Drawing.Point(12, 185);
            this.grpDonViQuyDoi.Name = "grpDonViQuyDoi";
            this.grpDonViQuyDoi.Size = new System.Drawing.Size(720, 150);
            this.grpDonViQuyDoi.TabIndex = 2;
            this.grpDonViQuyDoi.TabStop = false;
            this.grpDonViQuyDoi.Text = "2. THIẾT LẬP ĐƠN VỊ QUY ĐỔI (Đơn vị lớn: Thùng, Lốc, Bao...)";

            // 
            // lblDonViQuyDoi
            // 
            this.lblDonViQuyDoi.AutoSize = true;
            this.lblDonViQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonViQuyDoi.Location = new System.Drawing.Point(15, 30);
            this.lblDonViQuyDoi.Name = "lblDonViQuyDoi";
            this.lblDonViQuyDoi.Size = new System.Drawing.Size(111, 20);
            this.lblDonViQuyDoi.TabIndex = 0;
            this.lblDonViQuyDoi.Text = "Đơn vị quy đổi:";

            // 
            // cboDonViQuyDoi
            // 
            this.cboDonViQuyDoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonViQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDonViQuyDoi.FormattingEnabled = true;
            this.cboDonViQuyDoi.Location = new System.Drawing.Point(135, 27);
            this.cboDonViQuyDoi.Name = "cboDonViQuyDoi";
            this.cboDonViQuyDoi.Size = new System.Drawing.Size(125, 28);
            this.cboDonViQuyDoi.TabIndex = 1;
            this.cboDonViQuyDoi.SelectedIndexChanged += new System.EventHandler(this.cboDonViQuyDoi_SelectedIndexChanged);

            // 
            // btnThemDVTQuyDoi
            // 
            this.btnThemDVTQuyDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btnThemDVTQuyDoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.btnThemDVTQuyDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDVTQuyDoi.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnThemDVTQuyDoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnThemDVTQuyDoi.Location = new System.Drawing.Point(265, 27);
            this.btnThemDVTQuyDoi.Name = "btnThemDVTQuyDoi";
            this.btnThemDVTQuyDoi.Size = new System.Drawing.Size(75, 28);
            this.btnThemDVTQuyDoi.TabIndex = 2;
            this.btnThemDVTQuyDoi.Text = "+ ĐVT Mới";
            this.btnThemDVTQuyDoi.UseVisualStyleBackColor = false;
            this.btnThemDVTQuyDoi.Click += new System.EventHandler(this.btnThemDVTQuyDoi_Click);

            // 
            // lblSoLuongQuyDoi
            // 
            this.lblSoLuongQuyDoi.AutoSize = true;
            this.lblSoLuongQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuongQuyDoi.Location = new System.Drawing.Point(355, 30);
            this.lblSoLuongQuyDoi.Name = "lblSoLuongQuyDoi";
            this.lblSoLuongQuyDoi.Size = new System.Drawing.Size(65, 20);
            this.lblSoLuongQuyDoi.TabIndex = 3;
            this.lblSoLuongQuyDoi.Text = "Bằng số:";

            // 
            // nudSoLuongQuyDoi
            // 
            this.nudSoLuongQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudSoLuongQuyDoi.Location = new System.Drawing.Point(430, 28);
            this.nudSoLuongQuyDoi.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudSoLuongQuyDoi.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.nudSoLuongQuyDoi.Name = "nudSoLuongQuyDoi";
            this.nudSoLuongQuyDoi.Size = new System.Drawing.Size(100, 27);
            this.nudSoLuongQuyDoi.TabIndex = 4;
            this.nudSoLuongQuyDoi.Value = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudSoLuongQuyDoi.ValueChanged += new System.EventHandler(this.nudSoLuongQuyDoi_ValueChanged);

            // 
            // lblCongThucLive
            // 
            this.lblCongThucLive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblCongThucLive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCongThucLive.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCongThucLive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblCongThucLive.Location = new System.Drawing.Point(135, 68);
            this.lblCongThucLive.Name = "lblCongThucLive";
            this.lblCongThucLive.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblCongThucLive.Size = new System.Drawing.Size(570, 30);
            this.lblCongThucLive.TabIndex = 5;
            this.lblCongThucLive.Text = "👉 QUY ĐỔI: 1 Thùng = 10 Hộp";
            this.lblCongThucLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblGiaNhapQuyDoi
            // 
            this.lblGiaNhapQuyDoi.AutoSize = true;
            this.lblGiaNhapQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGiaNhapQuyDoi.Location = new System.Drawing.Point(15, 112);
            this.lblGiaNhapQuyDoi.Name = "lblGiaNhapQuyDoi";
            this.lblGiaNhapQuyDoi.Size = new System.Drawing.Size(73, 20);
            this.lblGiaNhapQuyDoi.TabIndex = 6;
            this.lblGiaNhapQuyDoi.Text = "Giá Nhập:";

            // 
            // txtGiaNhapQuyDoi
            // 
            this.txtGiaNhapQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaNhapQuyDoi.Location = new System.Drawing.Point(135, 108);
            this.txtGiaNhapQuyDoi.Name = "txtGiaNhapQuyDoi";
            this.txtGiaNhapQuyDoi.Size = new System.Drawing.Size(125, 27);
            this.txtGiaNhapQuyDoi.TabIndex = 7;

            // 
            // lblGiaBanQuyDoi
            // 
            this.lblGiaBanQuyDoi.AutoSize = true;
            this.lblGiaBanQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGiaBanQuyDoi.Location = new System.Drawing.Point(280, 112);
            this.lblGiaBanQuyDoi.Name = "lblGiaBanQuyDoi";
            this.lblGiaBanQuyDoi.Size = new System.Drawing.Size(63, 20);
            this.lblGiaBanQuyDoi.TabIndex = 8;
            this.lblGiaBanQuyDoi.Text = "Giá Bán:";

            // 
            // txtGiaBanQuyDoi
            // 
            this.txtGiaBanQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaBanQuyDoi.Location = new System.Drawing.Point(350, 108);
            this.txtGiaBanQuyDoi.Name = "txtGiaBanQuyDoi";
            this.txtGiaBanQuyDoi.Size = new System.Drawing.Size(125, 27);
            this.txtGiaBanQuyDoi.TabIndex = 9;

            // 
            // btnThemQuyDoi
            // 
            this.btnThemQuyDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnThemQuyDoi.FlatAppearance.BorderSize = 0;
            this.btnThemQuyDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemQuyDoi.ForeColor = System.Drawing.Color.White;
            this.btnThemQuyDoi.Location = new System.Drawing.Point(500, 106);
            this.btnThemQuyDoi.Name = "btnThemQuyDoi";
            this.btnThemQuyDoi.Size = new System.Drawing.Size(205, 32);
            this.btnThemQuyDoi.TabIndex = 10;
            this.btnThemQuyDoi.Text = "+ Thêm / Cập Nhật Quy Đổi";
            this.btnThemQuyDoi.UseVisualStyleBackColor = false;
            this.btnThemQuyDoi.Click += new System.EventHandler(this.btnThemQuyDoi_Click);

            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvDonVi);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.grpDanhSach.Location = new System.Drawing.Point(12, 345);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(720, 220);
            this.grpDanhSach.TabIndex = 3;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "3. DANH SÁCH ĐƠN VỊ TÍNH CỦA SẢN PHẨM NÀY";

            // 
            // dgvDonVi
            // 
            this.dgvDonVi.AllowUserToAddRows = false;
            this.dgvDonVi.AllowUserToDeleteRows = false;
            this.dgvDonVi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonVi.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonVi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonVi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonVi.ColumnHeadersDefaultCellStyle = dgvStyleHeader;
            this.dgvDonVi.ColumnHeadersHeight = 32;
            this.dgvDonVi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDonVi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDVT,
            this.colTenDV,
            this.colLoaiDV,
            this.colSoLuongQuyDoi,
            this.colCongThuc,
            this.colDonGiaNhap,
            this.colDonGiaBan,
            this.colXoa});
            this.dgvDonVi.DefaultCellStyle = dgvStyleRow;
            this.dgvDonVi.AlternatingRowsDefaultCellStyle = dgvStyleAltRow;
            this.dgvDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonVi.EnableHeadersVisualStyles = false;
            this.dgvDonVi.Location = new System.Drawing.Point(3, 23);
            this.dgvDonVi.MultiSelect = false;
            this.dgvDonVi.Name = "dgvDonVi";
            this.dgvDonVi.ReadOnly = true;
            this.dgvDonVi.RowHeadersVisible = false;
            this.dgvDonVi.RowTemplate.Height = 28;
            this.dgvDonVi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonVi.Size = new System.Drawing.Size(714, 194);
            this.dgvDonVi.TabIndex = 0;
            this.dgvDonVi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonVi_CellContentClick);

            // 
            // colMaDVT
            // 
            this.colMaDVT.DataPropertyName = "MaDVT";
            this.colMaDVT.HeaderText = "Mã ĐVT";
            this.colMaDVT.Name = "colMaDVT";
            this.colMaDVT.ReadOnly = true;
            this.colMaDVT.Width = 65;

            // 
            // colTenDV
            // 
            this.colTenDV.DataPropertyName = "TenDV";
            this.colTenDV.HeaderText = "Tên ĐVT";
            this.colTenDV.Name = "colTenDV";
            this.colTenDV.ReadOnly = true;
            this.colTenDV.Width = 85;

            // 
            // colLoaiDV
            // 
            this.colLoaiDV.DataPropertyName = "LoaiDV";
            this.colLoaiDV.HeaderText = "Vai Trò";
            this.colLoaiDV.Name = "colLoaiDV";
            this.colLoaiDV.ReadOnly = true;
            this.colLoaiDV.Width = 100;

            // 
            // colSoLuongQuyDoi
            // 
            this.colSoLuongQuyDoi.DataPropertyName = "SoLuongQuyDoi";
            this.colSoLuongQuyDoi.HeaderText = "Tỉ Lệ";
            this.colSoLuongQuyDoi.Name = "colSoLuongQuyDoi";
            this.colSoLuongQuyDoi.ReadOnly = true;
            this.colSoLuongQuyDoi.Width = 60;

            // 
            // colCongThuc
            // 
            this.colCongThuc.DataPropertyName = "CongThuc";
            this.colCongThuc.HeaderText = "Quy Đổi";
            this.colCongThuc.Name = "colCongThuc";
            this.colCongThuc.ReadOnly = true;
            this.colCongThuc.Width = 150;

            // 
            // colDonGiaNhap
            // 
            this.colDonGiaNhap.DataPropertyName = "DonGiaNhap";
            this.colDonGiaNhap.HeaderText = "Giá Nhập";
            this.colDonGiaNhap.Name = "colDonGiaNhap";
            this.colDonGiaNhap.ReadOnly = true;
            this.colDonGiaNhap.Width = 90;

            // 
            // colDonGiaBan
            // 
            this.colDonGiaBan.DataPropertyName = "DonGiaBan";
            this.colDonGiaBan.HeaderText = "Giá Bán";
            this.colDonGiaBan.Name = "colDonGiaBan";
            this.colDonGiaBan.ReadOnly = true;
            this.colDonGiaBan.Width = 90;

            // 
            // colXoa
            // 
            this.colXoa.HeaderText = "Thao tác";
            this.colXoa.Name = "colXoa";
            this.colXoa.ReadOnly = true;
            this.colXoa.Text = "Xóa";
            this.colXoa.UseColumnTextForButtonValue = true;
            this.colXoa.Width = 60;

            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Controls.Add(this.btnLuu);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 580);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(744, 55);
            this.pnlBottom.TabIndex = 4;

            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(135)))), ((int)(((byte)(55)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(460, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(160, 35);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "✔ Lưu & Áp Dụng";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(630, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(95, 35);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            // 
            // FrmQuyDoiDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(744, 635);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpDonViQuyDoi);
            this.Controls.Add(this.grpDonViCoBan);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuyDoiDonVi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quy Đổi Đơn Vị Tính Sản Phẩm";
            this.Load += new System.EventHandler(this.FrmQuyDoiDonVi_Load);
            this.pnlHeader.ResumeLayout(false);
            this.grpDonViCoBan.ResumeLayout(false);
            this.grpDonViCoBan.PerformLayout();
            this.grpDonViQuyDoi.ResumeLayout(false);
            this.grpDonViQuyDoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongQuyDoi)).EndInit();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonVi)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSubTieuDe;
        private System.Windows.Forms.GroupBox grpDonViCoBan;
        private System.Windows.Forms.Label lblDonViCoBan;
        private System.Windows.Forms.ComboBox cboDonViCoBan;
        private System.Windows.Forms.Button btnThemDVTCoBan;
        private System.Windows.Forms.Label lblGiaNhapCoBan;
        private System.Windows.Forms.TextBox txtGiaNhapCoBan;
        private System.Windows.Forms.Label lblGiaBanCoBan;
        private System.Windows.Forms.TextBox txtGiaBanCoBan;
        private System.Windows.Forms.Label lblNoteCoBan;
        private System.Windows.Forms.GroupBox grpDonViQuyDoi;
        private System.Windows.Forms.Label lblDonViQuyDoi;
        private System.Windows.Forms.ComboBox cboDonViQuyDoi;
        private System.Windows.Forms.Button btnThemDVTQuyDoi;
        private System.Windows.Forms.Label lblSoLuongQuyDoi;
        private System.Windows.Forms.NumericUpDown nudSoLuongQuyDoi;
        private System.Windows.Forms.Label lblCongThucLive;
        private System.Windows.Forms.Label lblGiaNhapQuyDoi;
        private System.Windows.Forms.TextBox txtGiaNhapQuyDoi;
        private System.Windows.Forms.Label lblGiaBanQuyDoi;
        private System.Windows.Forms.TextBox txtGiaBanQuyDoi;
        private System.Windows.Forms.Button btnThemQuyDoi;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvDonVi;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongQuyDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCongThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaBan;
        private System.Windows.Forms.DataGridViewButtonColumn colXoa;
    }
}
