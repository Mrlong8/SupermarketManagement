using ClosedXML.Excel;
using SupermarketManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SupermarketManagement.Views.Cashier
{
    public partial class InvoiceForm : Form
    {
        private decimal _tongTienHang;
        private decimal _tienGiamGia;
        private int _diemSuDung;
        private decimal _tienPhaiTra;
        public InvoiceForm()
        {
            InitializeComponent();
            this.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvInvoiceDetails.AllowUserToResizeColumns = false;
            this.dgvInvoiceDetails.AllowUserToResizeRows = false;
            this.dgvInvoiceDetails.RowHeadersVisible = false;
            this.dgvInvoiceDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        }
        public void HienThiHoaDon(
            string maHD,
            string maKH,
            string tenKH,
            string tenNhanVien,
            DateTime ngayMua,
            DataGridView bangSanPham,
            string tongTien,
            string tienGiamGia = "0",
            string diemSuDung = "0",
            string tienPhaiTra = "")
        {
            txtMaHD.Text = maHD;
            txtMaKH.Text = maKH;
            txtKhachHang.Text = tenKH;
            txtTenNV.Text = tenNhanVien;
            dtpNgayMua.Value = ngayMua;

            // Lưu riêng tổng tiền hàng để không nhầm với số tiền khách phải trả.
            _tongTienHang = ChuyenTien(tongTien);

            // Lưu thông tin thanh toán để xuất Excel
            _tienGiamGia = ChuyenTien(tienGiamGia);

            int.TryParse(diemSuDung, out _diemSuDung);

            _tienPhaiTra = string.IsNullOrWhiteSpace(tienPhaiTra)
                ? _tongTienHang - _tienGiamGia
                : ChuyenTien(tienPhaiTra);

            txtTongTien.Text = _tienPhaiTra.ToString("N0");

            dgvInvoiceDetails.Rows.Clear();

            int stt = 1;

            foreach (DataGridViewRow row in bangSanPham.Rows)
            {
                if (row.IsNewRow)
                    continue;

                object donViTinh = "";
                if (bangSanPham.Columns.Contains("colDonViTinh"))
                    donViTinh = row.Cells["colDonViTinh"].Value ?? "";

                dgvInvoiceDetails.Rows.Add(
                    stt++,
                    row.Cells["colMaSP"].Value,
                    row.Cells["colTenSP"].Value,
                    row.Cells["colSoLuong"].Value,
                    donViTinh,
                    row.Cells["colDonGia"].Value,
                    row.Cells["colThanhTien"].Value
                );
            }
        }



        private decimal ChuyenTien(string giaTri)
        {
            if (string.IsNullOrWhiteSpace(giaTri))
                return 0m;

            string so = giaTri.Trim()
                .Replace("₫", "")
                .Replace("đ", "")
                .Replace("Đ", "")
                .Replace(" ", "");

            int viTriPhay = so.LastIndexOf(',');
            int viTriCham = so.LastIndexOf('.');

            // Trường hợp có cả dấu phẩy và dấu chấm:
            // Dấu xuất hiện cuối cùng được xem là dấu thập phân.
            if (viTriPhay >= 0 && viTriCham >= 0)
            {
                if (viTriPhay > viTriCham)
                {
                    // Ví dụ: 30.000,50
                    so = so.Replace(".", "").Replace(',', '.');
                }
                else
                {
                    // Ví dụ: 30,000.50
                    so = so.Replace(",", "");
                }
            }
            else if (viTriPhay >= 0)
            {
                // Nếu có đúng 3 chữ số sau dấu phẩy,
                // xem dấu phẩy là dấu phân cách hàng nghìn.
                int soChuSoSauDau = so.Length - viTriPhay - 1;

                if (soChuSoSauDau == 3)
                    so = so.Replace(",", "");
                else
                    so = so.Replace(',', '.');
            }
            else if (viTriCham >= 0)
            {
                // Nếu có đúng 3 chữ số sau dấu chấm,
                // xem dấu chấm là dấu phân cách hàng nghìn.
                int soChuSoSauDau = so.Length - viTriCham - 1;

                if (soChuSoSauDau == 3)
                    so = so.Replace(".", "");
            }

            if (decimal.TryParse(
                so,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal ketQua))
            {
                return ketQua;
            }

            return 0m;
        }

        private void btnxuatExecl_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Xuất hóa đơn ra Excel";
                saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveDialog.FileName = "HoaDonBanHang.xlsx";
                saveDialog.DefaultExt = "xlsx";
                saveDialog.AddExtension = true;
                saveDialog.OverwritePrompt = true;

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add("HoaDon");

                        // 1. TIÊU ĐỀ HÓA ĐƠN
                        ws.Cell("A1").Value = "HÓA ĐƠN BÁN HÀNG";
                        ws.Range("A1:G1").Merge();

                        ws.Cell("A1").Style.Font.Bold = true;
                        ws.Cell("A1").Style.Font.FontSize = 18;
                        ws.Cell("A1").Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        ws.Cell("A1").Style.Alignment.Vertical =
                            XLAlignmentVerticalValues.Center;

                        ws.Row(1).Height = 30;


                        // 2. THÔNG TIN HÓA ĐƠN

                        ws.Cell("A3").Value = "Mã hóa đơn:";
                        ws.Range("B3:C3").Merge();
                        ws.Cell("B3").Value = txtMaHD.Text;


                        ws.Cell("D3").Value = "Ngày mua:";
                        ws.Cell("E3").Value = dtpNgayMua.Value;
                        ws.Cell("E3").Style.DateFormat.Format = "dd/MM/yyyy";
                        // Căn trái ngày mua
                        ws.Cell("E3").Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Left;

                        ws.Cell("A4").Value = "Mã khách hàng:";
                        ws.Cell("B4").Value = txtMaKH.Text;

                        ws.Cell("D4").Value = "Khách hàng:";
                        ws.Cell("E4").Value = txtKhachHang.Text;

                        ws.Cell("A5").Value = "Nhân viên:";
                        ws.Cell("B5").Value = txtTenNV.Text;


                        // 3. TIÊU ĐỀ BẢNG SẢN PHẨM
                        string[] headers =
                        {
                            "STT",
                            "Mã SP",
                            "Tên sản phẩm",
                            "Số lượng",
                            "Đơn vị tính",
                            "Đơn giá",
                            "Thành tiền"
                        };

                        for (int i = 0; i < headers.Length; i++)
                        {
                            ws.Cell(7, i + 1).Value = headers[i];
                        }

                        var headerRange = ws.Range("A7:G7");
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        headerRange.Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        headerRange.Style.Alignment.Vertical =
                            XLAlignmentVerticalValues.Center;
                        headerRange.Style.Alignment.WrapText = true;


                        // 4. GHI CHI TIẾT SẢN PHẨM
                        int row = 8;

                        foreach (DataGridViewRow r in dgvInvoiceDetails.Rows)
                        {
                            if (r.IsNewRow)
                                continue;

                            for (int col = 0; col < 7; col++)
                            {
                                object value = r.Cells[col].Value;
                                var cell = ws.Cell(row, col + 1);

                                if (value == null || value == DBNull.Value)
                                {
                                    cell.Value = "";
                                    continue;
                                }

                                // Các cột số: STT, số lượng, đơn giá, thành tiền
                                if (col == 0 || col == 3 ||
                                    col == 4 || col == 5)
                                {
                                    decimal number;

                                    if (decimal.TryParse(
                                        Convert.ToString(value),
                                        out number))
                                    {
                                        cell.Value = (double)number;
                                    }
                                    else
                                    {
                                        cell.Value = Convert.ToString(value);
                                    }
                                }
                                else
                                {
                                    cell.Value = Convert.ToString(value);
                                }
                            }
                            // Căn phải cột Mã SP và Tên sản phẩm
                            ws.Range(row, 2, row, 3).Style.Alignment.Horizontal =
                                XLAlignmentHorizontalValues.Right;

                            row++;
                        }

                        // 5. ĐỊNH DẠNG BẢNG
                        int lastDataRow = row - 1;

                        if (lastDataRow >= 7)
                        {
                            var tableRange = ws.Range(7, 1, lastDataRow, 7);

                            tableRange.Style.Border.OutsideBorder =
                                XLBorderStyleValues.Thin;
                            tableRange.Style.Border.InsideBorder =
                                XLBorderStyleValues.Thin;

                            tableRange.Style.Alignment.Vertical =
                                XLAlignmentVerticalValues.Center;

                            if (lastDataRow >= 8)
                            {
                                // Định dạng đơn giá và thành tiền
                                ws.Range(8, 6, lastDataRow, 7)
                                  .Style.NumberFormat.Format = "#,##0";

                                // Căn phải các cột số
                                ws.Range(8, 4, lastDataRow, 7)
                                  .Style.Alignment.Horizontal =
                                    XLAlignmentHorizontalValues.Right;
                                // Căn phải Mã SP và Tên sản phẩm
                                ws.Range(8, 2, lastDataRow, 3)
                                  .Style.Alignment.Horizontal =
                                    XLAlignmentHorizontalValues.Right;
                            }
                        }

                        // 6. TỔNG TIỀN



                        int totalRow = Math.Max(8, row) + 1;

                        // Tổng tiền hàng
                        ws.Cell(totalRow, 6).Value = "TỔNG TIỀN HÀNG:";
                        ws.Cell(totalRow, 7).Value = (double)_tongTienHang;

                        // Tiền giảm giá
                        ws.Cell(totalRow + 1, 6).Value = "TIỀN GIẢM GIÁ:";
                        ws.Cell(totalRow + 1, 7).Value = (double)_tienGiamGia;

                        // Điểm sử dụng
                        ws.Cell(totalRow + 2, 6).Value = "ĐIỂM SỬ DỤNG:";
                        ws.Cell(totalRow + 2, 7).Value = _diemSuDung;

                        // Khách phải trả
                        ws.Cell(totalRow + 3, 7).Value = "KHÁCH PHẢI TRẢ:";
                        ws.Cell(totalRow + 3, 7).Value = (double)_tienPhaiTra;

                        // Định dạng tiền
                        ws.Range(totalRow, 7, totalRow + 1, 7)
                            .Style.NumberFormat.Format = "#,##0";

                        ws.Cell(totalRow + 3, 7)
                            .Style.NumberFormat.Format = "#,##0";

                        // In đậm số tiền phải trả
                        ws.Range(totalRow + 3, 6, totalRow + 3, 7)
                            .Style.Font.Bold = true;

                        // Kẻ viền khu vực thanh toán
                        ws.Range(totalRow, 6, totalRow + 3, 7)
                            .Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        // 7. CĂN CHỈNH CỘT
                        ws.Columns(1, 7).AdjustToContents();

                        ws.Column(1).Width = 16;
                        ws.Column(2).Width = 22;
                        ws.Column(3).Width = 28;
                        ws.Column(4).Width = 12;
                        ws.Column(5).Width = 16;
                        ws.Column(6).Width = 18;
                        ws.Column(7).Width = 20;


                        // Lặp tiêu đề khi in nhiều trang
                        ws.PageSetup.SetRowsToRepeatAtTop("1:7");
                        ws.PageSetup.PageOrientation =
                            XLPageOrientation.Landscape;
                        ws.PageSetup.FitToPages(1, 0);

                        // 8. LƯU FILE
                        workbook.SaveAs(saveDialog.FileName);
                    }

                    MessageBox.Show(
                        "Xuất hóa đơn Excel thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Xuất Excel thất bại!\n" + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }



        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
