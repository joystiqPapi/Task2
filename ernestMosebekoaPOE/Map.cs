using System;
using System.Linq;
using System.Text;

namespace ernestMosebekoaPOE
{
    class Map
    {
        //class variables
        private const int MAP_SIZE = 20;
        public const int X_POSITION_IN_UNIT_POSITION_LIST = 0;
        public const int Y_POSITION_IN_UNIT_POSITION_LIST = 1;

        private const string TEAM_1_NAME = "Team 1";
        private const string TEAM_2_NAME = "Team 2";

        char[,] mapArray;
        private Unit[] unitList;
        private Random randomizer;
        private FormView view;
        private int numberOfUnits;
        private Building[] buildingList;
        private int numberOfBuildings;

        public Map(FormView view, int numberOfUnits, int numberOfBuildings)
        {
            this.view = view;
            this.numberOfUnits = numberOfUnits;
            this.numberOfBuildings = numberOfBuildings;
            randomizer = new Random();
            mapArray = new char[MAP_SIZE, MAP_SIZE];
            generateUnits();
            generateBuildings();
        }

        private void generateUnits()
        {
            unitList = new Unit[numberOfUnits];
            for (int i = 0; i < numberOfUnits; i++)
            {
                unitList[i] = createRandomUnit();
            }
        }

        private void generateBuildings()
        {
            buildingList = new Building[numberOfBuildings];
            for (int i = 0; i < numberOfBuildings; i++)
            {
                buildingList[i] = createRandomBuilding();
            }
        }

        private Unit createRandomUnit()
        {
            int randomNumber = randomizer.Next(0, 2);
            PositionModel unitPosition = new PositionModel(generateRandomUnitPosition(), generateRandomUnitPosition());

            if (randomNumber == 1)
            {
                return new MeleeUnit(unitPosition.XPosition, unitPosition.YPosition, TEAM_1_NAME,
                    generateMeleeUnitName());
            }
            else
            {
                return new RangedUnit(unitPosition.XPosition, unitPosition.YPosition, TEAM_2_NAME,
                    generateRangedUnitName());
            }
        }

        private Building createRandomBuilding()
        {
            int randomNumber = randomizer.Next(0, 2);
            PositionModel unitPosition = new PositionModel(generateRandomUnitPosition(), generateRandomUnitPosition());

            if (randomNumber == 1)
            {
                return new ResourceBuilding(unitPosition.XPosition, unitPosition.YPosition, generateBuildingTeamName(),
                    generateResourceType());
            }
            else
            {
                return new FactoryBuilding(unitPosition.XPosition, unitPosition.YPosition, generateBuildingTeamName(),
                    MAP_SIZE);
            }
        }

        private string generateBuildingTeamName()
        {
            int randomNumber = randomizer.Next(0, 2);
            if (randomNumber == 1)
            {
                return TEAM_1_NAME;
            }
            else
            {
                return TEAM_2_NAME;
            }
        }

        private string generateMeleeUnitName()
        {
            int randomNumber = randomizer.Next(0, 2);
            switch (randomNumber)
            {
                case 1:
                    return MeleeUnit.FOOT_SOLDIER_UNIT_NAME;
                    break;
                case 2:
                    return MeleeUnit.KNIGHT_UNIT_NAME;
                    break;
                default:
                    return MeleeUnit.FOOT_SOLDIER_UNIT_NAME;
            }
        }

        private string generateRangedUnitName()
        {
            int randomNumber = randomizer.Next(0, 2);
            switch (randomNumber)
            {
                case 1:
                    return RangedUnit.TANK_UNIT_NAME;
                    break;
                case 2:
                    return RangedUnit.CANNON_UNIT_NAME;
                    break;
                default:
                    return RangedUnit.TANK_UNIT_NAME;
            }
        }

        private int generateRandomUnitPosition()
        {
            return randomizer.Next(0, MAP_SIZE);
        }

        private ResourceType generateResourceType()
        {
            int random = randomizer.Next(0, 3);
            switch (random)
            {
                case 1:
                    return ResourceType.METAL;
                case 2:
                    return ResourceType.WOOD;
                case 3:
                    return ResourceType.GUN_POWDER;
                default:
                    return ResourceType.WOOD;
            }
        }

        public void displayUnitsOnBattlefield()
        {
            int[][] unitLayout = new int [unitList.Length][];
            char[] unitSymbol = new char [unitList.Length];
            for (int count = 0; count < unitList.Length; count++)
            {
                Unit unit = unitList[count];
                unitLayout[count] = unit.returnPosition();
                unitSymbol[count] = unit.returnSymbol();
            }

            PositionModel[] buildingPositions = new PositionModel[buildingList.Length];
            char[] buildingSymbol = new char [buildingList.Length];
            for (int count = 0; count < buildingPositions.Length; count++)
            {
                Building building = buildingList[count];
                buildingPositions[count] = building.returnPosition();
                buildingSymbol[count] = building.returnSymbol();
            }

            view.invalidateView(buildBattleField(unitLayout, buildingPositions, unitSymbol, buildingSymbol));
        }

        public void updateBattlefield(int unitPosition, int xPosition, int yPosition)
        {
            Unit unit = unitList[unitPosition];
            unit.move(xPosition, yPosition);
            unitList[unitPosition] = unit;
            displayUnitsOnBattlefield();
        }

        public Unit[] getUnits()
        {
            return unitList;
        }

        public Building[] getBuildings()
        {
            return buildingList;
        }

        public int[] getClosestEnemy(Unit engagingUnit)
        {
            int[] engagingUnitPosition = engagingUnit.returnPosition();
            int engagingXPosition = engagingUnitPosition[X_POSITION_IN_UNIT_POSITION_LIST];
            int engagingYPosition = engagingUnitPosition[Y_POSITION_IN_UNIT_POSITION_LIST];
            int[] unitDistances = new int[unitList.Length];

            for (int count = 0; count < unitList.Length; count++)
            {
                Unit enemyUnit = unitList[count];
                int[] enemyUnitPosition = enemyUnit.returnPosition();
                unitDistances[count] = distanceBetweenPoints(engagingXPosition, engagingYPosition,
                    enemyUnitPosition[X_POSITION_IN_UNIT_POSITION_LIST],
                    enemyUnitPosition[Y_POSITION_IN_UNIT_POSITION_LIST]);
            }

            int closestEnemyDistance = (from number in unitDistances orderby number ascending select number).Distinct()
                .Skip(1).First();
            int closetEnemyListPosition = Array.IndexOf(unitDistances, closestEnemyDistance);
            return new[] {closetEnemyListPosition, closestEnemyDistance};
        }

        private int distanceBetweenPoints(int x1, int y1, int x2, int y2)
        {
            int xAxis = x2 - x1;
            int xAxisSquared = xAxis * xAxis;

            int yAxis = y2 - y1;
            int yAxisSquared = yAxis * yAxis;

            return (int) Math.Sqrt(xAxisSquared + yAxisSquared);
        }

        public void unitRunAway(Unit unit)
        {
            int[] unitPosition = unit.returnPosition();
            int unitXPosition = unitPosition[X_POSITION_IN_UNIT_POSITION_LIST];
            int unitYPosition = unitPosition[Y_POSITION_IN_UNIT_POSITION_LIST];
            if (unitXPosition != 0)
            {
                int minX = unitXPosition - 1;
                int maxX = unitXPosition + 1;
                int minY = unitYPosition - 1;
                int maxY = unitYPosition + 1;
                Random random = new Random();
                unitXPosition = random.Next(minX, maxX);
                unitYPosition = random.Next(minY, maxY);
                unit.move(unitXPosition, unitYPosition);
            }

            displayUnitsOnBattlefield();
        }

        private string buildBattleField(int[][] battleFieldLayout, PositionModel[] buildingsPositions,
            char[] unitSymbol, char[] buildingSymbols)
        {
            StringBuilder field = new StringBuilder();
            for (int count = 0; count < MAP_SIZE; count++)
            {
                for (int i = 0; i < MAP_SIZE; i++)
                {
                    field.Append(buildUnits(battleFieldLayout, unitSymbol, count, i));
                    field.Append(buildBuildings(buildingsPositions, buildingSymbols, count, i));
                }

                field.Append("\n");
            }

            return field.ToString();
        }

        private string buildUnits(int[][] battleFieldLayout, char[] symbol, int xCord, int yCord)
        {
            for (int count = 0; count < battleFieldLayout.Length; count++)
            {
                int[] coodinates = battleFieldLayout[count];
                if (xCord == coodinates[0] && yCord == coodinates[1])
                {
                    return symbol[count].ToString();
                }
            }

            return "    ";
        }

        private string buildBuildings(PositionModel[] buildingPosition, char[] symbol, int xCord, int yCord)
        {
            for (int count = 0; count < buildingPosition.Length; count++)
            {
                PositionModel positionModel = buildingPosition[count];
                if (xCord == positionModel.XPosition && yCord == positionModel.YPosition)
                {
                    return symbol[count].ToString();
                }
            }

            return "";
        }

        public void showRounds(int round)
        {
            view.showRound(round);
        }

        public void addSpawnedUnitToBattlefield(Unit spawnedUnit)
        {
            System.Array.Resize(ref unitList, unitList.Length + 1);
            unitList[unitList.Length - 1] = spawnedUnit;
            displayUnitsOnBattlefield();
        }

        public void handleResourceGeneration(ResourceType[] resourceType)
        {
            
        }
    }
}