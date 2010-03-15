using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace GameOfLife
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

            // Setter opp MainWindow
            Console.WriteLine ("Setter opp MainWindow..");
            MainWindow m = new MainWindow ();
            m.Show ();

            Console.WriteLine ("Main loop");
            Application.Run(m);
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
