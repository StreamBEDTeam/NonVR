using StreamBED.Backend.Helper;
using StreamBED.Backend.Models;
using StreamBED.Backend.Models.ProtocolModels;
using StreamBED.Frontend.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
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
    public sealed partial class FeatureSelectionPage : Page
    {
        private ProtocolModel SelectedModel;

        private static ProtocolModel epifaunalSubstrateModel = new EpifaunalSubstrateModel();

        private static ProtocolModel bankStabilityModel = new BankStabilityModel();

        private List<ImageDataModel> protocolImages = new List<ImageDataModel>();

        private List<ImageDataModel> featureImages = new List<ImageDataModel>();

        private List<Keyword> protocolFeatures = new List<Keyword>();

        public FeatureSelectionPage()
        {
            this.InitializeComponent();
        }

        private void PivotRoot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pivotRoot.SelectedIndex == 1)
            {
                nextButton.Content = "Get Started";
                nextButton.Width = 310;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (pivotRoot.SelectedIndex < 1)
            {
                pivotRoot.SelectedIndex = ++pivotRoot.SelectedIndex;
            }
            else
            {
                ++layoutPivot.SelectedIndex;
            }
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SelectedModel = new BankStabilityModel();
            protocolTitle.Text = "BANK STABILITY";

            InitProtocolPage(BankStabilityModel.GetKeywords());
        }

        private void StackPanel_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            SelectedModel = new EpifaunalSubstrateModel();
            protocolTitle.Text = "EPIFAUNAL SUBSTRATE";

            InitProtocolPage(EpifaunalSubstrateModel.GetKeywords());
        }

        private void InitProtocolPage(Keyword[] keywords) 
        {
            protocolImages.Clear();
            protocolFeatures.Clear();
            listViewRoot.Items.Clear();

            foreach (Keyword keyword in keywords)
            {
                foreach (ImageDataModel image in FeaturePage.SelectedItems)
                {
                    if (image.Image.Keywords.Contains(keyword))
                    {
                        if (!protocolImages.Contains(image))
                        {
                            protocolImages.Add(image);
                        }

                        if (!protocolFeatures.Contains(keyword))
                        {
                            protocolFeatures.Add(keyword);
                        }
                    }
                }
            }

            GenerateProtocolPage();

            ++layoutPivot.SelectedIndex;
        }

        private void GenerateProtocolPage()
        {
            foreach (Keyword feature in protocolFeatures)
            {
                Border border = new Border()
                {
                    BorderBrush = new SolidColorBrush(ColorScheme.ColorFromHex("#D9D9D9")),
                    CornerRadius = new CornerRadius(8, 8, 8, 8),
                    BorderThickness = new Thickness(8, 8, 8, 8),
                    Margin = new Thickness(150, 12.5, 150, 12.5),
                    Width = 1200
                };

                Grid titleGrid = new Grid()
                {
                    Height = 75,
                    Background = new SolidColorBrush(Colors.White)
                };

                TextBlock title = new TextBlock()
                {
                    Foreground = new SolidColorBrush(Colors.Black),
                    FontSize = 30,
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = feature.Content.ToUpper()
                };

                titleGrid.Children.Add(title);
                border.Child = titleGrid;

                listViewRoot.Items.Add(border);
            }
        }

        private void LayoutPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = layoutPivot.SelectedIndex;

            if (index < 1)
            {
                navBar.Visibility = Visibility.Collapsed;
                protocolBlock.Visibility = Visibility.Collapsed;
                featureBlock.Visibility = Visibility.Collapsed;
            }
            else if (index < 2)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Collapsed;
                featureBlock.Visibility = Visibility.Collapsed;
            }
            else if (index < 3)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Visible;
                featureBlock.Visibility = Visibility.Collapsed;
            }
            else if (index < 4)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Visible;
                featureBlock.Visibility = Visibility.Visible;
            }
        }

        private void EvalTitle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (layoutPivot.SelectedIndex > 1)
            {
                layoutPivot.SelectedIndex = 1;
            }
        }

        private void ProtocolTitle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (layoutPivot.SelectedIndex > 2)
            {
                layoutPivot.SelectedIndex = 2;
            }
        }

        private void GlanceCloseButton_Click(object sender, RoutedEventArgs e)
        {
            glanceProtocol.Visibility = Visibility.Collapsed;
        }
    }
}
