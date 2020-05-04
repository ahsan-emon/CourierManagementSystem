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
    public partial class EmpHomeForm : Form
    {
        public EmpHomeForm()
        {
            InitializeComponent();
        }

        private void EmpHomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
