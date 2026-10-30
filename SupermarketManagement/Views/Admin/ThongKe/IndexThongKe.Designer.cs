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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartNgay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.lblTongDoanhThuThang = new System.Windows.Forms.Label();
            this.lblTongVonNhapThang = new System.Windows.Forms.Label();
            this.lblTongLoiNhuanThang = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTongVonNhapNam = new System.Windows.Forms.Label();
            this.lblTongLoiNhuanNam = new System.Windows.Forms.Label();
            this.lblTongDoanhThuNam = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chartThongKeTraHang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeTraHang)).BeginInit();
            this.SuspendLayout();
            // 
            // chartNgay
            // 
            chartArea1.Name = "ChartArea1";
            this.chartNgay.ChartAreas.Add(chartArea1);
            this.chartNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartNgay.Legends.Add(legend1);
            this.chartNgay.Location = new System.Drawing.Point(3, 18);
            this.chartNgay.Name = "chartNgay";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartNgay.Series.Add(series1);
            this.chartNgay.Size = new System.Drawing.Size(1202, 212);
            this.chartNgay.TabIndex = 0;
            this.chartNgay.Text = "chart1";
            // 
            // chartThang
            // 
            chartArea2.Name = "ChartArea1";
            this.chartThang.ChartAreas.Add(chartArea2);
            this.chartThang.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartThang.Legends.Add(legend2);
            this.chartThang.Location = new System.Drawing.Point(3, 3);
            this.chartThang.Name = "chartThang";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartThang.Series.Add(series2);
            this.chartThang.Size = new System.Drawing.Size(595, 205);
            this.chartThang.TabIndex = 4;
            this.chartThang.Text = "chart4";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(114)))), ((int)(((byte)(69)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(30, 569);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(180, 45);
            this.btnXuatExcel.TabIndex = 9;
            this.btnXuatExcel.Text = "Xuất File Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpThoiGian.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGian.Location = new System.Drawing.Point(30, 519);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(260, 30);
            this.dtpThoiGian.TabIndex = 11;
            this.dtpThoiGian.ValueChanged += new System.EventHandler(this.dtpThoiGian_ValueChanged);
            // 
            // lblTongDoanhThuThang
            // 
            this.lblTongDoanhThuThang.AutoSize = true;
            this.lblTongDoanhThuThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThuThang.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTongDoanhThuThang.Location = new System.Drawing.Point(20, 35);
            this.lblTongDoanhThuThang.Name = "lblTongDoanhThuThang";
            this.lblTongDoanhThuThang.Size = new System.Drawing.Size(181, 28);
            this.lblTongDoanhThuThang.TabIndex = 12;
            this.lblTongDoanhThuThang.Text = "Tổng Doanh Thu: ";
            // 
            // lblTongVonNhapThang
            // 
            this.lblTongVonNhapThang.AutoSize = true;
            this.lblTongVonNhapThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongVonNhapThang.ForeColor = System.Drawing.Color.Crimson;
            this.lblTongVonNhapThang.Location = new System.Drawing.Point(20, 70);
            this.lblTongVonNhapThang.Name = "lblTongVonNhapThang";
            this.lblTongVonNhapThang.Size = new System.Drawing.Size(171, 28);
            this.lblTongVonNhapThang.TabIndex = 13;
            this.lblTongVonNhapThang.Text = "Tổng Vốn Nhập: ";
            // 
            // lblTongLoiNhuanThang
            // 
            this.lblTongLoiNhuanThang.AutoSize = true;
            this.lblTongLoiNhuanThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLoiNhuanThang.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTongLoiNhuanThang.Location = new System.Drawing.Point(20, 105);
            this.lblTongLoiNhuanThang.Name = "lblTongLoiNhuanThang";
            this.lblTongLoiNhuanThang.Size = new System.Drawing.Size(175, 28);
            this.lblTongLoiNhuanThang.TabIndex = 14;
            this.lblTongLoiNhuanThang.Text = "Tổng Lợi Nhuận: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblTongVonNhapThang);
            this.groupBox1.Controls.Add(this.lblTongLoiNhuanThang);
            this.groupBox1.Controls.Add(this.lblTongDoanhThuThang);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(801, 540);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 150);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê theo tháng";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lblTongVonNhapNam);
            this.groupBox2.Controls.Add(this.lblTongLoiNhuanNam);
            this.groupBox2.Controls.Add(this.lblTongDoanhThuNam);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(391, 540);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 150);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doanh thu theo năm";
            // 
            // lblTongVonNhapNam
            // 
            this.lblTongVonNhapNam.AutoSize = true;
            this.lblTongVonNhapNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongVonNhapNam.ForeColor = System.Drawing.Color.Crimson;
            this.lblTongVonNhapNam.Location = new System.Drawing.Point(20, 70);
            this.lblTongVonNhapNam.Name = "lblTongVonNhapNam";
            this.lblTongVonNhapNam.Size = new System.Drawing.Size(171, 28);
            this.lblTongVonNhapNam.TabIndex = 13;
            this.lblTongVonNhapNam.Text = "Tổng Vốn Nhập: ";
            // 
            // lblTongLoiNhuanNam
            // 
            this.lblTongLoiNhuanNam.AutoSize = true;
            this.lblTongLoiNhuanNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLoiNhuanNam.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTongLoiNhuanNam.Location = new System.Drawing.Point(20, 105);
            this.lblTongLoiNhuanNam.Name = "lblTongLoiNhuanNam";
            this.lblTongLoiNhuanNam.Size = new System.Drawing.Size(175, 28);
            this.lblTongLoiNhuanNam.TabIndex = 14;
            this.lblTongLoiNhuanNam.Text = "Tổng Lợi Nhuận: ";
            // 
            // lblTongDoanhThuNam
            // 
            this.lblTongDoanhThuNam.AutoSize = true;
            this.lblTongDoanhThuNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThuNam.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTongDoanhThuNam.Location = new System.Drawing.Point(20, 35);
            this.lblTongDoanhThuNam.Name = "lblTongDoanhThuNam";
            this.lblTongDoanhThuNam.Size = new System.Drawing.Size(181, 28);
            this.lblTongDoanhThuNam.TabIndex = 12;
            this.lblTongDoanhThuNam.Text = "Tổng Doanh Thu: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1208, 232);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thống nhập hàng kê theo ngày";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chartNgay);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 241);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1208, 233);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thống kê doanh thu theo ngày";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1214, 477);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.chartThongKeTraHang, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chartThang, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1202, 211);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // chartThongKeTraHang
            // 
            chartArea3.Name = "ChartArea1";
            this.chartThongKeTraHang.ChartAreas.Add(chartArea3);
            this.chartThongKeTraHang.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartThongKeTraHang.Legends.Add(legend3);
            this.chartThongKeTraHang.Location = new System.Drawing.Point(604, 3);
            this.chartThongKeTraHang.Name = "chartThongKeTraHang";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartThongKeTraHang.Series.Add(series3);
            this.chartThongKeTraHang.Size = new System.Drawing.Size(595, 205);
            this.chartThongKeTraHang.TabIndex = 5;
            this.chartThongKeTraHang.Text = "chart4";
            // 
            // IndexThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1273, 725);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpThoiGian);
            this.Controls.Add(this.btnXuatExcel);
            this.Name = "IndexThongKe";
            this.Text = "Thống Kê Doanh Thu";
            this.Load += new System.EventHandler(this.IndexThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeTraHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartNgay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThang;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Label lblTongDoanhThuThang;
        private System.Windows.Forms.Label lblTongVonNhapThang;
        private System.Windows.Forms.Label lblTongLoiNhuanThang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTongVonNhapNam;
        private System.Windows.Forms.Label lblTongLoiNhuanNam;
        private System.Windows.Forms.Label lblTongDoanhThuNam;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeTraHang;
    }
}