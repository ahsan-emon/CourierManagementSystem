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
    public partial class CustOrderForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        string[] phone = { "017", "014", "013", "015", "019", "018", "016", "011" };
        string[] mail = { "@gmail.com", "@yahoo.com", "@hotmail.com", "@mail.com", "@outlook.com" };
        public CustOrderForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            label27.BackColor = Color.Blue;
        }

        private void CustNewDelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            CustHomeForm home = new CustHomeForm(dt);
            home.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            CustTrackForm track = new CustTrackForm(dt);
            track.Show();
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

        private void label25_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            label26.BackColor = Color.Blue;
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

        private void label26_MouseLeave(object sender, EventArgs e)
        {
            label26.BackColor = Color.FromArgb(0, 0, 64);
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

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals("Describe the Product"))
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Describe the Product";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox4.ForeColor = Color.Black;
            errorProvider1.SetError(textBox4, "");
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals("Quantity"))
            {
                textBox5.Text = "";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals(""))
            {
                textBox5.Text = "Quantity";
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)8)))
            {
                e.Handled = true;
            }
            textBox5.ForeColor = Color.Black;
            errorProvider1.SetError(textBox5, "");
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("Full Name"))
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "Full Name";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            errorProvider1.SetError(textBox1, "");
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("Contact Number"))
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Contact Number";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.ForeColor = Color.Black;
            errorProvider1.SetError(textBox2, "");
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("Email*"))
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "Email*";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox3.ForeColor = Color.Black;
            errorProvider1.SetError(textBox3, "");
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals("Address"))
            {
                textBox6.Text = "";
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals(""))
            {
                textBox6.Text = "Address";
                textBox6.ForeColor = Color.Gray;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox6.ForeColor = Color.Black;
            errorProvider1.SetError(textBox6, "");
        }

        private DataTable Branch()
        {
            DataTable dt2 = dataAccess.GetData<Branch_Info>("");
            return dt2;
        }

        private void CustOrderForm_Load(object sender, EventArgs e)
        {
            comboBox4.DisplayMember = "Branch_Name";
            comboBox4.ValueMember = "Id";
            comboBox4.DataSource = Branch();

            comboBox5.DisplayMember = "Branch_Name";
            comboBox5.ValueMember = "Id";
            comboBox5.DataSource = Branch();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                textBox4.ReadOnly = false;
                textBox4.Focus();
                return;
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Focus();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Focus();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox5.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private bool isvalidphone()
        {
            foreach (string p in phone)
            {
                if (textBox2.Text.StartsWith(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isValidEmail()
        {
            foreach (string e in mail)
            {
                if (textBox3.Text.EndsWith(e))
                {
                    return true;
                }
            }
            return false;
        }

        private bool validation()
        {
            if (!isvalidphone())
            {
                errorProvider1.SetError(textBox2, "Not a valid Phone Number");
                return false;
            }
            else if (!isValidEmail())
            {
                errorProvider1.SetError(textBox3, "Not a valid Email");
                return false;
            }

            return true;
        }

        private int category()
        {
            int c;
            string desi = comboBox1.SelectedItem.ToString();
            if (desi.Equals("Document"))
            {
                c = (int)Product_Info.ProductCategoryEnum.Document;
            }
            else if (desi.Equals("Package"))
            {
                c = (int)Product_Info.ProductCategoryEnum.Package;
            }
            else if (desi.Equals("Accessories"))
            {
                c = (int)Product_Info.ProductCategoryEnum.Accessories;
            }
            else if (desi.Equals("Electronics"))
            {
                c = (int)Product_Info.ProductCategoryEnum.Electronics;
            }
            else if (desi.Equals("Groceries"))
            {
                c = (int)Product_Info.ProductCategoryEnum.Groceries;
            }
            else
            {
                c = (int)Product_Info.ProductCategoryEnum.Others;
            }
            return c;
        }

        private int pType()
        {
            int c;
            string desi = comboBox3.SelectedItem.ToString();
            if (desi.Equals("Extra_Large"))
            {
                c = (int)Product_Info.ProductTypeEnum.Extra_Large;
            }
            else if (desi.Equals("Large"))
            {
                c = (int)Product_Info.ProductTypeEnum.Large;
            }
            else if (desi.Equals("Medium"))
            {
                c = (int)Product_Info.ProductTypeEnum.Medium;
            }
            else
            {
                c = (int)Product_Info.ProductTypeEnum.Small;
            }
            return c;
        }

        private string rEmail()
        {
            if (textBox3.Text.Equals("Email*"))
            {
                string s = "";
                return s;
            }
            else
            {
                string s = textBox3.Text;
                return s;
            }
        }
        private Product_Info fill_data()
        {
            Product_Info pi = new Product_Info()
            {
                Customer_id = dt.Rows[0].Field<int>("Id"),
                UpdatedDate = DateTime.Now,
                PaymentMethod = (int)Product_Info.PaymentMethodEnum.Cash,
                ProductCategory = category(),
                ProductType = pType(),
                Description = textBox4.Text,
                Receiving_B_id = Int32.Parse(comboBox5.SelectedValue.ToString()),
                Sending_B_id = Int32.Parse(comboBox4.SelectedValue.ToString()),
                RecieverAddress = textBox6.Text,
                RecieverName = textBox1.Text,
                RecieverContact = textBox2.Text,
                RecieverEmail = rEmail(),
                Delivery_charge = 100,
                Receiving_Manager_id = -1,
                Sending_Manager_id = -1,
                Product_State = (int)Product_Info.ProductStateEnum.Not_yet_Received,
                Release_Date = DateTime.Now.AddDays(3)

            };
            return pi;
        }
        private void submit()
        {
            if (validation())
            {
                Product_Info newproduct = fill_data();

                int rowsAffected = dataAccess.Insert<Product_Info>(newproduct, true);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Your Requested Submitted Successfully");
                    CustHomeForm ch = new CustHomeForm(dt);
                    ch.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong!!!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox5.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
