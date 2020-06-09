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

namespace CourierManagement.Admin_GUI
{
    public partial class AdminViewWorker : Form
    {
        DataTable dt,dt2,dt3;
        DataAccess dataAccess = new DataAccess();

        public AdminViewWorker(DataTable dt,DataTable dt2,DataTable dt3)
        {
            InitializeComponent();
            label4.BackColor = Color.Firebrick;
            this.dt = dt;
            this.dt2 = dt2;
            this.dt3=dt3;
            //label10.Text = dt3.Rows[0].Field<string>("UserName");
        }

        private void AdminViewWorker_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            AdminShowForm sh = new AdminShowForm(dt2,1,dt3);
            sh.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm add = new AdminAddBranchForm(dt3);
            add.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm(dt3);
            home.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            AdminShowForm sh = new AdminShowForm(dataAccess.GetData<Branch>(""),3,dt3);
            sh.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.Firebrick;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Firebrick;
        }

        private void label13_MouseEnter(object sender, EventArgs e)
        {
            label13.BackColor = Color.Firebrick;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Firebrick;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.DimGray;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DimGray;
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.BackColor = Color.DimGray;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DimGray;
        }

        private void set_value()
        {
            label12.Text = dt.Rows[0].Field<string>("Name");
            textBox4.Text = dt.Rows[0][3].ToString();
            textBox5.Text = dt.Rows[0][4].ToString();
            comboBox1.SelectedItem = ((Employee.DesignationEnum)dt.Rows[0].Field<int>("Designation")).ToString();
            DataTable dt2 = dataAccess.GetData<Branch>("");
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "Branch_Name";
            comboBox2.ValueMember = "Id";
            comboBox2.SelectedIndex = dt.Rows[0].Field<int>("Branch_id")-1;
        }

        private Employee fill()
        {
            string desi = comboBox1.SelectedItem.ToString();
            int desig;
            if (desi.Equals("Manager"))
            {
                desig = (int)Employee.DesignationEnum.Manager;
            }
            else if (desi.Equals("Worker"))
            {
                desig = (int)Employee.DesignationEnum.Worker;
            }
            else if (desi.Equals("Driver"))
            {
                desig = (int)Employee.DesignationEnum.Driver;
            }
            else
            {
                desig = (int)Employee.DesignationEnum.Delivery_boy;
            }
            Employee e = new Employee()
            {
                Id = dt.Rows[0].Field<int>("Id"),
                UpdatedDate = dt.Rows[0].Field<DateTime>("UpdatedDate"),
                Name = dt.Rows[0].Field<string>("Name"),
                Designation = desig,
                DOB = dt.Rows[0].Field<DateTime>("DOB"),
                Address = dt.Rows[0].Field<string>("Address"),
                Joining_date = dt.Rows[0].Field<DateTime>("Joining_date"),
                Blood_Group = dt.Rows[0].Field<string>("Blood_Group"),
                Bonus = float.Parse(textBox5.Text),
                Branch_id = (int)comboBox2.SelectedValue,
                Contact = dt.Rows[0].Field<string>("Contact"),
                Qualification = dt.Rows[0].Field<string>("Qualification"),
                Salary = float.Parse(textBox4.Text),
                User_id = dt.Rows[0].Field<int>("User_id")
            };
            return e;
        }

        private void update()
        {
            Employee e = fill();
            int rowsAffected = dataAccess.Insert<Employee>(e, true);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Profile updated of the worker");
                AdminShowForm add = new AdminShowForm(dataAccess.GetData<Employee>(""),1,dt3);
                add.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Something Went Wrong!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void delete()
        {
            string id = dt.Rows[0].Field<int>("User_id").ToString();
            int rowsAffected = dataAccess.Delete("Employee", "User_id", id);
            if (rowsAffected > 0)
            {
                rowsAffected = dataAccess.Delete("Users", "Id", id);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Account Deleted Successfully");
                    DataTable dtw = dataAccess.GetData<Employee>("");
                    AdminShowForm sh = new AdminShowForm(dtw, 1,dt3);
                    sh.Show();
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

        private void label20_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminViewWorker_Load(object sender, EventArgs e)
        {
            set_value();
        }
    }
}
