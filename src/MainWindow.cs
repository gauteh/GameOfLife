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
        public Rule rule;
        

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

            // Timer
            
            Timer clock;
            clock = new Timer();
            clock.Interval = 300;
            clock.Start();
            clock.Tick += new EventHandler(clock_Tick);
                        

        }

        
        
        public void clock_Tick(object sender,EventArgs eArgs)
        {
            if(table.RunCheck)
            table.RuleIteration();
        }
            
        public void OnTableChanged () {
            // Invalider forma slik at grid blir teikna på nytt
            this.Invalidate ();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            
            if (table.RunCheck == true)
                table.RunCheck = false;
            else
                table.RunCheck = true;
        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
