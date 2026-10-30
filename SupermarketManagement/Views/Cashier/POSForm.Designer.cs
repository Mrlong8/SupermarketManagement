using System.Drawing;
using System.Windows.Forms;

namespace SupermarketManagement
{
    partial class POSForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTrai = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTimKiem = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimKiemSP = new System.Windows.Forms.Label();
            this.txtTimKiemSP = new System.Windows.Forms.TextBox();
            this.grpDSSP = new System.Windows.Forms.GroupBox();
            this.dgvDSSP = new System.Windows.Forms.DataGridView();
            this.colMaSP_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaBan_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh_DSSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpDonViTinh = new System.Windows.Forms.TableLayoutPanel();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.cboDonViTinh = new System.Windows.Forms.ComboBox();
            this.lblQuyDoi = new System.Windows.Forms.Label();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.tlpChiTiet = new System.Windows.Forms.TableLayoutPanel();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpThaoTac = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXoaSPKhoiHD = new System.Windows.Forms.Button();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.tlpPhai = new System.Windows.Forms.TableLayoutPanel();
            this.grpKhachHang = new System.Windows.Forms.GroupBox();
            this.tlpKhachHang = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.btnTaoMaKH = new System.Windows.Forms.Button();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDiemTichLuy = new System.Windows.Forms.Label();
            this.txtDiemTichLuy = new System.Windows.Forms.TextBox();
            this.flpNutKH = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.btnTimKiemKH = new System.Windows.Forms.Button();
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.tlpHoaDon = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblDiemSuDung = new System.Windows.Forms.Label();
            this.lblTienGiamGia = new System.Windows.Forms.Label();
            this.txtTienGiamGia = new System.Windows.Forms.TextBox();
            this.lblTienPhaiTra = new System.Windows.Forms.Label();
            this.txtTienPhaiTra = new System.Windows.Forms.TextBox();
            this.grpGiamGia = new System.Windows.Forms.GroupBox();
            this.rdoGiam30 = new System.Windows.Forms.RadioButton();
            this.rdoGiam20 = new System.Windows.Forms.RadioButton();
            this.rdoGiam10 = new System.Windows.Forms.RadioButton();
            this.rdoGiam5 = new System.Windows.Forms.RadioButton();
            this.tlpNut = new System.Windows.Forms.TableLayoutPanel();
            this.btnThemHoaDon = new System.Windows.Forms.Button();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.btnTraHang = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpTrai.SuspendLayout();
            this.tlpTimKiem.SuspendLayout();
            this.grpDSSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSP)).BeginInit();
            this.tlpDonViTinh.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            this.tlpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.flpThaoTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.tlpPhai.SuspendLayout();
            this.grpKhachHang.SuspendLayout();
            this.tlpKhachHang.SuspendLayout();
            this.flpNutKH.SuspendLayout();
            this.grpHoaDon.SuspendLayout();
            this.tlpHoaDon.SuspendLayout();
            this.grpGiamGia.SuspendLayout();
            this.tlpNut.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(181)))), ((int)(((byte)(232)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1600, 70);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Padding = new System.Windows.Forms.Padding(542, 0, 0, 0);
            this.lblTieuDe.Size = new System.Drawing.Size(1000, 70);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ BÁN HÀNG";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblNhanVien.ForeColor = System.Drawing.Color.White;
            this.lblNhanVien.Location = new System.Drawing.Point(1000, 0);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblNhanVien.Size = new System.Drawing.Size(600, 70);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpMain.Controls.Add(this.tlpTrai, 0, 0);
            this.tlpMain.Controls.Add(this.tlpPhai, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 70);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1600, 809);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpTrai
            // 
            this.tlpTrai.ColumnCount = 1;
            this.tlpTrai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrai.Controls.Add(this.tlpTimKiem, 0, 0);
            this.tlpTrai.Controls.Add(this.grpDSSP, 0, 1);
            this.tlpTrai.Controls.Add(this.tlpDonViTinh, 0, 2);
            this.tlpTrai.Controls.Add(this.grpChiTiet, 0, 3);
            this.tlpTrai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTrai.Location = new System.Drawing.Point(15, 15);
            this.tlpTrai.Name = "tlpTrai";
            this.tlpTrai.RowCount = 4;
            this.tlpTrai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpTrai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tlpTrai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpTrai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54F));
            this.tlpTrai.Size = new System.Drawing.Size(971, 779);
            this.tlpTrai.TabIndex = 0;
            // 
            // tlpTimKiem
            // 
            this.tlpTimKiem.ColumnCount = 2;
            this.tlpTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tlpTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimKiem.Controls.Add(this.lblTimKiemSP, 0, 0);
            this.tlpTimKiem.Controls.Add(this.txtTimKiemSP, 1, 0);
            this.tlpTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpTimKiem.Location = new System.Drawing.Point(3, 3);
            this.tlpTimKiem.Name = "tlpTimKiem";
            this.tlpTimKiem.RowCount = 1;
            this.tlpTimKiem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimKiem.Size = new System.Drawing.Size(965, 49);
            this.tlpTimKiem.TabIndex = 0;
            // 
            // lblTimKiemSP
            // 
            this.lblTimKiemSP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimKiemSP.AutoSize = true;
            this.lblTimKiemSP.Location = new System.Drawing.Point(3, 13);
            this.lblTimKiemSP.Name = "lblTimKiemSP";
            this.lblTimKiemSP.Size = new System.Drawing.Size(123, 23);
            this.lblTimKiemSP.TabIndex = 0;
            this.lblTimKiemSP.Text = "Tìm (mã / tên):";
            // 
            // txtTimKiemSP
            // 
            this.txtTimKiemSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiemSP.Location = new System.Drawing.Point(165, 9);
            this.txtTimKiemSP.Name = "txtTimKiemSP";
            this.txtTimKiemSP.Size = new System.Drawing.Size(797, 30);
            this.txtTimKiemSP.TabIndex = 1;
            this.txtTimKiemSP.TextChanged += new System.EventHandler(this.txtTimKiemSP_TextChanged);
            // 
            // grpDSSP
            // 
            this.grpDSSP.BackColor = System.Drawing.Color.White;
            this.grpDSSP.Controls.Add(this.dgvDSSP);
            this.grpDSSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDSSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDSSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.grpDSSP.Location = new System.Drawing.Point(3, 58);
            this.grpDSSP.Name = "grpDSSP";
            this.grpDSSP.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grpDSSP.Size = new System.Drawing.Size(965, 304);
            this.grpDSSP.TabIndex = 1;
            this.grpDSSP.TabStop = false;
            this.grpDSSP.Text = "DANH SÁCH SẢN PHẨM (nhấp đúp để thêm vào hóa đơn)";
            // 
            // dgvDSSP
            // 
            this.dgvDSSP.AllowUserToAddRows = false;
            this.dgvDSSP.AllowUserToDeleteRows = false;
            this.dgvDSSP.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.dgvDSSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSSP.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(181)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSSP.ColumnHeadersHeight = 34;
            this.dgvDSSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDSSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP_DSSP,
            this.colTenSP_DSSP,
            this.colSoLuong_DSSP,
            this.colDonGiaBan_DSSP,
            this.colDonViTinh_DSSP});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSSP.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDSSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSSP.EnableHeadersVisualStyles = false;
            this.dgvDSSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDSSP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.dgvDSSP.Location = new System.Drawing.Point(10, 33);
            this.dgvDSSP.MultiSelect = false;
            this.dgvDSSP.Name = "dgvDSSP";
            this.dgvDSSP.ReadOnly = true;
            this.dgvDSSP.RowHeadersVisible = false;
            this.dgvDSSP.RowHeadersWidth = 62;
            this.dgvDSSP.RowTemplate.Height = 30;
            this.dgvDSSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSSP.Size = new System.Drawing.Size(945, 261);
            this.dgvDSSP.TabIndex = 0;
            this.dgvDSSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSSP_CellClick);
            this.dgvDSSP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSSP_CellDoubleClick);
            this.dgvDSSP.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSSP_CellFormatting);
            this.dgvDSSP.SelectionChanged += new System.EventHandler(this.dgvDSSP_SelectionChanged);
            // 
            // colMaSP_DSSP
            // 
            this.colMaSP_DSSP.DataPropertyName = "MaSP";
            this.colMaSP_DSSP.FillWeight = 20F;
            this.colMaSP_DSSP.HeaderText = "Mã SP";
            this.colMaSP_DSSP.MinimumWidth = 8;
            this.colMaSP_DSSP.Name = "colMaSP_DSSP";
            this.colMaSP_DSSP.ReadOnly = true;
            // 
            // colTenSP_DSSP
            // 
            this.colTenSP_DSSP.DataPropertyName = "TenSanPham";
            this.colTenSP_DSSP.FillWeight = 45F;
            this.colTenSP_DSSP.HeaderText = "Tên sản phẩm";
            this.colTenSP_DSSP.MinimumWidth = 8;
            this.colTenSP_DSSP.Name = "colTenSP_DSSP";
            this.colTenSP_DSSP.ReadOnly = true;
            // 
            // colSoLuong_DSSP
            // 
            this.colSoLuong_DSSP.DataPropertyName = "SoLuong";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.colSoLuong_DSSP.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSoLuong_DSSP.FillWeight = 15F;
            this.colSoLuong_DSSP.HeaderText = "Tồn kho";
            this.colSoLuong_DSSP.MinimumWidth = 8;
            this.colSoLuong_DSSP.Name = "colSoLuong_DSSP";
            this.colSoLuong_DSSP.ReadOnly = true;
            // 
            // colDonGiaBan_DSSP
            // 
            this.colDonGiaBan_DSSP.DataPropertyName = "DonGiaBan";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.colDonGiaBan_DSSP.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDonGiaBan_DSSP.FillWeight = 20F;
            this.colDonGiaBan_DSSP.HeaderText = "Đơn giá bán";
            this.colDonGiaBan_DSSP.MinimumWidth = 8;
            this.colDonGiaBan_DSSP.Name = "colDonGiaBan_DSSP";
            this.colDonGiaBan_DSSP.ReadOnly = true;
            // 
            // colDonViTinh_DSSP
            // 
            this.colDonViTinh_DSSP.DataPropertyName = "DonViTinh";
            this.colDonViTinh_DSSP.FillWeight = 18F;
            this.colDonViTinh_DSSP.HeaderText = "Đơn vị tính";
            this.colDonViTinh_DSSP.MinimumWidth = 8;
            this.colDonViTinh_DSSP.Name = "colDonViTinh_DSSP";
            this.colDonViTinh_DSSP.ReadOnly = true;
            // 
            // tlpDonViTinh
            // 
            this.tlpDonViTinh.ColumnCount = 3;
            this.tlpDonViTinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlpDonViTinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tlpDonViTinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDonViTinh.Controls.Add(this.lblDonViTinh, 0, 0);
            this.tlpDonViTinh.Controls.Add(this.cboDonViTinh, 1, 0);
            this.tlpDonViTinh.Controls.Add(this.lblQuyDoi, 2, 0);
            this.tlpDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDonViTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpDonViTinh.Location = new System.Drawing.Point(3, 365);
            this.tlpDonViTinh.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tlpDonViTinh.Name = "tlpDonViTinh";
            this.tlpDonViTinh.RowCount = 1;
            this.tlpDonViTinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDonViTinh.Size = new System.Drawing.Size(965, 48);
            this.tlpDonViTinh.TabIndex = 3;
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Location = new System.Drawing.Point(2, 12);
            this.lblDonViTinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(98, 23);
            this.lblDonViTinh.TabIndex = 0;
            this.lblDonViTinh.Text = "Đơn vị tính:";
            // 
            // cboDonViTinh
            // 
            this.cboDonViTinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboDonViTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonViTinh.FormattingEnabled = true;
            this.cboDonViTinh.Location = new System.Drawing.Point(127, 8);
            this.cboDonViTinh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboDonViTinh.Name = "cboDonViTinh";
            this.cboDonViTinh.Size = new System.Drawing.Size(142, 31);
            this.cboDonViTinh.TabIndex = 1;
            this.cboDonViTinh.SelectedIndexChanged += new System.EventHandler(this.cboDonViTinh_SelectedIndexChanged_1);
            // 
            // lblQuyDoi
            // 
            this.lblQuyDoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuyDoi.AutoSize = true;
            this.lblQuyDoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblQuyDoi.Location = new System.Drawing.Point(285, 12);
            this.lblQuyDoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuyDoi.Name = "lblQuyDoi";
            this.lblQuyDoi.Size = new System.Drawing.Size(306, 23);
            this.lblQuyDoi.TabIndex = 2;
            this.lblQuyDoi.Text = "Chọn sản phẩm để xem quy đổi đơn vị";
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.BackColor = System.Drawing.Color.White;
            this.grpChiTiet.Controls.Add(this.tlpChiTiet);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.grpChiTiet.Location = new System.Drawing.Point(3, 416);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grpChiTiet.Size = new System.Drawing.Size(965, 360);
            this.grpChiTiet.TabIndex = 2;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // tlpChiTiet
            // 
            this.tlpChiTiet.ColumnCount = 1;
            this.tlpChiTiet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChiTiet.Controls.Add(this.dgvChiTietHoaDon, 0, 0);
            this.tlpChiTiet.Controls.Add(this.flpThaoTac, 0, 1);
            this.tlpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpChiTiet.Location = new System.Drawing.Point(10, 33);
            this.tlpChiTiet.Name = "tlpChiTiet";
            this.tlpChiTiet.RowCount = 2;
            this.tlpChiTiet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChiTiet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tlpChiTiet.Size = new System.Drawing.Size(945, 317);
            this.tlpChiTiet.TabIndex = 0;
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            this.dgvChiTietHoaDon.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.dgvChiTietHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(181)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvChiTietHoaDon.ColumnHeadersHeight = 34;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colTenSP,
            this.colSoLuong,
            this.colDonViTinh,
            this.colDonGia,
            this.colThanhTien});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietHoaDon.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvChiTietHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietHoaDon.EnableHeadersVisualStyles = false;
            this.dgvChiTietHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvChiTietHoaDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(3, 3);
            this.dgvChiTietHoaDon.MultiSelect = false;
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersVisible = false;
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.RowTemplate.Height = 30;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(939, 253);
            this.dgvChiTietHoaDon.TabIndex = 0;
            this.dgvChiTietHoaDon.SelectionChanged += new System.EventHandler(this.dgvChiTietHoaDon_SelectionChanged);
            // 
            // colMaSP
            // 
            this.colMaSP.FillWeight = 15F;
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.MinimumWidth = 8;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.ReadOnly = true;
            // 
            // colTenSP
            // 
            this.colTenSP.FillWeight = 35F;
            this.colTenSP.HeaderText = "Tên sản phẩm";
            this.colTenSP.MinimumWidth = 8;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            // 
            // colSoLuong
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.colSoLuong.DefaultCellStyle = dataGridViewCellStyle8;
            this.colSoLuong.FillWeight = 12F;
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 8;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.FillWeight = 15F;
            this.colDonViTinh.HeaderText = "Đơn vị tính";
            this.colDonViTinh.MinimumWidth = 8;
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            // 
            // colDonGia
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle9;
            this.colDonGia.FillWeight = 19F;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 8;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.colThanhTien.DefaultCellStyle = dataGridViewCellStyle10;
            this.colThanhTien.FillWeight = 19F;
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 8;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // flpThaoTac
            // 
            this.flpThaoTac.Controls.Add(this.btnXoaSPKhoiHD);
            this.flpThaoTac.Controls.Add(this.btnSuaSP);
            this.flpThaoTac.Controls.Add(this.nudSoLuong);
            this.flpThaoTac.Controls.Add(this.lblSoLuong);
            this.flpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThaoTac.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpThaoTac.Location = new System.Drawing.Point(3, 262);
            this.flpThaoTac.Name = "flpThaoTac";
            this.flpThaoTac.Size = new System.Drawing.Size(939, 52);
            this.flpThaoTac.TabIndex = 1;
            this.flpThaoTac.WrapContents = false;
            // 
            // btnXoaSPKhoiHD
            // 
            this.btnXoaSPKhoiHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoaSPKhoiHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaSPKhoiHD.FlatAppearance.BorderSize = 0;
            this.btnXoaSPKhoiHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSPKhoiHD.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaSPKhoiHD.ForeColor = System.Drawing.Color.White;
            this.btnXoaSPKhoiHD.Location = new System.Drawing.Point(774, 8);
            this.btnXoaSPKhoiHD.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.btnXoaSPKhoiHD.Name = "btnXoaSPKhoiHD";
            this.btnXoaSPKhoiHD.Size = new System.Drawing.Size(162, 42);
            this.btnXoaSPKhoiHD.TabIndex = 0;
            this.btnXoaSPKhoiHD.Text = "Xóa sản phẩm";
            this.btnXoaSPKhoiHD.UseVisualStyleBackColor = false;
            this.btnXoaSPKhoiHD.Click += new System.EventHandler(this.btnXoaSPKhoiHD_Click);
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSuaSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaSP.FlatAppearance.BorderSize = 0;
            this.btnSuaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSP.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSuaSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnSuaSP.Location = new System.Drawing.Point(568, 8);
            this.btnSuaSP.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(200, 42);
            this.btnSuaSP.TabIndex = 1;
            this.btnSuaSP.Text = "Cập nhật số lượng";
            this.btnSuaSP.UseVisualStyleBackColor = false;
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click);
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(450, 12);
            this.nudSoLuong.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(112, 30);
            this.nudSoLuong.TabIndex = 2;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudSoLuong_KeyDown);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(328, 17);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(3, 17, 3, 0);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(116, 23);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng mới:";
            // 
            // tlpPhai
            // 
            this.tlpPhai.ColumnCount = 1;
            this.tlpPhai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhai.Controls.Add(this.grpKhachHang, 0, 0);
            this.tlpPhai.Controls.Add(this.grpHoaDon, 0, 1);
            this.tlpPhai.Controls.Add(this.tlpNut, 0, 2);
            this.tlpPhai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPhai.Location = new System.Drawing.Point(992, 15);
            this.tlpPhai.Name = "tlpPhai";
            this.tlpPhai.RowCount = 3;
            this.tlpPhai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 357F));
            this.tlpPhai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tlpPhai.Size = new System.Drawing.Size(593, 779);
            this.tlpPhai.TabIndex = 1;
            // 
            // grpKhachHang
            // 
            this.grpKhachHang.BackColor = System.Drawing.Color.White;
            this.grpKhachHang.Controls.Add(this.tlpKhachHang);
            this.grpKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.grpKhachHang.Location = new System.Drawing.Point(3, 3);
            this.grpKhachHang.Name = "grpKhachHang";
            this.grpKhachHang.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grpKhachHang.Size = new System.Drawing.Size(587, 351);
            this.grpKhachHang.TabIndex = 0;
            this.grpKhachHang.TabStop = false;
            this.grpKhachHang.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // tlpKhachHang
            // 
            this.tlpKhachHang.ColumnCount = 3;
            this.tlpKhachHang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tlpKhachHang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKhachHang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tlpKhachHang.Controls.Add(this.lblMaKH, 0, 0);
            this.tlpKhachHang.Controls.Add(this.txtMaKH, 1, 0);
            this.tlpKhachHang.Controls.Add(this.btnTaoMaKH, 2, 0);
            this.tlpKhachHang.Controls.Add(this.lblTenKH, 0, 1);
            this.tlpKhachHang.Controls.Add(this.txtTenKH, 1, 1);
            this.tlpKhachHang.Controls.Add(this.lblSDT, 0, 2);
            this.tlpKhachHang.Controls.Add(this.txtSDT, 1, 2);
            this.tlpKhachHang.Controls.Add(this.lblEmail, 0, 3);
            this.tlpKhachHang.Controls.Add(this.txtEmail, 1, 3);
            this.tlpKhachHang.Controls.Add(this.lblDiemTichLuy, 0, 4);
            this.tlpKhachHang.Controls.Add(this.txtDiemTichLuy, 1, 4);
            this.tlpKhachHang.Controls.Add(this.flpNutKH, 0, 5);
            this.tlpKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpKhachHang.Location = new System.Drawing.Point(10, 33);
            this.tlpKhachHang.Name = "tlpKhachHang";
            this.tlpKhachHang.RowCount = 6;
            this.tlpKhachHang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpKhachHang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpKhachHang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpKhachHang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpKhachHang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpKhachHang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKhachHang.Size = new System.Drawing.Size(567, 308);
            this.tlpKhachHang.TabIndex = 0;
            // 
            // lblMaKH
            // 
            this.lblMaKH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(3, 11);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(61, 23);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã KH";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtMaKH.Location = new System.Drawing.Point(135, 7);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(272, 30);
            this.txtMaKH.TabIndex = 1;
            // 
            // btnTaoMaKH
            // 
            this.btnTaoMaKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnTaoMaKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoMaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTaoMaKH.FlatAppearance.BorderSize = 0;
            this.btnTaoMaKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMaKH.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTaoMaKH.ForeColor = System.Drawing.Color.White;
            this.btnTaoMaKH.Location = new System.Drawing.Point(413, 3);
            this.btnTaoMaKH.Name = "btnTaoMaKH";
            this.btnTaoMaKH.Size = new System.Drawing.Size(151, 39);
            this.btnTaoMaKH.TabIndex = 2;
            this.btnTaoMaKH.Text = "Tạo mã KH";
            this.btnTaoMaKH.UseVisualStyleBackColor = false;
            this.btnTaoMaKH.Click += new System.EventHandler(this.btnTaoMaKH_Click);
            // 
            // lblTenKH
            // 
            this.lblTenKH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(3, 56);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(62, 23);
            this.lblTenKH.TabIndex = 3;
            this.lblTenKH.Text = "Họ tên";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpKhachHang.SetColumnSpan(this.txtTenKH, 2);
            this.txtTenKH.Location = new System.Drawing.Point(135, 52);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(429, 30);
            this.txtTenKH.TabIndex = 4;
            // 
            // lblSDT
            // 
            this.lblSDT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(3, 101);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(111, 23);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpKhachHang.SetColumnSpan(this.txtSDT, 2);
            this.txtSDT.Location = new System.Drawing.Point(135, 97);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(429, 30);
            this.txtSDT.TabIndex = 6;
            this.txtSDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSDT_KeyDown);
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 146);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 23);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpKhachHang.SetColumnSpan(this.txtEmail, 2);
            this.txtEmail.Location = new System.Drawing.Point(135, 142);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(429, 30);
            this.txtEmail.TabIndex = 8;
            // 
            // lblDiemTichLuy
            // 
            this.lblDiemTichLuy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiemTichLuy.AutoSize = true;
            this.lblDiemTichLuy.Location = new System.Drawing.Point(3, 191);
            this.lblDiemTichLuy.Name = "lblDiemTichLuy";
            this.lblDiemTichLuy.Size = new System.Drawing.Size(110, 23);
            this.lblDiemTichLuy.TabIndex = 9;
            this.lblDiemTichLuy.Text = "Điểm tích lũy";
            // 
            // txtDiemTichLuy
            // 
            this.txtDiemTichLuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiemTichLuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.tlpKhachHang.SetColumnSpan(this.txtDiemTichLuy, 2);
            this.txtDiemTichLuy.Location = new System.Drawing.Point(135, 187);
            this.txtDiemTichLuy.Name = "txtDiemTichLuy";
            this.txtDiemTichLuy.ReadOnly = true;
            this.txtDiemTichLuy.Size = new System.Drawing.Size(429, 30);
            this.txtDiemTichLuy.TabIndex = 10;
            // 
            // flpNutKH
            // 
            this.tlpKhachHang.SetColumnSpan(this.flpNutKH, 3);
            this.flpNutKH.Controls.Add(this.btnThemKH);
            this.flpNutKH.Controls.Add(this.btnTimKiemKH);
            this.flpNutKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNutKH.Location = new System.Drawing.Point(3, 228);
            this.flpNutKH.Name = "flpNutKH";
            this.flpNutKH.Size = new System.Drawing.Size(561, 77);
            this.flpNutKH.TabIndex = 11;
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThemKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemKH.FlatAppearance.BorderSize = 0;
            this.btnThemKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKH.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemKH.ForeColor = System.Drawing.Color.White;
            this.btnThemKH.Location = new System.Drawing.Point(3, 3);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(188, 42);
            this.btnThemKH.TabIndex = 0;
            this.btnThemKH.Text = "Thêm khách hàng";
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // btnTimKiemKH
            // 
            this.btnTimKiemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnTimKiemKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemKH.FlatAppearance.BorderSize = 0;
            this.btnTimKiemKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemKH.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTimKiemKH.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemKH.Location = new System.Drawing.Point(197, 3);
            this.btnTimKiemKH.Name = "btnTimKiemKH";
            this.btnTimKiemKH.Size = new System.Drawing.Size(162, 42);
            this.btnTimKiemKH.TabIndex = 1;
            this.btnTimKiemKH.Text = "Tìm kiếm";
            this.btnTimKiemKH.UseVisualStyleBackColor = false;
            this.btnTimKiemKH.Click += new System.EventHandler(this.btnTimKiemKH_Click);
            // 
            // grpHoaDon
            // 
            this.grpHoaDon.BackColor = System.Drawing.Color.White;
            this.grpHoaDon.Controls.Add(this.tlpHoaDon);
            this.grpHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.grpHoaDon.Location = new System.Drawing.Point(3, 360);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grpHoaDon.Size = new System.Drawing.Size(587, 278);
            this.grpHoaDon.TabIndex = 1;
            this.grpHoaDon.TabStop = false;
            this.grpHoaDon.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // tlpHoaDon
            // 
            this.tlpHoaDon.ColumnCount = 2;
            this.tlpHoaDon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tlpHoaDon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHoaDon.Controls.Add(this.lblMaHD, 0, 0);
            this.tlpHoaDon.Controls.Add(this.txtMaHD, 1, 0);
            this.tlpHoaDon.Controls.Add(this.lblTongTien, 0, 1);
            this.tlpHoaDon.Controls.Add(this.txtTongTien, 1, 1);
            this.tlpHoaDon.Controls.Add(this.lblDiemSuDung, 0, 2);
            this.tlpHoaDon.Controls.Add(this.lblTienGiamGia, 0, 3);
            this.tlpHoaDon.Controls.Add(this.txtTienGiamGia, 1, 3);
            this.tlpHoaDon.Controls.Add(this.lblTienPhaiTra, 0, 4);
            this.tlpHoaDon.Controls.Add(this.txtTienPhaiTra, 1, 4);
            this.tlpHoaDon.Controls.Add(this.grpGiamGia, 1, 2);
            this.tlpHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpHoaDon.Location = new System.Drawing.Point(10, 33);
            this.tlpHoaDon.Name = "tlpHoaDon";
            this.tlpHoaDon.RowCount = 5;
            this.tlpHoaDon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHoaDon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHoaDon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHoaDon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHoaDon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHoaDon.Size = new System.Drawing.Size(567, 235);
            this.tlpHoaDon.TabIndex = 0;
            // 
            // lblMaHD
            // 
            this.lblMaHD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(3, 12);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(103, 23);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã hóa đơn";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtMaHD.Location = new System.Drawing.Point(165, 8);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(399, 30);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(3, 59);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(127, 23);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tổng tiền hàng";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtTongTien.Location = new System.Drawing.Point(165, 55);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(399, 30);
            this.txtTongTien.TabIndex = 3;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDiemSuDung
            // 
            this.lblDiemSuDung.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiemSuDung.AutoSize = true;
            this.lblDiemSuDung.Location = new System.Drawing.Point(3, 106);
            this.lblDiemSuDung.Name = "lblDiemSuDung";
            this.lblDiemSuDung.Size = new System.Drawing.Size(114, 23);
            this.lblDiemSuDung.TabIndex = 4;
            this.lblDiemSuDung.Text = "Mức giảm giá";
            // 
            // lblTienGiamGia
            // 
            this.lblTienGiamGia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTienGiamGia.AutoSize = true;
            this.lblTienGiamGia.Location = new System.Drawing.Point(3, 153);
            this.lblTienGiamGia.Name = "lblTienGiamGia";
            this.lblTienGiamGia.Size = new System.Drawing.Size(113, 23);
            this.lblTienGiamGia.TabIndex = 6;
            this.lblTienGiamGia.Text = "Tiền giảm giá";
            // 
            // txtTienGiamGia
            // 
            this.txtTienGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienGiamGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtTienGiamGia.Location = new System.Drawing.Point(165, 149);
            this.txtTienGiamGia.Name = "txtTienGiamGia";
            this.txtTienGiamGia.ReadOnly = true;
            this.txtTienGiamGia.Size = new System.Drawing.Size(399, 30);
            this.txtTienGiamGia.TabIndex = 7;
            this.txtTienGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTienPhaiTra
            // 
            this.lblTienPhaiTra.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTienPhaiTra.AutoSize = true;
            this.lblTienPhaiTra.Location = new System.Drawing.Point(3, 200);
            this.lblTienPhaiTra.Name = "lblTienPhaiTra";
            this.lblTienPhaiTra.Size = new System.Drawing.Size(121, 23);
            this.lblTienPhaiTra.TabIndex = 8;
            this.lblTienPhaiTra.Text = "Khách phải trả";
            // 
            // txtTienPhaiTra
            // 
            this.txtTienPhaiTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienPhaiTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtTienPhaiTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTienPhaiTra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.txtTienPhaiTra.Location = new System.Drawing.Point(165, 194);
            this.txtTienPhaiTra.Name = "txtTienPhaiTra";
            this.txtTienPhaiTra.ReadOnly = true;
            this.txtTienPhaiTra.Size = new System.Drawing.Size(399, 34);
            this.txtTienPhaiTra.TabIndex = 9;
            this.txtTienPhaiTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpGiamGia
            // 
            this.grpGiamGia.Controls.Add(this.rdoGiam30);
            this.grpGiamGia.Controls.Add(this.rdoGiam20);
            this.grpGiamGia.Controls.Add(this.rdoGiam10);
            this.grpGiamGia.Controls.Add(this.rdoGiam5);
            this.grpGiamGia.Location = new System.Drawing.Point(164, 96);
            this.grpGiamGia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpGiamGia.Name = "grpGiamGia";
            this.grpGiamGia.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpGiamGia.Size = new System.Drawing.Size(398, 43);
            this.grpGiamGia.TabIndex = 10;
            this.grpGiamGia.TabStop = false;
            this.grpGiamGia.Text = "Chọn mức giảm giá";
            // 
            // rdoGiam30
            // 
            this.rdoGiam30.AutoSize = true;
            this.rdoGiam30.Location = new System.Drawing.Point(307, 28);
            this.rdoGiam30.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoGiam30.Name = "rdoGiam30";
            this.rdoGiam30.Size = new System.Drawing.Size(63, 27);
            this.rdoGiam30.TabIndex = 3;
            this.rdoGiam30.TabStop = true;
            this.rdoGiam30.Text = "30%";
            this.rdoGiam30.UseVisualStyleBackColor = true;
            this.rdoGiam30.CheckedChanged += new System.EventHandler(this.rdoGiam30_CheckedChanged);
            // 
            // rdoGiam20
            // 
            this.rdoGiam20.AutoSize = true;
            this.rdoGiam20.Location = new System.Drawing.Point(213, 28);
            this.rdoGiam20.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoGiam20.Name = "rdoGiam20";
            this.rdoGiam20.Size = new System.Drawing.Size(63, 27);
            this.rdoGiam20.TabIndex = 2;
            this.rdoGiam20.TabStop = true;
            this.rdoGiam20.Text = "20%";
            this.rdoGiam20.UseVisualStyleBackColor = true;
            this.rdoGiam20.CheckedChanged += new System.EventHandler(this.rdoGiam20_CheckedChanged);
            // 
            // rdoGiam10
            // 
            this.rdoGiam10.AutoSize = true;
            this.rdoGiam10.Location = new System.Drawing.Point(115, 28);
            this.rdoGiam10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoGiam10.Name = "rdoGiam10";
            this.rdoGiam10.Size = new System.Drawing.Size(63, 27);
            this.rdoGiam10.TabIndex = 1;
            this.rdoGiam10.TabStop = true;
            this.rdoGiam10.Text = "10%";
            this.rdoGiam10.UseVisualStyleBackColor = true;
            this.rdoGiam10.CheckedChanged += new System.EventHandler(this.rdoGiam10_CheckedChanged);
            // 
            // rdoGiam5
            // 
            this.rdoGiam5.AutoSize = true;
            this.rdoGiam5.Location = new System.Drawing.Point(25, 28);
            this.rdoGiam5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoGiam5.Name = "rdoGiam5";
            this.rdoGiam5.Size = new System.Drawing.Size(54, 27);
            this.rdoGiam5.TabIndex = 0;
            this.rdoGiam5.TabStop = true;
            this.rdoGiam5.Text = "5%";
            this.rdoGiam5.UseVisualStyleBackColor = true;
            this.rdoGiam5.CheckedChanged += new System.EventHandler(this.rdoGiam5_CheckedChanged);
            // 
            // tlpNut
            // 
            this.tlpNut.ColumnCount = 2;
            this.tlpNut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNut.Controls.Add(this.btnThemHoaDon, 0, 0);
            this.tlpNut.Controls.Add(this.btnTaoHoaDon, 1, 0);
            this.tlpNut.Controls.Add(this.btnXuatHoaDon, 0, 1);
            this.tlpNut.Controls.Add(this.btnTraHang, 1, 1);
            this.tlpNut.Controls.Add(this.btnThoat, 0, 2);
            this.tlpNut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNut.Location = new System.Drawing.Point(3, 644);
            this.tlpNut.Name = "tlpNut";
            this.tlpNut.RowCount = 3;
            this.tlpNut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.333F));
            this.tlpNut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.333F));
            this.tlpNut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.334F));
            this.tlpNut.Size = new System.Drawing.Size(587, 132);
            this.tlpNut.TabIndex = 2;
            // 
            // btnThemHoaDon
            // 
            this.btnThemHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThemHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThemHoaDon.FlatAppearance.BorderSize = 0;
            this.btnThemHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnThemHoaDon.Location = new System.Drawing.Point(5, 5);
            this.btnThemHoaDon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnThemHoaDon.Name = "btnThemHoaDon";
            this.btnThemHoaDon.Size = new System.Drawing.Size(283, 33);
            this.btnThemHoaDon.TabIndex = 0;
            this.btnThemHoaDon.Text = "Hóa đơn mới";
            this.btnThemHoaDon.UseVisualStyleBackColor = false;
            this.btnThemHoaDon.Click += new System.EventHandler(this.btnThemHoaDon_Click);
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnTaoHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTaoHoaDon.FlatAppearance.BorderSize = 0;
            this.btnTaoHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTaoHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnTaoHoaDon.Location = new System.Drawing.Point(298, 5);
            this.btnTaoHoaDon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(284, 33);
            this.btnTaoHoaDon.TabIndex = 1;
            this.btnTaoHoaDon.Text = "Xem lịch sử hóa đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = false;
            this.btnTaoHoaDon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(181)))), ((int)(((byte)(232)))));
            this.btnXuatHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXuatHoaDon.FlatAppearance.BorderSize = 0;
            this.btnXuatHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXuatHoaDon.Location = new System.Drawing.Point(5, 48);
            this.btnXuatHoaDon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(283, 33);
            this.btnXuatHoaDon.TabIndex = 2;
            this.btnXuatHoaDon.Text = "Xuất hóa đơn";
            this.btnXuatHoaDon.UseVisualStyleBackColor = false;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // btnTraHang
            // 
            this.btnTraHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnTraHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTraHang.FlatAppearance.BorderSize = 0;
            this.btnTraHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTraHang.ForeColor = System.Drawing.Color.White;
            this.btnTraHang.Location = new System.Drawing.Point(298, 48);
            this.btnTraHang.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnTraHang.Name = "btnTraHang";
            this.btnTraHang.Size = new System.Drawing.Size(284, 33);
            this.btnTraHang.TabIndex = 3;
            this.btnTraHang.Text = "Trả hàng";
            this.btnTraHang.UseVisualStyleBackColor = false;
            this.btnTraHang.Click += new System.EventHandler(this.btnTraHang_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.tlpNut.SetColumnSpan(this.btnThoat, 2);
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(5, 91);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(577, 36);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Đăng xuất";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1600, 879);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1369, 797);
            this.Name = "POSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ BÁN HÀNG";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpTrai.ResumeLayout(false);
            this.tlpTimKiem.ResumeLayout(false);
            this.tlpTimKiem.PerformLayout();
            this.grpDSSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSP)).EndInit();
            this.tlpDonViTinh.ResumeLayout(false);
            this.tlpDonViTinh.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            this.tlpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.flpThaoTac.ResumeLayout(false);
            this.flpThaoTac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.tlpPhai.ResumeLayout(false);
            this.grpKhachHang.ResumeLayout(false);
            this.tlpKhachHang.ResumeLayout(false);
            this.tlpKhachHang.PerformLayout();
            this.flpNutKH.ResumeLayout(false);
            this.grpHoaDon.ResumeLayout(false);
            this.tlpHoaDon.ResumeLayout(false);
            this.tlpHoaDon.PerformLayout();
            this.grpGiamGia.ResumeLayout(false);
            this.grpGiamGia.PerformLayout();
            this.tlpNut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblNhanVien;

        private TableLayoutPanel tlpMain;
        private TableLayoutPanel tlpTrai;
        private TableLayoutPanel tlpPhai;

        private TableLayoutPanel tlpTimKiem;
        private Label lblTimKiemSP;
        private TextBox txtTimKiemSP;
        private TableLayoutPanel tlpDonViTinh;
        private Label lblDonViTinh;
        private ComboBox cboDonViTinh;
        private Label lblQuyDoi;
        private GroupBox grpDSSP;
        private DataGridView dgvDSSP;
        private DataGridViewTextBoxColumn colMaSP_DSSP;
        private DataGridViewTextBoxColumn colTenSP_DSSP;
        private DataGridViewTextBoxColumn colSoLuong_DSSP;
        private DataGridViewTextBoxColumn colDonGiaBan_DSSP;
        private DataGridViewTextBoxColumn colDonViTinh_DSSP;

        private GroupBox grpChiTiet;
        private TableLayoutPanel tlpChiTiet;
        private DataGridView dgvChiTietHoaDon;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
        private DataGridViewTextBoxColumn colDonViTinh;
        private FlowLayoutPanel flpThaoTac;
        private Button btnXoaSPKhoiHD;
        private Button btnSuaSP;
        private NumericUpDown nudSoLuong;
        private Label lblSoLuong;

        private GroupBox grpKhachHang;
        private TableLayoutPanel tlpKhachHang;
        private Label lblMaKH;
        private TextBox txtMaKH;
        private Button btnTaoMaKH;
        private Label lblTenKH;
        private TextBox txtTenKH;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblDiemTichLuy;
        private TextBox txtDiemTichLuy;
        private FlowLayoutPanel flpNutKH;
        private Button btnThemKH;
        private Button btnTimKiemKH;

        private GroupBox grpHoaDon;
        private TableLayoutPanel tlpHoaDon;
        private Label lblMaHD;
        private TextBox txtMaHD;
        private Label lblTongTien;
        private TextBox txtTongTien;
        private Label lblDiemSuDung;
        private Label lblTienGiamGia;
        private TextBox txtTienGiamGia;
        private Label lblTienPhaiTra;
        private TextBox txtTienPhaiTra;

        private TableLayoutPanel tlpNut;
        private Button btnThemHoaDon;
        private Button btnTaoHoaDon;
        private Button btnXuatHoaDon;
        private Button btnTraHang;
        private Button btnThoat;
        private GroupBox grpGiamGia;
        private RadioButton rdoGiam30;
        private RadioButton rdoGiam20;
        private RadioButton rdoGiam10;
        private RadioButton rdoGiam5;
    }
}