﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int a = 2;
        public Form1()
        {
            InitializeComponent();
        }

        private void таблиціБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stones f1 = new Stones();
            f1.ShowDialog();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About f2 = new About();
            f2.ShowDialog();
        }

        private void адмініструванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn f3 = new LogIn();
            f3.ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
