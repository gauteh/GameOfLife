using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace GameOfLife
{
    public partial class MainWindow : Form
    {
        // variabel som viser om vi treng å teikne gridden på nytt
        public bool repainted = false;

        public System.Drawing.Point gridLocation;
        public System.Drawing.Size  gridSize;

        // gridClick event (om musa blir klikka innafor gridden)
        // http://msdn.microsoft.com/en-us/library/aa645739(VS.71).aspx
        // Lagar ein delegate prototype: denne typen funksjonar kan ta i mot klikk innafor gridden
        public delegate void gridClickHandler (object sender, MouseEventArgs e);

        // Sjølve eventen som ein må koble seg på med slike funksjonar
        public event gridClickHandler gridClickEvent;

        public MainWindow()
        {
            InitializeComponent();

            // Koblar funksjonen on_GridClick til _alle_ museklikk
            // den sjekkar om den ligg innafor gridden, og lagar eit nytt gridClickEvent
            // om den er innafor. Denne kan ein koble seg på på samme måte som den her er kobla på
            // m.gridClickEvent += new gridClickHandler (funksjon) der m er instansen av MainWindow
            this.MouseClick += new MouseEventHandler (on_gridClick);
        }

        protected override void OnPaint (PaintEventArgs e) {
            base.OnPaint (e);
            repainted = true;
        }

        private void on_gridClick (object sender, MouseEventArgs e)
        {
            // TODO: Muligens flytte det her til Grid.cs og gi ut ei spesifikk rute i Eventen
            if ((e.Location.X > gridLocation.X && e.Location.X < (gridLocation.X + gridSize.Width)) &&
               (e.Location.Y > gridLocation.Y && e.Location.Y < (gridLocation.Y + gridSize.Height)))
            {
                if (gridClickEvent != null)
                    gridClickEvent (this, e); // Køyr gridClick event
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
