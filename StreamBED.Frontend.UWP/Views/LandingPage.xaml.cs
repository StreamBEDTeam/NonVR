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
using StreamBED.Backend.Helper;
using StreamBED.Frontend.UWP.Helper;
using Windows.Storage.Pickers;
using Windows.Storage;
using StreamBED.Frontend.UWP.Models;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using StreamBED.Backend.Models.ProtocolModels;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Popups;

namespace StreamBED.Frontend.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        internal static ImageSerialization imageSerialization = new ImageSerialization();

        internal static string ParticipantNumber = "";

        public LandingPage()
        {
            this.InitializeComponent();
        }

        private void PivotRoot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pivotRoot.SelectedIndex == 0)
            {
                nextButton.Content = "Next";
                pivotRoot.IsHitTestVisible = true;
            }
            else if (pivotRoot.SelectedIndex == 1)
            {
                nextButton.Content = "Start Assessment";
                pivotRoot.IsHitTestVisible = false;
            }
            else if (pivotRoot.SelectedIndex == 2)
            {
                nextButton.Content = "Next";
                nextButton.Width = 200;
            }
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (pivotRoot.SelectedIndex < 4)
            {
                if (pivotRoot.SelectedIndex == 0)
                {
                    if (!idBox.Text.Equals(""))
                    {
                        ParticipantNumber = idBox.Text;
                        pivotRoot.SelectedIndex = ++pivotRoot.SelectedIndex;
                    }
                    else
                    {
                        await new MessageDialog("Please enter Participation Number.").ShowAsync();
                    }
                }
                else
                {
                    pivotRoot.SelectedIndex = ++pivotRoot.SelectedIndex;
                }
            }
            else
            {
                this.Frame.Navigate(typeof(AreaPage));
            }
        }

        private async void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            imageSerialization.ClearImages();

            FileOpenPicker p = new FileOpenPicker();
            p.FileTypeFilter.Add(".dat");
            StorageFile file = await p.PickSingleFileAsync();

            imageSerialization.DeserializeImage(await file.OpenStreamForReadAsync());

            imageStatus.Text = "Images loaded: " + imageSerialization.ImageList.Count;

            nextButton.Visibility = Visibility.Visible;
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            imageSerialization.ClearImages();

            var buffer = await Convert(new BitmapImage(
                                        new Uri("ms-appx:///Assets/Logo/image.png")));

            ColorScheme scheme = new ColorScheme();
            Random r = new Random();

            for (int i = 0; i < 2; i++)
            {
                var image = new ImageWithMetadata(buffer);

                for (int j = 0; j < r.Next(0, 4); j++)
                {
                    var k = EpifaunalSubstrateModel.GetKeywords()[r.Next(0, 4)];

                    if (!image.Keywords.Contains(k))
                    {
                        image.AddKeyword(k);
                    }
                }

                for (int j = 0; j < r.Next(0, 2); j++)
                {
                    var k = BankStabilityModel.GetKeywords()[r.Next(0, 5)];

                    if (!image.Keywords.Contains(k))
                    {
                        image.AddKeyword(k);
                    }
                }

                image.Location = "Area " + r.Next(1, 7);

                imageSerialization.AddImage(image);
            }

            imageStatus.Text = "Images loaded: " + imageSerialization.ImageList.Count;

            nextButton.Visibility = Visibility.Visible;
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

        private async void Grid_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var storageItems = await e.DataView.GetStorageItemsAsync();

                foreach (StorageFile file in storageItems)
                {
                    imageSerialization.DeserializeImage(await file.OpenStreamForReadAsync());

                    imageStatus.Text = "Images loaded: " + imageSerialization.ImageList.Count;
                }
            }

            nextButton.Visibility = Visibility.Visible;
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void ExtractButton_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker p = new FileSavePicker();
            p.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            p.FileTypeChoices.Add("XML", new List<string>() { ".xml" });
            p.SuggestedFileName = "Results";

            StorageFile file = await p.PickSaveFileAsync();

            if (file != null)
            {
                CachedFileManager.DeferUpdates(file);

                StorageFile data = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\Results.xml");

                await FileIO.WriteTextAsync(file, await FileIO.ReadTextAsync(data));
            }
        }
    }
}
