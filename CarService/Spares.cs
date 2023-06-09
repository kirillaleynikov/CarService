using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;

namespace CarService
{
    public partial class Spares : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public Spares()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_spare", "Код запчасти");
            dataGridView1.Columns.Add("title_spare", "Название запчасти");
            dataGridView1.Columns.Add("amount_spare", "Кол-во на складе");
            dataGridView1.Columns.Add("price_spare", "Цена");
            dataGridView1.Columns.Add("mark_car", "Марка машины");
            dataGridView1.Columns.Add("country", "Страна производства");
            dataGridView1.Columns.Add("isNew", String.Empty);
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 120;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 200;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 130;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 170;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 150;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 150;
        }
        private void ReadSingleRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetDecimal(3), record.GetString(4), record.GetString(5), RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from spares";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRows(dgw, reader);
            }
            reader.Close();
        }
        private void DeleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
        }
        private void Update()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[6].Value;
                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from spares where id_spare = '{id}'";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var idSpare = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var titleSpare = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var amount = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var price = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var carMark = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var country = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var changeQuery = $"update spares set title_spare = '{titleSpare}', amount_spare = '{amount}', price_spare = '{price}', mark_car = '{carMark}', country = '{country}' where id_spare ='{idSpare}'";
                    var command = new SqlCommand(changeQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void Spares_Load(object sender, EventArgs e)
        {
            CreateColumns();
            dataGridView1.Columns[6].Visible = false;
            RefreshDataGrid(dataGridView1);
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from spares where concat (id_spare, title_spare, amount_spare, price_spare, mark_car, country) like '%" + textBoxForSearch.Text + "%'";
            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRows(dgw, reader);
            }
            reader.Close();
        }

        private void textBoxForSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void btnDeleteSpare_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы действительно хотите удалить запчасть?", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DeleteRow();
            Update();
        }

        private void btnGoToAddSpare_Click(object sender, EventArgs e)
        {
            AddSpare addSpare = new AddSpare();
            addSpare.Show();
            Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBoxIdSpare.Text = row.Cells[0].Value.ToString();
                textBoxAddTitleSpare.Text = row.Cells[1].Value.ToString();
                numericUpDown1.Text = row.Cells[2].Value.ToString();
                numericUpDown2.Text = row.Cells[3].Value.ToString();
                textBoxMark.Text = row.Cells[4].Value.ToString();
                textBoxCountry.Text = row.Cells[5].Value.ToString();
            }
            textBoxAddTitleSpare.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            textBoxMark.Enabled = true;
            textBoxCountry.Enabled = true;
            btnChange.Enabled = true;
        }
        private void Change()
        {
            var idSpare = textBoxIdSpare.Text;
            var titleSpare = textBoxAddTitleSpare.Text;
            var amount = numericUpDown1.Value.ToString();
            var price = numericUpDown2.Value.ToString();
            var mark = textBoxMark.Text;
            var country = textBoxCountry.Text;


            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRow].SetValues(idSpare, titleSpare, amount, price, mark, country);
                dataGridView1.Rows[selectedRow].Cells[6].Value = RowState.Modified;
            }
            textBoxIdSpare.Text = "";
            textBoxAddTitleSpare.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            textBoxMark.Text = "";
            textBoxCountry.Text = "";
            textBoxAddTitleSpare.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            textBoxMark.Enabled = false;
            textBoxCountry.Enabled = false;
            btnChange.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change();
            Update();
            textBoxAddTitleSpare.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            textBoxMark.Enabled = false;
            textBoxCountry.Enabled = false;
            btnChange.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            exApp.Columns.ColumnWidth = 30;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j <= dataGridView1.ColumnCount - 2; j++)
                {
                    wsh.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }
            exApp.Cells.HorizontalAlignment = 3;
            exApp.Cells[1, 1] = "Код запчасти";
            exApp.Cells[1, 2] = "Название";
            exApp.Cells[1, 3] = "Кол-во на складе";
            exApp.Cells[1, 4] = "Цена";
            exApp.Cells[1, 5] = "Марка машины";
            exApp.Cells[1, 6] = "Страна производства";
            exApp.Visible = true;
        }

        private void textBoxCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void Filter(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string Ot = textBoxOt.Text;
            string Do = textBoxDo.Text;
            string searchString = $"select * from spares where price_spare >= {Ot} and price_spare <= {Do}";
            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRows(dgw, reader);
            }
            reader.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter(dataGridView1);
        }

        private void Spares_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForEmployees menuForEmployees = new MenuForEmployees();
            menuForEmployees.Show();
        }
    }
}
