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
    public partial class PcbCard : UserControl
    {
        public int Id { get; set; }
        public PcbCard(PcbCardInfo info)
        {
            InitializeComponent();

            Id = info.Id;
            NameLabel.Text = info.Name;
            DescriptionLabel.Text = info.Description != "" ? info.Description : "Описание отсутствует";
            PriceLabel.Text = $"Стоимость: {info.Price} руб.";
            QuantityLabel.Text = $"Всего на складе: {info.Quantity} шт.";
            if (info.ImagePath != null && info.ImagePath != "")
            {
                PcbImage.ImageLocation = info.ImagePath;
            }
            else
            {
                PcbImage.Image = Properties.Resources.circuit_placeholder;
            }

            SettingsUI.StyleCard(this);
        }

        private void Card_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
