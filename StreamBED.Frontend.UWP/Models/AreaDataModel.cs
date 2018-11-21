using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using StreamBED.Backend.Helper;
using StreamBED.Backend.Models;

namespace StreamBED.Frontend.UWP.Models
{
    public class AreaDataModel
    {
        public AreaModelBase Area { get; }

        public Color ItemColor { get; set; }

        public SolidColorBrush ItemColorBrush
        {
            get { return new SolidColorBrush(ItemColor); }
        }

        public AreaDataModel(AreaModelBase Area, Color ItemColor)
        {
            this.Area = Area;
            this.ItemColor = ItemColor;
        }
    }
}
