using System;
using System.Collections.Generic;

class Activity
{
    protected DateTime date;
    protected int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Base class does not have a distance
    }

    public virtual double GetSpeed()
    {
        return 0; // Base class does not have a speed
    }

    public virtual double GetPace()
    {
        return 0; // Base class does not have a pace
    }

    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy} (Unknown Activity) ({minutes} min)";
    }
}


class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / minutes * 60;
    }

    public override double GetPace()
    {
        return minutes / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {distance} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return speed * minutes / 60;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance()} miles, Speed {speed} mph, Pace: {GetPace()} min per mile";
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000; // Convert laps to kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / minutes * 60;
    }

    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance()} km, Speed {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        // Create at least one activity of each type
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 4), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 5), 20, 10));

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
