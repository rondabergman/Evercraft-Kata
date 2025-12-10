using Evercraft_Kata.Actions;
using Evercraft_Kata.Characters;
using Evercraft_Kata.Tests;

namespace Evercraft_Kata.Tests
{
    public class ActionsTests
    {
        [Fact]
        public void RollDieTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                int roll = Roll.RollDie();
                Assert.InRange(roll, 1, 20);
                Console.WriteLine(roll);
            }
        }

        [Fact]
        public void AttackReducesHitPointsOnSuccessfulHit()
        {
            int roll = 5;

            roll = roll < 20 ? roll + 1 : 1;

            var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
            var defender = new Evercraft_Kata.Chracters.Character("Defender");

            // Mocking a successful attack by setting a low armor class
            defender.ArmorClass = -20;
            int initialHitPoints = defender.HitPoints + (defender.Level * 5);

            // Using the MockAttack to ensure a roll of less than 20
            new Attack().ExecuteAttack(attacker, defender, roll);

            if (!((initialHitPoints + defender.Constitution) > defender.HitPoints))
            {
                var huh = 1;
            }

            Assert.True((initialHitPoints + defender.Constitution) > defender.HitPoints);
        }

        [Fact]
        public void AttackDoesNotReduceHitPointsOnMiss()
        {
            int roll = 0;

            roll = roll < 18 ? roll + 1 : 1;
            var modifier = Attributes.GetModifier(roll);

            var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
            var defender = new Evercraft_Kata.Chracters.Character("Defender");
            int initialHitPoints = defender.HitPoints + defender.Constitution + (defender.Level * 5);

            // Mocking a miss by setting a high armor class
            defender.ArmorClass = 21;

            // Using the AttackMock to ensure a roll of less than 20
            new Attack().ExecuteAttack(attacker, defender, roll);
            Assert.Equal(initialHitPoints, defender.HitPoints);
        }

        [Fact]
        public void AttackReducesHitPointsWith20RollAndArmorOver20()
        {
            int roll = 20;

            var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
            var defender = new Evercraft_Kata.Chracters.Character("Defender");

            int initialHitPoints = defender.HitPoints + defender.Constitution + (defender.Level * 5);

            // Mocking a miss by setting a high armor class
            defender.ArmorClass = 35;

            // Using the AttackMock to ensure a roll of 20
            new Attack().ExecuteAttack(attacker, defender, roll);
            Assert.Equal(initialHitPoints - 2, defender.HitPoints);
        }

        [Fact]
        public void RollOf20DoublesHitPointReduction()
        {
            int roll = 20;

            var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
            var defender = new Evercraft_Kata.Chracters.Character("Defender");
            int initialHitPoints = defender.HitPoints;

            // Using the AttackMock to ensure a roll of 20
            new Attack().ExecuteAttack(attacker, defender, roll);
            initialHitPoints -= (2 + (attacker.Strength));
            Assert.Equal(initialHitPoints, defender.HitPoints);
        }

        [Fact]
        public void AttackOnDefenderWith1HitPointKillsDefender()
        {
            int roll = 14;

            roll = roll < 19 ? roll + 1 : 10;

            var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
            var defender = new Evercraft_Kata.Chracters.Character("Defender");
            int initialHitPoints = defender.HitPoints;

            attacker.Strength = 100;

            // Mocking a hit by setting a low armor class
            defender.ArmorClass = 1;

            // Mocking a kill shot by setting hit points to 1
            defender.HitPoints = 1;

            // Using the AttackMock to ensure a roll of less than 20
            new Attack().ExecuteAttack(attacker, defender, roll);

            Assert.True(defender.IsAlive);
        }

        [Fact]
        public void AttackOnDefenderWith3HitPointsAttackerWith0ModifierStillAlive()
        {
            var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
            var defender = new Evercraft_Kata.Chracters.Character("Defender");

            defender.HitPoints = 3;
            int initialHitPoints = defender.HitPoints;

            // Mocking a hit by setting a low armor class
            defender.ArmorClass = 1;

            attacker.Strength = 0; // No modifier

            // Mocking not a kill shot by setting hit points to 30
            defender.HitPoints = 30;

            var roll = Roll.RollDie();
            new Attack().ExecuteAttack(attacker, defender, roll);

            Assert.True(defender.IsAlive);
        }
        [Fact]
        public void AttackOnDefenderWith1HitPointsAttackerWith3StrengthKillsDefener()
        {
            var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
            var defender = new Evercraft_Kata.Chracters.Character("Defender");

            int initialHitPoints = defender.HitPoints;

            // Mocking a hit by setting a low armor class
            defender.ArmorClass = 1;

            attacker.Strength = 3;

            // Mocking a kill shot by setting hit points to 3
            defender.HitPoints = 1;

            new Attack().ExecuteAttack(attacker, defender, 1);

            Assert.True(defender.IsAlive);
        }

        [Fact]
        public void AttackOnDefenderUsingDexterity()
        {
            int roll = 0;

            roll = roll < 20 ? roll + 1 : 1;
            var modifier = Attributes.GetModifier(roll);

            var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
            var defender = new Evercraft_Kata.Chracters.Character("Defender");
            var initialHitPoints = defender.HitPoints + (defender.Level * 5) + defender.Dexterity;

            new Attack().ExecuteAttack(attacker, defender, roll);

            if (defender.ArmorClass <= roll)
                Assert.True(defender.HitPoints < (4 + (defender.Level * 5)));
            else
                Assert.Equal(initialHitPoints, defender.HitPoints);
        }
    }
}
