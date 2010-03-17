using System;

namespace GameOfLife
{

    public abstract class Game
    {
        public MainWindow mainwindow;

        public Game (MainWindow m) {
             mainwindow = m;
        }

        public abstract bool CheckFinished (Table table);
        public abstract int GetScore (Table table);
        public abstract void Iterate ();
    }
}
