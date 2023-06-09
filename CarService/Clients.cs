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
using ToolTip = System.Windows.Forms.ToolTip;

namespace CarService
{
    enum RowState
    {
        ModifiedNew,
        Existed,
        Deleted,
        Modified
    }
    public partial class Clients : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public Clients()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void CreateColumns() //создание столбцов
        {
            dataGridView1.Columns.Add("id_client", "Код клиента");
            dataGridView1.Columns.Add("name_client", "ФИО");
            dataGridView1.Columns.Add("phone_number", "Номер телефона");
            dataGridView1.Columns.Add("car_mark", "Марка машины");
            dataGridView1.Columns.Add("state_number", "Гос номер");
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
            column4.Width = 90;
        }
        private void ReadSingleRows(DataGridView dgw, IDataRecord record) //чтение записей
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw) //обновление таблицы
        {
            dgw.Rows.Clear();
            string queryString = $"select * from clients";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRows(dgw, reader);
            }
            reader.Close();
        }

        private void DeleteRow() //удаление клиента
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void Update() //метод для обновления
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;
                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from clients where id_client = '{id}'";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var idClient = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var nameClient = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var phoneNumber = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var carMark = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var stateNumber = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var changeQuery = $"update clients set name_client = '{nameClient}', phone_number = '{phoneNumber}', car_mark = '{carMark}', state_number = '{stateNumber}' where id_client ='{idClient}'";
                    var command = new SqlCommand(changeQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            CreateColumns();
            dataGridView1.Columns[5].Visible = false;
            RefreshDataGrid(dataGridView1);
        }

        private void Search(DataGridView dgw) //метод для поиска
        {
            dgw.Rows.Clear();
            string searchString = $"select * from clients where concat (id_client, name_client, phone_number, car_mark, state_number) like '%" + textBoxForSearch.Text + "%'";
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

        private void btnGoToAddClient_Click(object sender, EventArgs e) //переход на форму добавления клиента
        {
            AddClient addClient = new AddClient();
            addClient.Show();
            Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //вынесение выбранных данных в область для редактирования
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBoxIdClient.Text = row.Cells[0].Value.ToString();
                textBoxAddName.Text = row.Cells[1].Value.ToString();
                textBoxAddPhoneNumber.Text = row.Cells[2].Value.ToString();
                textBoxCarMark.Text = row.Cells[3].Value.ToString();
                TextBoxStateNumber.Text = row.Cells[4].Value.ToString();
                btnChange.Enabled = true;
            }
            textBoxAddName.Enabled = true;
            textBoxAddPhoneNumber.Enabled = true;
            textBoxCarMark.Enabled = true;
            TextBoxStateNumber.Enabled = true;
            btnChange.Enabled = true;
        }

        private void btnDeleteClient_Click(object sender, EventArgs e) //удаление клиента
        {
            MessageBox.Show("Вы действительно хотите удалить клиента?", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DeleteRow();
            Update();
        }
        private void Change() //занесение изменённых данных в таблицу
        {
            var idClient = textBoxIdClient.Text;
            var nameClient = textBoxAddName.Text;
            var phoneNumber = textBoxAddPhoneNumber.Text;
            var carMark = textBoxCarMark.Text;
            var stateNumber = TextBoxStateNumber.Text;

            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRow].SetValues(idClient, nameClient, phoneNumber, carMark, stateNumber);
                dataGridView1.Rows[selectedRow].Cells[5].Value = RowState.Modified;
            }
            textBoxIdClient.Text = "";
            textBoxAddName.Text = "";
            textBoxAddPhoneNumber.Text = "";
            textBoxCarMark.Text = "";
            TextBoxStateNumber.Text = "";
            btnChange.Enabled = false;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Change();
            Update();
            textBoxAddName.Enabled = false;
            textBoxAddPhoneNumber.Enabled = false;
            textBoxCarMark.Enabled = false;
            TextBoxStateNumber.Enabled = false;
            btnChange.Enabled = false;
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
            exApp.Cells[1, 1] = "Код клиента";
            exApp.Cells[1, 2] = "ФИО клиента";
            exApp.Cells[1, 3] = "Номер телефона";
            exApp.Cells[1, 4] = "Марка машины";
            exApp.Cells[1, 5] = "Гос номер";
            exApp.Visible = true;
        }

        private void textBoxAddName_KeyPress(object sender, KeyPressEventArgs e) //запрет на ввод цифр в поле ввода ФИО
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void Clients_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForEmployees menuForEmployees = new MenuForEmployees();
            menuForEmployees.Show();
        }
    }
}
