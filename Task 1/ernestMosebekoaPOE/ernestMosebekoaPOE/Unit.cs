﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ernestMosebekoaPOE
{
    abstract class Unit
    {   //field protected definitions
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

        Random r = new Random();


        public Unit(int xPosition, int yPosition, int health, int speed, int attack, int attackRange, string team, char unitSymbol,bool isAttacking)
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

            
        }
                
        //abstract method definitions
        public  abstract void move();
       public abstract void combat();
       public abstract bool withinRange();
       public abstract void returnPosition();
       public abstract bool isDead();
       public abstract string toString();


    }
}
