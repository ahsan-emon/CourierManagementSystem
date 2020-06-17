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
            lblSerHistory.BackColor = Color.Blue;
            label10.Text = dt.Rows[0].Field<string>("UserName");
        }

        private void CustSerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            LoginForm ad = new LoginForm();
            ad.Show();
            this.Hide();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            CustHomeForm home = new CustHomeForm(dt);
            home.Show();
            this.Hide();
        }

        private void lblTrackOrder_Click(object sender, EventArgs e)
        {
            CustTrackForm track = new CustTrackForm(dt);
            track.Show();
            this.Hide();
        }

        private void lblEditProfile_Click(object sender, EventArgs e)
        {
            CustEditForm edit = new CustEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void lblHome_MouseEnter(object sender, EventArgs e)
        {
            lblHome.BackColor = Color.Blue;
        }

        private void lblHome_MouseLeave(object sender, EventArgs e)
        {
            lblHome.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblTrackOrder_MouseEnter(object sender, EventArgs e)
        {
            lblTrackOrder.BackColor = Color.Blue;
        }

        private void lblEditProfile_MouseEnter(object sender, EventArgs e)
        {
            lblEditProfile.BackColor = Color.Blue;
        }

        private void lblDeleteAcc_MouseEnter(object sender, EventArgs e)
        {
            lblDeleteAcc.BackColor = Color.Blue;
        }

        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.Blue;
        }

        private void lblTrackOrder_MouseLeave(object sender, EventArgs e)
        {
            lblTrackOrder.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblEditProfile_MouseLeave(object sender, EventArgs e)
        {
            lblEditProfile.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblDeleteAcc_MouseLeave(object sender, EventArgs e)
        {
            lblDeleteAcc.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void set_grid()
        {
            DataTable dt2 = dataAccess.GetData<Product>($"where Product_State = '{4}'");
            grdShowData.DataSource = dt2;
            grdShowData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdShowData.Columns[0].Visible = false;
        }

        private void CustSerForm_Load(object sender, EventArgs e)
        {
            set_grid();
            cmbSearch.SelectedIndex = 0;
        }

        private void grdShowData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show($"This Product was Released on '{grdShowData.Rows[e.RowIndex].Cells[1].Value.ToString()}'");
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDeleteAcc_Click(object sender, EventArgs e)
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
            if(cmbSearch.SelectedIndex == 0)
            {
                string sql = $"select * FROM Product_Info WHERE RecieverName LIKE '%{txtSearch.Text}%' and Product_State = '{4}'";
                DataTable dtw = dataAccess.Execute(sql);
                grdShowData.DataSource = dtw;
            }
            else if(cmbSearch.SelectedIndex == 1)
            {
                string sql = $"select * FROM Product_Info WHERE RecieverContact LIKE '%{txtSearch.Text}%' and Product_State = '{4}'";
                DataTable dtw = dataAccess.Execute(sql);
                grdShowData.DataSource = dtw;
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            search();
        }
    }
}
