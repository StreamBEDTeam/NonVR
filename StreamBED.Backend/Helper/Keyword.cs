using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    public class Keyword : Attribute
    {
        public string Content { get; }

        internal Keyword(string Content)
        {
            this.Content = Content;
        }
    }
}
