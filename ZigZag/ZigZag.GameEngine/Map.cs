using System;
using System.Collections.Generic;
using System.Linq;
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
                    throw new ArgumentException("Coordinate can't be < 0");

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
                    throw new ArgumentException();
                if (point.X < 0 || point.Y < 0)
                    throw new ArgumentException("Coordinate can't be < 0");

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
        public IEnumerable<IGameObject> GameObjects
        {
            get { return this._gameObjects; }
        }
        public IEnumerable<MapHolder> Map
        {
            get { return this._map; }
        }
        public Ball Ball { get; private set; }

        #endregion

        #region Public Methods

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
                bool flag = ((x >= 0) && (x < this.Width) && (y >= 0) /*&& (y < this.Height)*/);
                
                return flag;
            }
            else
            {
                return false;
            }
        }

        private void GenerateMap(Point startPoint)
        {
            Random rnd = new Random();
            _map.Add(new MapHolder(Rotation.Left, startPoint));
            _map.Add(new MapHolder(Rotation.Left, GetNextPoint()));
            var i = _map.Count;
            while (i++ < _capacity)
            {
                // Generate Rotation.
                #region Generate Rotation

                if (Math.Abs(_leftRotateCount - _rightRotateCount) <= 5)
                {
                    if (rnd.Next(2) == 0)
                    {
                        _map.Add(new MapHolder(Rotation.Left, GetNextPoint()));
                        _leftRotateCount++;
                    }
                    else
                    {
                        _map.Add(new MapHolder(Rotation.Right, GetNextPoint()));
                        _rightRotateCount++;
                    }
                }
                else
                {
                    if (_leftRotateCount < _rightRotateCount)
                    {
                        if (rnd.Next(3) == 0)
                        {
                            _map.Add(new MapHolder(Rotation.Right, GetNextPoint()));
                            _rightRotateCount++;
                        }
                        else
                        {
                            _map.Add(new MapHolder(Rotation.Left, GetNextPoint()));
                            _leftRotateCount++;
                        }
                    }
                    else
                    {
                        if (rnd.Next(3) == 0)
                        {
                            _map.Add(new MapHolder(Rotation.Left, GetNextPoint()));
                            _leftRotateCount++;
                        }
                        else
                        {
                            _map.Add(new MapHolder(Rotation.Right, GetNextPoint()));
                            _rightRotateCount++;
                        }
                    }
                }

                #endregion

                // Generate diamond.
                if (rnd.Next(15) <= 5)
                {
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
            }
        }

        private Point GetNextPoint()
        {
            Point point = new Point(_map.Last().Point.X, _map.Last().Point.Y);
            if (_map.Last().Rotation == Rotation.Left)
            {
                point.X -= RoadWidth;
                point.Y += RoadHeight;
            }
            else
            {
                point.X += RoadWidth;
                point.Y += RoadHeight;
            }
            return point;
        }

        #endregion

    }
}
