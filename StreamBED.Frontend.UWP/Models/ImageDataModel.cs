using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace StreamBED.Frontend.UWP.Models
{
    public class ImageDataModel
    {
        private readonly ImageWithMetadata LoadedImage;

        public Image ConvertedImage;

        public ImageDataModel(ImageWithMetadata LoadedImage)
        {
            this.LoadedImage = LoadedImage;

            ConvertedImage.Source = ProcessLoadedImage().Result;
            ConvertedImage.Height = 250;
            ConvertedImage.Width = 250;
        }

        private async Task<BitmapImage> ProcessLoadedImage()
        {
            BitmapImage bitmapImage = new BitmapImage();

            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(LoadedImage.GetPhoto().AsBuffer());
                stream.Seek(0);
                await bitmapImage.SetSourceAsync(stream);
            }

            return bitmapImage;
        }
    }
}
