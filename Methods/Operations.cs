namespace NewMathGame.Methods;

public static class Operations
{
    public static void AdditionGame(string message)
    {
        Console.Clear();

        var random = new Random();
        var score = 0;

        int firstNumber = random.Next(1, 9);
        int secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} + {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber + secondNumber)
        {
            Console.WriteLine("Correct!");
            score++;
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }

    public static void SubtractionGame(string message)
    {
        Console.WriteLine(message);
    }

    public static void MultiplicationGame(string message)
    {
        Console.WriteLine(message);
    }

    public static void DivisionGame(string message)
    {
        Console.WriteLine(message);
    }

    public static void ViewPreviousGames(string message)
    {
        Console.WriteLine(message);
    }
}
