using CourierManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourierManagement.Admin_GUI
{
    public partial class AdminViewBranch : Form
    {
        DataAccess dataAccess = new DataAccess();
        public AdminViewBranch()
        {
            InitializeComponent();
        }

        private void AdminViewBranch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm();
            home.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm add = new AdminAddBranchForm();
            add.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            AdminViewBranch view = new AdminViewBranch();
            view.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void AdminViewBranch_Load(object sender, EventArgs e)
        {
            DataTable dt = dataAccess.GetData<Branch_Info>("");
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
