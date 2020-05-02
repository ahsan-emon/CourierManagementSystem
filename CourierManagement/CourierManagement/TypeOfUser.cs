using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourierManagement
{
    public partial class TypeOfUser : Form
    {
        public TypeOfUser()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            AdminLoginForm a = new AdminLoginForm();
            a.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            EmpLoginForm r = new EmpLoginForm();
            r.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CustLoginForm c = new CustLoginForm();
            c.ShowDialog();
        }
    }
}
