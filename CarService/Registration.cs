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
    public partial class Registration : Form
    {
        DataBase dataBase = new DataBase();
        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enter enter = new Enter();
            enter.Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(textBoxLogin, "Придумайте логин");
            toolTip.SetToolTip(textBoxPassword, "Придумайте пароль");
            toolTip.SetToolTip(pictureBox1, "Показать пароль");
            toolTip.SetToolTip(pictureBox2, "Скрыть пароль");
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
        }

        private void btnRegistration_Click(object sender, EventArgs e) //занесение нового пользователя в БД
        {
            if (checkUser())
            {
                return;
            }
            var login = textBoxLogin.Text;
            var password = md5.hashPassword(textBoxPassword.Text);
            string queryString = $"insert into register(login_user, password_user) values('{login}', '{password}')";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            dataBase.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успешно!");
                Enter enter = new Enter();
                this.Close();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            dataBase.closeConnection();
        }
        private Boolean checkUser() //проверка на сущетсовование пользователя и обработка ошибок
        {
            var loginUser = textBoxLogin.Text;
            var passUser = md5.hashPassword(textBoxPassword.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string queryString = $"select * from register where login_user = '{loginUser}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (loginUser == "" || passUser == md5.hashPassword(""))
            {
                MessageBox.Show("Введите логин или пароль!", "Ошибка!" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void textBoxLogin_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Придумайте логин";
        }

        private void textBoxPassword_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Придумайте пароль";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Показать пароль";
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Скрыть пароль";
        }
    }
}
