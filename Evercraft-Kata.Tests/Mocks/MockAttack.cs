using Evercraft_Kata.Actions;
using Evercraft_Kata.Characters;
using Evercraft_Kata.Chracters;
using Evercraft_Kata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evercraft_Kata.Tests
{
    public class MockAttack(int mockRoll) : IAttack
    {
        public void ExecuteAttack(Character attacker, Character defender)
        {
            int roll = mockRoll;

            var modifier = Attributes.GetModifier(roll);
            var armor = defender.ArmorClass + modifier;
            defender.Constitution = modifier;
            defender.HitPoints += defender.Constitution;

            if (roll == 20) //Critical hit
            {
                if (armor >= 20)
                {
                    defender.HitPoints -= 1; // Minimum damage on critical hit if armor is too high
                }
                else
                {
                    defender.HitPoints -= 2 + (modifier * 2);
                }

                attacker.ExperiencePoints += 10;
            }
            else if (roll >= defender.ArmorClass)
            {
                int hitPointsToDeduct = (1 + modifier > 0) ? (1 + modifier) : 1;
                defender.HitPoints -= 1 + hitPointsToDeduct;

                attacker.ExperiencePoints += 10;
            }

            if (defender.HitPoints < 1)
            {
                defender.IsAlive = false;
            }
        }
    }
}
