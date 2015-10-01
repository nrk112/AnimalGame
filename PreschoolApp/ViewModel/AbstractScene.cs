using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreschoolApp.ViewModel
{
    abstract class AbstractScene : ViewModelBase
    {
        public AbstractScene(Form parentForm) : base(parentForm)
        {
            ParentForm.SizeChanged += new EventHandler(OnLoad);
            OnLoad(null, null);
        }

        protected virtual void OnLoad(Object sender, EventArgs e)
        {
            AnimalSoundLabelLocation = CalculateAnimalSoundLabelLocation();
            HitboxRectangle = CalculateHitboxRectangle();
            LevelLabelLocation = CalculateLevelLabelLocation();
            MonkeyHeadLocation = CalculateMonkeyHeadLocation();
            ScoreLabelLocation = CalculateScoreLabelLocation();
            WhoSaysLabelLocation = CalculateWhoSaysLabelLocation();
            OnPropertyChanged();
        }

        /// <summary>
        /// Calculates the center point of the current window.
        /// </summary>
        /// <returns>The center point</returns>
        protected virtual Point CalculateScreenCenterPoint()
        {
            Point point = new Point();
            point.X = ParentForm.Width / 2;
            point.Y = ParentForm.Height / 2;
            return point;
        }

        protected virtual Rectangle CalculateHitboxRectangle()
        {
            //Magic numbers are just ratio divisors to get the best placement.
            int hitboxWidth = ParentForm.Width / 5;
            int hitboxHeight = ParentForm.Height / 5;
            Size hitboxSize = new Size(hitboxWidth, hitboxHeight);

            int x = (ParentForm.Width / 2) - (hitboxWidth / 2);
            int y = ParentForm.Height / 18;
            Point hitboxLocation = new Point(x, y);

            return new Rectangle(hitboxLocation, hitboxSize);
        }
        protected virtual Point CalculateAnimalSoundLabelLocation()
        {
            return CalculateScreenCenterPoint();
        }
        protected virtual Point CalculateLevelLabelLocation()
        {
            Point location = new Point();
            location.X = ParentForm.Width - 125;
            location.Y = 30;
            return location;
        }
        protected virtual Point CalculateMonkeyHeadLocation()
        {
            return new Point(125, 150);
        }
        protected virtual Point CalculateScoreLabelLocation()
        {
            return new Point(125, 30);
        }
        protected virtual Point CalculateWhoSaysLabelLocation()
        {
            Point point = CalculateScreenCenterPoint();
            point.Y -= 60;
            return point;
        }
        public abstract void UpdateAnimalLocations(bool isReversed, List<Animal> animals);

        #region Properties
        protected Point animalSoundLabelLocation;
        public virtual Point AnimalSoundLabelLocation
        {
            get
            {
                return animalSoundLabelLocation;
            }
            set
            {
                animalSoundLabelLocation = value;
            }
        }

        public abstract Bitmap BackgroundImage
        {
            get;
        }

        protected Rectangle hitboxRectangle;
        public virtual Rectangle HitboxRectangle
        {
            get
            {
                return hitboxRectangle;
            }
            set
            {
                hitboxRectangle = value;
            }
        }

        protected Point levelLabelLocation;
        public virtual Point LevelLabelLocation
        {
            get
            {
                return levelLabelLocation;
            }
            set
            {
                levelLabelLocation = value;
            }
        }

        protected Point monkeyHeadLocation;
        public virtual Point MonkeyHeadLocation
        {
            get
            {
                return monkeyHeadLocation;
            }
            set
            {
                monkeyHeadLocation = value;
            }
        }

        protected Point scoreLabelLocation;
        public virtual Point ScoreLabelLocation
        {
            get
            {
                return scoreLabelLocation;
            }
            set
            {
                scoreLabelLocation = value;
            }
        }

        public abstract string SoundTrackFilename
        {
            get;
        }

        protected Point whoSaysLabelLocation;
        public virtual Point WhoSaysLabelLocation
        {
            get
            {
                return whoSaysLabelLocation;
            }
            set
            {
                whoSaysLabelLocation = value;
            }
        }
        #endregion
    }
}
