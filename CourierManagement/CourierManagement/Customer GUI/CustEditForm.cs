using CourierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CourierManagement
{
    public partial class CustEditForm : Form
    {
        string[] mail = { "@gmail.com", "@yahoo.com", "@hotmail.com", "@mail.com", "@outlook.com" };
        string[] phone = { "017", "014", "013", "015", "019", "018", "016", "011" };
        DataTable dt,dt2;
        DataAccess dataAccess = new DataAccess();
        public CustEditForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            lblEditProfile.BackColor = Color.Blue;
            label10.Text = dt.Rows[0].Field<string>("UserName");
        }

        private void CustEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            CustHomeForm home = new CustHomeForm(dt);
            home.Show();
            this.Hide();
        }

        private void lblTrackOrder_Click(object sender, EventArgs e)
        {
            CustTrackForm track = new CustTrackForm(dt);
            track.Show();
            this.Hide();
        }

        private void lblSerHistory_Click(object sender, EventArgs e)
        {
            CustSerForm ser = new CustSerForm(dt);
            ser.Show();
            this.Hide();
        }

        private void lblHome_MouseEnter(object sender, EventArgs e)
        {
            lblHome.BackColor = Color.Blue;
        }

        private void lblHome_MouseLeave(object sender, EventArgs e)
        {
            lblHome.BackColor = Color.FromArgb(0,0,64);
        }

        private void lblTrackOrder_MouseEnter(object sender, EventArgs e)
        {
            lblTrackOrder.BackColor = Color.Blue;
        }

        private void lblSerHistory_MouseEnter(object sender, EventArgs e)
        {
            lblSerHistory.BackColor = Color.Blue;
        }

        private void lblDeleteAcc_MouseEnter(object sender, EventArgs e)
        {
            lblDeleteAcc.BackColor = Color.Blue;
        }

        private void label25_MouseEnter(object sender, EventArgs e)
        {
            label25.BackColor = Color.Blue;
        }

        private void lblTrackOrder_MouseLeave(object sender, EventArgs e)
        {
            lblTrackOrder.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblSerHistory_MouseLeave(object sender, EventArgs e)
        {
            lblSerHistory.BackColor = Color.FromArgb(0, 0, 64);
        }


        private void lblDeleteAcc_MouseLeave(object sender, EventArgs e)
        {
            lblDeleteAcc.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label25_MouseLeave(object sender, EventArgs e)
        {
            label25.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void fill()
        {
            dt2 = dataAccess.GetData<Customers>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
            if (dt2.Rows.Count > 0)
            {
                txtName.Text = dt2.Rows[0].Field<string>("Name");
                txtUserName.Text = dt.Rows[0].Field<string>("UserName");
                txtContact.Text = dt2.Rows[0].Field<string>("Contact");
                txtAddress.Text = dt2.Rows[0].Field<string>("Address");
                txtRePassword.Text = dt.Rows[0].Field<string>("Password");
                txtPassword.Text = dt.Rows[0].Field<string>("Password");
                txtEmail.Text = dt.Rows[0].Field<string>("EmailAddress");
                txtSecurityQue.Text = dt2.Rows[0].Field<string>("Sequrity_Que");
            }
        }

        private void CustEditForm_Load(object sender, EventArgs e)
        {
            fill();
        }

        private void edit()
        {
            if (check_all())
            {
                Users users = new Users()
                {
                    Id = dt.Rows[0].Field<int>("Id"),
                    UserName = txtUserName.Text,
                    Password = txtRePassword.Text,
                    EmailAddress = txtEmail.Text,
                    Information_given = true,
                    UserType = 2,
                    UpdatedDate = dt.Rows[0].Field<DateTime>("UpdatedDate")
                };
                int affectedRowCount = dataAccess.Insert<Users>(users, true);

                DataTable dtu = dataAccess.GetData<Users>($"where UserName = '{txtUserName.Text}' and Password = '{txtRePassword.Text}'");
                if (affectedRowCount > 0)
                {
                    Customers customer = new Customers()
                    {
                        Id = dt2.Rows[0].Field<int>("Id"),
                        User_Id = dt.Rows[0].Field<int>("Id"),
                        Address = txtAddress.Text,
                        Contact = txtContact.Text,
                        Name = txtName.Text,
                        Sequrity_Que = txtSecurityQue.Text,
                        UpdatedDate = dt2.Rows[0].Field<DateTime>("UpdatedDate"),
                        Is_verified = true

                    };
                    affectedRowCount = dataAccess.Insert<Customers>(customer, true);

                    if (affectedRowCount > 0)
                    {
                        MessageBox.Show("Profile Edited Successfull");
                        CustHomeForm ch = new CustHomeForm(dt);
                        ch.Show();
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

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            edit();
        }

        private bool unique_check()
        {
            //DataTable dt;
            //dt = dataAccess.GetData<Users>($"where UserName = '{textBox2.Text}' or EmailAddress = '{textBox6.Text}'");
            //if (dt.Rows.Count > 0)
            //{
            //    if (dt.Rows[0].Field<string>("UserName").Equals(textBox2.Text))
            //    {
            //        errorProvider1.SetError(textBox2, "User Name already taken!!!");
            //        textBox2.Focus();
            //        return false;
            //    }
            //    else if (dt.Rows[0].Field<string>("EmailAddress").Equals(textBox6.Text))
            //    {
            //        errorProvider1.SetError(textBox6, "Email Already Used!!!");
            //        textBox6.Focus();
            //        return false;
            //    }
            //}
            return true;
        }

        private bool validationcheck()
        {
            if (!isvalidphone())
            {
                errorProvider1.SetError(txtContact, "This is not a valid contact number!!!");
                return false;
            }
            else if (txtContact.Text.Length < 11)
            {
                errorProvider1.SetError(txtContact, "There must be 11 number in your phone!!!");
                return false;
            }
            else if (txtContact.Text.Length > 11)
            {
                errorProvider1.SetError(txtContact, "There must be 11 number in your phone!!!");
                return false;
            }
            else if (!isValidEmail())
            {
                errorProvider1.SetError(txtEmail, "This is not a valid Email address!!!");
                return false;
            }

            return true;
        }

        private bool isvalidphone()
        {
            foreach (string p in phone)
            {
                if (txtContact.Text.StartsWith(p))
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
                if (txtEmail.Text.EndsWith(e))
                {
                    return true;
                }
            }
            return false;
        }

        private bool passwordcheck()
        {
            if (!txtRePassword.Text.Equals(txtPassword.Text))
            {
                errorProvider1.SetError(txtRePassword, "Password doesn't match");
                errorProvider1.SetError(txtPassword, "Password doesn't match");
                return false;
            }
            else if (txtRePassword.Text.Length < 8)
            {
                errorProvider1.SetError(txtRePassword, "Password must be at least 8 word");
                errorProvider1.SetError(txtPassword, "Password must be at least 8 word");
                return false;
            }
            return true;
        }

        private bool check_all()
        {
            return unique_check() && !check_empty() && validationcheck() && passwordcheck();
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
            if (txtSecurityQue.Text.Equals("Who is your favourite person?"))
            {
                errorProvider1.SetError(txtSecurityQue, "This field should be left blank!!");
                return true;
            }
            return false;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUserName.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRePassword.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtRePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContact.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSecurityQue.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtSecurityQue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                edit();
            }
        }
        private void lblEye1_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                lblEye1.Image = CourierManagement.Properties.Resources.Undo;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                lblEye1.Image = CourierManagement.Properties.Resources.Redo;
            }
        }
        private void lblEye2_Click(object sender, EventArgs e)
        {
            if (txtRePassword.UseSystemPasswordChar)
            {
                txtRePassword.UseSystemPasswordChar = false;
                lblEye2.Image = CourierManagement.Properties.Resources.Undo;
            }
            else
            {
                txtRePassword.UseSystemPasswordChar = true;
                lblEye2.Image = CourierManagement.Properties.Resources.Redo;
            }
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDeleteAcc_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you Want to Delete the Customer Account?", "Account deleting", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string id = dt.Rows[0].Field<int>("Id").ToString();
                int rowsAffected = dataAccess.Delete("Customers", "User_Id", id);
                if (rowsAffected > 0)
                {
                    rowsAffected = dataAccess.Delete("Users", "Id", id);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account Deleted Successfully");
                        LoginForm lf = new LoginForm();
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
                    MessageBox.Show("Something Went Wrong!!!");
                }
            }
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

    }
}
