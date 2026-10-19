using SupermarketManagement.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.Product
{
    public partial class ProductItemControl : UserControl
    {
        private string _maSP;
        public ProductItemControl()
        {
            InitializeComponent();
        }

        public void SetData(string maSP, string TenSP, string GiaNhap, string GiaBan, string SoLuong, string UrlImage)
        {
            _maSP = maSP;
            lblTenSP.Text = TenSP;
            lblGiaNhap.Text = "Giá Nhập: " + GiaNhap;
            lblGiaBan.Text = "Giá Bán: " + GiaBan;
            lblSoLuong.Text = "Số Lượng: " + SoLuong;
            if (!string.IsNullOrEmpty(UrlImage))
            {
                // Chuyển / thành \ để phù hợp với đường dẫn Windows
                string cleanPath = UrlImage.Replace("/", "\\").TrimStart('\\');

                // Kết hợp với thư mục đang chạy ứng dụng (bin\Debug)
                string fullPath = System.IO.Path.Combine(Application.StartupPath, cleanPath);

                if (System.IO.File.Exists(fullPath))
                {
                    using (var fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        pctbImageItem.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    pctbImageItem.Image = null; // Hoặc gán ảnh mặc định nếu không thấy file
                }
            }
        }

        private void btnXoaItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Bạn chắc chắn muốn xóa sản phẩm {lblTenSP.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SanPhamRepositoryV2 repo = new SanPhamRepositoryV2();
                    repo.Delete(_maSP); 

                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    IndexProduct.Instance.GetSanPham();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaItem_Click(object sender, EventArgs e)
        {
            EditProduct frm = new EditProduct(_maSP);
            frm.ShowDialog();
        }
    }
}
