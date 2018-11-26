using StreamBED.Backend.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    public class ImageWithMetadata
    {
        private EpifaunalSubstrateScore epifaunalScore;

        private BankStabilityScore bankScore;

        private List<Keyword> keywords;

        public byte[] Data { get; }

        public IList<Keyword> Keywords { get { return keywords.AsReadOnly(); } }

        public AreaModelBase Location { get; set; }

        public int EpifaunalSubstarteScore { get { return epifaunalScore.GetScore(); } }

        public int BankStabilityScore { get { return bankScore.GetScore(); } }

        public ImageWithMetadata(byte[] Data)
        {
            this.Data = Data;
            keywords = new List<Keyword>();
        }

        public void ChangeEpifaunalSubstrateScore(int i)
        {
            epifaunalScore.ChangeScore(i);
        }

        public void ChangeBankStabilityScore(int i)
        {
            bankScore.ChangeScore(i);
        }

        public int GetImageSize()
        {
            return Data.Length;
        }

        public void AddKeyword(Keyword keyword)
        {
            if (!keywords.Contains(keyword))
                keywords.Add(keyword);
            else
                Debug.Write("Already contains the keyword " + keyword);
        }
    }
}
