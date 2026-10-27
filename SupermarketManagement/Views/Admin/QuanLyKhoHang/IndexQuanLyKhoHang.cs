using SupermarketManagement.Controllers;
using SupermarketManagement.Models.Entities;
using SupermarketManagement.Utils;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.QuanLyKhoHang
{
    public partial class IndexQuanLyKhoHang : Form
    {
        private KhoHangController _controller = new KhoHangController();
        private DataTable _dtChiTietNhap = new DataTable();

        public IndexQuanLyKhoHang()
        {
            InitializeComponent();
        }

        private void IndexQuanLyKhoHang_Load(object sender, EventArgs e)
        {
            grpDanhMuc.Visible = false;

            KhoiTaoBangChiTietNhap();
            LoadComboBoxData();
            LoadComboBoxMatHang();
            LoadDanhSachHangHoa();
            LoadDanhSachHoaDonNhap();
            LoadDanhSachDanhMuc();

            LamMoiPhieuNhap();
            LamMoiFormHangHoa();
        }

        #region Khởi tạo cấu trúc bảng Chi Tiết Nhập (Giỏ hàng nhập)

        private void KhoiTaoBangChiTietNhap()
        {
            _dtChiTietNhap = new DataTable();
            _dtChiTietNhap.Columns.Add("STT", typeof(int));
            _dtChiTietNhap.Columns.Add("MaSP", typeof(string));
            _dtChiTietNhap.Columns.Add("TenSP", typeof(string));
            _dtChiTietNhap.Columns.Add("MaDVT", typeof(string));
            _dtChiTietNhap.Columns.Add("TenDV", typeof(string));
            _dtChiTietNhap.Columns.Add("SoLuongNhap", typeof(int));
            _dtChiTietNhap.Columns.Add("SoLuongQuyDoi", typeof(int));
            _dtChiTietNhap.Columns.Add("SoLuongQuyDoiKho", typeof(int));
            _dtChiTietNhap.Columns.Add("DonGiaNhap", typeof(decimal));
            _dtChiTietNhap.Columns.Add("ThanhTien", typeof(decimal));
            _dtChiTietNhap.Columns.Add("NgaySanXuat", typeof(object));
            _dtChiTietNhap.Columns.Add("NgayHetHan", typeof(object));

            dgvChiTietNhap.AutoGenerateColumns = false;

            colSTT.DataPropertyName = "STT";
            colMaSP.DataPropertyName = "MaSP";
            colTenSP.DataPropertyName = "TenSP";
            colMaDVT.DataPropertyName = "MaDVT";
            colTenDV.DataPropertyName = "TenDV";
            colSoLuongNhap.DataPropertyName = "SoLuongNhap";
            colSoLuongQuyDoi.DataPropertyName = "SoLuongQuyDoi";
            colSoLuongQuyDoiKho.DataPropertyName = "SoLuongQuyDoiKho";
            colDonGiaNhap.DataPropertyName = "DonGiaNhap";
            colThanhTien.DataPropertyName = "ThanhTien";
            colNSX.DataPropertyName = "NgaySanXuat";
            colHSD.DataPropertyName = "NgayHetHan";

            colDonGiaNhap.DefaultCellStyle.Format = "N0";
            colThanhTien.DefaultCellStyle.Format = "N0";
            colNSX.DefaultCellStyle.Format = "dd/MM/yyyy";
            colHSD.DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvChiTietNhap.DataSource = _dtChiTietNhap;
        }

        #endregion

        #region Load ComboBox Data

        private void LoadComboBoxData()
        {
            try
            {
                // 1. Nhà Cung Cấp
                DataTable dtNCC = _controller.LoadNhaCungCap();
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";
                cboNhaCungCap.DataSource = dtNCC;

                // Lọc NCC ở tab lịch sử
                DataTable dtLocNCC = dtNCC.Copy();
                DataRow rAll = dtLocNCC.NewRow();
                rAll["MaNCC"] = "";
                rAll["TenNCC"] = "-- Tất Cả Nhà Cung Cấp --";
                dtLocNCC.Rows.InsertAt(rAll, 0);

                cboLocNCC.SelectedIndexChanged -= cboLocNCC_SelectedIndexChanged;
                cboLocNCC.DisplayMember = "TenNCC";
                cboLocNCC.ValueMember = "MaNCC";
                cboLocNCC.DataSource = dtLocNCC;
                cboLocNCC.SelectedIndexChanged += cboLocNCC_SelectedIndexChanged;

                // 2. Nhân Viên Nhập Kho
                DataTable dtNV = _controller.LoadNhanVien();
                cboNguoiNhap.DisplayMember = "HoTen";
                cboNguoiNhap.ValueMember = "MaNV";
                cboNguoiNhap.DataSource = dtNV;

                int maNVCurrent = UserSession.MaNV > 0 ? UserSession.MaNV : PhienDangNhap.MaNV;
                if (maNVCurrent > 0)
                {
                    cboNguoiNhap.SelectedValue = maNVCurrent.ToString();
                }

                // 3. Danh mục
                CapNhatComboBoxDanhMuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục chọn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxMatHang()
        {
            try
            {
                DataTable dtSP = _controller.LoadSanPham();

                // Tạo cột hiển thị kết hợp [Mã SP] - [Tên SP]
                if (!dtSP.Columns.Contains("DisplaySP"))
                {
                    dtSP.Columns.Add("DisplaySP", typeof(string));
                    foreach (DataRow r in dtSP.Rows)
                    {
                        r["DisplaySP"] = $"{r["MaSP"]} - {r["TenSanPham"]}";
                    }
                }

                cboMatHang.SelectedIndexChanged -= cboMatHang_SelectedIndexChanged;
                cboMatHang.DisplayMember = "DisplaySP";
                cboMatHang.ValueMember = "MaSP";
                cboMatHang.DataSource = dtSP;
                cboMatHang.SelectedIndexChanged += cboMatHang_SelectedIndexChanged;

                if (cboMatHang.Items.Count > 0)
                {
                    cboMatHang.SelectedIndex = 0;
                    cboMatHang_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách mặt hàng: " + ex.Message);
            }
        }

        private void CapNhatComboBoxDanhMuc()
        {
            DataTable dtDM = _controller.LoadDanhMuc();

            DataRow row = dtDM.NewRow();
            row["MaDM"] = 0;
            row["TenDanhMuc"] = "Tất cả danh mục";
            dtDM.Rows.InsertAt(row, 0);

            cboDanhMucHH.SelectedIndexChanged -= cboDanhMucHH_SelectedIndexChanged;
            cboDanhMucHH.DisplayMember = "TenDanhMuc";
            cboDanhMucHH.ValueMember = "MaDM";
            cboDanhMucHH.DataSource = dtDM;
            cboDanhMucHH.SelectedIndexChanged += cboDanhMucHH_SelectedIndexChanged;
        }

        #endregion

        #region TAB 1: SỰ KIỆN LẬP PHIẾU NHẬP HÀNG & QUY ĐỔI ĐƠN VỊ

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            using (FrmThemNhaCungCap frm = new FrmThemNhaCungCap())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string maMoi = frm.MaNCCMoi;
                    LoadComboBoxData();
                    if (!string.IsNullOrEmpty(maMoi))
                    {
                        cboNhaCungCap.SelectedValue = maMoi;
                    }
                }
            }
        }

        private void cboMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMatHang.SelectedValue == null) return;
            string maSP = cboMatHang.SelectedValue.ToString();
            if (cboMatHang.SelectedValue is DataRowView rowView)
            {
                maSP = rowView["MaSP"].ToString();
            }

            LoadDonViTinhCuaSanPham(maSP);
        }

        private void LoadDonViTinhCuaSanPham(string maSP)
        {
            try
            {
                DataTable dtDVT = _controller.LoadDonViTinhTheoSanPham(maSP);
                if (dtDVT == null || dtDVT.Rows.Count == 0)
                {
                    dtDVT = _controller.LoadAllDonViTinh();
                    if (!dtDVT.Columns.Contains("SoLuongQuyDoi"))
                        dtDVT.Columns.Add("SoLuongQuyDoi", typeof(int), "1");
                    if (!dtDVT.Columns.Contains("DonGiaNhapLe"))
                        dtDVT.Columns.Add("DonGiaNhapLe", typeof(decimal), "0");
                }

                cboDonViTinh.SelectedIndexChanged -= cboDonViTinh_SelectedIndexChanged;
                cboDonViTinh.DisplayMember = "TenDV";
                cboDonViTinh.ValueMember = "MaDVT";
                cboDonViTinh.DataSource = dtDVT;
                cboDonViTinh.SelectedIndexChanged += cboDonViTinh_SelectedIndexChanged;

                if (cboDonViTinh.Items.Count > 0)
                {
                    cboDonViTinh.SelectedIndex = 0;
                    cboDonViTinh_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đơn vị tính: " + ex.Message);
            }
        }

        private void cboDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDonViTinh.SelectedItem is DataRowView drv)
            {
                if (drv.DataView.Table.Columns.Contains("SoLuongQuyDoi"))
                {
                    int quyDoi = Convert.ToInt32(drv["SoLuongQuyDoi"]);
                    nudSoLuongQuyDoi.Value = quyDoi > 0 ? quyDoi : 1;
                }
                else
                {
                    nudSoLuongQuyDoi.Value = 1;
                }

                if (drv.DataView.Table.Columns.Contains("DonGiaNhapLe"))
                {
                    decimal gia = Convert.ToDecimal(drv["DonGiaNhapLe"]);
                    txtDonGiaNhapItem.Text = gia.ToString("N0");
                }
            }

            CapNhatQuyDoiVaThanhTienItem();
        }

        private void nudSoLuongNhap_ValueChanged(object sender, EventArgs e)
        {
            CapNhatQuyDoiVaThanhTienItem();
        }

        private void nudSoLuongQuyDoi_ValueChanged(object sender, EventArgs e)
        {
            CapNhatQuyDoiVaThanhTienItem();
        }

        private void txtDonGiaNhapItem_TextChanged(object sender, EventArgs e)
        {
            CapNhatQuyDoiVaThanhTienItem();
        }

        private void CapNhatQuyDoiVaThanhTienItem()
        {
            int slNhap = (int)nudSoLuongNhap.Value;
            int quyDoi = (int)nudSoLuongQuyDoi.Value;
            if (quyDoi <= 0) quyDoi = 1;

            int slKho = slNhap * quyDoi;
            string tenDV = cboDonViTinh.Text;

            // Hiển thị công thức quy đổi trực quan theo yêu cầu bài toán
            lblQuyDoiPreview.Text = $"👉 Quy đổi: {slNhap} {tenDV} x {quyDoi} = {slKho:N0} (sẽ cộng vào tổng kho)";

            // Tính thành tiền của món
            string rawGia = txtDonGiaNhapItem.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(rawGia, out decimal donGia))
            {
                decimal thanhTien = slNhap * donGia;
                txtThanhTienItem.Text = thanhTien.ToString("N0") + " đ";
            }
            else
            {
                txtThanhTienItem.Text = "0 đ";
            }
        }

        private void chkCoHSD_CheckedChanged(object sender, EventArgs e)
        {
            dtpNSX.Enabled = chkCoHSD.Checked;
            dtpHSD.Enabled = chkCoHSD.Checked;
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (cboMatHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDonViTinh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int slNhap = (int)nudSoLuongNhap.Value;
            if (slNhap <= 0)
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn 0!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int slQuyDoi = (int)nudSoLuongQuyDoi.Value;
            if (slQuyDoi <= 0) slQuyDoi = 1;

            string rawGia = txtDonGiaNhapItem.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(rawGia, out decimal donGiaNhap) || donGiaNhap < 0)
            {
                MessageBox.Show("Đơn giá nhập không hợp lệ!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = cboMatHang.SelectedValue.ToString();
            string tenSP = "";
            if (cboMatHang.SelectedItem is DataRowView rowSP)
            {
                maSP = rowSP["MaSP"].ToString();
                tenSP = rowSP["TenSanPham"].ToString();
            }

            string maDVT = cboDonViTinh.SelectedValue.ToString();
            string tenDV = cboDonViTinh.Text;

            object nsx = chkCoHSD.Checked ? (object)dtpNSX.Value.Date : DBNull.Value;
            object hsd = chkCoHSD.Checked ? (object)dtpHSD.Value.Date : DBNull.Value;

            // Kiểm tra xem sản phẩm cùng DVT đã có trong danh sách phiếu chưa
            DataRow[] found = _dtChiTietNhap.Select($"MaSP = '{maSP.Replace("'", "''")}' AND MaDVT = '{maDVT.Replace("'", "''")}'");
            if (found.Length > 0)
            {
                DialogResult dr = MessageBox.Show($"Sản phẩm '{tenSP}' ({tenDV}) đã có trong phiếu nhập. Bạn có muốn cộng dồn số lượng thêm {slNhap} {tenDV} không?", "Trùng mặt hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int oldSL = Convert.ToInt32(found[0]["SoLuongNhap"]);
                    int newSL = oldSL + slNhap;
                    found[0]["SoLuongNhap"] = newSL;
                    found[0]["SoLuongQuyDoi"] = slQuyDoi;
                    found[0]["SoLuongQuyDoiKho"] = newSL * slQuyDoi;
                    found[0]["DonGiaNhap"] = donGiaNhap;
                    found[0]["ThanhTien"] = newSL * donGiaNhap;
                    found[0]["NgaySanXuat"] = nsx;
                    found[0]["NgayHetHan"] = hsd;
                }
            }
            else
            {
                int slQuyDoiKho = slNhap * slQuyDoi;
                decimal thanhTien = slNhap * donGiaNhap;
                int stt = _dtChiTietNhap.Rows.Count + 1;

                _dtChiTietNhap.Rows.Add(stt, maSP, tenSP, maDVT, tenDV, slNhap, slQuyDoi, slQuyDoiKho, donGiaNhap, thanhTien, nsx, hsd);
            }

            DanhSoLaiSTT();
            CapNhatTongKetPhieuNhap();

            // Reset lại ô số lượng về 1 để nhập tiếp
            nudSoLuongNhap.Value = 1;
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.CurrentRow == null || dgvChiTietNhap.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng hàng hóa trong bảng để xóa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvChiTietNhap.CurrentRow.Index;
            _dtChiTietNhap.Rows.RemoveAt(index);
            DanhSoLaiSTT();
            CapNhatTongKetPhieuNhap();
        }

        private void btnLamMoiChiTiet_Click(object sender, EventArgs e)
        {
            nudSoLuongNhap.Value = 1;
            chkCoHSD.Checked = false;
            if (cboMatHang.Items.Count > 0) cboMatHang.SelectedIndex = 0;
        }

        private void dgvChiTietNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _dtChiTietNhap.Rows.Count)
            {
                DataRow r = _dtChiTietNhap.Rows[e.RowIndex];
                try
                {
                    cboMatHang.SelectedValue = r["MaSP"].ToString();
                    cboDonViTinh.SelectedValue = r["MaDVT"].ToString();
                    nudSoLuongNhap.Value = Convert.ToDecimal(r["SoLuongNhap"]);
                    nudSoLuongQuyDoi.Value = Convert.ToDecimal(r["SoLuongQuyDoi"]);
                    txtDonGiaNhapItem.Text = Convert.ToDecimal(r["DonGiaNhap"]).ToString("N0");

                    if (r["NgaySanXuat"] != DBNull.Value && r["NgaySanXuat"] != null)
                    {
                        chkCoHSD.Checked = true;
                        dtpNSX.Value = Convert.ToDateTime(r["NgaySanXuat"]);
                    }
                    if (r["NgayHetHan"] != DBNull.Value && r["NgayHetHan"] != null)
                    {
                        dtpHSD.Value = Convert.ToDateTime(r["NgayHetHan"]);
                    }
                }
                catch { }
            }
        }

        private void DanhSoLaiSTT()
        {
            for (int i = 0; i < _dtChiTietNhap.Rows.Count; i++)
            {
                _dtChiTietNhap.Rows[i]["STT"] = i + 1;
            }
        }

        private void CapNhatTongKetPhieuNhap()
        {
            int soMatHang = _dtChiTietNhap.Rows.Count;
            int tongSLQuyDoiKho = 0;
            decimal tongTien = 0;

            foreach (DataRow r in _dtChiTietNhap.Rows)
            {
                tongSLQuyDoiKho += Convert.ToInt32(r["SoLuongQuyDoiKho"]);
                tongTien += Convert.ToDecimal(r["ThanhTien"]);
            }

            lblTongSoMatHang.Text = $"Số mặt hàng: {soMatHang} món";
            lblTongSLQuyDoiKho.Text = $"Tổng SL quy đổi vào kho: {tongSLQuyDoiKho:N0} (đơn vị cơ bản)";
            lblTongTienHD.Text = $"TỔNG TIỀN: {tongTien:N0} VNĐ";
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            string maPNH = txtMaHoaDon.Text.Trim();
            DateTime ngayNhap = dtpNgayNhap.Value;
            string maNCC = cboNhaCungCap.SelectedValue != null ? cboNhaCungCap.SelectedValue.ToString() : "";
            string maNV = cboNguoiNhap.SelectedValue != null ? cboNguoiNhap.SelectedValue.ToString() : "1";

            if (string.IsNullOrWhiteSpace(maNCC))
            {
                MessageBox.Show("Vui lòng chọn một Nhà Cung Cấp!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaCungCap.Focus();
                return;
            }

            if (_dtChiTietNhap.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu nhập chưa có mặt hàng nào! Vui lòng chọn sản phẩm và bấm '+ Thêm Vào Phiếu'.", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Xác nhận lưu phiếu nhập {maPNH} gồm {_dtChiTietNhap.Rows.Count} mặt hàng từ nhà cung cấp '{cboNhaCungCap.Text}'?\n\nSố lượng các mặt hàng sẽ được quy đổi thành đơn vị cơ bản và cộng dồn vào tổng số tồn kho.", "Xác nhận nhập kho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string thongBao;
            if (_controller.LuuPhieuNhap(maPNH, ngayNhap, maNCC, maNV, _dtChiTietNhap, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu sau khi nhập kho
                LamMoiPhieuNhap();
                LoadDanhSachHoaDonNhap();
                LoadDanhSachHangHoa();
            }
            else
            {
                MessageBox.Show(thongBao, "Lỗi khi nhập hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiHD_Click(object sender, EventArgs e)
        {
            LamMoiPhieuNhap();
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            if (_dtChiTietNhap.Rows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu nhập đang lập dở này không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LamMoiPhieuNhap();
                }
            }
            else
            {
                LamMoiPhieuNhap();
            }
        }

        private void LamMoiPhieuNhap()
        {
            txtMaHoaDon.Text = _controller.TaoMaPhieuNhapMoi();
            dtpNgayNhap.Value = DateTime.Now;
            _dtChiTietNhap.Rows.Clear();
            CapNhatTongKetPhieuNhap();
            btnLamMoiChiTiet_Click(null, null);
        }

        #endregion

        #region TAB 2: LỊCH SỬ & DANH SÁCH PHIẾU NHẬP

        private void LoadDanhSachHoaDonNhap()
        {
            try
            {
                DataTable dt = _controller.LoadPhieuNhapHang();
                dgvHoaDonNhap.DataSource = dt;

                if (dgvHoaDonNhap.Columns.Count > 0)
                {
                    if (dgvHoaDonNhap.Columns.Contains("MaPNH"))
                    {
                        dgvHoaDonNhap.Columns["MaPNH"].HeaderText = "Mã Phiếu";
                        dgvHoaDonNhap.Columns["MaPNH"].Width = 100;
                    }
                    if (dgvHoaDonNhap.Columns.Contains("NgayNhap"))
                    {
                        dgvHoaDonNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                        dgvHoaDonNhap.Columns["NgayNhap"].Width = 140;
                        dgvHoaDonNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvHoaDonNhap.Columns.Contains("TenNCC"))
                    {
                        dgvHoaDonNhap.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
                        dgvHoaDonNhap.Columns["TenNCC"].Width = 260;
                    }
                    if (dgvHoaDonNhap.Columns.Contains("NguoiNhap"))
                    {
                        dgvHoaDonNhap.Columns["NguoiNhap"].HeaderText = "Người Nhập (Thủ Kho)";
                        dgvHoaDonNhap.Columns["NguoiNhap"].Width = 160;
                    }
                    if (dgvHoaDonNhap.Columns.Contains("SoMatHang"))
                    {
                        dgvHoaDonNhap.Columns["SoMatHang"].HeaderText = "Số Món";
                        dgvHoaDonNhap.Columns["SoMatHang"].Width = 80;
                    }
                    if (dgvHoaDonNhap.Columns.Contains("TongTien"))
                    {
                        dgvHoaDonNhap.Columns["TongTien"].HeaderText = "Tổng Tiền (VNĐ)";
                        dgvHoaDonNhap.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                        dgvHoaDonNhap.Columns["TongTien"].Width = 150;
                    }

                    if (dgvHoaDonNhap.Columns.Contains("MaNCC")) dgvHoaDonNhap.Columns["MaNCC"].Visible = false;
                    if (dgvHoaDonNhap.Columns.Contains("MaNV")) dgvHoaDonNhap.Columns["MaNV"].Visible = false;
                }

                if (dgvHoaDonNhap.Rows.Count > 0)
                {
                    dgvHoaDonNhap_CellClick(null, new DataGridViewCellEventArgs(0, 0));
                }
                else
                {
                    dgvChiTietPhieuCu.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn nhập: " + ex.Message);
            }
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null && e.RowIndex >= 0 && e.RowIndex < dgvHoaDonNhap.Rows.Count)
            {
                DataGridViewRow row = dgvHoaDonNhap.Rows[e.RowIndex];
                string maPNH = row.Cells["MaPNH"].Value?.ToString();

                if (!string.IsNullOrEmpty(maPNH))
                {
                    LoadChiTietPhieuNhapCu(maPNH);
                }
            }
        }

        private void LoadChiTietPhieuNhapCu(string maPNH)
        {
            try
            {
                DataTable dtCT = _controller.LoadChiTietPhieuNhap(maPNH);
                dgvChiTietPhieuCu.DataSource = dtCT;

                if (dgvChiTietPhieuCu.Columns.Count > 0)
                {
                    if (dgvChiTietPhieuCu.Columns.Contains("MaPNH")) dgvChiTietPhieuCu.Columns["MaPNH"].Visible = false;
                    if (dgvChiTietPhieuCu.Columns.Contains("MaDVT")) dgvChiTietPhieuCu.Columns["MaDVT"].Visible = false;

                    if (dgvChiTietPhieuCu.Columns.Contains("MaSP"))
                    {
                        dgvChiTietPhieuCu.Columns["MaSP"].HeaderText = "Mã SP";
                        dgvChiTietPhieuCu.Columns["MaSP"].Width = 60;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("TenSanPham"))
                    {
                        dgvChiTietPhieuCu.Columns["TenSanPham"].HeaderText = "Tên Hàng Hóa";
                        dgvChiTietPhieuCu.Columns["TenSanPham"].Width = 200;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("TenDV"))
                    {
                        dgvChiTietPhieuCu.Columns["TenDV"].HeaderText = "ĐVT Nhập";
                        dgvChiTietPhieuCu.Columns["TenDV"].Width = 90;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("SoLuongNhap"))
                    {
                        dgvChiTietPhieuCu.Columns["SoLuongNhap"].HeaderText = "SL Nhập";
                        dgvChiTietPhieuCu.Columns["SoLuongNhap"].Width = 80;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("SoLuongQuyDoi"))
                    {
                        dgvChiTietPhieuCu.Columns["SoLuongQuyDoi"].HeaderText = "Quy Đổi";
                        dgvChiTietPhieuCu.Columns["SoLuongQuyDoi"].Width = 70;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("SoLuongQuyDoiKho"))
                    {
                        dgvChiTietPhieuCu.Columns["SoLuongQuyDoiKho"].HeaderText = "SL Vào Kho";
                        dgvChiTietPhieuCu.Columns["SoLuongQuyDoiKho"].Width = 100;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("DonGiaNhap"))
                    {
                        dgvChiTietPhieuCu.Columns["DonGiaNhap"].HeaderText = "Đơn Giá Nhập";
                        dgvChiTietPhieuCu.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
                        dgvChiTietPhieuCu.Columns["DonGiaNhap"].Width = 120;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("ThanhTien"))
                    {
                        dgvChiTietPhieuCu.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                        dgvChiTietPhieuCu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                        dgvChiTietPhieuCu.Columns["ThanhTien"].Width = 130;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("NgaySanXuat"))
                    {
                        dgvChiTietPhieuCu.Columns["NgaySanXuat"].HeaderText = "NSX";
                        dgvChiTietPhieuCu.Columns["NgaySanXuat"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvChiTietPhieuCu.Columns["NgaySanXuat"].Width = 95;
                    }
                    if (dgvChiTietPhieuCu.Columns.Contains("NgayHetHan"))
                    {
                        dgvChiTietPhieuCu.Columns["NgayHetHan"].HeaderText = "HSD";
                        dgvChiTietPhieuCu.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvChiTietPhieuCu.Columns["NgayHetHan"].Width = 95;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết phiếu nhập: " + ex.Message);
            }
        }

        private void txtTimKiemPNH_TextChanged(object sender, EventArgs e)
        {
            LocDanhSachHoaDonNhap();
        }

        private void cboLocNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDanhSachHoaDonNhap();
        }

        private void LocDanhSachHoaDonNhap()
        {
            DataTable dt = dgvHoaDonNhap.DataSource as DataTable;
            if (dt == null) return;

            string filterMa = txtTimKiemPNH.Text.Trim().Replace("'", "''");
            string maNCC = cboLocNCC.SelectedValue != null ? cboLocNCC.SelectedValue.ToString() : "";

            string filter = "";
            if (!string.IsNullOrEmpty(filterMa))
            {
                filter += $"MaPNH LIKE '%{filterMa}%'";
            }
            if (!string.IsNullOrEmpty(maNCC))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += $"MaNCC = '{maNCC.Replace("'", "''")}'";
            }

            dt.DefaultView.RowFilter = filter;
        }

        private void btnLamMoiLichSu_Click(object sender, EventArgs e)
        {
            txtTimKiemPNH.Clear();
            if (cboLocNCC.Items.Count > 0) cboLocNCC.SelectedIndex = 0;
            LoadDanhSachHoaDonNhap();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonNhap.CurrentRow == null || dgvHoaDonNhap.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập từ bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPNH = dgvHoaDonNhap.CurrentRow.Cells["MaPNH"].Value?.ToString();
            if (string.IsNullOrEmpty(maPNH)) return;

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu nhập '{maPNH}' không?\n\nLưu ý: Toàn bộ số lượng hàng hóa trong phiếu (đã quy đổi) sẽ được hoàn trừ lại khỏi kho tồn!", "Xác nhận xóa phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string thongBao;
                if (_controller.XoaPhieuNhap(maPNH, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDonNhap();
                    LoadDanhSachHangHoa();
                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region TAB 3: QUẢN LÝ KHO HÀNG HÓA

        private void LoadDanhSachHangHoa()
        {
            try
            {
                dgvHangHoa.DataSource = _controller.LoadSanPham();
                if (dgvHangHoa.Columns.Count > 0)
                {
                    if (dgvHangHoa.Columns.Contains("MaSP"))
                    {
                        dgvHangHoa.Columns["MaSP"].HeaderText = "Mã SP";
                        dgvHangHoa.Columns["MaSP"].Width = 70;
                    }
                    if (dgvHangHoa.Columns.Contains("TenSanPham"))
                    {
                        dgvHangHoa.Columns["TenSanPham"].HeaderText = "Tên Hàng Hóa";
                        dgvHangHoa.Columns["TenSanPham"].Width = 240;
                    }
                    if (dgvHangHoa.Columns.Contains("TenDanhMuc"))
                    {
                        dgvHangHoa.Columns["TenDanhMuc"].HeaderText = "Danh Mục";
                        dgvHangHoa.Columns["TenDanhMuc"].Width = 150;
                    }
                    if (dgvHangHoa.Columns.Contains("SoLuongTong"))
                    {
                        dgvHangHoa.Columns["SoLuongTong"].HeaderText = "Tổng Tồn Kho";
                        dgvHangHoa.Columns["SoLuongTong"].Width = 110;
                    }
                    if (dgvHangHoa.Columns.Contains("TenDV"))
                    {
                        dgvHangHoa.Columns["TenDV"].HeaderText = "Đ/Vị Cơ Bản";
                        dgvHangHoa.Columns["TenDV"].Width = 90;
                    }
                    if (dgvHangHoa.Columns.Contains("DonGiaNhap"))
                    {
                        dgvHangHoa.Columns["DonGiaNhap"].HeaderText = "Giá Nhập Cơ Bản";
                        dgvHangHoa.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
                        dgvHangHoa.Columns["DonGiaNhap"].Width = 130;
                    }
                    if (dgvHangHoa.Columns.Contains("DonGiaBan"))
                    {
                        dgvHangHoa.Columns["DonGiaBan"].HeaderText = "Giá Bán Cơ Bản";
                        dgvHangHoa.Columns["DonGiaBan"].DefaultCellStyle.Format = "N0";
                        dgvHangHoa.Columns["DonGiaBan"].Width = 130;
                    }

                    if (dgvHangHoa.Columns.Contains("SoLuong")) dgvHangHoa.Columns["SoLuong"].Visible = false;
                    if (dgvHangHoa.Columns.Contains("MaDM")) dgvHangHoa.Columns["MaDM"].Visible = false;
                    if (dgvHangHoa.Columns.Contains("MaDVT")) dgvHangHoa.Columns["MaDVT"].Visible = false;
                    if (dgvHangHoa.Columns.Contains("MaNCC")) dgvHangHoa.Columns["MaNCC"].Visible = false;
                    if (dgvHangHoa.Columns.Contains("TenNCC")) dgvHangHoa.Columns["TenNCC"].Visible = false;
                    if (dgvHangHoa.Columns.Contains("MoTa")) dgvHangHoa.Columns["MoTa"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hàng hóa: " + ex.Message);
            }
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHangHoa.Rows.Count)
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];

                txtMaHangHoa.Text = row.Cells["MaSP"].Value?.ToString();
                txtTenHangHoa.Text = row.Cells["TenSanPham"].Value?.ToString();
                txtSoLuong.Text = row.Cells["SoLuongTong"].Value?.ToString();
                txtDonGiaNhap.Text = Convert.ToDecimal(row.Cells["DonGiaNhap"].Value ?? 0).ToString("N0");
                txtDonGiaBan.Text = Convert.ToDecimal(row.Cells["DonGiaBan"].Value ?? 0).ToString("N0");
                txtMoTaHH.Text = row.Cells["MoTa"].Value?.ToString();

                if (row.Cells["MaDM"].Value != null && row.Cells["MaDM"].Value != DBNull.Value)
                {
                    cboDanhMucHH.SelectedValue = row.Cells["MaDM"].Value;
                }
            }
        }

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            int maDM = cboDanhMucHH.SelectedValue != null ? Convert.ToInt32(cboDanhMucHH.SelectedValue) : 0;
            if (maDM == 0)
            {
                MessageBox.Show("Vui lòng chọn một Danh mục cụ thể (không chọn 'Tất cả danh mục') trước khi Thêm!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = PhienDangNhap.MaNV > 0 ? PhienDangNhap.MaNV : (UserSession.MaNV > 0 ? UserSession.MaNV : 1);

            string thongBao;
            if (_controller.ThemSanPham(txtMaHangHoa.Text, txtTenHangHoa.Text, txtSoLuong.Text, "0", txtDonGiaNhap.Text, txtDonGiaBan.Text, txtMoTaHH.Text, maDM, maNV, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHangHoa();
                LoadComboBoxMatHang();
                LamMoiFormHangHoa();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaHH_Click(object sender, EventArgs e)
        {
            int maDM = cboDanhMucHH.SelectedValue != null ? Convert.ToInt32(cboDanhMucHH.SelectedValue) : 1;
            if (maDM == 0) maDM = 1;

            string thongBao;
            if (_controller.SuaSanPham(txtMaHangHoa.Text, txtTenHangHoa.Text, txtSoLuong.Text, "0", txtDonGiaNhap.Text, txtDonGiaBan.Text, txtMoTaHH.Text, maDM, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHangHoa();
                LoadComboBoxMatHang();
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

            string maSPDuocChon = dgvHangHoa.CurrentRow.Cells["MaSP"].Value.ToString();
            string tenSP = dgvHangHoa.CurrentRow.Cells["TenSanPham"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hàng hóa '{tenSP}' (Mã {maSPDuocChon}) không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string thongBao;
                if (_controller.XoaSanPham(maSPDuocChon, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHangHoa();
                    LoadComboBoxMatHang();
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

        private void LamMoiFormHangHoa()
        {
            txtMaHangHoa.Text = _controller.TaoMaSanPhamMoi();
            txtTenHangHoa.Clear();
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtMoTaHH.Clear();
        }

        #endregion

        #region QUẢN LÝ DANH MỤC

        private void LoadDanhSachDanhMuc()
        {
            try
            {
                dgvDanhMuc.DataSource = _controller.LoadDanhMuc();
                if (dgvDanhMuc.Columns.Count > 0)
                {
                    dgvDanhMuc.Columns["MaDM"].HeaderText = "Mã DM";
                    dgvDanhMuc.Columns["MaDM"].Width = 70;
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
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhMuc.Rows.Count)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
                txtMaDanhMuc.Text = row.Cells["MaDM"].Value?.ToString();
                txtTenDanhMuc.Text = row.Cells["TenDanhMuc"].Value?.ToString();
            }
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            string thongBao;
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

        private void BtnMoQLDM_Click(object sender, EventArgs e)
        {
            Form frmDM = new Form();
            frmDM.Text = "Quản Lý Danh Mục";
            frmDM.Size = new System.Drawing.Size(420, 550);
            frmDM.StartPosition = FormStartPosition.CenterParent;
            frmDM.MaximizeBox = false;
            frmDM.MinimizeBox = false;
            frmDM.BackColor = Color.White;

            grpDanhMuc.Location = new System.Drawing.Point(10, 10);
            grpDanhMuc.Visible = true;
            frmDM.Controls.Add(grpDanhMuc);

            frmDM.FormClosing += (s, ev) =>
            {
                this.tabHangHoa.Controls.Add(grpDanhMuc);
                grpDanhMuc.Visible = false;
            };

            LamMoiFormDanhMuc();
            frmDM.ShowDialog();
        }

        #endregion
    }
}
