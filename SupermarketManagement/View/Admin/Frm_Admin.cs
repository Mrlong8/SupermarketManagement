using SupermarketManagement.Utils;
using SupermarketManagement.View.Account;
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

namespace SupermarketManagement.View.Admin
{
    public partial class Frm_Admin : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;

        public Frm_Admin()
        {
            InitializeComponent();
            random = new Random();
            //pnlTitleBar.MouseDown += pnlTitleBar_MouseDown;
        }


        private void Frm_Admin_Load(object sender, EventArgs e)
        {

        }

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


        private void ShowAccountControl(UserControl uc)
        {
            pnlMainAdmin.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainAdmin.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            IndexControl ucIndex = new IndexControl();
            ShowAccountControl(ucIndex);
        }

        private void pnlSideBar_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnManagerProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);

        }
    }
}
