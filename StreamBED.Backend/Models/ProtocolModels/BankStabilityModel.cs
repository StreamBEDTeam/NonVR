using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBED.Backend.Models.ProtocolModels
{
    public sealed class BankStabilityModel : ProtocolModel
    {
        enum Keywords
        {
            [Keyword("Steep Bank")] SteepBank,
            [Keyword("Gently Sloping Bank")] GentlySlopingBank,
            [Keyword("Bank Failure")] BankFailure,
            [Keyword("Crumbling Bank")] CrumblingBank,
            [Keyword("Erosional Scars")] ErosionalScars,
            [Keyword("Exposed Soil")] ExposedSoil,
            [Keyword("Exposed Tree Root")] ExposedTreeRoot
        }

        public override Category GetCategory()
        {
            /* TO-DO: Implement this */

            throw new NotImplementedException();
        }

        public override void InitializeDictionary()
        {
            /* TO-DO: Implement this */

            throw new NotImplementedException();
        }
    }
}
