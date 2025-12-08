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
            defender.ArmorClass += defender.Dexterity;
            defender.HitPoints += defender.Constitution;

            if (roll >= defender.ArmorClass)
            {
                if (roll == 20) //Critical hit
                {
                    attacker.Strength = modifier * 2;
                    defender.HitPoints -= 2 + (attacker.Strength * 2);
                    attacker.ExperiencePoints += 10;
                    return;
                }
                attacker.Strength = modifier;

                int hitPointsToDeduct = (1 + attacker.Strength > 0) ? (1 + attacker.Strength) : 1;

                defender.HitPoints -= 1 + hitPointsToDeduct;

                attacker.ExperiencePoints += 10;
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
