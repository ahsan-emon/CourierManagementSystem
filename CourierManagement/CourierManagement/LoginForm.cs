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
            login();
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
    }
}
