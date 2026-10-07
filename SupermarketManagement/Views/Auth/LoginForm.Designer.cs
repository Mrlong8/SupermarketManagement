namespace SupermarketManagement.Views.Auth
{
    partial class LoginForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.chkHienMK = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(30, 85);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(110, 25);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Tên đăng nhập:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(145, 82);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(195, 27);
            this.txtUser.TabIndex = 2;
            // 
            // lblPass
            // 
            this.lblPass.Location = new System.Drawing.Point(30, 130);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(110, 25);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Mật khẩu:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(145, 127);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(195, 27);
            this.txtPass.TabIndex = 4;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // chkHienMK
            // 
            this.chkHienMK.Location = new System.Drawing.Point(145, 160);
            this.chkHienMK.Name = "chkHienMK";
            this.chkHienMK.Size = new System.Drawing.Size(195, 25);
            this.chkHienMK.TabIndex = 5;
            this.chkHienMK.Text = "Hiện mật khẩu";
            this.chkHienMK.UseVisualStyleBackColor = true;
            this.chkHienMK.CheckedChanged += new System.EventHandler(this.chkHienMK_CheckedChanged);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(60, 210);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(120, 38);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(200, 210);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 38);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(380, 290);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.chkHienMK);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.btnThoat);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkHienMK;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
    }
}