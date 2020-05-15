
using CourierManagement.Entities;
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
    public partial class AdminHomeForm : Form
    {
       
        DataAccess dataAccess = new DataAccess();
        public AdminHomeForm()
        {
            InitializeComponent();
            label4.BackColor = Color.Firebrick;
        }

        private void AdminHomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            WorkerList();
        }

        private void AdminHomeForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.Firebrick;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Firebrick;
        }

        private void label13_MouseEnter(object sender, EventArgs e)
        {
            label13.BackColor = Color.Firebrick;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Firebrick;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.DimGray;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DimGray;
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.BackColor = Color.DimGray;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DimGray;
        }

        private void label20_MouseEnter(object sender, EventArgs e)
        {
            label20.ForeColor = Color.White;
        }

        private void label18_MouseEnter(object sender, EventArgs e)
        {
            label18.ForeColor = Color.White;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            label18.ForeColor = Color.Black;
        }

        private void label20_MouseLeave(object sender, EventArgs e)
        {
            label20.ForeColor = Color.Black;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm ad = new LoginForm();
            ad.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm add = new AdminAddBranchForm();
            add.Show();
            this.Hide();
        }
        public void WorkerList()
        {
            DataTable dt = dataAccess.GetData<Employee>("");
            AdminShowForm add = new AdminShowForm(dt,1);
            add.Show();
            this.Hide();
        }
        public void AddWorker()
        {
            AdminAddWorkerForm add = new AdminAddWorkerForm();
            add.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            WorkerList();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            WorkerList();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            WorkerList();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            AddWorker();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            AddWorker();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DataTable dt = dataAccess.GetData<Branch_Info>("");
            AdminShowForm view = new AdminShowForm(dt,2);
            view.Show();
            this.Hide();
        }
    }
}
