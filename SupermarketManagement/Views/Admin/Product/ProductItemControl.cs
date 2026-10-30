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

        // Gán dữ liệu sản phẩm và hiển thị thông tin lô hạn sử dụng
        public void SetData(string maSP, string TenSP, string GiaNhap, string GiaBan, string SoLuong, string UrlImage, string TenDV = "", string ngaySanXuat = "", string ngayHetHan = "")
        {
            _maSP = maSP;
            lblTenSP.Text = TenSP;
            lblGiaNhap.Text = "Giá Nhập: " + GiaNhap;
            lblGiaBan.Text = "Giá Bán: " + GiaBan;
            lblSoLuong.Text = "Số Lượng: " + SoLuong + (string.IsNullOrEmpty(TenDV) ? "" : " " + TenDV);

            if (DateTime.TryParse(ngaySanXuat, out DateTime nsx))
                lblNSX.Text = "NSX: " + nsx.ToString("dd/MM/yyyy");
            else
                lblNSX.Text = "NSX: " + (string.IsNullOrEmpty(ngaySanXuat) ? "N/A" : ngaySanXuat);

            if (DateTime.TryParse(ngayHetHan, out DateTime nhh))
                lblNHH.Text = "NHH: " + nhh.ToString("dd/MM/yyyy");
            else
                lblNHH.Text = "NHH: " + (string.IsNullOrEmpty(ngayHetHan) ? "N/A" : ngayHetHan);

            if (!string.IsNullOrEmpty(UrlImage))
            {
                string cleanPath = UrlImage.Replace("/", "\\").TrimStart('\\');
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
                    pctbImageItem.Image = null;
                }
            }
        }

        // Xử lý sự kiện khi nhấn nút xóa sản phẩm
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

        // Mở Form chỉnh sửa thông tin sản phẩm
        private void btnSuaItem_Click(object sender, EventArgs e)
        {
            EditProduct frm = new EditProduct(_maSP);
            frm.ShowDialog();
        }
    }
}