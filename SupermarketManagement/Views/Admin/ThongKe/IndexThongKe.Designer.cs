namespace SupermarketManagement.Views.Admin.ThongKe
{
    partial class IndexThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartNgay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chartThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTongVonNhap = new System.Windows.Forms.Label();
            this.lblTongLoiNhuan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThang)).BeginInit();
            this.SuspendLayout();
            // 
            // chartNgay
            // 
            this.chartNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartNgay.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartNgay.Legends.Add(legend1);
            this.chartNgay.Location = new System.Drawing.Point(51, 37);
            this.chartNgay.Name = "chartNgay";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartNgay.Series.Add(series1);
            this.chartNgay.Size = new System.Drawing.Size(1167, 214);
            this.chartNgay.TabIndex = 0;
            this.chartNgay.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thống kê doanh thu theo ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 551);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thống kê vốn nhâp hàng theo tháng";
            // 
            // chartThang
            // 
            chartArea2.Name = "ChartArea1";
            this.chartThang.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartThang.Legends.Add(legend2);
            this.chartThang.Location = new System.Drawing.Point(51, 314);
            this.chartThang.Name = "chartThang";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartThang.Series.Add(series2);
            this.chartThang.Size = new System.Drawing.Size(643, 214);
            this.chartThang.TabIndex = 4;
            this.chartThang.Text = "chart4";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(130)))), ((int)(((byte)(48)))));
            this.btnXuatExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(55)))));
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(51, 603);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(165, 36);
            this.btnXuatExcel.TabIndex = 9;
            this.btnXuatExcel.Text = "Xuất File EXcel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpThoiGian.Location = new System.Drawing.Point(273, 610);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(229, 22);
            this.dtpThoiGian.TabIndex = 11;
            this.dtpThoiGian.ValueChanged += new System.EventHandler(this.dtpThoiGian_ValueChanged);
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(728, 353);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(205, 31);
            this.lblTongDoanhThu.TabIndex = 12;
            this.lblTongDoanhThu.Text = "Tổng Doanh Thu: ";
            // 
            // lblTongVonNhap
            // 
            this.lblTongVonNhap.AutoSize = true;
            this.lblTongVonNhap.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongVonNhap.ForeColor = System.Drawing.Color.Crimson;
            this.lblTongVonNhap.Location = new System.Drawing.Point(728, 402);
            this.lblTongVonNhap.Name = "lblTongVonNhap";
            this.lblTongVonNhap.Size = new System.Drawing.Size(194, 31);
            this.lblTongVonNhap.TabIndex = 13;
            this.lblTongVonNhap.Text = "Tổng Vốn Nhập: ";
            // 
            // lblTongLoiNhuan
            // 
            this.lblTongLoiNhuan.AutoSize = true;
            this.lblTongLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLoiNhuan.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTongLoiNhuan.Location = new System.Drawing.Point(728, 452);
            this.lblTongLoiNhuan.Name = "lblTongLoiNhuan";
            this.lblTongLoiNhuan.Size = new System.Drawing.Size(198, 31);
            this.lblTongLoiNhuan.TabIndex = 14;
            this.lblTongLoiNhuan.Text = "Tổng Lợi Nhuận: ";
            // 
            // IndexThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 660);
            this.Controls.Add(this.lblTongLoiNhuan);
            this.Controls.Add(this.lblTongVonNhap);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Controls.Add(this.dtpThoiGian);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chartThang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartNgay);
            this.Name = "IndexThongKe";
            this.Text = "IndexThongKe";
            this.Load += new System.EventHandler(this.IndexThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThang;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblTongVonNhap;
        private System.Windows.Forms.Label lblTongLoiNhuan;
    }
}