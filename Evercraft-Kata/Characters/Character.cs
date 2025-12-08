

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
        private int _wisdom = 10;
        private int _charisma = 10;

        private int _experiencePoints = 0;
        private int _level = 0;

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
        public int Dexterity { get => _dexterity; set => _dexterity = value; }
        public int Constitution { get => _constitution; set => _constitution = value; }
        public int Intelligence { get => _intelligence; set => _intelligence = value; }
        public int Wisdom { get => _wisdom; set => _wisdom = value; }
        public int Charisma { get => _charisma; set => _charisma = value; }
        public int ExperiencePoints
        {
            get => _experiencePoints;
            set
            {
                _experiencePoints = value;
                _level = (_experiencePoints / 1000) + 1;
            }
        }
        public int Level { get => _level; }
    }
}