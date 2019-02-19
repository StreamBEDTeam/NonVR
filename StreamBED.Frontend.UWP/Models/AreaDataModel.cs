using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using StreamBED.Backend.Helper;
using StreamBED.Backend.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace StreamBED.Frontend.UWP.Models
{
    public class AreaDataModel
    {
        public string Name { get; }

        public ObservableCollection<ImageDataModel> ImageList { get; }

        public bool IsCompleted = false;

        public bool IsEnabled { get { return !IsCompleted; } }

        public bool? IsBank = false;

        public Visibility Visibility { get { return (IsCompleted) ? Visibility.Visible : Visibility.Collapsed; } }

        public AreaDataModel(string Name)
        {
            this.Name = Name;

            ImageList = new ObservableCollection<ImageDataModel>();
        }
    }
}
