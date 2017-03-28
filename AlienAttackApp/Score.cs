using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAttackApp
{
    class Score
    {
        int score = 0; //alkupisteet, pitäskö olla private tms?

        public void Scores()
        {
            
        }

        public void AddScore() //voiks näin sanoo? eli jos alieniin osuu, niin lisätään piste
        {
            if Alien.BeenHit(){
                score++;
            }
            else
            {

            }
        }

        public void Reset()
        {
            
        }
    }
}
