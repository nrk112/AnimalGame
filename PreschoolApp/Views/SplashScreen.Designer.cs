namespace PreschoolApp.Views
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.timeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.fadeTimer = new System.Windows.Forms.Timer(this.components);
            this.fadeOutTimer = new System.Windows.Forms.Timer(this.components);
            this.copywriteLabel = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeoutTimer
            // 
            this.timeoutTimer.Interval = 4000;
            this.timeoutTimer.Tick += new System.EventHandler(this.timeoutTimer_Tick);
            // 
            // fadeTimer
            // 
            this.fadeTimer.Interval = 50;
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
            // 
            // fadeOutTimer
            // 
            this.fadeOutTimer.Interval = 50;
            this.fadeOutTimer.Tick += new System.EventHandler(this.fadeOutTimer_Tick);
            // 
            // copywriteLabel
            // 
            this.copywriteLabel.AutoSize = true;
            this.copywriteLabel.BackColor = System.Drawing.Color.Transparent;
            this.copywriteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copywriteLabel.ForeColor = System.Drawing.Color.Black;
            this.copywriteLabel.Location = new System.Drawing.Point(361, 712);
            this.copywriteLabel.Name = "copywriteLabel";
            this.copywriteLabel.Size = new System.Drawing.Size(903, 25);
            this.copywriteLabel.TabIndex = 0;
            this.copywriteLabel.Text = "All sounds and images are licensed under the public domain unless otherwise noted" +
    ".";
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.BackColor = System.Drawing.Color.Transparent;
            this.classLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLabel.Location = new System.Drawing.Point(13, 13);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(299, 20);
            this.classLabel.TabIndex = 1;
            this.classLabel.Text = "Nicholas Kehagias - COP4367 - Fall 2015";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PreschoolApp.Properties.Resources.GlyphicMonkeyGamesLogo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1470, 926);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.copywriteLabel);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timeoutTimer;
        private System.Windows.Forms.Timer fadeTimer;
        private System.Windows.Forms.Timer fadeOutTimer;
        private System.Windows.Forms.Label copywriteLabel;
        private System.Windows.Forms.Label classLabel;
    }
}