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
    public partial class AddRepair : Form
    {
        public DateTime dateTime = DateTime.Today;
        DataBase dataBase = new DataBase();
        public AddRepair()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dateTimePicker1.Value = dateTime.AddDays(1);
            dateTimePicker2.Value = dateTime.AddDays(2);
            dateTimePicker1.MinDate = dateTime;
            dateTimePicker1.MaxDate = dateTime.AddYears(2);
            dateTimePicker2.MinDate = dateTime.AddDays(1);
            dateTimePicker2.MaxDate = dateTime.AddYears(2);

        }

        private void AddRepair_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();
            string queryString = $"select name_client from clients";
            string queryString2 = $"select name_worker from workers";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());       
            var read = command.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read[0].ToString());
            }
            read.Close();
            comboBox1.SelectedIndex = 0;
            SqlCommand command2 = new SqlCommand(queryString2, dataBase.GetConnection());
            var read2 = command2.ExecuteReader();
            while (read2.Read())
            {
                comboBox3.Items.Add(read2[0].ToString());
            }
            read2.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var selectedClient = comboBox1.SelectedItem.ToString();
            string queryString = $"select car_mark, state_number, phone_number from clients where name_client='{selectedClient}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            var ex = command.ExecuteReader();
            while (ex.Read())
            {
                textBox1.Text = ex[0].ToString();
                TextBoxStateNumber.Text = ex[1].ToString();
                textBox3.Text = ex[2].ToString();
            }
            ex.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var nameClient = comboBox1.SelectedItem.ToString();
            var carMark = textBox1.Text;
            var stateNumber = TextBoxStateNumber.Text;
            var phoneNumber = textBox3.Text;
            var startDay = dateTimePicker1.Text;
            var endDay = dateTimePicker2.Text;
            var statusRepair = comboBox2.SelectedItem.ToString();
            var price = numericUpDown1.Value;
            var worker = comboBox3.SelectedItem.ToString();
            var addQuery = $"insert into repairs (name_client, car_mark, state_number, " +
                $"phone_number, start_day, end_day, status_repair, price, worker) values " +
                $"('{nameClient}', '{carMark}', '{stateNumber}', '{phoneNumber}', '{startDay}', '{endDay}', '{statusRepair}', '{price}', '{worker}')";
            var command = new SqlCommand(addQuery, dataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана! Обновите таблицу", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
            Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = dateTime;
            dateTimePicker1.MaxDate = Convert.ToDateTime(dateTimePicker2.Value).AddDays(-1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = Convert.ToDateTime(dateTimePicker1.Value).AddDays(1);
            dateTimePicker2.MaxDate = dateTime.AddYears(2);
        }

        private void AddRepair_FormClosed(object sender, FormClosedEventArgs e)
        {
            Repairs repairs = new Repairs();
            repairs.Show();
        }
    }
}