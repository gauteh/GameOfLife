using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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

        private MainWindow mainwindow;

        private int gridTop;  // Start i frå toppen
        private int gridLeft; // Start i frå venstre

        private int gridWidth;
        private int gridHeight;

        // GridEventArgs klasse som held informasjon om hvilke rute som vart klikka
        public class GridEventArgs : EventArgs
        {
            // Ruteposisjon
            public Point Cell;
            public MouseEventArgs MouseEvent;

            public GridEventArgs(int y, int x, MouseEventArgs mouseevent)
            {
                MouseEvent = mouseevent;

                Cell.Y = y;
                Cell.X = x;
            }

            public int X
            { get { return Cell.X; } }

            public int Y
            { get { return Cell.Y; } }
        }
        // gridClick event (om musa blir klikka innafor gridden)
        // http://msdn.microsoft.com/en-us/library/aa645739(VS.71).aspx
        // Lagar ein delegate prototype: denne typen funksjonar kan ta i mot klikk innafor gridden
        public delegate void gridClickHandler (object sender, GridEventArgs e);

        // Sjølve eventen som ein må koble seg på med slike funksjonar
        public event gridClickHandler gridClickEvent;

        public Grid (MainWindow m)
        {
            mainwindow = m;
            gridWidth = m.Size.Width - 20;
            gridHeight = m.Size.Height - m.Controls.Find("groupControllers", true)[0].Size.Height - 20;

            gridTop = 6;
            gridLeft = 6;

            // Koblar funksjonen on_GridClick til _alle_ museklikk
            // den sjekkar om den ligg innafor gridden, og lagar eit nytt gridClickEvent
            // om den er innafor. Denne kan ein koble seg på på samme måte som den her er kobla på
            // m.gridClickEvent += new gridClickHandler (funksjon) der m er instansen av MainWindow
            m.MouseClick += new MouseEventHandler (on_gridClick);
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            Table table = mainwindow.table;
            Graphics ge = e.Graphics;
            // ge er teikneområdet på forma som dåke kan teikne på
            int x = 6;
            int y = 6;
            int m = 0;
            int n = 0;
            int px, py;

            px = 6 + (x * 10);
            py = 6 + (y * 10);
            Pen bluepen = new Pen(Color.Blue);
            Brush bluebrsh = new SolidBrush(Color.Blue);

            // Ein brush med bakgrunnsfargen til Forma slik at vi kan 'viske' :)
            Brush cleanbrsh = new SolidBrush(mainwindow.BackColor);


            Point pStart = new Point(x, y);
            Point pHight = new Point(x, 305);
            Point p1Start = new Point(x, y);
            Point p1Width = new Point(685, y);


            for (m = 0; m <= Table.WIDTH; m++)
            {
                ge.DrawLine(bluepen, pStart, pHight);
                pStart.X += 10;
                pHight.X += 10;
            }
            for (n = 0; n <= Table.HEIGHT; n++)
            {
                ge.DrawLine(bluepen, p1Start, p1Width);
                p1Start.Y += 10;
                p1Width.Y += 10;
            }

            for (m = 0; m < Table.HEIGHT; m++)
            {
                for (n = 0; n < Table.WIDTH; n++)
                {
                    if (table.Cells[m, n] == 1)
                    {
                        Rectangle a = new Rectangle(pStart.X, p1Start.Y, 10, 10);
                        x += 10;
                        ge.FillRectangle(bluebrsh, a);
                    }
                    else
                    {
                        Rectangle c = new Rectangle(pStart.X + 1, p1Start.Y + 1, 9, 9);
                        x += 10;
                        ge.FillRectangle(cleanbrsh, c);
                    }
                }
                x = 6;
                y += 10;
            }
        }
               
                
            
    
                 



        
        // Teikn enkeltcelle, blir køyrd på TableCellChanged eventen
        public void DrawCell (int y, int x) {
            Table table = mainwindow.table;
            Graphics ge = mainwindow.CreateGraphics ();

            int px, py;

            px = 6 + (x * 10);
            py = 6 + (y * 10);

            Pen bluepen = new Pen(Color.Blue);
            Brush bluebrsh = new SolidBrush(Color.Blue);

            // Ein brush med bakgrunnsfargen til Forma slik at vi kan 'viske' :)
            Brush cleanbrsh = new SolidBrush (mainwindow.BackColor);

            if (table.Cells[y,x] == 1)
            {
                Rectangle a = new Rectangle(px, py, 10, 10);
                ge.FillRectangle(bluebrsh,a);
             }
             else
             {
                Rectangle a = new Rectangle(px, py, 10, 10);
                Rectangle c = new Rectangle (px + 1, py + 1, 9, 9);
                ge.DrawRectangle (bluepen, a);
                ge.FillRectangle (cleanbrsh, c);
             }
        }


        // Funksjonen som sjekkar om klikket er innafor gridden og sender ut ein ny event i sofall
        private void on_gridClick (object sender, MouseEventArgs e)
        {
            if ((e.Location.X > gridLeft && e.Location.X < (gridLeft + gridWidth)) &&
               (e.Location.Y > gridTop && e.Location.Y < (gridTop + gridWidth)))
            {
                double diffx = gridWidth / Table.WIDTH;
                double diffy = gridHeight / Table.HEIGHT;

                double x = (e.Location.X - gridLeft - (diffx / 2)) / diffx;
                double y = (e.Location.Y - gridTop - (diffy / 2)) / diffy;

                int ix = Convert.ToInt32 (x);
                int iy = Convert.ToInt32 (y);

                if (ix < Table.WIDTH || iy < Table.HEIGHT)
                    if (gridClickEvent != null)
                        gridClickEvent(this, new GridEventArgs (iy, ix, e));
            }
        }

        public System.Drawing.Point Location {
            get { return new System.Drawing.Point (gridTop, gridLeft); }
        }

        public System.Drawing.Size Size {
            get { return new System.Drawing.Size (gridWidth, gridHeight); }
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
