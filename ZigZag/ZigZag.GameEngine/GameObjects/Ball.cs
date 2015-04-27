using System;

namespace ZigZag.GameEngine.GameObjects
{
    public class Ball : BaseGameObject, IMovable
    {
        #region Public Properties

        public Rotation Rotation { get; set; }

        #endregion

        #region Public Constructors

        public Ball(int x, int y)
            : base(x, y)
        {
            Rotation = Rotation.Left;
        }

        public Ball(Point point)
            : base(point)
        {
            Rotation = Rotation.Left;
        }


        #endregion

        #region IMovable Members

        public void MoveAt(int x, int y)
        {
            if (!this.CanBeMoveAt(x, y))
            {
                throw new ArgumentException("Ball can't be moved at this position.");
            }
            else
            {
                this.CPoint.X = x;
                this.CPoint.Y = y;
            }
        }

        #endregion

        #region Public Methods

        public bool CanBeMoveAt(int x, int y)
        {
            if (this.Map != null)
                return Map.CanBePlaced(this, x, y);
            else
                return false;
        }

        #endregion
    }
}
