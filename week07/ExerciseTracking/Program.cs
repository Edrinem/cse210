using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime date;
    private int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public int GetMinutes() => minutes;
    public DateTime GetDate() => date;

    // Abstract methods to be overridden by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // General method to provide a summary
    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} - {this.GetType().Name} ({minutes} min) " +
               $"- Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}
public class Running : Activity
{
    private double distance; // in km

    public Running(DateTime date, int minutes, double distance) 
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / distance;
}
public class Cycling : Activity
{
    private double speed; // in kph

    public Cycling(DateTime date, int minutes, double speed) 
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * GetMinutes()) / 60;

    public override double GetSpeed() => speed;

    public override double GetPace() => 60 / speed;
}
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps) 
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => (laps * 50) / 1000.0;

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / GetDistance();
}
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 02, 20), 60, 8.8),
            new Cycling(new DateTime(2025, 02, 20), 50, 35.0),
            new Swimming(new DateTime(2025, 02, 20), 45, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
