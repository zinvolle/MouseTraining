using MoleGame.Models;

namespace MoleGame.Pages
{
    public partial class HomeGame
    {
        int score = 0;
        int currentTime = 10;
        int hitPosition = 0;
        string message = "";
        int gameSpeed;
        bool gameIsRunning = true;
        private int numberOfSquares;
        public List<SquareModel> Squares { get; set; } = new List<SquareModel>();

        private readonly Dictionary<string, (int squareCount, int speed)> difficultySettings = new Dictionary<string, (int, int)>
        {
            {"easy", (150, 1000)},
            {"medium",(400, 800)},
            {"hard", (1000, 500)}
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
                InitializeSquares();
            }
            else
            {
                throw new ArgumentException("Invalid difficulty level");
            }
        }

        private void InitializeSquares()
        {
            Squares.Clear();
            for (int i = 0; i < numberOfSquares; i++)
            {
                Squares.Add(new SquareModel { Id = i });
            }
        }

        public void ChangeDifficulty(string newDifficulty)
        {
            SetDifficulty(newDifficulty);
            ResetGame(); // Reset game when difficulty changes
        }

        private void ResetGame()
        {
            score = 0;
            currentTime = 10;
            hitPosition = 0;
            message = "";
            gameIsRunning = true;
            // Additional reset logic if needed
        }
    }
}
