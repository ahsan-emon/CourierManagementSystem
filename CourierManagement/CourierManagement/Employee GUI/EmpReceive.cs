using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourierManagement.Employee_GUI
{
    public partial class EmpReceive : Form
    {
        DataTable dt;

        public EmpReceive(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            EmpHomeForm home = new EmpHomeForm(dt);
            home.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            EmpProfile profile = new EmpProfile(dt);
            profile.Show();
            this.Hide();

        }

        private void EmpReceive_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            EmpShowForm show = new EmpShowForm(dt);
            show.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            EmpEditForm edit = new EmpEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            label11.ForeColor = Color.White;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.ForeColor = Color.White;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label13_MouseEnter(object sender, EventArgs e)
        {
            label13.ForeColor = Color.White;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Black;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Black;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.ForeColor = Color.Black;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
        }
    }
}
