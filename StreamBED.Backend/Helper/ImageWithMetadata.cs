using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    public class ImageWithMetadata
    {
        private readonly byte[] Data;

        private List<Keyword> Keywords;

        private string Location;

        private EpifaunalSubstrateScore eScore;
        private BankStabilityScore bScore;

        public ImageWithMetadata(byte[] Data)
        {
            this.Data = Data;
            Keywords = new List<Keyword>();
        }

        public void ChangeEScore(int i)
        {
            eScore.ChangeScore(i);
        }

        public void ChangeBScore(int i)
        {
            bScore.ChangeScore(i);
        }

        public string GetLocation()
        {
            return Location;
        }

        public void SetLocation(string s)
        {
            Location = s;
        }

        public byte[] GetPhoto()
        {
            return Data;
        }

        public int GetPhotoSize()
        {
            return Data.Length;
        }

        public List<Keyword> GetKeywords()
        {
            return Keywords;
        }

        public void AddKeyword(Keyword keyword)
        {
            if (!Keywords.Contains(keyword))
                Keywords.Add(keyword);
            else
                Debug.Write("Already contains the keyword " + keyword);
        }
    }
}
