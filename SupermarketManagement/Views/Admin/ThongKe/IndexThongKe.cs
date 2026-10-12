using OfficeOpenXml;
using OfficeOpenXml.Style;
using SupermarketManagement.Models.Repositories;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SupermarketManagement.Views.Admin.ThongKe
{
    public partial class IndexThongKe : Form
    {
        private ThongKeRepository _repo = new ThongKeRepository();

        public IndexThongKe()
        {
            InitializeComponent();
        }

        private void IndexThongKe_Load(object sender, EventArgs e)
        {
            // Cấu hình DateTimePicker hiển thị Tháng/Năm
            dtpThoiGian.Format = DateTimePickerFormat.Custom;
            dtpThoiGian.CustomFormat = "MM/yyyy";
            dtpThoiGian.ShowUpDown = true;

            LoadThongKeData();
        }

        private void LoadThongKeData()
        {
            DateTime selectedDate = dtpThoiGian.Value;
            int thang = selectedDate.Month;
            int nam = selectedDate.Year;

            // 1. Load Biểu đồ Doanh Thu Theo Ngày trong Tháng
            decimal tongDoanhThu = LoadChartDoanhThuTheoNgay(thang, nam);

            // 2. Load Biểu đồ Vốn Nhập Theo Ngày trong Tháng
            decimal tongVonNhap = LoadChartVonNhapTheoNgay(thang, nam);

            // 3. Tính Lợi Nhuận và hiển thị tổng số của Tháng
            decimal tongLoiNhuan = tongDoanhThu - tongVonNhap;

            lblTongDoanhThu.Text = $"Tổng Doanh Thu: {tongDoanhThu:N0} VNĐ";
            lblTongVonNhap.Text = $"Tổng Vốn Nhập: {tongVonNhap:N0} VNĐ";
            lblTongLoiNhuan.Text = $"Tổng Lợi Nhuận: {tongLoiNhuan:N0} VNĐ";
        }

        // --- VẼ BIỂU ĐỒ 1: DOANH THU BÁN HÀNG THEO NGÀY ---
        private decimal LoadChartDoanhThuTheoNgay(int thang, int nam)
        {
            DataTable dtData = _repo.GetDoanhThuTheoNgayInThang(thang, nam);
            decimal tongDoanhThu = 0;

            chartNgay.Series.Clear();
            chartNgay.Titles.Clear();

            Title title = new Title($"THỐNG KÊ DOANH THU THEO NGÀY (THÁNG {thang}/{nam})",
                                    Docking.Top, new Font("Segoe UI", 10, FontStyle.Bold), Color.DarkBlue);
            chartNgay.Titles.Add(title);

            Series seriesDoanhThu = new Series("Doanh Thu");
            seriesDoanhThu.ChartType = SeriesChartType.Column;
            seriesDoanhThu.Color = Color.FromArgb(0, 122, 204);

            if (dtData != null && dtData.Rows.Count > 0)
            {
                foreach (DataRow row in dtData.Rows)
                {
                    string ngayLabel = "D" + row["Ngay"].ToString();
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                    tongDoanhThu += doanhThu;

                    seriesDoanhThu.Points.AddXY(ngayLabel, (double)doanhThu);
                }
            }

            chartNgay.Series.Add(seriesDoanhThu);

            ChartArea area = chartNgay.ChartAreas[0];
            area.AxisY.LabelStyle.Format = "#,##0";
            area.AxisX.Interval = 1;

            return tongDoanhThu;
        }

        // --- VẼ BIỂU ĐỒ 2: VỐN NHẬP HÀNG THEO NGÀY ---
        private decimal LoadChartVonNhapTheoNgay(int thang, int nam)
        {
            DataTable dtData = _repo.GetVonNhapTheoNgayInThang(thang, nam);
            decimal tongVonNhap = 0;

            chartThang.Series.Clear();
            chartThang.Titles.Clear();

            Title title = new Title($"THỐNG KÊ VỐN NHẬP HÀNG THEO NGÀY (THÁNG {thang}/{nam})",
                                    Docking.Top, new Font("Segoe UI", 10, FontStyle.Bold), Color.DarkRed);
            chartThang.Titles.Add(title);

            Series seriesVonNhap = new Series("Vốn Nhập");
            seriesVonNhap.ChartType = SeriesChartType.Column;
            seriesVonNhap.Color = Color.FromArgb(220, 53, 69);

            if (dtData != null && dtData.Rows.Count > 0)
            {
                foreach (DataRow row in dtData.Rows)
                {
                    string ngayLabel = "D" + row["Ngay"].ToString();
                    decimal vonNhap = Convert.ToDecimal(row["VonNhap"]);
                    tongVonNhap += vonNhap;

                    seriesVonNhap.Points.AddXY(ngayLabel, (double)vonNhap);
                }
            }

            chartThang.Series.Add(seriesVonNhap);

            ChartArea area = chartThang.ChartAreas[0];
            area.AxisY.LabelStyle.Format = "#,##0";
            area.AxisX.Interval = 1;

            return tongVonNhap;
        }

        // Sự kiện khi chọn lại Tháng/Năm trên DateTimePicker
        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            LoadThongKeData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpThoiGian.Value;
            int thang = selectedDate.Month;
            int nam = selectedDate.Year;

            // 1. Lấy dữ liệu chi tiết doanh thu và vốn nhập theo ngày từ Repository
            DataTable dtDoanhThu = _repo.GetDoanhThuTheoNgayInThang(thang, nam);
            DataTable dtVonNhap = _repo.GetVonNhapTheoNgayInThang(thang, nam);

            if (dtDoanhThu == null || dtDoanhThu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thống kê để xuất file Excel!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mở hộp thoại chọn vị trí lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = $"BaoCaoThongKe_T{thang}_{nam}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatBaoCaoThongKeRaExcel(saveFileDialog.FileName, dtDoanhThu, dtVonNhap, thang, nam);
                    MessageBox.Show("Xuất file Excel báo cáo thống kê thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void XuatBaoCaoThongKeRaExcel(string filePath, DataTable dtDoanhThu, DataTable dtVonNhap, int thang, int nam)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;// Cấu hình bản quyền EPPlus miễn phí

            using (ExcelPackage package = new ExcelPackage())
            {
                // Tạo một Worksheet mới
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add($"ThongKe_T{thang}_{nam}");

                // --- 1. TIÊU ĐỀ BÁO CÁO ---
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1"].Value = $"BÁO CÁO THỐNG KÊ DOANH THU & VỐN NHẬP (THÁNG {thang}/{nam})";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.Font.Color.SetColor(Color.DarkBlue);
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A2:D2"].Merge = true;
                worksheet.Cells["A2"].Value = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Cells["A2"].Style.Font.Italic = true;
                worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // --- 2. HEADER BẢNG DỮ LIỆU ---
                worksheet.Cells["A4"].Value = "Ngày";
                worksheet.Cells["B4"].Value = "Doanh Thu (VNĐ)";
                worksheet.Cells["C4"].Value = "Vốn Nhập (VNĐ)";
                worksheet.Cells["D4"].Value = "Lợi Nhuận (VNĐ)";

                using (var range = worksheet.Cells["A4:D4"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 122, 204)); // Màu xanh chủ đạo
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // --- 3. ĐỔ DỮ LIỆU CHI TIẾT THEO NGÀY ---
                int currentRow = 5;
                decimal tongDoanhThu = 0;
                decimal tongVonNhap = 0;

                for (int i = 0; i < dtDoanhThu.Rows.Count; i++)
                {
                    int ngay = Convert.ToInt32(dtDoanhThu.Rows[i]["Ngay"]);
                    decimal doanhThu = Convert.ToDecimal(dtDoanhThu.Rows[i]["DoanhThu"]);
                    decimal vonNhap = Convert.ToDecimal(dtVonNhap.Rows[i]["VonNhap"]);
                    decimal loiNhuan = doanhThu - vonNhap;

                    tongDoanhThu += doanhThu;
                    tongVonNhap += vonNhap;

                    worksheet.Cells[currentRow, 1].Value = $"Ngày {ngay:D2}/{thang:D2}/{nam}";
                    worksheet.Cells[currentRow, 2].Value = doanhThu;
                    worksheet.Cells[currentRow, 3].Value = vonNhap;
                    worksheet.Cells[currentRow, 4].Value = loiNhuan;

                    // Định dạng số tiền
                    worksheet.Cells[currentRow, 2].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[currentRow, 3].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[currentRow, 4].Style.Numberformat.Format = "#,##0";

                    // Căn chỉnh
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    currentRow++;
                }

                // --- 4. DÒNG TỔNG CỘNG ---
                worksheet.Cells[currentRow, 1].Value = "TỔNG CỘNG";
                worksheet.Cells[currentRow, 2].Value = tongDoanhThu;
                worksheet.Cells[currentRow, 3].Value = tongVonNhap;
                worksheet.Cells[currentRow, 4].Value = tongDoanhThu - tongVonNhap;

                using (var range = worksheet.Cells[currentRow, 1, currentRow, 4])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 230, 230));
                }

                worksheet.Cells[currentRow, 2].Style.Numberformat.Format = "#,##0";
                worksheet.Cells[currentRow, 3].Style.Numberformat.Format = "#,##0";
                worksheet.Cells[currentRow, 4].Style.Numberformat.Format = "#,##0";

                // Kẻ viền (Border) cho toàn bộ bảng
                using (var range = worksheet.Cells[4, 1, currentRow, 4])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                // Tự động căn chỉnh độ rộng cột
                worksheet.Cells.AutoFitColumns();

                // Lưu file
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }
    }
}