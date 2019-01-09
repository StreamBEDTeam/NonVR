using StreamBED.Frontend.UWP.Models;
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
    public sealed partial class EpifaunalAssessmentPage : Page
    {
        private ImageDataModel CurrentImage;

        private int CurrentScore = 0;

        private int Index = 0;

        public EpifaunalAssessmentPage()
        {
            this.InitializeComponent();

            CurrentImage = FeatureSelectionPage.SelectedFeature.ImageList[Index];
            progressBar.Maximum = FeatureSelectionPage.SelectedFeature.ImageList.Count;
        }

        public int NextImage()
        {
            if (Index < FeatureSelectionPage.SelectedFeature.ImageList.Count)
            {
                CurrentImage = FeatureSelectionPage.SelectedFeature.ImageList[++Index];

                return 0;
            }

            return -1;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentImage.Image.ChangeEpifaunalSubstrateScore(CurrentScore);
            CurrentImage.isComplete = true;

            ++progressBar.Value;

            NextImage();
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
            string name = (sender as Button).Name;

            if (name.Equals("detailButton1"))
            {
                detail1.Visibility = Visibility.Visible;
                detailButton1.Visibility = Visibility.Collapsed;
            }
            else if (name.Equals("detailButton2"))
            {
                detail2.Visibility = Visibility.Visible;
                detailButton2.Visibility = Visibility.Collapsed;
            }
            else if (name.Equals("detailButton3"))
            {
                detail3.Visibility = Visibility.Visible;
                detailButton3.Visibility = Visibility.Collapsed;
            }
            else if (name.Equals("detailButton4"))
            {
                detail4.Visibility = Visibility.Visible;
                detailButton4.Visibility = Visibility.Collapsed;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentScore = Convert.ToInt32((sender as RadioButton).Content);
        }
    }
}
