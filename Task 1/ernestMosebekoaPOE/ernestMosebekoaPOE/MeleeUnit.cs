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

        Random r = new Random();
        public MeleeUnit(int xPosition, int yPosition) : base(xPosition, yPosition, 100, 1, 5, 1, "Melee", 'M', false)
        {
            base.xPosition = xPosition;
            base.yPosition = yPosition;
            base.health = Health;
            base.speed = speed;
            int enemyXPosition = r.Next(1, 20);
            int enemyYposition = r.Next(1, 20);

            

           


  
        }

       

        public override void combat()
        {
      //
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
        public override void move()
        {
            ///move to a new position
            /////first find the unit position
            /// //getting unit position and enemy position,THAT PYTHAGORAS SHIT MAN
            yPosition = r.Next(1, 20);
            xPosition = r.Next(1, 20);
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {  
                    MeleeUnit[,] unitPosition = new MeleeUnit[yPosition, xPosition];
                   
                }
            }

        }
        public override void returnPosition()
        {
         //can you see?
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
