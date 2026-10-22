using SupermarketManagement.Controllers;
using SupermarketManagement.Models.Entities;
using SupermarketManagement.Models.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.QuanLyKhoHang
{
    public partial class IndexQuanLyKhoHang : Form
    {
        private decimal giaNhapHienTai = 0;
        private string maSanPhamHienTai = "";
        private KhoHangController _controller = new KhoHangController();

        public IndexQuanLyKhoHang()
        {
            InitializeComponent();
        }

        private void IndexQuanLyKhoHang_Load(object sender, EventArgs e)
        {

            grpDanhMuc.Visible = false;
            //đki sự kiện lọc danh mục
            cboDanhMucHH.SelectedIndexChanged += cboDanhMucHH_SelectedIndexChanged;

            LoadComboBoxData();
            LoadDanhSachDanhMuc();
            LoadDanhSachHangHoa();
            LoadDanhSachHoaDonNhap();
            LamMoiFormHoaDon();
            LamMoiFormHangHoa();

            LoadComboBoxMatHang();
        }

        private void LoadComboBoxData()
        {
            try
            {
                DataTable dtNCC = _controller.LoadNhaCungCap();
                cboNhaCungCap.DataSource = dtNCC;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";

                DataTable dtNV = _controller.LoadNhanVien();
                cboNguoiNhap.DataSource = dtNV;
                cboNguoiNhap.DisplayMember = "HoTen";
                cboNguoiNhap.ValueMember = "MaNV";

                if (PhienDangNhap.MaNV > 0)
                {
                    cboNguoiNhap.SelectedValue = PhienDangNhap.MaNV;
                }

                CapNhatComboBoxDanhMuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu danh mục chọn: " + ex.Message);
            }
        }


        private void CapNhatComboBoxDanhMuc()
        {
            DataTable dtDM = _controller.LoadDanhMuc();

            DataRow row = dtDM.NewRow();
            row["MaDM"] = 0;
            row["TenDanhMuc"] = "Tất cả";
            dtDM.Rows.InsertAt(row, 0);

            // Tạm thời tắt sự kiện để tránh kích hoạt nhầm
            cboDanhMucHH.SelectedIndexChanged -= cboDanhMucHH_SelectedIndexChanged;

            // QUAN TRỌNG: Phải gán DisplayMember và ValueMember TRƯỚC khi gán DataSource
            cboDanhMucHH.DisplayMember = "TenDanhMuc";
            cboDanhMucHH.ValueMember = "MaDM";
            cboDanhMucHH.DataSource = dtDM;

            // Bật lại sự kiện
            cboDanhMucHH.SelectedIndexChanged += cboDanhMucHH_SelectedIndexChanged;
        }

        //khu xử lý phiếu nhập hàng

        private void LoadDanhSachHoaDonNhap()
        {
            try
            {
                dgvHoaDonNhap.DataSource = _controller.LoadPhieuNhapHang();
                if (dgvHoaDonNhap.Columns.Count > 0)
                {
                    // 1. Cấu hình các cột cơ bản và ép kích thước nhỏ lại (Width)
                    dgvHoaDonNhap.Columns["MaPNH"].HeaderText = "Mã Phiếu";
                    dgvHoaDonNhap.Columns["MaPNH"].Width = 60;

                    dgvHoaDonNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                    dgvHoaDonNhap.Columns["NgayNhap"].Width = 100;

                    // 2. Cho cột Mặt Hàng tự động co giãn lấp đầy khoảng trống (Fill)
                    dgvHoaDonNhap.Columns["MatHang"].HeaderText = "Mặt Hàng";
                    dgvHoaDonNhap.Columns["MatHang"].Width = 100;

                    // 3. Cấu hình 2 cột mới (kiểm tra Contains để tránh lỗi nếu SQL chưa có cột này)
                    if (dgvHoaDonNhap.Columns.Contains("SoLuongNhap"))
                    {
                        dgvHoaDonNhap.Columns["SoLuongNhap"].HeaderText = "Số Lượng";
                        dgvHoaDonNhap.Columns["SoLuongNhap"].Width = 50;
                    }

                    if (dgvHoaDonNhap.Columns.Contains("DonGiaNhap"))
                    {
                        dgvHoaDonNhap.Columns["DonGiaNhap"].HeaderText = "Đơn Giá Nhập";
                        dgvHoaDonNhap.Columns["DonGiaNhap"].Width = 80;
                        dgvHoaDonNhap.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
                    }

                    dgvHoaDonNhap.Columns["NguoiNhap"].HeaderText = "Người Nhập";
                    dgvHoaDonNhap.Columns["NguoiNhap"].Width = 100;

                    // 4. Thu nhỏ cột Tổng tiền
                    if (dgvHoaDonNhap.Columns.Contains("TongTien"))
                    {
                        dgvHoaDonNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
                        dgvHoaDonNhap.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                        dgvHoaDonNhap.Columns["TongTien"].Width = 80;
                    }

                    // 5. Ẩn các cột không cần thiết
                    dgvHoaDonNhap.Columns["MaNCC"].Visible = false;
                    dgvHoaDonNhap.Columns["MaNV"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn nhập: " + ex.Message);
            }
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDonNhap.Rows[e.RowIndex];
                txtMaHoaDon.Text = row.Cells["MaPNH"].Value?.ToString();

                if (row.Cells["NgayNhap"].Value != null && row.Cells["NgayNhap"].Value != DBNull.Value)
                {
                    dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                }

                if (row.Cells["MaNCC"].Value != null && row.Cells["MaNCC"].Value != DBNull.Value)
                {
                    cboNhaCungCap.SelectedValue = row.Cells["MaNCC"].Value;
                }

                if (row.Cells["MaNV"].Value != null && row.Cells["MaNV"].Value != DBNull.Value)
                {
                    cboNguoiNhap.SelectedValue = row.Cells["MaNV"].Value;
                }

                txtTongTienHD.Text = row.Cells["TongTien"].Value?.ToString();
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {

            string maPNH = txtMaHoaDon.Text.Trim();
            DateTime ngayNhap = dtpNgayNhap.Value;
            int maNCC = cboNhaCungCap.SelectedValue != null ? Convert.ToInt32(cboNhaCungCap.SelectedValue) : 1;
            int maNV = PhienDangNhap.MaNV > 0 ? PhienDangNhap.MaNV : 1;

            string maSP = cboMatHang.SelectedValue != null ? cboMatHang.SelectedValue.ToString() : "";
            string soLuong = txtSoLuongNhap.Text;
            string tongTien = txtTongTienHD.Text;

            string thongBao;

            if (_controller.ThemHoaDonMoi(maPNH, ngayNhap, maNCC, maNV, maSP, soLuong, tongTien, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                LoadDanhSachHoaDonNhap();

                LoadDanhSachHangHoa();

                LamMoiFormHoaDon();
                txtSoLuongNhap.Clear();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            int maNV = cboNguoiNhap.SelectedValue != null ? Convert.ToInt32(cboNguoiNhap.SelectedValue) : 1;
            int maNCC = cboNhaCungCap.SelectedValue != null ? Convert.ToInt32(cboNhaCungCap.SelectedValue) : 1;

            string thongBao;
            if (_controller.SuaPhieuNhap(txtMaHoaDon.Text, dtpNgayNhap.Value, maNV, maNCC, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHoaDonNhap();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn nhập để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn nhập " + txtMaHoaDon.Text + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string thongBao;
                if (_controller.XoaPhieuNhap(txtMaHoaDon.Text, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDonNhap();
                    LamMoiFormHoaDon();
                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maSanPhamHienTai))
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng từ danh sách!");
                return;
            }

            int soLuong = int.Parse(txtSoLuongNhap.Text);

            // Khởi tạo Repository và thực thi cộng dồn số lượng
            SanPhamRepositoryV2 repo = new SanPhamRepositoryV2();
            bool thanhCong = repo.CapNhatSoLuongKhiNhapHang(maSanPhamHienTai, soLuong);

            if (thanhCong)
            {
                MessageBox.Show("Cập nhật số lượng nhập hàng thành công!");
                // Gọi lại hàm Load danh sách hàng hóa tại đây để DataGridView tự làm mới số lượng
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            LamMoiFormHoaDon();
        }

        private void btnLamMoiHD_Click(object sender, EventArgs e)
        {
            LamMoiFormHoaDon();
            LoadDanhSachHoaDonNhap();
        }

        private void LamMoiFormHoaDon()
        {
            txtMaHoaDon.Text = _controller.TaoMaPhieuNhapMoi();
            txtTongTienHD.Text = "0";
            dtpNgayNhap.Value = DateTime.Now;
        }
        // khu xử lý kho hàng hóa

        private void LoadDanhSachHangHoa()
        {
            try
            {
                dgvHangHoa.DataSource = _controller.LoadSanPham();
                if (dgvHangHoa.Columns.Count > 0)
                {
                    dgvHangHoa.Columns["MaSP"].HeaderText = "Mã SP";
                    dgvHangHoa.Columns["MaSP"].Width = 60;
                    dgvHangHoa.Columns["TenSanPham"].HeaderText = "Tên Hàng Hóa";
                    dgvHangHoa.Columns["TenDanhMuc"].HeaderText = "Danh Mục";
                    dgvHangHoa.Columns["SoLuong"].HeaderText = "Số Lượng";

                    dgvHangHoa.Columns["DonGiaNhap"].HeaderText = "Giá Nhập";
                    dgvHangHoa.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
                    dgvHangHoa.Columns["DonGiaBan"].HeaderText = "Giá Bán";
                    dgvHangHoa.Columns["DonGiaBan"].DefaultCellStyle.Format = "N0";

                    dgvHangHoa.Columns["MaDM"].Visible = false;
                    dgvHangHoa.Columns["TrongLuong"].Visible = false;
                    dgvHangHoa.Columns["MoTa"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hàng hóa: " + ex.Message);
            }
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo không click vào tiêu đề cột
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];

                maSanPhamHienTai = row.Cells[0].Value.ToString();
                cboMatHang.Text = row.Cells[1].Value.ToString();
                giaNhapHienTai = Convert.ToDecimal(row.Cells[3].Value);
                txtSoLuongNhap.Text = "0";


            }
        }

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            int maDM = cboDanhMucHH.SelectedValue != null ? Convert.ToInt32(cboDanhMucHH.SelectedValue) : 0;
            if (maDM == 0)
            {
                MessageBox.Show("Vui lòng chọn một Danh mục cụ thể (không chọn 'Tất cả') trước khi Thêm!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = PhienDangNhap.MaNV > 0 ? PhienDangNhap.MaNV : 1;

            string thongBao;
            if (_controller.ThemSanPham(txtMaHangHoa.Text, txtTenHangHoa.Text, txtSoLuong.Text, txtTrongLuong.Text, txtDonGiaNhap.Text, txtDonGiaBan.Text, txtMoTaHH.Text, maDM, maNV, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHangHoa();
                LamMoiFormHangHoa();
                LoadDanhSachHoaDonNhap();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaHH_Click(object sender, EventArgs e)
        {
            int maDM = cboDanhMucHH.SelectedValue != null ? Convert.ToInt32(cboDanhMucHH.SelectedValue) : 1;

            string thongBao;
            if (_controller.SuaSanPham(txtMaHangHoa.Text, txtTenHangHoa.Text, txtSoLuong.Text, txtTrongLuong.Text, txtDonGiaNhap.Text, txtDonGiaBan.Text, txtMoTaHH.Text, maDM, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHangHoa();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaHH_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.CurrentRow == null || dgvHangHoa.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng hóa từ bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string thongBao;

                string maSPDuocChon = dgvHangHoa.CurrentRow.Cells["MaSP"].Value.ToString();

                if (_controller.XoaSanPham(maSPDuocChon, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHangHoa();
                    LamMoiFormHangHoa();
                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiemHH_TextChanged(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = _controller.TimKiemSanPham(txtTimKiemHH.Text);
        }

        private void LamMoiFormHangHoa()
        {
            txtMaHangHoa.Text = _controller.TaoMaSanPhamMoi();
            txtTenHangHoa.Clear();
            txtSoLuong.Clear();
            txtTrongLuong.Clear();
            txtDonGiaNhap.Clear();
            txtDonGiaBan.Clear();
            txtMoTaHH.Clear();
        }

        // khu vực xử lý quản lý danh mục

        private void LoadDanhSachDanhMuc()
        {
            try
            {
                dgvDanhMuc.DataSource = _controller.LoadDanhMuc();

                if (dgvDanhMuc.Columns.Count > 0)
                {
                    dgvDanhMuc.Columns["MaDM"].HeaderText = "Mã DM";
                    dgvDanhMuc.Columns["MaDM"].Width = 60;
                    dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên Danh Mục";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
                txtMaDanhMuc.Text = row.Cells["MaDM"].Value?.ToString();
                txtTenDanhMuc.Text = row.Cells["TenDanhMuc"].Value?.ToString();
            }
        }

        

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            string thongBao;
            if (_controller.SuaDanhMuc(txtMaDanhMuc.Text, txtTenDanhMuc.Text, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDanhMuc();
                CapNhatComboBoxDanhMuc();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn một danh mục để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string thongBao;
                if (_controller.XoaDanhMuc(txtMaDanhMuc.Text, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDanhMuc();
                    CapNhatComboBoxDanhMuc();
                    LamMoiFormDanhMuc();
                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LamMoiFormDanhMuc()
        {
            txtMaDanhMuc.Text = _controller.TaoMaDanhMucMoi();
            txtTenDanhMuc.Clear();
            txtMoTaDM.Clear();
        }

        private void grpDanhMuc_Enter(object sender, EventArgs e)
        {

        }

        private void cboDanhMucHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSP = dgvHangHoa.DataSource as DataTable;
                if (dtSP == null) return;

                if (cboDanhMucHH.SelectedValue != null)
                {
                    string giaTri = cboDanhMucHH.SelectedValue.ToString();
                    if (cboDanhMucHH.SelectedValue is DataRowView rowView)
                    {
                        giaTri = rowView["MaDM"].ToString();
                    }

                    if (int.TryParse(giaTri, out int maDM))
                    {
                        if (maDM == 0)
                        {
                            dtSP.DefaultView.RowFilter = "";
                        }
                        else
                        {
                            dtSP.DefaultView.RowFilter = $"MaDM = {maDM}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMoQLDM_Click(object sender, EventArgs e)
        {
            Form frmDM = new Form();
            frmDM.Text = "Quản Lý Danh Mục";
            frmDM.Size = new System.Drawing.Size(350, 500);
            frmDM.StartPosition = FormStartPosition.CenterParent;
            frmDM.MaximizeBox = false;
            frmDM.MinimizeBox = false;

            grpDanhMuc.Location = new System.Drawing.Point(5, 5);
            grpDanhMuc.Visible = true;
            frmDM.Controls.Add(grpDanhMuc);

            frmDM.FormClosing += (s, ev) =>
            {
                this.Controls.Add(grpDanhMuc);
                grpDanhMuc.Visible = false;
            };
            LamMoiFormDanhMuc();
            frmDM.ShowDialog();
        }

        private void LoadComboBoxMatHang()
        {
            try
            {
                DataTable dtSP = _controller.LoadSanPham();
                cboMatHang.SelectedIndexChanged -= cboMatHang_SelectedIndexChanged;

                cboMatHang.DataSource = dtSP;
                cboMatHang.DisplayMember = "TenSanPham";
                cboMatHang.ValueMember = "MaSP";

                cboMatHang.SelectedIndexChanged += cboMatHang_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách mặt hàng: " + ex.Message);
            }
        }

        private void TinhTongTienPhieuNhap()
        {
            if (int.TryParse(txtSoLuongNhap.Text, out int soLuong) && soLuong > 0)
            {
                DataRowView rowView = cboMatHang.SelectedItem as DataRowView;
                if (rowView != null)
                {
                    if (decimal.TryParse(rowView["DonGiaNhap"].ToString(), out decimal donGiaNhap))
                    {
                        decimal tongTien = soLuong * donGiaNhap;
                        txtTongTienHD.Text = tongTien.ToString("N0");
                        return;
                    }
                }
            }
            txtTongTienHD.Text = "0";
        }

        private void cboMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTienPhieuNhap();
        }

        private void txtSoLuongNhap_TextChanged(object sender, EventArgs e)
        {
            TinhTongTienPhieuNhap();
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            string thongBao;
            // Thêm .Trim() để dọn dẹp khoảng trắng thừa
            string maDM = txtMaDanhMuc.Text.Trim();
            string tenDM = txtTenDanhMuc.Text.Trim();

            if (_controller.ThemDanhMuc(maDM, tenDM, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDanhMuc();
                CapNhatComboBoxDanhMuc();
                LamMoiFormDanhMuc();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}