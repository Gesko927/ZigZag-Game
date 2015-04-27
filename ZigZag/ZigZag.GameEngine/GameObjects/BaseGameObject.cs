using System;

namespace ZigZag.GameEngine.GameObjects
{
    public class BaseGameObject :IGameObject
    {
        #region Private Fields

        private Point _cPoint = new Point();

        #endregion

        #region Constructors

        public BaseGameObject(int x, int y)
        {
            Map = null;
            if (x < 0 || y < 0)
                throw new ArgumentException("Invalid coordinates.");

            this.CPoint.X = x;
            this.CPoint.Y = y;
        }

        public BaseGameObject(Point point) : this(point.X, point.Y)
        {
            
        }

        #endregion

        #region IGameObject Members

        public GameMap Map { get; set; }
        public Point CPoint
        {
            get { return this._cPoint; }
//            protected set { this._cPoint = value; }
        }

        #endregion
    }
}
