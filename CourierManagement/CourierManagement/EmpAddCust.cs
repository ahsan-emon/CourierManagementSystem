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
    public partial class EmpAddCust : Form
    {
        public EmpAddCust()
        {
            InitializeComponent();
        }

        private void EmpAddCust_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
