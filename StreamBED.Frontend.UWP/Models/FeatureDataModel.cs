using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBED.Frontend.UWP.Models
{
    public class FeatureDataModel
    {
        public Keyword Keyword { get; }

        public ObservableCollection<ImageDataModel> ImageList { get; }

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
