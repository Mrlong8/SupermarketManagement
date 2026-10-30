using SupermarketManagement.Models.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.Product
{
    public partial class Frm_KhoiPhuc : Form
    {
        private SanPhamRepositoryV2 _repo = new SanPhamRepositoryV2();

        public Frm_KhoiPhuc()
        {
            InitializeComponent();
        }

        // Tải danh sách sản phẩm đã bị xóa lên DataGridView
        private void LoadData()
        {
            DataTable dt = _repo.GetListSanPhamDaXoa();
            dgvDaTa.DataSource = dt;
        }

        // Khởi tạo và nạp dữ liệu khi mở Form
        private void Frm_KhoiPhuc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Khôi phục trạng thái sản phẩm được chọn từ 0 thành 1
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (dgvDaTa.CurrentRow == null || dgvDaTa.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần khôi phục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = dgvDaTa.CurrentRow.Cells["MaSP"].Value?.ToString();
            string tenSP = dgvDaTa.CurrentRow.Cells["TenSanPham"].Value?.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn khôi phục sản phẩm {tenSP}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _repo.KhoiPhuc(maSP);
                    MessageBox.Show("Khôi phục sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();

                    if (IndexProduct.Instance != null)
                    {
                        IndexProduct.Instance.GetSanPham();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi khôi phục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Đóng Form khôi phục
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}