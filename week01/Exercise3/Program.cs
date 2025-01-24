using System;

class Program
{
    static void Main(string[] args)
    {
        // Generate a random number as the magic number
        Random random = new Random();
        int magicNumber = random.Next(1, 101); // Random number between 1 and 100
        int guess = -1;

        Console.WriteLine("I have picked a number between 1 and 100. Can you guess it?");

        // Keep looping until the user guesses the correct number
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();

            // Validate if the input is a valid integer
            if (int.TryParse(input, out guess))
            {
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}

