using System;

namespace ZigZag.GameEngine
{
    public class Point : ICloneable
    {
        #region Public Properties

        public int X { get; set; }
        public int Y { get; set; }


        #endregion

        #region Public Constructors

        public Point()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(Point point)
            : this(point.X, point.Y)
        {

        }

        #endregion

        #region Overrided Methods

        public override bool Equals(object obj)
        {
            var tmp = (Point)obj;
            if (this.X == tmp.X && this.Y == tmp.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.X*111 ^ this.Y*222;
        }

        #endregion

        #region IClonable Implementation
        public object Clone()
        {
            return new Point(this);
        }

        #endregion
    }

}
