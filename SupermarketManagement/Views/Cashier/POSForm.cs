using SupermarketManagement.Controllers.Repositories;
using SupermarketManagement.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupermarketManagement.Utils;

namespace SupermarketManagement
{
    public partial class POSForm : Form
    {
        private int soHoaDon = 1;

        private readonly HoaDonRepository hoaDonRepository = new HoaDonRepository();
        private readonly SanPhamRepositoryV2 sanPhamRepository = new SanPhamRepositoryV2();
        public POSForm()
        {


            InitializeComponent();
            // Cấu hình bảng chi tiết hóa đơn
            dgvChiTietHoaDon.ReadOnly = true;
            dgvChiTietHoaDon.MultiSelect = false;
            dgvChiTietHoaDon.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvChiTietHoaDon.AllowUserToAddRows = false;
            dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            dgvChiTietHoaDon.RowHeadersVisible = false;

            dgvChiTietHoaDon.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvChiTietHoaDon.BackgroundColor = Color.White;
            dgvChiTietHoaDon.GridColor = Color.Silver;

            dgvDSSP.ReadOnly = true;
            dgvDSSP.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvDSSP.MultiSelect = false;
            dgvDSSP.AllowUserToAddRows = false;
            TaiDanhSachSanPham();

            lblMaNV.Text = "Mã NV: " + UserSession.MaNV;
            lblTenNV.Text = "Nhân viên: " + UserSession.HoTen;
            txtMaHD.Clear();
            txtMaHD.ReadOnly = true;
            txtTongTien.ReadOnly = true;

            CapNhatTongTien();
        }


        // Thêm sản phẩm vào hóa đơn

        private void btnThemSP_Click(object sender, EventArgs e)
        {
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

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong)
                || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0.");
                txtSoLuong.Focus();
                return;
            }

            // Tìm sản phẩm trong danh sách tồn kho
            DataGridViewRow dongSanPham = null;

            foreach (DataGridViewRow row in dgvDSSP.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (Convert.ToString(row.Cells["colMaSP_DSSP"].Value) == maSP)
                {
                    dongSanPham = row;
                    break;
                }
            }

            if (dongSanPham == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm trong danh sách tồn kho.");
                return;
            }

            int tonKho = Convert.ToInt32(
                dongSanPham.Cells["colSoLuong_DSSP"].Value);

            if (soLuong > tonKho)
            {
                MessageBox.Show("Số lượng tồn kho không đủ!");
                return;
            }

            // Kiểm tra sản phẩm đã có trong hóa đơn chưa
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (Convert.ToString(row.Cells["colMaSP"].Value) == maSP)
                {
                    decimal giaCu = Convert.ToDecimal(
                        row.Cells["colDonGia"].Value);

                    if (giaCu != donGia)
                    {
                        MessageBox.Show(
                            "Mã sản phẩm này đã có trong hóa đơn với đơn giá khác.");
                        return;
                    }

                    int soLuongCu = Convert.ToInt32(
                        row.Cells["colSoLuong"].Value);

                    row.Cells["colSoLuong"].Value = soLuongCu + soLuong;
                    row.Cells["colThanhTien"].Value =
                        (soLuongCu + soLuong) * donGia;

                    // Trừ số lượng tồn kho


                    CapNhatTongTien();
                    LamTrongThongTinSanPham();
                    return;
                }
            }

            // Thêm sản phẩm mới vào chi tiết hóa đơn
            dgvChiTietHoaDon.Rows.Add(
                maSP,
                tenSP,
                soLuong,
                donGia,
                soLuong * donGia
            );

            // Trừ số lượng tồn kho
         
            CapNhatTongTien();
            LamTrongThongTinSanPham();
        }


        // Sửa sản phẩm đang được chọn trong hóa đơn

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.CurrentRow == null ||
                dgvChiTietHoaDon.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong chi tiết hóa đơn.");
                return;
            }

            string maSP = Convert.ToString(
                dgvChiTietHoaDon.CurrentRow.Cells["colMaSP"].Value);

            string tenSP = Convert.ToString(
                dgvChiTietHoaDon.CurrentRow.Cells["colTenSP"].Value);

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia)
                || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuongMoi)
                || soLuongMoi <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                return;
            }

            DataGridViewRow rowHoaDon = dgvChiTietHoaDon.CurrentRow;

            int soLuongCu = Convert.ToInt32(
                rowHoaDon.Cells["colSoLuong"].Value);

            // Tìm sản phẩm tương ứng trong danh sách tồn kho
            DataGridViewRow rowSanPham = null;

            foreach (DataGridViewRow row in dgvDSSP.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (Convert.ToString(row.Cells["colMaSP_DSSP"].Value) == maSP)
                {
                    rowSanPham = row;
                    break;
                }
            }

            if (rowSanPham == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm trong danh sách tồn kho.");
                return;
            }

            int tonKhoHienTai = Convert.ToInt32(
                rowSanPham.Cells["colSoLuong_DSSP"].Value);

            // Hoàn lại số lượng cũ để tính lượng tồn kho có thể sử dụng
            int tonKhoCoTheSuDung = tonKhoHienTai + soLuongCu;

            if (soLuongMoi > tonKhoCoTheSuDung)
            {
                MessageBox.Show("Số lượng tồn kho không đủ!");
                return;
            }

            // Cập nhật chi tiết hóa đơn
            rowHoaDon.Cells["colTenSP"].Value = tenSP;
            rowHoaDon.Cells["colSoLuong"].Value = soLuongMoi;
            rowHoaDon.Cells["colDonGia"].Value = donGia;
            rowHoaDon.Cells["colThanhTien"].Value = donGia * soLuongMoi;

            // Cập nhật tồn kho trên giao diện
            rowSanPham.Cells["colSoLuong_DSSP"].Value =
                tonKhoCoTheSuDung - soLuongMoi;

            CapNhatTongTien();
            LamTrongThongTinSanPham();

            MessageBox.Show("Đã sửa sản phẩm trong hóa đơn.");
        }


        private void TaiDanhSachSanPham()
        {
            try
            {
                DataTable dt = sanPhamRepository.GetListSanPham();

                dgvDSSP.AutoGenerateColumns = false;
                dgvDSSP.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải sản phẩm: " + ex.Message,"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }

        private void dgvDSSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu nhấn vào tiêu đề cột
            if (e.RowIndex < 0)
                return;

            // Lấy dòng sản phẩm được chọn
            DataGridViewRow row = dgvDSSP.Rows[e.RowIndex];

            string maSP = row.Cells["colMaSP_DSSP"].Value?.ToString();
            string tenSP = row.Cells["colTenSP_DSSP"].Value?.ToString();

            decimal donGia = Convert.ToDecimal(
                row.Cells["colDonGiaBan_DSSP"].Value);

            // Lấy số lượng tồn kho hiện tại
            int tonKho = Convert.ToInt32(row.Cells["colSoLuong_DSSP"].Value);

            // Kiểm tra còn hàng không
            if (tonKho <= 0)
            {
                MessageBox.Show("Sản phẩm đã hết hàng!");
                return;
            }

            // Kiểm tra sản phẩm đã có trong hóa đơn chưa
            foreach (DataGridViewRow dong in dgvChiTietHoaDon.Rows)
            {
                if (dong.IsNewRow)
                    continue;

                if (dong.Cells["colMaSP"].Value?.ToString() == maSP)
                {
                    int soLuong = Convert.ToInt32(
                        dong.Cells["colSoLuong"].Value);

                    // Tăng số lượng trong hóa đơn
                    dong.Cells["colSoLuong"].Value = soLuong + 1;

                    dong.Cells["colThanhTien"].Value =
                        (soLuong + 1) * donGia;

                    // Trừ 1 sản phẩm trong danh sách tồn kho
                    row.Cells["colSoLuong_DSSP"].Value = tonKho - 1;

                    CapNhatTongTien();
                    return;
                }
            }

            // Nếu chưa có trong hóa đơn, thêm sản phẩm mới
            dgvChiTietHoaDon.Rows.Add(
                maSP,
                tenSP,
                1,
                donGia,
                donGia
            );

            // Trừ 1 sản phẩm trong danh sách tồn kho
            row.Cells["colSoLuong_DSSP"].Value = tonKho - 1;

            CapNhatTongTien();
        }

        // Chọn sản phẩm khi nhấn vào bất kỳ ô nào trong hàng
        private void dgvChiTietHoaDon_CellClick( object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvChiTietHoaDon.Rows[e.RowIndex];

            txtMaSP.Text = Convert.ToString(row.Cells["colMaSP"].Value);
            txtTenSP.Text = Convert.ToString(row.Cells["colTenSP"].Value);
            txtSoLuong.Text = Convert.ToString(row.Cells["colSoLuong"].Value);
            txtDonGia.Text = Convert.ToString(row.Cells["colDonGia"].Value);
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

                    dgvChiTietHoaDon_CellClick(
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
                // Lấy thông tin trước khi xóa
                DataGridViewRow dong = dgvChiTietHoaDon.CurrentRow;

                string maSP = Convert.ToString(
                    dong.Cells["colMaSP"].Value);

                int soLuong = Convert.ToInt32(
                    dong.Cells["colSoLuong"].Value);

                // Tìm sản phẩm trong danh sách tồn kho
                foreach (DataGridViewRow row in dgvDSSP.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    string maSPKho = Convert.ToString(
                        row.Cells["colMaSP_DSSP"].Value);

                    if (maSPKho == maSP)
                    {
                        int tonKho = Convert.ToInt32(
                            row.Cells["colSoLuong_DSSP"].Value);

                        // Hoàn lại số lượng trên giao diện
                        row.Cells["colSoLuong_DSSP"].Value =
                            tonKho + soLuong;

                        break;
                    }
                }

                // Xóa sản phẩm khỏi hóa đơn
                dgvChiTietHoaDon.Rows.Remove(dong);

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
            TinhTienThanhToan();
        }


        private void TinhTienThanhToan()
        {
            decimal tongTien = 0;
            decimal.TryParse(txtTongTien.Text, out tongTien);

            int diemHienCo = 0;
            int.TryParse(txtDiemTichLuyHD.Text, out diemHienCo);

            int diemMoi = (int)(tongTien / 10000m);

            int diemSuDung;
            bool hopLe = int.TryParse(txtDiemSuDung.Text, out diemSuDung);

            if (!hopLe || diemSuDung < 0)
            {
                txtTienGiamGia.Text = "0";
                txtTienPhaiTra.Text = tongTien.ToString("N0");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                diemSuDung > diemHienCo + diemMoi ||
                diemSuDung * 1000m > tongTien)
            {
                txtTienGiamGia.Text = "0";
                txtTienPhaiTra.Text = tongTien.ToString("N0");
                return;
            }

            decimal tienGiamGia = diemSuDung * 1000m;

            txtTienGiamGia.Text = tienGiamGia.ToString("N0");
            txtTienPhaiTra.Text = (tongTien - tienGiamGia).ToString("N0");
        }


        private void txtDiemSuDung_TextChanged(object sender, EventArgs e)
        {
            TinhTienThanhToan();
        }

        //Thêm mã hóa đơn mới

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra hóa đơn hiện tại đã có sản phẩm chưa
            if (dgvChiTietHoaDon.Rows
                .Cast<DataGridViewRow>()
                .Any(row => !row.IsNewRow))
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn bắt đầu hóa đơn mới không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            // Xóa chi tiết hóa đơn cũ
            dgvChiTietHoaDon.Rows.Clear();

            // Xóa thông tin sản phẩm và khách hàng đang nhập
            LamTrongThongTinSanPham();

            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiemTichLuy.Clear();
            txtDiemTichLuyHD.Clear();
            txtDiemSuDung.Clear();
            txtTienGiamGia.Clear();
            txtTienPhaiTra.Clear();
            txtTongTien.Clear();
            txtMaHD.Clear();

            CapNhatTongTien();

            // Đặt tổng tiền về 0
            txtTongTien.Text = "0";

            // Tạo mã hóa đơn mới
            TaoMaHoaDonMoi();

            MessageBox.Show(
                "Đã tạo hóa đơn mới. Bạn có thể thêm sản phẩm.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Tạo mã hóa đơn mới

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra hóa đơn có sản phẩm chưa
            if (dgvChiTietHoaDon.Rows.Count == 0 ||
                (dgvChiTietHoaDon.Rows.Count == 1 &&
                 dgvChiTietHoaDon.Rows[0].IsNewRow))
            {
                MessageBox.Show("Hóa đơn chưa có sản phẩm.");
                return;
            }

            // 2. Kiểm tra mã hóa đơn
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Mã hóa đơn đang trống.");
                return;
            }

            // 3. Lấy mã nhân viên đang đăng nhập
            string maNV = UserSession.MaNV;

            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show(
                    "Không xác định được nhân viên đang đăng nhập. " +
                    "Vui lòng đăng nhập lại.");
                return;
            }

            // 4. Lấy mã khách hàng
            string maKH = string.IsNullOrWhiteSpace(txtMaKH.Text)
                ? null
                : txtMaKH.Text.Trim();

            try
            {
                // 5. Tính tổng tiền
                decimal tongTien = 0;

                foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    if (row.Cells["colThanhTien"].Value == null)
                        continue;

                    tongTien += Convert.ToDecimal(
                        row.Cells["colThanhTien"].Value);
                }

                // 6. Lấy chi tiết hóa đơn
                DataTable dtChiTiet = LayChiTietHoaDon();
                int diemHienCo = 0;
                int.TryParse(txtDiemTichLuyHD.Text, out diemHienCo);

                int diemSuDung = 0;
                int.TryParse(txtDiemSuDung.Text, out diemSuDung);

                int diemMoi = (int)(tongTien / 10000m);

                if (string.IsNullOrWhiteSpace(maKH) && diemSuDung > 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng trước khi sử dụng điểm.");
                    return;
                }

                if (diemSuDung > diemHienCo + diemMoi)
                {
                    MessageBox.Show("Số điểm sử dụng vượt quá số điểm được phép.");
                    return;
                }
                // 7. Lưu hóa đơn và chi tiết hóa đơn
                hoaDonRepository.LuuHoaDon(
                txtMaHD.Text.Trim(),
                tongTien,
                DateTime.Now,
                maKH,
                maNV,
                dtChiTiet,
                diemSuDung
                );
                TaiDanhSachSanPham();
                MessageBox.Show(
                    "Lưu hóa đơn và chi tiết hóa đơn thành công!");

                // 8. Xóa dữ liệu sau khi lưu thành công
                dgvChiTietHoaDon.Rows.Clear();

                txtMaKH.Clear();
                txtTenKH.Clear();
                txtSDT.Clear();
                txtEmail.Clear();
                txtDiemTichLuy.Clear();
                txtDiemTichLuyHD.Clear();
                txtDiemSuDung.Clear();
                txtTienGiamGia.Clear();
                txtTienPhaiTra.Clear();
                txtTongTien.Clear();
                txtMaHD.Clear();

                CapNhatTongTien();

             
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
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
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
            txtSoLuong.Clear();
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
                    lblMaNV.Text.Replace("Mã NV:", "").Trim(),
                    DateTime.Now,
                    dgvChiTietHoaDon,
                    txtTongTien.Text,
                    txtTienGiamGia.Text,
                    txtDiemSuDung.Text,
                    txtTienPhaiTra.Text
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

        private readonly List<KhachHang> danhSachKH = new List<KhachHang>();


        private bool KiemTraThongTinKhachHang(
            string maKH, string tenKH, string sdt, string email)
        {
            // Kiểm tra mã khách hàng và họ tên
            if (string.IsNullOrWhiteSpace(maKH) ||
                string.IsNullOrWhiteSpace(tenKH))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng và họ tên.");
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại để tích điểm.");
                txtSDT.Focus();
                return false;
            }

            if (!Regex.IsMatch(sdt, @"^0[0-9]{9}$") || sdt.Distinct().Count() == 1)
            {
                MessageBox.Show(
                    "Số điện thoại phải bắt đầu bằng 0, đủ 10 chữ số và không được gồm 10 số giống hệt nhau.");

                txtSDT.Focus();
                return false;
            }

            // Email không bắt buộc
            // Chỉ kiểm tra định dạng nếu khách có nhập email
            if (!string.IsNullOrWhiteSpace(email))
            {
                try
                {
                    MailAddress diaChi = new MailAddress(email);

                    if (diaChi.Address != email)
                        throw new FormatException();
                }
                catch
                {
                    MessageBox.Show(
                        "Email không đúng định dạng. Ví dụ: abc@gmail.com");
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnTaoMaKH_Click(object sender, EventArgs e)
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            string maKH;

            using (SqlConnection conn = new SqlConnection(
                @"Data Source=localhost;Initial Catalog=SupermarketManagement_New;Integrated Security=True"))
            {
                conn.Open();

                string sql = @"SELECT COUNT(*) FROM KhachHang
                       WHERE MaKH LIKE @ngay + '%'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ngay", "KH" + ngay);
                    int so = (int)cmd.ExecuteScalar() + 1;
                    maKH = "KH" + ngay + so.ToString("D3");
                }
            }

            txtMaKH.Text = maKH;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            // 1. Kiểm tra thông tin khách hàng
            if (!KiemTraThongTinKhachHang(maKH, tenKH, sdt, email))
                return;

            try
            {
                DbConection db = new DbConection();

                // 2. Kiểm tra mã khách hàng đã tồn tại chưa
                DataTable dt = db.GetTable(
                    "SELECT MaKH FROM dbo.KhachHang WHERE MaKH = @MaKH",
                    new SqlParameter("@MaKH", maKH));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại.");
                    return;
                }

                // 3. Kiểm tra số điện thoại đã đăng ký chưa
                dt = db.GetTable(
                    "SELECT MaKH FROM dbo.KhachHang WHERE SoDienThoai = @SDT",
                    new SqlParameter("@SDT", sdt));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(
                        "Số điện thoại này đã được đăng ký. " +
                        "Vui lòng tìm khách hàng cũ để tích điểm.");
                    return;
                }

                // 4. Chỉ kiểm tra email trùng nếu khách có nhập email
                if (!string.IsNullOrWhiteSpace(email))
                {
                    dt = db.GetTable(
                        "SELECT MaKH FROM dbo.KhachHang WHERE Email = @Email",
                        new SqlParameter("@Email", email));

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Email đã được đăng ký.");
                        txtEmail.Focus();
                        return;
                    }
                }

                // 5. Email trống thì lưu NULL
                object giaTriEmail = string.IsNullOrWhiteSpace(email)
                    ? (object)DBNull.Value
                    : email;

                // 6. Thêm khách hàng vào database
                string sql = @"
            INSERT INTO dbo.KhachHang
                (MaKH, HoTen, SoDienThoai, Email,
                 NgayDangKy, DiemTichLuy)
            VALUES
                (@MaKH, @HoTen, @SDT, @Email,
                 GETDATE(), 0)";

                int soDong = db.ExecuteNonQuery(
                    sql,
                    new SqlParameter("@MaKH", maKH),
                    new SqlParameter("@HoTen", tenKH),
                    new SqlParameter("@SDT", sdt),
                    new SqlParameter("@Email", giaTriEmail));

                if (soDong > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công.");

                    // Xóa thông tin sau khi thêm thành công
                    txtMaKH.Clear();
                    txtTenKH.Clear();
                    txtSDT.Clear();
                    txtEmail.Clear();
                }
                else
                {
                    MessageBox.Show("Không thêm được khách hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi thêm khách hàng:\n" + ex.Message);
            }
        }


        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (!KiemTraThongTinKhachHang(maKH, tenKH, sdt, email))
                return;

            try
            {
                DbConection db = new DbConection();

                // Kiểm tra khách hàng có tồn tại
                DataTable dt = db.GetTable(
                    "SELECT MaKH FROM dbo.KhachHang WHERE MaKH = @MaKH",
                    new SqlParameter("@MaKH", maKH));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng cần sửa.");
                    return;
                }

                // Kiểm tra số điện thoại có thuộc khách hàng khác không
                dt = db.GetTable(
                    @"SELECT MaKH FROM dbo.KhachHang
              WHERE SoDienThoai = @SDT AND MaKH <> @MaKH",
                    new SqlParameter("@SDT", sdt),
                    new SqlParameter("@MaKH", maKH));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Số điện thoại đã được khách hàng khác đăng ký.");
                    return;
                }

                // Kiểm tra email có thuộc khách hàng khác không
                dt = db.GetTable(
                    @"SELECT MaKH FROM dbo.KhachHang
              WHERE Email = @Email AND MaKH <> @MaKH",
                    new SqlParameter("@Email", email),
                    new SqlParameter("@MaKH", maKH));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Email đã được khách hàng khác đăng ký.");
                    return;
                }

                string sql = @"
            UPDATE dbo.KhachHang
            SET HoTen = @HoTen,
                SoDienThoai = @SDT,
                Email = @Email
            WHERE MaKH = @MaKH";

                int soDong = db.ExecuteNonQuery(
                    sql,
                    new SqlParameter("@HoTen", tenKH),
                    new SqlParameter("@SDT", sdt),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@MaKH", maKH));

                MessageBox.Show(soDong > 0
                    ? "Sửa khách hàng thành công."
                    : "Không có dữ liệu được cập nhật.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa khách hàng:\n" + ex.Message);
            }
        }



        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();

            if (maKH == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa.");
                txtMaKH.Focus();
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách hàng " + maKH + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
                return;

            try
            {
                DbConection db = new DbConection();

                int soDong = db.ExecuteNonQuery(
                    "DELETE FROM dbo.KhachHang WHERE MaKH = @MaKH",
                    new SqlParameter("@MaKH", maKH));

                if (soDong > 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công.");
                    txtMaKH.Clear();
                    txtTenKH.Clear();
                    txtSDT.Clear();
                    txtEmail.Clear();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa khách hàng. Có thể khách hàng đã có hóa đơn liên quan.\n"
                    + ex.Message);
            }
        }


        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();

            if (sdt == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                txtSDT.Focus();
                return;
            }

            try
            {
                DbConection db = new DbConection();

                string sql = @"
            SELECT MaKH, HoTen, SoDienThoai, Email, DiemTichLuy
            FROM dbo.KhachHang
            WHERE SoDienThoai = @SDT";

                DataTable dt = db.GetTable(
                    sql,
                    new SqlParameter("@SDT", sdt));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng.");

                    txtMaKH.Clear();
                    txtTenKH.Clear();
                    txtEmail.Clear();
                    txtDiemTichLuy.Clear();
                    txtDiemTichLuyHD.Clear();

                    return;
                }

                if (dt.Rows.Count > 1)
                {
                    MessageBox.Show(
                        "Số điện thoại bị trùng trong database. Vui lòng kiểm tra dữ liệu.");

                    return;
                }

                DataRow row = dt.Rows[0];

                txtMaKH.Text = Convert.ToString(row["MaKH"]);
                txtTenKH.Text = Convert.ToString(row["HoTen"]);
                txtEmail.Text = row["Email"] == DBNull.Value
                    ? ""
                    : Convert.ToString(row["Email"]);

                txtDiemTichLuy.Text = row["DiemTichLuy"] == DBNull.Value
                    ? "0"
                    : Convert.ToString(row["DiemTichLuy"]);

                txtDiemTichLuyHD.Text = txtDiemTichLuy.Text;

                TinhTienThanhToan();

                MessageBox.Show("Tìm thấy khách hàng.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm khách hàng:\n" + ex.Message);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
        "Bạn có chắc chắn muốn thoát không?",
        "Xác nhận thoát",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

       
    }

}
