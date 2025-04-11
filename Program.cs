/* 
Improvements:
 * Added Exception handlings for possible invalid inputs
 * After user chose all options, the program will print them before starting next step
 * Added dictionary to store game types and their names to use them later
 * Add average score and other analyses in "View Previous Games" option
 * Make more readable
 */

class Program
{
    static void Main(string[] args)
    {
        DateTime date = DateTime.Now;
        var menuChoices = new Dictionary<char, string>(){
            { 'A', "Addition" },
            { 'S', "Subtraction" },
            { 'M', "Multiplication" },
            { 'D', "Division" },
            { 'R', "Random" },
            { 'V', "View Previous Games" },
            { 'Q', "Quit The Program" }
        };
        char userOption;
        List<string> gamesHistory = new();
        var grandTotalTime = 0;
        int totalScore = 0;
        int totalRounds = 0;

        Console.WriteLine("What's your name?");
        string? name = Console.ReadLine();

        Console.WriteLine($"Hello {name}! Today is {date}. Welcome to the Math Game!\n");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();

        var isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine($"Games played: {gamesHistory.Count}\n");

            Console.WriteLine("What game would you like to play?");
            foreach (var choice in menuChoices)
            {
                Console.WriteLine($"{choice.Key} - {choice.Value}");
            }
            userOption = Console.ReadKey().KeyChar;

            switch (char.ToUpper(userOption)) // Chose ToUpper so could use Dictionary later
            {
                case 'A':
                    PlayGame('a');
                    break;
                case 'S':
                    PlayGame('s');
                    break;
                case 'M':
                    PlayGame('m');
                    break;
                case 'D':
                    PlayGame('d');
                    break;
                case 'R':
                    PlayGame('r', true);
                    break;
                case 'V':
                    ViewPreviousGames();
                    break;
                case 'Q':
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (isGameOn);


        void PlayGame(char gameType, bool isRandom = false)
        {
            char[] gameTypes = { 'a', 's', 'm', 'd' };

            Console.Clear();
            var score = 0;
            int numberOfRounds;

            Console.WriteLine("How many times would you like to play?");
            while (!int.TryParse(Console.ReadLine(), out numberOfRounds) || numberOfRounds <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
            }

            char difficultyLevel = ChooseDifficultyLevel();

            string gameName = menuChoices[char.ToUpper(gameType)]; //converts gameType (like 'a') to uppercase and fetches "Addition" from the dictionary.
            string difficultyName = difficultyLevel switch //converts 'e'/'m'/'h' to "Easy"/"Medium"/"Hard"
            {
                'e' => "Easy",
                'm' => "Medium",
                'h' => "Hard",
                _ => "Unknown"
            };

            Console.Clear();
            Console.WriteLine($"You chose to play the {gameName} game for {numberOfRounds} rounds with difficulty level - {difficultyName}.\n");

            var startTime = DateTime.Now;

            for (int i = 0; i < numberOfRounds; i++)
            {
                if (isRandom)
                {
                    var random = new Random();
                    var gameIndex = random.Next(0, gameTypes.Length); //istead of (0, 4)
                    gameType = gameTypes[gameIndex];
                }

                string operators = gameType switch
                {
                    'a' => "+",
                    's' => "-",
                    'm' => "*",
                    'd' => "/",
                    _ => throw new ArgumentException("Invalid game type") //For any value that doesn’t match 
                };

                Func<int, int, int> operation = gameType switch
                {
                    'a' => (a, b) => a + b,
                    's' => (a, b) => a - b,
                    'm' => (a, b) => a * b,
                    'd' => (a, b) => a / b,
                    _ => throw new ArgumentException("Invalid game type") //For any value that doesn’t match
                };

                var operands = GetOperands(difficultyLevel, gameType);
                var firstNumber = operands[0];
                var secondNumber = operands[1];

                Console.WriteLine($"How much is {firstNumber} {operators} {secondNumber}?");
                var result = Console.ReadLine();

                if (int.TryParse(result, out int parsedResult)) // Checks if user entered number
                {
                    if (parsedResult == operation(firstNumber, secondNumber))
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input (counts as a mistake).\n");
                }
            }

            var endTime = DateTime.Now;
            TimeSpan totalTime = endTime - startTime;

            Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds} in {totalTime.TotalSeconds:0.00} seconds. \nPress any key to go back to main menu.");
            Console.ReadKey();

            gamesHistory.Add($"{DateTime.Now} - {gameName} - Difficulty: {difficultyName} - Score: {score} out of {numberOfRounds} - Time: {totalTime.TotalSeconds:0.00}s");
            grandTotalTime += (int)totalTime.TotalSeconds;
            totalScore += score;
            totalRounds += numberOfRounds;
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

            Console.WriteLine($"{name}'s games List");
            Console.WriteLine("------------------------------------");
            foreach (var game in gamesHistory)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("------------------------------------\n");
            Console.WriteLine(@$"{name}'s game analysis:
-   Total games played: {gamesHistory.Count}.
-   Total time used: {grandTotalTime} seconds.
-   Total score: {totalScore} out of {totalRounds}, meaning that you were correct {(double)totalScore / totalRounds * 100:0.00}% of the time.
-   Average time per game: {(double)grandTotalTime / gamesHistory.Count:0.00} seconds.
");

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

            while (!options.Contains(level))
            {
                Console.WriteLine("Invalid input. Please choose a valid difficulty level.");
                level = char.ToLower(Console.ReadKey().KeyChar);

            }
            return level;
        }
    }
}