using System;
using System.Collections.Generic;

// Base class: Activity
class Activity
{
    public DateTime Date { get; set; }
    public int LengthInMinutes { get; set; }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual TimeSpan GetPace()
    {
        return TimeSpan.Zero;
    }

    public string GetSummary()
    {
        return $"Date: {Date.ToShortDateString()}\nLength: {LengthInMinutes} minutes";
    }
}

// Derived class: Running
class Running : Activity
{
    public double Distance { get; set; }

    public override double GetDistance()
    {
        return Distance;
    }

    public override TimeSpan GetPace()
    {
        if (LengthInMinutes == 0)
            return TimeSpan.Zero;

        double paceSeconds = LengthInMinutes * 60 / Distance;
        return TimeSpan.FromSeconds(paceSeconds);
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}\nDistance: {Distance} miles\nPace: {GetPace()} per mile";
    }
}

// Derived class: Cycling
class Cycling : Activity
{
    public double Speed { get; set; }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}\nSpeed: {Speed} mph";
    }
}

// Derived class: Swimming
class Swimming : Activity
{
    public int Laps { get; set; }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}\nLaps: {Laps}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running
        {
            Date = new DateTime(2023, 7, 10),
            LengthInMinutes = 30,
            Distance = 3.5
        };
        activities.Add(running);

        Cycling cycling = new Cycling
        {
            Date = new DateTime(2023, 7, 11),
            LengthInMinutes = 45,
            Speed = 15.5
        };
        activities.Add(cycling);

        Swimming swimming = new Swimming
        {
            Date = new DateTime(2023, 7, 12),
            LengthInMinutes = 60,
            Laps = 20
        };
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
