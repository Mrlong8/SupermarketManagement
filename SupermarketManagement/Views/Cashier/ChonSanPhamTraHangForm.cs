using SupermarketManagement.Models.Repositories;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SupermarketManagement.Views.Cashier
{
    // Form chọn sản phẩm, mở bằng ShowDialog() từ TraHangForm
    internal partial class ChonSanPhamTraHangForm : Form
    {
        // TraHangForm đọc thuộc tính này sau khi form đóng để biết người dùng chọn dòng nào
        public DataRow SanPham { get; private set; }

        private readonly TraHangRepository repository;

        public ChonSanPhamTraHangForm(TraHangRepository repository)
        {
            InitializeComponent();       // dựng control do Designer sinh ra
            this.repository = repository; // lưu repository để nạp dữ liệu
        }

        // Form mở lên thì nạp danh sách sản phẩm
        private void ChonSanPhamTraHangForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable data = repository.LayDanhSachSanPhamDeChon();
                grid.DataSource = data;   // đổ dữ liệu vào lưới
                if (data.Rows.Count == 0)
                    MessageBox.Show("Không có sản phẩm đang hoạt động để chọn.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách sản phẩm: " + ex.Message, "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            ChonDongDangChon();
        }

        // Nhấp đúp vào một dòng cũng được tính là chọn (RowIndex >= 0 để bỏ qua dòng tiêu đề)
        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ChonDongDangChon();
        }

        private void ChonDongDangChon()
        {
            // "is DataRowView rowView" vừa kiểm tra kiểu vừa gán biến nếu đúng kiểu
            if (grid.CurrentRow == null || !(grid.CurrentRow.DataBoundItem is DataRowView rowView))
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SanPham = rowView.Row;               // lưu dòng được chọn để form cha lấy
            DialogResult = DialogResult.OK;      // báo cho ShowDialog() biết là đã chọn
            Close();
        }

        // Canh nút Chọn/Hủy sát lề phải mỗi khi panel đổi kích thước
        private void pnlNut_Resize(object sender, EventArgs e)
        {
            btnHuy.Left = pnlNut.ClientSize.Width - btnHuy.Width - 12;
            btnChon.Left = btnHuy.Left - btnChon.Width - 10;
        }
    }
}