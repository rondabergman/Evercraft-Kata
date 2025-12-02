
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
        private int _armorClass = 10;
        private int _hitPoints = 5;
        private bool _isAlive = true;

        public Character(string name)
        {
            Name = name;
        }

        public string Name { get => _name; set => _name = value; }
        public Alignment Alignment { get => _alignment; set => _alignment = value; }
        public int ArmorClass { get => _armorClass; set => _armorClass = value; }
        public int HitPoints { get => _hitPoints; set => _hitPoints = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
    }
}