using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
			MainWindow m = new MainWindow ();
			m.Show ();
			
			Console.WriteLine ("Main loop");
			
			// Køyrer hovedloopen her slik at vi har kontroll på våre eigne ting og
			// kan legge inn ekstra ting som regelutrekning osv sjølv som skal gå 
			// 'paralelt' med oppdateringa av brukargrensesnittet.
			
			while (m.Created) {
				m.Update (); // Teikn på nytt dei delane av Forma som er 'Invalidated'
							 // bruk dette på Grid for å få den teikna på nytt

				Application.DoEvents (); // Prosesser alle museklikk osv..

			}
            //Application.Run(new MainWindow());

        }
    }
}
