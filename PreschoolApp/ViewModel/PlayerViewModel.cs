using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreschoolApp.ViewModel
{
    class PlayerViewModel : ViewModelBase
    {
        public PlayerViewModel(Form form) : base(form)
        {
            this.Name = "Player 1";
            this.score = 0;
            this.level = 1;
            this.LevelUpCount = 5;
        }

        private int score;

        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged();

                if (score % LevelUpCount == 0)
                {
                    this.Level += 1;
                }
            }
        }

        private int level;

        public int Level
        {
            get { return level; }
            protected set
            {
                level = value;
                OnPropertyChanged();
            }
        }

        public string Name { get; set; }

        public int LevelUpCount { get; set; }

    }
}
