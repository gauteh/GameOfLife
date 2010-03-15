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

        public const int HEIGHT = 30;
        public const int WIDTH = 68;

        // Liste med tabellar
        // Tabellen vil ha størrelsen int[HØGDE, BREIDDE]

        private List<int[,]> tables;

        // TableChanged event, når tabellen har endra seg får Grid beskjed
        public delegate void TableChangedHandler ();
        public event TableChangedHandler TableChangedEvent;

        // TableCellChanged event, når ei celle har forandra seg
        // Ungår å måtte teikne heile gridden på nytt
        public delegate void TableCellChangedHandler (int y, int x);
        public event TableCellChangedHandler TableCellChangedEvent;

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

            Changed ();
        }

        public void Swap () {
            // TODO: Optimiser ? Standard måte å gjere dette på ?
            int [,] tmp = tables[0];
            tables[0] = tables[1];
            tables[1] = tmp;
            Changed ();
        }

        public int[,] TableNow {
            get { return tables[0]; }
        }

        public int[,] TableNext {
            get { return tables[1]; }
            set { tables[1] = value; }
        }

        public List<int[,]> Tables {
            get { return tables; }
        }

        private void Changed () {
            // Send TableChangedEvent
            if (TableChangedEvent != null)
                TableChangedEvent ();
        }


        // Toggle ei celle i tabellen (ie. ved museklikk)
        // Baserar oss på den gamle tabellen men byttar i begge slik at den
        // og blir tatt med i neste berekning.
        public void ToggleCell (int y, int x) {
            if (tables[0][y,x] == 0) {
                tables[0][y,x] = 1;
                tables[1][y,x] = 1;
            } else {
                tables[0][y,x] = 0;
                tables[1][y,x] = 0;
            }

            if (TableCellChangedEvent != null)
                TableCellChangedEvent (y, x);

        }

    }
}

// vim: set noai sw=4 tw=4 ts=4:
