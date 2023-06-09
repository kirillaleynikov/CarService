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
using Excel = Microsoft.Office.Interop.Excel;

namespace CarService
{
    public partial class Workers : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public Workers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_worker", "Код сотрудника");
            dataGridView1.Columns.Add("name_worker", "ФИО сотрудника");
            dataGridView1.Columns.Add("phone_number_worker", "Номер телефона сотрудника");
            dataGridView1.Columns.Add("isNew", String.Empty);
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 120;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 200;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 190;
        }
        private void ReadSingleRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from workers";
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
                dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;
        }
        private void Update()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[3].Value;
                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from workers where id_worker = '{id}'";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var idWorker = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var nameWorker = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var phoneNumber = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var changeQuery = $"update workers set name_worker = '{nameWorker}', phone_number_worker = '{phoneNumber}' where id_worker ='{idWorker}'";
                    var command = new SqlCommand(changeQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Workers_Load(object sender, EventArgs e)
        {
            CreateColumns();
            dataGridView1.Columns[3].Visible = false;
            RefreshDataGrid(dataGridView1);
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from workers where concat (id_worker, name_worker, phone_number_worker) like '%" + textBoxForSearch.Text + "%'";
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

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы действительно хотите удалить сотрудника?", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DeleteRow();
            Update();
        }

        private void btnGoToAddWorker_Click(object sender, EventArgs e)
        {
            AddWorker addWorker = new AddWorker();
            addWorker.Show();
            Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBoxIdWorker.Text = row.Cells[0].Value.ToString();
                textBoxAddName.Text = row.Cells[1].Value.ToString();
                textBoxAddPhoneNumber.Text = row.Cells[2].Value.ToString();
            }
            textBoxAddName.Enabled = true;
            textBoxAddPhoneNumber.Enabled = true;
            btnChange.Enabled = true;
        }
        private void Change()
        {
            var idWorker = textBoxIdWorker.Text;
            var nameWorker = textBoxAddName.Text;
            var phoneNumber = textBoxAddPhoneNumber.Text;
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRow].SetValues(idWorker, nameWorker, phoneNumber);
                dataGridView1.Rows[selectedRow].Cells[3].Value = RowState.Modified;
            }
            textBoxIdWorker.Text = "";
            textBoxAddName.Text = "";
            textBoxAddPhoneNumber.Text = "";
            btnChange.Enabled = false;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Change();
            Update();
            textBoxAddName.Enabled = false;
            textBoxAddPhoneNumber.Enabled = false;
            btnChange.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
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
            exApp.Cells[1, 1] = "Код сотрудника";
            exApp.Cells[1, 2] = "ФИО сотрудника";
            exApp.Cells[1, 3] = "Номер телефона";
            exApp.Visible = true;
        }

        private void textBoxAddName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void Workers_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForEmployees menuForEmployees = new MenuForEmployees();
            menuForEmployees.Show();
        }
    }
}
