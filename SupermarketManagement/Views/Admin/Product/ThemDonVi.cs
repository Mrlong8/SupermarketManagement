using SupermarketManagement.Models.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin.Product
{
    public partial class ThemDonVi : Form
    {
        private DonViRepository _repo = new DonViRepository();

        public ThemDonVi()
        {
            InitializeComponent();
        }

        private void ThemDonVi_Load(object sender, EventArgs e)
        {
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtMaDV.ReadOnly = true;     // mã tự sinh, không cho nhập tay
            LoadData();
            txtMaDV.Text = _repo.TaoMaTuDong();
            txtTenDV.Focus();
        }

        private void LoadData()
        {
            dgvData.DataSource = _repo.GetAll();

            if (dgvData.Columns.Contains("MaDVT")) dgvData.Columns["MaDVT"].HeaderText = "Mã đơn vị";
            if (dgvData.Columns.Contains("TenDV")) dgvData.Columns["TenDV"].HeaderText = "Tên đơn vị";
            if (dgvData.Columns.Contains("GhiChu")) dgvData.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDV.Text.Trim();
            string tenDV = txtTenDV.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();

            if (maDV == "")
            {
                MessageBox.Show("Vui lòng nhập mã đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDV.Focus();
                return;
            }
            if (tenDV == "")
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDV.Focus();
                return;
            }

            try
            {
                if (_repo.TonTai(maDV))
                {
                    MessageBox.Show($"Mã đơn vị '{maDV}' đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDV.Focus();
                    return;
                }

                _repo.Them(maDV, tenDV, ghiChu);

                MessageBox.Show("Thêm đơn vị tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenDV.Clear();
                txtGhiChu.Clear();
                LoadData();
                txtMaDV.Text = _repo.TaoMaTuDong();   
                txtTenDV.Focus();

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}