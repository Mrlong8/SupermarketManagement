namespace SupermarketManagement.Views.Admin.Product
{
    partial class ProductItemControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblGiaNhap = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pctbImageItem = new System.Windows.Forms.PictureBox();
            this.btnSuaItem = new System.Windows.Forms.Button();
            this.btnXoaItem = new System.Windows.Forms.Button();
            this.lblGiaBan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctbImageItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenSP
            // 
            this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTenSP.Location = new System.Drawing.Point(6, 142);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(206, 38);
            this.lblTenSP.TabIndex = 1;
            this.lblTenSP.Text = "Tên Sản Phẩm";
            this.lblTenSP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGiaNhap
            // 
            this.lblGiaNhap.AutoSize = true;
            this.lblGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaNhap.ForeColor = System.Drawing.Color.Crimson;
            this.lblGiaNhap.Location = new System.Drawing.Point(10, 185);
            this.lblGiaNhap.Name = "lblGiaNhap";
            this.lblGiaNhap.Size = new System.Drawing.Size(44, 20);
            this.lblGiaNhap.TabIndex = 2;
            this.lblGiaNhap.Text = "Giá : ";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.DimGray;
            this.lblSoLuong.Location = new System.Drawing.Point(8, 247);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(83, 20);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số Lượng : ";
            // 
            // pctbImageItem
            // 
            this.pctbImageItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pctbImageItem.Location = new System.Drawing.Point(5, 5);
            this.pctbImageItem.Name = "pctbImageItem";
            this.pctbImageItem.Size = new System.Drawing.Size(200, 130);
            this.pctbImageItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctbImageItem.TabIndex = 0;
            this.pctbImageItem.TabStop = false;
            // 
            // btnSuaItem
            // 
            this.btnSuaItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSuaItem.FlatAppearance.BorderSize = 0;
            this.btnSuaItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaItem.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaItem.ForeColor = System.Drawing.Color.White;
            this.btnSuaItem.Location = new System.Drawing.Point(12, 280);
            this.btnSuaItem.Name = "btnSuaItem";
            this.btnSuaItem.Size = new System.Drawing.Size(88, 30);
            this.btnSuaItem.TabIndex = 4;
            this.btnSuaItem.Text = "Sửa";
            this.btnSuaItem.UseVisualStyleBackColor = false;
            this.btnSuaItem.Click += new System.EventHandler(this.btnSuaItem_Click);
            // 
            // btnXoaItem
            // 
            this.btnXoaItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoaItem.FlatAppearance.BorderSize = 0;
            this.btnXoaItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaItem.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaItem.ForeColor = System.Drawing.Color.White;
            this.btnXoaItem.Location = new System.Drawing.Point(114, 280);
            this.btnXoaItem.Name = "btnXoaItem";
            this.btnXoaItem.Size = new System.Drawing.Size(88, 30);
            this.btnXoaItem.TabIndex = 5;
            this.btnXoaItem.Text = "Xóa";
            this.btnXoaItem.UseVisualStyleBackColor = false;
            this.btnXoaItem.Click += new System.EventHandler(this.btnXoaItem_Click);
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaBan.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblGiaBan.Location = new System.Drawing.Point(10, 218);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(44, 20);
            this.lblGiaBan.TabIndex = 6;
            this.lblGiaBan.Text = "Giá : ";
            // 
            // ProductItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.btnXoaItem);
            this.Controls.Add(this.btnSuaItem);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblGiaNhap);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.pctbImageItem);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProductItemControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(210, 324);
            ((System.ComponentModel.ISupportInitialize)(this.pctbImageItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctbImageItem;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblGiaNhap;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Button btnSuaItem;
        private System.Windows.Forms.Button btnXoaItem;
        private System.Windows.Forms.Label lblGiaBan;
    }
}