using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Create an instance of the EternalQuestManager
        EternalQuestManager manager = new EternalQuestManager();

        // Load existing goals and scores from a file
        manager.LoadGoals();

        // Main menu
        while (true)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save and Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.DisplayGoals();
                    break;

                case "2":
                    manager.CreateNewGoal();
                    break;

                case "3":
                    manager.RecordEvent();
                    break;

                case "4":
                    manager.DisplayScore();
                    break;

                case "5":
                    // Save goals and scores to a file before exiting
                    manager.SaveGoals();
                    Console.WriteLine("Goals and scores saved. Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

// Base class for all types of goals
abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Completed { get; set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    // Abstract method to record an event for the goal
    public abstract void RecordEvent();
}

// Simple goal class
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override void RecordEvent()
    {
        Completed = true;
    }
}

// Eternal goal class
class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override void RecordEvent()
    {
        // Eternal goals never complete, user gets points every time
        Console.WriteLine($"{Name} recorded. You gained {Value} points!");
    }
}

// Checklist goal class
class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CompletedCount { get; set; }

    public ChecklistGoal(string name, int value, int targetCount) : base(name, value)
    {
        TargetCount = targetCount;
        CompletedCount = 0;
    }

    public override void RecordEvent()
    {
        CompletedCount++;
        Console.WriteLine($"{Name} recorded. You gained {Value} points!");

        if (CompletedCount == TargetCount)
        {
            // Bonus points for completing the checklist
            Console.WriteLine($"Congratulations! Bonus {Value * 2} points for completing the checklist!");
            Completed = true;
        }
    }
}

// Manager class to handle goals and scores
class EternalQuestManager
{
    private List<Goal> goals = new List<Goal>();
    private int userScore = 0;
    private string filename = "goals.txt";

    public void DisplayGoals()
    {
        Console.WriteLine("\nCurrent Goals:");
        foreach (var goal in goals)
        {
            Console.Write($"[{(goal.Completed ? "X" : " ")}] {goal.Name}");
            if (goal is ChecklistGoal checklistGoal)
                Console.Write($" (Completed {checklistGoal.CompletedCount}/{checklistGoal.TargetCount} times)");
            Console.WriteLine();
        }
    }

    public void CreateNewGoal()
    {
        Console.Write("\nEnter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter the value/points for this goal: ");
        int value = int.Parse(Console.ReadLine());

        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Goal newGoal;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, value);
                break;

            case "2":
                newGoal = new EternalGoal(name, value);
                break;

            case "3":
                Console.Write("Enter the target count for the checklist goal: ");
                int targetCount = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, value, targetCount);
                break;

            default:
                Console.WriteLine("Invalid choice. Goal creation failed.");
                return;
        }

        goals.Add(newGoal);
        Console.WriteLine($"New goal '{name}' created successfully!");
    }

    public void RecordEvent()
    {
        Console.Write("\nEnter the name of the goal you completed: ");
        string goalName = Console.ReadLine();

        Goal goal = goals.Find(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));

        if (goal != null)
        {
            goal.RecordEvent();
            userScore += goal.Value;
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found. Recording failed.");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYour Current Score: {userScore} points");
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                outputFile.WriteLine($"{goal.GetType().Name}:{goal.Name}:{goal.Value}:{goal.Completed}");
                if (goal is ChecklistGoal checklistGoal)
                    outputFile.WriteLine($"{checklistGoal.TargetCount}:{checklistGoal.CompletedCount}");
            }
            outputFile.WriteLine($"Score:{userScore}");
        }
    }

    public void LoadGoals()
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                string[] parts = line.Split(':');

                if (parts[0] == "SimpleGoal")
                {
                    goals.Add(new SimpleGoal(parts[1], int.Parse(parts[2])) { Completed = bool.Parse(parts[3]) });
                }
                else if (parts[0] == "EternalGoal")
                {
                    goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])) { Completed = bool.Parse(parts[3]) });
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    goals.Add(new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[4]))
                    {
                        Completed = bool.Parse(parts[3]),
                        CompletedCount = int.Parse(parts[5])
                    });
                }
                else if (parts[0] == "Score")
                {
                    userScore = int.Parse(parts[1]);
                }
            }

            Console.WriteLine("Goals and scores loaded successfully!");
        }
        else
        {
            Console.WriteLine("No previous goals found.");
        }
    }
}
