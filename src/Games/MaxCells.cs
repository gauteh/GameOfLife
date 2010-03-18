using System;
using System.Windows.Forms;

namespace GameOfLife
{


    public class MaxCells : Game
    {
        private bool game_ready; // klar til å startast
        private bool game_started; // har blitt starta
        private bool game_finished; // har blitt fullført

        private const int maxinputcells = 15;

        private int maxcells = 0; // the maxium number of cells that has been present

        private int[,] ppreviouscells;
        private int[,] previouscells;

        public MaxCells (MainWindow m) : base (m)
        {
          // Setter opp spel
          DisableControls ();

          // Fyll inn ruter (sjå OnGridClick)
          game_ready = false;
          game_started = false;
          game_finished = false;

          ppreviouscells = null;
          previouscells = null;
        }

        public override int GetScore () {
            return maxcells * 100;
        }

        public override bool Finished () {
            if (!game_finished) {
                bool equal = true;

                int [,] cells = mainwindow.table.Cells;

                if (ppreviouscells == null) {
                  equal = false;
                } else {
                  for (int y = 0; y < Table.HEIGHT; y++)
                    for (int x = 0; x < Table.WIDTH; x++) {
                      if (ppreviouscells[y, x] != cells[y, x]) {
                        equal = false;
                        break;
                      }
                    }
                }

                if (equal) {
                    game_finished = true;
                }

                // lag kopi av cellen som eg sjekkar mot ved neste iterasjon
                if (previouscells != null) ppreviouscells = Rule.CopyCells (previouscells);
                previouscells = Rule.CopyCells (cells);
            }

            return game_finished;
        }

        public override void Iterate () {
            if (game_ready) {
                iterations++;
                mainwindow.table.RuleIteration ();

                // update score
                int x = CountActiveCells (mainwindow.table.Cells);
                if (x > maxcells) maxcells = x;

                if (Finished ()) {
                    MessageBox.Show ("Yey! Du er ferdig; scoren din er: " + GetScore().ToString (), "Ferdig!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Running = false;

                    mainwindow.btnRun.Enabled = false;
                    mainwindow.btnStep.Enabled = false;
                }
            }
        }

        public override void OnGridClick (object sender, Grid.GridEventArgs e) {
            // Kan kun fylle inn dersom spelet ikkje har blitt starta
            if (!game_started && !game_ready) {
                mainwindow.table.ToggleCell (e.Y, e.X);
                if (CountActiveCells (mainwindow.table.Cells) >= maxinputcells) {
                    game_ready = true;
                    EnableControls ();
                } else {
                    game_ready = false;
                    DisableControls ();
                }
            }
        }

        private int CountActiveCells (int [,] cells) {
            int activecells = 0;

            for (int y = 0; y < Table.HEIGHT; y++)
              for (int x = 0; x < Table.WIDTH; x++)
                if (cells[y, x] == 1) activecells++;

            return activecells;
        }

        public override void Tick(object sender,EventArgs eArgs)
        {
            if(Running) Iterate();
        }

        public override void RunButton(object sender, EventArgs e)
        {
            if (Running)
            {
                Running = false;
                mainwindow.btnRun.Text = "Run";
            }
            else
            {
                if (game_ready) {
                  Running = true;
                  game_started = true;
                  mainwindow.btnRun.Text = "Stop";
                }
            }
        }

        public override void StepButton (object sender, EventArgs e)
        {
            if (!Running && game_ready) {
                game_started = true;
                Iterate();
            }
        }

        public override void ClearButton (object sender, EventArgs e) {
            // reset game
            Running = false;
            game_ready = false;
            game_started = false;
            maxcells = 0;
            mainwindow.table.Clear ();
            mainwindow.btnRun.Text = "Run";
            DisableControls ();
        }
    }
}
