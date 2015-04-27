using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZigZag.GameEngine.Test
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void TestConstructors()
        {
            Point point = new Point();
            Assert.AreEqual(point.X, 0);
            Assert.AreEqual(point.Y, 0);

            point = new Point(1, 2);
            Assert.AreEqual(point.X, 1);
            Assert.AreEqual(point.Y, 2);

            point = new Point(new Point(3, 4));
            Assert.AreEqual(point.X, 3);
            Assert.AreEqual(point.Y, 4);
        }

        [TestMethod]
        public void TestEquals()
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(1, 2);
            Assert.IsTrue(p1.Equals(p2));

            p2 = new Point(3, 4);
            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(2, 3);
            Assert.AreNotEqual(p1.GetHashCode(), p2.GetHashCode());
        }

        [TestMethod]
        public void TestClone()
        {
            Point p1 = new Point(1, 2);
            Point p2 = p1.Clone() as Point;
            Assert.IsTrue(Equals(p1, p2));
        }
    }
}
