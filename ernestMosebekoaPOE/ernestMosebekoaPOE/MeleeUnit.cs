using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ernestMosebekoaPOE
{
    class MeleeUnit : Unit
    {
        public int XPosition { get => base.xPosition; set => base.xPosition = value; }
        public int YPosition { get => base.yPosition; set => base.yPosition = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth; }
        public int Speed { get => base.speed; set => base.speed = value; }
        public int Attack { get => base.attack; set => base.attack = value; }
        public int AttackRange { get => base.attackRange; set => base.attackRange = value; }
        public string Team { get => base.team; set => base.team = value; }
        public char UnitSymbol { get => base.unitSymbol; set => base.unitSymbol = value; }
        public bool IsAttacking { get => base.isAttacking; set => base.isAttacking = value; }
        public MeleeUnit(int xPosition, int yPosition) : base(xPosition, yPosition, 100, 1, 5, 1, "Melee", 'M', false)
        {
            base.xPosition = xPosition;
            base.yPosition = yPosition;
            base.health = Health;
            base.speed = speed;
  
        }

       

        public override void combat()
        {
      
        }
        public override void isDead()
        {
        
        }
        public override void move()
        {
        
        }
        public override void returnPosition()
        {
         
        }
        public override void toString()
        {
          
        }
        public override void withinRange()
        {
  
        }
    }
}
