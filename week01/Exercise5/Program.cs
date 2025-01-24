using System;

class Program
{
    static void Main(string[] args)
    {
        
        // Call the DisplayWelcome function
        DisplayWelcome();

        // Get the user's name by calling PromptUserName
        string userName = PromptUserName();

        // Get the user's favorite number by calling PromptUserNumber
        int favoriteNumber = PromptUserNumber();

        // Calculate the square of the number by calling SquareNumber
        int squaredNumber = SquareNumber(favoriteNumber);

        // Display the result by calling DisplayResult
        DisplayResult(userName, squaredNumber);
    }

    // Function to display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt the user for their favorite number and return it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to calculate the square of a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}

    
