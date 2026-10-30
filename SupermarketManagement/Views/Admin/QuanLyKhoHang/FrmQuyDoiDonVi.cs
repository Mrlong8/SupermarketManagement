using SupermarketManagement.Controllers;
using SupermarketManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.QuanLyKhoHang
{
    public partial class FrmQuyDoiDonVi : Form
    {
        private readonly string _maSP;
        private readonly string _tenSP;
        private decimal _giaNhapCoBan;
        private decimal _giaBanCoBan;
        private readonly bool _isNewProduct;
        private readonly KhoHangController _controller = new KhoHangController();

        private List<DonViQuyDoiItem> _dsDonVi = new List<DonViQuyDoiItem>();
        private DataTable _dtAllDonViTinh;
        private bool _isInitializing = true;

        public List<DonViQuyDoiItem> DanhSachDonVi => _dsDonVi;

        public DonViQuyDoiItem DonViCoBan => _dsDonVi.FirstOrDefault(x => x.SoLuongQuyDoi == 1);

        public decimal GiaNhapCoBanLayRa
        {
            get
            {
                string raw = txtGiaNhapCoBan.Text.Replace(",", "").Replace(".", "").Trim();
                return decimal.TryParse(raw, out decimal val) ? val : _giaNhapCoBan;
            }
        }

        public decimal GiaBanCoBanLayRa
        {
            get
            {
                string raw = txtGiaBanCoBan.Text.Replace(",", "").Replace(".", "").Trim();
                return decimal.TryParse(raw, out decimal val) ? val : _giaBanCoBan;
            }
        }

        public string MoTaQuyDoi
        {
            get
            {
                var coBan = DonViCoBan;
                var quyDoiList = _dsDonVi.Where(x => x.SoLuongQuyDoi > 1).OrderBy(x => x.SoLuongQuyDoi).ToList();
                if (coBan == null) return "-";
                if (quyDoiList.Count == 0) return $"1 {coBan.TenDV}";

                List<string> parts = new List<string>();
                foreach (var qd in quyDoiList)
                {
                    parts.Add($"1 {qd.TenDV} = {qd.SoLuongQuyDoi} {coBan.TenDV}");
                }
                return string.Join(", ", parts);
            }
        }

        public FrmQuyDoiDonVi(string maSP, string tenSP, decimal giaNhap, decimal giaBan, List<DonViQuyDoiItem> initialUnits = null, bool isNewProduct = false)
        {
            InitializeComponent();
            _maSP = maSP?.Trim() ?? "";
            _tenSP = tenSP?.Trim() ?? "";
            _giaNhapCoBan = giaNhap;
            _giaBanCoBan = giaBan;
            _isNewProduct = isNewProduct;

            if (initialUnits != null && initialUnits.Count > 0)
            {
                _dsDonVi = initialUnits.Select(x => new DonViQuyDoiItem(x.MaDVT, x.TenDV, x.SoLuongQuyDoi, x.DonGiaNhapLe, x.DonGiaBanLe)).ToList();
            }
        }

        private void FrmQuyDoiDonVi_Load(object sender, EventArgs e)
        {
            lblSubTieuDe.Text = $"Mã SP: {(!string.IsNullOrEmpty(_maSP) ? _maSP : "(Chưa có)")} | Tên SP: {(!string.IsNullOrEmpty(_tenSP) ? _tenSP : "(Chưa đặt tên)")}";
            txtGiaNhapCoBan.Text = _giaNhapCoBan.ToString("N0");
            txtGiaBanCoBan.Text = _giaBanCoBan.ToString("N0");

            TaiDanhSachDonViTinhHeThong();

            // Nếu chưa có đơn vị nào được truyền vào và sản phẩm đã tồn tại trong CSDL, tải từ CSDL
            if (_dsDonVi.Count == 0 && !_isNewProduct && !string.IsNullOrEmpty(_maSP))
            {
                DataTable dtDVT = _controller.LoadDonViTinhTheoSanPham(_maSP);
                if (dtDVT != null && dtDVT.Rows.Count > 0)
                {
                    foreach (DataRow r in dtDVT.Rows)
                    {
                        string maDVT = r["MaDVT"]?.ToString();
                        string tenDV = r["TenDV"]?.ToString();
                        int qd = Convert.ToInt32(r["SoLuongQuyDoi"] ?? 1);
                        decimal gNhap = Convert.ToDecimal(r["DonGiaNhapLe"] ?? 0);
                        decimal gBan = Convert.ToDecimal(r["DonGiaBanLe"] ?? 0);
                        _dsDonVi.Add(new DonViQuyDoiItem(maDVT, tenDV, qd, gNhap, gBan));
                    }
                }
            }

            // Nếu vẫn rỗng (sản phẩm mới chưa cấu hình), khởi tạo đơn vị cơ bản mặc định
            if (_dsDonVi.Count == 0)
            {
                KhoiTaoGoiYDonViMacDinh();
            }

            // Đồng bộ combobox cơ bản với đơn vị cơ bản hiện tại
            var dvCoBan = DonViCoBan;
            if (dvCoBan != null && cboDonViCoBan.Items.Count > 0)
            {
                cboDonViCoBan.SelectedValue = dvCoBan.MaDVT;
            }

            // Đồng bộ combobox quy đổi với 1 đơn vị lớn hơn (mặc định Thùng hoặc đơn vị quy đổi đầu tiên)
            ChonDonViQuyDoiMacDinh();

            _isInitializing = false;
            CapNhatGiaVaCongThucLive();
            RenderGrid();
        }

        private void TaiDanhSachDonViTinhHeThong()
        {
            _dtAllDonViTinh = _controller.LoadAllDonViTinh();

            cboDonViCoBan.DataSource = null;
            cboDonViCoBan.DisplayMember = "TenDV";
            cboDonViCoBan.ValueMember = "MaDVT";
            cboDonViCoBan.DataSource = _dtAllDonViTinh.Copy();

            cboDonViQuyDoi.DataSource = null;
            cboDonViQuyDoi.DisplayMember = "TenDV";
            cboDonViQuyDoi.ValueMember = "MaDVT";
            cboDonViQuyDoi.DataSource = _dtAllDonViTinh.Copy();
        }

        private void KhoiTaoGoiYDonViMacDinh()
        {
            string text = (_tenSP ?? "").ToLower();
            string maCoBan = "DV01";
            string tenCoBan = "Cái";

            if (text.Contains("lego") || text.Contains("sữa") || text.Contains("hộp"))
            {
                maCoBan = "DV03"; // Hộp
                tenCoBan = "Hộp";
            }
            else if (text.Contains("bánh") || text.Contains("kẹo") || text.Contains("snack") || text.Contains("mì"))
            {
                maCoBan = "DV07"; // Gói
                tenCoBan = "Gói";
            }
            else if (text.Contains("chai") || text.Contains("dầu gội") || text.Contains("rửa chén") || text.Contains("nước ngọt") || text.Contains("rượu"))
            {
                maCoBan = "DV05"; // Chai
                tenCoBan = "Chai";
            }
            else if (text.Contains("táo") || text.Contains("thịt") || text.Contains("cá") || text.Contains("tươi"))
            {
                maCoBan = "DV08"; // Kg
                tenCoBan = "Kg";
            }

            // Tìm tên thật từ _dtAllDonViTinh nếu có
            if (_dtAllDonViTinh != null)
            {
                DataRow[] rows = _dtAllDonViTinh.Select($"MaDVT = '{maCoBan}'");
                if (rows.Length > 0)
                {
                    tenCoBan = rows[0]["TenDV"].ToString();
                }
            }

            decimal gNhap = _giaNhapCoBan;
            decimal gBan = _giaBanCoBan;
            _dsDonVi.Add(new DonViQuyDoiItem(maCoBan, tenCoBan, 1, gNhap, gBan));

            // Gợi ý thêm đơn vị quy đổi Thùng = 10 hộp/gói
            string maThung = "DV02";
            string tenThung = "Thùng";
            if (_dtAllDonViTinh != null)
            {
                DataRow[] rowsThung = _dtAllDonViTinh.Select("MaDVT = 'DV02'");
                if (rowsThung.Length > 0)
                {
                    tenThung = rowsThung[0]["TenDV"].ToString();
                    int qd = 10;
                    _dsDonVi.Add(new DonViQuyDoiItem(maThung, tenThung, qd, gNhap * qd, gBan * qd));
                }
            }
        }

        private void ChonDonViQuyDoiMacDinh()
        {
            var coBan = DonViCoBan;
            string maCoBan = coBan?.MaDVT ?? "";

            // Ưu tiên chọn DV02 (Thùng) nếu khác đơn vị cơ bản
            if (maCoBan != "DV02")
            {
                cboDonViQuyDoi.SelectedValue = "DV02";
            }
            else
            {
                // Nếu cơ bản đã là Thùng, chọn Lốc hoặc Hộp
                cboDonViQuyDoi.SelectedValue = "DV04";
            }

            // Nếu đã có quy đổi sẵn trong danh sách, chọn theo quy đổi đầu tiên
            var firstQuyDoi = _dsDonVi.FirstOrDefault(x => x.SoLuongQuyDoi > 1);
            if (firstQuyDoi != null)
            {
                cboDonViQuyDoi.SelectedValue = firstQuyDoi.MaDVT;
                nudSoLuongQuyDoi.Value = firstQuyDoi.SoLuongQuyDoi >= 2 ? firstQuyDoi.SoLuongQuyDoi : 10;
            }
        }

        private void CapNhatGiaVaCongThucLive()
        {
            if (_isInitializing) return;

            string tenCoBan = cboDonViCoBan.Text;
            string tenQuyDoi = cboDonViQuyDoi.Text;
            int qd = (int)nudSoLuongQuyDoi.Value;
            if (qd <= 0) qd = 1;

            lblCongThucLive.Text = $"👉 QUY ĐỔI: 1 {tenQuyDoi} = {qd} {tenCoBan}";

            string rawGiaNhap = txtGiaNhapCoBan.Text.Replace(",", "").Replace(".", "").Trim();
            decimal gNhapCoBan = decimal.TryParse(rawGiaNhap, out decimal gn) ? gn : 0;

            string rawGiaBan = txtGiaBanCoBan.Text.Replace(",", "").Replace(".", "").Trim();
            decimal gBanCoBan = decimal.TryParse(rawGiaBan, out decimal gb) ? gb : 0;

            txtGiaNhapQuyDoi.Text = (gNhapCoBan * qd).ToString("N0");
            txtGiaBanQuyDoi.Text = (gBanCoBan * qd).ToString("N0");
        }

        private void RenderGrid()
        {
            var coBan = DonViCoBan;
            string tenCoBan = coBan != null ? coBan.TenDV : cboDonViCoBan.Text;

            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("MaDVT", typeof(string));
            dtGrid.Columns.Add("TenDV", typeof(string));
            dtGrid.Columns.Add("LoaiDV", typeof(string));
            dtGrid.Columns.Add("SoLuongQuyDoi", typeof(int));
            dtGrid.Columns.Add("CongThuc", typeof(string));
            dtGrid.Columns.Add("DonGiaNhap", typeof(string));
            dtGrid.Columns.Add("DonGiaBan", typeof(string));

            foreach (var item in _dsDonVi.OrderBy(x => x.SoLuongQuyDoi))
            {
                string loai = item.SoLuongQuyDoi == 1 ? "Cơ bản (Gốc)" : "Quy đổi";
                string congThuc = item.SoLuongQuyDoi == 1 ? "Đơn vị gốc (1)" : $"1 {item.TenDV} = {item.SoLuongQuyDoi} {tenCoBan}";

                dtGrid.Rows.Add(
                    item.MaDVT,
                    item.TenDV,
                    loai,
                    item.SoLuongQuyDoi,
                    congThuc,
                    item.DonGiaNhapLe.ToString("N0"),
                    item.DonGiaBanLe.ToString("N0")
                );
            }

            dgvDonVi.DataSource = dtGrid;

            // Highlight dòng đơn vị cơ bản
            foreach (DataGridViewRow row in dgvDonVi.Rows)
            {
                if (row.Cells["colLoaiDV"].Value?.ToString() == "Cơ bản (Gốc)")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(235, 248, 238);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void cboDonViCoBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing || cboDonViCoBan.SelectedValue == null) return;

            string maDVT = cboDonViCoBan.SelectedValue.ToString();
            string tenDV = cboDonViCoBan.Text;

            string rawGiaNhap = txtGiaNhapCoBan.Text.Replace(",", "").Replace(".", "").Trim();
            decimal gNhapCoBan = decimal.TryParse(rawGiaNhap, out decimal gn) ? gn : 0;

            string rawGiaBan = txtGiaBanCoBan.Text.Replace(",", "").Replace(".", "").Trim();
            decimal gBanCoBan = decimal.TryParse(rawGiaBan, out decimal gb) ? gb : 0;

            // Cập nhật hoặc tạo mới đơn vị cơ bản trong danh sách
            var existingCoBan = DonViCoBan;
            if (existingCoBan != null)
            {
                existingCoBan.MaDVT = maDVT;
                existingCoBan.TenDV = tenDV;
                existingCoBan.DonGiaNhapLe = gNhapCoBan;
                existingCoBan.DonGiaBanLe = gBanCoBan;
            }
            else
            {
                _dsDonVi.Insert(0, new DonViQuyDoiItem(maDVT, tenDV, 1, gNhapCoBan, gBanCoBan));
            }

            CapNhatGiaVaCongThucLive();
            RenderGrid();
        }

        private void cboDonViQuyDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatGiaVaCongThucLive();
        }

        private void nudSoLuongQuyDoi_ValueChanged(object sender, EventArgs e)
        {
            CapNhatGiaVaCongThucLive();
        }

        private void txtGiaCoBan_TextChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            var coBan = DonViCoBan;
            if (coBan != null)
            {
                string rawGiaNhap = txtGiaNhapCoBan.Text.Replace(",", "").Replace(".", "").Trim();
                if (decimal.TryParse(rawGiaNhap, out decimal gn)) coBan.DonGiaNhapLe = gn;

                string rawGiaBan = txtGiaBanCoBan.Text.Replace(",", "").Replace(".", "").Trim();
                if (decimal.TryParse(rawGiaBan, out decimal gb)) coBan.DonGiaBanLe = gb;
            }

            CapNhatGiaVaCongThucLive();
            RenderGrid();
        }

        private void btnThemQuyDoi_Click(object sender, EventArgs e)
        {
            if (cboDonViQuyDoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn vị quy đổi!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDVTQuyDoi = cboDonViQuyDoi.SelectedValue.ToString();
            string tenDVQuyDoi = cboDonViQuyDoi.Text.Trim();

            var coBan = DonViCoBan;
            if (coBan != null && maDVTQuyDoi == coBan.MaDVT)
            {
                MessageBox.Show($"Đơn vị quy đổi ({tenDVQuyDoi}) không được trùng với đơn vị cơ bản ({coBan.TenDV})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qd = (int)nudSoLuongQuyDoi.Value;
            if (qd <= 1)
            {
                MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 1 (Ví dụ: 1 Thùng = 10 Hộp)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rawGiaNhap = txtGiaNhapQuyDoi.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(rawGiaNhap, out decimal gNhapQuyDoi) || gNhapQuyDoi < 0)
            {
                gNhapQuyDoi = (coBan != null ? coBan.DonGiaNhapLe : 0) * qd;
            }

            string rawGiaBan = txtGiaBanQuyDoi.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(rawGiaBan, out decimal gBanQuyDoi) || gBanQuyDoi < 0)
            {
                gBanQuyDoi = (coBan != null ? coBan.DonGiaBanLe : 0) * qd;
            }

            // Kiểm tra xem đơn vị này đã có trong danh sách chưa
            var existing = _dsDonVi.FirstOrDefault(x => x.MaDVT == maDVTQuyDoi);
            if (existing != null)
            {
                existing.SoLuongQuyDoi = qd;
                existing.TenDV = tenDVQuyDoi;
                existing.DonGiaNhapLe = gNhapQuyDoi;
                existing.DonGiaBanLe = gBanQuyDoi;
                MessageBox.Show($"Đã cập nhật quy đổi: 1 {tenDVQuyDoi} = {qd} {coBan?.TenDV}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _dsDonVi.Add(new DonViQuyDoiItem(maDVTQuyDoi, tenDVQuyDoi, qd, gNhapQuyDoi, gBanQuyDoi));
                MessageBox.Show($"Đã thêm quy đổi mới: 1 {tenDVQuyDoi} = {qd} {coBan?.TenDV}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RenderGrid();
        }

        private void dgvDonVi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDonVi.Rows.Count) return;

            // Kiểm tra click vào cột Xóa
            if (dgvDonVi.Columns[e.ColumnIndex].Name == "colXoa")
            {
                string maDVT = dgvDonVi.Rows[e.RowIndex].Cells["colMaDVT"].Value?.ToString();
                string tenDV = dgvDonVi.Rows[e.RowIndex].Cells["colTenDV"].Value?.ToString();
                int qd = Convert.ToInt32(dgvDonVi.Rows[e.RowIndex].Cells["colSoLuongQuyDoi"].Value ?? 1);

                if (qd == 1)
                {
                    MessageBox.Show("Không thể xóa đơn vị cơ bản! Nếu muốn đổi đơn vị cơ bản khác, hãy chọn tại mục 1 phía trên.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn vị quy đổi '{tenDV}' khỏi sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    _dsDonVi.RemoveAll(x => x.MaDVT == maDVT);
                    RenderGrid();
                }
            }
        }

        private void btnThemDVTCoBan_Click(object sender, EventArgs e)
        {
            ThemDonViTinhMoiVaoHeThong(isForCoBan: true);
        }

        private void btnThemDVTQuyDoi_Click(object sender, EventArgs e)
        {
            ThemDonViTinhMoiVaoHeThong(isForCoBan: false);
        }

        private void ThemDonViTinhMoiVaoHeThong(bool isForCoBan)
        {
            string tenDV = HienThiDialogNhapDonViMoi("Thêm Đơn Vị Tính Mới", "Nhập tên Đơn Vị Tính mới (VD: Thùng, Hộp, Bao, Két, Vỉ, Bịch...):");
            if (string.IsNullOrWhiteSpace(tenDV)) return;

            tenDV = tenDV.Trim();
            string maMoi;
            string thongBao;
            if (_controller.ThemDonViTinhMoi(tenDV, "Thêm từ giao diện quy đổi", out maMoi, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachDonViTinhHeThong();

                if (isForCoBan)
                {
                    cboDonViCoBan.SelectedValue = maMoi;
                }
                else
                {
                    cboDonViQuyDoi.SelectedValue = maMoi;
                }
            }
            else
            {
                MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HienThiDialogNhapDonViMoi(string title, string prompt)
        {
            using (Form promptForm = new Form())
            {
                promptForm.Width = 380;
                promptForm.Height = 175;
                promptForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                promptForm.Text = title;
                promptForm.StartPosition = FormStartPosition.CenterParent;
                promptForm.MaximizeBox = false;
                promptForm.MinimizeBox = false;
                promptForm.BackColor = Color.White;

                Label textLabel = new Label() { Left = 20, Top = 15, Width = 325, Text = prompt, Font = new Font("Segoe UI", 9F) };
                TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 325, Font = new Font("Segoe UI", 9.5F) };
                Button confirmation = new Button() { Text = "Đồng ý", Left = 165, Width = 85, Top = 88, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(22, 135, 55), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold) };
                confirmation.FlatAppearance.BorderSize = 0;
                Button cancel = new Button() { Text = "Hủy", Left = 260, Width = 85, Top = 88, DialogResult = DialogResult.Cancel, BackColor = Color.FromArgb(108, 117, 125), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 8.5F) };
                cancel.FlatAppearance.BorderSize = 0;

                promptForm.Controls.Add(textLabel);
                promptForm.Controls.Add(textBox);
                promptForm.Controls.Add(confirmation);
                promptForm.Controls.Add(cancel);
                promptForm.AcceptButton = confirmation;
                promptForm.CancelButton = cancel;

                return promptForm.ShowDialog(this) == DialogResult.OK ? textBox.Text.Trim() : "";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var coBan = DonViCoBan;
            if (coBan == null)
            {
                MessageBox.Show("Sản phẩm phải có ít nhất 1 đơn vị cơ bản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đồng bộ giá cơ bản từ ô nhập
            string rawGiaNhap = txtGiaNhapCoBan.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(rawGiaNhap, out decimal gn)) coBan.DonGiaNhapLe = gn;

            string rawGiaBan = txtGiaBanCoBan.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(rawGiaBan, out decimal gb)) coBan.DonGiaBanLe = gb;

            // Nếu sản phẩm đã tồn tại trong CSDL, lưu trực tiếp vào CSDL
            if (!_isNewProduct && !string.IsNullOrEmpty(_maSP))
            {
                string thongBao;
                if (!_controller.SaveDonViTinhChoSanPham(_maSP, _dsDonVi, out thongBao))
                {
                    MessageBox.Show(thongBao, "Lỗi khi lưu vào CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Cập nhật quy đổi đơn vị tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
