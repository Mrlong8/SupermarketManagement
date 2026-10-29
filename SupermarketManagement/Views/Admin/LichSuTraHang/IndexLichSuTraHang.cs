using OfficeOpenXml;
using OfficeOpenXml.Style;
using SupermarketManagement.Models.Repositories;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.LichSuTraHang
{
    public partial class IndexLichSuTraHang : Form
    {
        private LichSuTraHangRepository _repo = new LichSuTraHangRepository();

        public IndexLichSuTraHang()
        {
            InitializeComponent();
        }

        // Khởi tạo dữ liệu và tải danh sách ban đầu
        private void IndexLichSuTraHang_Load(object sender, EventArgs e)
        {
            GetDataPhieuTra();
            ConfigComboBoxAutoComplete();
            LoadComboBoxData();
        }

        // Lấy danh sách tất cả phiếu trả hàng hiển thị lên DataGridView
        public void GetDataPhieuTra()
        {
            dgvListPhieuNhap.DataSource = _repo.GetDanhSachPhieuTra();
        }

        // Hiển thị chi tiết phiếu trả khi click vào một dòng trong danh sách
        private void dgvListPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListPhieuNhap.Rows[e.RowIndex];
                string maPhieuTra = row.Cells["Mã Phiếu Trả"].Value?.ToString();

                if (!string.IsNullOrEmpty(maPhieuTra))
                {
                    dgvChiTietPhieuNhap.DataSource = _repo.GetChiTietPhieuTra(maPhieuTra);
                }
            }
        }

        // Đưa tất cả các ô nhập liệu và bộ lọc về trạng thái ban đầu
        private void btnReset_Click(object sender, EventArgs e)
        {
            cbNhanVien.SelectedIndexChanged -= cbNhanVien_SelectedIndexChanged;
            cbNhaCungCap.SelectedIndexChanged -= cbKhachHang_SelectedIndexChanged;
            dtpNgayNhap.ValueChanged -= dtpNgayMua_ValueChanged;

            cbNhanVien.SelectedIndex = -1;
            cbNhaCungCap.SelectedIndex = -1;
            dtpNgayNhap.Value = DateTime.Now;

            cbNhanVien.SelectedIndexChanged += cbNhanVien_SelectedIndexChanged;
            cbNhaCungCap.SelectedIndexChanged += cbKhachHang_SelectedIndexChanged;
            dtpNgayNhap.ValueChanged += dtpNgayMua_ValueChanged;

            GetDataPhieuTra();
            if (dgvChiTietPhieuNhap.DataSource != null)
            {
                ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
            }
        }

        // Thiết lập tính năng tự động gợi ý danh sách khi gõ chữ vào ComboBox
        private void ConfigComboBoxAutoComplete()
        {
            cbNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbNhaCungCap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbNhaCungCap.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // Nạp danh sách Nhân viên và Khách hàng vào ComboBox
        private void LoadComboBoxData()
        {
            DataTable dtNV = _repo.GetNhanVienList();
            cbNhanVien.DataSource = dtNV;
            cbNhanVien.DisplayMember = "HoTen";
            cbNhanVien.ValueMember = "MaNV";
            cbNhanVien.SelectedIndex = -1;

            DataTable dtKH = _repo.GetKhachHangList();
            cbNhaCungCap.DataSource = dtKH;
            cbNhaCungCap.DisplayMember = "HoTen";
            cbNhaCungCap.ValueMember = "MaKH";
            cbNhaCungCap.SelectedIndex = -1;
        }

        // Lọc danh sách phiếu trả hàng theo nhân viên được chọn
        private void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.Focused && cbNhanVien.SelectedValue != null)
            {
                string maNV = cbNhanVien.SelectedValue.ToString();
                DataTable dtResult = _repo.LocTheoNhanVien(maNV);
                dgvListPhieuNhap.DataSource = dtResult;

                if (dtResult.Rows.Count == 0 && dgvChiTietPhieuNhap.DataSource != null)
                {
                    ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
                }
            }
        }

        // Lọc danh sách phiếu trả hàng theo khách hàng được chọn
        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhaCungCap.Focused && cbNhaCungCap.SelectedValue != null)
            {
                string maKH = cbNhaCungCap.SelectedValue.ToString();
                DataTable dtResult = _repo.LocTheoKhachHang(maKH);
                dgvListPhieuNhap.DataSource = dtResult;

                if (dtResult.Rows.Count == 0 && dgvChiTietPhieuNhap.DataSource != null)
                {
                    ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
                }
            }
        }

        // Lọc danh sách phiếu trả hàng theo ngày được chọn
        private void dtpNgayMua_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayTra = dtpNgayNhap.Value.Date;
            DataTable dtResult = _repo.LocTheoNgayTra(ngayTra);
            dgvListPhieuNhap.DataSource = dtResult;

            if (dtResult.Rows.Count == 0 && dgvChiTietPhieuNhap.DataSource != null)
            {
                ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
            }
        }

        // Thực hiện xóa phiếu trả hàng khỏi hệ thống
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvListPhieuNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu trả hàng cần xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieuTra = dgvListPhieuNhap.CurrentRow.Cells["Mã Phiếu Trả"].Value?.ToString();
            if (string.IsNullOrEmpty(maPhieuTra)) return;

            DialogResult hoi = MessageBox.Show(
                $"Bạn có chắc muốn xóa phiếu trả {maPhieuTra}?\nToàn bộ chi tiết của phiếu cũng sẽ bị xóa và không thể khôi phục.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (hoi != DialogResult.Yes) return;

            try
            {
                _repo.XoaPhieuTra(maPhieuTra);

                MessageBox.Show("Xóa phiếu trả hàng thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataPhieuTra();

                if (dgvChiTietPhieuNhap.DataSource != null)
                {
                    ((DataTable)dgvChiTietPhieuNhap.DataSource).Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa phiếu trả hàng này!\nLỗi: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemTruocHD_Click(object sender, EventArgs e)
        {
            if (dgvListPhieuNhap.SelectedRows.Count > 0)
            {
                string mapn = dgvListPhieuNhap.SelectedRows[0].Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(mapn))
                {
                    SupermarketManagement.Views.Admin.PhieuNhapHang.IndexPhieuNhapHang frmPrint =
                        new SupermarketManagement.Views.Admin.PhieuNhapHang.IndexPhieuNhapHang(mapn);
                    frmPrint.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu nhập trong danh sách để xem chi tiết!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Thực hiện xuất file Excel cho Phiếu Trả Hàng đang chọn
        private void btnXuatHoaDonTra_Click(object sender, EventArgs e)
        {
            if (dgvListPhieuNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu trả hàng trong danh sách để xuất hóa đơn!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin dòng phiếu trả hàng được chọn
            DataGridViewRow row = dgvListPhieuNhap.CurrentRow;
            string maPhieuTra = row.Cells["Mã Phiếu Trả"].Value?.ToString();
            string maHD = row.Cells["Mã Hóa Đơn"].Value?.ToString();
            string ngayTra = Convert.ToDateTime(row.Cells["Ngày Trả"].Value).ToString("dd/MM/yyyy HH:mm");
            string nhanVien = row.Cells["Nhân Viên Lập"].Value?.ToString();
            string khachHang = row.Cells["Khách Hàng"].Value?.ToString();
            string lyDo = row.Cells["Lý Do"].Value?.ToString();

            if (string.IsNullOrEmpty(maPhieuTra)) return;

            // Lấy danh sách chi tiết sản phẩm trả
            DataTable dtChiTiet = _repo.GetChiTietPhieuTra(maPhieuTra);
            if (dtChiTiet == null || dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin chi tiết sản phẩm của phiếu trả này!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở hộp thoại chọn vị trí lưu file Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = $"PhieuTraHang_{maPhieuTra}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatPhieuTraHangRaExcel(saveFileDialog.FileName, maPhieuTra, maHD, ngayTra, nhanVien, khachHang, lyDo, dtChiTiet);
                    MessageBox.Show("Xuất hóa đơn/phiếu trả hàng ra file Excel thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Phương thức định dạng và xuất chi tiết Hóa đơn trả hàng ra Excel
        private void XuatPhieuTraHangRaExcel(string filePath, string maPhieuTra, string maHD, string ngayTra,
                                            string nhanVien, string khachHang, string lyDo, DataTable dtChiTiet)
        {
            ExcelPackage.License.SetNonCommercialPersonal("SupermarketManagement");

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("PhieuTraHang");

                // --- 1. TIÊU ĐỀ PHIẾU ---
                worksheet.Cells["A1:E1"].Merge = true;
                worksheet.Cells["A1"].Value = "PHIẾU TRẢ HÀNG & HOÀN TIỀN";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // --- 2. THÔNG TIN CHUNG ---
                worksheet.Cells["A3"].Value = $"Mã Phiếu Trả: {maPhieuTra}";
                worksheet.Cells["D3"].Value = $"Ngày Trả: {ngayTra}";

                worksheet.Cells["A4"].Value = $"Mã Hóa Đơn Gốc: {maHD}";
                worksheet.Cells["D4"].Value = $"Nhân Viên Lập: {nhanVien}";

                worksheet.Cells["A5"].Value = $"Khách Hàng: {khachHang}";
                worksheet.Cells["D5"].Value = $"Lý Do Trả: {lyDo}";

                using (var range = worksheet.Cells["A3:E5"])
                {
                    range.Style.Font.Italic = true;
                }

                // --- 3. HEADER BẢNG DỮ LIỆU SẢN PHẨM ---
                int headerRow = 7;
                worksheet.Cells[headerRow, 1].Value = "STT";
                worksheet.Cells[headerRow, 2].Value = "Tên Sản Phẩm";
                worksheet.Cells[headerRow, 3].Value = "Đơn Vị Tính";
                worksheet.Cells[headerRow, 4].Value = "Số Lượng Trả";
                worksheet.Cells[headerRow, 5].Value = "Đơn Giá Hoàn (VNĐ)";
                worksheet.Cells[headerRow, 6].Value = "Thành Tiền (VNĐ)";

                using (var range = worksheet.Cells[headerRow, 1, headerRow, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // --- 4. ĐỔ DỮ LIỆU CHI TIẾT ---
                int currentRow = headerRow + 1;
                decimal tongTienHoan = 0;

                for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    DataRow r = dtChiTiet.Rows[i];
                    string tenSP = r["Tên Sản Phẩm"].ToString();
                    string dvt = r["Đơn Vị Tính"].ToString();
                    int soLuong = Convert.ToInt32(r["Số Lượng Trả"]);
                    decimal donGia = Convert.ToDecimal(r["Đơn Giá Hoàn"]);
                    decimal thanhTien = Convert.ToDecimal(r["Thành Tiền"]);

                    tongTienHoan += thanhTien;

                    worksheet.Cells[currentRow, 1].Value = i + 1;
                    worksheet.Cells[currentRow, 2].Value = tenSP;
                    worksheet.Cells[currentRow, 3].Value = dvt;
                    worksheet.Cells[currentRow, 4].Value = soLuong;
                    worksheet.Cells[currentRow, 5].Value = donGia;
                    worksheet.Cells[currentRow, 6].Value = thanhTien;

                    // Định dạng số & Căn lề
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 5, currentRow, 6].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[currentRow, 5, currentRow, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    currentRow++;
                }

                // --- 5. TỔNG CỘNG TIỀN HOÀN ---
                worksheet.Cells[currentRow, 1, currentRow, 5].Merge = true;
                worksheet.Cells[currentRow, 1].Value = "TỔNG TIỀN HOÀN LẠI KHÁCH HÀNG:";
                worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[currentRow, 6].Value = tongTienHoan;
                worksheet.Cells[currentRow, 6].Style.Font.Bold = true;
                worksheet.Cells[currentRow, 6].Style.Numberformat.Format = "#,##0";
                worksheet.Cells[currentRow, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                // Kẻ viền (Border) cho toàn bộ bảng
                using (var range = worksheet.Cells[headerRow, 1, currentRow, 6])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                // --- 6. KHỐI CHỮ KÝ ---
                int footerRow = currentRow + 2;
                worksheet.Cells[footerRow, 2].Value = "Khách Hàng";
                worksheet.Cells[footerRow, 2].Style.Font.Bold = true;
                worksheet.Cells[footerRow, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[footerRow, 5].Value = "Nhân Viên Lập";
                worksheet.Cells[footerRow, 5].Style.Font.Bold = true;
                worksheet.Cells[footerRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[footerRow + 1, 2].Value = "(Ký, ghi rõ họ tên)";
                worksheet.Cells[footerRow + 1, 2].Style.Font.Italic = true;
                worksheet.Cells[footerRow + 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[footerRow + 1, 5].Value = "(Ký, ghi rõ họ tên)";
                worksheet.Cells[footerRow + 1, 5].Style.Font.Italic = true;
                worksheet.Cells[footerRow + 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Căn chỉnh tự động độ rộng cột
                worksheet.Cells.AutoFitColumns();

                // Lưu file Excel
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }
    }
}