using CourierManagement.Entities;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CourierManagement.Employee_GUI
{
    public partial class EmpReceive : Form
    {
        DataTable dt,dt1,dt2,dte;
        DataAccess dataAccess = new DataAccess();
        public EmpReceive(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            lblHome.BackColor = Color.Black;
            UserName.Text = dt.Rows[0].Field<string>("UserName");
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            EmpHomeForm home = new EmpHomeForm(dt);
            home.Show();
            this.Hide();
        }

        private void lblProfile_Click(object sender, EventArgs e)
        {
            EmpProfile profile = new EmpProfile(dt);
            profile.Show();
            this.Hide();

        }

        private void EmpReceive_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblServiceHistory_Click(object sender, EventArgs e)
        {
            string sql = $"select * from Product_Info where Sending_Manager_id = '{dt.Rows[0].Field<int>("Id")}' or Receiving_Manager_id = '{dt.Rows[0].Field<int>("Id")}'";
            DataTable dt2 = dataAccess.Execute(sql);

            EmpShowForm es = new EmpShowForm(dt, dt2,5);
            es.Show();
            this.Hide();
        }

        private void lblEditProfile_Click(object sender, EventArgs e)
        {
            EmpEditForm edit = new EmpEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void lblProfile_MouseEnter(object sender, EventArgs e)
        {
            lblProfile.BackColor = Color.Black;
        }

        private void lblServiceHistory_MouseEnter(object sender, EventArgs e)
        {
            lblServiceHistory.BackColor = Color.Black;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Black;
        }

        private void lblEditProfile_MouseEnter(object sender, EventArgs e)
        {
            lblEditProfile.BackColor = Color.Black;
        }


        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.Black;
        }

        private void lblProfile_MouseLeave(object sender, EventArgs e)
        {
            lblProfile.BackColor = Color.DeepSkyBlue;
        }

        private void lblServiceHistory_MouseLeave(object sender, EventArgs e)
        {
            lblServiceHistory.BackColor = Color.DeepSkyBlue;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DeepSkyBlue;
        }

        private void lblEditProfile_MouseLeave(object sender, EventArgs e)
        {
            lblEditProfile.BackColor = Color.DeepSkyBlue;
        }

        private void set_gridview()
        {
            dt1 = dataAccess.GetData<Product>($"where Product_State = '{0}' and Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
            dt2 = dataAccess.GetData<Product>($"where Product_State = '{2}' and Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
            dgvReceiveFromCustomer.DataSource = dt1;
            dgvReceiveFromOtherBranch.DataSource = dt2;

            dgvReceiveFromCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceiveFromCustomer.Columns[0].Visible = false;

            dgvReceiveFromOtherBranch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceiveFromOtherBranch.Columns[0].Visible = false;
        }
        private void EmpReceive_Load(object sender, EventArgs e)
        {
            dte = dataAccess.GetData<Employee>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
            set_gridview();
        }

        private Product fill_cust(DataTable dtr)
        {
            
            if (dtr.Rows.Count > 0)
            {
                Product pi = new Product()
                {
                    Id = dtr.Rows[0].Field<int>("Id"),
                    UpdatedDate = dtr.Rows[0].Field<DateTime>("UpdatedDate"),
                    Customer_id = dtr.Rows[0].Field<int>("Customer_id"),
                    Delivery_charge = float.Parse(dtr.Rows[0][6].ToString()),
                    Description = dtr.Rows[0].Field<string>("Description"),
                    Release_Date = dtr.Rows[0].Field<DateTime>("Release_Date"),
                    RecieverEmail = dtr.Rows[0].Field<string>("RecieverEmail"),
                    PaymentMethod = dtr.Rows[0].Field<int>("PaymentMethod"),
                    ProductCategory = dtr.Rows[0].Field<int>("ProductCategory"),
                    ProductType = dtr.Rows[0].Field<int>("ProductType"),
                    Product_State = (int)Product.ProductStateEnum.Received,
                    Receiving_B_id = dtr.Rows[0].Field<int>("Receiving_B_id"),
                    Receiving_Manager_id = dtr.Rows[0].Field<int>("Receiving_Manager_id"),
                    RecieverAddress = dtr.Rows[0].Field<string>("RecieverAddress"),
                    RecieverContact = dtr.Rows[0].Field<string>("RecieverContact"),
                    RecieverName = dtr.Rows[0].Field<string>("RecieverName"),
                    Sending_B_id = dtr.Rows[0].Field<int>("Sending_B_id"),
                    Sending_Manager_id = dt.Rows[0].Field<int>("Id")
                };
                return pi;
            }
            return null;
        }

        private void dgvReceiveFromCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you Want to Receive the product?", "Product receiving", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //MessageBox.Show();
                DataTable dtr = dataAccess.GetData<Product>($"where Customer_id = '{dt1.Rows[e.RowIndex][3].ToString()}' and UpdatedDate = '{dt1.Rows[e.RowIndex][17].ToString()}'");
                Product pi = fill_cust(dtr);
                int rowsAffected = dataAccess.Insert<Product>(pi, true);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product Recieved Successfully");
                    set_gridview();
                }
                else
                {
                    MessageBox.Show("Something went wrong!!!");
                }
                
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Product Sent back to Customer");
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

        private Product fill_cust2(DataTable dtr)
        {
            if (dtr.Rows.Count > 0)
            {
                Product pi = new Product()
                {
                    Id = dtr.Rows[0].Field<int>("Id"),
                    UpdatedDate = dtr.Rows[0].Field<DateTime>("UpdatedDate"),
                    Customer_id = dtr.Rows[0].Field<int>("Customer_id"),
                    Delivery_charge = float.Parse(dtr.Rows[0][6].ToString()),
                    Description = dtr.Rows[0].Field<string>("Description"),
                    Release_Date = dtr.Rows[0].Field<DateTime>("Release_Date"),
                    RecieverEmail = dtr.Rows[0].Field<string>("RecieverEmail"),
                    PaymentMethod = dtr.Rows[0].Field<int>("PaymentMethod"),
                    ProductCategory = dtr.Rows[0].Field<int>("ProductCategory"),
                    ProductType = dtr.Rows[0].Field<int>("ProductType"),
                    Product_State = (int)Product.ProductStateEnum.Sent_to_destination,
                    Receiving_B_id = dtr.Rows[0].Field<int>("Receiving_B_id"),
                    Receiving_Manager_id = dt.Rows[0].Field<int>("Id"),
                    RecieverAddress = dtr.Rows[0].Field<string>("RecieverAddress"),
                    RecieverContact = dtr.Rows[0].Field<string>("RecieverContact"),
                    RecieverName = dtr.Rows[0].Field<string>("RecieverName"),
                    Sending_B_id = dtr.Rows[0].Field<int>("Sending_B_id"),
                    Sending_Manager_id = dtr.Rows[0].Field<int>("Sending_Manager_id")
                };
                return pi;
            }
            return null;
        }

        private void dgvReceiveFromOtherBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you Want to Receive the product?", "Product receiving", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //MessageBox.Show();
                DataTable dtr = dataAccess.GetData<Product>($"where Customer_id = '{dt2.Rows[e.RowIndex][3].ToString()}' and UpdatedDate = '{dt2.Rows[e.RowIndex][17].ToString()}'");
                Product pi = fill_cust2(dtr);
                int rowsAffected = dataAccess.Insert<Product>(pi, true);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product Recieved Successfully");
                    set_gridview();
                }
                else
                {
                    MessageBox.Show("Something went wrong!!!");
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Product Will remain on the Delivery van!!!");
            }
        }


        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.DeepSkyBlue;
        }
    }
}
