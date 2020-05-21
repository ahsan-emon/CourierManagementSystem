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
            label4.BackColor = Color.Black;
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
            string sql = $"select * from Product_Info where Sending_Manager_id = '{dt.Rows[0].Field<int>("Id")}' or Receiving_Manager_id = '{dt.Rows[0].Field<int>("Id")}'";
            DataTable dt2 = dataAccess.Execute(sql);

            EmpShowForm es = new EmpShowForm(dt, dt2,5);
            es.Show();
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
            //label4.BackColor = Color.Black;
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


        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Black;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            //label4.BackColor = Color.DeepSkyBlue;
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

        private void set_gridview()
        {
            dt1 = dataAccess.GetData<Product_Info>($"where Product_State = '{0}' and Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
            dt2 = dataAccess.GetData<Product_Info>($"where Product_State = '{2}' and Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
            dataGridView1.DataSource = dt1;
            dataGridView2.DataSource = dt2;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Columns[0].Visible = false;
        }
        private void EmpReceive_Load(object sender, EventArgs e)
        {
            dte = dataAccess.GetData<Employee>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
            set_gridview();
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
                    Product_State = (int)Product_Info.ProductStateEnum.Received,
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
            DialogResult dialogResult = MessageBox.Show("Do you Want to Receive the product?", "Product receiving", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //MessageBox.Show();
                DataTable dtr = dataAccess.GetData<Product_Info>($"where Customer_id = '{dt1.Rows[e.RowIndex][3].ToString()}' and UpdatedDate = '{dt1.Rows[e.RowIndex][17].ToString()}'");
                Product_Info pi = fill_cust(dtr);
                int rowsAffected = dataAccess.Insert<Product_Info>(pi, true);
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

        private void label13_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    Product_State = (int)Product_Info.ProductStateEnum.Sent_to_destination,
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you Want to Receive the product?", "Product receiving", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //MessageBox.Show();
                DataTable dtr = dataAccess.GetData<Product_Info>($"where Customer_id = '{dt2.Rows[e.RowIndex][3].ToString()}' and UpdatedDate = '{dt2.Rows[e.RowIndex][17].ToString()}'");
                Product_Info pi = fill_cust2(dtr);
                int rowsAffected = dataAccess.Insert<Product_Info>(pi, true);
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
                MessageBox.Show("Product Will be on the Delivery van!!!");
            }
        }


        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DeepSkyBlue;
        }
    }
}
