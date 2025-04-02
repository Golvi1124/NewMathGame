namespace NewMathGame.Methods;

public static class Operations
{
    public static void AdditionGame()
    {
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
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

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
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static void SubtractionGame()
    {
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
                firstNumber = random.Next(1, 21);
                secondNumber = random.Next(1, 21);

                //make it so that the first number is always greater than the second number

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
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static void MultiplicationGame()
    {
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
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

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
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static void DivisionGame()
    {
        
    }

    public static void ViewPreviousGames()
    {
        
    }
}
