using System.Collections.Generic;

namespace UnequalCharacters
{
    public class LatinCharacters
    {
        /// <summary>
        /// Get max number of same latin characters
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int GetMaxNumberofSameLatinCharacters(string[] args)
        {
            if (args.Length == 0)
            {
                return 0;
            }

            List<int> lengths = new List<int>() { 0 };

            if (Utilities.CheckInput(args))
            {
                char checkCharacter = args[0][0];
                int currentIndex = 0;

                foreach (char character in args[0])
                {
                    if (CheckLatin(character) && character == checkCharacter)
                    {
                        lengths[currentIndex] = lengths[currentIndex] + 1;
                    }
                    else if (CheckLatin(character))
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

            return Utilities.GetMaxNumberInList(lengths);
        }

        /// <summary>
        /// Check for latin character by ASCII code  
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private static bool CheckLatin(char character)
        {
            return character >= 65 && character <= 90 || character >= 97 && character <= 122;
        }
    }
}
