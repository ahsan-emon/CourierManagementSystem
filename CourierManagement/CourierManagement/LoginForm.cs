using System;
using System.Data;
using System.Windows.Forms;

namespace CourierManagement
{
    public partial class LoginForm : Form
    {
        DataAccess dataAccess = new DataAccess();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (checkEmpty())
            {
                login();
            }
        }

        bool checkEmpty()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox1, "User Name is empty!!!");
                errorProvider1.SetError(textBox2, "Password field is Emptyy!!");
                textBox1.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "User Name Left Emptyy!!");
                textBox1.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Password field should not be blank!!");
                textBox2.Focus();
                return false;
            }
            return true;
        }

        private void login()
        {
            DataTable dt;
            dt = dataAccess.GetData<Users>($"where UserName = '{textBox1.Text}' and Password = '{textBox2.Text}'");

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0].Field<int>("UserType") == 0)
                {
                    AdminHomeForm ah = new AdminHomeForm();
                    ah.Show();
                    this.Hide();
                }
                else if(dt.Rows[0].Field<int>("UserType") == 1)
                {
                    EmpHomeForm ah = new EmpHomeForm();
                    ah.Show();
                    this.Hide();
                }
                else
                {
                    CustHomeForm ch = new CustHomeForm();
                    ch.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Login Failed");
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
                login();
                e.SuppressKeyPress = true;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("Username"))
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("********"))
            {
                textBox2.Text = "";
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals(""))
            {
                textBox1.Text = "Username";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "********";
            }
        }
    }
}
