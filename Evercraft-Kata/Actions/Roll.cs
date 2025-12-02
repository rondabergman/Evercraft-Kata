using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evercraft_Kata.Actions
{
    public static class Roll
    {
        public static int RollDie()
        {
            Random random = new Random();
            return random.Next(1, 21);
        }
    }
}
