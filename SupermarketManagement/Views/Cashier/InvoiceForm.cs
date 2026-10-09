using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Cashier
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }

        public void HienThiHoaDon(
            string maHD,
            string maKH,
            string tenKH,
            string tenNhanVien,
            DateTime ngayMua,
            DataGridView bangSanPham,
            string tongTien)
        {
            txtMaHD.Text = maHD;
            txtMaKH.Text = maKH;
            txtKhachHang.Text = tenKH;
            txtNhanVien.Text = tenNhanVien;
            dtpNgayMua.Value = ngayMua;
            txtTongTien.Text = tongTien;

            dgvInvoiceDetails.Rows.Clear();

            int stt = 1;

            foreach (DataGridViewRow row in bangSanPham.Rows)
            {
                if (row.IsNewRow)
                    continue;

                dgvInvoiceDetails.Rows.Add(
                    stt++,
                    row.Cells["colMaSP"].Value,
                    row.Cells["colTenSP"].Value,
                    row.Cells["colSoLuong"].Value,
                    row.Cells["colDonGia"].Value,
                    row.Cells["colThanhTien"].Value
                );
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
