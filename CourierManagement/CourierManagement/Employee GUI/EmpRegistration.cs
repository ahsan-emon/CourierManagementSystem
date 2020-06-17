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
        DataTable dt;
        string[] phone = { "017", "014", "013", "015", "019", "018", "016", "011" };
        public EmpRegistration()
        {
            InitializeComponent();
        }
        public EmpRegistration(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            cmbBloodGroup.SelectedItem = "A(+ve)";
        }

        private void EmpRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDateOfBirth.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dtpDateOfBirth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContact.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtEducationalQualification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBloodGroup.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEducationalQualification.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbBloodGroup_KeyDown(object sender, KeyEventArgs e)
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
                txtChangePassword.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtChangePassword_KeyDown(object sender, KeyEventArgs e)
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
                btnUpdateDocument.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            LoginForm back = new LoginForm();
            back.Show();
            this.Hide();
        }

        private bool passwordcheck()
        {
            if (!txtChangePassword.Text.Equals(txtRePassword.Text))
            {
                errorProvider1.SetError(txtChangePassword, "Password doesn't match");
                errorProvider1.SetError(txtRePassword, "Password doesn't match");
                return false;
            }
            else if (txtChangePassword.Text.Length < 8)
            {
                errorProvider1.SetError(txtChangePassword, "Password must be at least 8 word");
                errorProvider1.SetError(txtRePassword, "Password must be at least 8 word");
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
            DateTime dt2 = this.dtpDateOfBirth.Value.Date;
            DataTable dte = dataAccess.GetData<Employee>($"where User_id = '{dt.Rows[0].Field<int>("Id")}'");
            if (passwordcheck() && !check_empty() && isvalidphone())
            {

                Employee employee = new Employee()
                {
                    Id = dte.Rows[0].Field<int>("Id"),
                    Name = txtName.Text,
                    DOB = dt2,
                    Contact = txtContact.Text,
                    Qualification = txtEducationalQualification.Text,
                    Blood_Group = cmbBloodGroup.SelectedItem.ToString(),
                    Address = txtAddress.Text,
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
                        Password = txtChangePassword.Text,
                        EmailAddress = dt.Rows[0].Field<string>("EmailAddress"),
                        UpdatedDate = dt.Rows[0].Field<DateTime>("UpdatedDate"),
                        UserName = dt.Rows[0].Field<string>("UserName"),
                        UserType = dt.Rows[0].Field<int>("UserType")

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

        private void btnUpdateDocument_Click(object sender, EventArgs e)
        {
            update_document();
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtContact, "");
            if (!(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)8)))
            {
                e.Handled = true;
            }
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

        private void lblEye1_Click(object sender, EventArgs e)
        {
            if (txtChangePassword.UseSystemPasswordChar)
            {
                txtChangePassword.UseSystemPasswordChar = false;
                lblEye1.Image = CourierManagement.Properties.Resources.Redo;
            }
            else
            {
                txtChangePassword.UseSystemPasswordChar = true;
                lblEye1.Image = CourierManagement.Properties.Resources.Undo;
            }
        }

        private void lblEye2_Click(object sender, EventArgs e)
        {
            if (txtRePassword.UseSystemPasswordChar)
            {
                txtRePassword.UseSystemPasswordChar = false;
                lblEye2.Image = CourierManagement.Properties.Resources.Redo;
            }
            else
            {
                txtRePassword.UseSystemPasswordChar = true;
                lblEye2.Image = CourierManagement.Properties.Resources.Undo;
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
    }
}
