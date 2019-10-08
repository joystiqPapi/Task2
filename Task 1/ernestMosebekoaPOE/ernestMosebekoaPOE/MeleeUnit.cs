using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ernestMosebekoaPOE
{
    class MeleeUnit : Unit
    {
        private const int meleeAttackRange = 1;
        private const int meleeAttack = 5;
        private const int meleeSpeed = 1;
        private const int initialMelleHealth = 100;
        private const bool inMeleeUnitAttacking = false;
        private const String meleeTeamName = "MeleeTeam";
        private const Char meleeUnitSymbol = 'M';
        private int XPosition { get => base.xPosition; set => base.xPosition = value; }
        private int YPosition { get => base.yPosition; set => base.yPosition = value; }
        private int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth; }
        private int Speed { get => base.speed; set => base.speed = value; }
        private int Attack { get => base.attack; set => base.attack = value; }
        private int AttackRange { get => base.attackRange; set => base.attackRange = value; }
        private string Team { get => base.team; set => base.team = value; }
        private char UnitSymbol { get => base.unitSymbol; set => base.unitSymbol = value; }
        private bool IsAttacking { get => base.isAttacking; set => base.isAttacking = value; }
        
        public MeleeUnit(int xPosition, int yPosition) : base(xPosition, yPosition, initialMelleHealth, meleeSpeed, meleeAttack, meleeAttackRange, meleeTeamName, meleeUnitSymbol, inMeleeUnitAttacking)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public override void combat()
        {
            
        }
        public override bool isDead()
        {
            bool unitDead = false;
            if(Health <= 0)
            {
                unitDead = true;
            }
            return unitDead;
        }
        public override void move(int newXPosition, int newYPosition)
        {
            XPosition = newXPosition;
            YPosition = newYPosition;
        }
        public override void returnPosition()
        {
            
        }
        public override string toString()
        {
         //output message
         string sentence = "I am Melee Unit";
         return sentence;
        }
        public override bool withinRange()
        {
            //Melle can only attack from a range of 1
            
            bool withinRange = false;
            if (AttackRange == 1)
            {
                withinRange = true;
            }
            return withinRange;
        }
    }
}
