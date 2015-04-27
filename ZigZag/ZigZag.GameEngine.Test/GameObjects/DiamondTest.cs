using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZigZag.GameEngine.GameObjects;

namespace ZigZag.GameEngine.Test.GameObjects
{
    [TestClass]
    public class DiamondTest
    {
        [TestMethod]
        public void TestConstructors()
        {
            Diamond diamond = new Diamond(GameBonus.Common);

            Assert.AreEqual(diamond.DiamondType, GameBonus.Common);
            Assert.AreEqual(diamond.Score, 2);
            Assert.AreEqual(diamond.CPoint, new Point(0, 0));
            Assert.IsNull(diamond.Map);

            diamond = new Diamond(GameBonus.Great, 3, 4);
            Assert.AreEqual(diamond.DiamondType, GameBonus.Great);
            Assert.AreEqual(diamond.Score, 10);
            Assert.AreEqual(diamond.CPoint, new Point(3, 4));
            Assert.IsNull(diamond.Map);
        }

        [TestMethod]
        public void TestScore()
        {
            Diamond diamond = new Diamond(GameBonus.Common);
            Assert.AreEqual(diamond.Score, 2);
            diamond = new Diamond(GameBonus.Average);
            Assert.AreEqual(diamond.Score, 5);
            diamond = new Diamond(GameBonus.Great);
            Assert.AreEqual(diamond.Score, 10);
        }
    }
}
