using MoleGame.Models;

namespace MoleGame.Pages
{
    public partial class HomeGame
    {
        int score = 0;
        int currentTime = 120;
        int hitPosition = 0;
        string message = "";
        int gameSpeed;
        bool gameIsRunning = false;
        private int numberOfSquares;
        string difficulty;
        public List<SquareModel> Squares { get; set; } = new List<SquareModel>();

        private readonly Dictionary<string, (int squareCount, int speed)> difficultySettings = new Dictionary<string, (int, int)>
        {
            {"easy", (150, 1000)},
            {"medium",(2250, 800)},
            {"hard", (9000, 500)}
        };

        public HomeGame()
        {
            SetDifficulty("easy");
        }

        public void SetDifficulty(string difficulty)
        {
            if (difficultySettings.TryGetValue(difficulty, out var settings))
            {
                numberOfSquares = settings.squareCount;
                gameSpeed = settings.speed;
                this.difficulty = difficulty;
                InitializeSquares(difficulty);
            }
            else
            {
                throw new ArgumentException("Invalid difficulty level");
            }
        }

        private void InitializeSquares(string difficulty)
        {
            Squares.Clear();
            for (int i = 0; i < numberOfSquares; i++)
            {
                Squares.Add(new SquareModel { Id = i, Difficulty = difficulty });
            }
        }


        private void ResetGame()
        {
            score = 0;
            currentTime = 120;
            message = "";
            gameIsRunning = false;
        }
    }
}
