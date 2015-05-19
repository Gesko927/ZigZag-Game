﻿using System;
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

        private readonly Ball _ball;

        #endregion

        #region Public Constructors

        public Game(int mapWidth, int mapHeight, int roadWidth, int roadHeigth, Point startPoint)
        {
            this._ball = new Ball(startPoint);
            this.GameMap = new GameMap(mapWidth, mapHeight, roadWidth, roadHeigth, startPoint, _ball);
            this.TotalScore = 0;
            this.Status = GameStatus.ReadyToStart;
        }

        #endregion

        #region Public Properties

        public int TotalScore { get; set; }

        public GameStatus Status { get; private set; }

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

            if (this.Status != GameStatus.ReadyToStart)
            {
                throw new InvalidOperationException("Only game with status 'ReadyToStart' can be started");
            }

            #endregion

            if (GameStartedEvent == null)
            {
                throw new NullReferenceException();
            }
            this.Status = GameStatus.InProgress;
            this.GameStartedEvent(this, EventArgs.Empty);
        }

        public void Pause()
        {
            #region Validation

            if (this.Status != GameStatus.InProgress)
            {
                throw new InvalidOperationException("Only game with status 'InProgress' can be paused");
            }

            #endregion

            if (GamePausedEvent == null)
            {
                throw new NullReferenceException();
            }
            this.Status = GameStatus.Paused;
            this.GamePausedEvent(this, EventArgs.Empty);
        }

        public void Resume()
        {
            #region Validation

            if (this.Status != GameStatus.Paused)
            {
                throw new InvalidOperationException("Only game with status 'Paused' can be resumed");
            }

            #endregion

            if (GameResumedEvent == null)
            {
                throw new NullReferenceException();
            }
            this.Status = GameStatus.InProgress;
            this.GameResumedEvent(this, EventArgs.Empty);
        }

        public void Stop()
        {
            #region Validation

            if (this.Status != GameStatus.InProgress && this.Status != GameStatus.Paused)
            {
                throw new InvalidOperationException("Only game with status 'InProgress' or 'InPaused' can be stopped");
            }

            #endregion

            if (GameStoppedEvent == null)
            {
                throw new NullReferenceException();
            }
            this.Status = GameStatus.Completed;
            this.GameStoppedEvent(this, EventArgs.Empty);
        }

        #endregion

        #region Events

        public event EventHandler GameStartedEvent;
        public event EventHandler GameStoppedEvent;
        public event EventHandler GamePausedEvent;
        public event EventHandler GameResumedEvent;

        #endregion
    }
}
