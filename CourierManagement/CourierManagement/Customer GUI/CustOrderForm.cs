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
    public partial class CustOrderForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        string[] phone = { "017", "014", "013", "015", "019", "018", "016", "011" };
        string[] mail = { "@gmail.com", "@yahoo.com", "@hotmail.com", "@mail.com", "@outlook.com" };
        public CustOrderForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            lblHome.BackColor = Color.Blue;
            label10.Text = dt.Rows[0].Field<string>("UserName");
        }

        private void CustNewDelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void lblEditProfile_Click(object sender, EventArgs e)
        {
            CustEditForm edit = new CustEditForm(dt);
            edit.Show();
            this.Hide();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void lblTrackOrder_MouseEnter(object sender, EventArgs e)
        {
            lblTrackOrder.BackColor = Color.Blue;
        }

        private void lblSerHistory_MouseEnter(object sender, EventArgs e)
        {
            lblSerHistory.BackColor = Color.Blue;
        }

        private void lblEditProfile_MouseEnter(object sender, EventArgs e)
        {
            lblEditProfile.BackColor = Color.Blue;
        }

        private void lblDeleteAcc_MouseEnter(object sender, EventArgs e)
        {
            lblDeleteAcc.BackColor = Color.Blue;
        }

        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.Blue;
        }

        private void lblTrackOrder_MouseLeave(object sender, EventArgs e)
        {
            lblTrackOrder.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblSerHistory_MouseLeave(object sender, EventArgs e)
        {
            lblSerHistory.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblEditProfile_MouseLeave(object sender, EventArgs e)
        {
            lblEditProfile.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblDeleteAcc_MouseLeave(object sender, EventArgs e)
        {
            lblDeleteAcc.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void txtDesProduct_Enter(object sender, EventArgs e)
        {
            if (txtDesProduct.Text.Equals("Describe the Product"))
            {
                txtDesProduct.Text = "";
            }
        }

        private void txtDesProduct_Leave(object sender, EventArgs e)
        {
            if (txtDesProduct.Text.Equals(""))
            {
                txtDesProduct.Text = "Describe the Product";
                txtDesProduct.ForeColor = Color.Gray;
            }
        }

        private void txtDesProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDesProduct.ForeColor = Color.Black;
            errorProvider1.SetError(txtDesProduct, "");
        }

        private void txtQuantity_Enter(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Equals("Quantity"))
            {
                txtQuantity.Text = "";
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Equals(""))
            {
                txtQuantity.Text = "Quantity";
                txtQuantity.ForeColor = Color.Gray;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)8)))
            {
                e.Handled = true;
            }
            txtQuantity.ForeColor = Color.Black;
            errorProvider1.SetError(txtQuantity, "");
        }

        private void txtFullName_Enter(object sender, EventArgs e)
        {
            if (txtFullName.Text.Equals("Full Name"))
            {
                txtFullName.Text = "";
            }
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            if (txtFullName.Text.Equals(""))
            {
                txtFullName.Text = "Full Name";
                txtFullName.ForeColor = Color.Gray;
            }
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtFullName.ForeColor = Color.Black;
            errorProvider1.SetError(txtFullName, "");
        }

        private void txtContactNumber_Enter(object sender, EventArgs e)
        {
            if (txtContactNumber.Text.Equals("Contact Number"))
            {
                txtContactNumber.Text = "";
            }
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {
            if (txtContactNumber.Text.Equals(""))
            {
                txtContactNumber.Text = "Contact Number";
                txtContactNumber.ForeColor = Color.Gray;
            }
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtContactNumber.ForeColor = Color.Black;
            errorProvider1.SetError(txtContactNumber, "");
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text.Equals("Email*"))
            {
                txtEmail.Text = "";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Equals(""))
            {
                txtEmail.Text = "Email*";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmail.ForeColor = Color.Black;
            errorProvider1.SetError(txtEmail, "");
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if (txtAddress.Text.Equals("Address"))
            {
                txtAddress.Text = "";
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text.Equals(""))
            {
                txtAddress.Text = "Address";
                txtAddress.ForeColor = Color.Gray;
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAddress.ForeColor = Color.Black;
            errorProvider1.SetError(txtAddress, "");
        }

        private DataTable Branch()
        {
            DataTable dt2 = dataAccess.GetData<Branch>("");
            return dt2;
        }

        private void CustOrderForm_Load(object sender, EventArgs e)
        {
            cmbBranch.DisplayMember = "Branch_Name";
            cmbBranch.ValueMember = "Id";
            cmbBranch.DataSource = Branch();

            cmbBrach1.DisplayMember = "Branch_Name";
            cmbBrach1.ValueMember = "Id";
            cmbBrach1.DataSource = Branch();
        }

        private void cmbSelectCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
                txtDesProduct.ReadOnly = false;
                txtDesProduct.Focus();
                return;
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPaymentMethod.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSize.Focus();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBranch.Focus();
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFullName.Focus();
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContactNumber.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtContactNumber_KeyDown(object sender, KeyEventArgs e)
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
                cmbBrach1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbBrach1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSubmitOrder.Focus();
        }

        private bool isvalidphone()
        {
            foreach (string p in phone)
            {
                if (txtContactNumber.Text.StartsWith(p))
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

        private bool validation()
        {
            if (!isvalidphone())
            {
                errorProvider1.SetError(txtContactNumber, "Not a valid Phone Number");
                return false;
            }
            else if (!isValidEmail())
            {
                errorProvider1.SetError(txtEmail, "Not a valid Email");
                return false;
            }

            return true;
        }

        private int category()
        {
            int c;
            string desi = cmbSelectCategory.SelectedItem.ToString();
            if (desi.Equals("Document"))
            {
                c = (int)Product.ProductCategoryEnum.Document;
            }
            else if (desi.Equals("Package"))
            {
                c = (int)Product.ProductCategoryEnum.Package;
            }
            else if (desi.Equals("Accessories"))
            {
                c = (int)Product.ProductCategoryEnum.Accessories;
            }
            else if (desi.Equals("Electronics"))
            {
                c = (int)Product.ProductCategoryEnum.Electronics;
            }
            else if (desi.Equals("Groceries"))
            {
                c = (int)Product.ProductCategoryEnum.Groceries;
            }
            else
            {
                c = (int)Product.ProductCategoryEnum.Others;
            }
            return c;
        }

        private int pType()
        {
            int c;
            string desi = cmbSize.SelectedItem.ToString();
            if (desi.Equals("Extra_Large"))
            {
                c = (int)Product.ProductTypeEnum.Extra_Large;
            }
            else if (desi.Equals("Large"))
            {
                c = (int)Product.ProductTypeEnum.Large;
            }
            else if (desi.Equals("Medium"))
            {
                c = (int)Product.ProductTypeEnum.Medium;
            }
            else
            {
                c = (int)Product.ProductTypeEnum.Small;
            }
            return c;
        }

        private string rEmail()
        {
            if (txtEmail.Text.Equals("Email*"))
            {
                string s = "";
                return s;
            }
            else
            {
                string s = txtEmail.Text;
                return s;
            }
        }
        private Product fill_data()
        {
            Product pi = new Product()
            {
                Customer_id = dt.Rows[0].Field<int>("Id"),
                UpdatedDate = DateTime.Now,
                PaymentMethod = (int)Product.PaymentMethodEnum.Cash,
                ProductCategory = category(),
                ProductType = pType(),
                Description = txtDesProduct.Text,
                Receiving_B_id = Int32.Parse(cmbBrach1.SelectedValue.ToString()),
                Sending_B_id = Int32.Parse(cmbBranch.SelectedValue.ToString()),
                RecieverAddress = txtAddress.Text,
                RecieverName = txtFullName.Text,
                RecieverContact = txtContactNumber.Text,
                RecieverEmail = rEmail(),
                Delivery_charge = Price.set_Price(cmbBrach1.SelectedValue.ToString(), cmbBranch.SelectedValue.ToString()),
                Receiving_Manager_id = -1,
                Sending_Manager_id = -1,
                Product_State = (int)Product.ProductStateEnum.Not_yet_Received,
                Release_Date = DateTime.Now.AddDays(3)

            };
            return pi;
        }
        private void submit()
        {
            if (validation())
            {
                DialogResult di =  MessageBox.Show($"Your Delivery charge will be {Price.set_Price(cmbBrach1.SelectedValue.ToString(), cmbBranch.SelectedValue.ToString()).ToString()} \ndo you want to confirm", "Confirmation", MessageBoxButtons.YesNo);

                if(di == DialogResult.Yes)
                {
                    Product newproduct = fill_data();

                    int rowsAffected = dataAccess.Insert<Product>(newproduct, true);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Your Requested Submitted Successfully");
                        CustHomeForm ch = new CustHomeForm(dt);
                        ch.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please be sure before confirming");
                }

            }
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void txtDesProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBrach1.Focus();
                e.SuppressKeyPress = true;
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
    }
}
