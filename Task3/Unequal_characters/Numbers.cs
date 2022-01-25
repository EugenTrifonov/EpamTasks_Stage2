using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnequalCharacters
{
    public class Numbers
    {
        public static int GetMaxNumberofSameNumbers(string[] args)
        {
            List<int> lengths = new List<int>() { 0 };
            if (Utilities.CheckInput(args))
            {
                char checkCharacter = args[0][0];
                int currentIndex = 0;

                foreach (char character in args[0])
                {
                    if (CheckNumber(character) && character == checkCharacter)
                    {
                        lengths[currentIndex] = lengths[currentIndex] + 1;
                    }
                    else if (CheckNumber(character))
                    {
                        currentIndex++;
                        lengths.Add(1);
                        checkCharacter = character;
                    }
                    else
                    {
                        lengths.Add(0);
                        currentIndex++;
                    }
                }
            }

            return Utilities.GetMaxIntInList(lengths);
        }

        private static bool CheckNumber(char character)
        {
            return character >= 48 && character <= 57;
        }
    }
}
