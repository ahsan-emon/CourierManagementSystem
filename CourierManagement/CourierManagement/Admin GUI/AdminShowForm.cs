
using CourierManagement.Admin_GUI;
using CourierManagement.Employee_GUI;
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
    public partial class AdminShowForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        int i;
        public AdminShowForm()
        {
            InitializeComponent();
            

        }

        public AdminShowForm(DataTable dt,int i)
        {
            InitializeComponent();
            this.dt = dt;
            this.i = i;
            label13.BackColor = Color.Firebrick;

        }

        private void AdminWorkerList_solForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Firebrick;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.Firebrick;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Firebrick;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Firebrick;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.DimGray;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.DimGray;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DimGray;
        }
        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DimGray;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm();
            home.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm branch = new AdminAddBranchForm();
            branch.Show();
            this.Hide();
        }

        private void set_gridview()
        {
            dataGridView1.DataSource = dt;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.Columns[0].Visible = false;
        }

        private void AdminShowForm_Load(object sender, EventArgs e)
        {
            set_gridview();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = (int)dataGridView1.Rows[e.RowIndex].Cells[11].Value;
            
            DataTable dt2 = dataAccess.GetData<Employee>($"where User_id = '{i}'");
            AdminViewWorker ec = new AdminViewWorker(dt2,dt);
            ec.Show();
            this.Hide();
        }
    }
}
