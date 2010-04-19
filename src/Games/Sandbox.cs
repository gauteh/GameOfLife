using System;
using System.Windows.Forms;

namespace GameOfLife
{
    /* Sandbox (av Gaute):
     *
     * Ein spelar / Conways reglar
     *
     * Eit test spel der du kan leike deg med å trykke inn celler slik du
     * ynskjer.
     *
     */

    public class Sandbox : Game
    {
        private bool explained = false; // har vist messagebox med instruksjona
        public ConwayRule rule;

        public Sandbox (MainWindow m) : base (m)
        {
            // Setter opp spel
            EnableControls ();

            rule = new ConwayRule ();
        }

        public void Explain () {
            explained = true;
            MessageBox.Show ("Dette spelet er for å kunne sjå korleis Conways regel fungerer, du kan fylle inn fritt med celler. Spelet vil derfor gå evig!", "Spel: Sandbox", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }

        public override int GetScore () {
            int i = Iterations - 2;
            if (i < 0) i = 0;
            return (maxcells * 100) + i * 10;
        }

        public override bool Finished () {
            // Spelet kan aldri bli ferdig, og vil derfor gå evig!
            return false;
        }

        public override void Iterate () {
            iterations++;
            rule.ApplyRule (mainwindow.table);

            // update score, brukar samme poengberekning som MaxCells
            int x = CountActiveCells (mainwindow.table.Cells);
            if (x > maxcells) maxcells = x;
        }

        public override void OnGridClick (object sender, Grid.GridEventArgs e)
        {
            // Det er lov å forandre celler heile tida.
            mainwindow.table.ToggleCell (e.Y, e.X);
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
                Running = true;
                mainwindow.btnRun.Text = "Stop";
            }
        }

        public override void StepButton (object sender, EventArgs e)
        {
            if (!Running) {
                Iterate();
            }
        }

        public override void ClearButton (object sender, EventArgs e) {
            // reset game
            Running = false;

            maxcells = 0;
            iterations = 0;

            mainwindow.table.Clear ();
            mainwindow.btnRun.Text = "Run";
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
