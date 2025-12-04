using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicsFactory
{
    public partial class ClientCard : UserControl
    {
        public int Id { get; set; }
        public ClientCard(ClientCardInfo info)
        {
            InitializeComponent();
            SettingsUI.StyleCard(this);

            Id = info.Id;
            NameLabel.Text = info.Name;
            TypeLabel.Text = info.Type;
            PhoneLabel.Text = $"Телефон: {info.Phone}";
            EmailLabel.Text = $"Email: {info.Email}";
        }

        private void Card_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void ClientCard_Load(object sender, EventArgs e)
        {

        }
    }
}
