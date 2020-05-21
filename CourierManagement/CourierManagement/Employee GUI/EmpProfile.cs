using CourierManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourierManagement
{
    public partial class EmpProfile : Form
    {
        DataAccess dataAccess = new DataAccess();
        DataTable dt;
        public EmpProfile(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            label5.BackColor = Color.Black;
        }

        private void EmpProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            string sql = $"select * from Product_Info where Sending_Manager_id = '{dt.Rows[0].Field<int>("Id")}' or Receiving_Manager_id = '{dt.Rows[0].Field<int>("Id")}'";
            DataTable dt2 = dataAccess.Execute(sql);

            EmpShowForm es = new EmpShowForm(dt, dt2,5);
            es.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            EmpHomeForm home = new EmpHomeForm(dt);
            home.Show();
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
            label4.BackColor = Color.DeepSkyBlue;
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

        private string branch_name(int id)
        {
            DataTable dt2 = dataAccess.GetData<Branch_Info>($"where Id = '{id}'");
            return dt2.Rows[0].Field<string>("Branch_Name");
        }

        private string total_recived()
        {
            DataTable dt2 = dataAccess.GetData<Product_Info>($"where Receiving_Manager_id = '{dt.Rows[0].Field<int>("Id")}'");
            return dt2.Rows.Count.ToString();
        }
        private string total_sent()
        {
            DataTable dt2 = dataAccess.GetData<Product_Info>($"where Sending_Manager_id = '{dt.Rows[0].Field<int>("Id")}'");
            return dt2.Rows.Count.ToString();
        }

        private void EmpProfile_Load(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Employee>($"where user_id = '{dt.Rows[0].Field<int>("Id")}'");

            label23.Text = dt2.Rows[0].Field<string>("Name");
            label19.Text = branch_name(dt2.Rows[0].Field<int>("Branch_id"));
            label22.Text = Enum.GetName(typeof(Employee.DesignationEnum), dt2.Rows[0].Field<int>("Designation"));
            label26.Text = dt.Rows[0].Field<string>("EmailAddress");
            label31.Text = dt2.Rows[0].Field<DateTime>("DOB").ToString("dd-MM-yyyy");
            label25.Text = dt2.Rows[0].Field<string>("Blood_Group");
            label24.Text = dt2.Rows[0].Field<string>("Contact"); 
            label15.Text = dt2.Rows[0].Field<string>("Address");
            label30.Text = total_sent();
            label27.Text = total_recived();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
