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
            label26.BackColor = Color.Blue;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustTrackForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            LoginForm ad = new LoginForm();
            ad.Show();
            this.Hide();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            CustHomeForm home = new CustHomeForm(dt);
            home.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            CustSerForm ser = new CustSerForm(dt);
            ser.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            CustEditForm edit = new CustEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            label27.BackColor = Color.Blue;
        }

        private void label27_MouseLeave(object sender, EventArgs e)
        {
            label27.BackColor = Color.FromArgb(0, 0, 64);
        }
        private void label22_MouseEnter(object sender, EventArgs e)
        {
            label22.BackColor = Color.Blue;
        }

        private void label24_MouseEnter(object sender, EventArgs e)
        {
            label24.BackColor = Color.Blue;
        }

        private void label23_MouseEnter(object sender, EventArgs e)
        {
            label23.BackColor = Color.Blue;
        }

        private void label21_MouseEnter(object sender, EventArgs e)
        {
            label21.BackColor = Color.Blue;
        }

        private void label25_MouseEnter(object sender, EventArgs e)
        {
            label25.BackColor = Color.Blue;
        }

        private void label22_MouseLeave(object sender, EventArgs e)
        {
            label22.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label24_MouseLeave(object sender, EventArgs e)
        {
            label24.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label23_MouseLeave(object sender, EventArgs e)
        {
            label23.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label21_MouseLeave(object sender, EventArgs e)
        {
            label21.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label25_MouseLeave(object sender, EventArgs e)
        {
            label25.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void set_gridview()
        {
            DataTable dt2 = dataAccess.GetData<Product_Info>($"where (Product_State = '{1}' or Product_State = '{0}') and Customer_id = '{dt.Rows[0].Field<int>("Id")}'");
            dataGridView1.DataSource = dt2;

            dt2 = dataAccess.GetData<Product_Info>($"where (Product_State = '{2}' or Product_State = '{3}') and Customer_id = '{dt.Rows[0].Field<int>("Id")}'");
            dataGridView2.DataSource = dt2;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CustTrackForm_Load(object sender, EventArgs e)
        {
            set_gridview();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("0"))
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
                DataTable dt2 = dataAccess.GetData<Product_Info>($"where (Product_State = '{1}' or Product_State = '{0}') and Customer_id = '{dt.Rows[0].Field<int>("Id")}'");
                CustTrackForm ct = new CustTrackForm(dt);
                ct.Show();
                this.Hide();

            }
            else if (dialogResult == DialogResult.No)
            {
                DataTable dt2 = dataAccess.GetData<Product_Info>($"where (Product_State = '{1}' or Product_State = '{0}') and Customer_id = '{dt.Rows[0].Field<int>("Id")}'");
                CustTrackForm ct = new CustTrackForm(dt);
                ct.Show();
                this.Hide();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("2"))
            {
                MessageBox.Show("Product Shipped \nNow it is on the way to the Destination Branch");
            }
            else
            {
                MessageBox.Show("Product Recieved by the Destination Branch \nReady to Release.");
            }
        }
    }
}
