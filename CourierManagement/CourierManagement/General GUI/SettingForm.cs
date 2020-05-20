using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourierManagement.General_GUI
{
    public partial class SettingForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        public SettingForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            EmpHomeForm home = new EmpHomeForm(dt);
            home.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.DarkSlateGray;
        }

        private void label15_MouseClick(object sender, MouseEventArgs e)
        {
            label23.BackColor = Color.DeepSkyBlue;
            label11.BackColor = Color.DeepSkyBlue;
            label17.BackColor = Color.DeepSkyBlue;
            label16.BackColor = Color.DeepSkyBlue;
            label18.BackColor = Color.DeepSkyBlue;
        }

        private void label9_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.Black;
        }

        private void label12_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.DarkCyan;
        }

        private void label13_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.Crimson;
        }

        private void label14_MouseClick(object sender, MouseEventArgs e)
        {
            label23.BackColor = Color.DimGray;
            label11.BackColor = Color.DimGray;
            label17.BackColor = Color.DimGray;
            label16.BackColor = Color.DimGray;
            label18.BackColor = Color.DimGray;
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            label23.BackColor = Color.FromArgb(0, 0, 64);
            label11.BackColor = Color.FromArgb(0, 0, 64);
            label17.BackColor = Color.FromArgb(0, 0, 64);
            label16.BackColor = Color.FromArgb(0, 0, 64);
            label18.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            label23.BackColor = Color.DarkGreen;
            label11.BackColor = Color.DarkGreen;
            label17.BackColor = Color.DarkGreen;
            label16.BackColor = Color.DarkGreen;
            label18.BackColor = Color.DarkGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
