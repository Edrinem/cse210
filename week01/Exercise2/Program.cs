using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("what is your grade");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";
        if (percent>=90)
        {letter="A";
        }
        else if (percent>=80)
        {letter="B";
        }
        else if (percent>=70)
        {letter="C";
        }
        else if (percent>=60)
        {letter="D";
        }
        else if (percent<60)
        {letter="F";
        }
        Console.WriteLine($"Your grade is: {letter}");
        if (percent>=70)
        Console.WriteLine("Thanks for your efforts you've passed");
        else
        Console.WriteLine("Thanks for your efforts but better luck next time");


    }
}