using System;

namespace ZigZag.GameEngine.GameObjects
{
    public enum GameBonus
    {
        Common,
        Average,
        Great
    }
    public interface IBonus
    {
        int Score { get; }
        GameBonus DiamondType { get; set; }
    }
}
