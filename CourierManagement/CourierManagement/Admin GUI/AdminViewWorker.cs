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

namespace CourierManagement.Admin_GUI
{
    public partial class AdminViewWorker : Form
    {
        DataTable dt,dt2;
        DataAccess dataAccess = new DataAccess();

        public AdminViewWorker(DataTable dt,DataTable dt2)
        {
            InitializeComponent();
            label4.BackColor = Color.Firebrick;
            this.dt = dt;
            this.dt2 = dt2;
        }

        private void AdminViewWorker_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            AdminShowForm sh = new AdminShowForm(dt2,1);
            sh.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm add = new AdminAddBranchForm();
            add.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm();
            home.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            AdminShowForm sh = new AdminShowForm();
            sh.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
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

        private void set_value()
        {
            label12.Text = dt.Rows[0].Field<string>("Name");
            textBox4.Text = dt.Rows[0][3].ToString();
            comboBox1.SelectedItem = ((Employee.DesignationEnum)dt.Rows[0].Field<int>("Designation")).ToString();
            DataTable dt2 = dataAccess.GetData<Branch_Info>("");
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "Branch_Name";
            comboBox2.ValueMember = "Id";
            comboBox2.SelectedIndex = dt.Rows[0].Field<int>("Branch_id")-1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void AdminViewWorker_Load(object sender, EventArgs e)
        {
            set_value();
        }
    }
}
