
using CourierManagement.Admin_GUI;
using CourierManagement.Employee_GUI;
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
    public partial class AdminShowForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        int i;

        public AdminShowForm(DataTable dt,int i)
        {
            InitializeComponent();
            this.dt = dt;
            this.i = i;
            imin();
        }

        private void imin()
        {
            if(i == 1 || i==2)
            {
                label4.BackColor = Color.Firebrick;
            }
            else if(i == 3)
            {
                label13.BackColor = Color.Firebrick;
            }

        }

        private void AdminWorkerList_solForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm logout = new LoginForm();
            logout.Show();
            this.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Firebrick;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.Firebrick;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Firebrick;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Firebrick;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.DimGray;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.DimGray;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.DimGray;
        }
        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.DimGray;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminHomeForm home = new AdminHomeForm();
            home.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminAddBranchForm branch = new AdminAddBranchForm();
            branch.Show();
            this.Hide();
        }

        private void set_gridview()
        {
            dataGridView1.DataSource = dt;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.Columns[0].Visible = false;
        }

        private void AdminShowForm_Load(object sender, EventArgs e)
        {
            set_gridview();
        }

        private void go(int i)
        {
            
            DataTable dt2 = dataAccess.GetData<Employee>($"where User_id = '{i}'");
            AdminViewWorker ec = new AdminViewWorker(dt2, dt);
            ec.Show();
            this.Hide();
        }

        private void go2()
        {
            string sql = $"select e.User_Id,e.Name,e.Contact,ep.Problem from Employee as e, Employee_Problem as ep where e.User_Id = ep.User_id";
            DataTable dtw = dataAccess.Execute(sql);
            AdminShowForm add = new AdminShowForm(dtw, 2);
            add.Show();
            this.Hide();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(i == 1)
            {
                int i = (int)dataGridView1.Rows[e.RowIndex].Cells[11].Value;
                go(i);
            }
            else if (i == 2)
            {
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                DialogResult dialogResult = MessageBox.Show("Resoponse to his problem now?", "Problem solving", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    int rowsAffected = dataAccess.Delete("Employee_Problem", "User_id", id);
                    if (rowsAffected > 0)
                    {
                            MessageBox.Show("Problem solved Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!!");
                    }
                    go2();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Problem Didn't solved you will get it later.");
                    go2();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    int rowsAffected = dataAccess.Delete("Employee_Problem", "User_id", id);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Problem Cancelled!!!");
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!!");
                    }
                    go2();
                }
            }
            else if(i == 3)
            {
                DialogResult dialogResult = MessageBox.Show("Want to delete the Branch?", "Branch Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DialogResult dialog = MessageBox.Show("If you Delete the branch all the worker in this branch will also be deleted\nDo you want to delete?", "Confirmation", MessageBoxButtons.YesNo);
                    if(dialog == DialogResult.Yes)
                    {
                        string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        int rowsAffected = dataAccess.Delete("Branch_Info", "Id", id);
                        if (rowsAffected > 0)
                        {
                            rowsAffected = dataAccess.Delete("Employee", "Branch_id", id);
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Branch deleted Successfully\nAlso all the worker of the branch Deleted");
                                DataTable dt = dataAccess.GetData<Branch_Info>("");
                                AdminShowForm view = new AdminShowForm(dt, 3);
                                view.Show();
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

        private void label13_Click(object sender, EventArgs e)
        {
            AdminShowForm sh = new AdminShowForm(dataAccess.GetData<Branch_Info>(""), 3);
            sh.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
