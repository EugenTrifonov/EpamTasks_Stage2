using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnequalCharacters;

namespace Tests
{
    [TestClass]
    public class LatinTests
    {
        [TestMethod]
        public void EmptyInputTest()
        {
            string[] sequence = new string[] { };

            int actual = LatinCharacters.GetMaxNumberofSameLatinCharacters(sequence);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow("aabcde", 2)]
        [DataRow("abccdef", 2)]
        [DataRow("abcdefgggg", 4)]
        [DataRow("abcdff123456fff", 3)]
        [DataRow("bbbbbb11111111111", 6)]
        [DataRow("впаыпрнелха13213213", 0)]
        public void GetMaxNumberofSameNumbersPositiveTest(string sequence, int expected)
        {
            string[] testSequence = new string[] { sequence };

            int actual = LatinCharacters.GetMaxNumberofSameLatinCharacters(testSequence);

            Assert.AreEqual(expected, actual);
        }
    }
}
