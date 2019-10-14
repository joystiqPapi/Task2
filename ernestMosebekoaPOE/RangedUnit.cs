namespace ernestMosebekoaPOE
{
    class RangedUnit : Unit
    {
        private const int RangedAttackRange = 1;
        private const int RangedAttack = 5;
        private const int RangedSpeed = 1;
        private const int InitialRangedHealth = 100;
        private const bool IsRangedUnitAttacking = false;
        private const char RangedUnitSymbol = 'R';

        public const string TANK_UNIT_NAME = "Tank"; 
        public const string CANNON_UNIT_NAME = "Cannon"; 
        private string unitActivity;

        public int XPosition { get => base.xPosition; set => base.xPosition = value; }
        public int YPosition { get => base.yPosition; set => base.yPosition = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get =>base. maxHealth; }
        public int Speed { get => base.speed; set => base.speed = value; }
        public int Attack { get => base.attack; set => base.attack = value; }
        public int AttackRange { get => base.attackRange; set => base.attackRange = value; }
        public string Team { get => base.team; set => base.team = value; }
        public char UnitSymbol { get => base.unitSymbol; set => base.unitSymbol = value; }
        public bool IsAttacking { get => base.isAttacking; set => base.isAttacking = value; }
        public string UnitName { get => base.unitName; set => base.unitName = value; }
        
        public RangedUnit(int xPosition, int yPosition, string teamName, string unitName) : base(xPosition, yPosition, InitialRangedHealth, RangedSpeed, RangedAttack, RangedAttackRange, teamName, RangedUnitSymbol, IsRangedUnitAttacking, unitName)
        {
        }

        public override void move(int newXPosition, int newYPosition)
        {
            unitActivity += " has moved from (" + XPosition + "," + YPosition + ") position to (" + newXPosition + "," + newXPosition + ")\n";
            XPosition = newXPosition;
            YPosition = newYPosition;
        }

        public override void combat(int enemyAttackStrength)
        {
            int newHealth = Health - enemyAttackStrength;
            unitActivity += " has taken a blow of " + enemyAttackStrength + " which drops it's health from" + Health + "to " + newHealth + "\n";
            Health = newHealth;
        }
        
        public override bool isDead()
        {
            bool isDead = Health <= 0;
            if (isDead)
            {
                unitActivity += " has been destroyed\n";
            }
            return Health <= 0;
        }
        public override string toString()
        {           
            return Team + unitActivity;
        }

        public override int returnAttackStrength()
        {
            unitActivity += " has initiated an attack on " + Attack + "\n";
            isAttacking = true;
            return Attack;
        }

        public override int [] returnPosition()
        {
            int[] unitPosition = new int[2];
            unitPosition[Map.X_POSITION_IN_UNIT_POSITION_LIST] = XPosition;
            unitPosition[Map.Y_POSITION_IN_UNIT_POSITION_LIST] = YPosition;
            return unitPosition;
        }

        public override bool withinRange(int distance)
        {
            return AttackRange <= distance;
        }

        public override char returnSymbol()
        {
            return UnitSymbol;
        }

        public override string returnUnitName()
        {
            return UnitName;
        }
    }
}

