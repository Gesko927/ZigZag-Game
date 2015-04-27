using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZigZag.GameEngine.Test
{
    [TestClass]
    public class GameTest
    {
        #region Test Constructors

        [TestMethod]
        public void TestConstructors()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            Assert.AreEqual(game.Status, GameStatus.ReadyToStart);
            Assert.AreEqual(game.GameMap.Width, 80);
            Assert.AreEqual(game.GameMap.Height, 40);
            Assert.AreEqual(game.GameMap.RoadWidth, 1);
            Assert.AreEqual(game.GameMap.RoadHeight, 1);
            Assert.AreEqual(game.Ball.CPoint, new Point(40, 0));
        }

        #endregion

        #region TestUsualLifecycle

        [TestMethod]
        public void TestUsualLifecycle()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.GamePausedEvent += () => { };
            game.GameResumedEvent += () => { };
            game.GameStoppedEvent += () => { };
            Assert.AreEqual(GameStatus.ReadyToStart, game.Status);
            game.Start();
            Assert.AreEqual(GameStatus.InProgress, game.Status);
            game.Pause();
            Assert.AreEqual(GameStatus.Paused, game.Status);
            game.Resume();
            Assert.AreEqual(GameStatus.InProgress, game.Status);
            game.Stop();
            Assert.AreEqual(GameStatus.Completed, game.Status);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void TestStart_WrongStatus_1()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.Start();
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStart_WrongStatus_2()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.GameStoppedEvent += () => { };
            game.Start();
            game.Stop();
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPause_WrongStatus_1()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GamePausedEvent += () => { };
            game.Pause();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPause_WrongStatus_2()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.GamePausedEvent += () => { };          
            game.Start();
            game.Pause();
            game.Pause();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestResume_WrongStatus_1()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GameResumedEvent += () => { };
            game.Resume();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestResume_WrongStatus_2()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.GameResumedEvent += () => { };
            game.Start();
            game.Resume();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStop_WrongStatus_1()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GameStoppedEvent += () => { };
            game.Stop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStop_WrongStatus_2()
        {
            Game game = new Game(80, 40, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.GameStoppedEvent += () => { };
            game.Start();
            game.Stop();
            game.Stop();
        }

        #endregion

        #region GameMap

        [TestMethod]
        public void TestBoardCreation()
        {
            Game game = new Game(80, 20, 1, 1, new Point(40, 0));
            Assert.IsNotNull(game.GameMap);
        }

        [TestMethod]
        public void TestBoardSize()
        {
            Game game = new Game(80, 20, 1, 1, new Point(40, 0));
            Assert.AreEqual(80, game.GameMap.Width);
            Assert.AreEqual(20, game.GameMap.Height);
            Assert.AreEqual(1, game.GameMap.RoadHeight);
            Assert.AreEqual(1, game.GameMap.RoadWidth);
        }

        #endregion

        #region Ball

        [TestMethod]
        public void TestPlayerCreation()
        {
            Game game = new Game(80, 20, 1, 1, new Point(40, 0));
            Assert.IsNotNull(game.Ball);
            Assert.AreSame(game.GameMap, game.Ball.Map);
        }

        #endregion

        #region Test Events

        [TestMethod]
        public void TestEventsRaised()
        {
            string started = "Started", paused = "Paused", resumed = "Resumed", stopped = "Stopped";
            
            List<string> receivedEvents = new List<string>();
            Game game = new Game(80, 20, 1, 1, new Point(40, 0));

            game.GameStartedEvent += () =>
            {
                receivedEvents.Add(started);
            };
            game.GamePausedEvent += () =>
            {
                receivedEvents.Add(paused);
            };
            game.GameResumedEvent += () =>
            {
                receivedEvents.Add(resumed);
            };
            game.GameStoppedEvent += () =>
            {
                receivedEvents.Add(stopped);
            };
            game.Start();
            game.Pause();;
            game.Resume();
            game.Stop();

            Assert.AreEqual(4, receivedEvents.Count);
            Assert.AreEqual(started, receivedEvents[0]);
            Assert.AreEqual(paused, receivedEvents[1]);
            Assert.AreEqual(resumed, receivedEvents[2]);
            Assert.AreEqual(stopped, receivedEvents[3]);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestUninitializedStartEvent()
        {
            Game game = new Game(80, 20, 1, 1, new Point(40, 0));
            game.Start();
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestUninitializedPauseEvent()
        {
            Game game = new Game(80, 20, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.Start();
            game.Pause();
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestUninitializedResumeEvent()
        {
            Game game = new Game(80, 20, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.GamePausedEvent += () => { };
            game.Start();
            game.Pause();
            game.Resume();
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestUninitializedStopEvent()
        {
            Game game = new Game(80, 20, 1, 1, new Point(40, 0));
            game.GameStartedEvent += () => { };
            game.GamePausedEvent += () => { };
            game.GameResumedEvent += () => { };
            game.Start();
            game.Pause();
            game.Resume();
            game.Stop();
        }


        #endregion
    }
}
