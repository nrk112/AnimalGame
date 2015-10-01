using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreschoolApp.Interfaces
{
    interface IScene
    {
        string SoundTrackFilename { get; }

        List<Point> PointsOnPath { get; }

        Rectangle HitboxRectangle { get; }

        Point ScoreLabelLocation { get; }

        Point LevelLabelLocation { get; }

        Point WhoSaysLabelLocation { get; }
        
        Point AnimalSoundLabelLocation { get; }
        
        Point MonkeyHeadLocation { get; }

        Bitmap BackgroundImage { get; }
        

    }
}
