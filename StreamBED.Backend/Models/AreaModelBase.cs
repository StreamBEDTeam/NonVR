﻿using StreamBED.Backend.Helper;
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

        public AreaModelBase(string Name)
        {
            ImageList = new List<ImageWithMetadata>();
            this.Name = Name;
        }
    }
}
