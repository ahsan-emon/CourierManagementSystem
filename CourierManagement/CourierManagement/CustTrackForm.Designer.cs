﻿namespace CourierManagement
{
    partial class CustTrackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.DarkGray;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 20);
            this.label14.TabIndex = 30;
            this.label14.Text = "Courier Service";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(184, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 393);
            this.panel1.TabIndex = 26;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(469, 345);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.LightBlue;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(162, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(165, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Tracking Product From";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label10.Location = new System.Drawing.Point(35, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Login/Logout";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.MediumAquamarine;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label6.Location = new System.Drawing.Point(328, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Customer Form";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 110F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::CourierManagement.Properties.Resources.Customer_p1;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.Location = new System.Drawing.Point(18, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 166);
            this.label7.TabIndex = 22;
            this.label7.Text = "  ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Cornsilk;
            this.label21.Image = global::CourierManagement.Properties.Resources.delete;
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Location = new System.Drawing.Point(11, 382);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(165, 29);
            this.label21.TabIndex = 63;
            this.label21.Text = "     Delete Acc.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Cornsilk;
            this.label22.Image = global::CourierManagement.Properties.Resources.service_history;
            this.label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label22.Location = new System.Drawing.Point(10, 289);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(167, 29);
            this.label22.TabIndex = 62;
            this.label22.Text = "     Ser. History";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Cornsilk;
            this.label23.Image = global::CourierManagement.Properties.Resources.edit_profile1;
            this.label23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label23.Location = new System.Drawing.Point(10, 351);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(167, 29);
            this.label23.TabIndex = 61;
            this.label23.Text = "     Edit Profile ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Cornsilk;
            this.label24.Image = global::CourierManagement.Properties.Resources.Setting;
            this.label24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label24.Location = new System.Drawing.Point(11, 320);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(166, 29);
            this.label24.TabIndex = 60;
            this.label24.Text = "         Setting    ";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Cornsilk;
            this.label25.Image = global::CourierManagement.Properties.Resources.logOut1;
            this.label25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label25.Location = new System.Drawing.Point(11, 413);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(165, 29);
            this.label25.TabIndex = 59;
            this.label25.Text = "         Logout    ";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Cornsilk;
            this.label26.Image = global::CourierManagement.Properties.Resources.tracking;
            this.label26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label26.Location = new System.Drawing.Point(10, 258);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(167, 29);
            this.label26.TabIndex = 58;
            this.label26.Text = "    Track Order";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Cornsilk;
            this.label27.Image = global::CourierManagement.Properties.Resources.home1;
            this.label27.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label27.Location = new System.Drawing.Point(9, 227);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(168, 29);
            this.label27.TabIndex = 57;
            this.label27.Text = "         Home      ";
            // 
            // CustTrackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(662, 453);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "CustTrackForm";
            this.Text = "CustTrackForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustTrackForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
    }
}