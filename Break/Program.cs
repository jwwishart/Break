using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Break
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );

            // Kudos: http://www.codeproject.com/KB/cs/NotifyChecker.aspx
            BreakRunner runner = BreakRunner.GetInstance();
            runner.Start();

            Application.Run();

            runner.Stop();
            runner = null;
        }
    }
}
