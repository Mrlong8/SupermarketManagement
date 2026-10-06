using SupermarketManagement.Utils;
using SupermarketManagement.Views.Account;
using SupermarketManagement.Views.Admin.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagement.Views.Admin
{
    public partial class Frm_Admin : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm = null;

        public Frm_Admin()
        {
            InitializeComponent();
            random = new Random();
          
        }


        private void Frm_Admin_Load(object sender, EventArgs e)
        {

        }
        // lấy màu
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        // dán màu vào nút
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Times New Roman", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        // hủy màu 
        private void DisableButton()
        {
            foreach (Control previousBtn in pnlSideBar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        // hireent thị user control vào panel chính
        private void ShowControl(UserControl uc,object btnSender)
        {
            ActivateButton(btnSender);
            pnlMainAdmin.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainAdmin.Controls.Add(uc);
            uc.BringToFront();
        }

        // hiển thị form con vào panel chính
        private void ShowChildForm(Form childForm, object btnSender)
        {
            // Nếu đang có một form con đang mở, đóng nó lại để giải phóng bộ nhớ
            if (activeForm != null)
            {
                activeForm.Close();
            }

            // Đổi màu nút bấm được kích hoạt
            ActivateButton(btnSender);

            activeForm = childForm;

            // Các thuộc tính bắt buộc khi nhúng Form con vào Panel
            childForm.TopLevel = false;                             // Không coi là cửa sổ độc lập
            childForm.FormBorderStyle = FormBorderStyle.None;       // Bỏ thanh tiêu đề, viền cửa sổ
            childForm.Dock = DockStyle.Fill;                        // Co giãn lấp đầy Panel

            // Xóa control cũ và thêm Form con vào Panel
            pnlMainAdmin.Controls.Clear();
            pnlMainAdmin.Controls.Add(childForm);
            pnlMainAdmin.Tag = childForm;

            // Hiển thị Form con
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {

            IndexControl ucIndex = new IndexControl();
            ShowControl(ucIndex, sender);
        }

        private void pnlSideBar_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private void btnManagerProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowChildForm(new IndexProduct(), sender);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);

        }
    }
}
