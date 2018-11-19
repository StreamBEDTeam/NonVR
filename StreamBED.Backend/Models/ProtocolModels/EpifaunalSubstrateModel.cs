using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models.ProtocolModels
{
    public class EpifaunalSubstrateModel : ProtocolModel
    {
        enum Keywords
        {
            [Keyword("Snags")]Snags,
            [Keyword("Submerged Logs")]SubmergedLogs,
            [Keyword("Undercut Banks")]UndercutBanks,
            [Keyword("Cobble")]Cobble
        }

        public static Keyword[] getKeywords() {
            Keyword[] k = { 
                            new Keyword("Snags"),
                            new Keyword("Submerged Logs"),
                            new Keyword("Undercut Banks"),
                            new Keyword("Cobble")
                          };
            return k;
        }

        public override Category GetCategory()
        {
            if (Score >= 0 && Score <= 5)
            {
                return Category.Poor;
            }
            else if (Score >= 6 && Score <= 10) {
                return Category.Marginal;
            }
            else if (Score >= 11 && Score <= 15)
            {
                return Category.Suboptimal;
            }
            else if (Score >= 16 && Score <= 20)
            {
                return Category.Optimal;
            }
            else
            {
                return Category.None;
            }
        }

        public override void InitializeDictionary()
        {
            /* TO-DO: Implement this. */
        }
    }
}
