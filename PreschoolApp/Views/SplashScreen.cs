using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreschoolApp.Views
{
    public partial class SplashScreen : Form
    {
        bool firstRun = true;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            SetLabelLocations();
            fadeTimer.Start();
        }

        /// <summary>
        /// Fades in the splash screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            if (this.Opacity == 1.0)
            {
                timeoutTimer.Start();
                fadeTimer.Stop();
            }
        }

        /// <summary>
        /// Set the timeout period for the length of time the splashscreen is shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeoutTimer_Tick(object sender, EventArgs e)
        {
            if (firstRun)
            {
                firstRun = false;
                this.BackgroundImage = Properties.Resources.ControlsPic;
                this.copywriteLabel.Visible = false;
            }
            else
            {
                this.TopMost = true;
                timeoutTimer.Stop();
                Form1 mainWindow = new Form1();
                mainWindow.Show();
                fadeOutTimer.Start();
            }
        }

        /// <summary>
        /// Fades out the splash screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fadeOutTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0.0)
                fadeOutTimer.Stop();
        }



        /// <summary>
        /// Sets the locations of any labels on the splash screen.
        /// </summary>
        private void SetLabelLocations()
        {
            Point location = new Point();

            location.X = (this.Width / 2) - (copywriteLabel.Width / 2);
            location.Y = (this.Height - 100);

            copywriteLabel.Location = location;
        }


    }
}
