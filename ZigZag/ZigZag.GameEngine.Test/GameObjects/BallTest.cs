using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZigZag.GameEngine;
using ZigZag.GameEngine.GameObjects;

namespace ZigZag.GameEngine.Test.GameObjects
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void TestConstructors()
        {
            Ball ball = new Ball(1, 2);
            Assert.AreEqual(1, ball.CPoint.X);
            Assert.AreEqual(2, ball.CPoint.Y);
            Assert.IsNull(ball.Map);

            ball = new Ball(new Point(3, 4));
            Assert.AreEqual(3, ball.CPoint.X);
            Assert.AreEqual(4, ball.CPoint.Y);
            Assert.IsNull(ball.Map);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestConstructorException()
        {
            Ball ball = new Ball(-1, -2);
        }

        [TestMethod]
        public void TestCanBeMovedOn_Without_Map()
        {
            Ball ball = new Ball(1, 2);
            Assert.IsFalse(ball.CanBeMoveAt(2, 2));
        }

        [TestMethod]
        public void TestCanBeMovedOn_With_Board()
        {
            Ball ball = new Ball(1, 2);
            GameMap map = new GameMap(80, 20, 1, 1, new Point(40, 0), ball);

            Assert.IsFalse(ball.CanBeMoveAt(-1, -1));
            Assert.IsTrue(ball.CanBeMoveAt(1, 3));
            Assert.IsTrue(ball.CanBeMoveAt(8, 4));
            Assert.IsFalse(ball.CanBeMoveAt(-1, -2));

            Assert.IsFalse(ball.CanBeMoveAt(9, -1));
            Assert.IsFalse(ball.CanBeMoveAt(-2, -1));
            Assert.IsTrue(ball.CanBeMoveAt(0, 5));
            Assert.IsFalse(ball.CanBeMoveAt(0, -3));
        }

        [ExpectedException((typeof(ArgumentException)))]
        [TestMethod]
        public void TestMoveOn_Without_Board()
        {
            Ball ball = new Ball(2, 2);
            ball.MoveAt(1, 1);
            Assert.AreEqual(2, ball.CPoint.X);
            Assert.AreEqual(2, ball.CPoint.Y);
        }        

        [TestMethod]
        public void TestMoveOn_With_Board()
        {
            Ball ball = new Ball(1, 2);
            GameMap board = new GameMap(80, 10, 1, 1, new Point(40, 0), ball);
            ball.MoveAt(4, 4);
            Assert.AreEqual(4, ball.CPoint.X);
            Assert.AreEqual(4, ball.CPoint.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMoveOn_With_Board_WrongX()
        {
            Ball ball = new Ball(1, 2);
            GameMap board = new GameMap(80, 10, 1, 1, new Point(40, 0), ball);
            ball.MoveAt(-9, 2);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMoveOn_With_Board_WrongY()
        {
            Ball ball = new Ball(1, 2);
            GameMap board = new GameMap(80, 20, 1, 1, new Point(40, 0), ball);
            ball.MoveAt(2, -3);
        }
    }
}
