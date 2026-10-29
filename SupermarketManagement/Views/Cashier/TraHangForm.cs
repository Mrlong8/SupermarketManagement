using SupermarketManagement.Models.Repositories;
using SupermarketManagement.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Cashier
{
    public partial class TraHangForm : Form
    {
        private readonly TraHangRepository repository;
        private DataTable bangChiTiet;
        private string maPhieu;

        public TraHangForm()
        {
            InitializeComponent();
            repository = new TraHangRepository();
            TaoBangChiTiet();
            TaoMaPhieuMoi();
            NapDanhSachHoaDonTrongNgay();
        }
        private void NapDanhSachHoaDonTrongNgay()
        {
            try
            {
                DataTable data = repository.LayDanhSachHoaDonTrongNgay();

                cboMaHD.DataSource = data;
                cboMaHD.DisplayMember = "MaHD";
                cboMaHD.ValueMember = "MaHD";
                cboMaHD.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách hóa đơn: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void BtnCapNhatSoLuongTra_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null ||
                dgv.CurrentRow.Index < 0 ||
                dgv.CurrentRow.Index >= bangChiTiet.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong bảng.");
                return;
            }

            int index = dgv.CurrentRow.Index;
            DataRow row = bangChiTiet.Rows[index];

            int daMua = Convert.ToInt32(row["SoLuongDaMua"]);
            int daTra = Convert.ToInt32(row["SoLuongDaTra"]);
            int soLuongTra = Convert.ToInt32(numSoLuongTra.Value);

            int soLuongConDuocTra = daMua - daTra;

            if (soLuongTra < 0 || soLuongTra > soLuongConDuocTra)
            {
                MessageBox.Show(
                    "Số lượng trả không được vượt quá số lượng đã mua còn lại.");
                return;
            }

            // Lấy hệ số quy đổi của một đơn vị tính.
            int heSoQuyDoi = Convert.ToInt32(row["HeSoQuyDoi"]);

            // Cập nhật số lượng trả và số lượng quy đổi tương ứng.
            row["SoLuongTra"] = soLuongTra;
            row["SoLuongQuyDoi"] = soLuongTra * heSoQuyDoi;

            // Tính thành tiền.
            row["ThanhTien"] = soLuongTra *
                Convert.ToDecimal(row["DonGia"]);

            dgv.Refresh();
        }


        private void TaoMaPhieuMoi()
        {
            maPhieu = "TH" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            lblMaPhieu.Text = "Mã phiếu: " + maPhieu;
            lblNgay.Text = "Ngày lập: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void TaoBangChiTiet()
        {
            bangChiTiet = new DataTable();
            bangChiTiet.Columns.Add("MaSP", typeof(string));
            bangChiTiet.Columns.Add("MaDVT", typeof(string));
            bangChiTiet.Columns.Add("TenSanPham", typeof(string));
            bangChiTiet.Columns.Add("TenDV", typeof(string));
            bangChiTiet.Columns.Add("SoLuongDaMua", typeof(int));
            bangChiTiet.Columns.Add("SoLuongDaTra", typeof(int));
            bangChiTiet.Columns.Add("SoLuongTra", typeof(int));
            bangChiTiet.Columns.Add("DonGia", typeof(decimal));
            bangChiTiet.Columns.Add("HeSoQuyDoi", typeof(int));
            bangChiTiet.Columns.Add("SoLuongQuyDoi", typeof(int));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            dgv.DataSource = bangChiTiet;
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            // Lấy mã hóa đơn được chọn trong ComboBox
            string maHD = cboMaHD.Text.Trim();

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn.");
                return;
            }

            try
            {
                DataTable result = repository.TimHoaDon(maHD);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy hóa đơn hoặc hóa đơn không có chi tiết.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Xóa dữ liệu hóa đơn trước đó
                bangChiTiet.Rows.Clear();

                // Hiển thị chi tiết hóa đơn được chọn
                foreach (DataRow row in result.Rows)
                {
                    bangChiTiet.Rows.Add(
                        Convert.ToString(row["MaSP"]),
                        Convert.ToString(row["MaDVT"]),
                        Convert.ToString(row["TenSanPham"]),
                        Convert.ToString(row["TenDV"]),
                        Convert.ToInt32(row["SoLuongDaMua"]),
                        Convert.ToInt32(row["SoLuongDaTra"]),
                        0,
                        Convert.ToDecimal(row["DonGia"]),
                        Convert.ToInt32(row["HeSoQuyDoi"]),
                        Convert.ToInt32(row["SoLuongQuyDoi"]),
                        0m
                    );
                }

                // Hiển thị tên khách hàng
                string tenKhachHang = repository.LayTenKhachHang(maHD);
                lblKhachHang.Text = "Khách hàng: " + tenKhachHang;

                // Cập nhật thành tiền
                CapNhatThanhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tìm hóa đơn. Hãy kiểm tra kết nối database và các bảng phiếu trả hàng.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void CapNhatThanhTien()
        {
            if (bangChiTiet == null) return;
            foreach (DataRow row in bangChiTiet.Rows)
            {
                int soLuong = 0;
                int.TryParse(Convert.ToString(row["SoLuongTra"]), out soLuong);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                row["ThanhTien"] = soLuong > 0 ? soLuong * donGia : 0m;
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Lấy mã hóa đơn được chọn từ ComboBox
            string maHD = cboMaHD.Text.Trim();

            if (string.IsNullOrEmpty(maHD) || bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hãy chọn hóa đơn và tìm hóa đơn trước khi lập phiếu trả.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do trả hàng.");
                txtLyDo.Focus();
                return;
            }

            try
            {
                // Cập nhật thành tiền trước khi lưu
                CapNhatThanhTien();

                // Lưu phiếu trả hàng
                repository.LuuPhieuTraHang(
                    maPhieu,
                    maHD,
                    Convert.ToString(UserSession.MaNV),
                    txtLyDo.Text.Trim(),
                    bangChiTiet);

                MessageBox.Show(
                    "Đã lập phiếu trả hàng " + maPhieu + " thành công.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lập phiếu trả hàng. Dữ liệu chưa được xác nhận.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Các handler được đặt trong file code-behind để Designer đọc được.
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CapNhatThanhTien();
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlBottom_Resize(object sender, EventArgs e)
        {
            if (pnlBottom == null || btnDong == null || btnLuu == null)
                return;

            btnDong.Left = pnlBottom.ClientSize.Width - btnDong.Width - 12;
            btnLuu.Left = btnDong.Left - btnLuu.Width - 10;
        }
        private void numSoLuongTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnCapNhatSoLuongTra_Click(btnCapNhatSoLuong, EventArgs.Empty);
            }
        }
        private void cboMaHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnTim_Click(btnTim, EventArgs.Empty);
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataRowView view = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;

            if (view == null)
                return;

            int soLuongHienTai = Convert.ToInt32(view["SoLuongTra"]);

            numSoLuongTra.Value = Math.Max(
                (int)numSoLuongTra.Minimum,
                Math.Min(soLuongHienTai, (int)numSoLuongTra.Maximum)
            );
        }
    }
}
