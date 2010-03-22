using System;

namespace GameOfLife
{

    public abstract class Game
    {
        public MainWindow mainwindow;
        private bool running = false;
        protected int iterations = 0;


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

        // Klasse som held info om ei 'linje' i Score databasen
        public class Score {
            public string type;
            public string name;
            public int score;

            public Score (string t, string n, int s) {
                type = t;
                name = n;
                score = s;
            }
        }

        public void SaveHighScore (string type, int score) {
            // Opn form for å få navn
            // skriv til fil avhengig av type (ie. MaxCells etc etc)
            // score = poengsummen oppnådd
            // den her blir overloada i subklassa der den gir seg sjølv som type
        }

        public Score[] GetHighScore (string type) {
            // hent score basert på type og returner ein array av 'scores'
            Score [] s = new Score [5];
            return s;
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
