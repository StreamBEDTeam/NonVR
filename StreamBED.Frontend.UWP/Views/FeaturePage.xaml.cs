﻿using StreamBED.Frontend.UWP.Models;
using StreamBED.Backend.Models.ProtocolModels;
using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StreamBED.Frontend.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeaturePage : Page
    {
        private AreaDataModel Area;

        public FeaturePage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Area = e.Parameter as AreaDataModel;

            foreach (Keyword keyword in EpifaunalSubstrateModel.GetKeywords())
            {
                listViewRoot.Items.Add(await FeatureDataModel.GetFeatureDataModel(keyword, Area.ImageList));
            }
        }
    }
}
