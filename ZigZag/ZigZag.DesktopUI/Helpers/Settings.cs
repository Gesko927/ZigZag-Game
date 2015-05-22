using System.Configuration;
using ZigZag.GameEngine;

namespace ZigZag.DesktopUI.Helpers
{
    /*
     * VV: добре. що налаштування зібрані в одному файлі, але цей клас не варто робити статичним
     */
    public static class Settings
    {
        #region Public Fields

        /*
         * VV: поля не повинні бути публічничи
         */
        public static readonly int MapWidth;
        public static readonly int MapHeight;
        public static readonly int RoadWidth;
        public static readonly int RoadHeight;
        public static readonly Point StartPoint;
        public static int MapUpdateDelay;
        public static readonly int BallWidth;
        public static readonly int BallHeight;

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
            MapUpdateDelay = int.Parse(config.Get("MapUpdateDelay"));
            BallWidth = int.Parse(config.Get("BallWidth"));
            BallHeight = int.Parse(config.Get("BallHeight"));
            Settings.BallHeight = int.Parse(config.Get("Settings.BallHeight"));
        }

        #endregion
    }
}
