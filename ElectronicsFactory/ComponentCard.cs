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
    public partial class ComponentCard : UserControl
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }

        public ComponentCard(ComponentCardInfo info)
        {
            InitializeComponent();

            Id = info.Id;
            ComponentName = info.Name;
            NameLabel.Text = info.Name;
            TypeLabel.Text = info.Type;
            ManufacturerLabel.Text = info.PcbCount.HasValue ?
                $"Количество на плате: {info.PcbCount.Value}" : $"Производитель: {info.Manufacturer}";
            QuantityLabel.Text = info.PcbCoordinates != null ?
                $"Координаты: {info.PcbCoordinates}" : $"На складе: {info.StockQuantity}";

            SettingsUI.StyleCard(this);
        }

        private void Card_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void ComponentCard_Paint(object sender, PaintEventArgs e)
        {
            SettingsUI.StyleCard(this);
        }
    }
}
