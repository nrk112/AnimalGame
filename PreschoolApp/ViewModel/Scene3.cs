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
    class Scene3 : AbstractScene
    {
        int radius;
        int angle = 0;
        Point currentLocation;
        Point rotationOrigin;
        Timer reverseTimer;
        Timer reverseBackTimer;

        public Scene3(Form1 parentForm) : base(parentForm)
        {
            radius = CalculateRadius();
            rotationOrigin = CalculateRotationOrigin();

            parentForm.SceneChanged += new ChangedEventHandler(OnSceneChanged);

            reverseTimer = new Timer();
            reverseTimer.Interval = 3000;
            reverseTimer.Tick += new EventHandler(ReverseTimer_Tick);

            reverseBackTimer = new Timer();
            reverseBackTimer.Interval = 500;
            reverseBackTimer.Tick += new EventHandler(ReverseBackTimer_Tick);
        }

        protected override Point CalculateAnimalSoundLabelLocation()
        {
            Point point = new Point();
            point.Y = ParentForm.Height - (ParentForm.Height / 3);
            point.X = ParentForm.Width / 2;
            return point;
        }

        protected override Point CalculateWhoSaysLabelLocation()
        {
            Point point = new Point();
            point.Y = ParentForm.Height - (ParentForm.Height / 3) + - 60;
            point.X = ParentForm.Width / 2;
            return point;
        }

        /// <summary>
        /// Calculates the radius of a circle that will fit in the current window.
        /// </summary>
        /// <param name="offset">The size in pixels that the radius will be reduced by.</param>
        /// <returns>The size of the radius in pixels.</returns>
        private int CalculateRadius(int offset = 200)
        {
            return ParentForm.Height - (ParentForm.Height / 7);
        }

        /// <summary>
        /// Gets a point along a circle of a specific radius.
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        /// <param name="angleInDegrees">The angle of a segment where the desired point will intersect.</param>
        /// <param name="origin">The cente location of the circle.</param>
        /// <returns>The calculated point.</returns>
        private Point PointOnCircle(int radius, int angleInDegrees, Point origin)
        {
            int x = (int)((radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.X);
            int y = (int)((radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.Y);
            return new Point(x, y);
        }

        /// <summary>
        /// Calculates the origin of the circular path
        /// </summary>
        /// <returns>The origin</returns>
        private Point CalculateRotationOrigin()
        {
            Point point = CalculateScreenCenterPoint();
            point.Y = ParentForm.Height;
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

        public override void UpdateAnimalLocations(bool isReversed, List<Animal> animals)
        {
            radius = CalculateRadius();
            if (isReversed)
                angle -= 1;
            else
                angle += 1;

            if (angle % 360 == 0)
                angle = 0;

            int angleOffset = 360 / animals.Count;
            foreach (Animal animal in animals)
            {
                angle += angleOffset;
                currentLocation = PointOnCircle(radius, angle, rotationOrigin);
                currentLocation = GetControlOffsetPoint(currentLocation, animal);
                animal.Location = currentLocation;
            }
        }

        public override string SoundTrackFilename
        {
            get
            {
                return "scene3music.mp3";
            }
        }

        public override Bitmap BackgroundImage
        {
            get
            {
                return Resources.palm_tree_at_sunset_Background;
            }
        }

        private void ReverseTimer_Tick(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;
            form.isReversed = !form.isReversed;
            reverseBackTimer.Start();
        }

        private void ReverseBackTimer_Tick(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;
            form.isReversed = !form.isReversed;
            reverseBackTimer.Stop();
        }

        private void OnSceneChanged(object sender, EventArgs e)
        {
            if (sender.Equals(this))
            {
                reverseTimer.Start();
            }
            else
            {
                reverseBackTimer.Stop();
                reverseTimer.Stop();
            }
        }
    }
}
