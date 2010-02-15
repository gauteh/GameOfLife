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
    	// variabel som viser om vi treng å teikne gridden på nytt
    	public bool repainted = false;
    	
        public MainWindow()
        {
            InitializeComponent();
        }
        
		protected override void OnPaint (PaintEventArgs e) {
			base.OnPaint (e);
			repainted = true;
		}
    }
}
