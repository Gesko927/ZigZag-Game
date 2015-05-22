using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using ZigZag.DesktopUI.GameForms;
using ZigZag.DesktopUI.Helpers;
using ZigZag.GameEngine;
using ZigZag.GameEngine.Statistic;
using Point = ZigZag.GameEngine.Point;

namespace ZigZag.DesktopUI
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private readonly string _userName;

        private readonly Game _game;
        private readonly GameStatistic _statistic;
        private readonly Timer _mapRedrawTimer;
        private readonly Timer _countingTimer;
        private readonly object _sync = new object();
        private readonly Graphics _dc;
        private bool _isMapRedraw = false;
        private int _countIndex = 3;
        private int _ballMoves = 0;
        private readonly Image _ballImage;
        private int _constYRect;
        private const double AngleRotateRad = (Math.PI / 180) * 45;
        private const int ChangeLevelValue = 20;
        private const int ChangeLevelDelay = 50;

        private int _mapPosition = 0;
        private int _ballPosition = 0;

        #endregion

        #region Private Properties

        private int Score
        {
            get
            {
                /*
                 * ВВ: 
                 *      ця функція не повинна змінювати значення полі форми
                 *      це слід реалізувати у set
                 * 
                 */
                this.ScoreLbl.Text = this._game.TotalScore.ToString();
                return this._game.TotalScore;
            }
            set { this._game.TotalScore = value; }
        }

        #endregion

        #region Constructors

        public MainForm(string userName)
        {
            InitializeComponent();
            this._userName = userName;
            /*
             * ВВ: іниціалізацію елементів форми слід виконувати в обробнику події Form_Load
             */
            this.UserNameLbl.Text = userName;
            var startPoint = new Point(this.GameBoardPnl.Width/2, 0);
            this._game = new Game(this.GameBoardPnl.Width, this.GameBoardPnl.Height, Settings.RoadWidth, Settings.RoadHeight, startPoint);
            this._mapRedrawTimer = new Timer() {Interval = Settings.MapUpdateDelay};
            this._mapRedrawTimer.Tick += this.MapRedrawEventHandler;
            this._countingTimer = new Timer {Interval = 1000};
            this._countingTimer.Tick += CountingEventHandler;
            this.countPictureBox.Hide();
            this._statistic = new GameStatistic();
            this._ballImage = (Image)new Bitmap(Properties.Resources.ball_skin, new Size(Settings.BallWidth, Settings.BallHeight));
            /*
             * ВВ: іниціалізацію елементів форми слід виконувати в обробнику події Form_Load
             */
            this.SoundModePcb.Image = SoundManager.SoundConfig == SoundMode.On ? 
                Properties.Resources.sound_on : Properties.Resources.sound_off;

            this._dc = this.GameBoardPnl.CreateGraphics();

            Console.WriteLine("MainForm - Thread - {0} - {1}", System.Threading.Thread.CurrentThread.Name, System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        #endregion

        #region Events

        #region Form Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._mapRedrawTimer.Stop();
            this._mapRedrawTimer.Dispose();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Key pressed");
#endif
            if (_game.Status == GameStatus.InProgress)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            SoundManager.ChangeBallRotation();
                            e.SuppressKeyPress = true;
                            this.Score += 3;
                            this._game.Ball.Rotation =
                                this._game.Ball.Rotation == Rotation.Left
                                    ? Rotation.Right
                                    : Rotation.Left;
                            break;
                        }
                    default:
                        break;
                }
            }
            if (e.Shift)
            {
                this.SoundModePcb_Click(sender, e);
            }
        }

        #endregion

        #region Buttons Events

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (this._game.Status == GameStatus.ReadyToStart)
            {
                SoundManager.MouseClick();
                var btn = (Button) sender;
                this._game.GameStartedEvent += delegate (object o, EventArgs eventArgs)
                {
                    this.DrawMap(this._dc);
                    this.DrawBall(this._dc, this._ballPosition);
                    this.countPictureBox.Visible = true;
                    this._countingTimer.Start();

                    btn.Enabled = false;
                    this.PauseBtn.Enabled = false;
                    this.StopBtn.Enabled = false;
                    this.ResumeBtn.Enabled = false;
                    this.CountingEventHandler(sender, e);
                };
                _game.Start();
                this.Activate();
            }
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            if (this._game.Status == GameStatus.InProgress)
            {
                SoundManager.MouseClick();
                this._game.GamePausedEvent += delegate (object o, EventArgs eventArgs)
                {
                    this.PauseBtn.Enabled = false;
                    this.ResumeBtn.Enabled = true;
                    this._mapRedrawTimer.Stop();
                };
                this._game.Pause();
                this.Activate();
            }
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            if (this._game.Status == GameStatus.Paused)
            {
                SoundManager.MouseClick();
                this._game.GameResumedEvent += delegate (object o, EventArgs eventArgs)
                {
                    this.ResumeBtn.Enabled = false;
                    this.PauseBtn.Enabled = true;
                    this._mapRedrawTimer.Start();
                };
                this._game.Resume();
                this.Activate();

            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("Stop Button Pressed");
#endif
            SoundManager.MouseClick();
            if (this._game.Status == GameStatus.InProgress ||
                this._game.Status == GameStatus.Paused)
            {
                this._game.GameStoppedEvent += delegate (object o, EventArgs eventArgs)
                {
                    this._mapRedrawTimer.Stop();
                    var gameOverForm = new GameOverForm(this._game.TotalScore);
                    this._statistic.AddStatistic(this._userName, this._game.TotalScore);
                    this.Hide();
                    gameOverForm.ShowDialog(this);
                    this.Owner.Visible = true;
                    this.Close();
                };
                this._game.Stop();
            }
        }

        #endregion

        #region Timer Events

        private void MapRedrawEventHandler(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("_this.ballPosition = {0}", this._ballPosition);
#endif
            this.countPictureBox.Hide();
            this.Score++;
            this._ballMoves++;
            if (this._ballMoves == Settings.BallHeight/2)
            {
                this._isMapRedraw = true;
                this._constYRect = this._game.Ball.CPoint.Y + (int)(Settings.RoadWidth * Math.Sin(AngleRotateRad));
#if DEBUG
                Console.WriteLine("YRECT = {0}", _constYRect);
#endif
            }
            /*
             * ВВ: наскільки я зрозумів, паралельні потоки не використовуються, тому не потрібна синхронізація
             */
            //lock (this._sync)
            {
                Console.WriteLine("MapRedrawEventHandler - Thread - {0} - {1}", System.Threading.Thread.CurrentThread.Name, System.Threading.Thread.CurrentThread.ManagedThreadId);
                if (this._isMapRedraw)
                {
                    var startIndex = this._mapPosition - Settings.BallHeight;
                    this._dc.Clear(Color.White);

                    var blockOffset = this._game.GameMap.GetMapItemPoint(startIndex).Y;

                    for (var i = startIndex; i < this._mapPosition + startIndex; ++i)
                    {
                        RedrawMap(this._dc, i, blockOffset);
                    }
                    this._mapPosition++;
                    this.DrawBall(this._dc, this._ballPosition);
                    this._ballPosition++;
                }
                else
                {
                    this._mapPosition = 0;
                    this.DrawMap(_dc);
                    this.DrawBall(_dc, _ballPosition);
                    this._ballPosition++;
                }
            }
            if (this._ballPosition%ChangeLevelValue == 0)
            {
                this._mapRedrawTimer.Interval -= ChangeLevelDelay;
                this._game.TotalScore += 10;
            }
        }

        private void CountingEventHandler(object sender, EventArgs e)
        {
            if (_countIndex == 3)
            {
                this.countPictureBox.Image = (Image)new Bitmap(Properties.Resources._3_number, this.countPictureBox.Size);
                _countIndex--;
            }
            else if (_countIndex == 2)
            {
                this.countPictureBox.Image = (Image)new Bitmap(Properties.Resources._2_number, this.countPictureBox.Size);
                _countIndex--;
            }
            else if (_countIndex == 1)
            {
                this.countPictureBox.Image =
                    (Image) new Bitmap(Properties.Resources._1_number, this.countPictureBox.Size);
                this._countIndex--;
                this._mapRedrawTimer.Start();               
                this._countingTimer.Stop();
                this.PauseBtn.Enabled = true;
                this.StopBtn.Enabled = true;
                this.ResumeBtn.Enabled = false;         
            }
        }

        #endregion

        #region Sound PictureBox Events

        private void SoundModePcb_Click(object sender, EventArgs e)
        {
            if (SoundManager.SoundConfig == SoundMode.On)
            {
                SoundManager.SoundConfig = SoundMode.Off;
                this.SoundModePcb.Image = Properties.Resources.sound_off;
            }
            else
            {
                SoundManager.SoundConfig = SoundMode.On;
                this.SoundModePcb.Image = Properties.Resources.sound_on;
                SoundManager.MouseClick();
            }
        }

        private void SoundModePcb_MouseEnter(object sender, EventArgs e)
        {
            SoundManager.MouseEnter();
        }

        #endregion

        private void GameBoardPnl_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_isMapRedraw)
            {
                this.MapRedrawEventHandler(null, null);
            }
        }

        #endregion

        #region Private Helpers

        private void DrawMap(Graphics gc)
        {
            gc.Clear(Color.White);
            for (var i = 0; i < Settings.BallHeight; ++i)
            {
                RedrawMap(gc, this._mapPosition);
                this._mapPosition++;
            }
        }

        private void RedrawMap(Graphics gc, int pos, int offset = 0)
        {
            var pen = new Pen(Color.CornflowerBlue, Settings.RoadWidth);
            var startPoint = new System.Drawing.Point
            {
                X = this._game.GameMap.GetMapItemPoint(pos).X,
                Y = this._game.GameMap.GetMapItemPoint(pos).Y - offset
            };
            var endPoint = TransformNext(this._game.GameMap.GetMapItem(pos).Rotation, startPoint);
            gc.DrawLine(pen, startPoint, endPoint);       
        }

        private void DrawBall(Graphics dc, int pos, int offset = 0)
        {
            /*
             * ВВ: наскільки я зрозумів, паралельні потоки не використовуються, тому не потрібна синхронізація
             */
            //lock (_sync)
            {
#if DEBUG
                Console.WriteLine("DrawBall - Thread - {0} - {1}", System.Threading.Thread.CurrentThread.Name, System.Threading.Thread.CurrentThread.ManagedThreadId);
#endif
                if (IsGameOver(pos))
                {
                    this._mapRedrawTimer.Stop();
                    SoundManager.GameOver();
                    var startPoint = new System.Drawing.Point()
                    {
                        X = _game.Ball.CPoint.X,
                        Y = _game.Ball.CPoint.Y
                    };
                    var point = TransformNext(this._game.Ball.Rotation, startPoint);
                    this._game.Ball.MoveAt(point.X, point.Y);
                    dc.DrawImage(this._ballImage, point.X, point.Y);
                    var gameOverForm = new GameOverForm(this._game.TotalScore);
                    this._statistic.AddStatistic(this._userName, this._game.TotalScore);
                    this.Hide();
                    gameOverForm.ShowDialog(this);
                    this.Close();
                }
                else
                {
                    var y = this._game.Ball.CPoint.Y;
                    //y = 168 + 21;
                    y = _constYRect;
                    var x = _game.GameMap.GetMapItem(pos).Rotation == Rotation.Left
                        ? this._game.GameMap.GetMapItemPoint(pos).X - (Settings.RoadWidth - Settings.BallWidth/2)
                        : this._game.GameMap.GetMapItemPoint(pos).X;
                    if (_isMapRedraw)
                    {                        
                        if (this._game.GameMap.GetMapItem(pos - 1).Rotation != this._game.Ball.Rotation)
                        {
                            x = this._game.GameMap.GetMapItemPoint(pos).X;
                        }
                        else if (this._game.Ball.Rotation == Rotation.Right)
                        {
                            x = this._game.GameMap.GetMapItemPoint(pos).X;
                        }
                        else if (this._game.Ball.Rotation == Rotation.Left)
                        {
                            x = this._game.GameMap.GetMapItemPoint(pos).X - (Settings.RoadWidth - Settings.BallWidth / 2);
                        }
                        if (this._game.Ball.Rotation == Rotation.Left &&
                            this._game.GameMap.GetMapItem(pos - 1).Rotation == Rotation.Right)
                        {
                            x = this._game.GameMap.GetMapItemPoint(pos).X - (Settings.RoadWidth - Settings.BallWidth / 2) - 2;
                        }
                    }
                    else
                    {
                        y = this._game.GameMap.GetMapItemPoint(pos).Y - offset;
                    }
#if DEBUG
                    Console.WriteLine("y = {0}", y);
#endif
                    this._game.Ball.MoveAt(x, y);
                    dc.DrawImage(this._ballImage, x, y);
                }
            }
        }

        private bool IsGameOver(int pos)
        {
            return this._game.Ball.Rotation != this._game.GameMap.GetMapItem(pos).Rotation;
        }

        private System.Drawing.Point TransformNext(Rotation rotation, System.Drawing.Point startPoint, int offset = 0)
        {
            var x = (int)Math.Round(Settings.RoadHeight*Math.Cos(AngleRotateRad));
            var y = (int)Math.Round(Settings.RoadHeight * Math.Sin(AngleRotateRad));

            return rotation == Rotation.Left ? 
                new System.Drawing.Point(startPoint.X - x, startPoint.Y + y - offset) : 
                new System.Drawing.Point(startPoint.X + x, startPoint.Y + y - offset);          
        }

        #endregion
    }
}
