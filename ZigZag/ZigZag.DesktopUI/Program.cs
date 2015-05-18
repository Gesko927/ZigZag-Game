using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZigZag.DesktopUI.Helpers;

namespace ZigZag.DesktopUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            NativeMethods.AllocConsole();
#endif
            Application.Run(new StartForm());
#if DEBUG
           NativeMethods.FreeConsole();
#endif
        }
    }
}
