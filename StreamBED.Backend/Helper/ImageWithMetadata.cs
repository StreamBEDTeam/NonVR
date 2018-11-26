using StreamBED.Backend.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    /// <summary>
    /// Defines an image with meta data like <see cref="keywords"/>,
    /// <see cref="Location"/>, etc.
    /// </summary>
    public class ImageWithMetadata
    {
        private EpifaunalSubstrateScore epifaunalScore;

        private BankStabilityScore bankScore;

        private List<Keyword> keywords;

        public byte[] Data { get; }

        public IList<Keyword> Keywords { get { return keywords.AsReadOnly(); } }

        public string Location { get; set; }

        public int EpifaunalSubstarteScore { get { return epifaunalScore.GetScore(); } }

        public int BankStabilityScore { get { return bankScore.GetScore(); } }

        public ImageWithMetadata(byte[] Data)
        {
            this.Data = Data;
            this.keywords = new List<Keyword>();

            this.epifaunalScore = new EpifaunalSubstrateScore();
            this.bankScore = new BankStabilityScore();
        }

        public void ChangeEpifaunalSubstrateScore(int i)
        {
            epifaunalScore.ChangeScore(i);

            ImageSerialization a = new ImageSerialization();
            
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
            {
                keywords.Add(keyword);
            }
        }
    }
}
