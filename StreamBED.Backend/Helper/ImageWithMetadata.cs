using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBED.Backend.Helper
{
    public sealed class ImageWithMetadata
    {
        private readonly byte[] Data;

        private List<Keyword> Keywords;
        private string Location;

        public ImageWithMetadata(byte[] Data)
        {
            this.Data = Data;
        }
    }
}
