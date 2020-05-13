using CourierManagement.Employee_GUI;
using CourierManagement.Entities;
using System;
using System.Data;
using System.Drawing;
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
                login();
        }

        bool checkEmpty()
        {
            if ((textBox1.Text.Equals("Username") && (textBox2.Text.Equals("********")||textBox2.Text.Equals(""))))
            {
                errorProvider1.SetError(textBox1, "User Name is empty!!!");
                errorProvider1.SetError(textBox2, "Password field is Emptyy!!");
                textBox1.Focus();
                return false;
            }
            else if (textBox1.Text.Equals("Username"))
            {
                errorProvider1.SetError(textBox1, "User Name Left Emptyy!!");
                textBox1.Focus();
                return false;
            }
            else if (textBox2.Text.Equals("********") || textBox2.Text.Equals(""))
            {
                errorProvider1.SetError(textBox2, "Password field should not be blank!!");
                textBox2.Focus();
                return false;
            }
            return true;
        }

        private void login()
        {
            if (checkEmpty())
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
                    else if (dt.Rows[0].Field<int>("UserType") == 1)
                    {
                        if (dt.Rows[0].Field<bool>("Information_given"))
                        {
                            EmpHomeForm ef = new EmpHomeForm(dt);
                            ef.Show();
                            this.Hide();
                        }
                        else
                        {
                            EmpRegistration em = new EmpRegistration(dt);
                            em.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        DataTable dt2 = dataAccess.GetData<Customers>($"where User_Id = '{dt.Rows[0].Field<int>("Id")}'");
                        if (dt2.Rows[0].Field<bool>("Is_verified"))
                        {
                            CustHomeForm ch = new CustHomeForm(dt);
                            ch.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Please wait for verification");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
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
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "********";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            errorProvider1.SetError(textBox1, "");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.ForeColor = Color.Black;
            errorProvider1.SetError(textBox2, "");
        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            label15.ForeColor = Color.Red;
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            label15.ForeColor = Color.CornflowerBlue;
        }

        private void label15_MouseClick(object sender, MouseEventArgs e)
        {
            PassChange fp = new PassChange();
            fp.Show();
            this.Hide();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Green;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.CornflowerBlue;
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            CustRegForm cr = new CustRegForm();
            cr.Show();
            this.Hide();
        }
    }
}
