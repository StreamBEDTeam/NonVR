using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    public class ImageWithMetadata
    {
        public readonly byte[] Data;

        public List<Keyword> Keywords;
        public string Location;

        public ImageWithMetadata(byte[] Data)
        {
            this.Data = Data;
        }
    }
}
