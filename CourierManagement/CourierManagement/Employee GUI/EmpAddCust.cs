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
    public partial class EmpAddCust : Form
    {
        string[] mail = { "@gmail.com", "@yahoo.com", "@hotmail.com", "@mail.com", "@outlook.com" };
        string[] phone = { "017", "014", "013", "015", "019", "018", "016", "011" };
        DataAccess dataAccess = new DataAccess();
        DataTable dt;
        public EmpAddCust(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void EmpAddCust_FormClosed(object sender, FormClosedEventArgs e)
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
            EmpShowForm ser = new EmpShowForm(dt);
            ser.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            add_new_customer();
        }

        private bool unique_check()
        {
            DataTable dt;
            dt = dataAccess.GetData<Users>($"where UserName = '{textBox2.Text}' or EmailAddress = '{textBox6.Text}'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0].Field<string>("UserName").Equals(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "User Name already taken!!!");
                    textBox2.Focus();
                    return false;
                }
                else if (dt.Rows[0].Field<string>("EmailAddress").Equals(textBox6.Text))
                {
                    errorProvider1.SetError(textBox6, "Email Already Used!!!");
                    textBox6.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool validationcheck()
        {
            if (!isvalidphone())
            {
                errorProvider1.SetError(textBox5, "This is not a valid contact number!!!");
                return false;
            }
            else if (textBox5.Text.Length < 11)
            {
                errorProvider1.SetError(textBox5, "There must be 11 number in your phone!!!");
                return false;
            }
            else if (textBox5.Text.Length > 11)
            {
                errorProvider1.SetError(textBox5, "There must be 11 number in your phone!!!");
                return false;
            }
            else if (!isValidEmail())
            {
                errorProvider1.SetError(textBox6, "This is not a valid Email address!!!");
                return false;
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

        private bool isValidEmail()
        {
            foreach (string e in mail)
            {
                if (textBox6.Text.EndsWith(e))
                {
                    return true;
                }
            }
            return false;
        }

        private bool passwordcheck()
        {
            if (!textBox3.Text.Equals(textBox4.Text))
            {
                errorProvider1.SetError(textBox3, "Password doesn't match");
                errorProvider1.SetError(textBox4, "Password doesn't match");
                return false;
            }
            else if (textBox3.Text.Length < 8)
            {
                errorProvider1.SetError(textBox3, "Password must be at least 8 word");
                errorProvider1.SetError(textBox4, "Password must be at least 8 word");
                return false;
            }
            return true;
        }

        private bool check_all()
        {
            return unique_check() && !check_empty() && validationcheck() && passwordcheck();
        }

        private void add_new_customer()
        {
            if (check_all())
            {
                Users users = new Users()
                {
                    UserName = textBox2.Text,
                    Password = textBox3.Text,
                    EmailAddress = textBox6.Text,
                    Information_given = true,
                    UserType = 2,
                    UpdatedDate = DateTime.Now
                };
                int affectedRowCount = dataAccess.Insert<Users>(users, true);
                DataTable dt = dataAccess.GetData<Users>($"where UserName = '{textBox2.Text}' and Password = '{textBox3.Text}'");
                if (affectedRowCount > 0)
                {
                    Customers customer = new Customers()
                    {
                        User_Id = dt.Rows[0].Field<int>("Id"),
                        Address = textBox7.Text,
                        Contact = textBox5.Text,
                        Name = textBox1.Text,
                        Sequrity_Que = textBox8.Text,
                        UpdatedDate = DateTime.Now

                    };
                    affectedRowCount = dataAccess.Insert<Customers>(customer, true);

                    if (affectedRowCount > 0)
                    {
                        MessageBox.Show("New Customer Added successfully");
                        LoginForm lf = new LoginForm();
                        lf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Unable to save.");
                    }
                }
                else
                {
                    MessageBox.Show("Unable to save.");
                }

            }
        }

        private bool check_empty()
        {
            List<Control> controls = new List<Control>(this.panel1.Controls.Cast<Control>()).OrderBy(c => c.TabIndex).ToList<Control>();
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
            if (textBox8.Text.Equals("Who is your favourite person?"))
            {
                errorProvider1.SetError(textBox8, "This field should be left blank!!");
                return true;
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
                textBox4.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
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
                textBox8.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_new_customer();
                e.SuppressKeyPress = true;
            }
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox5, "");
            if (!(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)8)))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox6, "");
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox7, "");
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox8, "");
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals("Who is your favourite person?"))
            {
                textBox8.Text = "";
                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals(""))
            {
                textBox8.Text = "Who is your favourite person?";
                textBox8.ForeColor = Color.Gray;
            }
        }
    }
}
