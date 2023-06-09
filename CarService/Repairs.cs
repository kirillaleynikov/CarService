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
    public partial class Repairs : Form
    {
        public DateTime dateTime = DateTime.Today;
        DataBase dataBase = new DataBase();
        int selectedRow;
        public Repairs()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void CreateColumns() //создание столбцов в dataGridView
        {
            dataGridView1.Columns.Add("id_repair", "Код ремонта");
            dataGridView1.Columns.Add("name_client", "ФИО клиента");
            dataGridView1.Columns.Add("car_mark", "Марка машины");
            dataGridView1.Columns.Add("state_number", "Гос номер");
            dataGridView1.Columns.Add("phone_number", "Номер телефона клиента");
            dataGridView1.Columns.Add("start_day", "Дата начала ремонта");
            dataGridView1.Columns.Add("end_day", "Дата окончания ремонта");
            dataGridView1.Columns.Add("status_repair", "Статус ремонта");
            dataGridView1.Columns.Add("price", "Стоимость ремонта");
            dataGridView1.Columns.Add("worker", "Ответственный сотрудник");
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
            column5.Width = 90;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 90;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 90;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 90;
            DataGridViewColumn column9 = dataGridView1.Columns[9];
            column9.Width = 200;
        }
        private void ReadSingleRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetDecimal(8), record.GetString(9), RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from repairs";
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
                dataGridView1.Rows[index].Cells[10].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[10].Value = RowState.Deleted;
        }
        private void Update()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[10].Value;
                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from repairs where id_repair = '{id}'";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var idRepair = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var clientName = dataGridView1.Rows[index].Cells[1].Value;
                    var carMark = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var stateNumber = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var phoneNumber = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var startRepair = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var endRepair = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var status = dataGridView1.Rows[index].Cells[7].Value;
                    var price = dataGridView1.Rows[index].Cells[8].Value.ToString();
                    var worker = dataGridView1.Rows[index].Cells[9].Value;
                    var changeQuery = $"update repairs set name_client = '{clientName}', car_mark = '{carMark}', state_number = '{stateNumber}', phone_number = '{phoneNumber}', start_day = '{startRepair}', end_day = '{endRepair}', status_repair = '{status}', price = '{price}', worker = '{worker}' where id_repair ='{idRepair}'";
                    var command = new SqlCommand(changeQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void btnGoToAddRepair_Click(object sender, EventArgs e)
        {
            AddRepair addRepair = new AddRepair();
            addRepair.Show();
            Hide();
        }

        private void Repairs_Load(object sender, EventArgs e)
        {
            CreateColumns();
            dataGridView1.Columns[10].Visible = false;
            RefreshDataGrid(dataGridView1);
            dataBase.openConnection();
            string queryString = $"select name_client from clients";
            string queryString2 = $"select name_worker from workers";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            var read = command.ExecuteReader();
            while (read.Read())
            {
                comboBoxClient.Items.Add(read[0].ToString());
            }
            read.Close();
            comboBoxClient.SelectedIndex = 0;
            SqlCommand command2 = new SqlCommand(queryString2, dataBase.GetConnection());
            var read2 = command2.ExecuteReader();
            while (read2.Read())
            {
                comboBoxWorker.Items.Add(read2[0].ToString());
            }
            read2.Close();
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from repairs where concat (id_repair, name_client, car_mark, state_number, phone_number, start_day, end_day, status_repair, price, worker) like '%" + textBoxForSearch.Text + "%'";
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

        private void btnDeleteRepair_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы действительно хотите удалить ремонт?", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DeleteRow();
            Update();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBoxIdRepair.Text = row.Cells[0].Value.ToString();
                comboBoxClient.Text = row.Cells[1].Value.ToString();
                textBoxCarMark.Text = row.Cells[2].Value.ToString();
                textBoxStateNumber.Text = row.Cells[3].Value.ToString();
                textBoxPhoneNumber.Text = row.Cells[4].Value.ToString();
                dateTimePicker1.Text = row.Cells[5].Value.ToString();
                dateTimePicker2.Text = row.Cells[6].Value.ToString();
                comboBoxStatus.Text = row.Cells[7].Value.ToString();
                numericUpDownPrice.Text = row.Cells[8].Value.ToString();
                comboBoxWorker.Text = row.Cells[9].Value.ToString();
                btnChange.Enabled = true;
            }
            comboBoxClient.Enabled = true;
            textBoxCarMark.Enabled = true;
            textBoxStateNumber.Enabled = true;
            textBoxPhoneNumber.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            comboBoxStatus.Enabled = true;
            numericUpDownPrice.Enabled = true;
            comboBoxWorker.Enabled = true;
            btnChange.Enabled = true;
        }
        private void Change()
        {
            var idRepair = textBoxIdRepair.Text;
            var client = comboBoxClient.Text;
            var carMark = textBoxCarMark.Text;
            var stateNumber = textBoxStateNumber.Text;
            var phoneNumber = textBoxPhoneNumber.Text;
            var startRepair = dateTimePicker1.Text;
            var endRepair = dateTimePicker2.Text;
            var status = comboBoxStatus.Text;
            var price = numericUpDownPrice.Text;
            var worker = comboBoxWorker.Text;
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRow].SetValues(idRepair, client, carMark, stateNumber, phoneNumber, startRepair, endRepair, status, price, worker);
                dataGridView1.Rows[selectedRow].Cells[10].Value = RowState.Modified;
            }
            textBoxIdRepair.Text = "";
            comboBoxClient.Text = "";
            textBoxCarMark.Text = "";
            textBoxStateNumber.Text = "";
            textBoxPhoneNumber.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            comboBoxStatus.Text = "";
            numericUpDownPrice.Text = "";
            comboBoxWorker.Text = "";
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Change();
            Update();
            comboBoxClient.Enabled = false;
            textBoxCarMark.Enabled = false;
            textBoxStateNumber.Enabled = false;
            textBoxPhoneNumber.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBoxStatus.Enabled = false;
            numericUpDownPrice.Enabled = false;
            comboBoxWorker.Enabled = false;
            btnChange.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //экспорт данных в Excel 
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
            exApp.Cells[1, 1] = "Код ремонта";
            exApp.Cells[1, 2] = "Клиент";
            exApp.Cells[1, 3] = "Марка машина";
            exApp.Cells[1, 4] = "Гос номер";
            exApp.Cells[1, 5] = "Номер телефона клиента";
            exApp.Cells[1, 6] = "Дата начала ремонта";
            exApp.Cells[1, 7] = "Дата окончания ремонта";
            exApp.Cells[1, 8] = "Статус ремонта";
            exApp.Cells[1, 9] = "Стоимость ремонта";
            exApp.Cells[1, 10] = "Ответсвенный сотрудник";
            exApp.Visible = true;
        }

        private void Filter(DataGridView dgw) //фильтрация по стоимости
        {
            dgw.Rows.Clear();
            string Ot = textBoxOt.Text;
            string Do = textBoxDo.Text;
            string searchString = $"select * from repairs where price >= {Ot} and price <= {Do}";
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

        private void Repairs_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForEmployees menuForEmployees = new MenuForEmployees();
            menuForEmployees.Show();
        }
    }
}
