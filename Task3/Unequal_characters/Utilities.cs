using System;
using System.Collections.Generic;

namespace UnequalCharacters
{
    public static class Utilities
    {
        /// <summary>
        /// Get max integer in List
        /// </summary>
        /// <param Input list="list"></param>
        /// <returns></returns>
        public static int GetMaxNumberInList(List<int> list)
        {
            int max = list[0];

            foreach (int number in list)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            return max;
        }

        /// <summary>
        /// Check input arguments
        /// </summary>
        /// <param Input arguments="args"></param>
        /// <returns></returns>
        public static bool CheckInput(string[] args)
        {
            if (args.Length == 0)
            {
                throw new Exception("Empty input");
            }
            if (args.Length > 1)
            {
                throw new Exception("Too much arguments");
            }

            return true;
        }
    }
}
