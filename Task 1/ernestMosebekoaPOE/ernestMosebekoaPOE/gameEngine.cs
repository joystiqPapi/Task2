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
            Random r = new Random();
            int numberOfRounds = 0;
            string action = "";
            int actionTaken = r.Next(1, 4);
            switch(actionTaken)
            {
                case 1: action = "Attack";
                    numberOfRoundsCompleted = numberOfRoundsCompleted + 1;
                    break;

                case 2: action = "Move";
                    numberOfRoundsCompleted = numberOfRoundsCompleted + 1;
                    break;
                case 3: action = "Run away";
                    numberOfRoundsCompleted = numberOfRoundsCompleted + 1;
                    break;

            }
    
            
        
        }
    }
}
