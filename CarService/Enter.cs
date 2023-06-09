using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    public partial class Enter : Form
    {
        DataBase dataBase = new DataBase();
        public Enter()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnGoToRegistrationForm_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Hide();
        }

        private void Enter_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartForm startForm = new StartForm();
            startForm.Show();
        }

        private void Enter_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(textBoxLogin, "Введите логин");
            toolTip.SetToolTip(textBoxPassword, "Введите пароль");
            toolTip.SetToolTip(pictureBox1, "Показать пароль");
            toolTip.SetToolTip(pictureBox2, "Скрыть пароль");
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxLogin.MaxLength = 50;
            textBoxPassword.MaxLength = 50;
            pictureBox2.Visible = false;
        }

        private void btnEnter_Click(object sender, EventArgs e) //обработка введённого логина и пароля пользователя
        {
            var loginUser = textBoxLogin.Text;
            var passUser = md5.hashPassword(textBoxPassword.Text);
            if (passUser == md5.hashPassword("admin") && loginUser == "admin")
            {
                MenuForEmployees menuForEmployees = new MenuForEmployees();
                menuForEmployees.Show();
                Hide();
            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                string queryString = $"select * from register where login_user = '{loginUser}' and password_user = '{passUser}'";
                SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вход выполнен успешно!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ForUsers forUsers = new ForUsers();
                    forUsers.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            toolStripStatusLabel1.Text = "Введите логин";
        }

        private void textBoxPassword_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Введите пароль";
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
