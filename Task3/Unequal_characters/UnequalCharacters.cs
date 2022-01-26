using System;
using System.Collections.Generic;

namespace UnequalCharacters
{
    public class UnequalCharactersSequence
    {
        private static string CharacterSequence;

        /// <summary>
        /// Get max length of unequal character sequence
        /// </summary>
        /// <param Input arguments="args"></param>
        /// <returns></returns>
        public static int GetMaxNumberofUnequalCharacters(string[] args)
        {
            int NumberofUnequalCharacters = 0;

            if (Utilities.CheckInput(args))
            {
                CharacterSequence = args[0];
                int CurrentIndex = 0;
                string CheckedCharacters = String.Empty;
                List<int> Lengths = new List<int>();

                foreach (char character in CharacterSequence)
                {
                    if (CheckedCharacters.Contains(character.ToString()))
                    {
                        Lengths.Add(NumberofUnequalCharacters);
                        NumberofUnequalCharacters -= IndexOfSameLeftNearestCharacter(character, CharacterSequence, CurrentIndex);
                    }
                    else
                    {
                        NumberofUnequalCharacters++;
                        CheckedCharacters += character;
                    }
                    CurrentIndex++;
                }

                Lengths.Add(NumberofUnequalCharacters);
                NumberofUnequalCharacters = Utilities.GetMaxNumberInList(Lengths);

            }
            return NumberofUnequalCharacters;
        }

        /// <summary>
        /// Get index of left nearest same character 
        /// </summary>
        /// <param Character thats needs to find="character"></param>
        /// <param Character sequence="sequence"></param>
        /// <param Current index of character="CurrentIndex"></param>
        /// <returns></returns>
        private static int IndexOfSameLeftNearestCharacter(char character, string sequence, int CurrentIndex)
        {
            while (sequence[CurrentIndex - 1] != character)
            {
                CurrentIndex--;
            }

            return CurrentIndex - 1;
        }
    }
}