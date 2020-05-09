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
    public partial class EmpTerms_Condition : Form
    {
        public EmpTerms_Condition()
        {
            InitializeComponent();
        }

        private void EmpTerms_Condition_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
