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
            if (Score >= 0 && Score <= 2)
            {
                return Category.Poor;
            }
            else if (Score >= 3 && Score <= 5)
            {
                return Category.Marginal;
            }
            else if (Score >= 6 && Score <= 8)
            {
                return Category.Suboptimal;
            }
            else if (Score >= 9 && Score <= 10)
            {
                return Category.Optimal;
            }
            else
            {
                return Category.None;
            }
        }
    }
}
