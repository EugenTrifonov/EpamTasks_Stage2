using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnequalCharacters;

namespace Tests
{
    [TestClass]
    public class NumbersTests
    {
        [TestMethod]
        public void EmptyInputTest()
        {
            string[] sequence = new string[] { };

            int actual = Numbers.GetMaxNumberofSameNumbers(sequence);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow("11112233", 4)]
        [DataRow("1122222233", 6)]
        [DataRow("112233333333", 8)]
        [DataRow("as11fddgdgyuj111qw", 3)]
        [DataRow("111dsa[", 3)]
        [DataRow("fddgfgdsdfs", 0)]
        public void GetMaxNumberofSameNumbersPositiveTest(string sequence, int expected)
        {
            string[] testSequence = new string[] { sequence };

            int actual = Numbers.GetMaxNumberofSameNumbers(testSequence);

            Assert.AreEqual(expected, actual);
        }
    }
}
