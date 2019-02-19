using StreamBED.Backend.Helper;
using StreamBED.Backend.Models.ProtocolModels;
using StreamBED.Frontend.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace StreamBED.Frontend.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AreaPage : Page
    {
        internal static List<AreaDataModel> AreaList = new List<AreaDataModel>();

        internal static Dictionary<string, string> AreaNames = new Dictionary<string, string>();

        private bool AllAreasCompleted = false;

        public AreaPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (AreaList.Count == 0)
            {
                ColorScheme scheme = new ColorScheme();

                List<ImageDataModel> imageModelList = new List<ImageDataModel>();

                foreach (ImageWithMetadata image in LandingPage.imageSerialization.ImageList)
                {
                    imageModelList.Add(new ImageDataModel(image));
                }

                int count = 1;

                foreach (ImageDataModel image in imageModelList)
                {
                    if (!AreaNames.ContainsKey(image.Image.Location))
                    {
                        AreaNames.Add(image.Image.Location, "Area " + count++);
                    }
                }

                foreach (string key in AreaNames.Keys)
                {
                    AreaDataModel area = new AreaDataModel(AreaNames.GetValueOrDefault(key));

                    if (key.ElementAt(1) == 'S')
                    {
                        area.IsBank = false;
                    }
                    else if (key.ElementAt(1) == 'B')
                    {
                        area.IsBank = true;
                    }

                    foreach (ImageDataModel image in imageModelList)
                    { 
                        if (AreaNames.GetValueOrDefault(image.Image.Location).Equals(area.Name))
                        {
                            area.ImageList.Add(image);
                        }
                    }

                    if (area.ImageList.Count != 0)
                    {
                        listViewRoot.Items.Add(area);
                        AreaList.Add(area);
                    }
                }
            }
            else
            {
                foreach (AreaDataModel area in AreaList)
                {
                    listViewRoot.Items.Add(area);
                }
            }

            foreach (AreaDataModel area in AreaList)
            {
                if (area.IsCompleted)
                {
                    AllAreasCompleted = true;
                }
                else
                {
                    AllAreasCompleted = false;
                    break;
                }
            }

            if (AllAreasCompleted)
            {
                nextButton.Visibility = Visibility.Visible;
            }

            progressRing.IsActive = false;
        }

        private async Task<byte[]> Convert(BitmapImage image)
        {
            byte[] buffer;

            using (IRandomAccessStreamWithContentType streamWithContent = await RandomAccessStreamReference.CreateFromUri(image.UriSource).OpenReadAsync())
            {
                buffer = new byte[streamWithContent.Size];
                await streamWithContent.ReadAsync(buffer.AsBuffer(), (uint)streamWithContent.Size, InputStreamOptions.None);
            }

            return buffer;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            AreaDataModel model = (sender as Button).DataContext as AreaDataModel;

            this.Frame.Navigate(typeof(FeaturePage), model);
        }

        private void NextButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FeatureEvalPage));
        }
    }
}
