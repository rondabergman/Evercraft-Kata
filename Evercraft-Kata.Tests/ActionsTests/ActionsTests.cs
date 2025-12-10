using Evercraft_Kata.Actions;
using static Evercraft_Kata.Helpers.Enums;


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
            int roll = 10;

            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            var defender = new Evercraft_Kata.Characters.Character("Defender");

            // Mocking a successful attack by setting a low armor class
            defender.ArmorClass = -20;
            int initialHitPoints = defender.HitPoints + (defender.Level * 5);

            new Attack().ExecuteAttack(attacker, defender, roll);

            Assert.True((initialHitPoints + defender.Constitution) > defender.HitPoints);
        }

        [Fact]
        public void AttackDoesNotReduceHitPointsOnMiss()
        {
            int roll = 0;

            roll = roll < 18 ? roll + 1 : 1;
            var modifier = Helpers.Calculations.GetAttackRollModifier(roll);

            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            var defender = new Evercraft_Kata.Characters.Character("Defender");
            int initialHitPoints = defender.HitPoints + defender.Constitution + (defender.Level * 5);

            // Mocking a miss by setting a high armor class
            defender.ArmorClass = 21;

            new Attack().ExecuteAttack(attacker, defender, roll);
            Assert.Equal(initialHitPoints, defender.HitPoints);
        }

        [Fact]
        public void AttackReducesHitPointsWith20RollAndArmorOver20()
        {
            int roll = 20;

            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            var defender = new Evercraft_Kata.Characters.Character("Defender");

            int initialHitPoints = defender.HitPoints + defender.Constitution + (defender.Level * 5);

            // Mocking a miss by setting a high armor class
            defender.ArmorClass = 35;

            new Attack().ExecuteAttack(attacker, defender, roll);
            Assert.Equal(initialHitPoints - 2, defender.HitPoints);
        }

        [Fact]
        public void RollOf20DoublesHitPointReduction()
        {
            int roll = 20;

            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            var defender = new Evercraft_Kata.Characters.Character("Defender");
            int initialHitPoints = defender.HitPoints + defender.Constitution;

            new Attack().ExecuteAttack(attacker, defender, roll);
            initialHitPoints -= (2 + (attacker.Strength) + roll);
            Assert.Equal(initialHitPoints, defender.HitPoints);
        }

        [Fact]
        public void AttackOnDefenderWith1HitPointKillsDefender()
        {
            int roll = 14;

            roll = roll < 19 ? roll + 1 : 10;

            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            var defender = new Evercraft_Kata.Characters.Character("Defender");
            int initialHitPoints = defender.HitPoints;

            attacker.Strength = 100;

            // Mocking a hit by setting a low armor class
            defender.ArmorClass = 1;

            // Mocking a kill shot by setting hit points to 1
            defender.HitPoints = 1;

            new Attack().ExecuteAttack(attacker, defender, roll);

            Assert.True(defender.IsAlive);
        }

        [Fact]
        public void AttackOnDefenderWith3HitPointsAttackerWith0ModifierStillAlive()
        {
            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            var defender = new Evercraft_Kata.Characters.Character("Defender");

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
            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            var defender = new Evercraft_Kata.Characters.Character("Defender");

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
            var modifier = Helpers.Calculations.GetAttackRollModifier(roll);

            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            var defender = new Evercraft_Kata.Characters.Character("Defender");
            var initialHitPoints = defender.HitPoints + (defender.Level * 5) + defender.Dexterity;

            new Attack().ExecuteAttack(attacker, defender, roll);

            if (defender.ArmorClass <= roll)
                Assert.True(defender.HitPoints < (4 + (defender.Level * 5)));
            else
                Assert.Equal(initialHitPoints, defender.HitPoints);
        }
    }

    public class ClassActionTests
    {
        [Fact]
        public void FighterHas10Hitpoints()
        {
            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            attacker.CharacterClass = ClassType.Fighter;

            Assert.Equal(10, attacker.HitPoints);
        }

        [Fact]
        public void RougeDoesTripleDamageOnCriticalHits()
        {
            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            attacker.CharacterClass = ClassType.Rogue;

            var defender = new Evercraft_Kata.Characters.Character("Defender");
            defender.ArmorClass = -30;

            new Attack().ExecuteAttack(attacker, defender, 20);

            Assert.Equal(-27, defender.HitPoints);
        }

        [Fact]
        public void MonkHas6PointHitPerLevel()
        {
            var attacker = new Evercraft_Kata.Characters.Character("Attacker");
            attacker.CharacterClass = ClassType.Monk;
            //attacker.ExperiencePoints = 3000;

            var defender = new Evercraft_Kata.Characters.Character("Defender");
            defender.ArmorClass = -30;

            new Attack().ExecuteAttack(attacker, defender, 20);

            Assert.Equal(-19, defender.HitPoints);
        }
    }
}
