using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int life = -1;
            
            Program.Defeat(life);

            bool _defeat = Program.defeat;

            Assert.IsTrue(_defeat);
        }

        [TestMethod]
        public void TestMethod2()
        {

        }

        [TestMethod]
        public void TestMethod3()
        {

        }

        [TestMethod]
        public void TestMethod4()
        {

        }
    }
}
