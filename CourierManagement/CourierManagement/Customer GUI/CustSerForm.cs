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
    public partial class CustSerForm : Form
    {
        public CustSerForm()
        {
            InitializeComponent();
            label22.BackColor = Color.Blue;
        }

        private void CustSerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            LoginForm ad = new LoginForm();
            ad.Show();
            this.Hide();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            CustHomeForm home = new CustHomeForm();
            home.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            CustTrackForm track = new CustTrackForm();
            track.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            CustEditForm edit = new CustEditForm();
            edit.Show();
            this.Hide();
        }

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            label27.BackColor = Color.Blue;
        }

        private void label27_MouseLeave(object sender, EventArgs e)
        {
            label27.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            label26.BackColor = Color.Blue;
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

        private void label26_MouseLeave(object sender, EventArgs e)
        {
            label26.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label24_MouseLeave(object sender, EventArgs e)
        {
            label24.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label23_MouseLeave(object sender, EventArgs e)
        {
            label23.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label21_MouseLeave(object sender, EventArgs e)
        {
            label21.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label25_MouseLeave(object sender, EventArgs e)
        {
            label25.BackColor = Color.FromArgb(0, 0, 64);
        }
    }
}
