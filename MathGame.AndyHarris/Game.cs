using MathGameLogic;

namespace MathGame
{
    // meant to handle game state and flow
    public class Game
    {
        public static int MenuChoice { get; set; }
        public int Questions { get; set; } = 5;
        public int Guess { get; set; }
        public int Difficulty { get; set; }
        public Dictionary<string, int> AnswerScores { get; private set; } = new Dictionary<string, int>()
            {
                { "correct", 0 },
                { "wrong", 0 }
            };

        public Dictionary<int, string> DifficultySetting { get; private set; } = new Dictionary<int, string>()
            {
                { 1, "Easy" },
                { 2, "Medium" },
                { 3, "Hard" }
            };

        public int ShowMenu()
        {
            int menuChoice;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Random Mode");
                Console.WriteLine("6. Show old games");
                Console.WriteLine("7. Set difficulty");
                Console.WriteLine("8. Exit");

                Console.WriteLine("Enter a choice:");

                if (int.TryParse(Console.ReadLine(), out menuChoice) && menuChoice >= 1 && menuChoice <= 8)
                {
                    MenuChoice = menuChoice;
                    break;
                }

                Console.Clear();
                Console.WriteLine("Wow, you're not going to do well at a math ..");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Try again:\n");

            } while (true);
            return menuChoice;
        }

        public void SetDifficulty()
        {
            do
            {
                Console.WriteLine("Choose difficulty:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");

                int difficultyInput;
                if (int.TryParse(Console.ReadLine(), out difficultyInput))
                {
                    Difficulty = difficultyInput;
                    break;
                }
            } while (true);
            Console.WriteLine("");
            Console.WriteLine($"Difficulty set to: {DifficultySetting[Difficulty]}\n");
        }

        public void CheckGuess()
        {
            Console.WriteLine($"You guessed: {Guess}");
            Console.WriteLine("Checking response...");
            Thread.Sleep(500);
            Console.WriteLine("You are...");
            Thread.Sleep(500);
            Console.WriteLine();

            if (GameLogic.Answer == Guess)
            {
                Console.WriteLine("Correct! S-M-R-T You are so smrt!\n");
                AnswerScores["correct"]++;
            }
            else
            {
                Console.WriteLine("Wrong... :( WOMP WOMP\n");
                AnswerScores["wrong"]++;
            }
        }
        public void ShowStats()
        {
            Console.WriteLine("");
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Correct answers: {AnswerScores["correct"]}");
            Console.WriteLine($"Wrong answers: {AnswerScores["wrong"]}");
            Console.WriteLine($"Grade: {AnswerScores["correct"] / (double)(AnswerScores["correct"] + AnswerScores["wrong"]):P1}");
        }

        public void PrintGameHistory()
        {
            if (GameLogic.GameHistory.Count() == 0)
            {
                Console.WriteLine("No game history yet. So get playing!");
                Console.WriteLine("");
            }
            else
            {
                foreach (string fart in GameLogic.GameHistory)
                {
                    Console.WriteLine(fart);
                }
            }
        }
    }
}