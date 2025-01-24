using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbers = new List<int>(); // Initialize an empty list to store numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Loop to collect numbers from the user
        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                break; // Exit the loop if the user enters 0
            }

            numbers.Add(number); // Add the number to the list
        }

        // Compute the sum of the numbers
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Compute the average of the numbers
        double average = (double)sum / numbers.Count;

        // Find the maximum number in the list
        int max = int.MinValue; // Initialize max to the smallest possible integer
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        // Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}

    
