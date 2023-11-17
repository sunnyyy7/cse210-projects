using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 Eternal Quest program!");
    }
}

public class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public virtual void MarkComplete()
    {
        IsComplete = true;
    }

    public virtual void DisplayStatus()
    {
        Console.WriteLine($"Goal: {Name}, Points: {Points}, Completed: {IsComplete}");
    }
}

public class SimpleGoal : Goal
{
    public override void MarkComplete()
    {
        base.MarkComplete();
    }
}

public class EternalGoal : Goal
{
    // Additional logic for eternal goals
}

public class ChecklistGoal : Goal
{
    public int CompletedCount { get; set; }
    public int RequiredCount { get; set; }

    public override void MarkComplete()
    {
        base.MarkComplete();
        CompletedCount++;

        if (CompletedCount == RequiredCount)
        {
            Points += 500; // Bonus points for completing the checklist goal
        }
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine($"Completed {CompletedCount}/{RequiredCount} times");
    }
}

class Program
{
    static void Main()
    {
        // Create instances of goals
        Goal simpleGoal = new SimpleGoal { Name = "Run a marathon", Points = 1000 };
        Goal eternalGoal = new EternalGoal { Name = "Read scriptures", Points = 100 };
        Goal checklistGoal = new ChecklistGoal { Name = "Attend the temple", Points = 50, RequiredCount = 10 };

        // Display initial status
        simpleGoal.DisplayStatus();
        eternalGoal.DisplayStatus();
        checklistGoal.DisplayStatus();

        // Mark goals as complete
        simpleGoal.MarkComplete();
        eternalGoal.MarkComplete();
        checklistGoal.MarkComplete();
        checklistGoal.MarkComplete(); 
        
        // Display updated status
        simpleGoal.DisplayStatus();
        eternalGoal.DisplayStatus();
        checklistGoal.DisplayStatus();
    }
}
