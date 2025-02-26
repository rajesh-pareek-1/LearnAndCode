using System;

class NumberGuessingGame
{
    static void Main()
    {
        PlayGame();
    }

    static void PlayGame()
    {
        int targetNumber = new Random().Next(1, 101);
        int attempts = 0;
        bool guessedCorrectly = false;

        Console.WriteLine("Guess a number between 1 and 100:");

        while (!guessedCorrectly)
        {
            int guess = GetValidGuess();
            attempts++;

            if (guess < targetNumber)
            {
                Console.WriteLine("Too low. Try again:");
            }
            else if (guess > targetNumber)
            {
                Console.WriteLine("Too high. Try again:");
            }
            else
            {
                Console.WriteLine($"You guessed it in {attempts} attempts!");
                guessedCorrectly = true;
            }
        }
    }

    static int GetValidGuess()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= 1 && number <= 100)
            {
                return number;
            }

            Console.WriteLine("Invalid input. Please enter a number between 1 and 100:");
        }
    }
}
