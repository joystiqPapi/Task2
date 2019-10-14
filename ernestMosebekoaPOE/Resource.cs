namespace ernestMosebekoaPOE
{
    public class Resource
    {
        private int resourceType;

        public Resource(int resourceType)
        {
            this.resourceType = resourceType;
        }

        public int ResourceType => resourceType;
    }
}