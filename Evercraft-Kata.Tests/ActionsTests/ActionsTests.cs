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
            int roll = 0;

            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                roll = roll < 20 ? roll + 1 : 1;

                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");

                // Mocking a successful attack by setting a low armor class
                defender.ArmorClass = 1;
                int initialHitPoints = defender.HitPoints;

                // Using the MockAttack to ensure a roll of less than 20
                new MockAttack(roll).ExecuteAttack(attacker, defender);

                Assert.True(initialHitPoints > defender.HitPoints);
            }
        }

        [Fact]
        public void AttackDoesNotReduceHitPointsOnMiss()
        {
            int roll = 0;

            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                roll = roll < 19 ? roll + 1 : 1;
                var modifier = Attributes.GetModifier(roll);

                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int initialHitPoints = defender.HitPoints + modifier;

                // Mocking a miss by setting a high armor class
                defender.ArmorClass = 21;

                // Using the AttackMock to ensure a roll of less than 20
                new MockAttack(roll).ExecuteAttack(attacker, defender);
                Assert.Equal(initialHitPoints, defender.HitPoints);
            }
        }

        [Fact]
        public void AttackReducesHitPointsWith20RollAndArmorOver20()
        {
            int roll = 20;

            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int initialHitPoints = defender.HitPoints;
                var modifier = Attributes.GetModifier(roll);

                // Mocking a miss by setting a high armor class
                defender.ArmorClass = 21;

                // Using the AttackMock to ensure a roll of 20
                new MockAttack(roll).ExecuteAttack(attacker, defender);
                Assert.Equal(initialHitPoints - 1, defender.HitPoints);
            }
        }

        [Fact]
        public void RollOf20DoublesHitPointReduction()
        {
            int roll = 20;

            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int initialHitPoints = defender.HitPoints;
                var modifier = Attributes.GetModifier(roll);

                // Using the AttackMock to ensure a roll of 20
                new MockAttack(roll).ExecuteAttack(attacker, defender);
                Assert.Equal(initialHitPoints - (2 + modifier * 2), defender.HitPoints);
            }
        }

        [Fact]
        public void AttackOnDefenderWith1HitPointKillsDefender()
        {
            int roll = 0;

            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                roll = roll < 19 ? roll + 1 : 1;

                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int initialHitPoints = defender.HitPoints;

                // Mocking a hit by setting a low armor class
                defender.ArmorClass = 1;

                // Mocking a kill shot by setting hit points to 1
                defender.HitPoints = 1;

                // Using the AttackMock to ensure a roll of less than 20
                new MockAttack(roll).ExecuteAttack(attacker, defender);

                Assert.False(defender.IsAlive);
            }
        }

        [Fact]
        public void AttackOnDefenderWith3HitPointsAttackerWith0ModifierStillAlive()
        {
            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
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
                new Attack().ExecuteAttack(attacker, defender);

                Assert.True(defender.IsAlive);
            }
        }
        [Fact]
        public void AttackOnDefenderWith1HitPointsAttackerWith3StrengthKillsDefener()
        {
            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");

                int initialHitPoints = defender.HitPoints;

                // Mocking a hit by setting a low armor class
                defender.ArmorClass = 1;

                attacker.Strength = 3;

                // Mocking a kill shot by setting hit points to 3
                defender.HitPoints = 1;
                new Attack().ExecuteAttack(attacker, defender);

                Assert.False(defender.IsAlive);
            }
        }

        [Fact]
        public void AttackOnDefenderUsingDexterity()
        {
            int roll = 0;

            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                roll = roll < 20 ? roll + 1 : 1;
                var modifier = Attributes.GetModifier(roll);

                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");

                new MockAttack(roll).ExecuteAttack(attacker, defender);
                
                if (defender.ArmorClass <= roll)
                    Assert.True(defender.HitPoints < 4);
                else
                    Assert.Equal(5 + modifier, defender.HitPoints);
            }
        }
    }
}
