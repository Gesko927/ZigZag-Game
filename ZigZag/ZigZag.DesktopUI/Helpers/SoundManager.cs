using System.Media;

namespace ZigZag.DesktopUI.Helpers
{
    static class SoundManager
    {
        #region Public Static Fields

        public static SoundMode SoundConfig;

        #endregion

        #region Static Constructor

        static SoundManager()
        {
            SoundConfig = SoundMode.On;
        }

        #endregion

        #region Public Static Methods

        public static void MouseClick()
        {
            if (SoundConfig == SoundMode.On)
            {
                var soundPlayer = new SoundPlayer
                {
                    Stream = Properties.Resources.mouse_click
                };
                soundPlayer.Play();
            }
        }

        public static void MouseEnter()
        {
            if (SoundConfig == SoundMode.On)
            {
                var soundPlayer = new SoundPlayer
                {
                    Stream = Properties.Resources.mouse_over
                };
                soundPlayer.Play();
            }
        }

        public static void ChangeBallRotation()
        {
            if (SoundConfig == SoundMode.On)
            {
                var soundPlayer = new SoundPlayer
                {
                    Stream = Properties.Resources.change_ball_rotation
                };
                soundPlayer.Play();
            }
        }

        public static void CloseApplication()
        {
            if (SoundConfig == SoundMode.On)
            {
                var soundPlayer = new SoundPlayer
                {
                    Stream = Properties.Resources.closeapp_snd
                };
                soundPlayer.Play();
            }
        }

        public static void GameOver()
        {
            if (SoundConfig == SoundMode.On)
            {
                var soundPlayer = new SoundPlayer
                {
                    Stream = Properties.Resources.game_over
                };
                soundPlayer.Play();
            }
        }

        #endregion
    }

    public enum SoundMode
    {
        On,
        Off
    }
}
