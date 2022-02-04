using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnequalCharacters;

namespace Tests
{
    [TestClass]
    public class UnequalCharactersTests
    {
        [TestMethod]
        public void EmptyInputTest()
        {
            string sequence = string.Empty;

            int actual = UnequalCharactersSequence.GetMaxNumberofUnequalCharacters(new string[] { sequence });

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow("abcdefa", 6)]
        [DataRow("aaabcde", 5)]
        [DataRow("aaaabcdefaaa", 6)]
        [DataRow("aaaaaaaaaaaaa", 1)]
        public void GetTheLongestUniqueSubsequenceLength_VariousInput_CorrestResult(string sequence, int expected)
        {
            string[] testSequence = new string[] { sequence };

            var actual = UnequalCharactersSequence.GetMaxNumberofUnequalCharacters(new string[] { sequence });

            Assert.AreEqual(expected, actual);
        }
    }
}
