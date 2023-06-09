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

namespace CarService
{
    public partial class ForUsers : Form
    {
        DataBase dataBase = new DataBase();
        public ForUsers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_spare", "Артикул запчасти");
            dataGridView1.Columns.Add("title_spare", "Название запчасти");
            dataGridView1.Columns.Add("amount_spare", "Кол-во на складе");
            dataGridView1.Columns.Add("price_spare", "Цена ₽");
            dataGridView1.Columns.Add("mark_car", "Марка машины");
            dataGridView1.Columns.Add("country", "Страна производства");
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
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetDecimal(3), record.GetString(4), record.GetString(5));
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

        private void ForUsers_Load(object sender, EventArgs e)
        {
            CreateColumns();
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

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
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

        private void ForUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enter enter = new Enter();
            enter.Show();
        }
    }
}
