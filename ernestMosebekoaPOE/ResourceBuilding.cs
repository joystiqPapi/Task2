using System.Linq;

namespace ernestMosebekoaPOE
{
    public class ResourceBuilding: Building
    {
        private ResourceType resourceType;
        private ResourceType[] generatedResources = new ResourceType [0];
        private const int generatedResourcesPerRound = 2;
        private int remainingResources = 10;
        private const char symbol = '^';
        private const int initialHealth = 100;
        private string buildingDescription = "";
        
        public ResourceBuilding(int xPosition, int yPosition, string team, ResourceType resourceType) : base(xPosition, yPosition, initialHealth, team, symbol)
        {
            buildingDescription = buildingDescription + team + "'created a new Resource Building at "+ xPosition + ":" + yPosition + "\n";
            this.resourceType = resourceType;
        }

        private int GetXPosition => base.xPosition;
        
        private int GetYPosition => base.yPosition;

        private char GetSymbol => base.symbol;

        private ResourceType[] generateResources()
        {
            if (generatedResources.Length > remainingResources)
            {
                buildingDescription = buildingDescription + team + "'s resource building has run out of resources to mine\n";
                return generatedResources;
            }
            
            System.Array.Resize(ref generatedResources, generatedResources.Length +1);
            int resourcePosition = generatedResources.Length - 1;
            generatedResources[resourcePosition] = resourceType;
            remainingResources = remainingResources -1;
            buildingDescription = buildingDescription + team + "'s resource building has has added "+ getResourceType() + " to their inventory\n";
            return generatedResources;
        }

        public override void onDestroyed()
        {
            buildingDescription = buildingDescription + team + "'s resource building has been destroyed\n";
            generatedResources = null;
        }

        public override string toString()
        {
            return buildingDescription;
        }

        public override PositionModel returnPosition()
        {
            return  new PositionModel(GetXPosition, GetYPosition);
        }

        public override char returnSymbol()
        {
            return GetSymbol;
        }

        public override void invokeSpeciality(IBuildingCallBack callBack, int round, int spawnUnitType)
        {
            callBack.generateResources(generateResources());
        }

        private string getResourceType()
        {
            switch (resourceType)
            {
                case ResourceType.METAL:
                    return "Metal";
                case ResourceType.WOOD:
                    return "Wood";
                case ResourceType.GUN_POWDER:
                    return "Gun Powder";
                default:
                    return "";
            }
        }
    }
}