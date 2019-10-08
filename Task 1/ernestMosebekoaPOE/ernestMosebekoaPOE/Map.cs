using System;

namespace ernestMosebekoaPOE
{
    class Map
    {
        //class variables
        private const int MAP_SIZE = 20;

        char[,] mapArray;
        private Unit[] unitList;
        private Random randomizer;

        public Map(int numberOfUnits)
        {
            this.randomizer = new Random();
            mapArray = new char[MAP_SIZE, MAP_SIZE];
            generateUnits(numberOfUnits);
        }

        private void generateUnits(int numberOfUnits)
        {
            unitList = new Unit[numberOfUnits];
            for (int i = 0; i < numberOfUnits; i++)
            {
                unitList[i] = createRandomUnit();
            }
        }

        private Unit createRandomUnit()
        {
            int randomNumber = randomizer.Next(0, 2);
            int unitXPosition = generateRandomUnitPosition();
            int unitYPosition = generateRandomUnitPosition();
            if (randomNumber == 1)
            {
                return new MeleeUnit(unitXPosition, unitYPosition);
            }
            else
            {
                return new RangedUnit(unitXPosition, unitYPosition);
            }
        }

        private int generateRandomUnitPosition()
        {
            return randomizer.Next(0, MAP_SIZE);
        }

        public void displayUnitsOnBattlefield()
        {
        }

        public void updateBattlefield(int unitPosition, int xPosition, int yPosition)
        {
            Unit unit = unitList[unitPosition];
            unit.move(xPosition, yPosition);
            unitList[unitPosition] = unit;
            displayUnitsOnBattlefield();
        }
    }
}