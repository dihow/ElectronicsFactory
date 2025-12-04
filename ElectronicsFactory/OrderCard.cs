using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ElectronicsFactory
{
    public partial class OrderCard : UserControl
    {
        public int Id { get; set; }

        public OrderCard(OrderCardInfo info)
        {
            InitializeComponent();

            Id = info.Id;
            ClientLabel.Text = $"Заказчик: {info.Client}";
            StatusLabel.Text = $"Статус: {info.Status}";
            TotalAmountLabel.Text = $"Стоимость плат: {info.TotalAmount} руб.";
            RegistrationDateLabel.Text = $"Дата регистрации: {info.RegistrationDate}";
            ShipmentDateLabel.Text = info.ShipmentDate != null ?
                $"Дата отгрузки: {info.ShipmentDate}" : "Дата отгрузки отсутствует";

            SettingsUI.StyleCard(this);
        }

        private void Card_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
