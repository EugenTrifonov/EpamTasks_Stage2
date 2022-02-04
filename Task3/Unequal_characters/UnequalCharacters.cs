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
                List<string> CheckedCharacters = new List<string> { "" };
                List<int> Lengths = new List<int>();

                for (int index = 0; index < CharacterSequence.Length; index++)
                {
                    if (CheckedCharacters[CheckedCharacters.Count - 1].Contains(CharacterSequence[index].ToString()))
                    {
                        Lengths.Add(NumberofUnequalCharacters);
                        CheckedCharacters.Add("");
                        NumberofUnequalCharacters--;
                    }
                    else
                    {
                        NumberofUnequalCharacters++;
                        CheckedCharacters[CheckedCharacters.Count - 1] += CharacterSequence[index];
                    }
                }

                Lengths.Add(NumberofUnequalCharacters);
                NumberofUnequalCharacters = Utilities.GetMaxNumberInList(Lengths);

            }

            return NumberofUnequalCharacters;
        }
    }
}