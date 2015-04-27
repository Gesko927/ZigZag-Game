using System;

namespace ZigZag.GameEngine.GameObjects
{
    public  interface IGameObject
    {
        GameMap Map { get; set; }
        Point CPoint { get; }
    }
}
