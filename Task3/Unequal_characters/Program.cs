using System;

namespace UnequalCharacters
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(UnequalCharactersSequence.GetMaxNumberofUnequalCharacters(new string[] { "abcdefa" }));
                Console.WriteLine(LatinCharacters.GetMaxNumberofSameLatinCharacters(new string[] { "aaaaaaaAbbBbbbbb" }));
                Console.WriteLine(Numbers.GetMaxNumberofSameNumbers(new string[] { "aaaaaaaaa122333" }));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}