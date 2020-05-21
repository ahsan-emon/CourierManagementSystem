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
    public partial class EmpHomeForm : Form
    {
        DataTable dt,dte;
        DataAccess dataAccess = new DataAccess();
        public EmpHomeForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            label4.BackColor = Color.Black;
        }

        private void EmpHomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void EmpHomeForm_Load(object sender, EventArgs e)
        {
            dte = dataAccess.GetData<Employee>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
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

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.DeepSkyBlue;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DeepSkyBlue;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label23_MouseEnter(object sender, EventArgs e)
        {
            label23.ForeColor = Color.White;
        }

        private void label18_MouseEnter(object sender, EventArgs e)
        {
            label18.ForeColor = Color.White;
        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            label17.ForeColor = Color.White;
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            label26.ForeColor = Color.White;
        }

        private void label28_MouseEnter(object sender, EventArgs e)
        {
            label28.ForeColor = Color.White;
        }

        private void label16_MouseEnter(object sender, EventArgs e)
        {
            label16.ForeColor = Color.White;
        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            label15.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label23_MouseLeave(object sender, EventArgs e)
        {
            label23.ForeColor = Color.Black;
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            label18.ForeColor = Color.Black;
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Black;
        }

        private void label26_MouseLeave(object sender, EventArgs e)
        {
            label26.ForeColor = Color.Black;
        }

        private void label28_MouseLeave(object sender, EventArgs e)
        {
            label28.ForeColor = Color.Black;
        }

        private void label16_MouseLeave(object sender, EventArgs e)
        {
            label16.ForeColor = Color.Black;
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            label15.ForeColor = Color.Black;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DeepSkyBlue;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm ad = new LoginForm();
            ad.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Customers>($"where Is_verified = '{true}'");
            EmpShowForm sh = new EmpShowForm(dt,dt2,4);
            sh.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Customers>($"where Is_verified = '{true}'");
            EmpShowForm sh = new EmpShowForm(dt,dt2,4);
            sh.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            EmpProfile profile = new EmpProfile(dt);
            profile.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            string sql = $"select * from Product_Info where Sending_Manager_id = '{dt.Rows[0].Field<int>("Id")}' or Receiving_Manager_id = '{dt.Rows[0].Field<int>("Id")}'";
            DataTable dt2 = dataAccess.Execute(sql);

            EmpShowForm es = new EmpShowForm(dt,dt2,5);
            es.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            EmpEditForm edit = new EmpEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void Receive()
        {
            EmpReceive rec = new EmpReceive(dt);
            rec.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Receive();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Customers>($"where Is_verified = '{false}'");
            EmpShowForm es = new EmpShowForm(dt,dt2,1);
            es.Show();
            this.Hide();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Product_Info>($"where Product_State = '{1}' and Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'"); ;
            if (dt2.Rows.Count > 0)
            {
                EmpShowForm es = new EmpShowForm(dt,dt2,2);
                es.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Product to ship");
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Product_Info>($"where Product_State = '{3}' and Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
            if (dt2.Rows.Count > 0)
            {
                EmpShowForm es = new EmpShowForm(dt,dt2,3);
                es.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Product to ship");
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Product_Info>($"where Product_State = '{3}' and Receiving_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
            if (dt2.Rows.Count > 0)
            {
                EmpShowForm es = new EmpShowForm(dt,dt2,3);
                es.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Product to ship");
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            //$"select p.* from Product_Info as p,Products_State_Info as ps where p.Id = ps.Product_Id and ps.Product_State = 1";
            DataTable dt2 = dataAccess.GetData<Product_Info>($"where Product_State = '{1}' and Sending_B_id = '{dte.Rows[0].Field<int>("Branch_id")}'");
            if(dt2.Rows.Count>0)
            { 
                EmpShowForm es = new EmpShowForm(dt,dt2,2);
                es.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Product to ship");
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Customers>($"where Is_verified = '{false}'");
            EmpShowForm es = new EmpShowForm(dt,dt2,1);
            es.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Receive();
        }

        public void addCUst()
        {
            EmpAddCust add = new EmpAddCust(dt);
            add.Show();
            this.Hide();
        }
        private void label19_Click(object sender, EventArgs e)
        {
            addCUst();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            addCUst();
        }

        public void helpline()
        {
            EmpHelpline help = new EmpHelpline(dt);
            help.Show();
            this.Hide();
        }
        private void label25_Click(object sender, EventArgs e)
        {
            helpline();
        }

        public void terms()
        {
            EmpTermCondition tr = new EmpTermCondition(dt);
            tr.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            terms();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            terms();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label30_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            helpline();
        }
    }
}
