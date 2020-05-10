using CourierManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourierManagement.Employee_GUI
{
    public partial class EmpRegistration : Form
    {
        DataAccess dataAccess = new DataAccess();
        int userid;
        public EmpRegistration()
        {
            InitializeComponent();
        }
        public EmpRegistration(int id)
        {
            InitializeComponent();
            userid = id;
        }

        private void EmpRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
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
                button1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            LoginForm back = new LoginForm();
            back.Show();
            this.Hide();
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

        private void update_document()
        {
            //DateTime dt = this.dateTimePicker1.Value.Date;
            if (passwordcheck() && !check_empty())
            {
                Employee employee = new Employee()
                {
                    Name = textBox1.Text,
                    //DOB = dt,
                    Contact = textBox2.Text,
                    Qualification = textBox3.Text,
                    Blood_Group = comboBox1.SelectedItem.ToString(),
                    Address = textBox4.Text
                };

                int rowsAffected = dataAccess.Insert<Employee>(employee, true);
                if (rowsAffected > 0)
                {
                    Users user = new Users()
                    {
                        Password = textBox5.Text
                    };
                    rowsAffected = dataAccess.Insert<Users>(user, true);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Document Updated Successfully");
                        LoginForm lf = new LoginForm();
                        lf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_document();
        }
    }
}
