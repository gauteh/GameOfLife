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
        public Table table;
        public Grid grid;
        public Game game;

        // Timer
        public Timer clock;

        public MainWindow()
        {
            InitializeComponent();

            this.Text = "Game of Life";

            // Setter opp tabell
            Console.WriteLine ("Setter opp tabell..");
            table = new Table ();


            // Teiknar forma på nytt dersom tabellen blir forandra
            table.TableChangedEvent += new Table.TableChangedHandler (this.OnTableChanged);

            // Setter opp grid
            Console.WriteLine ("Setter opp grid..");
            grid = new Grid (this);

            // Teikn enkeltcelle dersom dei blir forandra i tabellen
            table.TableCellChangedEvent += new Table.TableCellChangedHandler (grid.DrawCell);

            // Teikn gridden når forma blir teikna
            this.Paint += new PaintEventHandler (grid.Draw);


            clock = new Timer();
            clock.Interval = 1000;
            clock.Start();
           
            
            
            // Tooltips
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.btnRun, "Starter og stopper");

            // Setter opp eit nytt spel av typen 'MaxCells'
            // game = new MaxCells (this);
            game = new Sandbox (this);
        }

        public void OnTableChanged () {
            // Invalider forma slik at grid blir teikna på nytt
            this.Invalidate ();
        }

        private void SpeedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("speedbox" + this.SpeedBox.SelectedIndex.ToString());
            if (this.SpeedBox.SelectedIndex == 0)
                clock.Interval = 1000;

            if (this.SpeedBox.SelectedIndex == 1)
                clock.Interval = 100;

            
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
