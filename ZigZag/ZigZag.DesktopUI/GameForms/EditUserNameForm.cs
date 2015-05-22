using System;
using System.Windows.Forms;
using ZigZag.DesktopUI.Helpers;

namespace ZigZag.DesktopUI.GameForms
{
    public partial class EditUserNameForm : Form
    {
        #region Public Properties

        /*
         * ВВ: властивість можна реалізувати так, щоб в get і set відбувався прямий доступ до InputUserNameTxBx.Text
         * 
         */
        public string UserName { get; set; }

        #endregion

        #region Constructors

        public EditUserNameForm()
        {
            InitializeComponent();
            /*
             * ВВ: іниціалізацію елементів форми слід виконувати в обробнику події Form_Load
             */
            this.InputUserNameTxBx.Select(InputUserNameTxBx.Text.Length, 0);
        }

        #endregion

        #region Events

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            SoundManager.MouseClick();
            this.UserName = InputUserNameTxBx.Text; 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            SoundManager.MouseClick();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
