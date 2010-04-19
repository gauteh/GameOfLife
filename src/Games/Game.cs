using System;

namespace GameOfLife
{

    public abstract class Game
    {
        public MainWindow mainwindow;
        private bool running = false;
        protected int iterations = 0;
        protected int maxcells = 0; // maksimale nummer av celler som har
                                  // vore til stade samtidig


        public Game (MainWindow m) {
            mainwindow = m;

            // Koblar den lokale funksjonen onGridClick til gridClickEventen, den kan fråkoblast
            // og andre funksjonar kan og koblast på på eit seinare tidspunkt
            mainwindow.grid.gridClickEvent += new Grid.gridClickHandler (OnGridClick);
            mainwindow.clock.Tick += new EventHandler (Tick);
            mainwindow.btnStep.Click += new EventHandler (StepButton);
            mainwindow.btnRun.Click += new EventHandler (RunButton);
            mainwindow.btnClear.Click += new EventHandler (ClearButton);
        }

        public abstract bool Finished ();
        public abstract int GetScore ();
        public abstract void Iterate ();
        public abstract void Tick (object sender, EventArgs e);
        public abstract void RunButton (object sender, EventArgs e);
        public abstract void ClearButton (object sender, EventArgs e);
        public abstract void StepButton (object sender, EventArgs e);

        public void DisableControls () {
            mainwindow.btnRun.Enabled = false;
            mainwindow.btnClear.Enabled = false;
            mainwindow.btnStep.Enabled = false;
        }

        public void EnableControls () {
            mainwindow.btnRun.Enabled = true;
            mainwindow.btnClear.Enabled = true;
            mainwindow.btnStep.Enabled = true;
        }

         public int CountActiveCells (int [,] cells) {
            int activecells = 0;

            for (int y = 0; y < Table.HEIGHT; y++)
              for (int x = 0; x < Table.WIDTH; x++)
                if (cells[y, x] == 1) activecells++;

            return activecells;
        }

        public abstract void OnGridClick (object sender, Grid.GridEventArgs e);

        public bool Running
        {
            get { return running; }
            set { running = value; }
        }

        public int Iterations
        {
            get { return iterations; }
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
