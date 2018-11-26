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
        private readonly ImageWithMetadata Image;

        public ImageSource ImageSource;

        public ImageDataModel(ImageWithMetadata Image)
        {
            this.Image = Image;

            this.ImageSource = GetImageSource().Result;
        }

        public ImageDataModel(ImageSource source)
        {
            this.ImageSource = source;
        }


        public async Task<BitmapImage> GetImageSource()
        {
            BitmapImage bitmapImage = new BitmapImage();

            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(Image.Data.AsBuffer());
                stream.Seek(0);
                bitmapImage.SetSource(stream);
            }

            return bitmapImage;
        }
    }
}
