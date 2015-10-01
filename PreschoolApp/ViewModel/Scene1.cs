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
    class Scene1 : AbstractScene
    {
        int radius;
        int angle = 0;
        Point currentLocation;
        Point rotationOrigin;

        public Scene1(Form parentForm) : base(parentForm)
        {
            radius = CalculateRadius();
            rotationOrigin = CalculateRotationOrigin();
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
                return "scene1music.mp3";
            }
        }

        public override Bitmap BackgroundImage
        {
            get
            {
                return Resources.spring_background;
            }
        }
    }
}
