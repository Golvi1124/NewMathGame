using NewMathGame.Methods;

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

        Console.WriteLine($"Hello {name}! Today is {date}. This is your math's game. It's great that you're working on improving yourself.\n");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
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
                Operations.AdditionGame();
                break;
            case 's':
                Operations.SubtractionGame();
                break;
            case 'm':
                Operations.MultiplicationGame();
                break;
            case 'd':
                Operations.DivisionGame();
                break;
            case 'v':
             //   Operations.ViewPreviousGames("List of Games");
                break;
            case 'q':
                Console.WriteLine("Goodbye");
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }


    }
}
