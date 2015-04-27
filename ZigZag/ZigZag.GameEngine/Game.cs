using System;
using ZigZag.GameEngine.GameObjects;

namespace ZigZag.GameEngine
{
    public enum GameStatus
    {
        ReadyToStart,
        InProgress,
        Paused,
        Completed
    }
    public class Game
    {
        #region Private Fields

        private GameStatus _status;
        private Ball _ball;

        #endregion

        #region Public Constructors

        public Game(int mapWidth, int mapHeight, int roadWidth, int roadHeigth, Point startPoint)
        {
            this._ball = new Ball(startPoint);
            this.GameMap = new GameMap(mapWidth, mapHeight, roadWidth, roadHeigth, startPoint, _ball);
            this.TotalScore = 0;
            this._status = GameStatus.ReadyToStart;
        }

        #endregion

        #region Public Properties

        public int TotalScore { get; set; }

        public GameStatus Status
        {
            get { return this._status; }
        }

        public GameMap GameMap { get; private set; }

        public Ball Ball
        {
            get { return this._ball; }
        }

        #endregion

        #region Public Methods

        public void Start()
        {
            #region Validation

            if (this._status != GameStatus.ReadyToStart)
            {
                throw new InvalidOperationException("Only game with status 'ReadyToStart' can be started");
            }

            #endregion

            if (GameStartedEvent == null)
                throw new NullReferenceException();
            this._status = GameStatus.InProgress;
            GameStartedEvent.Invoke();
        }

        public void Pause()
        {
            #region Validation

            if (this._status != GameStatus.InProgress)
            {
                throw new InvalidOperationException("Only game with status 'InProgress' can be paused");
            }

            #endregion

            if (GamePausedEvent == null)
                throw new NullReferenceException();
            this._status = GameStatus.Paused;
            GamePausedEvent.Invoke();
        }

        public void Resume()
        {
            #region Validation

            if (this._status != GameStatus.Paused)
            {
                throw new InvalidOperationException("Only game with status 'Paused' can be resumed");
            }

            #endregion

            if (GameResumedEvent == null)
                throw new NullReferenceException("");
            this._status = GameStatus.InProgress;
            GameResumedEvent.Invoke();
        }

        public void Stop()
        {
            #region Validation

            if (this._status != GameStatus.InProgress)
            {
                throw new InvalidOperationException("Only game with status 'InProgress' can be stopped");
            }

            #endregion

            if (GameStoppedEvent == null)
                throw new NullReferenceException("");
            this._status = GameStatus.Completed;
            GameStoppedEvent.Invoke();
        }

        #endregion

        #region Events

        public event Action GameStartedEvent;
        public event Action GameStoppedEvent;
        public event Action GamePausedEvent;
        public event Action GameResumedEvent;

        #endregion
    }
}
