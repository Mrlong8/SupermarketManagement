namespace SupermarketManagement.Views.Admin.Product
{
    partial class IndexProduct
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
            this.product = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // product
            // 
            this.product.Location = new System.Drawing.Point(249, 169);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(189, 121);
            this.product.TabIndex = 0;
            this.product.Text = "product";
            this.product.UseVisualStyleBackColor = true;
            // 
            // IndexProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.product);
            this.Name = "IndexProduct";
            this.Text = "IndexProduct";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button product;
    }
}