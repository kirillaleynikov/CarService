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
    public partial class AddWorker : Form
    {
        DataBase dataBase = new DataBase();
        public AddWorker()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var name = textBoxFIO.Text;
            var phonenumber = TextBoxPhoneNumber.Text;
            var addQuery = $"insert into workers (name_worker, phone_number_worker) values ('{name}', '{phonenumber}')";
            var command = new SqlCommand(addQuery, dataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана! Обновите таблицу", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
            Close();
        }

        private void textBoxFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void AddWorker_FormClosed(object sender, FormClosedEventArgs e)
        {
            Workers workers = new Workers();
            workers.Show();
        }
    }
}
