using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZigZag.GameEngine.Statistic;

namespace ZigZag.GameEngine.Test.Statistic
{
    [TestClass]
    public class GameStatisticTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var statistic = new GameStatistic();
            Assert.IsNotNull(statistic.Top);
        }

        [TestMethod]
        public void TestAddStatistic()
        {
            var statistic = new GameStatistic();
            statistic.Top.Clear();
            statistic.AddStatistic("Test", 5);
            Assert.AreEqual(statistic.Top.Count, 1);
            statistic.AddStatistic("Test1", 10);
            Assert.AreEqual(statistic.Top.Count, 2);
        }

        [TestMethod]
        public void TestTop()
        {
            var statistic = new GameStatistic();
            statistic.Top.Clear();
            statistic.Top.Add(new GameStatistic.StatisticItemHolder("1", 1));
            Assert.AreEqual(statistic.Top.Count, 1);
            statistic.Top.Add(new GameStatistic.StatisticItemHolder("2", 2));
            Assert.AreEqual(statistic.Top.Count, 2);
            statistic.Top.Clear();
            Assert.AreEqual(statistic.Top.Count, 0);
        }

        [TestMethod]
        public void TestStatisticItemHolder()
        {
            var itemHolder = new GameStatistic.StatisticItemHolder();
            Assert.AreEqual(itemHolder.Name, String.Empty);
            Assert.AreEqual(itemHolder.Score, 0);
        }
    }
}



