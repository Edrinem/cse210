using System;
using System.Collections.Generic;
using System.IO;

// Base Goal Class
abstract class Goal
{
    protected string Name;
    public int Points;
    public bool IsComplete { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
}

// Simple Goal (One-time completion)
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        IsComplete = true;
        Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
    }

    public override string GetStatus() => IsComplete ? "[X] " + Name : "[ ] " + Name;
    public override string Serialize() => $"Simple|{Name}|{Points}|{IsComplete}";
}

// Eternal Goal (Repeats infinitely)
class EternalGoal : Goal
{
    private int timesCompleted = 0;

    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        timesCompleted++;
        Console.WriteLine($"Recorded '{Name}'. You earned {Points} points!");
    }

    public override string GetStatus() => $"[∞] {Name} (Completed {timesCompleted} times)";
    public override string Serialize() => $"Eternal|{Name}|{Points}|{timesCompleted}";
}

// Checklist Goal (Requires multiple completions)
class ChecklistGoal : Goal
{
    private int target;
    private int progress;
    private int bonus;

    public ChecklistGoal(string name, int points, int target, int bonus) : base(name, points)
    {
        this.target = target;
        this.bonus = bonus;
        progress = 0;
    }

    public override void RecordEvent()
    {
        progress++;
        if (progress >= target)
        {
            IsComplete = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points + bonus} points (Bonus included!).");
        }
        else
        {
            Console.WriteLine($"Recorded '{Name}'. You earned {Points} points! ({progress}/{target})");
        }
    }

    public override string GetStatus() => IsComplete ? $"[X] {Name} (Completed {target}/{target})" : $"[ ] {Name} (Completed {progress}/{target})";
    public override string Serialize() => $"Checklist|{Name}|{Points}|{progress}|{target}|{bonus}";
}

// Main Program
class EternalQuest
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalPoints = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest - Goal Tracking");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": RecordEvent(); break;
                case "3": ShowGoals(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice, try again."); break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select: ");

        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1": goals.Add(new SimpleGoal(name, points)); break;
            case "2": goals.Add(new EternalGoal(name, points)); break;
            case "3":
                Console.Write("Enter target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid option!");
                return;
        }
        Console.WriteLine("Goal added successfully!");
    }

    private static void RecordEvent()
    {
        ShowGoals();
        Console.Write("Enter goal number to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
            totalPoints += goals[index].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal selection!");
        }
    }

    private static void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.WriteLine($"Total Points: {totalPoints}\n");
    }

    private static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalPoints);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    private static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            totalPoints = int.Parse(lines[0]);
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("No saved data found.");
        }
    }
}
