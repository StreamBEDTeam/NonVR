﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Models
{
    /// <summary>
    /// Defines an abstract class to represent score associated with a protocol.
    /// </summary>
    public abstract class ScoreModel
    {
        /// <summary>
        /// Represents score associated with a protocol.
        /// </summary>
        internal int Score;

        internal int Count;

        // Contructor
        public ScoreModel()
        {
            Score = -1;
            Count = 1;
        }

        /// <summary>
        /// Abstrast <see cref="ScoreModel.ChangeScore(int)"/> method.
        /// </summary>
        /// <param name="score"></param>
        public abstract void ChangeScore(int score);

        public int GetScore()
        {
            return Score / Count;
        }
    }
}
