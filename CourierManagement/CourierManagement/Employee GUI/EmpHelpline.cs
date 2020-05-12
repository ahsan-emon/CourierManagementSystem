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
    public partial class EmpHelpline : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        public EmpHelpline(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void EmpHelpline_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
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

        private void label11_Click(object sender, EventArgs e)
        {
            EmpShowForm ser = new EmpShowForm(dt);
            ser.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            EmpEditForm edit = new EmpEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label14.BackColor = Color.Black;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.Black;
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            label11.BackColor = Color.Black;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Black;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Black;
        }

        private void label13_MouseEnter(object sender, EventArgs e)
        {
            label13.BackColor = Color.Black;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Black;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.DeepSkyBlue;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.DeepSkyBlue;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.BackColor = Color.DeepSkyBlue;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DeepSkyBlue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.DeepSkyBlue;
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.DeepSkyBlue;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DeepSkyBlue;
        }

        private void Problem_updated()
        {
            DataTable bid = dataAccess.GetData<Employee>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
            Employee_Problem ep = new Employee_Problem()
            {
                UpdatedDate = DateTime.Now,
                Problem = richTextBox1.Text,
                User_id = dt.Rows[0].Field<int>("Id"),
                Branch_id = bid.Rows[0].Field<int>("Branch_id")
            };
            int rowsAffected = dataAccess.Insert<Employee_Problem>(ep, true);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Complain Updated Sucessfully");
                EmpHomeForm home = new EmpHomeForm(dt);
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Something Went Wrong!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Trim().Length != 0)
            {
                Problem_updated();
            }
            else
            {
                MessageBox.Show("You haven't write any Complain");
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (richTextBox1.Text.Trim().Length != 0)
                {
                    Problem_updated();
                }
                else
                {
                    MessageBox.Show("You haven't write any Complain");
                }
                e.SuppressKeyPress = true;
            }
        }
    }
}
