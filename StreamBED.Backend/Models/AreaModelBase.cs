using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models
{
    public class AreaModelBase
    {
        public string Name { get; set; }

        public List<ImageWithMetadata> ImageList;

        public AreaModelBase(string Name, List<ImageWithMetadata> ImageList)
        {
            this.Name = Name;
            this.ImageList = ImageList;
        }
    }
}
