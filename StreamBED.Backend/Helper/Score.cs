using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    public abstract class Score
    {
        public abstract void ChangeScore(int s);

        public abstract int GetScore();
    }
}
