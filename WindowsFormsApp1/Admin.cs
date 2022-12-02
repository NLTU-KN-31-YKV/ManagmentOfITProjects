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
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class LogIn : Form
    {
        public string[,] matrix;
        DataTable dt;

        public LogIn()
        {
            InitializeComponent();

            // h.ConStr = "Data Source = 127.0.0.1,3306;Network Library = DBMSSOCN; Initial Catalog = yitp;User ID = root; Password = root";
            h.ConStr = "Server= localhost; Database= yitp; User ID = root; Password = root ";
            dt = h.myfunDt("SELECT * FROM person");
            int kilk = dt.Rows.Count;
            //MessageBox.Show(kilk.ToString());

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
            //textBox1.Text = h.EncriptedPassword(txtPassword.Text);
            bool flUser = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (String.Equals(cbxUser.Text.ToUpper(), matrix[i, 1].ToUpper()))
                {
                    flUser = true;
                    if (String.Equals(h.EncriptedPassword(txtPassword.Text), matrix[i, 3]))
                    {
                        h.nameUser = matrix[i, 1];
                        h.typeUser = matrix[i, 2];
                        cbxUser.Text = "";
                        txtPassword.Text = "";
                        this.Hide();
                        Form1 f0 = new Form1();
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

        private void cbxUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Avtorization();
            else if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Avtorization();
        }
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Avtorization();
            else if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        public static string EncriptedPassword(string s)
        {
            if (string.Compare(s, "null", true) == 0)
                return "NULL";
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHach = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHach)
                hash += String.Format("{0:x2}", b);
            return hash;
        }


    }

}
