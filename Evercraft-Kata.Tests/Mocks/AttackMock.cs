using Evercraft_Kata.Actions;
using Evercraft_Kata.Chracters;
using Evercraft_Kata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evercraft_Kata.Tests
{
    public class AttackMockNo20 : IAttack
    {
        public void ExecuteAttack(Character attacker, Character defender)
        {
            int roll = Roll.RollDie();

            if (roll == 20)
            {
                roll = 19; // Force a non-critical hit
            }

            if (roll == 20)
            {
                defender.HitPoints -= 2;
            }
            else if (roll >= defender.ArmorClass || roll == 20)
            {
                defender.HitPoints -= 1;
            }

            if (defender.HitPoints < 1)
            {
                defender.IsAlive = false;
            }
        }
    }

    public class AttackMockAlways20 : IAttack
    {
        public void ExecuteAttack(Character attacker, Character defender)
        {
            int roll = Roll.RollDie();
            
            if (roll != 20)
            {
                roll = 20; // Force a critical hit
            }

            if (roll == 20)
            {
                defender.HitPoints -= 2;
            }
            else if (roll >= defender.ArmorClass || roll == 20)
            {
                defender.HitPoints -= 1;
            }

            if (defender.HitPoints < 1)
            {
                defender.IsAlive = false;
            }
        }
    }

}
