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

            // Setter opp tabell
            Console.WriteLine ("Setter opp tabell..");
            Table table = new Table ();

            // Teiknar forma på nytt dersom tabellen blir forandra
            table.TableChangedEvent += new Table.TableChangedHandler (m.OnTableChanged);

            // Setter opp grid
            Console.WriteLine ("Setter opp grid..");
            Grid grid = new Grid (table, m);

            // Teikn enkeltcelle dersom dei blir forandra i tabellen
            table.TableCellChangedEvent += new Table.TableCellChangedHandler (grid.DrawCell);

            // Teikn gridden når forma blir teikna
            m.Paint += new PaintEventHandler (grid.Draw);

            Console.WriteLine ("Main loop");
            Application.Run(m);
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
