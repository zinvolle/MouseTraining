namespace MoleGame.Models
{
    public class SquareModel
    {
        private bool isShown;
        public int Id { get; set; }
        public string Style { get; set; }

        private string difficulty { get; set; }
        public bool IsShown
        {
            get => isShown;
            set
            {
                isShown = value;
                if (isShown)
                {
                    Style = "mole";
                }
                else
                {
                    Style = "";
                }
            }
        }

        public string Difficulty
        {
            get => difficulty;
            set => difficulty = value+"Square";
        }
    }
}
