using Evercraft_Kata.Chracters;
using Evercraft_Kata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evercraft_Kata.Actions
{
    // Remove static modifier and implement IAttack as an instance class
    public class Attack : IAttack
    {
        public void ExecuteAttack(Character attacker, Character defender)
        {
            int roll = Roll.RollDie();

            if (roll == 20) //Critical hit
            {
                defender.HitPoints -= 2 + (attacker.Strength * 2);
            }
            else if (roll >= defender.ArmorClass)
            {
                int hitPointsToDeduct = (1 + attacker.Strength > 0) ? (1 + attacker.Strength) : 1 ;
                defender.HitPoints -= 1 + hitPointsToDeduct;
            }

            if (defender.HitPoints < 1)
            {
                defender.IsAlive = false;
            }
        }
    }
}
