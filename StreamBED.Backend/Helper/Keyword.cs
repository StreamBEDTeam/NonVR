using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    /// <summary>
    /// Defines a keyword.
    /// </summary>
    public class Keyword : Attribute
    {
        /// <summary>
        /// Represents <see cref="Keyword"/> content.
        /// </summary>
        public string Content { get; }

        // Internal constructor
        internal Keyword(string Content)
        {
            this.Content = Content;
        }
    }
}
