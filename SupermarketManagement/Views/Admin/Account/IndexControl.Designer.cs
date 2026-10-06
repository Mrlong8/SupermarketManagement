namespace SupermarketManagement.Views.Account
{
    partial class IndexControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListAccount = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListAccount
            // 
            this.dgvListAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListAccount.Location = new System.Drawing.Point(70, 71);
            this.dgvListAccount.Name = "dgvListAccount";
            this.dgvListAccount.RowHeadersWidth = 51;
            this.dgvListAccount.RowTemplate.Height = 24;
            this.dgvListAccount.Size = new System.Drawing.Size(950, 350);
            this.dgvListAccount.TabIndex = 0;
            // 
            // IndexControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvListAccount);
            this.Name = "IndexControl";
            this.Size = new System.Drawing.Size(1100, 600);
            this.Load += new System.EventHandler(this.IndexControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListAccount;
    }
}
