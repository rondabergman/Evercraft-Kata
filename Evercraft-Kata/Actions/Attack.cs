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

            if (roll == 20)
            {
                defender.HitPoints -= 2;
            }
            else if (roll >= defender.ArmorClass || roll == 20)
            {
                defender.HitPoints -= 1;
            }
        }
    }
}
