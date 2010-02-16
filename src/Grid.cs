using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GameOfLife
{

    // Klasse for rutenett
    // - Skal teikne grafikken i MainWindow
    // - Tar i mot ein tabell
    // - Tar i mot museklikk og finn ut kor i tabellen det vart klikka
    public class Grid
    {
        // Privat fordi Table.* skal brukast
        private const int HEIGHT = Table.HEIGHT;
        private const int WIDTH = Table.WIDTH;

        // dirty forteller om gridden må teiknast på nytt
        private bool dirty = false;

        private Table table;
        private MainWindow mainwindow;
        private int gridWidtht;
        private int gridHeight;

        public Grid (Table t, MainWindow m)
        {
            table = t;
            mainwindow = m;
            gridWidtht = m.Size.Width - 20;
            gridHeight = m.Size.Height - m.Controls.Find("groupControllers", true)[0].Size.Height - 20;

            // Sett opp grid med størrelse HEIGHT * WIDTH
        }

        public void Draw (Graphics ge) {
            // ge er teikneområdet på forma som dåke kan teikne på
            Pen p = new Pen(Color.Red);

            Rectangle r = new Rectangle(5, 5, gridWidtht, gridHeight);
            Brush brsh = new SolidBrush(Color.Red);
            ge.DrawRectangle(p,r);
           // ge.DrawRectangle (p, r);
            ge.FillRectangle (brsh, r);

        }

        public bool Dirty {
            get { return dirty; }
            set { dirty = value; }

        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
