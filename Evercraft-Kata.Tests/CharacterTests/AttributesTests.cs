using Xunit;
using Evercraft_Kata.Chracters;

namespace Evercraft_Kata.Tests
{
    public class AttributesTests
    {
        [Fact]
        public void CharactersShouldHaveAttributesThatDefaultTo10()
        {
            Character character = new Character("Thorin");
            Assert.Equal(10, character.Strength);
            Assert.Equal(10, character.Dexterity);
            Assert.Equal(10, character.Constitution);
            Assert.Equal(10, character.Intelligence);
            Assert.Equal(10, character.Wisdom);
            Assert.Equal(10, character.Charisma);
        }
    }
}
