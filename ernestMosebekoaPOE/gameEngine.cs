using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ernestMosebekoaPOE
{
    class gameEngine: IBuildingCallBack
    { //class variable
        int numberOfRoundsCompleted = 0;
        private Map battleField;

        public gameEngine(Map battleField)
        {
            this.battleField = battleField;
        }

        public void initiateBattle()
        {
            Unit[] unitList = battleField.getUnits();
            for (int count = 0; count < unitList.Length; count++)
            {
                Unit unit = unitList[count];
                if (!unit.isDead())
                {
                    if (isFitForBattle(unit.returnAttackStrength()))
                    {
                        attackClosestEnemy(unit, unitList);
                    }
                    else
                    {
                        battleField.unitRunAway(unit);
                    }
                }
            }

            Building[] buildings = battleField.getBuildings();
            Random random = new Random();
            for (int count = 0; count < buildings.Length; count++)
            {
                Building building = buildings[count];
                building.invokeSpeciality(this, numberOfRoundsCompleted, random.Next(0,2));
            }
            numberOfRoundsCompleted++;
            battleField.showRounds(numberOfRoundsCompleted);
        }

        private void attackClosestEnemy(Unit attackingUnit, Unit [] unitList)
        {
            int[] closestEnemyDetails = battleField.getClosestEnemy(attackingUnit);
            Unit closestEnemy = unitList[closestEnemyDetails[0]];
            int closestEnemyDistance = closestEnemyDetails[1];

            if (attackingUnit.withinRange(closestEnemyDistance))
            {
                closestEnemy.combat(attackingUnit.returnAttackStrength());
                battleField.getUnits()[closestEnemyDetails[0]] = closestEnemy;
            }
        }

        private bool isFitForBattle(int unitHealth)
        {
            return unitHealth >= 25;
        }

        public void generateResources(ResourceType[] resource)
        {
            battleField.handleResourceGeneration(resource);
        }

        public void spawnUnit(Unit spawnedUnit)
        {
            battleField.addSpawnedUnitToBattlefield(spawnedUnit);
        }
    }
}
