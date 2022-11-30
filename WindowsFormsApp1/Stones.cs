using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Stones : Form
    {
        public Stones()
        {
            InitializeComponent();
        }
        static class h
        {
            //  internal static string conStr;

            public static string ConStr { get; set; }
            public static string typeUser { get; set; }
            public static string nameUser { get; set; }
            public static BindingSource bs1 { get; set; }
            public static string curVa10 { get; set; }
            public static string keyName { get; set; }
            public static string pathToPhoto { get; set; }

            public static DataTable myfunDt(string commandString)

            {
                DataTable dt = new DataTable();
                using (MySqlConnection con = new MySqlConnection(h.ConStr))
                {
                    MySqlCommand cmd = new MySqlCommand(commandString, con);

                    try
                    {
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dt.Load(dr);
                            }
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неможливо з'єднатися з SQL-сервером", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return dt;
            }

          


        }
        private void button1_Click(object sender, EventArgs e)
        {
            h.keyName = dataGridView1.Columns[0].Name;
            h.curVa10 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            Stones f3 = new Stones();
            f3.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM Region");
            dataGridView1.DataSource = h.bs1;
        }
    }
}
