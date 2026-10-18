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
        private decimal _tienGiamGia;
        private int _diemSuDung;
        private decimal _tienPhaiTra;
        public InvoiceForm()
        {
            InitializeComponent();
            ApDungGiaoDien();

            this.Resize += (sender, e) =>
            {
                BoTriGiaoDien();
            };
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
            txtMaNV.Text = tenNhanVien;
            dtpNgayMua.Value = ngayMua;

            decimal tong = ChuyenTien(tongTien);

            // Lưu thông tin thanh toán để xuất Excel
            _tienGiamGia = ChuyenTien(tienGiamGia);

            int.TryParse(diemSuDung, out _diemSuDung);

            _tienPhaiTra = string.IsNullOrWhiteSpace(tienPhaiTra)
                ? tong - _tienGiamGia
                : ChuyenTien(tienPhaiTra);

            txtTongTien.Text = _tienPhaiTra.ToString("N0");

            dgvInvoiceDetails.Rows.Clear();

            int stt = 1;

            foreach (DataGridViewRow row in bangSanPham.Rows)
            {
                if (row.IsNewRow)
                    continue;

                dgvInvoiceDetails.Rows.Add(
                    stt++,
                    row.Cells["colMaSP"].Value,
                    row.Cells["colTenSP"].Value,
                    row.Cells["colSoLuong"].Value,
                    row.Cells["colDonGia"].Value,
                    row.Cells["colThanhTien"].Value
                );
            }
        }


        private decimal ChuyenTien(string giaTri)
        {
            if (string.IsNullOrWhiteSpace(giaTri))
                return 0;

            string so = giaTri.Replace(",", "").Replace(".", "");

            if (decimal.TryParse(so, out decimal ketQua))
                return ketQua;

            return 0;
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
                        ws.Range("A1:F1").Merge();

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
                        ws.Cell("B5").Value = txtMaNV.Text;


                        // 3. TIÊU ĐỀ BẢNG SẢN PHẨM
                        string[] headers =
                        {
                            "STT",
                            "Mã SP",
                            "Tên sản phẩm",
                            "Số lượng",
                            "Đơn giá",
                            "Thành tiền"
                        };

                        for (int i = 0; i < headers.Length; i++)
                        {
                            ws.Cell(7, i + 1).Value = headers[i];
                        }

                        var headerRange = ws.Range("A7:F7");
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

                            for (int col = 0; col < 6; col++)
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
                            var tableRange = ws.Range(7, 1, lastDataRow, 6);

                            tableRange.Style.Border.OutsideBorder =
                                XLBorderStyleValues.Thin;
                            tableRange.Style.Border.InsideBorder =
                                XLBorderStyleValues.Thin;

                            tableRange.Style.Alignment.Vertical =
                                XLAlignmentVerticalValues.Center;

                            if (lastDataRow >= 8)
                            {
                                // Định dạng đơn giá và thành tiền
                                ws.Range(8, 5, lastDataRow, 6)
                                  .Style.NumberFormat.Format = "#,##0";

                                // Căn phải các cột số
                                ws.Range(8, 4, lastDataRow, 6)
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
                        ws.Cell(totalRow, 5).Value = "TỔNG TIỀN HÀNG:";
                        ws.Cell(totalRow, 6).Value = (double)ChuyenTien(txtTongTien.Text);

                        // Tiền giảm giá
                        ws.Cell(totalRow + 1, 5).Value = "TIỀN GIẢM GIÁ:";
                        ws.Cell(totalRow + 1, 6).Value = (double)_tienGiamGia;

                        // Điểm sử dụng
                        ws.Cell(totalRow + 2, 5).Value = "ĐIỂM SỬ DỤNG:";
                        ws.Cell(totalRow + 2, 6).Value = _diemSuDung;

                        // Khách phải trả
                        ws.Cell(totalRow + 3, 5).Value = "KHÁCH PHẢI TRẢ:";
                        ws.Cell(totalRow + 3, 6).Value = (double)_tienPhaiTra;

                        // Định dạng tiền
                        ws.Range(totalRow, 6, totalRow + 1, 6)
                            .Style.NumberFormat.Format = "#,##0";

                        ws.Cell(totalRow + 3, 6)
                            .Style.NumberFormat.Format = "#,##0";

                        // In đậm số tiền phải trả
                        ws.Range(totalRow + 3, 5, totalRow + 3, 6)
                            .Style.Font.Bold = true;

                        // Kẻ viền khu vực thanh toán
                        ws.Range(totalRow, 5, totalRow + 3, 6)
                            .Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        // 7. CĂN CHỈNH CỘT
                        ws.Columns(1, 6).AdjustToContents();

                        ws.Column(1).Width = 16;
                        ws.Column(2).Width = 22;
                        ws.Column(3).Width = 28;
                        ws.Column(4).Width = 15;
                        ws.Column(5).Width = 18;
                        ws.Column(6).Width = 20;


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
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserSession.DangXuat(this);
            }
        }

        private void ApDungGiaoDien()
        {
            // Màu sắc đồng bộ với POSForm
            Color xanhChuDao = Color.FromArgb(0, 181, 232);
            Color nen = Color.FromArgb(244, 246, 249);
            Color chu = Color.FromArgb(33, 37, 41);
            Color xanhNut = Color.FromArgb(0, 123, 255);
            Color xanhLa = Color.FromArgb(40, 167, 69);

            // Cấu hình cửa sổ
            this.Text = "Hóa đơn bán hàng";
            this.BackColor = nen;
            this.Font = new Font("Segoe UI", 10F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(900, 600);

            // Tiêu đề
            lblTieuDe.AutoSize = false;
            lblTieuDe.Text = "HÓA ĐƠN BÁN HÀNG";
            lblTieuDe.BackColor = xanhChuDao;
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.Size = new Size(this.ClientSize.Width, 55);
            lblTieuDe.Anchor = AnchorStyles.Top
                             | AnchorStyles.Left
                             | AnchorStyles.Right;

            // Các nhãn thông tin
            Label[] labels =
            {
        lblMaHD, lblMaKH, lblNhanVien,
        lblKhachHang, lblNgayMua, lblTongTien
    };

            foreach (Label label in labels)
            {
                label.ForeColor = chu;
                label.Font = new Font("Segoe UI", 10F);
            }

            // Các ô thông tin
            TextBox[] textBoxes =
            {
        txtMaHD, txtMaKH, txtMaNV,
        txtKhachHang, txtTongTien
    };

            foreach (TextBox txt in textBoxes)
            {
                txt.Font = new Font("Segoe UI", 10F);
                txt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            }

            txtMaHD.ReadOnly = true;
            txtMaKH.ReadOnly = true;
            txtMaNV.ReadOnly = true;
            txtKhachHang.ReadOnly = true;
            txtTongTien.ReadOnly = true;

            dtpNgayMua.Enabled = false;
            dtpNgayMua.Font = new Font("Segoe UI", 10F);

            // Bảng chi tiết hóa đơn
            dgvInvoiceDetails.BackgroundColor = Color.White;
            dgvInvoiceDetails.BorderStyle = BorderStyle.FixedSingle;
            dgvInvoiceDetails.Font = new Font("Segoe UI", 10F);
            dgvInvoiceDetails.ColumnHeadersDefaultCellStyle.BackColor =
                xanhChuDao;
            dgvInvoiceDetails.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvInvoiceDetails.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvInvoiceDetails.EnableHeadersVisualStyles = false;
            dgvInvoiceDetails.RowTemplate.Height = 32;
            dgvInvoiceDetails.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoiceDetails.ReadOnly = true;
            dgvInvoiceDetails.AllowUserToAddRows = false;
            dgvInvoiceDetails.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceDetails.Anchor = AnchorStyles.Top
                                     | AnchorStyles.Left
                                     | AnchorStyles.Right
                                     | AnchorStyles.Bottom;

            // Nút xuất Excel
            btnxuatExecl.Text = "Xuất ra Excel";
            btnxuatExecl.BackColor = xanhLa;
            btnxuatExecl.ForeColor = Color.White;
            btnxuatExecl.FlatStyle = FlatStyle.Flat;
            btnxuatExecl.FlatAppearance.BorderSize = 0;
            btnxuatExecl.Font = new Font("Segoe UI", 10F,
                                          FontStyle.Bold);
            btnxuatExecl.Size = new Size(150, 42);
            btnxuatExecl.Anchor = AnchorStyles.Bottom;

            // Nút thoát
            btnThoat.Text = "Thoát";
            btnThoat.BackColor = Color.FromArgb(108, 117, 125);
            btnThoat.ForeColor = Color.White;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Font = new Font("Segoe UI", 10F,
                                      FontStyle.Bold);
            btnThoat.Size = new Size(130, 42);
            btnThoat.Anchor = AnchorStyles.Bottom;

            // Bố trí lại theo kích thước cửa sổ
            BoTriGiaoDien();
        }

        private void BoTriGiaoDien()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            int margin = 24;
            int labelWidth = 125;
            int gap = 16;
            int top = 75;

            // Chia thông tin hóa đơn thành hai cột
            int columnWidth = (w - margin * 2 - gap) / 2;
            int leftX = margin;
            int rightX = margin + columnWidth + gap;

            int inputWidth = columnWidth - labelWidth - 20;
            int rowHeight = 42;

            // Cột trái
            lblMaHD.Location = new Point(leftX, top + 5);
            txtMaHD.Location = new Point(leftX + labelWidth,
                                         top);
            txtMaHD.Size = new Size(inputWidth, 30);

            lblMaKH.Location = new Point(leftX, top + rowHeight + 5);
            txtMaKH.Location = new Point(leftX + labelWidth,
                                         top + rowHeight);
            txtMaKH.Size = new Size(inputWidth, 30);

            lblNhanVien.Location = new Point(leftX,
                                             top + rowHeight * 2 + 5);
            txtMaNV.Location = new Point(leftX + labelWidth,
                                         top + rowHeight * 2);
            txtMaNV.Size = new Size(inputWidth, 30);

            // Cột phải
            lblNgayMua.Location = new Point(rightX, top + 5);
            dtpNgayMua.Location = new Point(rightX + labelWidth, top);
            dtpNgayMua.Size = new Size(inputWidth, 30);

            lblKhachHang.Location = new Point(rightX,
                                              top + rowHeight + 5);
            txtKhachHang.Location = new Point(rightX + labelWidth,
                                              top + rowHeight);
            txtKhachHang.Size = new Size(inputWidth, 30);

            // Bảng chi tiết
            int tableY = top + rowHeight * 3 + 25;
            int bottomHeight = 100;
            int buttonY = h - 62;

            dgvInvoiceDetails.Location = new Point(
                margin, tableY);

            dgvInvoiceDetails.Size = new Size(
                w - margin * 2,
                Math.Max(150, buttonY - tableY - bottomHeight));

            // Tổng tiền
            lblTongTien.Location = new Point(
                w - margin - 300, h - 105);

            txtTongTien.Location = new Point(
                w - margin - 190, h - 110);

            txtTongTien.Size = new Size(190, 30);

            // Hai nút cuối form
            btnxuatExecl.Location = new Point(
                w / 2 - 160, buttonY);

            btnThoat.Location = new Point(
                w / 2 + 30, buttonY);
        }

    }
}
