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

            txtMaHD.ReadOnly = true;
            txtTongTien.ReadOnly = true;

            TaoMaHoaDonMoi();
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

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong)
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

            // Kiểm tra sản phẩm đã có trong hóa đơn chưa
            foreach (DataGridViewRow dong in dgvChiTietHoaDon.Rows)
            {
                if (dong.IsNewRow)
                    continue;

                if (dong.Cells["colMaSP"].Value?.ToString() == maSP)
                {
                    int soLuong = Convert.ToInt32(
                        dong.Cells["colSoLuong"].Value);

                    dong.Cells["colSoLuong"].Value = soLuong + 1;
                    dong.Cells["colThanhTien"].Value = (soLuong + 1) * donGia;

                    CapNhatTongTien();
                    return;
                }
            }

            // Nếu chưa có, thêm sản phẩm vào hóa đơn
            dgvChiTietHoaDon.Rows.Add(
                maSP,
                tenSP,
                1,
                donGia,
                donGia
            );

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
            if (UserSession.MaNV <= 0)
            {
                MessageBox.Show("Không xác định được nhân viên đang đăng nhập.");
                return;
            }

            string maNV = UserSession.MaNV.ToString();

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
                MessageBox.Show(
                    "MaNV đăng nhập = " + UserSession.MaNV);
                // 7. Lưu hóa đơn và chi tiết hóa đơn
                hoaDonRepository.LuuHoaDon(
                    txtMaHD.Text.Trim(),
                    tongTien,
                    DateTime.Now,
                    maKH,
                    maNV,
                    dtChiTiet
                );

                MessageBox.Show(
                    "Lưu hóa đơn và chi tiết hóa đơn thành công!");

                // 8. Xóa dữ liệu đang lập sau khi lưu thành công
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

        private readonly List<KhachHang> danhSachKH = new List<KhachHang>();

        private bool KiemTraThongTinKhachHang(
             string maKH, string tenKH, string sdt, string email)
        {
            if (maKH == "" || tenKH == "" || sdt == "" || email == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ mã khách hàng, họ tên, số điện thoại và email.");
                return false;
            }

            if (!Regex.IsMatch(sdt, @"^[0-9]{10}$") || sdt == "0000000000")
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số và không được là toàn số 0.");
                txtSDT.Focus();
                return false;
            }

            try
            {
                MailAddress diaChi = new MailAddress(email);

                if (diaChi.Address != email)
                    throw new FormatException();
            }
            catch
            {
                MessageBox.Show("Email không đúng định dạng. Ví dụ: abc@gmail.com");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
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

                // Kiểm tra mã khách hàng trùng trong database
                DataTable dt = db.GetTable(
                    "SELECT MaKH FROM dbo.KhachHang WHERE MaKH = @MaKH",
                    new SqlParameter("@MaKH", maKH));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại.");
                    return;
                }

                // Kiểm tra số điện thoại trùng
                dt = db.GetTable(
                    "SELECT MaKH FROM dbo.KhachHang WHERE SoDienThoai = @SDT",
                    new SqlParameter("@SDT", sdt));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Số điện thoại đã được đăng ký.");
                    return;
                }

                // Kiểm tra email trùng
                dt = db.GetTable(
                    "SELECT MaKH FROM dbo.KhachHang WHERE Email = @Email",
                    new SqlParameter("@Email", email));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Email đã được đăng ký.");
                    return;
                }

                string sql = @"
            INSERT INTO dbo.KhachHang
                (MaKH, HoTen, SoDienThoai, Email, NgayDangKy, DiemTichLuy)
            VALUES
                (@MaKH, @HoTen, @SDT, @Email, GETDATE(), 0)";

                int soDong = db.ExecuteNonQuery(
                    sql,
                    new SqlParameter("@MaKH", maKH),
                    new SqlParameter("@HoTen", tenKH),
                    new SqlParameter("@SDT", sdt),
                    new SqlParameter("@Email", email));

                if (soDong > 0)
                {
                    MessageBox.Show("Thêm khách hàng vào database thành công.");
                }
                else
                {
                    MessageBox.Show("Không thêm được khách hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng:\n" + ex.Message);
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
            string maKH = txtMaKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (maKH == "" && sdt == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập mã khách hàng hoặc số điện thoại.");
                return;
            }

            try
            {
                DbConection db = new DbConection();

                string sql = @"
            SELECT MaKH, HoTen, SoDienThoai, Email
            FROM dbo.KhachHang
            WHERE MaKH = @MaKH OR SoDienThoai = @SDT";

                DataTable dt = db.GetTable(
                    sql,
                    new SqlParameter("@MaKH",
                        string.IsNullOrWhiteSpace(maKH)
                            ? (object)DBNull.Value : maKH),
                    new SqlParameter("@SDT",
                        string.IsNullOrWhiteSpace(sdt)
                            ? (object)DBNull.Value : sdt)
                );

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng trong database.");
                    return;
                }

                DataRow row = dt.Rows[0];

                txtMaKH.Text = Convert.ToString(row["MaKH"]);
                txtTenKH.Text = Convert.ToString(row["HoTen"]);
                txtSDT.Text = Convert.ToString(row["SoDienThoai"]);
                txtEmail.Text = Convert.ToString(row["Email"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm kiếm khách hàng:\n" + ex.Message);
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

      
    }

}
