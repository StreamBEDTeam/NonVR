using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    internal class BankStabilityScore : Score
    {
        private static int Score;

        public BankStabilityScore()
        {
            Score = 0;
        }

        public override void ChangeScore(int s)
        {
            if (s > 10 || s < 0)
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
