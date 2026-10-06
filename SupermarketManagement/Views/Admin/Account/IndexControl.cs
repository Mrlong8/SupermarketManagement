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

namespace SupermarketManagement.Views.Account
{
    public partial class IndexControl : UserControl
    {
        DbConection _db = new DbConection();
        public IndexControl()
        {
            InitializeComponent();
        }

        private void IndexControl_Load(object sender, EventArgs e)
        {
            string str = "SELECT * FROM NhanVien";
            dgvListAccount.DataSource = _db.GetListData(str);
        }
    }
}
