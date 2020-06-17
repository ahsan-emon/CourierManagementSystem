
using CourierManagement.Admin_GUI;
using CourierManagement.Employee_GUI;
using CourierManagement.Entities;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CourierManagement
{
    public partial class AdminShowForm : Form
    {
        DataTable showTable,userTable;
        DataAccess dataAccess = new DataAccess();
        int i;

        public AdminShowForm(DataTable showTable,int i,DataTable userTable)
        {
            InitializeComponent();
            this.showTable = showTable;
            this.i = i;
            this.userTable = userTable;
            lblUserName.Text = userTable.Rows[0].Field<string>("UserName");
            lblSelect();
        }

        private void lblSelect()
        {
            if(i == 1 || i==2)
            {
                lblHome.BackColor = Color.Firebrick;
            }
            else if(i == 3)
            {
                lblAllBranch.BackColor = Color.Firebrick;
            }

        }

        private void AdminWorkerList_solForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void lblHome_MouseEnter(object sender, EventArgs e)
        {
            if (i == 3)
            {
                lblHome.BackColor = Color.Firebrick;
            }
        }

        private void lblAddBranch_MouseEnter(object sender, EventArgs e)
        {
            lblAddBranch.BackColor = Color.Firebrick;
        }

        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.Firebrick;
        }

        private void lblHome_MouseLeave(object sender, EventArgs e)
        {
            if (i == 3)
            {
                lblHome.BackColor = Color.DimGray;
            }
        }

        private void lblAddBranch_MouseLeave(object sender, EventArgs e)
        {
            lblAddBranch.BackColor = Color.DimGray;
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.DimGray;
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm(userTable);
            home.Show();
            this.Hide();
        }

        private void lblAddBranch_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm branch = new AdminAddBranchForm(userTable);
            branch.Show();
            this.Hide();
        }

        private void setGridView()
        {
            gridShowTable.DataSource = showTable;
            gridShowTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void AdminShowForm_Load(object sender, EventArgs e)
        {
            setGridView();

            setComboBox();
        }

        private void FormToGo(int i)
        {
            
            DataTable EmployeeTable = dataAccess.GetData<Employee>($"where User_id = '{i}'");
            AdminViewWorker AdminView = new AdminViewWorker(EmployeeTable,showTable,userTable);
            AdminView.Show();
            this.Hide();
        }

        private void FormToGo2()
        {
            string sql = $"select e.User_Id,e.Name,e.Contact,ep.Problem from Employee as e, Employee_Problem as ep where e.User_Id = ep.User_id";
            DataTable EmployeeTable = dataAccess.Execute(sql);
            AdminShowForm AdminShow = new AdminShowForm(EmployeeTable, 2,userTable);
            AdminShow.Show();
            this.Hide();
        }

        private void Action_According_Dialog_Result_1(DialogResult dialogResult, DataGridViewCellEventArgs e)
        {
            if (dialogResult == DialogResult.Yes)
            {
                string id = gridShowTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                int rowsAffected = dataAccess.Delete("Employee_Problem", "User_id", id);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Problem solved Successfully");
                }
                else
                {
                    MessageBox.Show("Something Went Wrong!!!");
                }
                FormToGo2();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Problem Didn't solved you will get it later.");
                FormToGo2();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                string id = gridShowTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                int rowsAffected = dataAccess.Delete("Employee_Problem", "User_id", id);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Problem Cancelled!!!");
                }
                else
                {
                    MessageBox.Show("Something Went Wrong!!!");
                }
                FormToGo2();
            }
        }

        private void Action_According_Dialog_Result_2(DialogResult dialogResult, DataGridViewCellEventArgs e) 
        {
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialog = MessageBox.Show("If you Delete the branch all the worker in this branch will also be deleted\nDo you want to delete?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    string id = gridShowTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                    int rowsAffected = dataAccess.Delete("Branch_Info", "Id", id);
                    if (rowsAffected > 0)
                    {
                        rowsAffected = dataAccess.Delete("Employee", "Branch_id", id);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Branch deleted Successfully\nAlso all the worker of the branch Deleted");
                            DataTable BranchTable = dataAccess.GetData<Branch>("");
                            AdminShowForm AdminShow = new AdminShowForm(BranchTable, 3, userTable);
                            AdminShow.Show();
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
        private void gridShowTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(i == 1)
            {
                int i = (int)gridShowTable.Rows[e.RowIndex].Cells[11].Value;
                FormToGo(i);
            }
            else if (i == 2)
            {
                MessageBox.Show(gridShowTable.Rows[e.RowIndex].Cells[3].Value.ToString());
                DialogResult dialogResult = MessageBox.Show("Resoponse to his problem now?", "Problem solving", MessageBoxButtons.YesNoCancel);

                Action_According_Dialog_Result_1(dialogResult,e);
            }
            else if(i == 3)
            {
                DialogResult dialogResult = MessageBox.Show("Want to delete the Branch?", "Branch Deletion", MessageBoxButtons.YesNo);

                Action_According_Dialog_Result_2(dialogResult,e);
            }
        }

        private void lblAllBranch_Click(object sender, EventArgs e)
        {
            AdminShowForm AdminShow = new AdminShowForm(dataAccess.GetData<Branch>(""), 3,userTable);
            AdminShow.Show();
            this.Hide();
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

        private void setComboBox()
        {
            if (i == 1)
            {
                cmbSearchBy.Items.Add("Name");
                cmbSearchBy.Items.Add("Address");
                cmbSearchBy.Items.Add("Contact");
                cmbSearchBy.SelectedIndex = 0;
                cmbShow.SelectedIndex = 0;
            }
            else if (i == 2)
            {
                cmbSearchBy.Items.Add("Name");
                cmbSearchBy.Items.Add("Address");
                cmbSearchBy.Items.Add("Contact");
                cmbSearchBy.SelectedIndex = 0;
                lblShow.Visible = false;
                cmbShow.Visible = false;
            }
            else if (i == 3)
            {
                cmbSearchBy.Items.Add("Branch Name");
                cmbSearchBy.Items.Add("Address");
                cmbSearchBy.SelectedIndex = 0;
                lblShow.Visible = false;
                cmbShow.Visible = false;
            }
        }

        private void search()
        {
            if (i == 1)
            {
                if (cmbSearchBy.SelectedIndex == 0)
                {
                    string sql = $"select * FROM Employee WHERE Name LIKE '%{txtSearch.Text}%'";
                    DataTable SearchedTable = dataAccess.Execute(sql);
                    gridShowTable.DataSource = SearchedTable;
                }
                else if (cmbSearchBy.SelectedIndex == 1)
                {
                    string sql = $"select * FROM Employee WHERE Address LIKE '%{txtSearch.Text}%'";
                    DataTable SearchedTable = dataAccess.Execute(sql);
                    gridShowTable.DataSource = SearchedTable;
                }
                else if (cmbSearchBy.SelectedIndex == 2)
                {
                    string sql = $"select * FROM Employee WHERE Contact LIKE '%{txtSearch.Text}%'";
                    DataTable SearchedTable = dataAccess.Execute(sql);
                    gridShowTable.DataSource = SearchedTable;
                }

            }
            else if (i == 2)
            {
                if (cmbSearchBy.SelectedIndex == 0)
                {
                    string sql = $"select e.User_Id,e.Name,e.Contact,ep.Problem from Employee as e, Employee_Problem as ep where e.User_Id = ep.User_id and e.Name LIKE '%{txtSearch.Text}%'";
                    DataTable SearchedTable = dataAccess.Execute(sql);
                    gridShowTable.DataSource = SearchedTable;
                }
                else if (cmbSearchBy.SelectedIndex == 1)
                {
                    string sql = $"select e.User_Id,e.Name,e.Contact,ep.Problem from Employee as e, Employee_Problem as ep where e.User_Id = ep.User_id and e.Address LIKE '%{txtSearch.Text}%'";
                    DataTable SearchedTable = dataAccess.Execute(sql);
                    gridShowTable.DataSource = SearchedTable;
                }
                else if (cmbSearchBy.SelectedIndex == 2)
                {
                    string sql = $"select e.User_Id,e.Name,e.Contact,ep.Problem from Employee as e, Employee_Problem as ep where e.User_Id = ep.User_id and e.Contact LIKE '%{txtSearch.Text}%'";
                    DataTable SearchedTable = dataAccess.Execute(sql);
                    gridShowTable.DataSource = SearchedTable;
                }
            }
            else if (i == 3)
            {
                if (cmbSearchBy.SelectedIndex == 0)
                {
                    string sql = $"select * FROM Branch_Info WHERE Branch_Name LIKE '%{txtSearch.Text}%'";
                    DataTable SearchedTable = dataAccess.Execute(sql);
                    gridShowTable.DataSource = SearchedTable;
                }
                else if (cmbSearchBy.SelectedIndex == 1)
                {
                    string sql = $"select * FROM Branch_Info WHERE Address LIKE '%{txtSearch.Text}%'";
                    DataTable SearchedTable = dataAccess.Execute(sql);
                    gridShowTable.DataSource = SearchedTable;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            search();
        }

        private void lblAllBranch_MouseEnter(object sender, EventArgs e)
        {
            if (i == 1 || i == 2)
            {
                lblAllBranch.BackColor = Color.Firebrick;
            }
        }

        private void cmbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbShow.SelectedIndex == 0)
            {
                string sql = $"select * FROM Employee";
                DataTable EmployeeTable = dataAccess.Execute(sql);
                gridShowTable.DataSource = EmployeeTable;
            }
            else if(cmbShow.SelectedIndex == 1)
            {
                string sql = $"select * FROM Employee WHERE Designation = '{0}'";
                DataTable EmployeeTable = dataAccess.Execute(sql);
                gridShowTable.DataSource = EmployeeTable;
            }
            else if (cmbShow.SelectedIndex == 2)
            {
                string sql = $"select * FROM Employee WHERE Designation = '{1}'";
                DataTable EmployeeTable = dataAccess.Execute(sql);
                gridShowTable.DataSource = EmployeeTable;
            }
            else if (cmbShow.SelectedIndex == 3)
            {
                string sql = $"select * FROM Employee WHERE Designation = '{2}'";
                DataTable EmployeeTable = dataAccess.Execute(sql);
                gridShowTable.DataSource = EmployeeTable;
            }
            else if (cmbShow.SelectedIndex == 4)
            {
                string sql = $"select * FROM Employee WHERE Designation = '{3}'";
                DataTable EmployeeTable = dataAccess.Execute(sql);
                gridShowTable.DataSource = EmployeeTable;
            }
        }

        private void lblAllBranch_MouseLeave(object sender, EventArgs e)
        {
            if (i == 1 || i == 2)
            {
                lblAllBranch.BackColor = Color.DimGray;
            }
        }
    }
}
