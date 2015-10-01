using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PreschoolApp.ViewModel;

namespace PreschoolApp
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public partial class Form1 : Form
    {
        //Scene Objects
        int currentSceneIndex;
        AbstractScene currentScene;
        List<AbstractScene> scenes;
        public event ChangedEventHandler SceneChanged;

        //Sound Objects
        System.Media.SoundPlayer soundPlayer;
        Helpers.MusicPlayer musicPlayer;

        //Animation Objects
        public bool isReversed
        {
            get; set;
        }

        //ViewObjects
        private Animal currentAnimal;
        PlayerViewModel player;
        Form1ViewModel form1ViewModel;
        Form faderForm;

        #region View Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            isReversed = false;
            InitializeComponent();
            form1ViewModel = new Form1ViewModel(this);

            faderForm = new Form();
            faderForm.Enabled = false;
            faderForm.Visible = false;
            faderForm.Opacity = 0.0;
            faderForm.TopMost = true;
            faderForm.BackColor = Color.Black;
            faderForm.FormBorderStyle = FormBorderStyle.None;
            faderForm.StartPosition = FormStartPosition.CenterScreen;
            faderForm.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// On load event handler. Runs after form is constructed.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Enabled = false;

            //Set up animals
            AddAnimals();
            SetRandomAnimal();

            //Set up audio players
            musicPlayer = new Helpers.MusicPlayer(this);
            soundPlayer = new System.Media.SoundPlayer();

            //Set up the player
            player = new PlayerViewModel(this);
            player.PropertyChanged += new PropertyChangedEventHandler(OnPlayerPropertyChanged);

            //Set up the scenes
            scenes = new List<AbstractScene>();
            scenes.Add(new Scene1(this));
            scenes.Add(new Scene2(this));
            scenes.Add(new Scene3(this));
            currentSceneIndex = 0;
            currentScene = scenes[currentSceneIndex];
            InitializeScene(currentScene);

            PlaySound(soundPlayer, currentAnimal.Sound);

            this.Enabled = true;
        }

        /// <summary>
        /// Creates the target hit box at the top of the screen.
        /// </summary>
        /// <param name="thickness">The thickness of the brush.</param>
        private void DrawHitbox(int thickness = 10)
        {
            if (currentScene == null)
                return;

            using (Graphics g = this.CreateGraphics())
            {
                Pen pen = new Pen(Color.Red, thickness);
                g.DrawRectangle(pen, currentScene.HitboxRectangle);
                pen.Dispose();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            InitializeScene(currentScene);

            if (form1ViewModel.Animals != null)
            {
                foreach (Animal animal in form1ViewModel.Animals)
                {
                    animal.Height = (this.Height / 7);
                    animal.Width = (this.Width / 7);
                }
            }

            if (currentAnimal != null)
                soundLabel.Text = currentAnimal.Says;

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawHitbox();
        }

        /// <summary>
        /// Adds all the animals(panels) to the list of view controls.
        /// </summary>
        private void AddAnimals()
        {
            foreach (Animal animal in form1ViewModel.Animals)
            {
                Controls.Add(animal);
            }
            currentAnimal = form1ViewModel.Animals[1];
        }

        /// <summary>
        /// Event Handler will exit the program when this window closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Play the sound of an animal that has been clicked
        /// </summary>
        /// <param name="sender">Animal object</param>
        /// <param name="e">none</param>
        public void OnAnimalClick(object sender, EventArgs e)
        {
            Animal thisAnimal = (Animal)sender;
            PlaySound(soundPlayer, thisAnimal.Sound);
        }

        #endregion

        #region Game Logic

        /// <summary>
        /// Event handler for the PropertyChanged event from Player objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPlayerPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Score")
            {
                scoreLabel.Text = "Score: " + player.Score;
                scoreLabel.Invalidate();
            }
            else if (e.PropertyName == "Level")
            {
                this.Enabled = false;
                faderForm.Visible = true;
                fadeInTimer.Start();

                //Timer will finish loading scene when fade is complete
            }
        }

        private void ContinueSceneChange()
        {
            currentScene = GetNextScene();
            InitializeScene(currentScene);
            SceneChanged(currentScene, null);
            this.Enabled = true;
            fadeOutTimer.Start();
        }

        /// <summary>
        /// Sets the current scene to the next one in the scenes list or starts from the beginning if there is no more.
        /// </summary>
        private AbstractScene GetNextScene()
        {
            if (currentSceneIndex < (scenes.Count - 1))
                currentSceneIndex += 1;
            else
                currentSceneIndex = 0;

            return scenes[currentSceneIndex];
        }

        /// <summary>
        /// Sets the current target animal to a new random one.
        /// </summary>
        private void SetRandomAnimal()
        {
            Animal newAnimal;
            do
            {
                newAnimal = form1ViewModel.RandomAnimal;
            } while (currentAnimal.Equals(newAnimal));
            currentAnimal = newAnimal;
            soundLabel.Text = currentAnimal.Says;
            if (currentScene != null)
            {
                soundLabel.Location = GetControlOffsetPoint(currentScene.AnimalSoundLabelLocation, soundLabel);
            }

        }

        /// <summary>
        /// Checks if the current animal is in the hitbox. 
        /// </summary>
        private void AttemptToScore()
        {
            if (currentAnimal.Location.Y > currentScene.HitboxRectangle.Y + currentScene.HitboxRectangle.Height)
            {
                PlaySound(soundPlayer, Properties.Resources.wrong_action);
                return;
            }

            int hitLeft = currentScene.HitboxRectangle.X;
            int hitRight = currentScene.HitboxRectangle.X + currentScene.HitboxRectangle.Width;
            int animalLeft = currentAnimal.Location.X;
            int animalRight = currentAnimal.Location.X + currentAnimal.Width;

            if (animalLeft > hitLeft && animalRight < hitRight)
            {
                player.Score += 1;
                SetRandomAnimal();
                if (!(player.Score % player.LevelUpCount == 0))
                    PlaySound(soundPlayer, currentAnimal.Sound);
            }
            else
            {
                PlaySound(soundPlayer, Properties.Resources.wrong_action);
            }
        }

        #endregion

        #region Audio Functions

        /// <summary>
        /// Play single sounds
        /// </summary>
        /// <param name="soundPlayer">The soundPlayer used to play the sound.</param>
        /// <param name="stream">The sound stream to play.</param>
        private void PlaySound(System.Media.SoundPlayer soundPlayer, System.IO.Stream stream)
        {
            if (stream == null)
                return;

            soundPlayer.Stream = stream;
            soundPlayer.Stream.Position = 0;
            soundPlayer.Play();
        }
        #endregion

        #region Scene Setup

        /// <summary>
        /// Sets up scene object locations and data.
        /// </summary>
        private void InitializeScene(AbstractScene scene)
        {
            if (scene == null)
                return;

            scoreLabel.Location = GetControlOffsetPoint(scene.ScoreLabelLocation, scoreLabel);
            levelLabel.Location = GetControlOffsetPoint(scene.LevelLabelLocation, levelLabel);
            whoSaysLabel.Location = GetControlOffsetPoint(scene.WhoSaysLabelLocation, whoSaysLabel);
            soundLabel.Location = GetControlOffsetPoint(scene.AnimalSoundLabelLocation, soundLabel);

            musicPlayer.PlayMP3(scene.SoundTrackFilename);

            this.BackgroundImage = currentScene.BackgroundImage;

            levelLabel.Text = "Level: " + player.Level;
            levelLabel.Invalidate();

            scoreLabel.Text = "Score: " + player.Score;
            scoreLabel.Invalidate();
        }

        /// <summary>
        /// Adjusts the objects anchor point to be at the center of the object instead of the top left. 
        /// </summary>
        /// <param name="origin">The point where the center of the control should be anchored to.</param>
        /// <param name="control">The control to calculate the offsets from.</param>
        /// <returns>An offset point which can be used to anchor the control at the center.</returns>
        private Point GetControlOffsetPoint(Point origin, Control control)
        {
            Point location = new Point();
            location.X = origin.X - (control.Width / 2);
            location.Y = origin.Y - (control.Height / 2);
            return location;
        }

        #endregion

        #region Keyboard Input

        /// <summary>
        /// Invokes different functions depending on which key is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Make all keypresses uppercase
            char key = char.ToUpper(e.KeyChar);

            //reverse direction of rotation
            if (key == (char)Keys.R)
            {
                isReversed = !isReversed;
            }
            //score key
            else if (key == (char)Keys.Space)
            {
                AttemptToScore();
            }
        }

        /// <summary>
        /// Handles special keypresses
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Set rotation to counterclockwise
            if (keyData == Keys.Left)
            {
                isReversed = true;
                return true;
            }
            //Set rotation to clockwise
            else if (keyData == Keys.Right)
            {
                isReversed = false;
                return true;
            }
            else if (keyData == Keys.Up)
            {
                IncreaseFramerate();
                return true;
            }
            else if (keyData == Keys.Down)
            {
                DecreaseFramerate();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                framerateTimer.Stop();
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Application.Exit();
                framerateTimer.Start();
            }
            else if (keyData == Keys.Enter)
            {
                PlaySound(soundPlayer, currentAnimal.Sound);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Animation
        /// <summary>
        /// Timer event handler acts as the framerate for the animations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            currentScene.UpdateAnimalLocations(isReversed, form1ViewModel.Animals);
        }

        /// <summary>
        /// Decreases the interval of the timer which increases the speed of animation.
        /// </summary>
        /// <param name="modifierValue"></param>
        private void IncreaseFramerate(int modifierValue = 10)
        {
            if (framerateTimer.Interval >= 20)
            {
                framerateTimer.Interval -= modifierValue;
            }
        }

        /// <summary>
        /// Increases the interval of the timer which decreases the speed of animation.
        /// </summary>
        /// <param name="modifierValue"></param>
        private void DecreaseFramerate(int modifierValue = 10)
        {
            if (framerateTimer.Interval <= 150)
                framerateTimer.Interval += modifierValue;
        }

        private void fadeOutTimer_Tick(object sender, EventArgs e)
        {
            faderForm.Opacity -= 0.1;
            if (faderForm.Opacity == 0.0)
            {
                fadeOutTimer.Stop();
                faderForm.Visible = false;
                PlaySound(soundPlayer, currentAnimal.Sound);
            }

        }

        private void fadeInTimer_Tick(object sender, EventArgs e)
        {
            faderForm.Opacity += 0.1;
            if (faderForm.Opacity == 1.0)
            {
                fadeInTimer.Stop();
                ContinueSceneChange();
            }
        }
        #endregion
    }
}
