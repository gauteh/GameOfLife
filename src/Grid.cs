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
            int x = 6;
            int y = 6;
            Pen redpen = new Pen(Color.Red);
            Pen bluepen = new Pen(Color.Blue);
            Point pStart = new Point(x, y);
            Point pWidth = new Point(680, y);
            Point pHight = new Point(x, 310);

                for (int n = 0; n <= 31; n++)
                {


                    //Rectangle r = new Rectangle(6, 6, gridWidtht, gridHeight - 24);
                    ge.DrawLine(bluepen, pStart, pWidth);
                }
                for (int m = 0; m <= 68; m++)
                    {
                    ge.DrawLine(bluepen, pStart, pHight);
                    y += 10;
                }
                y = 6;
                x += 10;
            }
            //Rectangle b = new Rectangle(6, 6, 10,10);
            /*
                int x = 6;
                int y = 6;
                for (int m = 0; m < 30; m++)
                {
                    for (int n = 0; n < 68; n++)
                    {
                        Rectangle a = new Rectangle(x, y, 10, 10);
                        x += 10;
                        ge.DrawRectangle(p1, a);
                    }
                    x = 6;
                    y += 10;
                }
            */
           
            Brush brsh = new SolidBrush(Color.Blue);
            //ge.DrawRectangle(redpen,r);
        }

        public bool Dirty {
            get { return dirty; }
            set { dirty = value; }

        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
