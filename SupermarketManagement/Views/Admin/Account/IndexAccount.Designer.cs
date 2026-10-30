namespace SupermarketManagement.Views.Admin.Account
{
    partial class IndexAccount
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.picAvata = new System.Windows.Forms.PictureBox();
            this.lblManv = new System.Windows.Forms.Label();
            this.lblMaTK = new System.Windows.Forms.Label();
            this.btnThayAnh = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassCu = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.btnSuaThongTin = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtPasswordNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXacNhan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuenMK = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvata)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1137, 60);
            this.pnlHeader.TabIndex = 100;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(322, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN TÀI KHOẢN";
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.pnlAvatar.Controls.Add(this.picAvata);
            this.pnlAvatar.Controls.Add(this.lblManv);
            this.pnlAvatar.Controls.Add(this.lblMaTK);
            this.pnlAvatar.Controls.Add(this.btnThayAnh);
            this.pnlAvatar.Location = new System.Drawing.Point(0, 60);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(309, 469);
            this.pnlAvatar.TabIndex = 101;
            // 
            // picAvata
            // 
            this.picAvata.BackColor = System.Drawing.Color.White;
            this.picAvata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvata.Location = new System.Drawing.Point(54, 30);
            this.picAvata.Name = "picAvata";
            this.picAvata.Size = new System.Drawing.Size(200, 200);
            this.picAvata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvata.TabIndex = 0;
            this.picAvata.TabStop = false;
            // 
            // lblManv
            // 
            this.lblManv.AutoSize = true;
            this.lblManv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblManv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblManv.Location = new System.Drawing.Point(40, 248);
            this.lblManv.Name = "lblManv";
            this.lblManv.Size = new System.Drawing.Size(72, 23);
            this.lblManv.TabIndex = 15;
            this.lblManv.Text = "Mã NV :";
            // 
            // lblMaTK
            // 
            this.lblMaTK.AutoSize = true;
            this.lblMaTK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblMaTK.Location = new System.Drawing.Point(40, 278);
            this.lblMaTK.Name = "lblMaTK";
            this.lblMaTK.Size = new System.Drawing.Size(67, 23);
            this.lblMaTK.TabIndex = 16;
            this.lblMaTK.Text = "Mã TK :";
            // 
            // btnThayAnh
            // 
            this.btnThayAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThayAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThayAnh.FlatAppearance.BorderSize = 0;
            this.btnThayAnh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnThayAnh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnThayAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThayAnh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThayAnh.ForeColor = System.Drawing.Color.White;
            this.btnThayAnh.Location = new System.Drawing.Point(54, 333);
            this.btnThayAnh.Name = "btnThayAnh";
            this.btnThayAnh.Size = new System.Drawing.Size(200, 40);
            this.btnThayAnh.TabIndex = 14;
            this.btnThayAnh.Text = "Thay Đổi Ảnh";
            this.btnThayAnh.UseVisualStyleBackColor = false;
            this.btnThayAnh.Click += new System.EventHandler(this.btnThayAnh_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblUserName.Location = new System.Drawing.Point(368, 95);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(120, 25);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "UserName";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserName.Location = new System.Drawing.Point(581, 88);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(439, 32);
            this.txtUserName.TabIndex = 2;
            // 
            // lblPass
            // 
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblPass.Location = new System.Drawing.Point(368, 208);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(139, 25);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Passnew ";
            // 
            // txtPassCu
            // 
            this.txtPassCu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassCu.Enabled = false;
            this.txtPassCu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassCu.Location = new System.Drawing.Point(581, 148);
            this.txtPassCu.Name = "txtPassCu";
            this.txtPassCu.Size = new System.Drawing.Size(439, 32);
            this.txtPassCu.TabIndex = 4;
            this.txtPassCu.UseSystemPasswordChar = true;
            // 
            // lblSDT
            // 
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblSDT.Location = new System.Drawing.Point(368, 315);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(120, 25);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "SĐT";
            // 
            // txtSDT
            // 
            this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSDT.Enabled = false;
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSDT.Location = new System.Drawing.Point(581, 308);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(439, 32);
            this.txtSDT.TabIndex = 6;
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblRole.Location = new System.Drawing.Point(368, 375);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(120, 25);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "Role";
            // 
            // cbRole
            // 
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(784, 366);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(236, 33);
            this.cbRole.TabIndex = 13;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlSeparator.Location = new System.Drawing.Point(420, 431);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(600, 2);
            this.pnlSeparator.TabIndex = 102;
            // 
            // btnSuaThongTin
            // 
            this.btnSuaThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.btnSuaThongTin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaThongTin.FlatAppearance.BorderSize = 0;
            this.btnSuaThongTin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnSuaThongTin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSuaThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSuaThongTin.ForeColor = System.Drawing.Color.White;
            this.btnSuaThongTin.Location = new System.Drawing.Point(315, 463);
            this.btnSuaThongTin.Name = "btnSuaThongTin";
            this.btnSuaThongTin.Size = new System.Drawing.Size(152, 44);
            this.btnSuaThongTin.TabIndex = 18;
            this.btnSuaThongTin.Text = "Sửa Thông Tin";
            this.btnSuaThongTin.UseVisualStyleBackColor = false;
            this.btnSuaThongTin.Click += new System.EventHandler(this.btnSuaThongTin_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Enabled = false;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(487, 463);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(173, 44);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePass.FlatAppearance.BorderSize = 0;
            this.btnChangePass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnChangePass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePass.ForeColor = System.Drawing.Color.White;
            this.btnChangePass.Location = new System.Drawing.Point(666, 463);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(152, 44);
            this.btnChangePass.TabIndex = 20;
            this.btnChangePass.Text = "Đổi Mật Khẩu";
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.MediumPurple;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(999, 463);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(117, 44);
            this.btnThoat.TabIndex = 103;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtRole
            // 
            this.txtRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRole.Enabled = false;
            this.txtRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRole.Location = new System.Drawing.Point(581, 367);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(197, 32);
            this.txtRole.TabIndex = 104;
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordNew.Enabled = false;
            this.txtPasswordNew.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPasswordNew.Location = new System.Drawing.Point(581, 201);
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.Size = new System.Drawing.Size(439, 32);
            this.txtPasswordNew.TabIndex = 106;
            this.txtPasswordNew.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.label1.Location = new System.Drawing.Point(368, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 105;
            this.label1.Text = "Password";
            // 
            // txtXacNhan
            // 
            this.txtXacNhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXacNhan.Enabled = false;
            this.txtXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtXacNhan.Location = new System.Drawing.Point(581, 258);
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.Size = new System.Drawing.Size(439, 32);
            this.txtXacNhan.TabIndex = 108;
            this.txtXacNhan.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.label2.Location = new System.Drawing.Point(368, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 107;
            this.label2.Text = "Xác Nhận";
            // 
            // btnQuenMK
            // 
            this.btnQuenMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnQuenMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuenMK.FlatAppearance.BorderSize = 0;
            this.btnQuenMK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnQuenMK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnQuenMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuenMK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuenMK.ForeColor = System.Drawing.Color.White;
            this.btnQuenMK.Location = new System.Drawing.Point(824, 463);
            this.btnQuenMK.Name = "btnQuenMK";
            this.btnQuenMK.Size = new System.Drawing.Size(159, 44);
            this.btnQuenMK.TabIndex = 109;
            this.btnQuenMK.Text = "Quên Mật Khẩu";
            this.btnQuenMK.UseVisualStyleBackColor = false;
            this.btnQuenMK.Click += new System.EventHandler(this.btnQuenMK_Click);
            // 
            // IndexAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1137, 529);
            this.Controls.Add(this.btnQuenMK);
            this.Controls.Add(this.txtXacNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPasswordNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSuaThongTin);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtPassCu);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pnlAvatar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "IndexAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.Load += new System.EventHandler(this.IndexAccount_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlAvatar.ResumeLayout(false);
            this.pnlAvatar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.PictureBox picAvata;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassCu;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Button btnThayAnh;
        private System.Windows.Forms.Label lblManv;
        private System.Windows.Forms.Label lblMaTK;
        private System.Windows.Forms.Button btnSuaThongTin;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtPasswordNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXacNhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuenMK;
    }
}
