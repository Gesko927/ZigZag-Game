using System;
using System.Windows.Forms;
using ZigZag.DesktopUI.Helpers;

namespace ZigZag.DesktopUI.GameForms
{
    public partial class GameOverForm : Form
    {
        #region Private Fields

        private PicturesTags _backTag;

        #endregion

        #region Constructors

        public GameOverForm(int score)
        {
            InitializeComponent();
            this._backTag = PicturesTags.Light;
            /*
             * ВВ: іниціалізацію елементів форми слід виконувати в обробнику події Form_Load
             */
            this.ScoreValueLbl.Text = score.ToString();
        }

        #endregion

        #region Events

        private void BackToMainMenuPcb_MouseEnter(object sender, EventArgs e)
        {
            if (this._backTag == PicturesTags.Light)
            {
                SoundManager.MouseEnter();
                this._backTag = PicturesTags.Dark;;
                this.BackToMainMenuPcb.Image = Properties.Resources.back_to_main_menu_drag;
            }
        }

        private void BackToMainMenuPcb_MouseLeave(object sender, EventArgs e)
        {
            if (this._backTag == PicturesTags.Dark)
            {
                this._backTag = PicturesTags.Light;
                this.BackToMainMenuPcb.Image = Properties.Resources.back_to_main_menu;
            }
        }

        private void BackToMainMenuPcb_Click(object sender, EventArgs e)
        {
            SoundManager.MouseClick();
            this.Close();
        }

        #endregion
    }
}
