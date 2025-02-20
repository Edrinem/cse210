using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all activities
abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"\n{Name} - {Description}");
        Console.Write("Enter duration (seconds): ");
        Duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);

        RunActivity();

        Console.WriteLine("\nGood job! Activity completed.");
        Console.WriteLine($"You completed {Name} for {Duration} seconds.");
        ShowSpinner(3);
    }

    protected abstract void RunActivity();

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding your breathing.") {}

    protected override void RunActivity()
    {
        int timeLeft = Duration;
        while (timeLeft > 0)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            Console.Write("Breathe out... ");
            ShowCountdown(3);
            timeLeft -= 6;
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Reflection Activity
class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn from this experience?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on your strengths and experiences.") {}

    protected override void RunActivity()
    {
        Random rnd = new Random();
        Console.WriteLine("\n" + prompts[rnd.Next(prompts.Count)]);
        ShowSpinner(3);

        int timeLeft = Duration;
        while (timeLeft > 0)
        {
            Console.WriteLine(questions[rnd.Next(questions.Count)]);
            ShowSpinner(5);
            timeLeft -= 5;
        }
    }
}

// Listing Activity
class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on positive aspects of your life.") {}

    protected override void RunActivity()
    {
        Random rnd = new Random();
        Console.WriteLine("\n" + prompts[rnd.Next(prompts.Count)]);
        ShowSpinner(3);

        Console.WriteLine("Start listing items (press Enter after each one):");
        int count = 0;
        int timeLeft = Duration;
        while (timeLeft > 0)
        {
            Console.ReadLine();
            count++;
            timeLeft -= 3;
        }

        Console.WriteLine($"\nYou listed {count} items!");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => throw new Exception("Invalid choice. Try again.")
            };

            if (activity == null) break;

            activity.Start();
        }
    }
}
