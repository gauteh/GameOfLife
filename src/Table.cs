using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    // 2D tabell
    public class Table
    {
        // Timer
        public bool running = false;


        // Standardstørrelse på tabell og dermed og Grid
        // Alle klassar skal hente desse verdiane frå her; dermed vil vi enkelt kunne
        // utvide det seinare.

        public const int HEIGHT = 30;
        public const int WIDTH = 68;

        // Liste med tabellar
        // Tabellen vil ha størrelsen int[HØGDE, BREIDDE]

        private int[,] table;

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
            table = new int [HEIGHT, WIDTH];

            // Tøm tabell
            Console.WriteLine ("Tabell: Fyller tabeller med 0..");
            Clear ();

            // Sett opp regel
            rule = new Rule();
        }

        // Tømmer tabellen
        public void Clear () {
             for (int i = 0; i < HEIGHT; i++)
                for (int j = 0; j < WIDTH; j++)
                    table[i,j] = 0;

            Changed ();
        }

        public int[,] Cells {
            get { return table; }
        }


        private void Changed () {
            // Send TableChangedEvent
            if (TableChangedEvent != null)
                TableChangedEvent ();
        }


        // Toggle ei celle i tabellen (ie. ved museklikk)
        public void ToggleCell (int y, int x) {
            if (table[y,x] == 0) {
                table[y,x] = 1;
            } else {
                table[y,x] = 0;
            }

            if (TableCellChangedEvent != null)
                TableCellChangedEvent (y, x);

        }

        public void SetCell (int y, int x, int value) {
            table[y,x] = value;
            if (TableCellChangedEvent != null)
                TableCellChangedEvent (y, x);
        }

        public void RuleIteration()
        {
            rule.ApplyRule(this);
        }

        public bool RunCheck
        {
            get { return running; }
            set { running = value; }
        }
        

    }
}

// vim: set noai sw=4 tw=4 ts=4:
