namespace ernestMosebekoaPOE
{
    public interface IBuildingCallBack
    {
        void generateResources(ResourceType[] resource);

        void spawnUnit(Unit spawnedUnit);
    }
}