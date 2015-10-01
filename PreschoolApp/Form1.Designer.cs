namespace PreschoolApp
{
    partial class Form1
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
            this.framerateTimer = new System.Windows.Forms.Timer(this.components);
            this.whoSaysLabel = new System.Windows.Forms.Label();
            this.soundLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.levelUpLabel = new System.Windows.Forms.Label();
            this.fadeInTimer = new System.Windows.Forms.Timer(this.components);
            this.fadeOutTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // framerateTimer
            // 
            this.framerateTimer.Enabled = true;
            this.framerateTimer.Interval = 50;
            this.framerateTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // whoSaysLabel
            // 
            this.whoSaysLabel.AutoSize = true;
            this.whoSaysLabel.BackColor = System.Drawing.Color.Transparent;
            this.whoSaysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whoSaysLabel.Location = new System.Drawing.Point(412, 417);
            this.whoSaysLabel.Name = "whoSaysLabel";
            this.whoSaysLabel.Size = new System.Drawing.Size(243, 55);
            this.whoSaysLabel.TabIndex = 2;
            this.whoSaysLabel.Text = "Who Says";
            // 
            // soundLabel
            // 
            this.soundLabel.AutoSize = true;
            this.soundLabel.BackColor = System.Drawing.Color.Transparent;
            this.soundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundLabel.Location = new System.Drawing.Point(426, 454);
            this.soundLabel.Name = "soundLabel";
            this.soundLabel.Size = new System.Drawing.Size(152, 55);
            this.soundLabel.TabIndex = 3;
            this.soundLabel.Text = "label2";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.scoreLabel.Location = new System.Drawing.Point(13, 13);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(197, 54);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Score: 0";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.levelLabel.Location = new System.Drawing.Point(810, 9);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(186, 54);
            this.levelLabel.TabIndex = 5;
            this.levelLabel.Text = "Level: 1";
            // 
            // levelUpLabel
            // 
            this.levelUpLabel.AutoSize = true;
            this.levelUpLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelUpLabel.Location = new System.Drawing.Point(19, 707);
            this.levelUpLabel.Name = "levelUpLabel";
            this.levelUpLabel.Size = new System.Drawing.Size(56, 13);
            this.levelUpLabel.TabIndex = 6;
            this.levelUpLabel.Text = "Level Up!!";
            this.levelUpLabel.Visible = false;
            // 
            // fadeInTimer
            // 
            this.fadeInTimer.Tick += new System.EventHandler(this.fadeInTimer_Tick);
            // 
            // fadeOutTimer
            // 
            this.fadeOutTimer.Tick += new System.EventHandler(this.fadeOutTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BackgroundImage = global::PreschoolApp.Properties.Resources.spring_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.levelUpLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.soundLabel);
            this.Controls.Add(this.whoSaysLabel);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Animal Game";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer framerateTimer;
        private System.Windows.Forms.Label whoSaysLabel;
        private System.Windows.Forms.Label soundLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label levelUpLabel;
        public System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Timer fadeInTimer;
        private System.Windows.Forms.Timer fadeOutTimer;
    }
}

