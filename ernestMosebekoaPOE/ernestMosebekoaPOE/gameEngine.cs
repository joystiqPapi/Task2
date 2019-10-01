using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ernestMosebekoaPOE
{
    class gameEngine
    { //class variable
        int numberOfRoundsCompleted;
        bool MeleeTookAction = false;
        bool RangedTookAction = false;
        private Map battlefield;
        public int health;

        public gameEngine(Map battleField)
        {
            this.battlefield = battleField;
        }

        public void engageBattle()
        {
            Unit[] units = battlefield.getUnits();
            for(int i = 0; i < units.Length; i++)
            {
                if(health < 25)
                {
                 //run away
               
                }

            }
        }

        //class attributes

        public void overallGameLogic()
        {   //making 1 round
    
            for(int actions = 0; actions < 2; actions++)
            {
                MeleeTookAction = true;
                RangedTookAction = true;


            }
            if (MeleeTookAction == true & RangedTookAction == true)
            {
                numberOfRoundsCompleted = numberOfRoundsCompleted + 1;
            }
        }
    }
}
