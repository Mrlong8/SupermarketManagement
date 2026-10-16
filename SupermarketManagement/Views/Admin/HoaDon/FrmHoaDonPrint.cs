using iTextSharp.text;
using iTextSharp.text.pdf;
using SupermarketManagement.Models.Repositories;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.HoaDon
{
    public partial class FrmHoaDonPrint : Form
    {
        private string _maHD;
        private LichSuMuaRepository _repo = new LichSuMuaRepository();

        public FrmHoaDonPrint(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        private void FrmHoaDonPrint_Load(object sender, EventArgs e)
        {
            LoadDataHoaDon();
        }

        private void LoadDataHoaDon()
        {
            if (string.IsNullOrEmpty(_maHD)) return;

            // 1. Load thông tin chung
            DataRow rowHD = _repo.GetThongTinChungHoaDon(_maHD);
            if (rowHD != null)
            {
                lblMaHD.Text = "Mã HĐ: " + rowHD["MaHD"]?.ToString();

                if (rowHD["NgayMua"] != DBNull.Value && rowHD["NgayMua"] != null)
                    lblNgayMua.Text = "Ngày bán: " + Convert.ToDateTime(rowHD["NgayMua"]).ToString("dd/MM/yyyy HH:mm");

                lblKhachHang.Text = "Khách hàng: " + rowHD["TenKhachHang"]?.ToString();
                lblNhanVien.Text = "Thu ngân: " + rowHD["TenNhanVien"]?.ToString();

                if (rowHD["TongTien"] != DBNull.Value && rowHD["TongTien"] != null)
                    lblTongTien.Text = "Tổng tiền: " + Convert.ToDecimal(rowHD["TongTien"]).ToString("N0") + " VNĐ";
            }

            // 2. Load danh sách chi tiết sản phẩm
            DataTable dtChiTiet = _repo.GetChiTietHD(_maHD);
            if (dtChiTiet != null)
            {
                dgvChiTietHD.DataSource = dtChiTiet;
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF File (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"HoaDon_{_maHD}_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatHoaDonRaPDF(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file PDF hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chi tiết: " + ex.ToString(), "Lỗi xuất PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void XuatHoaDonRaPDF(string filePath)
        {
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Cấu hình Font chữ an toàn
            Font titleFont, headerFont, bodyFont;
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

            if (File.Exists(fontPath))
            {
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                titleFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                headerFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
                bodyFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            }
            else
            {
                titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            }

            // 1. Tiêu đề
            Paragraph header = new Paragraph("SIEU THI SUPERMARKET", titleFont);
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);

            Paragraph title = new Paragraph("HOA DON BAN HANG\n\n", headerFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // 2. Thông tin chung
            DataRow rowHD = _repo.GetThongTinChungHoaDon(_maHD);
            if (rowHD != null)
            {
                document.Add(new Paragraph($"Ma Hoa Don: {_maHD}", bodyFont));
                if (rowHD["NgayMua"] != DBNull.Value)
                    document.Add(new Paragraph($"Ngay Ban: {Convert.ToDateTime(rowHD["NgayMua"]):dd/MM/yyyy HH:mm}", bodyFont));
                document.Add(new Paragraph($"Khach Hang: {rowHD["TenKhachHang"]}", bodyFont));
                document.Add(new Paragraph($"Thu Ngan: {rowHD["TenNhanVien"]}", bodyFont));
            }
            document.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------", bodyFont));

            // 3. Bảng Chi Tiết
            DataTable dtChiTiet = _repo.GetChiTietHD(_maHD);
            if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
            {
                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 15f, 35f, 15f, 18f, 17f });

                // Tiêu đề cột
                table.AddCell(new PdfPCell(new Phrase("Ma SP", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Ten San Pham", headerFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase("So Luong", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Don Gia", headerFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase("Thanh Tien", headerFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                // Dữ liệu từng dòng (Lấy theo chỉ số index 0,1,2,3,4 để tránh lỗi sai tên cột)
                foreach (DataRow row in dtChiTiet.Rows)
                {
                    table.AddCell(new PdfPCell(new Phrase(row[0]?.ToString(), bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(row[1]?.ToString(), bodyFont)));
                    table.AddCell(new PdfPCell(new Phrase(row[2]?.ToString(), bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

                    decimal donGia = row[3] != DBNull.Value ? Convert.ToDecimal(row[3]) : 0;
                    decimal thanhTien = row[4] != DBNull.Value ? Convert.ToDecimal(row[4]) : 0;

                    table.AddCell(new PdfPCell(new Phrase(donGia.ToString("N0"), bodyFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase(thanhTien.ToString("N0"), bodyFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }

                document.Add(table);
            }

            // 4. Tổng Tiền
            document.Add(new Paragraph("\n"));
            if (rowHD != null && rowHD["TongTien"] != DBNull.Value)
            {
                decimal tongTienVal = Convert.ToDecimal(rowHD["TongTien"]);
                Paragraph tongTien = new Paragraph($"TONG CONG THANH TOAN: {tongTienVal:N0} VND", titleFont);
                tongTien.Alignment = Element.ALIGN_RIGHT;
                document.Add(tongTien);
            }

            Paragraph footer = new Paragraph("\nCam on quy khach va hen gap lai!", bodyFont);
            footer.Alignment = Element.ALIGN_CENTER;
            document.Add(footer);

            document.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}