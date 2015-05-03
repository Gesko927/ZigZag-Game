using System;
using System.Linq;
using System.Threading;
using System.Timers;
using ZigZag.GameEngine;
using ZigZag.GameEngine.GameObjects;

namespace ZigZag.ConsoleUI
{
    class ConsoleGame
    {
        #region Private Fields

        private readonly Game _game;
        private readonly Thread _backgroundThread;
        private int _mapPosition = 0;
        private int _diamondPosition = 0;
        private int _ballDiamondPosition = 0;
        private int _ballMapPosition = 0;
        /*
         * Review GY: _startDelay ніде не використовується.
         */
        private readonly int _startDelay;
        private int _delay;
        private readonly System.Timers.Timer _moveBallTimer;
        private readonly object _sync = new object();
        private readonly GameStatistic _top = new GameStatistic();
        private string _name = "Player";

        #endregion

        #region Public Constructors

        public ConsoleGame()
        {
            Console.CursorVisible = false;
            _startDelay = _delay;
            _delay = 700;
            _game = new Game(Settings.MapWidth, Settings.MapHeight, Settings.RoadWidth, Settings.RoadHeight, Settings.StartPoint);
            _backgroundThread = new Thread(StartBackgroundThreadListener);
            OnButtonClickEvent += OnButtonClick;
            _moveBallTimer = new System.Timers.Timer();
            _moveBallTimer.Elapsed += MoveBallTimerOnElapsed;
            _moveBallTimer.Interval = _delay;
            _backgroundThread.Start();
        }

        #endregion

        #region Public Methods
        public void StartGame()
        {
            this._game.GameStartedEvent += OnStart;
            this._game.Start();
        }

        public void PauseGame()
        {
            _game.GamePausedEvent += OnPause;
            this._game.Pause();
        }

        public void ResumeGame()
        {
            _game.GameResumedEvent += OnResume;
            this._game.Resume();
        }

        public void StopGame()
        {
            _game.GameStoppedEvent += OnStop;
            this._game.Stop();
        }

        #endregion

        #region Private Methods

        private void MoveBallTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            lock(_sync)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                bool isGameOver = false;
                char fill;
                var mapHolder = _game.GameMap.Map.ElementAt(_ballMapPosition);
                var gameObject = _game.GameMap.GameObjects.ElementAtOrDefault(_ballDiamondPosition);

                /*
                 * Review GY: подібні виклики не є прийнятними - _game.GameMap.Ball.CPoint.Equals(gameObject.CPoint)
                 * В даному випадку присутнє порушення принципу інкапсуляції.
                 * Класи Ball та GameMap повинні містити відповідні методи для порівняння.
                 */
                // Diamond position.
                if (gameObject != null && _game.GameMap.Ball.CPoint.Equals(gameObject.CPoint))
                {
                    var bonus = gameObject as IBonus;
                    if (bonus != null)
                    {
                        _ballDiamondPosition++;
                        this._game.TotalScore += bonus.Score;
                    }
                }
                _ballMapPosition++;

                // Game Over.
                if (mapHolder.Rotation != _game.Ball.Rotation)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    isGameOver = true;
                    if (_game.Ball.Rotation == Rotation.Left)
                    {
                        /*
                         * Review GY: логіку переміщення об'єкту Ball варто розмістити в класі Game.
                         */
                        _game.Ball.MoveAt(_game.Ball.CPoint.X - 1, _game.Ball.CPoint.Y + 1);
                    }
                    else
                    {
                        _game.Ball.MoveAt(_game.Ball.CPoint.X + 1, _game.Ball.CPoint.Y + 1);
                    }
                }
                else
                {
                    mapHolder = _game.GameMap.Map.ElementAt(_ballMapPosition);
                    _game.Ball.MoveAt(mapHolder.Point.X, mapHolder.Point.Y);
                }
                Console.CursorLeft = _game.Ball.CPoint.X;
                Console.CursorTop = _game.Ball.CPoint.Y;
                Console.Write(0);
                if (_game.Ball.CPoint.Y > Console.WindowHeight/2)
                {
                    RedrawMap();
                }

                // Change level.
                if (_ballMapPosition%10 == 0)
                {
                    ChangeLevel();
                }

                if (isGameOver)
                {
                    _game.GameStoppedEvent += OnStop;
                    _game.Stop();
                }
            }
        }
        private void ChangeLevel()
        {
            _delay -= 50;

            lock (_sync)
            {
                _moveBallTimer.Stop();
                _moveBallTimer.Interval = _delay;
                _moveBallTimer.Start();
                Console.Beep();
            }
        }
        private void StartBackgroundThreadListener(object o)
        {
            while (true)
            {
                if (OnButtonClickEvent == null)
                    throw new NullReferenceException();

                OnButtonClickEvent.Invoke(Console.ReadKey(true));
            }
        }
        private void OnButtonClick(ConsoleKeyInfo consoleKeyInfo)
        {
            lock (_sync)
            {
                if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
                {
                    if (_game.Status == GameStatus.InProgress)
                    {
                        Console.Beep();
                        _game.Ball.Rotation = _game.Ball.Rotation == Rotation.Left ? Rotation.Right : Rotation.Left;
                        _game.TotalScore++;
                    }
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Tab)
                {
                    if (_game.Status == GameStatus.ReadyToStart)
                    {
                        Console.Clear();
                        Console.Write("Enter player's name:  ");
                        _name = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Press Enter To Start.");
                    }
                    else if (_game.Status == GameStatus.Completed)
                    {
                        Console.Clear();
                        Console.WriteLine("№\tName\tScore");
                        for (var i = 0; i < _top.Top.Count; ++i)
                        {
                            Console.WriteLine("{0}.\t{1}\t{2}", i + 1, _top.Top[i].Name, _top.Top[i].Score);
                        }
                        Console.WriteLine("Press Esc To Quit");
                    }
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    if (_game.Status == GameStatus.Completed)
                    {
                        /*
                         * Review GY: не рекомендую закінчувати роботу потоку через виклик методу Abort().
                         * Це може призвести до неочікуваних наслідків.
                         */
                        _backgroundThread.Abort();
                    }
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    if (_game.Status == GameStatus.ReadyToStart)
                    {
                        Console.Clear();
                        this.StartGame();
                    }
                    else if (_game.Status == GameStatus.InProgress)
                    {
                        this.PauseGame();
                    }
                    else if (_game.Status == GameStatus.Paused)
                    {
                        this.ResumeGame();
                        Console.Beep();
                    }
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Q)
                {
                    this.StopGame();
                }
            }
        }
        private void DrawMap()
        {
            if (_game.Status != GameStatus.InProgress)
                throw new InvalidOperationException();

            lock (_sync)
            {
                for (; _mapPosition < (Console.WindowHeight - Console.WindowTop);)
                {
                    RedrawMap();
                }
            }
        }
        private void RedrawMap()
        {
            if (_game.Status != GameStatus.InProgress)
                throw new InvalidOperationException();

            lock (_sync)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                /*
                 * Review GY: уникайте в подальшому таких викликів - _game.GameMap.Map.ElementAt(_mapPosition).Point.X
                 * Рефакторінг класу GameMap допоможе їх позбутися.
                 */
                Console.CursorLeft = _game.GameMap.Map.ElementAt(_mapPosition).Point.X;
                Console.CursorTop = _game.GameMap.Map.ElementAt(_mapPosition).Point.Y;

                char fill = '#';
                if (_game.GameMap.GameObjects.ElementAtOrDefault(_diamondPosition) != null)
                {
                    Point diamondPoint = _game.GameMap.GameObjects.ElementAt(_diamondPosition).CPoint;
                    Point mapPoint = _game.GameMap.Map.ElementAt(_mapPosition).Point;
                    if (diamondPoint.Equals(mapPoint))
                    {
                        if (_game.GameMap.GameObjects.ElementAt(_diamondPosition) is Diamond)
                        {
                            var diamond = (Diamond)_game.GameMap.GameObjects.ElementAt(_diamondPosition);
                            if (diamond.DiamondType == GameBonus.Common)
                            {
                                fill = 'C';
                            }
                            else if (diamond.DiamondType == GameBonus.Average)
                            {
                                fill = 'A';
                            }
                            else
                            {
                                fill = 'G';
                            }
                        }
                        _diamondPosition++;
                    }
                }
                Console.Write(fill);
                _mapPosition++;
            }
        }
        private void OnStart()
        {
            DrawMap();
            _moveBallTimer.Start();
        }
        private void OnStop()
        {
            Console.CursorLeft = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Game over. Your score: {0}", _game.TotalScore);
            Console.Beep();
            _moveBallTimer.Stop();
            _moveBallTimer.Dispose();
            _top.AddStatistic(_name, _game.TotalScore);   
            Console.WriteLine("Press Tab To View Score Table");
            Console.WriteLine("Press Enter To Quit");
        }
        private void OnPause()
        {
            _moveBallTimer.Stop();
        }
        private void OnResume()
        {
            _moveBallTimer.Start();
        }

        #endregion

        #region Public Events

        private event Action<ConsoleKeyInfo> OnButtonClickEvent;

        #endregion
    }
}
