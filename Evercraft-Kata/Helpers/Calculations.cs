using Evercraft_Kata.Characters;
using static Evercraft_Kata.Helpers.Enums;

namespace Evercraft_Kata.Helpers
{
    public static class Calculations
    {
        public static int CalculateAttackScore(int roll, Character attacker)
        {
            var strength = Attributes.GetModifier(roll);

            if (attacker.CharacterClass == ClassType.Rogue)
            {
                strength += strength;
            }
            else if (attacker.CharacterClass == ClassType.Monk)
            {
                strength += 1; // Monks get +1 damage per level
            }

            if (roll == 20)
            { 
                strength += strength;
            }

            var attackModifier = GetAttackRollModifier(roll);
            int attackScore = roll + strength + attackModifier;
            return attackScore;
        }

        public static int GetAttackRollModifier(int roll)
        {
            if (roll == 20)
            {
                return 2; // Critical hit modifier
            }
            else
            {
                return 1;
            }
        }
    }
}
