using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnequalCharacters;

namespace FirstTaskTests
{
    [TestClass]
    public class FirstTaskTests
    {
        [TestMethod]
        [DataRow("abcdefa", 6)]
        [DataRow("111", 1)]
        [DataRow("asdfga", 5)]
        [DataRow("", 0)]
        public void PositiveGetTheLongestUnequalCharacterNumber(string input, int expectedLength)
        {
            Assert.AreEqual(expectedLength, UnequalCharactersSequence.GetMaxNumberofUnequalCharacters(new string[] { input }));
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        [DataRow(new string[] { "dfsdf", "adasdada", "dsfsf" })]
        public void GetTheLongestUnequalCharacterNumberIncorrectInput(string[] input)
        {
            UnequalCharactersSequence.GetMaxNumberofUnequalCharacters(input);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        [DataRow(new string[] { })]
        public void GetTheLongestUnequalCharacterNumberEmptyInput(string[] input)
        {
            UnequalCharactersSequence.GetMaxNumberofUnequalCharacters(input);
        }
    }
}
