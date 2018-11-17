using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBED.Backend.Helper
{
    public class BankStabilityScore : Score
    {
        public static int score;

        public EpifaunalSubstrateScore()
        {
            score = 0;
        }

        public void changeScore(int s)
        {
            if (s > 10 || s < 0)
                Debug.Log("Score is invalid, must be between 0-10");
            else
                score = s;
        }

        public int getScore()
        {
            return score;
        }
    }
}
