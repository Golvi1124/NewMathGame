/* To-do:
Difficulty levels
Timer
Random Game
Add average score in "View Previous Games" option
Seperate methods in different folder
Make more readable
 */

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine($"What's your name?");
        string name = Console.ReadLine();
        DateTime date = DateTime.Now;
        int gamesPlayed = 0;
        char userOption;
        decimal averageScore;
        bool isScoreEmpty = true;
        List<string> gamesHistory = new();

        Console.WriteLine($"Hello {name}! Today is {date}. This is your math's game.\n");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();

        var isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine($"Games played: {gamesPlayed}");
            Console.WriteLine(@"What game would you like to play?
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        V - View Previous Games
        Q - Quit The Program");

            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine($"\nYou chose the option: {userOption}");

            switch (char.ToLower(userOption))
            {
                case 'a':
                    AdditionGame();
                    break;
                case 's':
                    SubtractionGame();
                    break;
                case 'm':
                    MultiplicationGame();
                    break;
                case 'd':
                    DivisionGame();
                    break;
                case 'v':
                    ViewPreviousGames();
                    break;
                case 'q':
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            gamesPlayed++;
        } while (isGameOn);





    void AdditionGame()
    {
            Console.Clear();
            var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;

        Console.WriteLine("How many times would you like to play?");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var numberOfRounds))
        {
            for (int i = 0; i < numberOfRounds; i++)
            {
                firstNumber = random.Next(1, 51);
                secondNumber = random.Next(1, 51);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                if (int.TryParse(result, out var userAnswer) && userAnswer == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }
            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}");
                Console.ReadKey();

                gamesHistory.Add($"{DateTime.Now} - Addition - Score: {score} out of {numberOfRounds}");
            }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    void SubtractionGame() // first number always greater than second number
    {
            Console.Clear();
            Console.WriteLine("How many times would you like to play?");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var numberOfRounds))
        {
            var random = new Random();
            var score = 0;

            for (int i = 0; i < numberOfRounds; i++)
            {
                var subtractionNumbers = GetSubtractionNumbers(random);
                var firstNumber = subtractionNumbers[0];
                var secondNumber = subtractionNumbers[1];

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                if (int.TryParse(result, out var userAnswer) && userAnswer == firstNumber - secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }
            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}");
                Console.ReadKey();
                gamesHistory.Add($"{DateTime.Now} - Subtraction - Score: {score} out of {numberOfRounds}");
            }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    void MultiplicationGame()

    {
            Console.Clear();
            var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;


        Console.WriteLine("How many times would you like to play?");
        var input = Console.ReadLine();
        if (int.TryParse(input, out var numberOfRounds))
        {
            for (int i = 0; i < numberOfRounds; i++)
            {
                firstNumber = random.Next(1, 11);
                secondNumber = random.Next(1, 11);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();

                if (int.TryParse(result, out var userAnswer) && userAnswer == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }
            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}");
                Console.ReadKey();
                gamesHistory.Add($"{DateTime.Now} - Multiplication - Score: {score} out of {numberOfRounds}");
            }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    void DivisionGame()
    {
            Console.Clear();
            Console.WriteLine("How many times would you like to play?");
        var input = Console.ReadLine();
        if (int.TryParse(input, out var numberOfRounds))
        {
            var random = new Random();
            var score = 0;

            for (int i = 0; i < numberOfRounds; i++)
            {
                var divisionNumbers = GetDivisionNumbers(random);
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();

                if (int.TryParse(result, out var userAnswer) && userAnswer == firstNumber / secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }
            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}");
                Console.ReadKey();
                gamesHistory.Add($"{DateTime.Now} - Division - Score: {score} out of {numberOfRounds}");
            }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    void ViewPreviousGames()
    {
            Console.Clear();
            if (gamesHistory.Count == 0)
            {
                Console.WriteLine("No game have been played yet. Press any key to go back to main menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Games List");
            Console.WriteLine("------------------------------------");
            foreach (var game in gamesHistory)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("------------------------------------");

            Console.WriteLine($"\nPress any key to go back to main menu.");
            Console.ReadKey();
        }

    int[] GetDivisionNumbers(Random random)
    {
        var firstNumber = random.Next(1, 99);
        var secondNumber = random.Next(1, 99);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }

        return new int[] { firstNumber, secondNumber };
    }

    int[] GetSubtractionNumbers(Random random)
    {
        var firstNumber = random.Next(1, 51);
        var secondNumber = random.Next(1, 51);
        while (firstNumber < secondNumber)
        {
            firstNumber = random.Next(1, 51);
            secondNumber = random.Next(1, 51);
        }
        return new int[] { firstNumber, secondNumber };
    }


}
}
