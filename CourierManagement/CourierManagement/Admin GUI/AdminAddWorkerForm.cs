
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
    public partial class AdminAddWorkerForm : Form
    {
        DataAccess dataAccess = new DataAccess();
        string[] mail = { "@gmail.com", "@yahoo.com", "@hotmail.com", "@mail.com", "@outlook.com" };
        string[] phone = { "017", "014", "013", "015", "019", "018", "016", "011" };
        public AdminAddWorkerForm()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Firebrick;
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

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.DimGray;
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

        private void label4_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm();
            home.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm add = new AdminAddBranchForm();
            add.Show();
            this.Hide();
        }

        private void AdminAddWorkerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                textBox5.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_worker();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void add_worker()
        {
            if(validationcheck() && unique_check())
            {
                Users user = new Users()
                {
                    UserName = textBox1.Text,
                    Password = textBox2.Text,
                    EmailAddress = textBox3.Text,
                    Information_given = false,
                    UserType = 1,
                    UpdatedDate = DateTime.Now
                };
                int affectedRowCount = dataAccess.Insert<Users>(user, true);
                DataTable dt = dataAccess.GetData<Users>($"where UserName = '{textBox1.Text}' and Password = '{textBox2.Text}'");
                if (affectedRowCount > 0)
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
                    Employee employee = new Employee()
                    {
                        User_id = dt.Rows[0].Field<int>("Id"),
                        Contact = textBox5.Text,
                        UpdatedDate = DateTime.Now,
                        Salary = float.Parse(textBox4.Text),
                        Branch_id = (int)comboBox2.SelectedValue,
                        Designation = desig,
                        Name = "",
                        Address="",
                        Blood_Group ="",
                        Bonus = 0,
                        DOB = DateTime.Now,
                        Joining_date = DateTime.Now,
                        Qualification = ""
                    };
                    affectedRowCount = dataAccess.Insert<Employee>(employee, true);

                    if (affectedRowCount > 0)
                    {
                        MessageBox.Show("Worker Added Successfully");
                        AdminHomeForm lf = new AdminHomeForm();
                        lf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Unable to Add worker!!!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_worker();
        }

        private DataTable Branch()
        {
            DataTable dt = dataAccess.GetData<Branch_Info>("");
            return dt;
        }

        private void AdminAddWorkerForm_Load(object sender, EventArgs e)
        {
            DataTable dt = Branch();
            comboBox2.DisplayMember = "Branch_Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = dt;
            comboBox1.SelectedItem = "Manager";
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private bool unique_check()
        {
            DataTable dt;
            dt = dataAccess.GetData<Users>($"where UserName = '{textBox1.Text}' or EmailAddress = '{textBox3.Text}'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0].Field<string>("UserName").Equals(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "User Name already taken!!!");
                    textBox1.Focus();
                    return false;
                }
                else if (dt.Rows[0].Field<string>("EmailAddress").Equals(textBox3.Text))
                {
                    errorProvider1.SetError(textBox3, "Email Already Used!!!");
                    textBox3.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool isvalidphone()
        {
            foreach (string p in phone)
            {
                if (textBox5.Text.StartsWith(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool validationcheck()
        {
            if (!isvalidphone())
            {
                errorProvider1.SetError(textBox5, "This is not a valid contact number!!!");
                textBox5.Focus();
                return false;
            }
            else if (textBox5.Text.Length < 11)
            {
                errorProvider1.SetError(textBox5, "There must be 11 number in your phone!!!");
                textBox5.Focus();
                return false;
            }
            else if (textBox5.Text.Length > 11)
            {
                errorProvider1.SetError(textBox5, "There must be 11 number in your phone!!!");
                textBox5.Focus();
                return false;
            }
            else if (!isValidEmail())
            {
                errorProvider1.SetError(textBox3, "This is not a valid Email address!!!");
                textBox3.Focus();
                return false;
            }
            else if (textBox2.Text.Length < 8)
            {
                errorProvider1.SetError(textBox2, "Password should be atleast 8 word");
                textBox2.Focus();
                return false;
            }

            return true;
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox3, "");
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox5, "");
            if (!(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)8)))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox4, "");
            if (!(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)8)))
            {
                e.Handled = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DataTable dt = dataAccess.GetData<Branch_Info>("");
            AdminShowForm view = new AdminShowForm(dt,3);
            view.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar)
            {
                textBox2.UseSystemPasswordChar = false;
                label20.Image = CourierManagement.Properties.Resources.Undo;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                label20.Image = CourierManagement.Properties.Resources.Redo;
            }
        }
    }
}
