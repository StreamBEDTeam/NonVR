using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace StreamBED.Frontend.UWP.Models
{
    public class FeatureDataModel
    {
        public Keyword Keyword { get; }

        public ObservableCollection<ImageDataModel> ImageList { get; }

        public bool IsComplete
        {
            get
            {
                bool flag = false;

                foreach (ImageDataModel image in ImageList)
                {
                    if (image.isComplete)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }

                return flag;
            }
        }

        public int CountComplete
        {
            get
            {
                int count = 0;

                foreach (ImageDataModel image in ImageList)
                {
                    if (image.isComplete)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public Visibility Visibility { get { return (IsComplete) ? Visibility.Visible : Visibility.Collapsed; } }

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
