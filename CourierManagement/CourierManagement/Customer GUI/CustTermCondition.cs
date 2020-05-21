using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourierManagement.Customer_GUI
{
    public partial class CustTermCondition : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        public CustTermCondition(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            label27.BackColor = Color.Blue;
        }

        private void CustTermCondition_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            CustHomeForm home = new CustHomeForm(dt);
            home.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            CustTrackForm track = new CustTrackForm(dt);
            track.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            CustSerForm ser = new CustSerForm(dt);
            ser.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            CustEditForm edit = new CustEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            label26.BackColor = Color.Blue;
        }

        private void label22_MouseEnter(object sender, EventArgs e)
        {
            label22.BackColor = Color.Blue;
        }

        private void label23_MouseEnter(object sender, EventArgs e)
        {
            label23.BackColor = Color.Blue;
        }

        private void label21_MouseEnter(object sender, EventArgs e)
        {
            label21.BackColor = Color.Blue;
        }

        private void label25_MouseEnter(object sender, EventArgs e)
        {
            label25.BackColor = Color.Blue;
        }

        private void label26_MouseLeave(object sender, EventArgs e)
        {
            label26.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label22_MouseLeave(object sender, EventArgs e)
        {
            label22.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label23_MouseLeave(object sender, EventArgs e)
        {
            label23.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label21_MouseLeave(object sender, EventArgs e)
        {
            label21.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label25_MouseLeave(object sender, EventArgs e)
        {
            label25.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label25_Click(object sender, EventArgs e)
        {
            LoginForm ad = new LoginForm();
            ad.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you Want to Delete the Customer Account?", "Account deleting", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string id = dt.Rows[0].Field<int>("Id").ToString();
                int rowsAffected = dataAccess.Delete("Customers", "User_Id", id);
                if (rowsAffected > 0)
                {
                    rowsAffected = dataAccess.Delete("Users", "Id", id);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account Deleted Successfully");
                        LoginForm lf = new LoginForm();
                        lf.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Something Went Wrong!!!");
                }
            }
        }
    }
}
