using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    internal class EpifaunalSubstrateScore : Score
    {
        public static int Score;

        public EpifaunalSubstrateScore()
        {
            Score = 0;
        }

        public override void ChangeScore(int s)
        {
            if (s > 20 || s < 0)
                Debug.Write("Score is invalid, must be between 0-10");
            else
                Score = s;
        }

        public override int GetScore()
        {
            return Score;
        }
    }
}
