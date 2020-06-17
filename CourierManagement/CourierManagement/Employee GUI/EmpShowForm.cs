using CourierManagement.Employee_GUI;
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
using System.Windows.Forms.VisualStyles;

namespace CourierManagement
{
    public partial class EmpShowForm : Form
    {
        DataAccess dataAccess = new DataAccess();
        DataTable dt,dt2,dte;
        int check;
        public EmpShowForm(DataTable dt,DataTable dt2,int check)
        {
            InitializeComponent();
            this.dt = dt;
            this.dt2 = dt2;
            this.check = check;
            UserName.Text = dt.Rows[0].Field<string>("UserName");
            imin();
        }

        private void imin()
        {
            if(check !=5)
            {
                lblHome.BackColor = Color.Black;
            }
            else if(check == 5)
            {
                lblServiceHistory.BackColor = Color.Black;
            }
        }

        private void EmpViewCust_SerHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
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

        private void lblEditProfile_Click(object sender, EventArgs e)
        {
            EmpEditForm edit = new EmpEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void lblHome_MouseEnter(object sender, EventArgs e)
        {
            if (check == 5)
            {
                lblHome.BackColor = Color.Black;
            }
        }

        private void lblProfile_MouseEnter(object sender, EventArgs e)
        {
            lblProfile.BackColor = Color.Black;
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

        private void lblHome_MouseLeave(object sender, EventArgs e)
        {
            if (check == 5)
            {
                lblHome.BackColor = Color.DeepSkyBlue;
            }
        }

        private void lblProfile_MouseLeave(object sender, EventArgs e)
        {
            lblProfile.BackColor = Color.DeepSkyBlue;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DeepSkyBlue;
        }

        private void lblEditProfile_MouseLeave(object sender, EventArgs e)
        {
            lblEditProfile.BackColor = Color.DeepSkyBlue;
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.DeepSkyBlue;
        }

        private void set_gridview()
        {
            if(check == 1 || check == 5 || check == 4)
            {
                DataGridViewShow.DataSource = dt2;
                DataGridViewShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //dataGridView1.Columns[0].Visible = false;
            } 
            else if(check == 2)
            {
                dt2 = dataAccess.GetData<Product>($"where Product_State = '{1}' and Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
                DataGridViewShow.DataSource = dt2;
                DataGridViewShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //dataGridView1.Columns[0].Visible = false;
            }
            else if(check == 3)
            {
                dt2 = dataAccess.GetData<Product>($"where Product_State = '{3}' and Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
                DataGridViewShow.DataSource = dt2;
                DataGridViewShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //dataGridView1.Columns[0].Visible = false;
            }
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
                    Product_State = (int)Product.ProductStateEnum.Shipped,
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
                    Release_Date = DateTime.Now,
                    RecieverEmail = dtr.Rows[0].Field<string>("RecieverEmail"),
                    PaymentMethod = dtr.Rows[0].Field<int>("PaymentMethod"),
                    ProductCategory = dtr.Rows[0].Field<int>("ProductCategory"),
                    ProductType = dtr.Rows[0].Field<int>("ProductType"),
                    Product_State = (int)Product.ProductStateEnum.Released,
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

        private void lblServiceHistory_Click(object sender, EventArgs e)
        {
            string sql = $"select * from Product_Info where Sending_Manager_id = '{dt.Rows[0].Field<int>("Id")}' or Receiving_Manager_id = '{dt.Rows[0].Field<int>("Id")}'";
            DataTable dt2 = dataAccess.Execute(sql);

            EmpShowForm es = new EmpShowForm(dt, dt2, 5);
            es.Show();
            this.Hide();
        }

        private void search()
        {
            if (check == 2)
            {
                if (cmbPosition.SelectedIndex == 0)
                {
                    string sql = $"select p.* FROM Product_Info as p,Customers as c WHERE c.Name LIKE '%{txtSearchBy.Text}%' and p.Product_State = '{1}' and p.Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}' and c.User_id = p.Customer_id";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
                else if (cmbPosition.SelectedIndex == 1)
                {
                    string sql = $"select p.* FROM Product_Info as p,Customers as c WHERE c.Contact LIKE '%{txtSearchBy.Text}%' and p.Product_State = '{1}' and p.Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}' and c.User_id = p.Customer_id";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
                else if (cmbPosition.SelectedIndex == 2)
                {
                    string sql = $"select * FROM Product_Info WHERE RecieverName LIKE '%{txtSearchBy.Text}%' and Product_State = '{1}' and Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
                else if (cmbPosition.SelectedIndex == 3)
                {
                    string sql = $"select * FROM Product_Info WHERE RecieverContact LIKE '%{txtSearchBy.Text}%' and Product_State = '{1}' and Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
                else if (cmbPosition.SelectedIndex == 4)
                {
                    string sql = $"select * FROM Product_Info as p,Branch_Info as b WHERE Branch_Name LIKE '%{txtSearchBy.Text}%' and p.Product_State = '{1}' and p.Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}' b.Id = p.Sending_B_id";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }

            }
            else if(check == 3)
            {
                if (cmbPosition.SelectedIndex == 0)
                {
                    string sql = $"select * FROM Product_Info WHERE RecieverName LIKE '%{txtSearchBy.Text}%' and Product_State = '{3}' and Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
                else if (cmbPosition.SelectedIndex == 1)
                {
                    string sql = $"select * FROM Product_Info WHERE RecieverContact LIKE '%{txtSearchBy.Text}%' and Product_State = '{3}' and Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
                else if (cmbPosition.SelectedIndex == 2)
                {
                    string sql = $"select * FROM Product_Info as p,Branch_Info as b WHERE Branch_Name LIKE '%{txtSearchBy.Text}%' and p.Product_State = '{3}' and p.Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}' b.Id = p.Receiving_B_id";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
            }
            else if(check == 4)
            {
                if (cmbPosition.SelectedIndex == 0)
                {
                    string sql = $"select * FROM Customers WHERE Name LIKE '%{txtSearchBy.Text}%' and Is_verified = '{true}'";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
                else if (cmbPosition.SelectedIndex == 1)
                {
                    string sql = $"select * FROM Customers WHERE Address LIKE '%{txtSearchBy.Text}%' and Is_verified = '{true}'";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
                else if (cmbPosition.SelectedIndex == 2)
                {
                    string sql = $"select * FROM Customers WHERE Contact LIKE '%{txtSearchBy.Text}%' and Is_verified = '{true}'";
                    DataTable dtw = dataAccess.Execute(sql);
                    DataGridViewShow.DataSource = dtw;
                }
            }
        }

        private void txtSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            search();
        }

        private void set_combobox()
        {
            if(check == 1)
            {
                lblSearch.Visible = false;
                cmbPosition.Visible = false;
                //label15.Visible = false;
                txtSearchBy.Visible = false;
            }
            else if(check == 2)
            {
                cmbPosition.Items.Add("Sender Name");
                cmbPosition.Items.Add("Sender Contact");
                cmbPosition.Items.Add("Receiver Name");
                cmbPosition.Items.Add("Receiver Contact");
                cmbPosition.Items.Add("Destination Branch");
                cmbPosition.SelectedIndex = 0;
            }
            else if(check == 3)
            {
                cmbPosition.Items.Add("Receiver Name");
                cmbPosition.Items.Add("Receiver Contact");
                cmbPosition.Items.Add("Sending Branch");
                cmbPosition.SelectedIndex = 0;
            }
            else if(check == 4)
            {
                cmbPosition.Items.Add("Name");
                cmbPosition.Items.Add("Address");
                cmbPosition.Items.Add("Contact");
                cmbPosition.SelectedIndex = 0;
            }
            else if(check == 5)
            {
                lblSearch.Visible = false;
                cmbPosition.Visible = false;
                //label15.Visible = false;
                txtSearchBy.Visible = false;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            search();
        }

        private void lblServiceHistory_MouseEnter(object sender, EventArgs e)
        {
            if (check != 5)
            {
                lblServiceHistory.BackColor = Color.Black;
            }
        }

        private void lblServiceHistory_MouseLeave(object sender, EventArgs e)
        {
            if (check != 5)
            {
                lblServiceHistory.BackColor = Color.DeepSkyBlue;
            }
        }


        private void DataGridViewShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(check == 1)
            {
                int i = (int)DataGridViewShow.Rows[e.RowIndex].Cells[4].Value;
                EmpVerifyCust ec = new EmpVerifyCust(dt, i);
                ec.Show();
                this.Hide();
            }
            else if(check == 2)
            {
                DialogResult dialogResult = MessageBox.Show("Do you Want to Ship the product?", "Product receiving", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //MessageBox.Show();
                    DataTable dtr = dataAccess.GetData<Product>($"where Customer_id = '{dt2.Rows[e.RowIndex][3].ToString()}' and UpdatedDate = '{dt2.Rows[e.RowIndex][17].ToString()}'");
                    Product pi = fill_cust(dtr);
                    int rowsAffected = dataAccess.Insert<Product>(pi, true);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product Shipped Successfully ");
                        set_gridview();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong!!!");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Product did not shipped!!!");
                    
                }
            }
            else if(check == 3)
            {
                DialogResult dialogResult = MessageBox.Show("Do you Want to Release the product?", "Product receiving", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //MessageBox.Show();
                    DataTable dtr = dataAccess.GetData<Product>($"where Customer_id = '{dt2.Rows[e.RowIndex][3].ToString()}' and UpdatedDate = '{dt2.Rows[e.RowIndex][17].ToString()}'");
                    Product pi = fill_cust2(dtr);
                    int rowsAffected = dataAccess.Insert<Product>(pi, true);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product Released Successfully ");
                        set_gridview();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong!!!");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Product did not released!!!");

                }
            }
            else if(check == 4)
            {
                DialogResult dialogResult = MessageBox.Show("Do you Want to Delete the Customer Account?", "Account deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string id = DataGridViewShow.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int rowsAffected = dataAccess.Delete("Customers", "User_Id", id);
                    if (rowsAffected > 0)
                    {
                        rowsAffected = dataAccess.Delete("Users", "Id", id);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account Deleted Successfully");
                            set_gridview();
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
            else if(check == 5)
            {
                MessageBox.Show("Product Relased on :"+DataGridViewShow.Rows[e.RowIndex].Cells[17].Value.ToString());
            }
        }

        private void EmpShowForm_Load(object sender, EventArgs e)
        {
            dte = dataAccess.GetData<Employee>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
            set_gridview();
            set_combobox();
        }
    }
}
