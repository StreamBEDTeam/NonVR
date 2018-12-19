using StreamBED.Frontend.UWP.Models;
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
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Text;

namespace StreamBED.Frontend.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeaturePage : Page
    {
        private AreaDataModel Area;

        private int Count = 0;

        private int NumberOfKeywords = 0;

        private Grid CompletionGrid;

        private List<ImageDataModel> SelectedItems;

        public FeaturePage()
        {
            this.InitializeComponent();

            SelectedItems = new List<ImageDataModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Area = e.Parameter as AreaDataModel;

            foreach (Keyword keyword in EpifaunalSubstrateModel.GetKeywords())
            {
                listViewRoot.Items.Add(FeatureDataModel.GetFeatureDataModel(keyword, Area.ImageList));

                NumberOfKeywords++;
            }

            /*foreach (Keyword keyword in BankStabilityModel.GetKeywords())
            {
                listViewRoot.Items.Add(FeatureDataModel.GetFeatureDataModel(keyword, Area.ImageList));

                NumberOfKeywords++;
            }*/
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        { 
            if (Count == 0)
            {
                StackPanel stack = sender as StackPanel;

                Border border = new Border()
                {
                    BorderBrush = new SolidColorBrush(ColorScheme.ColorFromHex("#D9D9D9")),
                    CornerRadius = new CornerRadius(8, 8, 8, 8),
                    BorderThickness = new Thickness(8, 8, 8, 8),
                    Margin = new Thickness(150, 12.5, 150, 12.5)
                };

                Grid titleGrid = new Grid()
                {
                    Height = 75,
                    Background = Area.ItemColorBrush
                };

                TextBlock title = new TextBlock()
                {
                    Foreground = new SolidColorBrush(Colors.White),
                    FontSize = 30,
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = Area.Name.ToUpper()
                };

                CompletionGrid = titleGrid;

                titleGrid.Children.Add(title);
                border.Child = titleGrid;

                stack.Children.Insert(0, border);

                Count++;
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            listViewRoot.DataContext = null;

            this.Frame.Navigate(typeof(AreaPage));
        }

        private void ImageGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count != 0)
            {
                SelectedItems.Remove(e.RemovedItems.First() as ImageDataModel);
            }

            if (e.AddedItems.Count != 0)
            {
                SelectedItems.Add(e.AddedItems.First() as ImageDataModel);
            }

            if (SelectedItems.Count == NumberOfKeywords)
            {
                CompletionGrid.Background = new SolidColorBrush(Colors.LimeGreen);
                nextButton.Visibility = Visibility.Visible;

                Area.IsCompleted = true;
            }
            else
            {
                CompletionGrid.Background = Area.ItemColorBrush;
                nextButton.Visibility = Visibility.Collapsed;

                Area.IsCompleted = false;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var list = AreaPage.AreaList;
            int currIndex = list.IndexOf(Area);

            if (currIndex < list.Count - 1)
            {
                this.Frame.Navigate(typeof(FeaturePage), AreaPage.AreaList.ElementAt(AreaPage.AreaList.IndexOf(Area) + 1));
            }
            else
            {
                bool flag = false;

                foreach (AreaDataModel model in list)
                {
                    if (model.IsCompleted)
                    {
                        flag = true;
                    }
                    else
                    {
                        break;
                    }
                }
                
                if (flag)
                {
                    this.Frame.Navigate(typeof(FeatureSelectionPage));
                }
                else
                {
                    this.Frame.Navigate(typeof(AreaPage));
                }
            }
        }

        private void PopupButton_Click(object sender, RoutedEventArgs e)
        {
            messagePopup.Visibility = Visibility.Collapsed;
        }
    }
}
