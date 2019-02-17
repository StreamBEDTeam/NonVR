using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace StreamBED.Frontend.UWP.Models
{
    public class ColorScheme
    {
        private int StreamIndex = 0;

        private int BankIndex = 0;

        private readonly string[] StreamColorSchemeList = {
            "#81D4FA",
            "#4FC3F7",
            "#29B6F6",
            "#03A9F4",
            "#039BE5",
            "#0288D1",
            "#0277BD",
            "#01579B",
            "#40C4FF",
            "#00B0FF",
            "#0091EA"
        };

        private readonly string[] BankColorSchemeList = {
            "#FFCC80",
            "#FFB74D",
            "#FFA726",
            "#FF9800",
            "#FB8C00",
            "#F57C00",
            "#EF6C00",
            "#E65100",
            "#FFAB40",
            "#FF9100",
            "#FF6D00"
        };

        public Color GetColor(char type)
        {
            if (type == 'S' && StreamIndex < StreamColorSchemeList.Count())
            {
                return ColorFromHex(StreamColorSchemeList[StreamIndex++]);
            }

            else if (type == 'B' && BankIndex < BankColorSchemeList.Count())
            {
                return ColorFromHex(BankColorSchemeList[BankIndex++]);
            }
            else
            {
                return new Color();
            }
        }

        public static Color ColorFromHex(string hex)
        {
            System.Drawing.Color colorReference = (System.Drawing.Color)(new System.Drawing.ColorConverter()).ConvertFromString(hex);

            Color color = new Color();
            color.A = colorReference.A;
            color.R = colorReference.R;
            color.G = colorReference.G;
            color.B = colorReference.B;

            return color;
        }

    }
}
