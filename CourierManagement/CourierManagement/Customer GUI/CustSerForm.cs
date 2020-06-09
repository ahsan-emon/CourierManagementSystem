using CourierManagement.Entities;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CourierManagement
{
    public partial class CustSerForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        public CustSerForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            label22.BackColor = Color.Blue;
            label10.Text = dt.Rows[0].Field<string>("UserName");
        }

        private void CustSerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            LoginForm ad = new LoginForm();
            ad.Show();
            this.Hide();
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

        private void label23_Click(object sender, EventArgs e)
        {
            CustEditForm edit = new CustEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            label27.BackColor = Color.Blue;
        }

        private void label27_MouseLeave(object sender, EventArgs e)
        {
            label27.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            label26.BackColor = Color.Blue;
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

        private void set_grid()
        {
            DataTable dt2 = dataAccess.GetData<Product>($"where Product_State = '{4}'");
            dataGridView1.DataSource = dt2;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
        }

        private void CustSerForm_Load(object sender, EventArgs e)
        {
            set_grid();
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show($"This Product was Released on '{dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()}'");
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

        private void search()
        {
            if(comboBox1.SelectedIndex == 0)
            {
                string sql = $"select * FROM Product_Info WHERE RecieverName LIKE '%{textBox1.Text}%' and Product_State = '{4}'";
                DataTable dtw = dataAccess.Execute(sql);
                dataGridView1.DataSource = dtw;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                string sql = $"select * FROM Product_Info WHERE RecieverContact LIKE '%{textBox1.Text}%' and Product_State = '{4}'";
                DataTable dtw = dataAccess.Execute(sql);
                dataGridView1.DataSource = dtw;
            }
            //else if(comboBox1.SelectedIndex == 2)
            //{
            //    string sql = $"select * FROM Product_Info WHERE RecieverContact LIKE '%{textBox1.Text}%'";
            //    DataTable dtw = dataAccess.Execute(sql);
            //    dataGridView1.DataSource = dtw;
            //}
            //else if(comboBox1.SelectedIndex == 3)
            //{

            //}
        }

        private void label3_Click(object sender, EventArgs e)
        {
            search();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            search();
        }
    }
}
