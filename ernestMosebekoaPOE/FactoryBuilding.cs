using System;

namespace ernestMosebekoaPOE
{
    public class FactoryBuilding: Building
    {
        public const int PRODUCE_MELEE_UNIT = 1;
        public const int PRODUCE_RANGED_UNIT = 2;

        private const int productionSpeed = 3;
        
        private int unitTypeToProduce;
        private PositionModel spawnPoint;
        private Random randomizer;
        private int mapSize;
        private const char symbol = '^';
        private const int InitialHealth = 100;
        private string buildingDescription = "";
        
        public FactoryBuilding(int xPosition, int yPosition, string team, int mapSize) : base(xPosition, yPosition, InitialHealth, team, symbol)
        {
            buildingDescription = buildingDescription + team + "'created a new Factory Building at "+ xPosition + ":" + yPosition + "\n";
            randomizer = new Random();
            this.mapSize = mapSize;
        }
        public int GetFactoryXPosition => base.xPosition;
        public int GetFactoryYPosition => base.yPosition;
        public int ProductionSpeed => productionSpeed;
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth; set => base.maxHealth = value; }
        public string Team { get => base.team; set => base.team = value; }
        public char Symbol { get => base.symbol; set => base.symbol = value; }

        public override void onDestroyed()
        {
            buildingDescription = buildingDescription + team + "'s factory building has been destroyed\n";
        }

        public override string toString()
        {
            return buildingDescription;
        }

        public override PositionModel returnPosition()
        {
            return  new PositionModel(GetFactoryXPosition, GetFactoryYPosition);
        }

        public override char returnSymbol()
        {
            return Symbol;
        }

        public override void invokeSpeciality(IBuildingCallBack callBack, int round, int spawnUnitType)
        {
            if (round % ProductionSpeed == 0)
            {
                Unit spawnedUnit = spawnUnit(spawnUnitType);
                callBack.spawnUnit(spawnedUnit);
            }
        }

        private Unit spawnUnit(int spawnUnitType)
        {
            switch (spawnUnitType)
            {
                case PRODUCE_MELEE_UNIT:
                    return buildMeleeUnit();
                case PRODUCE_RANGED_UNIT:
                    return buildRangedUnit();
                default:
                    return buildMeleeUnit();
            }
        }

        private MeleeUnit buildMeleeUnit()
        {
            PositionModel spawnPositionModel = getSpawnUnitPosition();
            string meleeUnitName = generateMeleeUnitName();
            return new MeleeUnit(spawnPositionModel.XPosition, spawnPositionModel.YPosition, Team, meleeUnitName);
        }

        private RangedUnit buildRangedUnit()
        {
            PositionModel spawnPositionModel = getSpawnUnitPosition();
            string rangedUnitName = generateRangedUnitName();
            return new RangedUnit(spawnPositionModel.XPosition, spawnPositionModel.YPosition, Team, rangedUnitName);
        }

        private PositionModel getSpawnUnitPosition()
        {
            int factoryYPosition = GetFactoryYPosition;
            int unitSpawnXPosition = GetFactoryXPosition;
            
            if (factoryYPosition == mapSize)
            {
                return new PositionModel(unitSpawnXPosition, factoryYPosition -1);
            } else
            {
                return new PositionModel(unitSpawnXPosition, factoryYPosition +1);
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
    }
}