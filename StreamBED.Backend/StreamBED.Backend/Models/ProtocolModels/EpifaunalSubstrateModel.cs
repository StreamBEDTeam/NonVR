using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models.ProtocolModels
{
    public class EpifaunalSubstrateModel : ProtocolModel
    {
        enum Keywords {
            [Keyword("Snags")]Snags,
            [Keyword("Submerged Logs")]SubmergedLogs,
            [Keyword("Undercut Banks")]UndercutBanks,
            [Keyword("Cobble")]Cobble
        }

        public override Category GetCategory()
        {
            /* TO-DO: Implement this */

            throw new NotImplementedException();
        }

        public override void InitializeDictionary()
        {

        }
    }
}
