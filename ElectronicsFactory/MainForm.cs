using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicsFactory
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);
        }

        private void PcbsButton_Click(object sender, EventArgs e)
        {
            new PcbsListForm().ShowDialog();
        }

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            new ClientsListForm().ShowDialog();
        }

        private void ComponentsButton_Click(object sender, EventArgs e)
        {
            new ComponentsListForm().ShowDialog();
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            new OrdersListForm().ShowDialog();
        }

        private void MovementsButton_Click(object sender, EventArgs e)
        {
            new MovementsListForm().ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
