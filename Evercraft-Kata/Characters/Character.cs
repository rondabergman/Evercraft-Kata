

using static Evercraft_Kata.Helpers.Enums;

namespace Evercraft_Kata.Characters
{
    public class Character
    {
        private string _name = string.Empty;
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

        private AlignmentType _alignment = AlignmentType.Neutral;
        private ClassType _characterClass = ClassType.None;

        public Character(string name)
        {
            Name = name;
        }

        public string Name { get => _name; set => _name = value; }
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
                _level = (_experiencePoints / 1000);
            }
        }
        public int Level { get => _level; }
        public AlignmentType Alignment { get => _alignment; set => _alignment = value; }
        public ClassType CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                if (value == ClassType.Fighter)
                    _hitPoints += 5; // Fighters get +5 hit points
            }
        }
    }
}