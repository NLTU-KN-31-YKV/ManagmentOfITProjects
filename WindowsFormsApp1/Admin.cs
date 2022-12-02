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
    public partial class Admin : Form
    {
        public string[,] matrix;
        DataTable dt;

        public Admin()
        {

            InitializeComponent();
            h.ConStr = "server=193.93.216.145; characterset = cp1251;  database=sqlkn20_2_kk; user=sqlkn20_2_kk; password=kn20_kk;";
            dt = h.myfunDt("SELECT * FROM Person");
            int kilk = dt.Rows.Count;
            MessageBox.Show(kilk.ToString());

            matrix = new string[kilk, 4];
            for (int i = 0; i < kilk; i++)
            {
                matrix[i, 0] = dt.Rows[i].Field<int>("idPerson").ToString();
                matrix[i, 1] = dt.Rows[i].Field<string>("Name");
                matrix[i, 2] = dt.Rows[i].Field<int>("Type").ToString();
                matrix[i, 3] = dt.Rows[i].Field<string>("Password");
                cbxUser.Items.Add(matrix[i, 1]);
            }
            cbxUser.Text = matrix[0, 1];
            txtPassword.UseSystemPasswordChar = true;
            cbxUser.Focus();

        }
        private void Avtorization()
        {
            bool flUser = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (String.Equals(cbxUser.Text.ToUpper(), matrix[i, 1].ToUpper()))
                {
                    flUser = true;
                    if (String.Equals(txtPassword.Text, matrix[i, 3]))
                    {
                        h.nameUser = matrix[i, 1];
                        h.typeUser = matrix[i, 2];
                        cbxUser.Text = "";
                        txtPassword.Text = "";
                        this.Hide();
                        Admin f0 = new Admin();
                        f0.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Введіть правильний пароль!", "Помилка авторизації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                    }
                }


            }
            if (!flUser)
            {
                MessageBox.Show("Користувач " + cbxUser.Text + "не зареєстрований в системі!" + "\nЗверніться до адміністратора...", "Помилка авторизації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxUser.Text = "";
                cbxUser.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Avtorization();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    static class h
    {
        public static string ConStr { get; set; }
        public static string typeUser { get; set; }
        public static string nameUser { get; set; }
        public static BindingSource bs1 { get; set; }

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

}
