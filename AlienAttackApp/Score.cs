using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAttackApp
{
    class Score
    {
        private int score = 0; //alkupisteet

        public void CurrentScore()
        {
            PlayerScore.text = score;
        }

        public void AddScore() 
        {
            if alien.BeenHit(){     //voiks näin sanoo? eli jos alieniin osuu, niin lisätään piste
                score++;
            } 
        }

        public void Reset()
        {
            score = 0;
        }
    }
}
