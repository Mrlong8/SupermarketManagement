using SupermarketManagement.Controllers.Repositories;
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
    public partial class IndexProduct : Form
    {
        DbConection _db = new DbConection();
        public IndexProduct()
        {
            InitializeComponent();
        }

      

        private void IndexProduct_Load(object sender, EventArgs e)
        {
            flpListProduct.Controls.Clear();
            string sql = "SELECT * FROM SanPham";
            DataTable products = _db.GetListData(sql);

            foreach (DataRow item in products.Rows)
            {
                ProductItemControl control = new ProductItemControl();
                string tenSP = item["TenSanPham"].ToString();
                string giaSP = item["DonGiaBan"].ToString();
                string soLuong = item["SoLuong"].ToString();
                string urlImage = item["UrlImage"].ToString();
                control.SetData(tenSP, giaSP, soLuong, urlImage);
                flpListProduct.Controls.Add(control);
            }

        }
    }
}
