using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupermarketManagement.Models.Repositories;

namespace SupermarketManagement
{
    public partial class POSForm : Form
    {
        private int soHoaDon = 1;

        private readonly HoaDonRepository hoaDonRepository = new HoaDonRepository();
        public POSForm()
    {
            InitializeComponent();
            // Cấu hình bảng chi tiết hóa đơn
            dgvChiTietHoaDon.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietHoaDon.MultiSelect = false;
            dgvChiTietHoaDon.AllowUserToAddRows = false;

            txtMaHD.ReadOnly = true;
            txtTongTien.ReadOnly = true;

            TaoMaHoaDonMoi();
            CapNhatTongTien();
    }


    // Thêm sản phẩm vào hóa đơn
        private void btnThemSP_Click(object sender, EventArgs e)        {
            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();

            if (maSP == "" || tenSP == "")
            {
                MessageBox.Show("Vui lòng nhập mã và tên sản phẩm.");
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia)
                || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số lớn hơn 0.");
                txtDonGia.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuonh.Text.Trim(), out int soLuong)
                || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0.");
                txtSoLuonh.Focus();
                return;
            }

            // Nếu sản phẩm đã có trong hóa đơn thì cộng thêm số lượng
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (Convert.ToString(row.Cells["colMaSP"].Value)
                    .Equals(maSP, StringComparison.OrdinalIgnoreCase))
                {
                    decimal giaCu = Convert.ToDecimal(
                        row.Cells["colDonGia"].Value);

                    if (giaCu != donGia)
                    {
                        MessageBox.Show(
                            "Mã sản phẩm này đã có trong hóa đơn " +
                            "với đơn giá khác.");
                        return;
                    }

                    int soLuongCu = Convert.ToInt32(
                        row.Cells["colSoLuong"].Value);

                    row.Cells["colSoLuong"].Value = soLuongCu + soLuong;
                    row.Cells["colThanhTien"].Value =
                        (soLuongCu + soLuong) * donGia;

                    CapNhatTongTien();
                    LamTrongThongTinSanPham();
                    return;
                }
            }

            dgvChiTietHoaDon.Rows.Add(
                maSP,
                tenSP,
                soLuong,
                donGia,
                soLuong * donGia
            );

            CapNhatTongTien();
            LamTrongThongTinSanPham();
        }

        // Sửa sản phẩm đang được chọn trong hóa đơn
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.");
                return;
            }

            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();

            if (maSP == "" || tenSP == "")
            {
                MessageBox.Show("Vui lòng nhập mã và tên sản phẩm.");
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia)
                || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return;
            }

            if (!int.TryParse(txtSoLuonh.Text.Trim(), out int soLuong)
                || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                return;
            }

            DataGridViewRow row = dgvChiTietHoaDon.CurrentRow;

            row.Cells["colMaSP"].Value = maSP;
            row.Cells["colTenSP"].Value = tenSP;
            row.Cells["colSoLuong"].Value = soLuong;
            row.Cells["colDonGia"].Value = donGia;
            row.Cells["colThanhTien"].Value = donGia * soLuong;

            CapNhatTongTien();
            LamTrongThongTinSanPham();

            MessageBox.Show("Đã sửa sản phẩm trong hóa đơn.");
        }

        // Chọn sản phẩm trong bảng để đưa thông tin lên các ô nhập
        private void dgvChiTietHoaDon_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvChiTietHoaDon.Rows[e.RowIndex];

            txtMaSP.Text = Convert.ToString(row.Cells["colMaSP"].Value);
            txtTenSP.Text = Convert.ToString(row.Cells["colTenSP"].Value);
            txtSoLuonh.Text =
                Convert.ToString(row.Cells["colSoLuong"].Value);
            txtDonGia.Text =
                Convert.ToString(row.Cells["colDonGia"].Value);
        }

        // Tìm sản phẩm trong các dòng đã thêm vào hóa đơn
        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtMaSP.Text.Trim();

            if (tuKhoa == "")
                tuKhoa = txtTenSP.Text.Trim();

            if (tuKhoa == "")
            {
                MessageBox.Show("Nhập mã hoặc tên sản phẩm cần tìm.");
                return;
            }

            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                string maSP = Convert.ToString(
                    row.Cells["colMaSP"].Value);
                string tenSP = Convert.ToString(
                    row.Cells["colTenSP"].Value);

                if (maSP.IndexOf(tuKhoa,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || tenSP.IndexOf(tuKhoa,
                        StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    dgvChiTietHoaDon.ClearSelection();
                    row.Selected = true;
                    dgvChiTietHoaDon.CurrentCell =
                        row.Cells["colMaSP"];

                    dgvChiTietHoaDon_CellContentClick(
                        dgvChiTietHoaDon,
                        new DataGridViewCellEventArgs(
                            0, row.Index));

                    return;
                }
            }

            MessageBox.Show("Không tìm thấy sản phẩm trong hóa đơn.");
        }

        // Xóa sản phẩm khỏi hóa đơn
        private void btnXoaSPKhoiHD_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm đã chọn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.Yes)
            {
                dgvChiTietHoaDon.Rows.Remove(
                    dgvChiTietHoaDon.CurrentRow);

                CapNhatTongTien();
                LamTrongThongTinSanPham();
            }
        }

        // Tính tổng tiền của hóa đơn
        private void CapNhatTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Cells["colThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(
                        row.Cells["colThanhTien"].Value);
                }
            }

            txtTongTien.Text = tongTien.ToString("N0");
        }

        // Tạo mã hóa đơn mới

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.Rows.Count == 0 ||
                (dgvChiTietHoaDon.Rows.Count == 1 &&
                 dgvChiTietHoaDon.Rows[0].IsNewRow))
            {
                MessageBox.Show("Hóa đơn chưa có sản phẩm.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Mã hóa đơn đang trống.");
                return;
            }

            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.IsNewRow) continue;

                decimal thanhTien = Convert.ToDecimal(
                    row.Cells["colThanhTien"].Value);

                tongTien += thanhTien;
            }

            try
            {
            //chưa có mã khách hàng thật nên để là null
                string maKH = string.IsNullOrWhiteSpace(txtMaKH.Text)
                    ? null
                    : txtMaKH.Text.Trim();
                MessageBox.Show(
                      "MaKH = " + (maKH == null ? "NULL" : "[" + maKH + "]"));
                hoaDonRepository.LuuHoaDon(
                    txtMaHD.Text.Trim(),
                    tongTien,
                    DateTime.Now,
                    maKH,
                    null,
                    LayChiTietHoaDon()
            );


               

                MessageBox.Show(
                    "Lưu hóa đơn vào SQL Server thành công!");

                // Xóa dữ liệu sau khi lưu thành công
                dgvChiTietHoaDon.Rows.Clear();
                txtMaKH.Clear();
                txtTenKH.Clear();
                txtSDT.Clear();
                txtEmail.Clear();

                CapNhatTongTien();
                TaoMaHoaDonMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lưu hóa đơn:\n" + ex.Message);
            }
        }
        private DataTable LayChiTietHoaDon()    
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MaSP", typeof(string));
            dt.Columns.Add("SoLuongBan", typeof(int));
            dt.Columns.Add("DonGiaBan", typeof(decimal));

            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.IsNewRow) continue;

                dt.Rows.Add(
                    Convert.ToString(row.Cells["colMaSP"].Value),
                    Convert.ToInt32(row.Cells["colSoLuong"].Value),
                    Convert.ToDecimal(row.Cells["colDonGia"].Value)
                );
            }

            return dt;
        }

        private void TaoMaHoaDonMoi()
        {
            txtMaHD.Text =
                "HD" + DateTime.Now.ToString("yyyyMMddHHmmss")
                + soHoaDon.ToString("D3");

            soHoaDon++;
        }

        // Làm mới toàn bộ thông tin đang nhập
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có muốn xóa thông tin đang nhập để làm mới?",
                "Xác nhận làm mới",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
                return;

            dgvChiTietHoaDon.Rows.Clear();

            LamTrongThongTinSanPham();

            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();

            TaoMaHoaDonMoi();
            CapNhatTongTien();
        }

        private void LamTrongThongTinSanPham()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGia.Clear();
            txtSoLuonh.Clear();
        }

        // Xuất hóa đơn và mở form hóa đơn
        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có sản phẩm.");
                return;
            }

            string tenKH = string.IsNullOrWhiteSpace(txtTenKH.Text)
                ? "Khách lẻ"
                : txtTenKH.Text.Trim();

            using (var form =
                new SupermarketManagement.Views.Cashier.InvoiceForm())
            {
                form.HienThiHoaDon(
                    txtMaHD.Text,
                    txtMaKH.Text,
                    tenKH,
                    "Nhân viên",
                    DateTime.Now,
                    dgvChiTietHoaDon,
                    txtTongTien.Text
                );

                form.ShowDialog(this);
            }
        }
        private class KhachHang
        {
            public string MaKH { get; set; }
            public string TenKH { get; set; }
            public string SDT { get; set; }
            public string Email { get; set; }
        }

        private readonly List<KhachHang> danhSachKH =
            new List<KhachHang>();

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (maKH == "" || tenKH == "")
            {
                MessageBox.Show("Vui lòng nhập mã và họ tên khách hàng.");
                return;
            }

            if (danhSachKH.Any(kh => kh.MaKH.Equals(
                maKH, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại.");
                return;
            }

            if (sdt != "" && danhSachKH.Any(kh => kh.SDT == sdt))
            {
                MessageBox.Show("Số điện thoại đã được đăng ký.");
                return;
            }

            danhSachKH.Add(new KhachHang
            {
                MaKH = maKH,
                TenKH = tenKH,
                SDT = sdt,
                Email = email
            });

            MessageBox.Show("Thêm khách hàng thành công.");
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            KhachHang kh = danhSachKH.FirstOrDefault(
                x => x.MaKH.Equals(
                    maKH, StringComparison.OrdinalIgnoreCase));

            if (kh == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng cần sửa.");
                return;
            }

            if (tenKH == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng.");
                return;
            }

            if (sdt != "" && danhSachKH.Any(x =>
                x.SDT == sdt && x != kh))
            {
                MessageBox.Show("Số điện thoại đã được khách hàng khác sử dụng.");
                return;
            }

            kh.TenKH = tenKH;
            kh.SDT = sdt;
            kh.Email = email;

            MessageBox.Show("Cập nhật khách hàng thành công.");
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();

            if (maKH == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa.");
                return;
            }

            KhachHang kh = danhSachKH.FirstOrDefault(
                x => x.MaKH.Equals(
                    maKH, StringComparison.OrdinalIgnoreCase));

            if (kh == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng cần xóa.");
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa khách hàng " + kh.TenKH + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
                return;

            danhSachKH.Remove(kh);

            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();

            MessageBox.Show("Đã xóa khách hàng.");
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (maKH == "" && sdt == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập mã khách hàng hoặc số điện thoại.");
                return;
            }

            KhachHang kh = danhSachKH.FirstOrDefault(x =>
                (maKH != "" && x.MaKH.Equals(
                    maKH, StringComparison.OrdinalIgnoreCase))
                || (sdt != "" && x.SDT == sdt));

            if (kh == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
                return;
            }

            txtMaKH.Text = kh.MaKH;
            txtTenKH.Text = kh.TenKH;
            txtSDT.Text = kh.SDT;
            txtEmail.Text = kh.Email;
        }
        
    }

}
