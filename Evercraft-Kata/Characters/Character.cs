
namespace Evercraft_Kata.Chracters
{
    public enum Alignment
    {
        Good,
        Neutral,
        Evil
    }

    public class Character
    {
        private string _name = string.Empty;
        private Alignment _alignment = Alignment.Neutral;
        private int armorClass = 10;
        private int hitPoints = 5;

        public Character(string name)
        {
            Name = name;
        }

        public string Name { get => _name; set => _name = value; }
        public Alignment Alignment { get => _alignment; set => _alignment = value; }
        public int ArmorClass { get => armorClass; set => armorClass = value; }
        public int HitPoints { get => hitPoints; set => hitPoints = value; }
    }
}