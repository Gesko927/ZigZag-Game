using System;

namespace ZigZag.GameEngine.GameObjects
{
    public class Diamond : BaseGameObject, IBonus
    {
        #region Private Constant Fields

        private const int CommonScoreValue = 2;
        private const int AverageScoreValue = 5;
        private const int GreatScoreValue = 10;

        #endregion

        #region IBonus Members

        public int Score
        {
            get
            {
                switch (DiamondType)
                {
                    case GameBonus.Common:
                        return CommonScoreValue;
                    case GameBonus.Average:
                        return AverageScoreValue;
                    case GameBonus.Great:
                        return GreatScoreValue;
                    default:
                        return 0;
                }
            }
        }
        public GameBonus DiamondType { get; set; }

        #endregion

        #region Public Constructors

        public Diamond(GameBonus diamondType) : base(0, 0)
        {
            this.DiamondType = diamondType;
        }

        public Diamond(GameBonus diamondType, int x, int y) : base(x, y)
        {
            this.DiamondType = diamondType;
        }

        public Diamond(GameBonus diamondType, Point point) : base(point)
        {
            this.DiamondType = diamondType;
        }

        #endregion

    }
}
