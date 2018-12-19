﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using StreamBED.Backend.Helper;
using StreamBED.Backend.Models;
using System.Collections.ObjectModel;

namespace StreamBED.Frontend.UWP.Models
{
    public class AreaDataModel
    {
        public string Name { get; }

        public ObservableCollection<ImageDataModel> ImageList { get; }

        public Color ItemColor { get; }

        public bool IsCompleted = false;

        public SolidColorBrush ItemColorBrush
        {
            get { return (!IsCompleted) ? new SolidColorBrush(ItemColor) : new SolidColorBrush(Colors.LimeGreen); }
        }

        public AreaDataModel(string Name, Color ItemColor)
        {
            this.Name = Name;
            this.ItemColor = ItemColor;

            ImageList = new ObservableCollection<ImageDataModel>();
        }
    }
}
