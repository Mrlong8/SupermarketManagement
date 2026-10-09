namespace SupermarketManagement.Views.Admin.ChucVu
{
    partial class IndexChucVu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMaCV = new System.Windows.Forms.Label();
            this.txtMaCV = new System.Windows.Forms.TextBox();
            this.lblTenCV = new System.Windows.Forms.Label();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.txtHeSoLuong = new System.Windows.Forms.TextBox();
            this.lblHeSoLuong = new System.Windows.Forms.Label();
            this.lblCaLamViec = new System.Windows.Forms.Label();
            this.rdbFullTime = new System.Windows.Forms.RadioButton();
            this.rdbPartTime = new System.Windows.Forms.RadioButton();
            this.dgvListChucVu = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChucVu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaCV
            // 
            this.lblMaCV.AutoSize = true;
            this.lblMaCV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaCV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.lblMaCV.Location = new System.Drawing.Point(40, 50);
            this.lblMaCV.Name = "lblMaCV";
            this.lblMaCV.Size = new System.Drawing.Size(94, 21);
            this.lblMaCV.TabIndex = 0;
            this.lblMaCV.Text = "Mã Chức Vụ";
            // 
            // txtMaCV
            // 
            this.txtMaCV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaCV.Location = new System.Drawing.Point(150, 47);
            this.txtMaCV.Name = "txtMaCV";
            this.txtMaCV.Size = new System.Drawing.Size(200, 29);
            this.txtMaCV.TabIndex = 1;
            // 
            // lblTenCV
            // 
            this.lblTenCV.AutoSize = true;
            this.lblTenCV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTenCV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.lblTenCV.Location = new System.Drawing.Point(40, 110);
            this.lblTenCV.Name = "lblTenCV";
            this.lblTenCV.Size = new System.Drawing.Size(95, 21);
            this.lblTenCV.TabIndex = 2;
            this.lblTenCV.Text = "Tên Chức Vụ";
            // 
            // txtTenCV
            // 
            this.txtTenCV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTenCV.Location = new System.Drawing.Point(150, 107);
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(200, 29);
            this.txtTenCV.TabIndex = 3;
            // 
            // txtHeSoLuong
            // 
            this.txtHeSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtHeSoLuong.Location = new System.Drawing.Point(150, 167);
            this.txtHeSoLuong.Name = "txtHeSoLuong";
            this.txtHeSoLuong.ReadOnly = true;
            this.txtHeSoLuong.Size = new System.Drawing.Size(200, 29);
            this.txtHeSoLuong.TabIndex = 5;
            // 
            // lblHeSoLuong
            // 
            this.lblHeSoLuong.AutoSize = true;
            this.lblHeSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.lblHeSoLuong.Location = new System.Drawing.Point(40, 170);
            this.lblHeSoLuong.Name = "lblHeSoLuong";
            this.lblHeSoLuong.Size = new System.Drawing.Size(100, 21);
            this.lblHeSoLuong.TabIndex = 4;
            this.lblHeSoLuong.Text = "Hệ Số Lương";
            // 
            // lblCaLamViec
            // 
            this.lblCaLamViec.AutoSize = true;
            this.lblCaLamViec.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCaLamViec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.lblCaLamViec.Location = new System.Drawing.Point(40, 230);
            this.lblCaLamViec.Name = "lblCaLamViec";
            this.lblCaLamViec.Size = new System.Drawing.Size(95, 21);
            this.lblCaLamViec.TabIndex = 6;
            this.lblCaLamViec.Text = "Ca Làm Việc";
            // 
            // rdbFullTime
            // 
            this.rdbFullTime.AutoSize = true;
            this.rdbFullTime.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdbFullTime.Location = new System.Drawing.Point(150, 228);
            this.rdbFullTime.Name = "rdbFullTime";
            this.rdbFullTime.Size = new System.Drawing.Size(94, 25);
            this.rdbFullTime.TabIndex = 7;
            this.rdbFullTime.TabStop = true;
            this.rdbFullTime.Text = "Full Time";
            this.rdbFullTime.UseVisualStyleBackColor = true;
            this.rdbFullTime.CheckedChanged += new System.EventHandler(this.rdbFullTime_CheckedChanged);
            // 
            // rdbPartTime
            // 
            this.rdbPartTime.AutoSize = true;
            this.rdbPartTime.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdbPartTime.Location = new System.Drawing.Point(255, 228);
            this.rdbPartTime.Name = "rdbPartTime";
            this.rdbPartTime.Size = new System.Drawing.Size(96, 25);
            this.rdbPartTime.TabIndex = 8;
            this.rdbPartTime.TabStop = true;
            this.rdbPartTime.Text = "Part Time";
            this.rdbPartTime.UseVisualStyleBackColor = true;
            this.rdbPartTime.CheckedChanged += new System.EventHandler(this.rdbPartTime_CheckedChanged);
            // 
            // dgvListChucVu
            // 
            this.dgvListChucVu.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvListChucVu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListChucVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListChucVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListChucVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvListChucVu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListChucVu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(230)))));
            this.dgvListChucVu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvListChucVu.ColumnHeadersHeight = 35;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListChucVu.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvListChucVu.EnableHeadersVisualStyles = false;
            this.dgvListChucVu.Location = new System.Drawing.Point(390, 47);
            this.dgvListChucVu.MultiSelect = false;
            this.dgvListChucVu.Name = "dgvListChucVu";
            this.dgvListChucVu.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListChucVu.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvListChucVu.RowHeadersVisible = false;
            this.dgvListChucVu.RowHeadersWidth = 51;
            this.dgvListChucVu.RowTemplate.Height = 32;
            this.dgvListChucVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListChucVu.Size = new System.Drawing.Size(430, 280);
            this.dgvListChucVu.TabIndex = 9;
            this.dgvListChucVu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListChucVu_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(40, 310);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 36);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(150, 310);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 36);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(260, 310);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 36);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(725, 350);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(95, 36);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // CreateChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(851, 410);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvListChucVu);
            this.Controls.Add(this.rdbPartTime);
            this.Controls.Add(this.rdbFullTime);
            this.Controls.Add(this.lblCaLamViec);
            this.Controls.Add(this.txtHeSoLuong);
            this.Controls.Add(this.lblHeSoLuong);
            this.Controls.Add(this.txtTenCV);
            this.Controls.Add(this.lblTenCV);
            this.Controls.Add(this.txtMaCV);
            this.Controls.Add(this.lblMaCV);
            this.Name = "CreateChucVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chức Vụ";
            this.Load += new System.EventHandler(this.CreateChucVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChucVu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaCV;
        private System.Windows.Forms.TextBox txtMaCV;
        private System.Windows.Forms.Label lblTenCV;
        private System.Windows.Forms.TextBox txtTenCV;
        private System.Windows.Forms.TextBox txtHeSoLuong;
        private System.Windows.Forms.Label lblHeSoLuong;
        private System.Windows.Forms.Label lblCaLamViec;
        private System.Windows.Forms.RadioButton rdbFullTime;
        private System.Windows.Forms.RadioButton rdbPartTime;
        private System.Windows.Forms.DataGridView dgvListChucVu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
    }
}