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

        // Khởi tạo Form và gán Instance dùng chung
        public IndexProduct()
        {
            InitializeComponent();
            Instance = this;
        }

        // Khởi tạo danh mục, nạp danh sách sản phẩm và gắn sự kiện tự động tìm kiếm
        private void IndexProduct_Load(object sender, EventArgs e)
        {
            GetDanhMuc();
            GetSanPham();

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        // Vẽ danh sách Card sản phẩm lên FlowLayoutPanel
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
                    string tenDV = item["TenDV"]?.ToString();

                    control.SetData(maSP, tenSP, giaNhap, giaBan, soLuong, urlImage, tenDV);
                    flpListProduct.Controls.Add(control);
                }
            }

            flpListProduct.ResumeLayout();
        }

        // Lấy toàn bộ danh sách sản phẩm từ cơ sở dữ liệu và hiển thị lên giao diện
        public void GetSanPham()
        {
            DataTable products = _repo.GetListSanPham();
            RenderProductList(products);
        }

        // Nạp dữ liệu danh mục sản phẩm vào ComboBox
        private void GetDanhMuc()
        {
            DataTable dt = _repo.GetDanhMuc();

            cbDanhMuc.DataSource = dt;
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDM";
            cbDanhMuc.SelectedIndex = -1;
        }

        // Tự động lọc danh sách sản phẩm ngay khi nhập từ khóa vào ô tìm kiếm
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                GetSanPham();
                return;
            }

            cbDanhMuc.SelectedIndexChanged -= cbDanhMuc_SelectedIndexChanged;
            cbDanhMuc.SelectedIndex = -1;
            cbDanhMuc.SelectedIndexChanged += cbDanhMuc_SelectedIndexChanged;

            DataTable dtResult = _repo.TimKiemSanPhamTheoTen(keyword);
            RenderProductList(dtResult);
        }

        // Thực hiện tìm kiếm sản phẩm khi nhấn nút Tìm kiếm
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

            cbDanhMuc.SelectedIndex = -1;

            DataTable dtResult = _repo.TimKiemSanPhamTheoTen(keyword);
            RenderProductList(dtResult);

            if (dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Xử lý sự kiện nhấn phím Enter trong ô tìm kiếm
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        // Lọc danh sách sản phẩm theo danh mục được chọn từ ComboBox
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

        // Đưa ô tìm kiếm và danh mục về trạng thái mặc định
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