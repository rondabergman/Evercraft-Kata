using Xunit;
using Evercraft_Kata.Chracters;

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
    }
}
