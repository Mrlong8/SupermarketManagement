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

            lblTongDoanhThuThang.Text = $"Tổng Doanh Thu: {tongDoanhThu:N0} VNĐ";
            lblTongVonNhapThang.Text = $"Tổng Vốn Nhập: {tongVonNhap:N0} VNĐ";
            lblTongLoiNhuanThang.Text = $"Tổng Lợi Nhuận: {tongLoiNhuan:N0} VNĐ";

            // 4. Thống kê cả năm
            LoadThongKeNam(nam);
        }

        private void LoadThongKeNam(int nam)
        {
            decimal doanhThuNam = _repo.GetTongDoanhThuNam(nam);
            decimal vonNhapNam = _repo.GetTongVonNhapNam(nam);
            decimal loiNhuanNam = doanhThuNam - vonNhapNam;

            groupBox2.Text = $"Doanh thu theo năm {nam}";
            lblTongDoanhThuNam.Text = $"Tổng Doanh Thu: {doanhThuNam:N0} VNĐ";
            lblTongVonNhapNam.Text = $"Tổng Vốn Nhập: {vonNhapNam:N0} VNĐ";
            lblTongLoiNhuanNam.Text = $"Tổng Lợi Nhuận: {loiNhuanNam:N0} VNĐ";
        }

        private decimal VeBieuDoCot(Chart chart, DataTable dt, string cotGiaTri, string tenSeries,
                            string tieuDe, Color mauTieuDe, Color mauCot)
        {
            decimal tong = 0;
            double max = 0;

            chart.Series.Clear();
            chart.Titles.Clear();
            chart.Legends.Clear();   // bỏ chú thích "Vốn Nhập"/"Doanh Thu" vì đã có tiêu đề

            chart.Titles.Add(new Title(tieuDe, Docking.Top,
                                       new Font("Segoe UI", 10, FontStyle.Bold), mauTieuDe));

            Series s = new Series(tenSeries);
            s.ChartType = SeriesChartType.Column;
            s.Color = mauCot;
            s["PointWidth"] = "0.7";                       // độ rộng cột

            // Hiện số tiền trên đầu cột
            s.IsValueShownAsLabel = true;
            s.LabelFormat = "#,##0";
            s.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            s.LabelForeColor = Color.FromArgb(60, 60, 60);
            s.SmartLabelStyle.Enabled = false;
            s["LabelStyle"] = "Top";
            s.LabelAngle = -90;                            // xoay dọc để 31 cột không đè chữ lên nhau

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    decimal giaTri = Convert.ToDecimal(row[cotGiaTri]);
                    tong += giaTri;

                    int idx = s.Points.AddXY(row["Ngay"].ToString(), (double)giaTri);
                    if (giaTri == 0)
                        s.Points[idx].IsValueShownAsLabel = false;   // ngày không có tiền thì không hiện số 0

                    max = Math.Max(max, (double)giaTri);
                }
            }

            chart.Series.Add(s);

            // --- Giao diện vùng vẽ ---
            ChartArea area = chart.ChartAreas[0];
            area.BackColor = Color.White;

            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.IsStaggered = false;     // nhãn ngày nằm trên 1 hàng
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisX.MajorGrid.Enabled = false;          // bỏ các đường dọc đen
            area.AxisX.LineColor = Color.Gray;
            area.AxisX.Title = "Ngày";
            area.AxisX.TitleFont = new Font("Segoe UI", 8, FontStyle.Italic);

            area.AxisY.LabelStyle.Format = "#,##0";
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;      // lưới ngang mờ
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.LineColor = Color.Gray;
            area.AxisY.Minimum = 0;

            // Chừa chỗ phía trên để số tiền của cột cao nhất không bị cắt
            area.AxisY.Maximum = max > 0 ? max * 1.4 : double.NaN;

            return tong;
        }

        // --- VẼ BIỂU ĐỒ 1: DOANH THU BÁN HÀNG THEO NGÀY ---
        private decimal LoadChartDoanhThuTheoNgay(int thang, int nam)
        {
            DataTable dt = _repo.GetDoanhThuTheoNgayInThang(thang, nam);
            return VeBieuDoCot(chartNgay, dt, "DoanhThu", "Doanh Thu",
                               $"THỐNG KÊ DOANH THU THEO NGÀY (THÁNG {thang}/{nam})",
                               Color.DarkBlue, Color.FromArgb(0, 122, 204));
        }

        private decimal LoadChartVonNhapTheoNgay(int thang, int nam)
        {
            DataTable dt = _repo.GetVonNhapTheoNgayInThang(thang, nam);
            return VeBieuDoCot(chartThang, dt, "VonNhap", "Vốn Nhập",
                               $"THỐNG KÊ VỐN NHẬP HÀNG THEO NGÀY (THÁNG {thang}/{nam})",
                               Color.DarkRed, Color.FromArgb(220, 53, 69));
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

            // Repository luôn trả về đủ các ngày trong tháng nên phải kiểm tra tổng tiền mới biết có dữ liệu hay không
            decimal tongDT = 0, tongVN = 0;
            if (dtDoanhThu != null)
                foreach (DataRow r in dtDoanhThu.Rows) tongDT += Convert.ToDecimal(r["DoanhThu"]);
            if (dtVonNhap != null)
                foreach (DataRow r in dtVonNhap.Rows) tongVN += Convert.ToDecimal(r["VonNhap"]);

            if (dtDoanhThu == null || dtVonNhap == null || dtDoanhThu.Rows.Count == 0 || (tongDT == 0 && tongVN == 0))
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

        // Xuất Excel đơn giản, KHÔNG dùng màu: chỉ có chữ đậm, căn lề, định dạng số và viền.
        private void XuatBaoCaoThongKeRaExcel(string filePath, DataTable dtDoanhThu, DataTable dtVonNhap, int thang, int nam)
        {
            // EPPlus 8+: khai báo giấy phép phi thương mại (dùng cho học tập / cá nhân)
            ExcelPackage.License.SetNonCommercialPersonal("SupermarketManagement");

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add($"ThongKe_T{thang}_{nam}");

                // --- 1. TIÊU ĐỀ BÁO CÁO ---
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1"].Value = $"BÁO CÁO THỐNG KÊ DOANH THU & VỐN NHẬP (THÁNG {thang}/{nam})";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
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

                worksheet.Cells[currentRow, 1, currentRow, 4].Style.Font.Bold = true;
                worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
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