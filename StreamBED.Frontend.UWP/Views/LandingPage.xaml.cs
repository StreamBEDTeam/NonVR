﻿using System;
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
using StreamBED.Backend.Helper;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StreamBED.Frontend.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        public LandingPage()
        {
            this.InitializeComponent();
        }

        private void PivotRoot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Pivot)sender).SelectedIndex == 1)
            {
                nextButton.Content = "Next";
                nextButton.Width = 200;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (pivotRoot.SelectedIndex < 3)
            {
                pivotRoot.SelectedIndex = ++pivotRoot.SelectedIndex;
            }
            else
            {
                this.Frame.Navigate(typeof(AreaSelectionPage));
            }
        }
    }
}
