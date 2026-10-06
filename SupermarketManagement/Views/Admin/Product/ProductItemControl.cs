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
        public ProductItemControl()
        {
            InitializeComponent();
        }

        public void SetData(string TenSP, string GiaSP,string SoLuong,string UrlImage)
        {
            lblTenSP.Text = TenSP;
            lblGiaSP.Text = GiaSP;
            lblSoLuong.Text = SoLuong;
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
    }
}
