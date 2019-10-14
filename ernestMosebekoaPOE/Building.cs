namespace ernestMosebekoaPOE
{
    public abstract class Building
    {
        protected int xPosition;
        protected int yPosition;
        protected int health;
        protected int maxHealth;
        protected string team;
        protected char symbol;

        public abstract void onDestroyed();
        public abstract string toString();
        public abstract PositionModel returnPosition();
        public abstract char returnSymbol();
        public abstract void invokeSpeciality(IBuildingCallBack callBack, int round, int spawnUnitType);

        protected Building(int xPosition, int yPosition, int health, string team, char symbol)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
        }
    }
}