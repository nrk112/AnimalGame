using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreschoolApp.ViewModel
{
    class Form1ViewModel : ViewModelBase
    {
        Random rand = new Random();

        public Form1ViewModel(Form parentForm) : base(parentForm)
        {
            Animals = InitializeAnimals();
            AngleOffset = GetCalculatedAngleOffset();

        }

        private List<Animal> animals;
        public List<Animal> Animals
        {
            get
            {
                if (animals == null)
                {
                    animals = InitializeAnimals();
                    return animals;
                }
                return animals;
            }
            private set
            {
                this.animals = value;
            }
        }

        public int AngleOffset { get; private set; }

        /// <summary>
        /// Add any animals you would like in the rotation here.
        /// </summary>
        private List<Animal> InitializeAnimals()
        {
            Form1 form = (Form1)ParentForm;

            List<Animal> animals = new List<Animal>();
            Animal cat = new Animal();
            Animal dog = new Animal();
            Animal rooster = new Animal();
            Animal cow = new Animal();
            Animal monkey = new Animal();
            Animal lion = new Animal();

            cat.BackgroundImage = Properties.Resources.Cat1;
            cat.BackgroundImageLayout = ImageLayout.Stretch;
            cat.AnimalName = "Cat";
            cat.Says = "Meow!";
            cat.Sound = Properties.Resources.CatSound2;
            cat.Name = "catPanel";
            cat.Cursor = Cursors.Hand;
            cat.Click += new EventHandler(form.OnAnimalClick);
            animals.Add(cat);

            dog.BackgroundImage = Properties.Resources.Dog1;
            dog.BackgroundImageLayout = ImageLayout.Stretch;
            dog.AnimalName = "Dog";
            dog.Says = "Woof!";
            dog.Sound = Properties.Resources.DogSound;
            dog.Name = "dogPanel";
            dog.Cursor = Cursors.Hand;
            dog.Click += new EventHandler(form.OnAnimalClick);
            animals.Add(dog);

            cow.BackgroundImage = Properties.Resources.Cow1;
            cow.BackgroundImageLayout = ImageLayout.Stretch;
            cow.AnimalName = "Cow";
            cow.Says = "MOOOOOOOO!";
            cow.Sound = Properties.Resources.CowSound;
            cow.Name = "cowPanel";
            cow.Cursor = Cursors.Hand;
            cow.Click += new EventHandler(form.OnAnimalClick);
            animals.Add(cow);

            rooster.BackgroundImage = Properties.Resources.Rooster2;
            rooster.BackgroundImageLayout = ImageLayout.Stretch;
            rooster.AnimalName = "Rooster";
            rooster.Says = "Cockadoodle Doooo!";
            rooster.Sound = Properties.Resources.RoosterSound;
            rooster.Name = "roosterPanel";
            rooster.Cursor = Cursors.Hand;
            rooster.Click += new EventHandler(form.OnAnimalClick);
            animals.Add(rooster);

            lion.BackgroundImage = Properties.Resources.Lion1;
            lion.BackgroundImageLayout = ImageLayout.Stretch;
            lion.AnimalName = "Lion";
            lion.Says = "ROOOOOAR!";
            lion.Sound = Properties.Resources.LionSound;
            lion.Name = "lionPanel";
            lion.Cursor = Cursors.Hand;
            lion.Click += new EventHandler(form.OnAnimalClick);
            animals.Add(lion);

            monkey.BackgroundImage = Properties.Resources.Monkey1;
            monkey.BackgroundImageLayout = ImageLayout.Stretch;
            monkey.AnimalName = "Monkey";
            monkey.Says = "OoOoAhAh! AAAH AAAH!";
            monkey.Sound = Properties.Resources.MonkeySound;
            monkey.Name = "monkeyPanel";
            monkey.Cursor = Cursors.Hand;
            monkey.Click += new EventHandler(form.OnAnimalClick);
            animals.Add(monkey);

            return animals;
        }

        /// <summary>
        /// Returns a random animal from the list.
        /// </summary>
        public Animal RandomAnimal
        {
            get { return Animals.ElementAt(rand.Next(0, Animals.Count)); }
        }

        /// <summary>
        /// Calculates the degrees of spacing between each animal image on the circular path.
        /// </summary>
        /// <returns>the amount of degrees</returns>
        private int GetCalculatedAngleOffset()
        {
            if (Animals.Count != 0)
            {
                int degreesInCircle = 360;
                return degreesInCircle / Animals.Count;
            }
            return 0;
        }

    }
}
