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
            label11.BackColor = Color.Black;
        }

        private void EmpViewCust_SerHistory_FormClosed(object sender, FormClosedEventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            EmpEditForm edit = new EmpEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Black;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.Black;
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
            label13.BackColor = Color.DeepSkyBlue;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DeepSkyBlue;
        }

        private void set_gridview()
        {
            if(check == 1)
            {
                dataGridView1.DataSource = dt2;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
            } 
            else if(check == 2)
            {
                dt2 = dataAccess.GetData<Product_Info>($"where Product_State = '{1}' and Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
                dataGridView1.DataSource = dt2;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
            }
            else if(check == 3)
            {
                dt2 = dataAccess.GetData<Product_Info>($"where Product_State = '{3}' and Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
                dataGridView1.DataSource = dt2;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
            }
            else if(check == 4)
            {
                dataGridView1.DataSource = dt2;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private Product_Info fill_cust(DataTable dtr)
        {

            if (dtr.Rows.Count > 0)
            {
                Product_Info pi = new Product_Info()
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
                    Product_State = (int)Product_Info.ProductStateEnum.Shipped,
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

        private Product_Info fill_cust2(DataTable dtr)
        {

            if (dtr.Rows.Count > 0)
            {
                Product_Info pi = new Product_Info()
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
                    Product_State = (int)Product_Info.ProductStateEnum.Released,
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(check == 1)
            {
                int i = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
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
                    DataTable dtr = dataAccess.GetData<Product_Info>($"where Customer_id = '{dt2.Rows[e.RowIndex][3].ToString()}' and UpdatedDate = '{dt2.Rows[e.RowIndex][17].ToString()}'");
                    Product_Info pi = fill_cust(dtr);
                    int rowsAffected = dataAccess.Insert<Product_Info>(pi, true);
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
                    DataTable dtr = dataAccess.GetData<Product_Info>($"where Customer_id = '{dt2.Rows[e.RowIndex][3].ToString()}' and UpdatedDate = '{dt2.Rows[e.RowIndex][17].ToString()}'");
                    Product_Info pi = fill_cust2(dtr);
                    int rowsAffected = dataAccess.Insert<Product_Info>(pi, true);
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
                    int rowsAffected = 1;
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account deleted Successfully");
                        set_gridview();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong!!!");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void EmpShowForm_Load(object sender, EventArgs e)
        {
            dte = dataAccess.GetData<Employee>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
            set_gridview();
            
        }
    }
}
