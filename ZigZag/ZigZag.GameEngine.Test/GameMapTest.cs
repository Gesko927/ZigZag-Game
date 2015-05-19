using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZigZag.GameEngine.GameObjects;

namespace ZigZag.GameEngine.Test
{
    [TestClass]
    public class GameMapTest
    {
        #region Test Constructors

        [TestMethod]
        public void TestConstructor()
        {
            GameMap map = new GameMap(80, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
            Assert.AreEqual(80, map.Width);
            Assert.AreEqual(20, map.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWidth_Wrong_0()
        {
            GameMap map = new GameMap(0, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWidth_Wrong_1()
        {
            GameMap map = new GameMap(-5, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHeight_Wrong_0()
        {
            GameMap map = new GameMap(80, 0, 1, 1, new Point(40, 0), new Ball(40, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHeight_Wrong_1()
        {
            GameMap map = new GameMap(80, -5, 1, 1, new Point(40, 0), new Ball(40, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRoadWidth_Wrong_1()
        {
            GameMap map = new GameMap(80, 20, -4, 1, new Point(40, 0), new Ball(40, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRoadHeight_Wrong_1()
        {
            GameMap map = new GameMap(80, 20, 1, -1, new Point(40, 0), new Ball(40, 0));
        }

        #endregion

        #region Test GameMap Methods

        [TestMethod]
        public void TestAddGameObject_Player()
        {
            var map = new GameMap(80, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
            IGameObject ball = new Ball(1, 1);
            map.AddGameObject(ball);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddGameObject_Player_Wrong_Position()
        {
            var map = new GameMap(80, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
            IGameObject ball = new Ball(90, 1);
            map.AddGameObject(ball);
        }

        [TestMethod]
        public void TestCanBePlaced_Player()
        {
            GameMap map = new GameMap(80, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
            IGameObject diamond = new Diamond(GameBonus.Average ,1, 1);
            map.AddGameObject(diamond);

            Assert.IsTrue(map.CanBePlaced(diamond, 0, 0));
            Assert.IsTrue(map.CanBePlaced(diamond, 9, 4));
            Assert.IsTrue(map.CanBePlaced(diamond, 2, 1));

            Assert.IsFalse(map.CanBePlaced(diamond, -1, 0));
            Assert.IsFalse(map.CanBePlaced(diamond, 0, -1));
            Assert.IsFalse(map.CanBePlaced(diamond, 90, 0));
        }

        [TestMethod]
        public void TestCanBePlaced_Player_Does_Not_Belong_To()
        {
            GameMap map = new GameMap(80, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
            IGameObject diamond = new Diamond(GameBonus.Average, 1, 1);
            Assert.IsFalse(map.CanBePlaced(diamond, 0, 5));
        }

        [TestMethod]
        public void TestGetGameObject()
        {
            var map = new GameMap(80, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
            var obj = map.GetGameObject(0);
            Assert.IsNotNull(obj);
            obj = map.GetGameObject(100000);
            Assert.IsNull(obj);
        }

        [TestMethod]
        public void TestGetMapItem()
        {
            var map = new GameMap(80, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
            var item = map.GetMapItem(0);
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Point.Equals(new Point(40, 0)));
            item = map.GetMapItem(100000);
            Assert.IsNull(item);
        }

        [TestMethod]
        public void TestGetMapItemPoint()
        {
            var map = new GameMap(80, 20, 1, 1, new Point(40, 0), new Ball(40, 0));
            var item = map.GetMapItemPoint(0);
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Equals(new Point(40, 0)));
            item = map.GetMapItemPoint(100000);
            Assert.IsNull(item);
        }

        [TestMethod]
        public void TestMapHolderConstructor1()
        {
            var mapHolder = new GameMap.MapHolder(Rotation.Left);
            Assert.AreEqual(mapHolder.Rotation, Rotation.Left);
            Assert.IsTrue(mapHolder.Point.Equals(new Point()));
        }

        [TestMethod]
        public void TestMapHolderConstructor2()
        {
            var mapHolder = new GameMap.MapHolder(Rotation.Left, 1, 1);
            Assert.AreEqual(mapHolder.Rotation, Rotation.Left);
            Assert.IsTrue(mapHolder.Point.Equals(new Point(1, 1)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMapHolderConstructor2Exception()
        {
            var mapHolder = new GameMap.MapHolder(Rotation.Left, -1, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMapHolderConstructor3Exception1()
        {
            var mapHolder = new GameMap.MapHolder(Rotation.Left, new Point(-1, -3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMapHolderConstructor3Exception2()
        {
            var mapHolder = new GameMap.MapHolder(Rotation.Left, null);
        }

        #endregion
    }
}
