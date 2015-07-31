using System;
using System.Windows.Forms;

namespace WallChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">todo: describe args parameter on Main</param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#pragma warning disable CC0022 // Should dispose object
            Application.Run(new MainForm(args.Length > 0 && args[0] == "hide"));
#pragma warning restore CC0022 // Should dispose object
        }
    }
}
