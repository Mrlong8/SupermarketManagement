namespace SupermarketManagement.Views.Admin
{
    partial class Frm_Admin
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
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.pnlMainAdmin = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnManagerCustom = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManagerProduct = new System.Windows.Forms.Button();
            this.btnManageUser = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlSideBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.pnlSideBar.Controls.Add(this.button1);
            this.pnlSideBar.Controls.Add(this.btnThongKe);
            this.pnlSideBar.Controls.Add(this.btnManagerCustom);
            this.pnlSideBar.Controls.Add(this.btnLogout);
            this.pnlSideBar.Controls.Add(this.btnManagerProduct);
            this.pnlSideBar.Controls.Add(this.btnManageUser);
            this.pnlSideBar.Controls.Add(this.btnAccount);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(290, 767);
            this.pnlSideBar.TabIndex = 1;
            // 
            // pnlMainAdmin
            // 
            this.pnlMainAdmin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlMainAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainAdmin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlMainAdmin.Location = new System.Drawing.Point(0, 60);
            this.pnlMainAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainAdmin.Name = "pnlMainAdmin";
            this.pnlMainAdmin.Size = new System.Drawing.Size(1291, 707);
            this.pnlMainAdmin.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlMainAdmin, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlHeader, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(290, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1291, 767);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1291, 60);
            this.pnlHeader.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1291, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMIN DASHBOARD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlSideBar, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1581, 767);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThongKe.Image = global::SupermarketManagement.Properties.Resources.analytics;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(0, 276);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThongKe.Size = new System.Drawing.Size(290, 55);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "   Thống kê doanh số";
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // btnManagerCustom
            // 
            this.btnManagerCustom.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagerCustom.FlatAppearance.BorderSize = 0;
            this.btnManagerCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerCustom.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagerCustom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManagerCustom.Image = global::SupermarketManagement.Properties.Resources.customer;
            this.btnManagerCustom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagerCustom.Location = new System.Drawing.Point(0, 221);
            this.btnManagerCustom.Name = "btnManagerCustom";
            this.btnManagerCustom.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnManagerCustom.Size = new System.Drawing.Size(290, 55);
            this.btnManagerCustom.TabIndex = 6;
            this.btnManagerCustom.Text = "   Quản Lý Khách Hàng";
            this.btnManagerCustom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManagerCustom.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Image = global::SupermarketManagement.Properties.Resources.logout1;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 717);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(290, 50);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "        Đăng Xuất";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnManagerProduct
            // 
            this.btnManagerProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagerProduct.FlatAppearance.BorderSize = 0;
            this.btnManagerProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerProduct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagerProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManagerProduct.Image = global::SupermarketManagement.Properties.Resources.box3;
            this.btnManagerProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagerProduct.Location = new System.Drawing.Point(0, 166);
            this.btnManagerProduct.Name = "btnManagerProduct";
            this.btnManagerProduct.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnManagerProduct.Size = new System.Drawing.Size(290, 55);
            this.btnManagerProduct.TabIndex = 2;
            this.btnManagerProduct.Text = "   Quản Lý Hàng Hóa";
            this.btnManagerProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManagerProduct.UseVisualStyleBackColor = true;
            this.btnManagerProduct.Click += new System.EventHandler(this.btnManagerProduct_Click);
            // 
            // btnManageUser
            // 
            this.btnManageUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageUser.FlatAppearance.BorderSize = 0;
            this.btnManageUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageUser.Image = global::SupermarketManagement.Properties.Resources.user;
            this.btnManageUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageUser.Location = new System.Drawing.Point(0, 111);
            this.btnManageUser.Name = "btnManageUser";
            this.btnManageUser.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnManageUser.Size = new System.Drawing.Size(290, 55);
            this.btnManageUser.TabIndex = 2;
            this.btnManageUser.Text = "   Quản Lý Người Dùng";
            this.btnManageUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageUser.UseVisualStyleBackColor = true;
            this.btnManageUser.Click += new System.EventHandler(this.btnManageUser_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccount.Image = global::SupermarketManagement.Properties.Resources.profile;
            this.btnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.Location = new System.Drawing.Point(0, 0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAccount.Size = new System.Drawing.Size(290, 111);
            this.btnAccount.TabIndex = 1;
            this.btnAccount.Text = "   User Profile";
            this.btnAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccount.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::SupermarketManagement.Properties.Resources.invoice;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 331);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(290, 55);
            this.button1.TabIndex = 8;
            this.button1.Text = "   Lịch Sử Mua Hàng";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Frm_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 767);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Frm_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supermarket Management System";
            this.pnlSideBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Button btnManageUser;
        private System.Windows.Forms.Button btnManagerProduct;
        private System.Windows.Forms.Panel pnlMainAdmin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManagerCustom;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button button1;
    }
}