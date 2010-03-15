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
            this.btnStep = new System.Windows.Forms.Button();
            this.groupControllers.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControllers
            // 
            this.groupControllers.Controls.Add(this.btnStep);
            this.groupControllers.Location = new System.Drawing.Point(1, 315);
            this.groupControllers.Name = "groupControllers";
            this.groupControllers.Size = new System.Drawing.Size(690, 106);
            this.groupControllers.TabIndex = 0;
            this.groupControllers.TabStop = false;
            this.groupControllers.Text = "Kontrollera";
            this.groupControllers.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(597, 19);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(84, 32);
            this.btnStep.TabIndex = 0;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupControllers;
        private System.Windows.Forms.Button btnStep;
    }
}