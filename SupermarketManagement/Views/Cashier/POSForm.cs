using SupermarketManagement.Controllers.Repositories;
using SupermarketManagement.Models.Repositories;
using SupermarketManagement.Utils;
using SupermarketManagement.Views.Cashier;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SupermarketManagement
{
    public partial class POSForm : Form
    {
        // ===== HẰNG SỐ NGHIỆP VỤ =====
        private const decimal TienTichMotDiem = 10000m; // mua 10.000đ được 1 điểm
        private const decimal GiaTriMotDiem = 1000m;    // Giữ hằng số cũ để không ảnh hưởng code khác

        // ===== DỮ LIỆU =====
        private readonly NhanVienRepository nhanVienRepository = new NhanVienRepository();
        private readonly KhachHangRepository khachHangRepository = new KhachHangRepository();
        private readonly HoaDonRepository hoaDonRepository = new HoaDonRepository();
        private readonly SanPhamRepositoryV2 sanPhamRepository = new SanPhamRepositoryV2();

        private DataTable dtSanPham;     // danh sách sản phẩm + tồn kho đang hiển thị
        private decimal tongTienHang;    // tổng tiền hàng của hóa đơn hiện tại
        private int diemHienCo;          // điểm tích lũy của khách đang chọn
        private DataTable dtDonViTinh; // các đơn vị tính của sản phẩm đang chọn
        private bool dangTaiDonViTinh;

        public POSForm()
        {
            InitializeComponent();

            lblNhanVien.Text = "   Nhân viên: " + UserSession.HoTen;

            CauHinhCotDonViTinh();
            dgvDSSP.SelectionChanged += dgvDSSP_SelectionChanged;
            dgvDSSP.CellClick += dgvDSSP_CellClick;
            cboDonViTinh.SelectedIndexChanged += cboDonViTinh_SelectedIndexChanged;

            TaiDanhSachSanPham();
            TaoMaHoaDonMoi();
            CapNhatTongTien();
        }

        // =====================================================================
        // HÀM TIỆN ÍCH
        // =====================================================================

        private static void HienThongBao(string noiDung, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, icon);
        }

        private static bool XacNhan(string noiDung)
        {
            return MessageBox.Show(noiDung, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // =====================================================================
        // DANH SÁCH SẢN PHẨM
        // =====================================================================

        private void TaiDanhSachSanPham()
        {
            try
            {
                dtSanPham = sanPhamRepository.GetListSanPham();

                if (dtSanPham.Columns.Contains("TenDV"))
                    colDonViTinh_DSSP.DataPropertyName = "TenDV";

                if (dtSanPham.Columns.Contains("DonGiaBan"))
                    colDonGiaBan_DSSP.DataPropertyName = "DonGiaBan";

                // Bổ sung ánh xạ Ngày sản xuất & Hạn sử dụng vào DataGridView danh sách sản phẩm
                if (dtSanPham.Columns.Contains("NgaySanXuat") && dgvDSSP.Columns.Contains("colNgaySanXuat_DSSP"))
                    dgvDSSP.Columns["colNgaySanXuat_DSSP"].DataPropertyName = "NgaySanXuat";

                if (dtSanPham.Columns.Contains("NgayHetHan") && dgvDSSP.Columns.Contains("colNgayHetHan_DSSP"))
                    dgvDSSP.Columns["colNgayHetHan_DSSP"].DataPropertyName = "NgayHetHan";

                dgvDSSP.AutoGenerateColumns = false;
                dgvDSSP.DataSource = dtSanPham;

                LocSanPham();
            }
            catch (Exception ex)
            {
                HienThongBao("Lỗi tải sản phẩm: " + ex.Message, MessageBoxIcon.Error);
            }
        }
        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            LocSanPham();
        }

        // Lọc danh sách theo mã hoặc tên (không phân biệt hoa thường)
        private void LocSanPham()
        {
            if (dtSanPham == null)
                return;

            string tuKhoa = txtTimKiemSP.Text.Trim();

            if (tuKhoa.Length == 0)
            {
                dtSanPham.DefaultView.RowFilter = "";
                return;
            }

            string mau = ThoatKyTuLike(tuKhoa);
            dtSanPham.DefaultView.RowFilter =
                "Convert(MaSP, 'System.String') LIKE '%" + mau + "%' OR TenSanPham LIKE '%" + mau + "%'";
        }

        // Các ký tự ' [ ] % * có ý nghĩa đặc biệt trong RowFilter nên phải thoát
        private static string ThoatKyTuLike(string chuoi)
        {
            chuoi = chuoi.Replace("'", "''");
            return Regex.Replace(chuoi, @"[\[\]%*]", m => "[" + m.Value + "]");
        }

        // Tìm dòng sản phẩm trong DataTable (không phụ thuộc bộ lọc đang áp dụng)
        private DataRow TimSanPham(string maSP)
        {
            foreach (DataRow dong in dtSanPham.Rows)
            {
                if (Convert.ToString(dong["MaSP"]) == maSP)
                    return dong;
            }
            return null;
        }

        // =====================================================================
        // CHI TIẾT HÓA ĐƠN
        // =====================================================================


        // Cấu hình các cột động bao gồm đơn vị tính, hệ số quy đổi, ngày sản xuất và hạn sử dụng cho hóa đơn
        // Cấu hình các cột động bao gồm đơn vị tính, hệ số quy đổi, NSX và NHH cho hóa đơn
        private void CauHinhCotDonViTinh()
        {
            if (!dgvChiTietHoaDon.Columns.Contains("colMaDVT"))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "colMaDVT",
                    HeaderText = "Mã đơn vị",
                    Visible = false
                };
                dgvChiTietHoaDon.Columns.Add(col);
            }

            if (!dgvChiTietHoaDon.Columns.Contains("colSoLuongQuyDoi"))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "colSoLuongQuyDoi",
                    HeaderText = "Quy đổi",
                    Visible = false
                };
                dgvChiTietHoaDon.Columns.Add(col);
            }

            // Cột NSX tự co gọn theo độ rộng nội dung
            if (!dgvChiTietHoaDon.Columns.Contains("colNgaySanXuat"))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "colNgaySanXuat",
                    HeaderText = "NSX",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                };
                dgvChiTietHoaDon.Columns.Add(col);
            }

            // Cột NHH tự co gọn theo độ rộng nội dung
            if (!dgvChiTietHoaDon.Columns.Contains("colNgayHetHan"))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "colNgayHetHan",
                    HeaderText = "NHH",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                };
                dgvChiTietHoaDon.Columns.Add(col);
            }

            colDonViTinh_DSSP.DataPropertyName = "TenDV";
            colDonViTinh.DataPropertyName = "TenDV";
            colMaSP.DataPropertyName = "MaSP";
            colTenSP.DataPropertyName = "TenSanPham";
        }

        private void TaiDonViTinh(string maSP)
        {
            try
            {
                dangTaiDonViTinh = true;
                dtDonViTinh = sanPhamRepository.GetDonViTinhTheoSanPham(maSP);
                cboDonViTinh.DataSource = null;

                if (dtDonViTinh == null || dtDonViTinh.Rows.Count == 0)
                {
                    lblQuyDoi.Text = "Sản phẩm chưa có đơn vị tính";
                    return;
                }

                cboDonViTinh.DisplayMember = "TenDV";
                cboDonViTinh.ValueMember = "MaDVT";
                cboDonViTinh.DataSource = dtDonViTinh;
                cboDonViTinh.SelectedIndex = 0;
                CapNhatThongTinQuyDoi();
            }
            catch (Exception ex)
            {
                cboDonViTinh.DataSource = null;
                lblQuyDoi.Text = "Không tải được đơn vị tính";
                HienThongBao("Lỗi tải đơn vị tính: " + ex.Message, MessageBoxIcon.Error);
            }
            finally
            {
                dangTaiDonViTinh = false;
            }
        }

        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDSSP.Rows[e.RowIndex].DataBoundItem == null)
                return;

            DataRow sp = ((DataRowView)dgvDSSP.Rows[e.RowIndex].DataBoundItem).Row;
            string maSP = Convert.ToString(sp["MaSP"]);
            cboDonViTinh.Tag = maSP;
            TaiDonViTinh(maSP);
        }
        private void dgvDSSP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value != DBNull.Value)
            {
                string colName = dgvDSSP.Columns[e.ColumnIndex].Name;
                if (colName == "colNgaySanXuat_DSSP" || colName == "colNgayHetHan_DSSP" ||
                    dgvDSSP.Columns[e.ColumnIndex].DataPropertyName == "NgaySanXuat" ||
                    dgvDSSP.Columns[e.ColumnIndex].DataPropertyName == "NgayHetHan")
                {
                    if (DateTime.TryParse(e.Value.ToString(), out DateTime dateValue))
                    {
                        e.Value = dateValue.ToString("dd/MM/yyyy");
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void cboDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDonViTinh)
                return;

            CapNhatThongTinQuyDoi();
            CapNhatDonViChoDongHoaDonDangChon();
        }

        // Khi đổi đơn vị trên ComboBox, cập nhật dòng hóa đơn đang chọn
        // nếu dòng đó thuộc đúng sản phẩm đang chọn ở danh sách sản phẩm.
        private void CapNhatDonViChoDongHoaDonDangChon()
        {
            DataGridViewRow dong = dgvChiTietHoaDon.CurrentRow;
            DataRowView dvMoi = DonViTinhDangChon();

            if (dong == null || dong.IsNewRow || dvMoi == null)
                return;

            string maSP = Convert.ToString(dong.Cells["colMaSP"].Value);
            string maSPDangChon = Convert.ToString(cboDonViTinh.Tag);

            if (string.IsNullOrWhiteSpace(maSP) || maSP != maSPDangChon)
                return;

            string maDVTMoi = Convert.ToString(dvMoi["MaDVT"]);
            string maDVTCu = Convert.ToString(dong.Cells["colMaDVT"].Value);

            if (maDVTMoi == maDVTCu)
                return;

            decimal donGiaMoi = Convert.ToDecimal(dvMoi["DonGiaBanLe"]);
            if (donGiaMoi <= 0)
            {
                HienThongBao("Đơn vị tính này chưa có giá bán hợp lệ.", MessageBoxIcon.Warning);
                KhoiPhucDonViCu(maDVTCu);
                return;
            }

            DataRow sp = TimSanPham(maSP);
            if (sp == null)
                return;

            int soLuong = Convert.ToInt32(dong.Cells["colSoLuong"].Value);
            int quyDoiCu = Convert.ToInt32(dong.Cells["colSoLuongQuyDoi"].Value);
            int quyDoiMoi = Convert.ToInt32(dvMoi["SoLuongQuyDoi"]);

            if (quyDoiCu <= 0 || quyDoiMoi <= 0)
            {
                HienThongBao("Hệ số quy đổi phải lớn hơn 0.", MessageBoxIcon.Warning);
                KhoiPhucDonViCu(maDVTCu);
                return;
            }

            int tonKhoKhaDung = Convert.ToInt32(sp["SoLuong"]) + soLuong * quyDoiCu;
            int soLuongCoSoMoi = soLuong * quyDoiMoi;

            if (soLuongCoSoMoi > tonKhoKhaDung)
            {
                HienThongBao("Tồn kho không đủ để đổi sang đơn vị " +
                    Convert.ToString(dvMoi["TenDV"]) + ".", MessageBoxIcon.Warning);
                KhoiPhucDonViCu(maDVTCu);
                return;
            }

            dong.Cells["colDonViTinh"].Value = Convert.ToString(dvMoi["TenDV"]);
            dong.Cells["colDonGia"].Value = donGiaMoi;
            dong.Cells["colMaDVT"].Value = maDVTMoi;
            dong.Cells["colSoLuongQuyDoi"].Value = quyDoiMoi;
            DatSoLuongDong(dong, soLuong);

            // Hoàn lại lượng đã giữ theo đơn vị cũ rồi giữ theo đơn vị mới.
            sp["SoLuong"] = tonKhoKhaDung - soLuongCoSoMoi;
            CapNhatTongTien();
        }

        private void KhoiPhucDonViCu(string maDVT)
        {
            if (string.IsNullOrWhiteSpace(maDVT))
                return;

            try
            {
                dangTaiDonViTinh = true;
                cboDonViTinh.SelectedValue = maDVT;
            }
            finally
            {
                dangTaiDonViTinh = false;
            }

            CapNhatThongTinQuyDoi();
        }

        private void CapNhatThongTinQuyDoi()
        {
            DataRowView dv = cboDonViTinh.SelectedItem as DataRowView;
            if (dv == null)
                return;

            int quyDoi = Convert.ToInt32(dv["SoLuongQuyDoi"]);
            lblQuyDoi.Text = "1 " + Convert.ToString(dv["TenDV"]) +
                " = " + quyDoi.ToString("N0") + " đơn vị cơ bản";
        }

        private DataRowView DonViTinhDangChon()
        {
            return cboDonViTinh.SelectedItem as DataRowView;
        }

        private DataGridViewRow TimDongHoaDon(string maSP, string maDVT)
        {
            foreach (DataGridViewRow dong in dgvChiTietHoaDon.Rows)
            {
                if (Convert.ToString(dong.Cells["colMaSP"].Value) == maSP &&
                    Convert.ToString(dong.Cells["colMaDVT"].Value) == maDVT)
                    return dong;
            }
            return null;
        }

        private static void DatSoLuongDong(DataGridViewRow dong, int soLuong)
        {
            decimal donGia = Convert.ToDecimal(dong.Cells["colDonGia"].Value);
            dong.Cells["colSoLuong"].Value = soLuong;
            dong.Cells["colThanhTien"].Value = donGia * soLuong;
        }

        private void dgvDSSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDSSP.Rows[e.RowIndex].DataBoundItem == null)
                return;

            DataRow sp = ((DataRowView)dgvDSSP.Rows[e.RowIndex].DataBoundItem).Row;
            string maSP = Convert.ToString(sp["MaSP"]);

            // Lấy NSX và NHH từ lô nhập có hạn sử dụng gần nhất
            DataRow thongTinLo =
                sanPhamRepository.GetNgaySanXuatVaHetHanGanNhat(maSP);

            string nsx = "";
            string nhh = "";

            if (thongTinLo != null)
            {
                if (thongTinLo["NgaySanXuat"] != DBNull.Value)
                    nsx = Convert.ToDateTime(thongTinLo["NgaySanXuat"]).ToString("dd/MM/yyyy");

                if (thongTinLo["NgayHetHan"] != DBNull.Value)
                    nhh = Convert.ToDateTime(thongTinLo["NgayHetHan"]).ToString("dd/MM/yyyy");
            }
            if (dtDonViTinh == null || dtDonViTinh.Rows.Count == 0 ||
                Convert.ToString(cboDonViTinh.Tag) != maSP)
            {
                TaiDonViTinh(maSP);
                cboDonViTinh.Tag = maSP;
            }

            DataRowView dv = DonViTinhDangChon();
            if (dv == null)
            {
                HienThongBao("Vui lòng chọn đơn vị tính cho sản phẩm.", MessageBoxIcon.Warning);
                return;
            }

            string maDVT = Convert.ToString(dv["MaDVT"]);
            string tenDV = Convert.ToString(dv["TenDV"]);
            int quyDoi = Convert.ToInt32(dv["SoLuongQuyDoi"]);
            decimal donGia = Convert.ToDecimal(dv["DonGiaBanLe"]);
            int tonKhoCoSo = Convert.ToInt32(sp["SoLuong"]);

            DataGridViewRow dongHoaDon = TimDongHoaDon(maSP, maDVT);
            int soLuongCu = dongHoaDon == null ? 0 : Convert.ToInt32(dongHoaDon.Cells["colSoLuong"].Value);

            if (tonKhoCoSo < quyDoi)
            {
                HienThongBao("Tồn kho không đủ cho 1 " + tenDV + ".", MessageBoxIcon.Warning);
                return;
            }

            if (dongHoaDon == null)
            {
                int indexMoi = dgvChiTietHoaDon.Rows.Add();
                dongHoaDon = dgvChiTietHoaDon.Rows[indexMoi];
                dongHoaDon.Cells["colMaSP"].Value = maSP;
                dongHoaDon.Cells["colTenSP"].Value = Convert.ToString(sp["TenSanPham"]);
                dongHoaDon.Cells["colSoLuong"].Value = 1;
                dongHoaDon.Cells["colDonViTinh"].Value = tenDV;
                dongHoaDon.Cells["colDonGia"].Value = donGia;
                dongHoaDon.Cells["colThanhTien"].Value = donGia;
                dongHoaDon.Cells["colMaDVT"].Value = maDVT;
                dongHoaDon.Cells["colSoLuongQuyDoi"].Value = quyDoi;

                // Gán NSX & NHH vào chi tiết dòng hóa đơn
                dongHoaDon.Cells["colNgaySanXuat"].Value = nsx;
                dongHoaDon.Cells["colNgayHetHan"].Value = nhh;
            }
            
            else
            {
                DatSoLuongDong(dongHoaDon, soLuongCu + 1);

                // Cập nhật NSX và NHH
                dongHoaDon.Cells["colNgaySanXuat"].Value = nsx;
                dongHoaDon.Cells["colNgayHetHan"].Value = nhh;
            }
            

            dgvChiTietHoaDon.ClearSelection();
            dongHoaDon.Selected = true;
            dgvChiTietHoaDon.CurrentCell = dongHoaDon.Cells["colMaSP"];
            CapNhatSoLuongMoiTheoDongDangChon();

            sp["SoLuong"] = tonKhoCoSo - quyDoi;
            CapNhatTongTien();
        }

        // Chọn dòng trong chi tiết hóa đơn: cập nhật số lượng hiện tại
        private void dgvChiTietHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            CapNhatSoLuongMoiTheoDongDangChon();
        }
        private void CapNhatSoLuongMoiTheoDongDangChon()
        {
            if (dgvChiTietHoaDon.CurrentRow == null ||
                dgvChiTietHoaDon.CurrentRow.IsNewRow)
            {
                return;
            }

            object giaTri = dgvChiTietHoaDon.CurrentRow
                .Cells["colSoLuong"].Value;

            if (giaTri == null || giaTri == DBNull.Value)
                return;

            if (int.TryParse(Convert.ToString(giaTri), out int soLuong))
            {
                decimal soLuongHienThi = Math.Max(
                    nudSoLuong.Minimum,
                    Math.Min(nudSoLuong.Maximum, soLuong));

                if (nudSoLuong.Value != soLuongHienThi)
                    nudSoLuong.Value = soLuongHienThi;
            }
        }
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            DataGridViewRow dong = dgvChiTietHoaDon.CurrentRow;
            if (dong == null)
            {
                HienThongBao("Vui lòng chọn sản phẩm trong chi tiết hóa đơn.", MessageBoxIcon.Warning);
                return;
            }

            string maSP = Convert.ToString(dong.Cells["colMaSP"].Value);
            int soLuongCu = Convert.ToInt32(dong.Cells["colSoLuong"].Value);
            int soLuongMoi = (int)nudSoLuong.Value;
            int quyDoi = Convert.ToInt32(dong.Cells["colSoLuongQuyDoi"].Value);

            if (soLuongMoi == soLuongCu)
            {
                HienThongBao("Số lượng không thay đổi.");
                return;
            }

            DataRow sp = TimSanPham(maSP);
            if (sp == null)
            {
                HienThongBao("Không tìm thấy sản phẩm trong danh sách tồn kho.", MessageBoxIcon.Warning);
                return;
            }

            int tonKhoKhaDungCoSo = Convert.ToInt32(sp["SoLuong"]) + (soLuongCu * quyDoi);
            int soLuongQuyDoiMoi = soLuongMoi * quyDoi;
            if (soLuongQuyDoiMoi > tonKhoKhaDungCoSo)
            {
                int toiDa = tonKhoKhaDungCoSo / quyDoi;
                HienThongBao("Số lượng tồn kho không đủ! Tối đa: " + toiDa, MessageBoxIcon.Warning);
                return;
            }

            DatSoLuongDong(dong, soLuongMoi);
            sp["SoLuong"] = tonKhoKhaDungCoSo - soLuongQuyDoiMoi;
            CapNhatTongTien();
        }

        private void btnXoaSPKhoiHD_Click(object sender, EventArgs e)
        {
            DataGridViewRow dong = dgvChiTietHoaDon.CurrentRow;
            if (dong == null)
            {
                HienThongBao("Vui lòng chọn sản phẩm cần xóa.", MessageBoxIcon.Warning);
                return;
            }

            if (!XacNhan("Bạn có chắc chắn muốn xóa sản phẩm đã chọn?"))
                return;

            string maSP = Convert.ToString(dong.Cells["colMaSP"].Value);
            int soLuong = Convert.ToInt32(dong.Cells["colSoLuong"].Value);
            int quyDoi = Convert.ToInt32(dong.Cells["colSoLuongQuyDoi"].Value);

            DataRow sp = TimSanPham(maSP);
            if (sp != null)
                sp["SoLuong"] = Convert.ToInt32(sp["SoLuong"]) + (soLuong * quyDoi);

            dgvChiTietHoaDon.Rows.Remove(dong);
            CapNhatTongTien();
        }

        // TÍNH TIỀN
        // =====================================================================

        private void CapNhatTongTien()
        {
            tongTienHang = 0;

            foreach (DataGridViewRow dong in dgvChiTietHoaDon.Rows)
                tongTienHang += Convert.ToDecimal(dong.Cells["colThanhTien"].Value);

            txtTongTien.Text = tongTienHang.ToString("N0");
            TinhTienThanhToan();
        }

        // Số điểm tối đa được dùng: không vượt quá (điểm hiện có + điểm mới của hóa đơn)
        // và không làm tiền giảm giá lớn hơn tổng tiền hàng
        private int DiemToiDa()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                return 0;

            int diemMoi = (int)(tongTienHang / TienTichMotDiem);
            int diemTheoTien = (int)(tongTienHang / GiaTriMotDiem);

            return Math.Min(diemHienCo + diemMoi, diemTheoTien);
        }

        // Lấy phần trăm giảm giá từ 4 RadioButton trong grpGiamGia.
        private int LayPhanTramGiam()
        {
            if (rdoGiam5.Checked) return 5;
            if (rdoGiam10.Checked) return 10;
            if (rdoGiam20.Checked) return 20;
            if (rdoGiam30.Checked) return 30;
            return 0;
        }

        // 10 điểm đổi được 1% giảm giá.
        private int LayDiemCanDung()
        {
            return LayPhanTramGiam() * 10;
        }

        private void rdoGiamGia_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked)
                return;

            int phanTram = LayPhanTramGiam();
            int diemCanDung = phanTram * 10;

            if (phanTram > 0 && string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                HienThongBao("Vui lòng chọn khách hàng trước khi sử dụng điểm.", MessageBoxIcon.Warning);
                rb.Checked = false;
                TinhTienThanhToan();
                return;
            }

            if (diemHienCo < diemCanDung)
            {
                HienThongBao(
                    $"Cần {diemCanDung} điểm để giảm {phanTram}%.\n" +
                    $"Điểm hiện có: {diemHienCo} điểm.\n" +
                    $"Còn thiếu: {diemCanDung - diemHienCo} điểm.",
                    MessageBoxIcon.Warning);
                rb.Checked = false;
                TinhTienThanhToan();
                return;
            }

            TinhTienThanhToan();
        }

        private void TinhTienThanhToan()
        {
            int phanTram = LayPhanTramGiam();
            int diemCanDung = phanTram * 10;
            bool hopLe = phanTram == 0 ||
                (!string.IsNullOrWhiteSpace(txtMaKH.Text) && diemHienCo >= diemCanDung);

            decimal giamGia = (hopLe && phanTram > 0)
                ? tongTienHang * phanTram / 100m
                : 0m;

            txtTienGiamGia.Text = giamGia.ToString("N0");
            txtTienPhaiTra.Text = (tongTienHang - giamGia).ToString("N0");
        }

        // =====================================================================
        // HÓA ĐƠN
        // =====================================================================

        private void TaoMaHoaDonMoi()
        {
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        // Đưa form về trạng thái hóa đơn trống, tải lại tồn kho từ database
        private void BatDauHoaDonMoi()
        {
            dgvChiTietHoaDon.Rows.Clear();
            XoaThongTinKhachHang();
            // Bỏ lựa chọn giảm giá khi bắt đầu hóa đơn mới.
            rdoGiam5.Checked = false;
            rdoGiam10.Checked = false;
            rdoGiam20.Checked = false;
            rdoGiam30.Checked = false;
            txtTimKiemSP.Clear();
            cboDonViTinh.DataSource = null;
            dtDonViTinh = null;
            cboDonViTinh.Tag = null;
            lblQuyDoi.Text = "Chọn sản phẩm để xem quy đổi đơn vị";

            TaiDanhSachSanPham();
            TaoMaHoaDonMoi();
            CapNhatTongTien();
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.Rows.Count > 0 &&
                !XacNhan("Hóa đơn hiện tại chưa lưu sẽ bị hủy. Bạn có muốn bắt đầu hóa đơn mới?"))
                return;

            BatDauHoaDonMoi();
        }


        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            // Mở form xem lịch sử hóa đơn
            using (var form = new SupermarketManagement.Views.Admin.LichSuBan.IndexLichSuBan())
            {
                form.ShowDialog(this);
            }
        }


        // Chuyển bảng chi tiết hóa đơn thành DataTable để repository lưu
        private DataTable LayChiTietHoaDon()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP", typeof(string));
            dt.Columns.Add("MaDVT", typeof(string));
            dt.Columns.Add("SoLuongBan", typeof(int));
            dt.Columns.Add("DonGiaBan", typeof(decimal));
            dt.Columns.Add("SoLuongQuyDoi", typeof(int));

            foreach (DataGridViewRow dong in dgvChiTietHoaDon.Rows)
            {
                if (dong.IsNewRow)
                    continue;

                dt.Rows.Add(
                    Convert.ToString(dong.Cells["colMaSP"].Value),
                    Convert.ToString(dong.Cells["colMaDVT"].Value),
                    Convert.ToInt32(dong.Cells["colSoLuong"].Value),
                    Convert.ToDecimal(dong.Cells["colDonGia"].Value),
                    Convert.ToInt32(dong.Cells["colSoLuongQuyDoi"].Value));
            }

            return dt;
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.Rows.Count == 0)
            {
                HienThongBao("Hóa đơn chưa có sản phẩm.", MessageBoxIcon.Warning);
                return;
            }

            string tenKH = string.IsNullOrWhiteSpace(txtTenKH.Text)
                ? "Khách lẻ"
                : txtTenKH.Text.Trim();

            // Lấy thông tin hóa đơn hiện tại
            string maHD = txtMaHD.Text.Trim();
            string maKH = string.IsNullOrWhiteSpace(txtMaKH.Text)
                ? null
                : txtMaKH.Text.Trim();
            string maNV = Convert.ToString(UserSession.MaNV);
            string tenNV = Convert.ToString(UserSession.HoTen);
            int diemSuDung = LayDiemCanDung();

            // Lưu thông tin để hiển thị hóa đơn trước khi làm mới
            DateTime ngayMua = DateTime.Now;

            try
            {
                // 1. Lưu hóa đơn vào database
                hoaDonRepository.LuuHoaDon(
                    maHD,
                    tongTienHang,
                    ngayMua,
                    maKH,
                    maNV,
                    LayChiTietHoaDon(),
                    diemSuDung);

                // 2. Chỉ mở hóa đơn khi lưu thành công
                using (var form = new SupermarketManagement.Views.Cashier.InvoiceForm())
                {
                    form.HienThiHoaDon(
                        maHD,
                        txtMaKH.Text,
                        tenKH,
                        tenNV,
                        ngayMua,
                        dgvChiTietHoaDon,
                        txtTongTien.Text,
                        txtTienGiamGia.Text,
                        diemSuDung.ToString(),
                        txtTienPhaiTra.Text);

                    form.ShowDialog(this);
                }

                // 3. Làm mới sau khi đã lưu thành công
                dgvChiTietHoaDon.Rows.Clear();

                tongTienHang = 0;

                txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                txtTongTien.Text = "0";
                txtTienGiamGia.Text = "0";
                txtTienPhaiTra.Text = "0";

                // Xóa thông tin khách hàng để chuẩn bị hóa đơn mới
                txtMaKH.Clear();
                txtTenKH.Clear();
                txtSDT.Clear();
                txtEmail.Clear();
                txtDiemTichLuy.Clear();

                // Đưa mức giảm giá về 0%
                foreach (Control control in this.Controls)
                {
                    if (control is GroupBox group)
                    {
                        foreach (Control child in group.Controls)
                        {
                            if (child is RadioButton radio)
                            {
                                if (radio.Text.Contains("0%"))
                                {
                                    radio.Checked = true;
                                }
                            }
                        }
                    }
                }

                HienThongBao(
                    "Xuất hóa đơn thành công! Đã tạo hóa đơn mới.",
                    MessageBoxIcon.Information);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                HienThongBao(
                    "Hóa đơn này đã được lưu trước đó, không thể xuất trùng mã hóa đơn. " +
                    "Vui lòng kiểm tra lịch sử hóa đơn.",
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                HienThongBao(
                    "Không thể xuất hóa đơn. Dữ liệu trên màn hình được giữ lại.\nChi tiết: "
                    + ex.Message,
                    MessageBoxIcon.Error);
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

        // =====================================================================
        // KHÁCH HÀNG
        // =====================================================================

        private void XoaThongTinKhachHang(bool giuSoDienThoai = false)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtEmail.Clear();
            txtDiemTichLuy.Clear();
            if (!giuSoDienThoai)
                txtSDT.Clear();

            diemHienCo = 0;
            TinhTienThanhToan();
        }

        private static bool LaEmailHopLe(string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool KiemTraThongTinKhachHang(string maKH, string tenKH, string sdt, string email)
        {
            if (maKH.Length == 0 || tenKH.Length == 0)
            {
                HienThongBao("Vui lòng tạo mã khách hàng và nhập họ tên.", MessageBoxIcon.Warning);
                return false;
            }

            if (sdt.Length == 0)
            {
                HienThongBao("Vui lòng nhập số điện thoại để tích điểm.", MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (!Regex.IsMatch(sdt, @"^0[0-9]{9}$") || sdt.Distinct().Count() == 1)
            {
                HienThongBao("Số điện thoại phải bắt đầu bằng 0, đủ 10 chữ số và không được gồm 10 số giống hệt nhau.",
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // Email không bắt buộc, chỉ kiểm tra định dạng nếu có nhập
            if (email.Length > 0 && !LaEmailHopLe(email))
            {
                HienThongBao("Email không đúng định dạng. Ví dụ: abc@gmail.com", MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void btnTaoMaKH_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaKH.Text = khachHangRepository.RenderMaKhachHang();
            }
            catch (Exception ex)
            {
                HienThongBao(
                    "Không tạo được mã khách hàng:\n" + ex.Message,
                    MessageBoxIcon.Error);
            }
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
                if (khachHangRepository.CheckExists(maKH))
                {
                    HienThongBao("Mã khách hàng đã tồn tại.",
                        MessageBoxIcon.Warning);
                    return;
                }

                if (khachHangRepository.CheckPhoneExists(sdt))
                {
                    HienThongBao(
                        "Số điện thoại này đã được đăng ký. Vui lòng tìm khách hàng cũ để tích điểm.",
                        MessageBoxIcon.Warning);
                    return;
                }

                if (email.Length > 0 &&
                    khachHangRepository.CheckEmailExists(email))
                {
                    HienThongBao("Email đã được đăng ký.",
                        MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                khachHangRepository.InsertFromPOS(
                    maKH, tenKH, sdt, email);

                diemHienCo = 0;
                txtDiemTichLuy.Text = "0";
                TinhTienThanhToan();

                HienThongBao("Thêm khách hàng thành công.");
            }
            catch (Exception ex)
            {
                HienThongBao(
                    "Lỗi khi thêm khách hàng:\n" + ex.Message,
                    MessageBoxIcon.Error);
            }
        }
        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();

            if (sdt.Length == 0)
            {
                HienThongBao("Vui lòng nhập số điện thoại.",
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            try
            {
                DataTable dt = khachHangRepository.GetByPhone(sdt);

                if (dt.Rows.Count == 0)
                {
                    XoaThongTinKhachHang(giuSoDienThoai: true);
                    HienThongBao(
                        "Không tìm thấy khách hàng. Bạn có thể nhập thông tin để thêm mới.");
                    return;
                }

                if (dt.Rows.Count > 1)
                {
                    HienThongBao(
                        "Số điện thoại bị trùng trong database. Vui lòng kiểm tra dữ liệu.",
                        MessageBoxIcon.Warning);
                    return;
                }

                DataRow dong = dt.Rows[0];

                txtMaKH.Text = Convert.ToString(dong["MaKH"]);
                txtTenKH.Text = Convert.ToString(dong["HoTen"]);
                txtEmail.Text = dong["Email"] == DBNull.Value
                    ? ""
                    : Convert.ToString(dong["Email"]);

                diemHienCo = dong["DiemTichLuy"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(dong["DiemTichLuy"]);

                txtDiemTichLuy.Text = diemHienCo.ToString();

                TinhTienThanhToan();
            }
            catch (Exception ex)
            {
                HienThongBao(
                    "Lỗi tìm kiếm khách hàng:\n" + ex.Message,
                    MessageBoxIcon.Error);
            }
        }



        private void rdoGiam5_CheckedChanged(object sender, EventArgs e)
        {
            rdoGiamGia_CheckedChanged(sender, e);
        }

        private void rdoGiam10_CheckedChanged(object sender, EventArgs e)
        {
            rdoGiamGia_CheckedChanged(sender, e);
        }

        private void rdoGiam20_CheckedChanged(object sender, EventArgs e)
        {
            rdoGiamGia_CheckedChanged(sender, e);
        }

        private void rdoGiam30_CheckedChanged(object sender, EventArgs e)
        {
            rdoGiamGia_CheckedChanged(sender, e);
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiemKH.PerformClick();
            }
        }

        private void nudSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSuaSP.PerformClick();
            }
        }

        private void dgvDSSP_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDSSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSSP.CurrentRow == null ||
                dgvDSSP.CurrentRow.DataBoundItem == null)
                return;

            DataRowView dong =
                dgvDSSP.CurrentRow.DataBoundItem as DataRowView;

            if (dong == null)
                return;

            string maSP = Convert.ToString(dong["MaSP"]);

            if (Convert.ToString(cboDonViTinh.Tag) != maSP)
            {
                cboDonViTinh.Tag = maSP;
                TaiDonViTinh(maSP);
            }
        }

        private void cboDonViTinh_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnTraHang_Click(object sender, EventArgs e)
        {
            using (TraHangForm form = new TraHangForm())
            {
                form.ShowDialog(this);
            }
        }
    }
}