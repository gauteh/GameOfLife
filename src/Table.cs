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

        // Lar regel være ein del av tabell sidan den treng direkte tilgang
        public Rule rule;

        public Table () {
            tables = new List<int[,]>();

            // Sett opp tabell
            tables.Add (new int [HEIGHT, WIDTH]);
            tables.Add (new int [HEIGHT, WIDTH]);

            // Tøm tabell
            Console.WriteLine ("Tabell: Fyller tabeller med 0..");
            Clear ();

            // Sett opp regel
            rule = new Rule();
        }

        public void Swap () {
            // Kopierer TableNext til TableNow
            for (int i = 0; i < HEIGHT; i++)
                for (int j = 0; j < WIDTH; j++)
                    tables[0][i,j] = tables[1][i,j];
            Changed ();
        }

        // Tømmer tabellen
        public void Clear () {
             for (int i = 0; i < HEIGHT; i++)
                for (int j = 0; j < WIDTH; j++) {
                    tables[0][i,j] = 0;
                    tables[1][i,j] = 0;
            }
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
        public void ToggleCell (int y, int x) {
            if (tables[0][y,x] == 0) {
                tables[0][y,x] = 1;
            } else {
                tables[0][y,x] = 0;
            }

            if (TableCellChangedEvent != null)
                TableCellChangedEvent (y, x);

        }

        public void RuleIteration()
        {
            rule.ApplyRule(ref tables);
        }

    }
}

// vim: set noai sw=4 tw=4 ts=4:
