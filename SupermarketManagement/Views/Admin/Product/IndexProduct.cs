using SupermarketManagement.Models.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.Product
{
    public partial class IndexProduct : Form
    {
        private SanPhamRepositoryV2 _repo = new SanPhamRepositoryV2();
        public static IndexProduct Instance;
        public IndexProduct()
        {
            InitializeComponent();
            Instance = this;
        }

        private void IndexProduct_Load(object sender, EventArgs e)
        {
            GetDanhMuc();
            GetSanPham();
        }

        // Hàm chung hỗ trợ vẽ danh sách Card Sản Phẩm lên FlowLayoutPanel
        private void RenderProductList(DataTable products)
        {
            flpListProduct.SuspendLayout();
            flpListProduct.Controls.Clear();

            if (products != null && products.Rows.Count > 0)
            {
                foreach (DataRow item in products.Rows)
                {
                    ProductItemControl control = new ProductItemControl();

                    string maSP = item["MaSP"]?.ToString();
                    string tenSP = item["TenSanPham"]?.ToString();
                    string giaNhap = item["DonGiaNhap"]?.ToString();
                    string giaBan = item["DonGiaBan"]?.ToString();
                    string soLuong = item["SoLuong"]?.ToString();
                    string urlImage = item["UrlImage"]?.ToString();

                    control.SetData(maSP,tenSP, giaNhap, giaBan, soLuong, urlImage);
                    flpListProduct.Controls.Add(control);
                }
            }

            flpListProduct.ResumeLayout();
        }

        public void GetSanPham()
        {
            DataTable products = _repo.GetListSanPham();
            RenderProductList(products);
        }

        private void GetDanhMuc()
        {
            DataTable dt = _repo.GetDanhMuc();

            cbDanhMuc.DataSource = dt;
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDM";
            cbDanhMuc.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
                return;
            }

            // Bỏ chọn danh mục khi thực hiện tìm kiếm riêng
            cbDanhMuc.SelectedIndex = -1;

            DataTable dtResult = _repo.TimKiemSanPhamTheoTen(keyword);
            RenderProductList(dtResult);

            if (dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Bấm Enter trong ô tìm kiếm để kích hoạt nút Tìm kiếm
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }


   
        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDanhMuc.Focused && cbDanhMuc.SelectedValue != null)
            {
                string maDM = cbDanhMuc.SelectedValue.ToString();

                txtTimKiem.Clear();

                DataTable dtResult = _repo.LocSanPhamTheoDanhMuc(maDM);
                RenderProductList(dtResult);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cbDanhMuc.SelectedIndexChanged -= cbDanhMuc_SelectedIndexChanged;
            cbDanhMuc.SelectedIndex = -1;
            cbDanhMuc.SelectedIndexChanged += cbDanhMuc_SelectedIndexChanged;

            GetSanPham();
            txtTimKiem.Focus();
        }
    }
}