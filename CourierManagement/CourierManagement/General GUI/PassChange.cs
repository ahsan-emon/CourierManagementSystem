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
    public partial class PassChange : Form
    {
        DataAccess dataAccess = new DataAccess();
        public PassChange()
        {
            InitializeComponent();
            label2.Image = CourierManagement.Properties.Resources.help;
            button1.Text = "Verify";
            button1.Location = new Point(388, 245);
        }

        private bool passwordCheck()
        {
            if (!textBox3.Text.Equals(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Password doesn't match");
                errorProvider1.SetError(textBox3, "Password doesn't match");
                return false;
            }
            else if (textBox3.Text.Length < 8)
            {
                errorProvider1.SetError(textBox2, "Password must be at least 8 word");
                errorProvider1.SetError(textBox3, "Password must be at least 8 word");
                return false;
            }
            return true;
        }

        private void verify()
        {
            DataTable dtu = dataAccess.GetData<Users>($"where UserName = '{textBox1.Text}'");
            if (dtu.Rows.Count > 0)
            {
                if(dtu.Rows[0].Field<int>("UserType") == 2)
                {
                    DataTable dt2 = dataAccess.GetData<Customers>($"where User_Id = '{dtu.Rows[0].Field<int>("Id")}' and Sequrity_Que = '{textBox2.Text}'");
                    if (dt2.Rows.Count > 0)
                    {
                        textBox1.Focus();
                        textBox2.Text = "New Password!!!";
                        textBox2.ForeColor = Color.Gray;

                        textBox3.Text = "Repeat New Password!!!";
                        textBox3.ForeColor = Color.Gray;

                        MessageBox.Show("Verified");
                        label2.Image = CourierManagement.Properties.Resources.Pass1;
                        button1.Location = new Point(388, 298);
                        button1.Text = "Changed Password";
                        label15.Visible = true;
                        textBox3.Visible = true;
                        label4.Visible = true;
                        label22.Visible = true;
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, "User Name Maybe wrong");
                        errorProvider1.SetError(textBox2, "Sequrity Que ans maybe Wrong");
                        MessageBox.Show("User Name or Sequrity Que ans is not Correct!!!");
                        LoginForm lf = new LoginForm();
                        lf.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("You can't Chnage your Password In this way\nAsk the Admin about it");
                }
            }
        }

        private Users fill()
        {
            DataTable dt = dataAccess.GetData<Users>($"where UserName = '{textBox1.Text}'");
            Users u = new Users()
            {
                Id = dt.Rows[0].Field<int>("Id"),
                EmailAddress = dt.Rows[0].Field<string>("EmailAddress"),
                UpdatedDate= dt.Rows[0].Field<DateTime>("UpdatedDate"),
                Information_given = dt.Rows[0].Field<bool>("Information_given"),
                UserName = dt.Rows[0].Field<string>("UserName"),
                UserType = dt.Rows[0].Field<int>("UserType"),
                Password = textBox2.Text
            };
            return u;
        }

        private void changePassword()
        {
            if (passwordCheck())
            {
                Users u = fill();
                int rowsAffected = dataAccess.Insert<Users>(u, true);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password changed Successfully");
                    LoginForm lf = new LoginForm();
                    lf.Show();
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
            if (button1.Text.Equals("Verify"))
            {
                verify();
            }
            else
            {
                changePassword();
            }
        }

        private void PassChange_FormClosed(object sender, FormClosedEventArgs e)
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
                e.SuppressKeyPress = true;
                if (button1.Text.Equals("Verify"))
                {
                    verify();
                }
                else
                {
                    textBox3.Focus();
                    textBox3.Text = "";
                }
                
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                changePassword();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (label22.Visible)
            {
                textBox2.UseSystemPasswordChar = true;
                textBox2.ForeColor = Color.Black;
                errorProvider1.SetError(textBox2, "");
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            textBox3.ForeColor = Color.Black;
            errorProvider1.SetError(textBox3, "");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("Username"))
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            errorProvider1.SetError(textBox1, "");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("Sequrity Question answer?") || textBox2.Text.Equals("New Password!!!"))
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Sequrity Question answer?";
                textBox2.ForeColor = Color.Gray;
            }
            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("Repeat New Password!!!"))
            {
                textBox2.Text = "";
            }
            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Repeat New Password!!!";
                textBox2.ForeColor = Color.Gray;
            }
        }
    }
}
