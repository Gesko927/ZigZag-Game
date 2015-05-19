using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using ZigZag.GameEngine.GameObjects;

namespace ZigZag.GameEngine
{
    public enum Rotation
    {
        Left,
        Right
    }
    public class GameMap
    {
        #region Nested Classes

        public class MapHolder
        {
            #region Public Properties

            public Point Point { get; set; }
            public Rotation Rotation { get; set; }

            #endregion

            #region Public Constructors

            public MapHolder(Rotation rotation)
            {
                this.Rotation = rotation;
                this.Point = new Point();
            }
            public MapHolder(Rotation rotation, int x, int y)
            {
                #region Validation

                if (x < 0 || y < 0)
                {
                    throw new ArgumentException("Coordinate can't be < 0");
                }

                #endregion

                this.Point = new Point();
                this.Rotation = rotation;
                this.Point.X = x;
                this.Point.Y = y;
            }
            public MapHolder(Rotation rotation, Point point)
            {
                #region Validation

                if (point == null)
                {
                    throw new ArgumentException();
                }
                if (point.X < 0 || point.Y < 0)
                {
                    throw new ArgumentException("Coordinate can't be < 0");
                }

                #endregion

                this.Point = new Point();
                this.Rotation = rotation;
                this.Point.X = point.X;
                this.Point.Y = point.Y;
            }

            #endregion
        }

        #endregion

        #region Private Fields

        private readonly int _capacity;
        private readonly List<IGameObject> _gameObjects = new List<IGameObject>();
        private readonly List<MapHolder> _map;
        private readonly int _maxDifference = 6;
        private int _leftRotateCount = 0;
        private int _rightRotateCount = 0;

        #endregion

        #region Constructors

        public GameMap(int width, int height, int roadWidth, int roadHeight, Point startPoint, Ball ball)
        {
            #region Validation

            if (width <= 0)
            {
                throw new ArgumentException("'width' cannot be <= 0");
            }

            if (height <= 0)
            {
                throw new ArgumentException("'height' cannot be <= 0");
            }

            if (roadWidth <= 0)
            {
                throw new ArgumentException("'road width' cannot be <= 0");
            }

            if (roadHeight <= 0)
            {
                throw new ArgumentException("'road width' cannot be <= 0");
            }

            #endregion

            this.Width = width;
            this.Height = height;
            this.RoadWidth = roadWidth;
            this.RoadHeight = roadHeight;
            this.Ball = ball;
            this.Ball.Map = this;
            this._capacity = 1000;
            this._map = new List<MapHolder>(_capacity);
            this.GenerateMap(startPoint);
        }

        #endregion

        #region Public Properties

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int RoadWidth { get; private set; }
        public int RoadHeight { get; set; }
        public Ball Ball { get; private set; }

        #endregion

        #region Public Methods

        public IGameObject GetGameObject(int index)
        {
            if (index < this._gameObjects.Count)
            {
                return this._gameObjects[index];
            }
            else
            {
                return null;
            }
        }

        public MapHolder GetMapItem(int index)
        {
            if (index < this._map.Count)
            {
                return this._map[index];
            }
            else
            {
                return null;
            }
        }

        public Point GetMapItemPoint(int index)
        {
            if (index < this._map.Count)
            {
                return this._map[index].Point;
            }
            else
            {
                return null;
            }

        }

        public void AddGameObject(IGameObject gameObject)
        {
            if (this.IsCorrectPosition(gameObject, gameObject.CPoint.X, gameObject.CPoint.Y) == false)
            {
                throw new ArgumentException("A game object cannot be added to the board due to incorrect coordinates");
            }
            this._gameObjects.Add(gameObject);
            gameObject.Map = this;
        }

        public bool CanBePlaced(IGameObject gameObject, int x, int y)
        {
            if (gameObject is Ball)
                return IsCorrectPosition(gameObject, x, y);

            if (this._gameObjects.Any(r => r == gameObject) == false)
            {
                return false;
            }

            return IsCorrectPosition(gameObject, x, y);
        }

        #endregion

        #region Private Helpers

        private bool IsCorrectPosition(IGameObject gameObject, int x, int y)
        {
            if (gameObject is Ball || gameObject is Diamond)
            {
                var flag = ((x >= 0) && (x < this.Width) && (y >= 0) /*&& (y < this.Height)*/);

                return flag;
            }
            else
            {
                return false;
            }
        }

        private void GenerateMap(Point startPoint)
        {
            var rnd = new Random();
            _map.Add(new MapHolder(Rotation.Left, startPoint));
            _map.Add(new MapHolder(Rotation.Left, GetNextPoint()));
            _map.Add(new MapHolder(Rotation.Left, GetNextPoint()));
            var i = _map.Count;
            while (i++ < _capacity)
            {
                // Generate Rotation.
                #region Generate Map Rotation

                if (Math.Abs(_leftRotateCount - _rightRotateCount) <= _maxDifference)
                {
                    AddToMap(rnd.Next(2) == 0 ? Rotation.Left : Rotation.Right);
                }
                else
                {
                    var flag = _leftRotateCount < _rightRotateCount;
                    if (rnd.Next(8) == 0)
                    {
                        AddToMap(flag ? Rotation.Right : Rotation.Left);
                    }
                    else
                    {
                        AddToMap(flag ? Rotation.Left : Rotation.Right);
                    }
                }

                #endregion

                DiamondGemerate();
            }
        }

        private void DiamondGemerate()
        {
            var rnd = new Random();
            var diamondGen = rnd.Next(10);
            if (diamondGen == 0)
            {
                this.AddGameObject(new Diamond(GameBonus.Common, _map.Last().Point));
            }
            else if (diamondGen < 5)
            {
                this.AddGameObject(new Diamond(GameBonus.Average, _map.Last().Point));
            }
            else
            {
                this.AddGameObject(new Diamond(GameBonus.Great, _map.Last().Point));
            }
        }

        private void AddToMap(Rotation rotation)
        {
            _map.Add(new MapHolder(rotation, GetNextPoint()));
            _map.Add(new MapHolder(rotation, GetNextPoint()));
            if (rotation == Rotation.Left)
            {
                _leftRotateCount += 2;
            }
            else
            {
                _rightRotateCount += 2;
            }
        }

        private Point GetNextPoint()
        {
            var startPoint = new Point(_map.Last().Point.X, _map.Last().Point.Y);
            var angleRad = (Math.PI / 180) * 45;
            var x = (int)Math.Round(RoadHeight * Math.Cos(angleRad));
            var y = (int)Math.Round(RoadHeight * Math.Sin(angleRad));

            return _map.Last().Rotation == Rotation.Left ?
                new Point(startPoint.X - x, startPoint.Y + y) :
                new Point(startPoint.X + x, startPoint.Y + y);    
//             var point = new Point(_map.Last().Point.X, _map.Last().Point.Y);
//             if (_map.Last().Rotation == Rotation.Left)
//             {
//                 point.X -= RoadWidth;
//                 point.Y += RoadHeight;
//             }
//             else
//             {
//                 point.X += RoadWidth;
//                 point.Y += RoadHeight;
//             }
//             return point;
        }

        #endregion

    }
}
