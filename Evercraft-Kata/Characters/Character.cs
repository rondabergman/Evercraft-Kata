

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

        private int _strength = 10;
        private int _dexterity = 10;
        private int _constitution = 10;
        private int _intelligence = 10;
        private int _wisdomh = 10;
        private int _charisma = 10;

        private int _experiencePoints = 0;

        public Character(string name)
        {
            Name = name;
        }

        public string Name { get => _name; set => _name = value; }
        public Alignment Alignment { get => _alignment; set => _alignment = value; }
        public int ArmorClass { get => _armorClass; set => _armorClass = value; }
        public int HitPoints { get => _hitPoints; set => _hitPoints = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public int Strength { get => _strength; set => _strength = value; }
        public int Dexterity { get => _strength; set => _strength = value; }
        public int Constitution { get => _strength; set => _strength = value; }
        public int Intelligence { get => _strength; set => _strength = value; }
        public int Wisdom { get => _strength; set => _strength = value; }
        public int Charisma { get => _strength; set => _strength = value; }
        public int ExperiencePoints { get => _experiencePoints; set => _experiencePoints = value; }
    }
}