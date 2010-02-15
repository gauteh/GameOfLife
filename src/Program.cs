using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

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
			
			// Lagar MainWindow
			Console.WriteLine ("Setter opp MainWindow..");
			MainWindow m = new MainWindow ();
			m.Show ();
			
			// Lagar tabell
			Console.WriteLine ("Setter opp tabell..");
			Table table = new Table ();
			
			// Lagar Grid
			Console.WriteLine ("Setter opp grid..");
			Grid grid = new Grid (table);
			
			
			Console.WriteLine ("Main loop");
			
			// Køyrer hovedloopen her slik at vi har kontroll på våre eigne ting og
			// kan legge inn ekstra ting som regelutrekning osv sjølv som skal gå 
			// 'paralelt' med oppdateringa av brukargrensesnittet.
			
			while (m.Created) {
				Application.DoEvents (); // Prosesser alle museklikk osv..
				
				m.Update (); // Teikn forma på nytt
				
				// Teikn grid på nytt dersom tabell er oppdatert
				if (table.Dirty) grid.Dirty = true;
				
				// Teikn grid på nytt om nødvendig
				if (grid.Dirty) grid.Draw (m.CreateGraphics());
			}
            //Application.Run(new MainWindow());

        }
    }
}
