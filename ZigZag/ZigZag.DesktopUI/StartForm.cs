using System;
using System.Windows.Forms;
using ZigZag.DesktopUI.GameForms;
using ZigZag.DesktopUI.Helpers;

namespace ZigZag.DesktopUI
{
    public partial class StartForm : Form
    {
        #region Private Fields

        private PicturesTags _playTag;
        private PicturesTags _editUserNameTag;
        private PicturesTags _controlTag;
        private PicturesTags _ratingTag;
        private PicturesTags _exitTag;

        private string _userName;

        #endregion

        #region Public Constructors

        public StartForm()
        {
            InitializeComponent();
            this._playTag = PicturesTags.Light;
            this._editUserNameTag = PicturesTags.Light;
            this._controlTag = PicturesTags.Light;
            this._ratingTag = PicturesTags.Light;
            this._exitTag = PicturesTags.Light;
            this._userName = "Player";
        }

        #endregion

        #region Events

        #region Play PictureBox Events

        private void PlayPcb_MouseEnter(object sender, EventArgs e)
        {
            if (_playTag == PicturesTags.Light)
            {
                this.PlayPcb.Image = Properties.Resources.play_img_drag;
                _playTag = PicturesTags.Dark;
                SoundManager.MouseEnter();
            }
        }

        private void PlayPcb_MouseLeave(object sender, EventArgs e)
        {
            if (_playTag == PicturesTags.Dark)
            {
                _playTag = PicturesTags.Light;
                this.PlayPcb.Image = Properties.Resources.play_img;
            }
        }

        private void PlayPcb_MouseDown(object sender, MouseEventArgs e)
        {
            SoundManager.MouseClick();
            this.Visible = false;
            var form = new MainForm(_userName);
            form.ShowDialog(this);
            this.Visible = true;
        }

        #endregion

        #region Edit User Name PictureBox Events

        private void EditUserNamePcb_MouseEnter(object sender, EventArgs e)
        {
            if (this._editUserNameTag == PicturesTags.Light)
            {
                this.EditUserNamePcb.Image = Properties.Resources.edit_un_drag;
                this._editUserNameTag = PicturesTags.Dark;
                SoundManager.MouseEnter();
            }
        }

        private void EditUserNamePcb_MouseLeave(object sender, EventArgs e)
        {
            if (this._editUserNameTag == PicturesTags.Dark)
            {
                this._editUserNameTag = PicturesTags.Light;
                this.EditUserNamePcb.Image = Properties.Resources.edit_un;
            }
        }

        private void EditUserNamePcb_MouseDown(object sender, MouseEventArgs e)
        {
            SoundManager.MouseClick();
            var unForm = new EditUserNameForm();
            var dialogResult = unForm.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                this._userName = unForm.UserName;
            }
        }

        #endregion

        #region Control PictureBox Events

        private void ControlPcb_MouseEnter(object sender, EventArgs e)
        {
            if (this._controlTag == PicturesTags.Light)
            {
                this.ControlPcb.Image = Properties.Resources.control_drag;
                this._controlTag = PicturesTags.Dark;
                SoundManager.MouseEnter();
            }
        }

        private void ControlPcb_MouseLeave(object sender, EventArgs e)
        {
            if (this._controlTag == PicturesTags.Dark)
            {
                this._controlTag = PicturesTags.Light;
                this.ControlPcb.Image = Properties.Resources.control;
            }
        }

        private void ControlPcb_MouseDown(object sender, MouseEventArgs e)
        {
            SoundManager.MouseClick();
            var controlForm = new ControlInstructuinForm();
            controlForm.ShowDialog();
        }

        #endregion

        #region Rating PictureBox Events

        private void RatingPcb_MouseEnter(object sender, EventArgs e)
        {
            if (this._ratingTag == PicturesTags.Light)
            {
                this.RatingPcb.Image = Properties.Resources.rating_drag;
                this._ratingTag = PicturesTags.Dark;
                SoundManager.MouseEnter();
            }
        }

        private void RatingPcb_MouseLeave(object sender, EventArgs e)
        {
            if (this._ratingTag == PicturesTags.Dark)
            {
                this._ratingTag = PicturesTags.Light;
                this.RatingPcb.Image = Properties.Resources.rating;
            }
        }

        private void RatingPcb_MouseDown(object sender, MouseEventArgs e)
        {
            SoundManager.MouseClick();
            var ratingForm = new RatingForm();
            ratingForm.ShowDialog(this);
        }

        #endregion

        #region Exit PictureBox Events

        private void ExitPcb_MouseEnter(object sender, EventArgs e)
        {
            if (this._exitTag == PicturesTags.Light)
            {
                this.ExitPcb.Image = Properties.Resources.exit_img_drag;
                this._exitTag = PicturesTags.Dark;
                SoundManager.MouseEnter();
            }
        }

        private void ExitPcb_MouseLeave(object sender, EventArgs e)
        {
            if (this._exitTag == PicturesTags.Dark)
            {
                this._exitTag = PicturesTags.Light;
                this.ExitPcb.Image = Properties.Resources.exit_img;
            }
        }

        private void ExitPcb_MouseDown(object sender, MouseEventArgs e)
        {
            SoundManager.MouseClick();
            var dialogResult = MessageBox.Show("Are you sure you want to out?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (SoundManager.SoundConfig == SoundMode.On)
                {
                    SoundManager.CloseApplication();
                    this.Hide();
                    System.Threading.Thread.Sleep(3000);
                }
                this.Close();
            }
        }

        #endregion

        #region SoundMode PictureBox Events

        private void SoundModePcb_MouseEnter(object sender, EventArgs e)
        {
            SoundManager.MouseEnter();
        }

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

        #endregion

        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Key pressed in StartForm");
#endif

            if (e.Shift)
            {
#if DEBUG
                Console.WriteLine("Key Shift pressed in StartForm");
#endif
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
        }

        #endregion
    }
}
