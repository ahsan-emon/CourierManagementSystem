﻿using System;
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
            //textBox1.Text = "";
            textBox2.Text = "";
            textBox2.Focus();
            MessageBox.Show("Verified");
            label2.Image = CourierManagement.Properties.Resources.Pass1;
            button1.Location = new Point(388, 298);
            button1.Text = "Changed Password";
            label15.Visible = true;
            textBox3.Visible = true;
        }

        private void changePassword()
        {
            if (!passwordCheck())
            {
                MessageBox.Show("Password changed Successfully");
                LoginForm lf = new LoginForm();
                lf.Show();
                this.Hide();
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
            errorProvider1.SetError(textBox2, "");
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
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
    }
}
