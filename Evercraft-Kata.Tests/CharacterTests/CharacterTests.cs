using Evercraft_Kata.Actions;
using Evercraft_Kata.Chracters;
using Xunit;

namespace Evercraft_Kata.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void CharactersShouldHaveAName()
        {
            Character character = new Character("Gandalf");
            Assert.Equal("Gandalf", character.Name);
        }

        [Fact]
        public void CharacterShouldHaveAnAlignment()
        {
            Character character = new Character("Aragorn");
            character.Alignment = Alignment.Good;
            Assert.Equal(Alignment.Good, character.Alignment);
        }

        [Fact]
        public void CharacterShouldDefaultToNeutralAlignment()
        {
            Character character = new Character("Legolas");
            Assert.Equal(Alignment.Neutral, character.Alignment);
        }

        [Fact]
        public void CharacterShouldDefaultTo10ArmorClass()
        {
            Character character = new Character("Boromir");
            Assert.Equal(10, character.ArmorClass);
        }

        [Fact]
        public void CharacterShouldAllowSettingArmorClass()
        {
            Character character = new Character("Frodo");
            character.ArmorClass = 15;
            Assert.Equal(15, character.ArmorClass);
        }

        [Fact]
        public void CharacterShouldDefaultto5HitPoints()
        {
            Character character = new Character("Samwise");
            Assert.Equal(5, character.HitPoints);
        }

        [Fact]
        public void CharacterShouldBeAliveByDefault()
        {
            Character character = new Character("Merry");
            Assert.True(character.IsAlive);
        }

        [Fact]
        public void CharacterShouldHaveAbilityToAccumulateExperiencePoints()
        {
            Character attacker = new Character("Pippin");
            int initialExperience = attacker.ExperiencePoints;

            attacker.ExperiencePoints += 10;
            Assert.Equal(initialExperience + 10, attacker.ExperiencePoints);
        }

        [Fact]
        public void CharacterExperiencePointsShouldDefaultToZero()
        {
            Character attacker = new Character("Pippin");

            Assert.Equal(0, attacker.ExperiencePoints);
        }

        [Fact]
        public void CharacterShouldAccumulateExperienceOnSuccesfulAttack()
        {
            Character attacker = new Character("Pippin");
            Character defender = new Character("Orc");
            int initialExperience = attacker.ExperiencePoints;

            new Attack().ExecuteAttack(attacker, defender, 20);// Critical hit

            Assert.Equal(initialExperience + 10, attacker.ExperiencePoints);
        }

        [Fact]
        public void CharacterShouldNotAccumulateExperienceOnFailedAttack()
        {
            Character attacker = new Character("Pippin");
            Character defender = new Character("Orc");
            int initialExperience = attacker.ExperiencePoints;

            new MockAttack(1).ExecuteAttack(attacker, defender); 

            Assert.Equal(initialExperience, attacker.ExperiencePoints);
        }

        [Fact]
        public void CharacterShouldHaveALevelDefaultsTo0()
        {
            Character character = new Character("Gimli");
            Assert.Equal(0, character.Level);
        }

        [Fact]
        public void CharacterShouldLevelUpWithEach1000ExperiencePoints()
        {
            Character attacker = new Character("Gimli");
            Character defender = new Character("Loser");
            attacker.ExperiencePoints = 990;

            new MockAttack(20).ExecuteAttack(attacker, defender); // Critical hit

            Assert.Equal(2, attacker.Level);
        }

        [Fact]
        public void CharacterForEachLevelHitPointsIncreaseBy5PlusConModifier()
        {
            Character character = new Character("Gimli");
            character.ExperiencePoints = 1000;
           
            Assert.Equal(15, character.HitPoints + character.Constitution);
        }
    }
}

