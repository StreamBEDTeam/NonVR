using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models.ProtocolModels
{
    /// <summary>
    /// Defines the Bank Stability Model.
    /// </summary>
    public class BankStabilityModel : ProtocolModel
    {
        /// <summary>
        /// Lists all possible keywords associated with <see cref="BankStabilityModel"/> protocol.
        /// </summary>
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

        /// <summary>
        /// Returns <see cref="Keywords"/> associated with <see cref="BankStabilityModel"/> as an array.
        /// </summary>
        public static Keyword[] GetKeywords() {
            return (Keyword[])Enum.GetValues(typeof(Keywords));
        }

        /// <summary>
        /// Returns <see cref="ProtocolModel.Category"/> based on <see cref="ProtocolModel.Score"/>
        /// </summary>
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
