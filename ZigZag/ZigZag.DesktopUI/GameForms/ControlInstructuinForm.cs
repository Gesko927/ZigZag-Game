using System;
using System.Windows.Forms;
using ZigZag.DesktopUI.Helpers;

namespace ZigZag.DesktopUI.GameForms
{
    public partial class ControlInstructuinForm : Form
    {
        #region Constructors

        public ControlInstructuinForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void GoBackPcb_Click(object sender, EventArgs e)
        {
            SoundManager.MouseClick();
            this.Close();
        }

        private void GoBackPcb_MouseEnter(object sender, EventArgs e)
        {         
            SoundManager.MouseEnter();
        }

        #endregion
    }
}
