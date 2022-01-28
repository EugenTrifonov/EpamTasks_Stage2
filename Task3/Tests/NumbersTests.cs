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
            string [] sequence = new string[] { };
            int actual = Numbers.GetMaxNumberofSameNumbers(sequence);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow(new string[] { "11112233" }, 4)]
        [DataRow(new string[] { "1122222233" }, 6)]
        [DataRow(new string[] { "112233333333" }, 8)]
        [DataRow(new string[] { "as11fddgdgyuj111qw" }, 3)]
        [DataRow(new string[] { "111dsa[" }, 3)]
        [DataRow(new string[] { "fddgfgdsdfs" }, 0)]
        public void GetMaxNumberofSameNumbersPositiveTest(string [] sequence, int expected)
        {
            int actual = Numbers.GetMaxNumberofSameNumbers(sequence);
            Assert.AreEqual(expected, actual);
        }
    }
}
