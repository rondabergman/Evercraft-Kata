using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evercraft_Kata.Characters
{
    public static class Attributes
    {
        private static readonly int[] modifier = new int[20];

        static Attributes()
        {
            InitializeModifiers();
        }

        public static int GetModifier(int score)
        {
            return modifier[score - 1];
        }

        private static void InitializeModifiers()
        {
            int adder = -5;

            for (int i = 1; i <= modifier.Length; i++)
            {
                if (i % 2 == 0)
                {
                    adder++;
                }
                modifier[i - 1] = adder;
            }
        }
    }
}
