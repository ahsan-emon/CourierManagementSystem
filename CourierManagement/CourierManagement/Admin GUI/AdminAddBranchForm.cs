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
    public partial class AdminAddBranchForm : Form
    {
        DataAccess dataAcess = new DataAccess();
        public AdminAddBranchForm()
        {
            InitializeComponent();
            label5.BackColor = Color.Firebrick;
        }

        private void AdminAddBranchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm log = new LoginForm();
            log.Show();
            this.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Firebrick;
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

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.DimGray;
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

        private void label4_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm();
            home.Show();
            this.Hide();
        }

        private void add_branch()
        {
            Branch_Info branch = new Branch_Info()
            {
                Branch_Name = textBox1.Text,
                Address = textBox2.Text,
                UpdatedDate = DateTime.Now
            };
            int rowsAffected = dataAcess.Insert<Branch_Info>(branch, true);

            if (rowsAffected > 0)
            {
                MessageBox.Show("New Branch Added Successfully");
                AdminHomeForm af = new AdminHomeForm();
                af.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_branch();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_branch();
                e.SuppressKeyPress = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DataTable dt = dataAcess.GetData<Branch_Info>("");
            AdminShowForm view = new AdminShowForm(dt,3);
            view.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
