using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ernestMosebekoaPOE
{
    class Map
    {  //class variables
        int units;
        int xAxis;
        int yAxis;
        char[,] mapArray = new char[20, 20];
        char Melee = 'M';
        char Ranged = 'R';
        private int numberOfUnits;
        private Unit[] listOfUnits;

        Random r = new Random();



        public Map (int numberOfUnits)
        {
            
            this.numberOfUnits = numberOfUnits;
            this.listOfUnits = new Unit[numberOfUnits];
        }

        // class attributes
        //method that randomises x and Y position and the type of unit it is. Mellee or Range
        public void generateNewBattlefield()
        {
            for (int count = 0; count < numberOfUnits; numberOfUnits++)
            {
                int xPos = r.Next(0, 20);
                int yPos = r.Next(0, 20);
                switch (r.Next(1, 2))
                {
                    case 1:
                        listOfUnits[count] = new MeleeUnit(xPos, yPos);
                        break;
                    case 2:
                        listOfUnits[count] = new RangedUnit(xPos, yPos);
                        break;
                }
            }
        }
        //updating method
        public void updateMap(int newXposition,int newYposition)
        {
            //randomizing new positions
         newXposition = r.Next(0, 20);
         newYposition = r.Next(0, 20);
         Unit[] units = new Unit[20];
         int[,] newUnitPosition;
            for(int o = 0; o < units.Length; o++)
            {
                newUnitPosition = new int[newYposition,newXposition];
            }
            

        }
        //method to populate map
        public void populateMap(string unitType,int xPosition, int yPosition)
        {
            this.xAxis = 20;
            this.yAxis = 20;
            int[,] unitPosition;
            char MeleeUnit = 'A';
            char RangedUnit = 'R';
            string returnString;
            generateNewBattlefield();


            //populate
            for(int i = 0; i < xAxis; i++)
            {
                for (int k = 0; k < yAxis; k++)
                {
                    if(unitType == "Melee")
                    {
                        unitPosition = new int[yPosition, xPosition];
                       
                    }
                    else 
                    unitPosition = new int[yPosition, xPosition];
                     
                   
                }

            }
         //   return returnString;
        }

        public Unit[] getUnits()
        {
            return listOfUnits;
        }
    }
}
