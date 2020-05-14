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
    public partial class EmpEditForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        string[] phone = { "017", "014", "013", "015", "019", "018", "016", "011" };
        string[] mail = { "@gmail.com", "@yahoo.com", "@hotmail.com", "@mail.com", "@outlook.com" };

        public EmpEditForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            label3.BackColor = Color.Black;
        }

        private void EmpEditForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void label11_Click(object sender, EventArgs e)
        {
            string sql = $"select * from Product_Info where Sending_Manager_id = '{dt.Rows[0].Field<int>("Id")}' or Receiving_Manager_id = '{dt.Rows[0].Field<int>("Id")}'";
            DataTable dt2 = dataAccess.Execute(sql);

            EmpShowForm es = new EmpShowForm(dt, dt2);
            es.Show();
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

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            label11.BackColor = Color.Black;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Black;
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

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.BackColor = Color.DeepSkyBlue;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DeepSkyBlue;
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.BackColor = Color.DeepSkyBlue;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DeepSkyBlue;
        }

        private void EmpEditForm_Load(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Employee>($"where user_id = '{dt.Rows[0].Field<int>("Id")}'");
            textBox1.Text = dt2.Rows[0].Field<string>("Name");
            dateTimePicker1.Value = dt2.Rows[0].Field<DateTime>("DOB");
            textBox2.Text = dt2.Rows[0].Field<string>("Contact");
            textBox3.Text = dt2.Rows[0].Field<string>("Qualification");
            textBox4.Text = dt2.Rows[0].Field<string>("Address");
            textBox5.Text = dt.Rows[0].Field<string>("Password");
            textBox6.Text = dt.Rows[0].Field<string>("Password");
            textBox7.Text = dt.Rows[0].Field<string>("EmailAddress");
            comboBox1.SelectedItem = dt2.Rows[0].Field<string>("Blood_Group");
        }

        private bool passwordcheck()
        {
            if (!textBox5.Text.Equals(textBox6.Text))
            {
                errorProvider1.SetError(textBox5, "Password doesn't match");
                errorProvider1.SetError(textBox6, "Password doesn't match");
                return false;
            }
            else if (textBox5.Text.Length < 8)
            {
                errorProvider1.SetError(textBox5, "Password must be at least 8 word");
                errorProvider1.SetError(textBox6, "Password must be at least 8 word");
                return false;
            }
            return true;
        }

        private bool check_empty()
        {
            List<Control> controls = new List<Control>(this.Controls.Cast<Control>()).OrderBy(c => c.TabIndex).ToList<Control>();
            foreach (var control in controls)
            {
                if (control is TextBox)
                {
                    bool flag = EmptyValidationTextBox(errorProvider1, control as TextBox);

                    if (flag == true)
                    {
                        return flag;
                    }
                }
            }
            return false;
        }

        private bool EmptyValidationTextBox(ErrorProvider errorProvider, TextBox textbox)
        {
            if (textbox.Text.Trim().Length == 0)
            {
                textbox.Focus();
                errorProvider.SetError(textbox, "This field should not be left blank!!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Edit_profile()
        {
            DateTime dt2 = this.dateTimePicker1.Value.Date;
            DataTable dte = dataAccess.GetData<Employee>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
            if (passwordcheck() && !check_empty() && isvalidphone() && isValidEmail())
            {

                Employee employee = new Employee()
                {
                    Id = dte.Rows[0].Field<int>("Id"),
                    Name = textBox1.Text,
                    DOB = dt2,
                    Contact = textBox2.Text,
                    Qualification = textBox3.Text,
                    Blood_Group = comboBox1.SelectedItem.ToString(),
                    Address = textBox4.Text,
                    Bonus = float.Parse(dte.Rows[0][4].ToString()),
                    Branch_id = dte.Rows[0].Field<int>("Branch_id"),
                    Designation = dte.Rows[0].Field<int>("Designation"),
                    Joining_date = dte.Rows[0].Field<DateTime>("Joining_date"),
                    UpdatedDate = dte.Rows[0].Field<DateTime>("UpdatedDate"),
                    User_id = dt.Rows[0].Field<int>("Id"),
                    Salary = float.Parse(dte.Rows[0][3].ToString())
                };

                int rowsAffected = dataAccess.Insert<Employee>(employee, true);
                //int rowsAffected = 1;
                if (rowsAffected > 0)
                {
                    Users user = new Users()
                    {
                        Id = dt.Rows[0].Field<int>("Id"),
                        Information_given = true,
                        Password = textBox5.Text,
                        EmailAddress = dt.Rows[0].Field<string>("EmailAddress"),
                        UpdatedDate = dt.Rows[0].Field<DateTime>("UpdatedDate"),
                        UserName = dt.Rows[0].Field<string>("UserName"),
                        UserType = dt.Rows[0].Field<int>("UserType")

                    };
                    rowsAffected = dataAccess.Insert<Users>(user, true);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile Edit Successfully");
                        EmpHomeForm home = new EmpHomeForm(dt);
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!");
                    }
                }
            }
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
                if (textBox7.Text.EndsWith(e))
                {
                    return true;
                }
            }
            return false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
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
                comboBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            Edit_profile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edit_profile();
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox4, "");
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox7, "");
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox5, "");
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox6, "");
        }
    }
}
