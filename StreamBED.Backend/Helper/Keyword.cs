using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBED.Backend.Helper
{
    public class Keyword : Attribute
    {
        private readonly string content;

        public Keyword(string content)
        {
            this.content = content;
        }

        public string GetContent()
        {
            return content;
        }
        
        public bool equals(Keyword k)
        {
            return this.GetContent().Equals(k.GetContent());
        }
      
    }
}
