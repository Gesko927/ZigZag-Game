using System;
using System.Configuration;
using ZigZag.GameEngine;

namespace ZigZag.ConsoleUI
{
    public static class Settings
    {
        #region Public Properties

        public static readonly int MapWidth;
        public static readonly int MapHeight;
        public static readonly int RoadWidth;
        public static readonly int RoadHeight;
        public static readonly Point StartPoint;

        #endregion

        #region Static Constructor

        static Settings()
        {
            StartPoint = new Point();
            var config = ConfigurationManager.AppSettings;
            MapWidth = int.Parse(config.Get("MapWidth"));
            MapHeight = int.Parse(config.Get("MapHeight"));
            RoadWidth = int.Parse(config.Get("RoadWidth"));
            RoadHeight = int.Parse(config.Get("RoadHeight"));
            StartPoint.X = int.Parse(config.Get("StartPointX"));
            StartPoint.Y = int.Parse(config.Get("StartPointY"));
        }

        #endregion
    }
}
