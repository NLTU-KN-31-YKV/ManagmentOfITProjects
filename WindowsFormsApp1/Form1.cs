using System;
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
            Admin f3 = new Admin();
            f3.ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
