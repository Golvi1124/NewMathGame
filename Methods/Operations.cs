// need too add after wrong input user should be able to try again

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
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static void SubtractionGame() // first number always greater than second number
    {
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
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static void DivisionGame()
    {
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
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static void ViewPreviousGames()
    {

    }

    private static int[] GetDivisionNumbers(Random random)
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

    private static int[] GetSubtractionNumbers(Random random)
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

