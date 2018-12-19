﻿using StreamBED.Backend.Helper;
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
        public static List<AreaDataModel> AreaList = new List<AreaDataModel>();

        public AreaPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (AreaList.Count == 0)
            {
                var buffer = await Convert(new BitmapImage(
                                        new Uri("ms-appx:///Assets/Logo/image.png")
                                    ));

                ColorScheme scheme = new ColorScheme();

                for (int i = 1; i <= 7; i++)
                {
                    var area = new AreaDataModel("Area " + i, scheme.GetColor());

                    for (int j = 0; j < 10; j++)
                    {
                        /*area.ImageList.Add(new ImageDataModel(
                            new Backend.Helper.ImageWithMetadata(
                                await Convert(
                                    new BitmapImage(
                                        new Uri("ms-appx:///Assets/Logo/image.png")
                                    )
                                )
                            )
                        ));*/

                        var imageDataModel = new ImageDataModel(new ImageWithMetadata(buffer));

                        foreach (Keyword keyword in EpifaunalSubstrateModel.GetKeywords())
                        {
                            var l = imageDataModel.Image;
                            l.AddKeyword(keyword);
                        }

                        foreach (Keyword keyword in BankStabilityModel.GetKeywords())
                        {
                            imageDataModel.Image.AddKeyword(keyword);
                        }

                        area.ImageList.Add(imageDataModel);
                    }

                    listViewRoot.Items.Add(area);
                    AreaList.Add(area);

                }
            }
            else
            {
                foreach (AreaDataModel area in AreaList)
                {
                    listViewRoot.Items.Add(area);
                }
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
    }
}
