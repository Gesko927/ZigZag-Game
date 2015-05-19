using System;

namespace ZigZag.GameEngine.GameObjects
{
    public class Diamond : BaseGameObject, IBonus
    {
        #region Private Fields

        #endregion

        #region IBonus Members

        public int Score
        {
            get
            {
                /*
                 * Review GY: наявне використання магічних чисел.
                 * Рекомендую перенести їх в константи або зчитувати з конфігураційного файлу.
                 */
                if (DiamondType == GameBonus.Common)
                {
                    return 2;
                }
                else if (DiamondType == GameBonus.Average)
                {
                    return 5;
                }
                else
                {
                    return 10;
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
