using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models.ProtocolModels
{
    public class BankStabilityModel : ProtocolModel
    {
        public enum Keywords
        {
            [Keyword("Steep Bank")] SteepBank,
            [Keyword("Gently Sloping Bank")] GentlySlopingBank,
            [Keyword("Bank Failure")] BankFailure,
            [Keyword("Crumbling Bank")] CrumblingBank,
            [Keyword("Erosional Scars")] ErosionalScars,
            [Keyword("Exposed Soil")] ExposedSoil,
            [Keyword("Exposed Tree Root")] ExposedTreeRoot
        }

        public static Keyword[] GetKeywords() {
            return (Keyword[])Enum.GetValues(typeof(Keywords));
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
