using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models.ProtocolModels
{
    /// <summary>
    /// Defines the Epifaunal Substrate Model.
    /// </summary>
    public class EpifaunalSubstrateModel : ProtocolModel
    {
        /// <summary>
        /// Lists all possible keywords associated with <see cref="EpifaunalSubstrateModel"/> protocol.
        /// </summary>
        public enum Keywords
        {
            [Keyword("Snags")]Snags,
            [Keyword("Submerged Logs")]SubmergedLogs,
            [Keyword("Undercut Banks")]UndercutBanks,
            [Keyword("Cobble")]Cobble
        }

        /// <summary>
        /// Returns <see cref="Keywords"/> associated with <see cref="EpifaunalSubstrateModel"/> as an array.
        /// </summary>
        public static Keyword[] GetKeywords() {
            return (Keyword[])Enum.GetValues(typeof(Keywords));
        }

        /// <summary>
        /// Returns <see cref="ProtocolModel.Category"/> based on <see cref="ProtocolModel.Score"/>
        /// </summary>
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
    }
}
