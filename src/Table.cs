using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{   
	// 2D tabell
    public class Table
    {
		// Standardstørrelse på tabell og dermed og Grid
		// Alle klassar skal hente desse verdiane frå her; dermed vil vi enkelt kunne
		// utvide det seinare.
		
		public const int HEIGHT = 50;
		public const int WIDTH = 80;
		
		// Liste med tabellar
		// Tabellen vil ha størrelsen int[HØGDE, BREIDDE]
		
		private List<int[,]> tables;
		
		// Forteller om tabellen har blitt forandra
		private bool dirty = false;
		
		public Table () {
			tables = new List<int[,]>();
			
			// Sett opp tabell
			tables.Add (new int [HEIGHT, WIDTH]);
			tables.Add (new int [HEIGHT, WIDTH]);
			
			// Sett til 0
			Console.WriteLine ("Tabell: Fyller tabeller med 0..");
			foreach (int[,] a in tables) {
				for (int i = 0; i < HEIGHT; i++) {
					for (int j = 0; j < WIDTH; j++) {
						a[i,j] = 0;	
					}
				}
			}
			
			dirty = true;
		}
		
		public void Swap () {
			// TODO: Optimiser ? Standard måte å gjere dette på ?
			int [,] tmp = tables[0];
			tables[0] = tables[1];
			tables[1] = tmp;
			dirty = true;
		}
		
		public int[,] TableNow {
			get { return tables[0]; }
		}
		
		public int[,] TableNext {
			get { return tables[1]; }
			set { 
				tables[1] = value; 
				dirty = true;
			}
		}
		
		public List<int[,]> Tables {
			get { return tables; }
		}
		
		public bool Dirty {
			get { return dirty; }
			set {
				dirty = value;
			}
		}

		// Toggle ei celle i tabellen (ie. ved museklikk)
		// Baserar oss på den gamle tabellen men byttar i begge slik at den
		// og blir tatt med i neste berekning.
		public void ToggleCell (int x, int y) {
			if (tables[0][x,y] == 0) {
				tables[0][x,y] = 1;
				tables[1][x,y] = 1;
			} else {
				tables[0][x,y] = 0;
				tables[1][x,y] = 0;
			}
			dirty = true;
		}
        
    }
}
