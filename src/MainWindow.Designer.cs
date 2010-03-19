namespace GameOfLife
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControllers = new System.Windows.Forms.GroupBox();
            this.labelScoreText = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.SpeedBox = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.groupControllers.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControllers
            // 
            this.groupControllers.Controls.Add(this.labelScoreText);
            this.groupControllers.Controls.Add(this.labelScore);
            this.groupControllers.Controls.Add(this.SpeedBox);
            this.groupControllers.Controls.Add(this.btnRun);
            this.groupControllers.Controls.Add(this.btnClear);
            this.groupControllers.Controls.Add(this.btnStep);
            this.groupControllers.Location = new System.Drawing.Point(1, 315);
            this.groupControllers.Name = "groupControllers";
            this.groupControllers.Size = new System.Drawing.Size(690, 106);
            this.groupControllers.TabIndex = 0;
            this.groupControllers.TabStop = false;
            this.groupControllers.Text = "Kontrollera";
            // 
            // labelScoreText
            // 
            this.labelScoreText.AutoSize = true;
            this.labelScoreText.Location = new System.Drawing.Point(532, 29);
            this.labelScoreText.Name = "labelScoreText";
            this.labelScoreText.Size = new System.Drawing.Size(38, 13);
            this.labelScoreText.TabIndex = 2;
            this.labelScoreText.Text = "Score:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(573, 29);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(35, 13);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Score";
            // 
            // SpeedBox
            // 
            this.SpeedBox.FormattingEnabled = true;
            this.SpeedBox.Items.AddRange(new object[] {
            "Speed 1",
            "Speed 2"});
            this.SpeedBox.Location = new System.Drawing.Point(334, 26);
            this.SpeedBox.Name = "SpeedBox";
            this.SpeedBox.Size = new System.Drawing.Size(121, 21);
            this.SpeedBox.TabIndex = 1;
            this.SpeedBox.SelectedIndexChanged += new System.EventHandler(this.SpeedBox_SelectedIndexChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(11, 19);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(84, 32);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(191, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(101, 19);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(84, 32);
            this.btnStep.TabIndex = 0;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 422);
            this.Controls.Add(this.groupControllers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.groupControllers.ResumeLayout(false);
            this.groupControllers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupControllers;
        public System.Windows.Forms.Button btnStep;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnRun;
        public System.Windows.Forms.ComboBox SpeedBox;
        public System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelScoreText;
    }
}
