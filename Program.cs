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

            Console.WriteLine("How many times would you like to play?");
            var numberOfRounds = int.Parse(Console.ReadLine());

            char difficultyLevel = ChooseDifficultyLevel();

            var startTime = DateTime.Now;

            for (int i = 0; i < numberOfRounds; i++)
            {
                var operands = GetOperands(difficultyLevel, 'a');
                var firstNumber = operands[0];
                var secondNumber = operands[1];

                Console.WriteLine($"How much is {firstNumber} + {secondNumber}?");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!\n");
                }
            }
            var endTime = DateTime.Now;
            var totalTime = endTime - startTime;

            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds} in {totalTime.TotalSeconds:0.00} seconds. Press any key to go back to main menu.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - Addition - Difficulty: {char.ToUpper(difficultyLevel)} - Score: {score} out of {numberOfRounds} - Time: {totalTime.TotalSeconds:0.00}s");
        }

        void SubtractionGame()
        {
            Console.Clear();
            var score = 0;

            Console.WriteLine("How many times would you like to play?");
            var numberOfRounds = int.Parse(Console.ReadLine());

            char difficultyLevel = ChooseDifficultyLevel();

            var startTime = DateTime.Now;

            for (int i = 0; i < numberOfRounds; i++)
            {
                var operands = GetOperands(difficultyLevel, 's');
                var firstNumber = operands[0];
                var secondNumber = operands[1];

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

            var endTime = DateTime.Now;
            var totalTime = endTime - startTime;

            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds} in {totalTime.TotalSeconds:0.00} seconds. Press any key to go back to main menu.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - Subtraction - Difficulty: {char.ToUpper(difficultyLevel)} - Score: {score} out of {numberOfRounds} - Time: {totalTime.TotalSeconds:0.00}s");
        }

        void MultiplicationGame()
        {
            Console.Clear();
            var score = 0;

            Console.WriteLine("How many times would you like to play?");
            var numberOfRounds = int.Parse(Console.ReadLine());

            char difficultyLevel = ChooseDifficultyLevel();

            var startTime = DateTime.Now;

            for (int i = 0; i < numberOfRounds; i++)
            {
                var operands = GetOperands(difficultyLevel, 'm');
                var firstNumber = operands[0];
                var secondNumber = operands[1];

                Console.WriteLine($"How much is {firstNumber} * {secondNumber}?");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!\n");
                }
            }

            var endTime = DateTime.Now;
            var totalTime = endTime - startTime;

            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds} in {totalTime.TotalSeconds:0.00} seconds. Press any key to go back to main menu.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - Multiplication - Difficulty: {char.ToUpper(difficultyLevel)} - Score: {score} out of {numberOfRounds} - Time: {totalTime.TotalSeconds:0.00}s");
        }

        void DivisionGame()
        {
            Console.Clear();
            var score = 0;

            Console.WriteLine($"How many times would you like to play?");
            var numberOfRounds = int.Parse(Console.ReadLine());

            char difficultyLevel = ChooseDifficultyLevel();

            var startTime = DateTime.Now;

            for (int i = 0; i < numberOfRounds; i++)
            {
                var operands = GetOperands(difficultyLevel, 'd');
                var firstNumber = operands[0];
                var secondNumber = operands[1];

                Console.WriteLine($"How much is {firstNumber} / {secondNumber}?");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!\n");
                }
            }

            var endTime = DateTime.Now;
            var totalTime = endTime - startTime;

            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds} in {totalTime.TotalSeconds:0.00} seconds. Press any key to go back to main menu.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - Division - Difficulty: {char.ToUpper(difficultyLevel)} - Score: {score} out of {numberOfRounds} - Time: {totalTime.TotalSeconds:0.00}s");
        }


        int[] GetOperands(char difficultyLevel, char gameType)
        {
            int topOfRange = 0;

            switch (difficultyLevel)
            {
                case 'e':
                    topOfRange = gameType == 'd' ? 99 : 9;
                    break;
                case 'm':
                    topOfRange = gameType == 'd' ? 999 : 99;
                    break;
                case 'h':
                    topOfRange = gameType == 'd' ? 9999 : 999;
                    break;
            }

            var random = new Random();
            var firstNumber = random.Next(1, topOfRange);
            var secondNumber = random.Next(1, topOfRange);

            var result = new int[2];

            if (gameType == 'd')
            {
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, topOfRange);
                    secondNumber = random.Next(1, topOfRange);
                }
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
