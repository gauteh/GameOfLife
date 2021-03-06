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

        // Tabell med celle
        // Tabellen vil ha størrelsen int[HØGDE, BREIDDE]

        private int[,] cells;

        // TableChanged event, når tabellen har endra seg får Grid beskjed
        public delegate void TableChangedHandler ();
        public event TableChangedHandler TableChangedEvent;

        // TableCellChanged event, når ei celle har forandra seg
        // Ungår å måtte teikne heile gridden på nytt
        public delegate void TableCellChangedHandler (int y, int x);
        public event TableCellChangedHandler TableCellChangedEvent;

        public Table () {
            cells = new int [HEIGHT, WIDTH];
        }

        // Tømmer tabellen
        public void Clear () {
             for (int i = 0; i < HEIGHT; i++)
                for (int j = 0; j < WIDTH; j++)
                    cells[i,j] = 0;

            Changed ();
        }

        public int[,] Cells {
            get { return cells; }
        }


        private void Changed () {
            // Send TableChangedEvent
            if (TableChangedEvent != null)
                TableChangedEvent ();
        }


        // Toggle ei celle i tabellen (ie. ved museklikk)
        public void ToggleCell (int y, int x) {
            if (cells[y,x] == 0) {
                cells[y,x] = 1;
            } else {
                cells[y,x] = 0;
            }

            if (TableCellChangedEvent != null)
                TableCellChangedEvent (y, x);

        }

        public void SetCell (int y, int x, int value) {
            cells[y,x] = value;
            if (TableCellChangedEvent != null)
                TableCellChangedEvent (y, x);
        }

        // Hjelpe funksjon som returnerar ein kopi av ein celletabell
        // Størrelsen definert her i Table
        public static int[,] CopyCells (int [,] cells) {
            int [,] copy = new int[Table.HEIGHT, Table.WIDTH];
            for (int i = 0; i < Table.HEIGHT; i++)
                for (int j = 0; j < Table.WIDTH; j++)
                    copy[i,j] = cells[i,j];

            return copy;
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
