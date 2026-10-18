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
            ApDungGiaoDienThongNhat();
            this.AutoScroll = false;
            this.Resize += (s, e) => LayoutPOSForm();

            LayoutPOSForm();
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

        //private void btnThemSP_Click(object sender, EventArgs e)
        //{
        //    string maSP = txtMaSP.Text.Trim();
        //    string tenSP = txtTenSP.Text.Trim();

        //    if (maSP == "" || tenSP == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập mã và tên sản phẩm.");
        //        return;
        //    }

        //    if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia)
        //        || donGia <= 0)
        //    {
        //        MessageBox.Show("Đơn giá phải là số lớn hơn 0.");
        //        txtDonGia.Focus();
        //        return;
        //    }

        //    if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong)
        //        || soLuong <= 0)
        //    {
        //        MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0.");
        //        txtSoLuong.Focus();
        //        return;
        //    }

        //    // Tìm sản phẩm trong danh sách tồn kho
        //    DataGridViewRow dongSanPham = null;

        //    foreach (DataGridViewRow row in dgvDSSP.Rows)
        //    {
        //        if (row.IsNewRow)
        //            continue;

        //        if (Convert.ToString(row.Cells["colMaSP_DSSP"].Value) == maSP)
        //        {
        //            dongSanPham = row;
        //            break;
        //        }
        //    }

        //    if (dongSanPham == null)
        //    {
        //        MessageBox.Show("Không tìm thấy sản phẩm trong danh sách tồn kho.");
        //        return;
        //    }

        //    int tonKho = Convert.ToInt32(
        //        dongSanPham.Cells["colSoLuong_DSSP"].Value);

        //    if (soLuong > tonKho)
        //    {
        //        MessageBox.Show("Số lượng tồn kho không đủ!");
        //        return;
        //    }

        //    // Kiểm tra sản phẩm đã có trong hóa đơn chưa
        //    foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
        //    {
        //        if (row.IsNewRow)
        //            continue;

        //        if (Convert.ToString(row.Cells["colMaSP"].Value) == maSP)
        //        {
        //            decimal giaCu = Convert.ToDecimal(
        //                row.Cells["colDonGia"].Value);

        //            if (giaCu != donGia)
        //            {
        //                MessageBox.Show(
        //                    "Mã sản phẩm này đã có trong hóa đơn với đơn giá khác.");
        //                return;
        //            }

        //            int soLuongCu = Convert.ToInt32(
        //                row.Cells["colSoLuong"].Value);

        //            row.Cells["colSoLuong"].Value = soLuongCu + soLuong;
        //            row.Cells["colThanhTien"].Value =
        //                (soLuongCu + soLuong) * donGia;

        //            // Trừ số lượng tồn kho


        //            CapNhatTongTien();
        //            LamTrongThongTinSanPham();
        //            return;
        //        }
        //    }

        //    // Thêm sản phẩm mới vào chi tiết hóa đơn
        //    dgvChiTietHoaDon.Rows.Add(
        //        maSP,
        //        tenSP,
        //        soLuong,
        //        donGia,
        //        soLuong * donGia
        //    );

        //    // Trừ số lượng tồn kho
         
        //    CapNhatTongTien();
        //    LamTrongThongTinSanPham();
        //}


        // Sửa sản phẩm đang được chọn trong hóa đơn

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.CurrentRow == null ||
                dgvChiTietHoaDon.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong chi tiết hóa đơn.");
                return;
            }
            txtTenSP.ReadOnly = true;
            txtSoLuong.ReadOnly = false;
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
            // Bước 1: Mở ô tên sản phẩm
            if (txtTenSP.ReadOnly && txtMaSP.ReadOnly)
            {
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtDonGia.Clear();
                txtSoLuong.Clear();

                txtTenSP.ReadOnly = false;
                txtMaSP.ReadOnly = true;
                txtDonGia.ReadOnly = true;
                txtSoLuong.ReadOnly = true;

                txtTenSP.Focus();
                return;
            }

            string tenSP = txtTenSP.Text.Trim();

            if (tenSP == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                txtTenSP.Focus();
                return;
            }

            // Đếm số sản phẩm khớp với tên tìm kiếm
            int soKetQua = 0;
            DataGridViewRow dongTimThay = null;

            foreach (DataGridViewRow row in dgvDSSP.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string tenTrongBang = Convert.ToString(
                    row.Cells["colTenSP_DSSP"].Value);

                if (tenTrongBang != null &&
                    tenTrongBang.IndexOf(
                        tenSP, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    soKetQua++;
                    dongTimThay = row;
                }
            }

            // Không tìm thấy
            if (soKetQua == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
                txtTenSP.Focus();
                txtTenSP.SelectAll();
                return;
            }

            // Có nhiều sản phẩm trùng tên
            if (soKetQua > 1 && txtMaSP.ReadOnly)
            {
                MessageBox.Show(
                    "Có nhiều sản phẩm trùng tên. Vui lòng nhập mã sản phẩm để tìm chính xác.");

                txtMaSP.ReadOnly = false;
                txtMaSP.Focus();
                return;
            }

            // Nếu đã nhập mã, tìm đúng sản phẩm theo cả tên và mã
            if (!txtMaSP.ReadOnly)
            {
                string maSP = txtMaSP.Text.Trim();
                dongTimThay = null;

                foreach (DataGridViewRow row in dgvDSSP.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    string maTrongBang = Convert.ToString(
                        row.Cells["colMaSP_DSSP"].Value);

                    string tenTrongBang = Convert.ToString(
                        row.Cells["colTenSP_DSSP"].Value);

                    if (maTrongBang == maSP &&
                        tenTrongBang != null &&
                        tenTrongBang.IndexOf(
                            tenSP, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        dongTimThay = row;
                        break;
                    }
                }

                if (dongTimThay == null)
                {
                    MessageBox.Show("Mã sản phẩm không khớp với tên đã nhập!");
                    txtMaSP.Focus();
                    txtMaSP.SelectAll();
                    return;
                }
            }

            // Hiển thị sản phẩm tìm thấy
            txtMaSP.Text = Convert.ToString(
                dongTimThay.Cells["colMaSP_DSSP"].Value);

            txtTenSP.Text = Convert.ToString(
                dongTimThay.Cells["colTenSP_DSSP"].Value);

            txtDonGia.Text = Convert.ToString(
                dongTimThay.Cells["colDonGiaBan_DSSP"].Value);

            txtSoLuong.Text = "1";

            // Khóa cả 4 ô sau khi tìm thành công
            txtMaSP.ReadOnly = true;
            txtTenSP.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtSoLuong.ReadOnly = true;
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
            string maNV = UserSession.MaNV.ToString();

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


        //private void btnSuaKH_Click(object sender, EventArgs e)
        //{
        //    string maKH = txtMaKH.Text.Trim();
        //    string tenKH = txtTenKH.Text.Trim();
        //    string sdt = txtSDT.Text.Trim();
        //    string email = txtEmail.Text.Trim();

        //    if (!KiemTraThongTinKhachHang(maKH, tenKH, sdt, email))
        //        return;

        //    try
        //    {
        //        DbConection db = new DbConection();

        //        // Kiểm tra khách hàng có tồn tại
        //        DataTable dt = db.GetTable(
        //            "SELECT MaKH FROM dbo.KhachHang WHERE MaKH = @MaKH",
        //            new SqlParameter("@MaKH", maKH));

        //        if (dt.Rows.Count == 0)
        //        {
        //            MessageBox.Show("Không tìm thấy khách hàng cần sửa.");
        //            return;
        //        }

        //        // Kiểm tra số điện thoại có thuộc khách hàng khác không
        //        dt = db.GetTable(
        //            @"SELECT MaKH FROM dbo.KhachHang
        //      WHERE SoDienThoai = @SDT AND MaKH <> @MaKH",
        //            new SqlParameter("@SDT", sdt),
        //            new SqlParameter("@MaKH", maKH));

        //        if (dt.Rows.Count > 0)
        //        {
        //            MessageBox.Show("Số điện thoại đã được khách hàng khác đăng ký.");
        //            return;
        //        }

        //        // Kiểm tra email có thuộc khách hàng khác không
        //        dt = db.GetTable(
        //            @"SELECT MaKH FROM dbo.KhachHang
        //      WHERE Email = @Email AND MaKH <> @MaKH",
        //            new SqlParameter("@Email", email),
        //            new SqlParameter("@MaKH", maKH));

        //        if (dt.Rows.Count > 0)
        //        {
        //            MessageBox.Show("Email đã được khách hàng khác đăng ký.");
        //            return;
        //        }

        //        string sql = @"
        //    UPDATE dbo.KhachHang
        //    SET HoTen = @HoTen,
        //        SoDienThoai = @SDT,
        //        Email = @Email
        //    WHERE MaKH = @MaKH";

        //        int soDong = db.ExecuteNonQuery(
        //            sql,
        //            new SqlParameter("@HoTen", tenKH),
        //            new SqlParameter("@SDT", sdt),
        //            new SqlParameter("@Email", email),
        //            new SqlParameter("@MaKH", maKH));

        //        MessageBox.Show(soDong > 0
        //            ? "Sửa khách hàng thành công."
        //            : "Không có dữ liệu được cập nhật.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi sửa khách hàng:\n" + ex.Message);
        //    }
        //}



        //private void btnXoaKH_Click(object sender, EventArgs e)
        //{
        //    string maKH = txtMaKH.Text.Trim();

        //    if (maKH == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa.");
        //        txtMaKH.Focus();
        //        return;
        //    }

        //    DialogResult ketQua = MessageBox.Show(
        //        "Bạn có chắc chắn muốn xóa khách hàng " + maKH + "?",
        //        "Xác nhận xóa",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question);

        //    if (ketQua != DialogResult.Yes)
        //        return;

        //    try
        //    {
        //        DbConection db = new DbConection();

        //        int soDong = db.ExecuteNonQuery(
        //            "DELETE FROM dbo.KhachHang WHERE MaKH = @MaKH",
        //            new SqlParameter("@MaKH", maKH));

        //        if (soDong > 0)
        //        {
        //            MessageBox.Show("Xóa khách hàng thành công.");
        //            txtMaKH.Clear();
        //            txtTenKH.Clear();
        //            txtSDT.Clear();
        //            txtEmail.Clear();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không tìm thấy khách hàng cần xóa.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //            "Không thể xóa khách hàng. Có thể khách hàng đã có hóa đơn liên quan.\n"
        //            + ex.Message);
        //    }
        //}


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
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserSession.DangXuat(this);
            }
        }

        private void ApDungGiaoDienThongNhat()
        {
            // Màu sắc đồng bộ với giao diện Admin
            Color xanhChuDao = Color.FromArgb(8, 181, 232);
            Color xanhDuong = Color.FromArgb(0, 123, 255);
            Color xanhLa = Color.FromArgb(40, 167, 69);
            Color doo = Color.FromArgb(220, 53, 69);

            Color cam = Color.FromArgb(255, 193, 7);
            Color nen = Color.FromArgb(244, 246, 249);

            // Giao diện chung
            this.BackColor = nen;
            this.Font = new Font("Segoe UI", 10F);

       
            // Tiêu đề QUẢN LÝ BÁN HÀNG
            lblTieuDe.BackColor = Color.Transparent;
            lblTieuDe.ForeColor = Color.FromArgb(33, 37, 41);
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.AutoSize = false;
            lblTieuDe.Location = new Point(0, 45);
            lblTieuDe.Size = new Size(this.ClientSize.Width, 38);
            lblTieuDe.Anchor = AnchorStyles.Top
                             | AnchorStyles.Left
                             | AnchorStyles.Right;

            // Mã nhân viên
            lblMaNV.ForeColor = Color.FromArgb(33, 37, 41);
            lblMaNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(600, 88);

            // Tên nhân viên
            lblTenNV.ForeColor = Color.FromArgb(33, 37, 41);
            lblTenNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblTenNV.AutoSize = true;
            lblTenNV.Location = new Point(790, 88);

            // Các khu vực thông tin
            GroupBox[] nhom = {
                grpSanPham,
                grpKhachHang,
                grpHoaDon
            };

            foreach (GroupBox group in nhom)
            {
                group.BackColor = Color.White;
                group.ForeColor = Color.FromArgb(40, 50, 65);
                group.Font = new Font("Segoe UI", 10F,
                                      FontStyle.Bold);
            }

            // Nút chức năng
            Button[] tatCaNut = {
                btnSuaSP,
                btnTimKiemSP,
                btnThemKH,
                btnTimKiemKH,
                btnTaoMaKH,
                btnThemHoaDon,
                btnTaoHoaDon,
                btnXuatHoaDon,
                btnLamMoi,
                btnThoat,
                btnXoaSPKhoiHD
            };

            foreach (Button nut in tatCaNut)
            {
                nut.FlatStyle = FlatStyle.Flat;
                nut.FlatAppearance.BorderSize = 0;
                nut.ForeColor = Color.White;
                nut.Font = new Font("Segoe UI", 9.5F,
                                    FontStyle.Bold);
                nut.Cursor = Cursors.Hand;

                string ten = nut.Text.ToLower();

                if (ten.Contains("xóa"))
                    nut.BackColor = doo;
                else if (ten.Contains("thêm"))
                    nut.BackColor = xanhLa;
                else if (ten.Contains("tìm kiếm")
                      || ten.Contains("tạo hóa đơn"))
                    nut.BackColor = xanhDuong;
                else if (ten.Contains("sửa"))
                    nut.BackColor = cam;
                else if (ten.Contains("xuất"))
                    nut.BackColor = xanhChuDao;
                else
                    nut.BackColor = Color.FromArgb(108, 117, 125);
            }

            // Hai bảng dữ liệu
            DataGridView[] bang = {
                dgvDSSP,
                dgvChiTietHoaDon
                };

            foreach (DataGridView dgv in bang)
            {
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.FixedSingle;
                dgv.GridColor = Color.FromArgb(220, 225, 230);

                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = xanhChuDao;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Segoe UI", 10F, FontStyle.Bold);
                dgv.ColumnHeadersHeight = 35;

                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor =
                    Color.FromArgb(40, 50, 65);
                dgv.DefaultCellStyle.SelectionBackColor =
                    Color.FromArgb(204, 235, 250);
                dgv.DefaultCellStyle.SelectionForeColor =
                    Color.FromArgb(30, 40, 50);

                dgv.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.FromArgb(240, 247, 252);

                dgv.RowTemplate.Height = 30;

            }
        }

        private void LayoutPOSForm()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            if (w < 500 || h < 500)
                return;

            int margin = 10;
            int gap = 12;

            // Tiêu đề: nền trong suốt, chữ đen
            lblTieuDe.BackColor = Color.Transparent;
            lblTieuDe.ForeColor = Color.FromArgb(33, 37, 41);
            lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;
            lblTieuDe.Location = new Point(10, 45);
            lblTieuDe.Size = new Size(w - 20, 38);
            lblTieuDe.Anchor = AnchorStyles.Top
                             | AnchorStyles.Left
                             | AnchorStyles.Right;

            // Căn chỉnh thông tin nhân viên
            // Font giống label Mã sản phẩm
            lblMaNV.Font = lblMaSP.Font;
            lblTenNV.Font = lblMaSP.Font;
            // Mã nhân viên
            lblMaNV.Location = new Point(w / 2 + 250, 5);

            // Tên nhân viên
            lblTenNV.Location = new Point(w / 2 + 450, 5);
            int topY = 48;
            int topH = 195;
            int groupW = (w - margin * 2 - gap) / 2;

            grpSanPham.Location = new Point(margin, topY);
            grpSanPham.Size = new Size(groupW, topH);

            grpKhachHang.Location =
                new Point(margin + groupW + gap, topY);
            grpKhachHang.Size = new Size(groupW, topH);

            // Thông tin sản phẩm
            lblMaSP.Location = new Point(15, 30);
            txtMaSP.Location = new Point(135, 27);
            txtMaSP.Size = new Size(Math.Max(120, groupW / 3), 26);

            lblTenSP.Location = new Point(15, 63);
            txtTenSP.Location = new Point(135, 60);
            txtTenSP.Size = new Size(Math.Max(150, groupW / 2), 26);

            lblDonGia.Location = new Point(15, 96);
            txtDonGia.Location = new Point(135, 93);
            txtDonGia.Size = new Size(140, 26);

            lblSoLuong.Location = new Point(15, 129);
            txtSoLuong.Location = new Point(135, 126);
            txtSoLuong.Size = new Size(140, 26);

            int buttonY = 157;
            int buttonW = Math.Min(130, (groupW - 45) / 2);

            btnSuaSP.Location = new Point(30, buttonY);
            btnSuaSP.Size = new Size(buttonW, 32);

            btnTimKiemSP.Location =
                new Point(groupW - buttonW - 30, buttonY);
            btnTimKiemSP.Size = new Size(buttonW, 32);

            // Thông tin khách hàng
            lblMaKH.Location = new Point(15, 30);
            txtMaKH.Location = new Point(145, 27);
            txtMaKH.Size = new Size(Math.Max(130, groupW / 3), 26);

            lblTenKH.Location = new Point(15, 63);
            txtTenKH.Location = new Point(145, 60);
            txtTenKH.Size = new Size(Math.Max(130, groupW / 3), 26);

            lblSDT.Location = new Point(15, 96);
            txtSDT.Location = new Point(145, 93);
            txtSDT.Size = new Size(Math.Max(130, groupW / 3), 26);

            lblEmain.Location = new Point(15, 129);
            txtEmail.Location = new Point(145, 126);
            txtEmail.Size = new Size(Math.Max(130, groupW / 3), 26);

            btnTaoMaKH.Location =
                new Point(groupW - 145, 27);
            btnTaoMaKH.Size = new Size(130, 30);

            txtDiemTichLuy.Location =
                new Point(groupW - 145, 65);
            txtDiemTichLuy.Size = new Size(130, 26);

            btnThemKH.Location = new Point(145, 157);
            btnThemKH.Size = new Size(130, 32);

            btnTimKiemKH.Location =
                new Point(groupW - 145, 157);
            btnTimKiemKH.Size = new Size(130, 32);

            // 3. Danh sách sản phẩm
            int labelY = topY + topH + 4;
            label2.AutoSize = false;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Location = new Point(margin, labelY);
            label2.Size = new Size(w - margin * 2, 25);

            int productY = labelY + 27;
            int productH = Math.Max(100, (h - productY) / 5);

            dgvDSSP.Location = new Point(margin, productY);
            dgvDSSP.Size = new Size(w - margin * 2, productH);
            dgvDSSP.Anchor = AnchorStyles.Top
                           | AnchorStyles.Left
                           | AnchorStyles.Right;

            // 4. Chi tiết hóa đơn
            int detailLabelY = productY + productH + 4;

            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Location = new Point(margin, detailLabelY);
            label1.Size = new Size(w - margin * 2, 25);

            int detailY = detailLabelY + 27;
            int bottomH = 175;
            int deleteH = 35;
            int detailH = Math.Max(
                80,
                h - detailY - deleteH - bottomH - 4 * margin
            );

            dgvChiTietHoaDon.Location = new Point(margin, detailY);
            dgvChiTietHoaDon.Size =
                new Size(w - margin * 2, detailH);
            dgvChiTietHoaDon.Anchor = AnchorStyles.Top
                                    | AnchorStyles.Left
                                    | AnchorStyles.Right;

            btnXoaSPKhoiHD.Location = new Point(
                w - margin - 135,
                detailY + detailH + 3
            );
            btnXoaSPKhoiHD.Size = new Size(135, deleteH);

            // 5. Khu vực hóa đơn
            int invoiceY = btnXoaSPKhoiHD.Bottom + 3;

            grpHoaDon.Location = new Point(margin, invoiceY);
            grpHoaDon.Size = new Size(
                w - margin * 2,
                Math.Max(160, h - invoiceY - margin)
            );

            grpHoaDon.Anchor = AnchorStyles.Top
                             | AnchorStyles.Left
                             | AnchorStyles.Right
                             | AnchorStyles.Bottom;

            // Các trường hóa đơn được bố trí thành 3 cột
            int invoiceW = grpHoaDon.ClientSize.Width;

            int marginLeft = 15;
            int labelWidth = 115;

            int col1 = marginLeft;
            int col2 = invoiceW / 3;
            int col3 = invoiceW * 2 / 3;

            // Cột 1: Mã hóa đơn và điểm tích lũy
            lblMaHD.Location = new Point(col1, 35);
            txtMaHD.Location = new Point(col1 + labelWidth, 30);
            txtMaHD.Width = 180;

            lblDiemTichLuy.Location = new Point(col1, 75);
            txtDiemTichLuyHD.Location = new Point(
                 txtMaHD.Left,
                 70
             );
            txtDiemTichLuy.Width = 165;

            // Cột 2: Tổng tiền hàng và điểm sử dụng
            lblTongTien.Location = new Point(col2, 35);
            txtTongTien.Location = new Point(col2 + labelWidth, 30);
            txtTongTien.Width = 150;

            lblDiemSuDung.Location = new Point(col2, 75);
            txtDiemSuDung.Location = new Point(col2 + labelWidth, 70);
            txtDiemSuDung.Width = 150;

            // Cột 3: Tiền giảm giá và khách hàng trả
            label5.Location = new Point(col3, 35);
            txtTienGiamGia.Location = new Point(col3 + labelWidth, 30);
            txtTienGiamGia.Width = 150;

            label4.Location = new Point(col3, 75);
            txtTienPhaiTra.Location = new Point(col3 + labelWidth, 70);
            txtTienPhaiTra.Width = 150;

            // Nhóm nút phía dưới
            int btnY = grpHoaDon.ClientSize.Height - 48;
            int btnWidth = Math.Min(130, (invoiceW - 60) / 5);
            int btnGap = (invoiceW - 2 * margin - 5 * btnWidth) / 4;

            Button[] buttons =
            {
                btnThemHoaDon,
                btnTaoHoaDon,
                btnXuatHoaDon,
                btnLamMoi,
                btnThoat
            };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Location = new Point(
                    margin + i * (btnWidth + btnGap),
                    btnY
                );
                buttons[i].Size = new Size(btnWidth, 38);
            }
        }


    }

}
