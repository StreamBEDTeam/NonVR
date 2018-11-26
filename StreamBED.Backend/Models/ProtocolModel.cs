using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models
{
    public abstract class ProtocolModel
    {
        /// <summary>
        /// Lists all possible categories associated with a protocol.
        /// </summary>
        public enum Category
        {
            Optimal,
            Suboptimal,
            Marginal,
            Poor,
            None
        }

        public double Score = 0;

        public abstract Category GetCategory();

        public double GetScore()
        {
            return Score;
        }
    }
}
