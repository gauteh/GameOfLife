using System;
using System.Windows.Forms;

namespace GameOfLife
{
    /* MaxCells (av Gaute):
     *
     * Ein spelar / Conways reglar
     *
     * 1. Du får 15 celler (definert i 'private const int maxinputcells')
     *    som du må plassere ut.
     * 2. Velg 'Run'
     * 3. Spelet køyrer og du får poeng for:
     *    a.) det største antallet celler som finst på ein gang (x100)
     *    b.) antall iterasjoner                                (x10)
     *
     */

    public class MaxCells : Game
    {
        private bool game_ready; // klar til å startast
        private bool game_started; // har blitt starta
        private bool game_finished; // har blitt fullført
        private bool explained = false; // har vist messagebox med instruksjona

        private const int maxinputcells = 15;

        private int maxcells = 0; // maksimale nummer av celler som har
                                  // vore til stade samtidig

        private int[,] ppreviouscells;
        private int[,] previouscells;

        public ConwayRule rule;

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

            rule = new ConwayRule ();
        }

        public void Explain () {
            explained = true;
            MessageBox.Show ("Velg 15 celler, målet er oppnå mest mogleg celler på ein gang og lengst mogleg levetid", "Spel: MaxCells",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
         }

        public override int GetScore () {
            int i = Iterations - 2;
            if (i < 0) i = 0;
            return (maxcells * 100) + i * 10;
        }

        public override bool Finished () {
            if (!game_finished) {
                bool equal = true;

                int [,] cells = mainwindow.table.Cells;

                /* Testar om tabellen er den samme som den var for
                 * to iterasjonar sidan; alle loopar større enn det
                 * vil vi ikkje være i stand til å oppdage..
                 *
                 * TODO: Litt meir robust test? Om mogleg?
                 */

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
                if (previouscells != null) ppreviouscells = Table.CopyCells (previouscells);
                previouscells = Table.CopyCells (cells);
            }

            return game_finished;
        }

        public override void Iterate () {
            if (game_ready) {
                iterations++;
                rule.ApplyRule (mainwindow.table);

                // update score
                int x = CountActiveCells (mainwindow.table.Cells);
                if (x > maxcells) maxcells = x;

                if (Finished ()) {
                    Running = false;
                    mainwindow.btnRun.Enabled = false;
                    mainwindow.btnStep.Enabled = false;
                    MessageBox.Show ("Yey! Du er ferdig; scoren din er: " + GetScore().ToString () + "\n\nIterasjoner: " + Iterations.ToString () + "\nMax celler: " + maxcells.ToString (),
                                     "Ferdig!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public override void OnGridClick (object sender, Grid.GridEventArgs e) {
            // Kan kun fylle inn dersom spelet ikkje har blitt starta
            if (!game_started) {
                int [,] cells = mainwindow.table.Cells;

                if (cells[e.Y, e.X] == 1) {
                    mainwindow.table.ToggleCell (e.Y, e.X);
                } else {
                    if (CountActiveCells (cells) < maxinputcells)
                        mainwindow.table.ToggleCell (e.Y, e.X);
                }

                if (CountActiveCells (cells) >= maxinputcells)
                {
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
            if (!explained) Explain ();
            if (Running) Iterate();

            mainwindow.labelScore.Text = Convert.ToString(GetScore());

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
            game_finished = false;

            maxcells = 0;
            iterations = 0;

            mainwindow.table.Clear ();
            mainwindow.btnRun.Text = "Run";
            DisableControls ();
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
