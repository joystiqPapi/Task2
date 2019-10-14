namespace ernestMosebekoaPOE
{
    public abstract class Unit
    {
        //field protected definitions
        protected int xPosition;
        protected int yPosition;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected string team;
        protected char unitSymbol;
        protected bool isAttacking;
        protected string unitName;
        
        protected Unit(int xPosition, int yPosition, int health, int speed, int attack, int attackRange, string team,
            char unitSymbol, bool isAttacking, string unitName)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.team = team;
            this.unitSymbol = unitSymbol;
            this.isAttacking = isAttacking;
            this.unitName = unitName;
        }

        //abstract method definitions
        public abstract void move(int xPosition, int yPosition);
        public abstract void combat(int enemyAttackStrength);
        public abstract bool withinRange(int distance);
        public abstract int [] returnPosition();
        public abstract bool isDead();
        public abstract string toString();
        public abstract int returnAttackStrength();
        public abstract char returnSymbol();
        public abstract string returnUnitName();
    }
}