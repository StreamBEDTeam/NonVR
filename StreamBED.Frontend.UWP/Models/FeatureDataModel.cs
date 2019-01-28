using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace StreamBED.Frontend.UWP.Models
{
    public class FeatureDataModel : INotifyPropertyChanged
    {
        public Keyword Keyword { get; }

        public ObservableCollection<ImageDataModel> ImageList { get; }

        private bool isComplete = false;

        public bool IsComplete
        {
            get
            {
                if (IsHidden)
                {
                    return true;
                }
                else
                {
                    return isComplete;
                }
            }

            set { isComplete = IsComplete; }
        }

        public bool IsHidden
        {
            get
            {
                foreach (ImageDataModel image in ImageList)
                {
                    if (!image.IsHidden)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public int NonHiddenCount
        {
            get
            {
                int count = 0;

                foreach (ImageDataModel image in ImageList)
                {
                    if (!image.IsHidden)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public int CountComplete = 0;

        public Visibility Visibility { get { NotifyPropertyChanged(nameof(IsComplete)); return (IsComplete) ? Visibility.Visible : Visibility.Collapsed; } }

        public FeatureDataModel(Keyword keyword)
        {
            this.Keyword = keyword;
            ImageList = new ObservableCollection<ImageDataModel>();
        }

        public static FeatureDataModel GetFeatureDataModel(Keyword keyword, ICollection<ImageDataModel> imageList)
        {
            FeatureDataModel feature = new FeatureDataModel(keyword);

            foreach (ImageDataModel image in imageList)
            {
                if (image.Image.Keywords.Contains(keyword))
                {
                    feature.ImageList.Add(image);
                }
            }

            if (feature.ImageList.Count != 0)
            {
                return feature;
            }
            else
            {
                return null;
            }
        }
    }
}
