using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using PreschoolApp.Properties;

namespace PreschoolApp.ViewModel
{
    class Scene2 : AbstractScene
    {
        Point currentLocation;

        public Scene2(Form1 parentForm) : base(parentForm)
        {
            parentForm.SceneChanged += new ChangedEventHandler(OnSceneChaged);
            amplitude = ParentForm.Height / 11;
            y = ParentForm.Height / 7;
        }

        protected override Rectangle CalculateHitboxRectangle()
        {
            //Magic numbers are just ratio divisors to get the best placement.
            int hitboxWidth = ParentForm.Width / 5;
            int hitboxHeight = ParentForm.Height / 3;
            Size hitboxSize = new Size(hitboxWidth, hitboxHeight);

            int x = (ParentForm.Width / 2) - (hitboxWidth / 2);
            int y = ParentForm.Height / 18;
            Point hitboxLocation = new Point(x, y);

            return new Rectangle(hitboxLocation, hitboxSize);
        }

        protected override Point CalculateAnimalSoundLabelLocation()
        {
            Point point = new Point();
            point.Y = ParentForm.Height - (ParentForm.Height / 5);
            point.X = ParentForm.Width / 5;
            return point;
        }

        protected override Point CalculateWhoSaysLabelLocation()
        {
            Point point = new Point();
            point.Y = ParentForm.Height - (ParentForm.Height / 5) - 60;
            point.X = ParentForm.Width / 5;
            return point;
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

        int x = 6;
        //y = normalized centerline of sine wave
        int y;
        int amplitude;
        double period = 1;
        //TODO: runOnce should be reset on screen resize.  Fullscreen app anyways, probably not needed.
        bool runOnce = true;
        public override void UpdateAnimalLocations(bool isReversed, List<Animal> animals)
        {
            int pathLength = ParentForm.Width * 2;
            int offset = pathLength / animals.Count;
            int leftEnd = -(ParentForm.Width / 2);
            int rightEnd = ParentForm.Width + (ParentForm.Width / 2);

            if (runOnce)
            {
                int startX = leftEnd;
                runOnce = false;
                foreach (Animal animal in animals)
                {
                    currentLocation = new Point(startX, y);
                    currentLocation = GetControlOffsetPoint(currentLocation, animal);
                    animal.Location = currentLocation;
                    startX += offset;
                }
            }

            foreach (Animal animal in animals)
            {
                currentLocation = animal.Location;

                if (isReversed)
                {
                    currentLocation.X -= x;
                    if (currentLocation.X < leftEnd)
                        currentLocation.X = rightEnd;
                }
                else
                {
                    currentLocation.X += x;
                    if (currentLocation.X > rightEnd)
                        currentLocation.X = leftEnd;
                }
                currentLocation.Y = YPathFromSine(currentLocation.X) + y;
                animal.Location = currentLocation;
            }
        }

        private void OnSceneChaged(object source, EventArgs e)
        {
            runOnce = true;
        }

        /// <summary>
        /// Calculates a useable Y value for a sinewave path used for the animals.
        /// </summary>
        /// <param name="x">Distance along the path.</param>
        /// <returns></returns>
        private int YPathFromSine(double angle)
        {
            //Normalize x
            //angle = Math.Abs(angle % 360);
            angle = angle % 360;

            //Convert to radians
            angle = angle * Math.PI / 180;

            //Adjust period
            angle = angle * period;

            //calculate y 
            return (int)(amplitude * (Math.Sin(angle)));
        }

        public override string SoundTrackFilename
        {
            get
            {
                return "scene2music.mp3";
            }
        }

        public override Bitmap BackgroundImage
        {
            get
            {
                return Resources.underwater_background;
            }
        }

    }
}
