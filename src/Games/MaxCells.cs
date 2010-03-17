
using System;

namespace GameOfLife
{


    public class MaxCells : Game
    {
        public MaxCells (MainWindow m) : base (m)
        {
        }

        public override int GetScore (Table table) {
            return 0;
        }

        public override bool CheckFinished (Table table) {
             return false;
        }

        public override void Iterate () {
            if (!CheckFinished ()) {
                mainwindow.table.RuleIteration ();
            }
        }
    }
}
