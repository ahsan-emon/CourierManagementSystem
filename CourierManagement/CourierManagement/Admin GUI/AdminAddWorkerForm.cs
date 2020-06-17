
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
    public partial class AdminAddWorkerForm : Form
    {
        DataTable UserTable;
        DataAccess dataAccess = new DataAccess();
        string[] mail = { "@gmail.com", "@yahoo.com", "@hotmail.com", "@mail.com", "@outlook.com" };
        string[] phone = { "017", "014", "013", "015", "019", "018", "016", "011" };
        public AdminAddWorkerForm(DataTable UserTable)
        {
            InitializeComponent();
            lblHome.BackColor = Color.Firebrick;
            this.UserTable = UserTable;
            label10.Text = UserTable.Rows[0].Field<string>("UserName");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.Firebrick;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Firebrick;
        }

        private void label13_MouseEnter(object sender, EventArgs e)
        {
            label13.BackColor = Color.Firebrick;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Firebrick;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.DimGray;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DimGray;
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.BackColor = Color.DimGray;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DimGray;
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm(UserTable);
            home.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm add = new AdminAddBranchForm(UserTable);
            add.Show();
            this.Hide();
        }

        private void AdminAddWorkerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContact.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDesignation.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_worker();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBranch.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void add_worker()
        {
            if(validationcheck() && unique_check())
            {
                Users user = new Users()
                {
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    EmailAddress = txtEmail.Text,
                    Information_given = false,
                    UserType = 1,
                    UpdatedDate = DateTime.Now
                };
                int affectedRowCount = dataAccess.Insert<Users>(user, true);
                DataTable dt = dataAccess.GetData<Users>($"where UserName = '{txtUserName.Text}' and Password = '{txtPassword.Text}'");
                if (affectedRowCount > 0)
                {
                    string desi = cmbDesignation.SelectedItem.ToString();
                    int desig;
                    if (desi.Equals("Manager"))
                    {
                        desig = (int)Employee.DesignationEnum.Manager;
                    }
                    else if (desi.Equals("Worker"))
                    {
                        desig = (int)Employee.DesignationEnum.Worker;
                    }
                    else if (desi.Equals("Driver"))
                    {
                        desig = (int)Employee.DesignationEnum.Driver;
                    }
                    else
                    {
                        desig = (int)Employee.DesignationEnum.Delivery_boy;
                    }
                    Employee employee = new Employee()
                    {
                        User_id = dt.Rows[0].Field<int>("Id"),
                        Contact = txtContact.Text,
                        UpdatedDate = DateTime.Now,
                        Salary = float.Parse(txtSalary.Text),
                        Branch_id = (int)cmbBranch.SelectedValue,
                        Designation = desig,
                        Name = "",
                        Address="",
                        Blood_Group ="",
                        Bonus = 0,
                        DOB = DateTime.Now,
                        Joining_date = DateTime.Now,
                        Qualification = ""
                    };
                    affectedRowCount = dataAccess.Insert<Employee>(employee, true);

                    if (affectedRowCount > 0)
                    {
                        MessageBox.Show("Worker Added Successfully");
                        AdminHomeForm lf = new AdminHomeForm(dt);
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
                    MessageBox.Show("Unable to Add worker!!!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_worker();
        }

        private DataTable Branch()
        {
            DataTable dt = dataAccess.GetData<Branch>("");
            return dt;
        }

        private void AdminAddWorkerForm_Load(object sender, EventArgs e)
        {
            DataTable dt = Branch();
            cmbBranch.DisplayMember = "Branch_Name";
            cmbBranch.ValueMember = "Id";
            cmbBranch.DataSource = dt;
            cmbDesignation.SelectedItem = "Manager";
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSalary.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private bool unique_check()
        {
            DataTable dt;
            dt = dataAccess.GetData<Users>($"where UserName = '{txtUserName.Text}' or EmailAddress = '{txtEmail.Text}'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0].Field<string>("UserName").Equals(txtUserName.Text))
                {
                    errorProvider1.SetError(txtUserName, "User Name already taken!!!");
                    txtUserName.Focus();
                    return false;
                }
                else if (dt.Rows[0].Field<string>("EmailAddress").Equals(txtEmail.Text))
                {
                    errorProvider1.SetError(txtEmail, "Email Already Used!!!");
                    txtEmail.Focus();
                    return false;
                }
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

        private bool validationcheck()
        {
            if (!isvalidphone())
            {
                errorProvider1.SetError(txtContact, "This is not a valid contact number!!!");
                txtContact.Focus();
                return false;
            }
            else if (txtContact.Text.Length < 11)
            {
                errorProvider1.SetError(txtContact, "There must be 11 number in your phone!!!");
                txtContact.Focus();
                return false;
            }
            else if (txtContact.Text.Length > 11)
            {
                errorProvider1.SetError(txtContact, "There must be 11 number in your phone!!!");
                txtContact.Focus();
                return false;
            }
            else if (!isValidEmail())
            {
                errorProvider1.SetError(txtEmail, "This is not a valid Email address!!!");
                txtEmail.Focus();
                return false;
            }
            else if (txtPassword.Text.Length < 8)
            {
                errorProvider1.SetError(txtPassword, "Password should be atleast 8 word");
                txtPassword.Focus();
                return false;
            }

            return true;
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

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtUserName, "");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtPassword, "");
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtEmail, "");
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtContact, "");
            if (!(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)8)))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtSalary, "");
            if (!(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)8)))
            {
                e.Handled = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataAccess.GetData<Branch>("");
            AdminShowForm view = new AdminShowForm(dt2,3,UserTable);
            view.Show();
            this.Hide();
        }

        private void lblEye_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                lblEye.Image = CourierManagement.Properties.Resources.Undo;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                lblEye.Image = CourierManagement.Properties.Resources.Redo;
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
