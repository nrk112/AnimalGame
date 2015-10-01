using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace PreschoolApp.Helpers
{
    class MusicPlayer
    {
        private Form parentForm;
        private System.Windows.Media.MediaPlayer mediaPlayer1;
        private System.Windows.Media.MediaPlayer mediaPlayer2;
        private int activePlayer = 0;
        private int interval = 150;
        float volumeLimit = 0.15F;
        float fadeAmount = 0.02F;
        Timer timer;

        public MusicPlayer(Form parentForm)
        {
            this.parentForm = parentForm;

            mediaPlayer1 = new System.Windows.Media.MediaPlayer();
            mediaPlayer2 = new System.Windows.Media.MediaPlayer();
            mediaPlayer1.Volume = 0.0;
            mediaPlayer2.Volume = 0.0;

            

            timer = new Timer();
            timer.Interval = interval;
            timer.Enabled = false;
            timer.Tick += new EventHandler(OnTimerTick);

        }

        /// <summary>
        /// Chooses a player to use and plays the file.
        /// </summary>
        /// <param name="filename">The filename of the MP3 in the .\Music directory.</param>
        public void PlayMP3(string filename)
        {
            string fullFileName = System.IO.Directory.GetCurrentDirectory() + "\\" + filename;
            Uri uriFile = new Uri(fullFileName);

            timer.Enabled = true;

            if (activePlayer == 1)
            {
                mediaPlayer2.Open(uriFile);
                mediaPlayer2.Play();
            }
            else
            {
                mediaPlayer1.Open(uriFile);
                mediaPlayer1.Play();
            }

        }

        /// <summary>
        /// Timer is used to fade music between tracks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTimerTick(Object sender, EventArgs e)
        {
            if (activePlayer == 1)
            {
                mediaPlayer1.Volume -= fadeAmount;
                mediaPlayer2.Volume += fadeAmount;
                if(mediaPlayer2.Volume >= volumeLimit)
                {
                    timer.Enabled = false;
                    activePlayer = 2;
                    mediaPlayer1.Stop();
                }
            }
            else
            {
                mediaPlayer1.Volume += fadeAmount;
                mediaPlayer2.Volume -= fadeAmount;
                if (mediaPlayer1.Volume >= volumeLimit)
                {
                    timer.Enabled = false;
                    activePlayer = 1;
                    mediaPlayer2.Stop();
                }
            }
        }
    }
}
