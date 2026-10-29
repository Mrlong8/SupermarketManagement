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

            // 3. Load Biểu đồ Trả Hàng Theo Ngày trong Tháng
            decimal tongTienTra = LoadChartTraHangTheoNgay(thang, nam);

            // 4. Tính Lợi Nhuận và hiển thị tổng số của Tháng
            decimal tongLoiNhuan = tongDoanhThu - tongVonNhap;

            lblTongDoanhThuThang.Text = $"Tổng Doanh Thu: {tongDoanhThu:N0} VNĐ";
            lblTongVonNhapThang.Text = $"Tổng Vốn Nhập: {tongVonNhap:N0} VNĐ";
            lblTongLoiNhuanThang.Text = $"Tổng Lợi Nhuận: {tongLoiNhuan:N0} VNĐ";

            // Hiển thị thêm Tổng Tiền Trả nếu trên giao diện có Label tương ứng
            // lblTongTienTraThang.Text = $"Tổng Trả Hàng: {tongTienTra:N0} VNĐ";

            // 5. Thống kê cả năm
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
            chart.Legends.Clear();   // bỏ chú thích vì đã có tiêu đề

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
            s.LabelAngle = -90;                            // xoay dọc để các cột không đè chữ

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
            area.AxisX.MajorGrid.Enabled = false;          // bỏ đường dọc
            area.AxisX.LineColor = Color.Gray;
            area.AxisX.Title = "Ngày";
            area.AxisX.TitleFont = new Font("Segoe UI", 8, FontStyle.Italic);

            area.AxisY.LabelStyle.Format = "#,##0";
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;      // lưới ngang mờ
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.LineColor = Color.Gray;
            area.AxisY.Minimum = 0;

            // Chừa chỗ phía trên để số tiền không bị cắt
            area.AxisY.Maximum = max > 0 ? max * 1.4 : double.NaN;

            return tong;
        }

        // --- VẼ BIỂU ĐỒ 1: DOANH THU BÁN HÀNG THEO NGÀY ---
        private decimal LoadChartDoanhThuTheoNgay(int thang, int nam)
        {
            DataTable dt = _repo.GetDoanhThuTheoNgayInThang(thang, nam);
            return VeBieuDoCot(chartNgay, dt, "DoanhThu", "Doanh Thu",
                               $"THỐNG KÊ DOANH THU THUẦN THEO NGÀY (THÁNG {thang}/{nam})",
                               Color.DarkBlue, Color.FromArgb(0, 122, 204));
        }

        // --- VẼ BIỂU ĐỒ 2: VỐN NHẬP HÀNG THEO NGÀY ---
        private decimal LoadChartVonNhapTheoNgay(int thang, int nam)
        {
            DataTable dt = _repo.GetVonNhapTheoNgayInThang(thang, nam);
            return VeBieuDoCot(chartThang, dt, "VonNhap", "Vốn Nhập",
                               $"THỐNG KÊ VỐN NHẬP HÀNG THEO NGÀY (THÁNG {thang}/{nam})",
                               Color.DarkRed, Color.FromArgb(220, 53, 69));
        }

        // --- VẼ BIỂU ĐỒ 3: GIÁ TRỊ TRẢ HÀNG THEO NGÀY ---
        private decimal LoadChartTraHangTheoNgay(int thang, int nam)
        {
            DataTable dt = _repo.GetTienTraTheoNgayInThang(thang, nam);
            return VeBieuDoCot(chartThongKeTraHang, dt, "TienTra", "Tiền Trả",
                               $"THỐNG KÊ GIÁ TRỊ TRẢ HÀNG THEO NGÀY (THÁNG {thang}/{nam})",
                               Color.DarkOrange, Color.FromArgb(255, 152, 0));
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

            // 1. Lấy dữ liệu chi tiết theo ngày
            DataTable dtDoanhThu = _repo.GetDoanhThuTheoNgayInThang(thang, nam);
            DataTable dtVonNhap = _repo.GetVonNhapTheoNgayInThang(thang, nam);
            DataTable dtTienTra = _repo.GetTienTraTheoNgayInThang(thang, nam);

            // 2. Lấy dữ liệu tổng quan cả năm
            decimal doanhThuNam = _repo.GetTongDoanhThuNam(nam);
            decimal vonNhapNam = _repo.GetTongVonNhapNam(nam);

            if (dtDoanhThu == null || dtVonNhap == null || dtTienTra == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu thống kê!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Mở hộp thoại chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = $"BaoCaoThongKe_TongHop_T{thang}_{nam}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatBaoCaoThongKeRaExcel(saveFileDialog.FileName, dtDoanhThu, dtVonNhap, dtTienTra, thang, nam, doanhThuNam, vonNhapNam);
                    MessageBox.Show("Xuất file Excel báo cáo thống kê tổng hợp thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm xuất Excel chuyên nghiệp chứa đầy đủ thông tin năm, tháng và ngày
        private void XuatBaoCaoThongKeRaExcel(string filePath, DataTable dtDoanhThu, DataTable dtVonNhap, DataTable dtTienTra,
                                             int thang, int nam, decimal doanhThuNam, decimal vonNhapNam)
        {
            ExcelPackage.License.SetNonCommercialPersonal("SupermarketManagement");

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add($"ThongKe_T{thang}_{nam}");

                // ==========================================
                // 1. TIÊU ĐỀ CHÍNH BÁO CÁO
                // ==========================================
                worksheet.Cells["A1:E1"].Merge = true;
                worksheet.Cells["A1"].Value = $"BÁO CÁO THỐNG KÊ TỔNG HỢP DOANH THU & VỐN NHẬP";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A2:E2"].Merge = true;
                worksheet.Cells["A2"].Value = $"Kỳ báo cáo: Tháng {thang}/{nam} | Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Cells["A2"].Style.Font.Italic = true;
                worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // ==========================================
                // 2. KHỐI TỔNG QUAN NĂM & THÁNG
                // ==========================================
                // --- Cột 1: Thống kê cả năm ---
                worksheet.Cells["A4:B4"].Merge = true;
                worksheet.Cells["A4"].Value = $"1. THỐNG KÊ THEO NĂM {nam}";
                worksheet.Cells["A4"].Style.Font.Bold = true;

                worksheet.Cells["A5"].Value = "Tổng Doanh Thu Cả Năm:";
                worksheet.Cells["B5"].Value = doanhThuNam;
                worksheet.Cells["A6"].Value = "Tổng Vốn Nhập Cả Năm:";
                worksheet.Cells["B6"].Value = vonNhapNam;
                worksheet.Cells["A7"].Value = "Tổng Lợi Nhuận Cả Năm:";
                worksheet.Cells["B7"].Value = doanhThuNam - vonNhapNam;

                // --- Cột 2: Thống kê trong tháng ---
                worksheet.Cells["D4:E4"].Merge = true;
                worksheet.Cells["D4"].Value = $"2. THỐNG KÊ THEO THÁNG {thang}/{nam}";
                worksheet.Cells["D4"].Style.Font.Bold = true;

                // Tính tổng tiền trong tháng
                decimal tongDoanhThuThang = 0, tongVonNhapThang = 0, tongTienTraThang = 0;
                for (int i = 0; i < dtDoanhThu.Rows.Count; i++)
                {
                    tongDoanhThuThang += Convert.ToDecimal(dtDoanhThu.Rows[i]["DoanhThu"]);
                    tongVonNhapThang += Convert.ToDecimal(dtVonNhap.Rows[i]["VonNhap"]);
                    tongTienTraThang += Convert.ToDecimal(dtTienTra.Rows[i]["TienTra"]);
                }

                worksheet.Cells["D5"].Value = "Tổng Doanh Thu Thuần Tháng:";
                worksheet.Cells["E5"].Value = tongDoanhThuThang;
                worksheet.Cells["D6"].Value = "Tổng Vốn Nhập Tháng:";
                worksheet.Cells["E6"].Value = tongVonNhapThang;
                worksheet.Cells["D7"].Value = "Tổng Giá Trị Trả Hàng:";
                worksheet.Cells["E7"].Value = tongTienTraThang;
                worksheet.Cells["D8"].Value = "Tổng Lợi Nhuận Tháng:";
                worksheet.Cells["E8"].Value = tongDoanhThuThang - tongVonNhapThang;

                // Định dạng tiền tệ cho khối tổng quan
                worksheet.Cells["B5:B7"].Style.Numberformat.Format = "#,##0";
                worksheet.Cells["E5:E8"].Style.Numberformat.Format = "#,##0";
                worksheet.Cells["B5:B7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["E5:E8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                // ==========================================
                // 3. BẢNG CHI TIẾT THEO NGÀY
                // ==========================================
                int startRow = 10;
                worksheet.Cells[startRow, 1].Value = "3. CHI TIẾT THỐNG KÊ THEO NGÀY TRONG THÁNG";
                worksheet.Cells[startRow, 1].Style.Font.Bold = true;

                int headerRow = startRow + 1;
                worksheet.Cells[headerRow, 1].Value = "Ngày";
                worksheet.Cells[headerRow, 2].Value = "Doanh Thu Thuần (VNĐ)";
                worksheet.Cells[headerRow, 3].Value = "Vốn Nhập Hàng (VNĐ)";
                worksheet.Cells[headerRow, 4].Value = "Giá Trị Trả Hàng (VNĐ)";
                worksheet.Cells[headerRow, 5].Value = "Lợi Nhuận Trong Ngày (VNĐ)";

                using (var range = worksheet.Cells[headerRow, 1, headerRow, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // Đổ từng dòng dữ liệu theo ngày
                int currentRow = headerRow + 1;
                for (int i = 0; i < dtDoanhThu.Rows.Count; i++)
                {
                    int ngay = Convert.ToInt32(dtDoanhThu.Rows[i]["Ngay"]);
                    decimal doanhThu = Convert.ToDecimal(dtDoanhThu.Rows[i]["DoanhThu"]);
                    decimal vonNhap = Convert.ToDecimal(dtVonNhap.Rows[i]["VonNhap"]);
                    decimal tienTra = Convert.ToDecimal(dtTienTra.Rows[i]["TienTra"]);
                    decimal loiNhuan = doanhThu - vonNhap;

                    worksheet.Cells[currentRow, 1].Value = $"Ngày {ngay:D2}/{thang:D2}/{nam}";
                    worksheet.Cells[currentRow, 2].Value = doanhThu;
                    worksheet.Cells[currentRow, 3].Value = vonNhap;
                    worksheet.Cells[currentRow, 4].Value = tienTra;
                    worksheet.Cells[currentRow, 5].Value = loiNhuan;

                    // Định dạng căn lề và số tiền
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 2, currentRow, 5].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[currentRow, 2, currentRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    currentRow++;
                }

                // ==========================================
                // 4. DÒNG TỔNG CỘNG BẢNG CHI TIẾT
                // ==========================================
                worksheet.Cells[currentRow, 1].Value = "TỔNG CỘNG";
                worksheet.Cells[currentRow, 2].Value = tongDoanhThuThang;
                worksheet.Cells[currentRow, 3].Value = tongVonNhapThang;
                worksheet.Cells[currentRow, 4].Value = tongTienTraThang;
                worksheet.Cells[currentRow, 5].Value = tongDoanhThuThang - tongVonNhapThang;

                using (var range = worksheet.Cells[currentRow, 1, currentRow, 5])
                {
                    range.Style.Font.Bold = true;
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 2, currentRow, 5].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[currentRow, 2, currentRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                // Kẻ viền (Border) cho bảng chi tiết
                using (var range = worksheet.Cells[headerRow, 1, currentRow, 5])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                // Tự động căn chỉnh độ rộng các cột
                worksheet.Cells.AutoFitColumns();

                // Lưu file Excel
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        private void XuatBaoCaoThongKeRaExcel(string filePath, DataTable dtDoanhThu, DataTable dtVonNhap, DataTable dtTienTra, int thang, int nam)
        {
            ExcelPackage.License.SetNonCommercialPersonal("SupermarketManagement");

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add($"ThongKe_T{thang}_{nam}");

                // --- 1. TIÊU ĐỀ BÁO CÁO ---
                worksheet.Cells["A1:E1"].Merge = true;
                worksheet.Cells["A1"].Value = $"BÁO CÁO THỐNG KÊ DOANH THU, VỐN NHẬP & TRẢ HÀNG (THÁNG {thang}/{nam})";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A2:E2"].Merge = true;
                worksheet.Cells["A2"].Value = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Cells["A2"].Style.Font.Italic = true;
                worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // --- 2. HEADER BẢNG DỮ LIỆU ---
                worksheet.Cells["A4"].Value = "Ngày";
                worksheet.Cells["B4"].Value = "Doanh Thu Thuần (VNĐ)";
                worksheet.Cells["C4"].Value = "Vốn Nhập (VNĐ)";
                worksheet.Cells["D4"].Value = "Giá Trị Trả Hàng (VNĐ)";
                worksheet.Cells["E4"].Value = "Lợi Nhuận (VNĐ)";

                using (var range = worksheet.Cells["A4:E4"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // --- 3. ĐỔ DỮ LIỆU CHI TIẾT ---
                int currentRow = 5;
                decimal tongDoanhThu = 0;
                decimal tongVonNhap = 0;
                decimal tongTienTra = 0;

                for (int i = 0; i < dtDoanhThu.Rows.Count; i++)
                {
                    int ngay = Convert.ToInt32(dtDoanhThu.Rows[i]["Ngay"]);
                    decimal doanhThu = Convert.ToDecimal(dtDoanhThu.Rows[i]["DoanhThu"]);
                    decimal vonNhap = Convert.ToDecimal(dtVonNhap.Rows[i]["VonNhap"]);
                    decimal tienTra = Convert.ToDecimal(dtTienTra.Rows[i]["TienTra"]);
                    decimal loiNhuan = doanhThu - vonNhap;

                    tongDoanhThu += doanhThu;
                    tongVonNhap += vonNhap;
                    tongTienTra += tienTra;

                    worksheet.Cells[currentRow, 1].Value = $"Ngày {ngay:D2}/{thang:D2}/{nam}";
                    worksheet.Cells[currentRow, 2].Value = doanhThu;
                    worksheet.Cells[currentRow, 3].Value = vonNhap;
                    worksheet.Cells[currentRow, 4].Value = tienTra;
                    worksheet.Cells[currentRow, 5].Value = loiNhuan;

                    // Định dạng số tiền
                    worksheet.Cells[currentRow, 2, currentRow, 5].Style.Numberformat.Format = "#,##0";

                    // Căn chỉnh
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 2, currentRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    currentRow++;
                }

                // --- 4. DÒNG TỔNG CỘNG ---
                worksheet.Cells[currentRow, 1].Value = "TỔNG CỘNG";
                worksheet.Cells[currentRow, 2].Value = tongDoanhThu;
                worksheet.Cells[currentRow, 3].Value = tongVonNhap;
                worksheet.Cells[currentRow, 4].Value = tongTienTra;
                worksheet.Cells[currentRow, 5].Value = tongDoanhThu - tongVonNhap;

                worksheet.Cells[currentRow, 1, currentRow, 5].Style.Font.Bold = true;
                worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[currentRow, 2, currentRow, 5].Style.Numberformat.Format = "#,##0";

                // Kẻ viền bảng
                using (var range = worksheet.Cells[4, 1, currentRow, 5])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                worksheet.Cells.AutoFitColumns();

                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }
    }
}