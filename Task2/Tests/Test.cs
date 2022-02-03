using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
using Task2.Comands;

namespace Tests
{
    [TestClass]
    public class Test
    {
        private static CarPark _park;
        private static Invoker _invoker;

        [TestInitialize]
        public void TestInitialize()
        {
            _park = CarPark.GetPark();
            _invoker = new Invoker();
        }

        [TestMethod]
        public void PositiveAddTest()
        {
            _invoker.SetCommand(CommandFactory.GetCommand(new string[] { "add", "sdf", "asdf", "123", "123" }));
            _invoker.Run();

            Assert.AreEqual(123, _park.CountAll());
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        [DataRow(new string[] { "add", "sdf", "dgd", "123" })]
        [DataRow(new string[] { "add", "sdf", "123", "dfg" })]
        [DataRow(new string[] { "add", "sdf", "dfg", "dfg" })]
        [DataRow(new string[] { "add", "sdf" })]
        public void NegativeAddTest(string[] args)
        {
            _invoker.SetCommand(CommandFactory.GetCommand(args));
            _invoker.Run();

            Assert.AreEqual(1, _park.CountAll());
        }

        [TestMethod]
        public void CountAllTest()
        {
            _invoker.SetCommand(CommandFactory.GetCommand(new string[] { "add", "sdf","asdf", "123", "123" }));
            _invoker.Run();

            Assert.AreEqual(246, _park.CountAll());
        }

        [TestMethod]
        public void ExitTest()
        {
            _invoker.SetCommand(CommandFactory.GetCommand(new string[] { "exit" }));
            _invoker.Run();

            Assert.AreEqual(false, Program.status);
        }

        [TestMethod]
        [DataRow(new string[] { "adsdfd"})]
        [DataRow(new string[] { "add"})]
        [DataRow(new string[] { "count" })]
        [DataRow(new string[] { "average" })]
        [DataRow(new string[] { "average","price","type" })]
        [ExpectedException(typeof(System.Exception))]
        public void IncorrectCommandTest(string [] args)
        {
            _invoker.SetCommand(CommandFactory.GetCommand(args));
            _invoker.Run();

            Assert.AreEqual(false, Program.status);
        }
    }
}
