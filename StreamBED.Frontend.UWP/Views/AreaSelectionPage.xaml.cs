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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StreamBED.Frontend.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AreaSelectionPage : Page
    {
        public AreaSelectionPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 7; i++)
            {
                var area = new AreaDataModel("Area " + i, ColorScheme.GetColor());

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

                    area.ImageList.Add(new ImageDataModel(
                        new BitmapImage(
                            new Uri("ms-appx:///Assets/Logo/image.png")
                    )));
                }

                listViewRoot.Items.Add(area);
            }
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
    }
}
