using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    public partial class MenuForEmployees : Form
    {
        public MenuForEmployees()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
            Hide();
        }

        private void btnSpares_Click(object sender, EventArgs e)
        {
            Spares spares = new Spares();
            spares.Show();
            Hide();
        }

        private void btnRepairs_Click(object sender, EventArgs e)
        {
            Repairs repairs = new Repairs();
            repairs.Show();
            Hide();
        }

        private void btnWorkers_Click(object sender, EventArgs e)
        {
            Workers workers = new Workers();
            workers.Show();
            Hide();
        }

        private void MenuForEmployees_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enter enter = new Enter();
            enter.Show();
        }
    }
}
