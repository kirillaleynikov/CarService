using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarService
{
    public partial class AddClient : Form
    {
        DataBase dataBase = new DataBase();
        public AddClient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAddClient_Click(object sender, EventArgs e) //заполнение БД новыми введёнными данными
        {
            dataBase.openConnection();
            var name = textBoxAddName.Text;
            var phonenumber = textBoxAddPhoneNumber.Text;
            var carmark = textBoxCarMark.Text;
            var statenumber = TextBoxStateNumber.Text;
            var addQuery = $"insert into clients (name_client, phone_number, car_mark, state_number) values ('{name}', '{phonenumber}', '{carmark}', '{statenumber}')";
            var command = new SqlCommand(addQuery, dataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана! Обновите таблицу", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
            Close();
        }

        private void textBoxAddName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void AddClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
        }
    }
}
