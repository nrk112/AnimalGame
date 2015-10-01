using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PreschoolApp
{
    class Animal : Panel
    {
        public Animal(int x = 300, int y = 200)
        {
            this.Height = y;
            this.Width = x;
        }

        private string name;

        public string AnimalName
        {
            get { return name; }
            set { name = value; }
        }

        private Image image;

        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                BackgroundImage = value;
            }
        }

        private UnmanagedMemoryStream sound;

        public UnmanagedMemoryStream Sound
        {
            get { return sound; }
            set { sound = value; }
        }

        private string says;

        public string Says
        {
            get { return says; }
            set { says = value; }
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
        }
    }
}
