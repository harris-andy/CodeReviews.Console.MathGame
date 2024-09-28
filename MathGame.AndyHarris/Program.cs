using System.Diagnostics;
using MathGame;
using MathGameLogic;

GameLogic gameLogic = new GameLogic();
Game game = new Game();
Stopwatch stopwatch = new Stopwatch();

/*
Choose an option:
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random Mode
6. Show old games
7. Set difficulty
8. Exit
*/

// get menu choice
Console.Clear();
while (true)
{
    Game.MenuChoice = game.ShowMenu();

    if (Game.MenuChoice == 8)
    {
        break;
    }

    // set difficulty (should be in the GameLogic class?)
    if (Game.MenuChoice == 7)
    {
        game.SetDifficulty();
    }

    if (Game.MenuChoice < 6)
    {
        stopwatch.Reset();
        stopwatch.Start();

        for (int i = 0; i < game.Questions; i++)
        {
            gameLogic.SetProblem(Game.MenuChoice, game.Difficulty);
            gameLogic.SetAnswer();

            Console.WriteLine(gameLogic.Problem);

            // Get player's guess
            do
            {
                Console.WriteLine("Enter your answer:");
                int guessInput;
                if (int.TryParse(Console.ReadLine(), out guessInput))
                {
                    game.Guess = guessInput;
                    break;
                }
            } while (true);

            // give player their result
            game.CheckGuess();
        }
        // show time for the current round
        stopwatch.Stop();
        Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalSeconds:N1} seconds");
        Thread.Sleep(1500);

        // print score
        game.ShowStats();

        // reset scores for next round
        game.AnswerScores["correct"] = 0;
        game.AnswerScores["wrong"] = 0;
    }

    if (Game.MenuChoice == 6)
    {
        game.PrintGameHistory();
    }
}