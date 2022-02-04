﻿using System.Collections.Generic;

namespace UnequalCharacters
{
    public class Numbers
    {
        
        /// <summary>
        /// Get max number of same numbers
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int GetMaxNumberofSameNumbers(string[] args)
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

            return Utilities.GetMaxNumberInList(lengths);
        }

        /// <summary>
        /// Check for number by ASCII code
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private static bool CheckNumber(char character)
        {
            return character >= 48 && character <= 57;
        }
    }
}
