using MathGame;

namespace MathGameLogic
{
    // meant to handle the math bits
    public class GameLogic
    {
        public string Problem { get; set; } = "";
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public static int Answer { get; set; }
        private int currentOperator;
        private Random random = new Random();

        public static List<string> GameHistory { get; set; } = new List<string>();
        public static Dictionary<int, char> Operators = new Dictionary<int, char>()
        {
            { 1, '+'},
            { 2, '-'},
            { 3, '*'},
            { 4, '/'}
        };

        public int MathOperations(int FirstNumber, int SecondNumber, char operation)
        {
            switch (operation)
            {
                case '+':
                    GameHistory.Add($"{FirstNumber} + {SecondNumber} = {FirstNumber + SecondNumber}");
                    return FirstNumber + SecondNumber;

                case '-':
                    GameHistory.Add($"{FirstNumber} - {SecondNumber} = {FirstNumber - SecondNumber}");
                    return FirstNumber - SecondNumber;

                case '*':
                    GameHistory.Add($"{FirstNumber} * {SecondNumber} = {FirstNumber * SecondNumber}");
                    return FirstNumber * SecondNumber;

                case '/':
                    GameHistory.Add($"{FirstNumber} / {SecondNumber} = {FirstNumber / SecondNumber}");
                    return FirstNumber / SecondNumber;

                default:
                    break;
            }
            return 0;
        }

        public void SetProblem(int menuChoice, int difficulty)
        {
            // set difficulty. default (1) = easy, 2 = med, 3 = hard
            int high = 10;
            if (difficulty == 2)
            {
                high = 30;
            }
            if (difficulty == 3)
            {
                high = 100;
            }
            FirstNumber = random.Next(1, high);
            SecondNumber = random.Next(1, high);

            // set operator for random mode
            currentOperator = (menuChoice == 5) ? random.Next(1, 5) : menuChoice;

            // make sure only whole numbers for division
            if (menuChoice == 4 || currentOperator == 4)
                do
                {
                    FirstNumber = random.Next(1, high);
                    SecondNumber = random.Next(1, high);
                }
                while (SecondNumber == 0 || FirstNumber % SecondNumber != 0);

            Problem = $"{FirstNumber} {Operators[currentOperator]} {SecondNumber} = ______";
        }

        public void SetAnswer()
        {
            Answer = MathOperations(FirstNumber, SecondNumber, Operators[currentOperator]);
        }
    }
}