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

            new MockAttack(20).ExecuteAttack(attacker, defender); // Critical hit

            Assert.Equal(initialExperience + 10, attacker.ExperiencePoints);
        }

        [Fact]
        public void CharacterShouldNotAccumulateExperienceOnFailedAttack()
        {
            Character attacker = new Character("Pippin");
            Character defender = new Character("Orc");
            int initialExperience = attacker.ExperiencePoints;

            new MockAttack(1).ExecuteAttack(attacker, defender); // Critical hit

            Assert.Equal(initialExperience, attacker.ExperiencePoints);
        }
    }
}
