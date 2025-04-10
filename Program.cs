/* To-do:
 * Stop trying to improve game while not done with all the instructions!!!!
 * Add things/ideas from previous repo, but keep it simple
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

        Console.WriteLine($"Hello {name}! Today is {date}. This is your math's game. It's great that you're working on improving yourself.\n");
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
            var numberOfRounds = int.Parse(Console.ReadLine());

            char difficultyLevel = ChooseDifficultyLevel();

            for (int i = 0; i < numberOfRounds; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"How much is {firstNumber} + {secondNumber}?");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct!/n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!/n");
                }
            }
            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - Addition - Score: {score} out of {numberOfRounds}");

        }

        void SubtractionGame()
        {
            Console.Clear();

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            Console.WriteLine("How many times would you like to play?");
            var numberOfRounds = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRounds; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"How much is {firstNumber} - {secondNumber}?");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!\n");
                }
            }
            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - Subtraction - Score: {score} out of {numberOfRounds}");
        }

        void MultiplicationGame()
        {
            Console.Clear();

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            Console.WriteLine("How many times would you like to play?");
            var numberOfRounds = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRounds; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"How much is {firstNumber} * {secondNumber}?");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }
            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - Multiplication - Score: {score} out of {numberOfRounds}");
        }

        void DivisionGame()
        {
            Console.Clear();
            var score = 0;
            Console.WriteLine($"How many times would you like to play?");
            var numberOfRounds = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRounds; i++)
            {
                var divisionNumbers = GetDivisionNumbers();


                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"How much is {firstNumber} / {secondNumber}?");
                var input = Console.ReadLine();

                if (int.Parse(input) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }
            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - Division - Score: {score} out of {numberOfRounds}");
        }


        int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }






        void ViewPreviousGames()
        {
            Console.Clear();
            if (gamesHistory.Count == 0)
            {
                Console.WriteLine("No games played yet. Press any key to go back to main menu.");
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

        char ChooseDifficultyLevel()
        {
            Console.WriteLine($@"
Choose difficulty level:
E - Easy
M - Medium
H - Hard");

            var level = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            var options = new char[] { 'e', 'm', 'h' };

            while(!options.Contains(level))
            {
                Console.WriteLine("Invalid input. Please choose a valid difficulty level.");
                level = char.ToLower(Console.ReadKey().KeyChar);
                
            }
            return level;
        }







    }
}
