using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarService
{
    public partial class AddSpare : Form
    {
        DataBase dataBase = new DataBase();
        public AddSpare()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var titleSpare = textBox1.Text;
            var amountSpare = numericUpDown1.Value;
            var priceSpare = numericUpDown2.Value;
            var markCar = textBox2.Text;
            var country = textBox3.Text;
            var addQuery = $"insert into spares (title_spare, amount_spare, price_spare, mark_car, country) values ('{titleSpare}','{amountSpare}','{priceSpare}','{markCar}','{country}')";
            var command = new SqlCommand(addQuery, dataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана! Обновите таблицу", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
            Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void AddSpare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Spares spares = new Spares();
            spares.Show();
        }
    }
}
