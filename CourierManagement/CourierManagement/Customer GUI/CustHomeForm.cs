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
    public partial class CustHomeForm : Form
    {
        DataTable dt;
        DataAccess dataAccess = new DataAccess();
        public CustHomeForm()
        {
            InitializeComponent();
        }
        public CustHomeForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void CustHomeForm_Load(object sender, EventArgs e)
        {
            DataTable dt2;
            dt2 = dataAccess.GetData<Customers>($"where User_Id = '{dt.Rows[0].Field<int>("Id")}'");
            if (dt2.Rows.Count > 0)
            {
                label5.Text = "Name: " + dt2.Rows[0].Field<string>("Name");
                label8.Text = "Email: " + dt.Rows[0].Field<string>("EmailAddress");
                label9.Text = "Phone No: " + dt2.Rows[0].Field<string>("Contact");
                label11.Text = "Address: " + dt2.Rows[0].Field<string>("Address");
            }
            else
            {
                label5.Text = "Name: ???";
                label8.Text = "Email: ???";
                label9.Text = "Phone No: ???";
                label11.Text = "Address: ???";
                MessageBox.Show("Something Went Wrong!!!");
            }
        }

        private void CustHomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            label27.BackColor = Color.Blue;
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            label26.BackColor = Color.Blue;
        }

        private void label22_MouseEnter(object sender, EventArgs e)
        {
            label22.BackColor = Color.Blue;
        }

        private void label24_MouseEnter(object sender, EventArgs e)
        {
            label24.BackColor = Color.Blue;
        }

        private void label23_MouseEnter(object sender, EventArgs e)
        {
            label23.BackColor = Color.Blue;
        }

        private void label21_MouseEnter(object sender, EventArgs e)
        {
            label21.BackColor = Color.Blue;
        }

        private void label25_MouseEnter(object sender, EventArgs e)
        {
            label25.BackColor = Color.Blue;
        }

        private void label27_MouseLeave(object sender, EventArgs e)
        {
            label27.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label26_MouseLeave(object sender, EventArgs e)
        {
            label26.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label22_MouseLeave(object sender, EventArgs e)
        {
            label22.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label24_MouseLeave(object sender, EventArgs e)
        {
            label24.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label21_MouseLeave(object sender, EventArgs e)
        {
            label21.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label25_MouseLeave(object sender, EventArgs e)
        {
            label25.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            label15.ForeColor = Color.White;
            label17.ForeColor = Color.White;
        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            label17.ForeColor = Color.White;
            label15.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.DarkBlue;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.DarkBlue;
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            label15.ForeColor = Color.DarkBlue;
            label17.ForeColor = Color.DarkBlue;
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            label15.ForeColor = Color.DarkBlue;
            label17.ForeColor = Color.DarkBlue;
        }

        private void label23_MouseLeave(object sender, EventArgs e)
        {
            label23.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label25_Click(object sender, EventArgs e)
        {
            LoginForm ad = new LoginForm();
            ad.Show();
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
            CustTrackForm track = new CustTrackForm();
            track.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            CustSerForm ser = new CustSerForm();
            ser.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            CustEditForm edit = new CustEditForm();
            edit.Show();
            this.Hide();
        }
        public void NewDel()
        {
            CustOrderForm add = new CustOrderForm();
            add.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            NewDel();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            NewDel();
        }
    }
}
