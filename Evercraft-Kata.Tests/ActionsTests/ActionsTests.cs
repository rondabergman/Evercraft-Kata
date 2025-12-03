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
                int roll = Evercraft_Kata.Actions.Roll.RollDie();
                Assert.InRange(roll, 1, 20);
                Console.WriteLine(roll);
            }
        }

        [Fact]
        public void AttackReducesHitPointsOnSuccessfulHit()
        {
            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");

                // Mocking a successful attack by setting a low armor class
                defender.ArmorClass = 1;
                int initialHitPoints = defender.HitPoints;

                // Using the AttackMockNo20 to ensure a roll of less than 20
                new AttackMockNo20().ExecuteAttack(attacker, defender);

                Assert.True(initialHitPoints > defender.HitPoints);
            }
        }

        [Fact]
        public void AttackDoesNotReduceHitPointsOnMiss()
        {
            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int initialHitPoints = defender.HitPoints;

                // Mocking a miss by setting a high armor class
                defender.ArmorClass = 21;
                // Using the AttackMockNo20 to ensure a roll of less than 20
                new AttackMockNo20().ExecuteAttack(attacker, defender);
                Assert.Equal(initialHitPoints, defender.HitPoints);
            }
        }

        [Fact]
        public void AttackReducesHitPointsWith20RollAndArmorOver20()
        {
            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int initialHitPoints = defender.HitPoints;

                // Mocking a miss by setting a high armor class
                defender.ArmorClass = 21;
                // Using the AttackMockAlways20 to ensure a roll of 20
                new AttackMockAlways20().ExecuteAttack(attacker, defender);
                Assert.Equal(initialHitPoints -2, defender.HitPoints);
            }
        }

        [Fact]
        public void RollOf20DoublesHitPointReduction()
        {
            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int initialHitPoints = defender.HitPoints;
                // Using the AttackMockAlways20 to ensure a roll of 20
                new AttackMockAlways20().ExecuteAttack(attacker, defender);
                Assert.Equal(initialHitPoints - 2, defender.HitPoints);
            }
        }

        [Fact]
        public void AttackOnDefenderWith1HitPointKillsDefender()
        {
            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int initialHitPoints = defender.HitPoints;
                // Mocking a hit by setting a low armor class
                defender.ArmorClass = 1;
                // Mocking a kill shot by setting hit points to 1
                defender.HitPoints = 1;
                // Using the AttackMockNo20 to ensure a roll of less than 20
                new AttackMockNo20().ExecuteAttack(attacker, defender);
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

                attacker.Strength = 3; // modifier

                // Mocking a kill shot by setting hit points to 3
                defender.HitPoints = 1;
                new Attack().ExecuteAttack(attacker, defender);

                Assert.False(defender.IsAlive);
            }
        }

        [Fact] 
        public void AttackChangesAttributesOfCharactersCorrectly()
        {
            for (int i = 0; i < 100; i++) // Multiple attempts to ensure working
            {
                var attacker = new Evercraft_Kata.Chracters.Character("Attacker");
                var defender = new Evercraft_Kata.Chracters.Character("Defender");
                int attackerInitialHitPoints = attacker.HitPoints;
                int defenderInitialHitPoints = defender.HitPoints;

                // Mocking a hit by setting a low armor class
                defender.ArmorClass = 1;
                new Attack().ExecuteAttack(attacker, defender);

                // Attacker's hit points should remain unchanged
                Assert.Equal(attackerInitialHitPoints, attacker.HitPoints);

                // Defender's hit points should be reduced by at least 1
                Assert.True(defender.HitPoints < defenderInitialHitPoints);
            }
        }
    }
}
