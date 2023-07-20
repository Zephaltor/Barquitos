using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //Player player;

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
            Player player = new Player("cannon", new Vector2(0, 0), 0);

            int expectedLife = player.HitPoints - 1;

            player.GetDamageTest();

            //int expectedLife = player.HitPoints - 1;
            int life = player.HitPoints;

            Assert.AreEqual(life, expectedLife);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Collitions collitions = new Collitions();

            Vector2 pos1 = new Vector2(0, 10);
            Vector2 pos2 = new Vector2(10, 10);
            Vector2 size1 = new Vector2(10, 10);
            Vector2 size2 = new Vector2(15, 10);

            bool isColliding = collitions.BoxToBoxCollition(pos1, pos2, size1, size2);

            Assert.IsTrue(isColliding);
            //Assert.IsFalse(isColliding);
        }
    }
}
