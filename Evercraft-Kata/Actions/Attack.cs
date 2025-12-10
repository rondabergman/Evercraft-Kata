using Evercraft_Kata.Characters;
using static Evercraft_Kata.Helpers.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evercraft_Kata.Actions
{
    // Remove static modifier and implement IAttack as an instance class
    public class Attack
    {
        public void ExecuteAttack(Character attacker, Character defender, int roll)
        {
            defender.ArmorClass += defender.Dexterity;
            defender.HitPoints += defender.Constitution;

            if (roll >= defender.ArmorClass)
            {
                defender.HitPoints -= (CalculateAttackScore(roll, attacker));
                attacker.ExperiencePoints += 10;
                return;
            }
            else if (roll == 20) //Critical hit
            {
                defender.HitPoints -= 2;
                attacker.ExperiencePoints += 10;
            }

            if (defender.HitPoints < 1)
            {
                defender.IsAlive = false;
            }
        }
    }
}
