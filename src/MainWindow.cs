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

        // Spel i gang
        private bool running = false;

        // Timer
        private Timer clock;

        public MainWindow()
        {
            InitializeComponent();

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
            clock.Interval = 300;
            clock.Start();    
            clock.Tick += new EventHandler(clock_Tick);
          

            // Koblar den lokale funksjonen onGridClick til gridClickEventen, den kan fråkoblast
            // og andre funksjonar kan og koblast på på eit seinare tidspunkt
            grid.gridClickEvent += new Grid.gridClickHandler (OnGridClick);

            // Tooltips
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.btnRun, "Starter og stopper");

            // Setter opp eit nytt spel av typen 'MaxCells'
            Game = new MaxCells (this);
           
        }

        public void clock_Tick(object sender,EventArgs eArgs)
        {
            if(Running) {
                table.RuleIteration();

            }
        }
            
        public void OnTableChanged () {
            // Invalider forma slik at grid blir teikna på nytt
            this.Invalidate ();
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            // Køyr regelen ein iterasjon
            table.RuleIteration();
        }

        private void btnClear_click(object sender, EventArgs e)
        {
            table.Clear();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            if (Running == true)
            {
                Running = false;
                this.btnRun.Text = "Run";
            }
            else
            {
                Running = true;
                this.btnRun.Text = "Stop";
            }
        }

        private void OnGridClick (object sender, Grid.GridEventArgs e) {
            if (!Running) table.ToggleCell (e.Y, e.X);
        }

        private void SpeedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tenke å ordne slik at vi fikk variere farten 
        }

        public bool Running
        {
            get { return running; }
            set { running = value; }
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4: