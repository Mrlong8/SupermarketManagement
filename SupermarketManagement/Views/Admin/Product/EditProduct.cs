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
using System.IO;
namespace SupermarketManagement.Views.Admin.Product
{
    public partial class EditProduct : Form
    {
        private string _maSP;
        private SanPhamRepositoryV2 _repo = new SanPhamRepositoryV2();
        private string _urlImage;

        public EditProduct(string maSP)
        {
            InitializeComponent();
            _maSP = maSP;
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Giá nhập/giá bán là của đơn vị cơ bản; có thể NULL nếu sản phẩm chưa có đơn vị tính
        private string LayGia(object value)
        {
            if (value == null || value == DBNull.Value) return "0";
            return Convert.ToDecimal(value).ToString("0.##");
        }

        public void LoadData()
        {
            cbDanhMuc.DataSource = _repo.GetDanhMuc();
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDM";

            DataTable dt = _repo.GetSanPhamById(_maSP);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            DataRow row = dt.Rows[0];

            txtTenSP.Text = row["TenSanPham"].ToString();
            txtDonGiaNhap.Text = LayGia(row["DonGiaNhap"]);   // giá nhập của đơn vị cơ bản
            txtDonGiaBan.Text = LayGia(row["DonGiaBan"]);     // giá bán của đơn vị cơ bản
            txtSoLuong.Text = row["SoLuong"].ToString();      // SoLuongTong (tính theo đơn vị nhỏ nhất)
            cbDanhMuc.SelectedValue = row["MaDM"].ToString();
            txtMaSP.Text = row["MaSP"].ToString();
            txtGhiChu.Text = row["MoTa"].ToString();

            _urlImage = row["UrlImage"]?.ToString();
            HienThiAnh();

        }

        private void HienThiAnh()
        {

            if (!string.IsNullOrEmpty(_urlImage))
            {
                _urlImage = _urlImage.TrimStart('/', '\\');
                string fullPath = Path.Combine(Application.StartupPath, _urlImage);
                if (File.Exists(fullPath))
                {
                    picImage.ImageLocation = fullPath;

                }
                else
                {
                    picImage.Image = null;
                }
            }
            else
            {
                picImage.Image = null;
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ giao diện
                string maSP = txtMaSP.Text.Trim();
                string tenSP = txtTenSP.Text.Trim();
                string maDM = cbDanhMuc.SelectedValue?.ToString() ?? "";
                string moTa = txtGhiChu.Text.Trim();

                // 2. Kiểm tra dữ liệu
                if (string.IsNullOrWhiteSpace(tenSP))
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                    txtTenSP.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(maDM))
                {
                    MessageBox.Show("Vui lòng chọn danh mục!");
                    cbDanhMuc.Focus();
                    return;
                }

                if (!decimal.TryParse(txtDonGiaNhap.Text, out decimal giaNhap) ||
                    !decimal.TryParse(txtDonGiaBan.Text, out decimal giaBan) ||
                    !int.TryParse(txtSoLuong.Text, out int soLuong))
                {
                    MessageBox.Show("Giá nhập, giá bán hoặc số lượng không hợp lệ!");
                    return;
                }

                if (giaNhap < 0 || giaBan < 0 || soLuong < 0)
                {
                    MessageBox.Show("Giá và số lượng không được âm!");
                    return;
                }

                // 3. Cập nhật thông tin sản phẩm
                // (giá được ghi vào đơn vị cơ bản trong SanPham_DonViTinh, số lượng ghi vào SoLuongTong)
                _repo.Update(
                    maSP,
                    tenSP,
                    giaNhap,
                    giaBan,
                    soLuong,
                    maDM,
                    moTa
                );

                // 4. Thông báo và đóng form
                MessageBox.Show(
                    "Cập nhật sản phẩm thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                IndexProduct.Instance.GetSanPham();


            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi cập nhật sản phẩm: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnThayAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "File ảnh |*.jpg;*.jpeg;*.png";
            openFile.Title = "Chọn ảnh đại diện";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string targetFoder = Path.Combine(Application.StartupPath, "Resources", "Product");
                    if (!Directory.Exists(targetFoder))
                    {
                        Directory.CreateDirectory(targetFoder);
                    }

                    string fileName = txtMaSP.Text + "_" + Path.GetFileName(openFile.FileName);
                    string fullPath = Path.Combine(targetFoder, fileName);

                    string oldFullPath = "";
                    DataTable dt = _repo.GetSanPhamById(txtMaSP.Text);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string oldRelativePath = dt.Rows[0]["UrlImage"]?.ToString();
                        if (!string.IsNullOrEmpty(oldRelativePath))
                        {
                            oldFullPath = Path.Combine(Application.StartupPath, oldRelativePath);

                        }
                    }

                    // dùng để copy ảng vào thư mục lưu trữ
                    File.Copy(openFile.FileName, fullPath, true);
                    // hiểm thị ảnh
                    picImage.ImageLocation = fullPath;

                    // luwu leen csdl
                    string relativePath = Path.Combine("Resources", "Product", fileName);

                    _repo.UpdateImage(txtMaSP.Text, relativePath);

                    if (!string.IsNullOrEmpty(oldFullPath) && File.Exists(oldFullPath) && oldFullPath.ToLower() != fullPath.ToLower())
                    {
                        File.Delete(oldFullPath);
                    }
                    MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chọn ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
            IndexProduct.Instance.GetSanPham();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}