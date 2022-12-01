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
    public partial class Stones : Form
    {
        int rowEdit = -1;
        int colEdit = -1;
        public Stones()
        {
            InitializeComponent();
        }

        private void Stone_Load(object sender, EventArgs e)
        {
            h.bs1 = new BindingSource();
            h.bs1.DataSource = h.myfunDt("SELECT * from Stone");
            dataGridView1.DataSource = h.bs1;
            StoneFormatDGW();
            bindingNavigator1.BindingSource = h.bs1;

            h.bs1.Sort = "Форма";
        }

        private void StoneFormatDGW()
        {
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 45;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 30;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.GridColor = Color.IndianRed;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.MistyRose;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Tomato;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
            dataGridView1.Columns[0].HeaderText = "idS";
            dataGridView1.Columns[1].HeaderText = "Форма";
            dataGridView1.Columns[2].HeaderText = "Колір";
            dataGridView1.Columns[3].HeaderText = "Текстура";
            dataGridView1.Columns[4].HeaderText = "Розмір";
            dataGridView1.Columns[5].HeaderText = "Якість";
            dataGridView1.Columns[6].HeaderText = "idVl";
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Italic);
            dataGridView1.Columns[0].HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Regular);
            dataGridView1.Columns[1].HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Regular);
            dataGridView1.Columns[2].HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Regular);
            dataGridView1.Columns[3].HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Regular);
            dataGridView1.Columns[4].HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Regular);
            dataGridView1.Columns[5].HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Regular);
            dataGridView1.Columns[6].HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Regular);
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType !=
                typeof(DataGridViewTextBoxEditingControl)) return;

            rowEdit = dataGridView1.CurrentCell.RowIndex;
            colEdit = dataGridView1.CurrentCell.ColumnIndex;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (colEdit == -1) return;
            var c = colEdit;
            var r = rowEdit;

            colEdit = -1;
            rowEdit = -1;

            dataGridView1.CurrentCell = dataGridView1[c, r];

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else
            {
                int ri, ci;
                if (e.KeyCode == Keys.Enter)
                {
                    ri = dataGridView1.CurrentCell.RowIndex;
                    ci = dataGridView1.CurrentCell.ColumnIndex;
                    e.SuppressKeyPress = true;

                    if (dataGridView1.Columns.Count > ci + 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[ri].Cells[ci + 1];
                        return;
                    }
                    else
                    {
                        if (dataGridView1.Rows.Count > ri + 1)
                            dataGridView1.CurrentCell = dataGridView1.Rows[ri + 1].Cells[0];
                    }
                }

            }
        }
    }
}
