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
            bangChiTiet.Columns.Add("SoLuongQuyDoi", typeof(int));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            dgv.DataSource = bangChiTiet;
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            if (maHD.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn.");
                return;
            }

            try
            {
                DataTable result = repository.TimHoaDon(maHD);
                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn hoặc hóa đơn không có chi tiết.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                bangChiTiet.Rows.Clear();
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
                        Convert.ToInt32(row["SoLuongQuyDoi"]),
                        0m);
                }

                string tenKhachHang = repository.LayTenKhachHang(maHD);
                lblKhachHang.Text = "Khách hàng: " + tenKhachHang;
                CapNhatThanhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tìm hóa đơn. Hãy kiểm tra kết nối database và các bảng phiếu trả hàng.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            using (var form = new ChonSanPhamTraHangForm(repository))
            {
                if (form.ShowDialog(this) != DialogResult.OK || form.SanPham == null)
                    return;

                DataRow sanPham = form.SanPham;
                foreach (DataRow row in bangChiTiet.Rows)
                {
                    if (Convert.ToString(row["MaSP"]) == Convert.ToString(sanPham["MaSP"]) &&
                        Convert.ToString(row["MaDVT"]) == Convert.ToString(sanPham["MaDVT"]))
                    {
                        MessageBox.Show("Sản phẩm và đơn vị tính này đã có trong phiếu.");
                        return;
                    }
                }

                DataRow dongMoi = bangChiTiet.NewRow();
                dongMoi["MaSP"] = Convert.ToString(sanPham["MaSP"]);
                dongMoi["MaDVT"] = Convert.ToString(sanPham["MaDVT"]);
                dongMoi["TenSanPham"] = Convert.ToString(sanPham["TenSanPham"]);
                dongMoi["TenDV"] = Convert.ToString(sanPham["TenDV"]);
                dongMoi["SoLuongDaMua"] = 0;
                dongMoi["SoLuongDaTra"] = 0;
                dongMoi["SoLuongTra"] = 0;
                dongMoi["DonGia"] = Convert.ToDecimal(sanPham["DonGiaBanLe"]);
                dongMoi["SoLuongQuyDoi"] = Convert.ToInt32(sanPham["SoLuongQuyDoi"]);
                dongMoi["ThanhTien"] = 0m;
                bangChiTiet.Rows.Add(dongMoi);
                dgv.Refresh();
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
            string maHD = txtMaHD.Text.Trim();
            if (maHD.Length == 0 || bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hãy tìm hóa đơn và chọn sản phẩm trả.");
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
                CapNhatThanhTien();
                repository.LuuPhieuTraHang(
                    maPhieu,
                    maHD,
                    Convert.ToString(UserSession.MaNV),
                    txtLyDo.Text.Trim(),
                    bangChiTiet);

                MessageBox.Show("Đã lập phiếu trả hàng " + maPhieu + " thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lập phiếu trả hàng. Dữ liệu chưa được xác nhận.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Các handler được đặt trong file code-behind để Designer đọc được.
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CapNhatThanhTien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null &&
                dgv.CurrentRow.Index >= 0 &&
                dgv.CurrentRow.Index < bangChiTiet.Rows.Count)
            {
                bangChiTiet.Rows.RemoveAt(dgv.CurrentRow.Index);
                CapNhatThanhTien();
            }
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
    }
}
