﻿using CourierManagement.Entities;
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
            label23.BackColor = Color.Blue;
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

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            label27.BackColor = Color.Blue;
        }

        private void label27_MouseLeave(object sender, EventArgs e)
        {
            label27.BackColor = Color.FromArgb(0,0,64);
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            label26.BackColor = Color.Blue;
        }

        private void label22_MouseEnter(object sender, EventArgs e)
        {
            label22.BackColor = Color.Blue;
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


        private void label21_MouseLeave(object sender, EventArgs e)
        {
            label21.BackColor = Color.FromArgb(0, 0, 64);
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
                textBox1.Text = dt2.Rows[0].Field<string>("Name");
                textBox2.Text = dt.Rows[0].Field<string>("UserName");
                textBox7.Text = dt2.Rows[0].Field<string>("Contact");
                textBox5.Text = dt2.Rows[0].Field<string>("Address");
                textBox3.Text = dt.Rows[0].Field<string>("Password");
                textBox4.Text = dt.Rows[0].Field<string>("Password");
                textBox6.Text = dt.Rows[0].Field<string>("EmailAddress");
                textBox8.Text = dt2.Rows[0].Field<string>("Sequrity_Que");
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
                    UserName = textBox2.Text,
                    Password = textBox3.Text,
                    EmailAddress = textBox6.Text,
                    Information_given = true,
                    UserType = 2,
                    UpdatedDate = dt.Rows[0].Field<DateTime>("UpdatedDate")
                };
                int affectedRowCount = dataAccess.Insert<Users>(users, true);

                DataTable dtu = dataAccess.GetData<Users>($"where UserName = '{textBox2.Text}' and Password = '{textBox3.Text}'");
                if (affectedRowCount > 0)
                {
                    Customers customer = new Customers()
                    {
                        Id = dt2.Rows[0].Field<int>("Id"),
                        User_Id = dt.Rows[0].Field<int>("Id"),
                        Address = textBox5.Text,
                        Contact = textBox7.Text,
                        Name = textBox1.Text,
                        Sequrity_Que = textBox8.Text,
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

        private void button1_Click(object sender, EventArgs e)
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
                errorProvider1.SetError(textBox7, "This is not a valid contact number!!!");
                return false;
            }
            else if (textBox7.Text.Length < 11)
            {
                errorProvider1.SetError(textBox7, "There must be 11 number in your phone!!!");
                return false;
            }
            else if (textBox7.Text.Length > 11)
            {
                errorProvider1.SetError(textBox7, "There must be 11 number in your phone!!!");
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
                if (textBox7.Text.StartsWith(p))
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
                textBox4.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
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
                textBox7.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
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
                textBox5.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
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

                edit();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (textBox4.UseSystemPasswordChar)
            {
                textBox4.UseSystemPasswordChar = false;
                label4.Image = CourierManagement.Properties.Resources.Undo;
            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
                label4.Image = CourierManagement.Properties.Resources.Redo;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            if (textBox3.UseSystemPasswordChar)
            {
                textBox3.UseSystemPasswordChar = false;
                label3.Image = CourierManagement.Properties.Resources.Undo;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
                label3.Image = CourierManagement.Properties.Resources.Redo;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
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
