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
using Windows.UI.Xaml.Media.Animation;
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

        private List<int> visit = new List<int>() { 20, 15, 10, 5, 0 };

        public EpifaunalAssessmentPage()
        {
            this.InitializeComponent();

            Index = FeatureEvalPage.SelectedFeature.CountComplete;
            CurrentImage = FeatureEvalPage.SelectedFeature.ImageList[Index++];
            progressBar.Maximum = FeatureEvalPage.SelectedFeature.ImageList.Count;
            progressBar.Value = FeatureEvalPage.SelectedFeature.CountComplete;
        }

        public int NextImage()
        {
            if (Index < FeatureEvalPage.SelectedFeature.ImageList.Count)
            {
                CurrentImage = FeatureEvalPage.SelectedFeature.ImageList[Index++];

                foreach (UIElement elem in radioStack.Children)
                {
                    RadioButton button = elem as RadioButton;

                    if (button.IsChecked.Value)
                    {
                        button.IsChecked = false;
                    }

                    if (button.Style.Equals((Style)App.Current.Resources["AssessmentRadioButtonSmall"]))
                    {
                        button.Opacity = 0;
                        button.IsHitTestVisible = true;
                    }
                }

                detailButton1.Opacity = 1;
                detailButton1.IsHitTestVisible = true;

                detailButton2.Opacity = 1;
                detailButton2.IsHitTestVisible = true;

                detailButton3.Opacity = 1;
                detailButton3.IsHitTestVisible = true;

                detailButton4.Opacity = 1;
                detailButton4.IsHitTestVisible = true;

                return 0;
            }

            FeatureEvalPage.SelectedFeature.IsComplete = true;

            return -1;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentImage.Image.ChangeEpifaunalSubstrateScore(CurrentScore);
            CurrentImage.isComplete = true;

            ++FeatureEvalPage.SelectedFeature.CountComplete;

            ++progressBar.Value;

            NextImage();
        }

        private void ReferenceImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Storyboard animation = new Storyboard();

            DoubleAnimation reveal = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.25))
            };

            DoubleAnimation hide = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(0.25))
            };

            Storyboard.SetTarget(reveal, refImage);
            Storyboard.SetTargetProperty(reveal, "UIElement.Opacity");

            Storyboard.SetTarget(hide, refImageDetail);
            Storyboard.SetTargetProperty(hide, "UIElement.Opacity");

            animation.Children.Add(hide);
            animation.Children.Add(reveal);

            animation.Begin();
        }

        private void ReferenceImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Storyboard animation = new Storyboard();

            DoubleAnimation reveal = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.25))
            };

            DoubleAnimation hide = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(0.25))
            };

            Storyboard.SetTarget(hide, refImage);
            Storyboard.SetTargetProperty(hide, "UIElement.Opacity");

            Storyboard.SetTarget(reveal, refImageDetail);
            Storyboard.SetTargetProperty(reveal, "UIElement.Opacity");

            animation.Children.Add(hide);
            animation.Children.Add(reveal);

            animation.Begin();
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Name;

            int u = 0, l = 0;

            if (name.Equals("detailButton1"))
            {
                u = 20;
                l = 15;

                detailButton1.Opacity = 0;
                detailButton1.IsHitTestVisible = false;
            }
            else if (name.Equals("detailButton2"))
            {
                u = 15;
                l = 10;

                detailButton2.Opacity = 0;
                detailButton2.IsHitTestVisible = false;
            }
            else if (name.Equals("detailButton3"))
            {
                u = 10;
                l = 5;

                detailButton3.Opacity = 0;
                detailButton3.IsHitTestVisible = false;
            }
            else if (name.Equals("detailButton4"))
            {
                u = 5;
                l = 0;

                detailButton4.Opacity = 0;
                detailButton4.IsHitTestVisible = false;
            }

            foreach (UIElement elem in radioStack.Children)
            {
                RadioButton button = elem as RadioButton;

                if (Convert.ToInt32(button.Content) > l && Convert.ToInt32(button.Content) < u)
                {
                    button.Opacity = 1;
                    button.IsHitTestVisible = true;
                }
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentScore = Convert.ToInt32((sender as RadioButton).Content);

            if (visit.Contains(CurrentScore))
            {
                visit.Remove(CurrentScore);
            }

            if (visit.Count == 0)
            {
                detailButton1.IsHitTestVisible = true;
                detailButton2.IsHitTestVisible = true;
                detailButton3.IsHitTestVisible = true;
                detailButton4.IsHitTestVisible = true;

                submitButton.IsEnabled = true;
            }
        }

        private void GlanceCloseButton_Click(object sender, RoutedEventArgs e)
        {
            glanceProtocol.Visibility = Visibility.Collapsed;
        }

        private void GlanceOpenButton_Click(object sender, RoutedEventArgs e)
        {
            glanceProtocol.Visibility = Visibility.Visible;
        }
    }
}
