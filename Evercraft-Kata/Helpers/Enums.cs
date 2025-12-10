using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evercraft_Kata.Helpers
{
    public class Enums
    {
        public enum AlignmentType
        {
            Evil = -1,
            Neutral = 0, 
            Good = 1
        }

        public enum ClassType
        {
            None = 0,
            Fighter = 1,
            Rogue = 2,
            Monk = 3,
            Paladin = 4
        }
    }
}
