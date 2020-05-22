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

namespace CourierManagement.Employee_GUI
{
    public partial class EmpVerifyCust : Form
    {
        DataAccess dataAccess = new DataAccess();
        DataTable dt;
        int id;
        public EmpVerifyCust(DataTable dt,int id)
        {    
            InitializeComponent();
            this.dt = dt;
            this.id = id;
            //this.check = check;
            label4.BackColor = Color.Black;
            label10.Text = dt.Rows[0].Field<string>("UserName");
        }

        private void EmpVerifyCust_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
                DataTable dt2 = dataAccess.GetData<Customers>($"where Is_verified = '{false}'");
                EmpShowForm sh = new EmpShowForm(dt, dt2,1);
                sh.Show();
                this.Hide();  
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

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DeepSkyBlue;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            string sql = $"select * from Product_Info where Sending_Manager_id = '{dt.Rows[0].Field<int>("Id")}' or Receiving_Manager_id = '{dt.Rows[0].Field<int>("Id")}'";
            DataTable dt2 = dataAccess.Execute(sql);
            EmpShowForm sh = new EmpShowForm(dt,dt2,5);
            sh.Show();
            this.Hide();
        }

        private void EmpVerifyCust_Load(object sender, EventArgs e)
        {
            string sql = $"select c.Name,u.UserName,u.Password,c.Contact,u.EmailAddress,c.Address,c.Sequrity_Que from Users as u,Customers as c where u.Id = c.User_id and u.Id = '{id}'";
            DataTable dt2 = dataAccess.Execute(sql);

            label27.Text = dt2.Rows[0][0].ToString();
            label26.Text = dt2.Rows[0][1].ToString();
            label23.Text = dt2.Rows[0][2].ToString();
            label25.Text = dt2.Rows[0][3].ToString();
            label24.Text = dt2.Rows[0][4].ToString();
            label22.Text = dt2.Rows[0][5].ToString();
            label21.Text = dt2.Rows[0][6].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowsAffected = dataAccess.Delete("Customers", "User_Id", id.ToString());
            if (rowsAffected > 0)
            {
                rowsAffected = dataAccess.Delete("Users", "Id", id.ToString());
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Account Deleted Successfully");
                    DataTable dt2 = dataAccess.GetData<Customers>($"where Is_verified = '{false}'");
                    EmpShowForm es = new EmpShowForm(dt, dt2, 1);
                    es.Show();
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


        private Customers fill()
        {
            DataTable dt2 = dataAccess.GetData<Customers>($"where User_id='{id}'");
            Customers cs = new Customers()
            {
                User_Id = dt2.Rows[0].Field<int>("User_Id"),
                Name = dt2.Rows[0].Field<string>("Name"),
                Id = dt2.Rows[0].Field<int>("Id"),
                Address = dt2.Rows[0].Field<string>("Address"),
                Contact = dt2.Rows[0].Field<string>("Contact"),
                UpdatedDate = dt2.Rows[0].Field<DateTime>("UpdatedDate"),
                Sequrity_Que = dt2.Rows[0].Field<string>("Sequrity_Que"),
                Is_verified = true

            };
            return cs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Customers cs = fill();
            int rowsAffected = dataAccess.Insert<Customers>(cs, true);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Customer Verified Successfully");
                this.Dispose();
                DataTable dt2 = dataAccess.GetData<Customers>($"where Is_verified = '{false}'");
                EmpShowForm sh = new EmpShowForm(dt, dt2,1);
                sh.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Something Went Wrong!!!");
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label29_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
