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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StreamBED.Frontend.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BankAssessmentPage : Page
    {
        public BankAssessmentPage()
        {
            this.InitializeComponent();
        }

        public int NextImage()
        {
            return 0;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReferenceImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            referenceImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/ProtocolAssets/0_BW_2.png"));
        }

        private void ReferenceImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            referenceImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/ProtocolAssets/0_C.png"));
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32((sender as Button).Name.Last());

            if (i == 1)
            {

            }
        }
    }
}
