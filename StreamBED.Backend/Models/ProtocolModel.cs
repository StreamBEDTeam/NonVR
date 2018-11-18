using StreamBED.Backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models
{
    public abstract class ProtocolModel
    {
        public enum Category
        {
            Optimal,
            Suboptimal,
            Marginal,
            Poor,
            None
        }

        internal Dictionary<int, string> Descriptions = new Dictionary<int, string>();
        public double Score = 0;

        public string GetCategoryDescription(int key)
        {
            return Descriptions.Values.ElementAt<string>(key);
        }

        public abstract void InitializeDictionary();

        public abstract Category GetCategory();

        public double GetScore()
        {
            return Score;
        }
    }
}
