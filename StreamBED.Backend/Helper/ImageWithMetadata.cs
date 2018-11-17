using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBED.Backend.Helper
{
    public sealed class ImageWithMetadata
    {
        private readonly byte[] Data;

        private List<Keyword> Keywords;
        private string Location;
        private EpifaunalSubstrateScore eScore;
        private BankStabilityScore bScore;

        public ImageWithMetadata(byte[] Data)
        {
            this.Data = Data;
            Keywords = new List<Keywords>();
            eScore = 0;
            bScore = 0;
        }

        public void changeEScore(int i)
        {
            eScore.changeScore(i);
        }

        public void changeBScore(int i)
        {
            bScore.changeScore(i);
        }

        public string getLocation()
        {
            return Location;
        }

        public void setLocation(string s)
        {
            Location = s;
        }

        public byte[] getPhoto()
        {
            return Data;
        }

        public List<Keyword> getKeywords()
        {
            return Keywords;
        }
        
        public void addKeyword(string keyword)
        {
            if (!Keywords.Contains(keyword))
                Keywords.Add(keyword);
            else
                Debug.Log("Already contains the keyword " + keyword);
        }
    }
}
