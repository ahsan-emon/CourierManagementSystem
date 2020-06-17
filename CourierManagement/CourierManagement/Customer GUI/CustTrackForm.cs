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
    public partial class CustTrackForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        public CustTrackForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            lblTrackOrder.BackColor = Color.Blue;
            label10.Text = dt.Rows[0].Field<string>("UserName");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustTrackForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void lblSerHistory_Click(object sender, EventArgs e)
        {
            CustSerForm ser = new CustSerForm(dt);
            ser.Show();
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
        private void lblSerHistory_MouseEnter(object sender, EventArgs e)
        {
            lblSerHistory.BackColor = Color.Blue;
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

        private void lblSerHistory_MouseLeave(object sender, EventArgs e)
        {
            lblSerHistory.BackColor = Color.FromArgb(0, 0, 64);
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

        private void set_gridview()
        {
            DataTable dt2 = dataAccess.GetData<Product>($"where (Product_State = '{1}' or Product_State = '{0}') and Customer_id = '{dt.Rows[0].Field<int>("Id")}'");
            grdPendingPro.DataSource = dt2;

            dt2 = dataAccess.GetData<Product>($"where (Product_State = '{2}' or Product_State = '{3}') and Customer_id = '{dt.Rows[0].Field<int>("Id")}'");
            grdShippedPro.DataSource = dt2;

            grdPendingPro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdShippedPro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CustTrackForm_Load(object sender, EventArgs e)
        {
            set_gridview();
        }

        private void grdPendingPro_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (grdPendingPro.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("0"))
            {
                MessageBox.Show("Product Isn't Recived at the Source Branch yet!!!");
            }
            else
            {
                MessageBox.Show("Product Recieved by the Source Branch \nReady to Ship.");
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to Cancel The Product Shipping?", "Cancel Form", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Product Shipping Cancelled");
                DataTable dt2 = dataAccess.GetData<Product>($"where (Product_State = '{1}' or Product_State = '{0}') and Customer_id = '{dt.Rows[0].Field<int>("Id")}'");
                CustTrackForm ct = new CustTrackForm(dt);
                ct.Show();
                this.Hide();

            }
            else if (dialogResult == DialogResult.No)
            {
                DataTable dt2 = dataAccess.GetData<Product>($"where (Product_State = '{1}' or Product_State = '{0}') and Customer_id = '{dt.Rows[0].Field<int>("Id")}'");
                CustTrackForm ct = new CustTrackForm(dt);
                ct.Show();
                this.Hide();
            }
        }

        private void grdShippedPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdShippedPro.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("2"))
            {
                MessageBox.Show("Product Shipped \nNow it is on the way to the Destination Branch");
            }
            else
            {
                MessageBox.Show("Product Recieved by the Destination Branch \nReady to Release.");
            }
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
    }
}
