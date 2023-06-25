using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Base class representing a general goal
[Serializable]
public abstract class Goal
{
    public string Name { get; set; }
    public int Score { get; set; }

    public virtual void RecordCompletion()
    {
        // Do nothing by default
    }

    public virtual void DisplayProgress()
    {
        // Display goal progress by default
    }
}

// Derived class representing a simple goal
[Serializable]
public class SimpleGoal : Goal
{
    public override void RecordCompletion()
    {
        Console.WriteLine($"Goal '{Name}' completed! You gained {Score} points.");
    }
}

// Derived class representing an eternal goal
[Serializable]
public class EternalGoal : Goal
{
    public override void RecordCompletion()
    {
        Console.WriteLine($"Goal '{Name}' recorded! You gained {Score} points.");
    }
}

// Derived class representing a checklist goal
[Serializable]
public class ChecklistGoal : Goal
{
    public int RequiredCount { get; set; }
    private int currentCount;

    public ChecklistGoal()
    {
        currentCount = 0;
    }

    public override void RecordCompletion()
    {
        currentCount++;
        Console.WriteLine($"Goal '{Name}' recorded! You gained {Score} points.");

        if (currentCount >= RequiredCount)
        {
            Console.WriteLine($"Congratulations! You completed goal '{Name}' and earned a bonus of {Score} points.");
        }
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"Goal '{Name}' - Completed {currentCount}/{RequiredCount} times.");
    }
}

// Class representing the player
[Serializable]
public class Player
{
    public string Name { get; set; }
    public int TotalScore { get; private set; }

    public Player(string name)
    {
        Name = name;
        TotalScore = 0;
    }

    public void UpdateScore(int points)
    {
        TotalScore += points;
    }
}

// Class responsible for managing goals and player
public class GoalManager
{
    private List<Goal> goals;
    private Player player;

    public GoalManager(string playerName)
    {
        goals = new List<Goal>();
        player = new Player(playerName);
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordCompletion(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            goal.RecordCompletion();
            player.UpdateScore(goal.Score);
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.Write($"[{i + 1}] {goal.Name} - ");

            if (goal is ChecklistGoal checklistGoal)
            {
                checklistGoal.DisplayProgress();
            }
            else
            {
                Console.WriteLine(goal.Score);
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Player: {player.Name}");
        Console.WriteLine($"Total Score: {player.TotalScore}");
    }

    public void SaveGoals(string filePath)
    {
        try
        {
            using (FileStream stream = File.OpenWrite(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, goals);
                Console.WriteLine("Goals saved successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to save goals: {e.Message}");
        }
    }

    public void LoadGoals(string filePath)
    {
        try
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                goals = (List<Goal>)formatter.Deserialize(stream);
                Console.WriteLine("Goals loaded successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to load goals: {e.Message}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        GoalManager goalManager = new GoalManager("Player1");

        // Creating goals
        SimpleGoal simpleGoal = new SimpleGoal
        {
            Name = "Run a Marathon",
            Score = 1000
        };

        EternalGoal eternalGoal = new EternalGoal
        {
            Name = "Read Scriptures",
            Score = 100
        };

        ChecklistGoal checklistGoal = new ChecklistGoal
        {
            Name = "Attend Temple",
            Score = 50,
            RequiredCount = 10
        };

        // Adding goals
        goalManager.AddGoal(simpleGoal);
        goalManager.AddGoal(eternalGoal);
        goalManager.AddGoal(checklistGoal);

        // Saving goals
        goalManager.SaveGoals("goals.dat");

        // Loading goals
        goalManager.LoadGoals("goals.dat");

        // Recording completions
        goalManager.RecordCompletion(0); // Run a Marathon - Simple Goal
        goalManager.RecordCompletion(1); // Read Scriptures - Eternal Goal
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (1st time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (2nd time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (3rd time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (4th time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (5th time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (6th time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (7th time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (8th time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (9th time)
        goalManager.RecordCompletion(2); // Attend Temple - Checklist Goal (10th time)

        // Displaying goals and score
        goalManager.DisplayGoals();
        goalManager.DisplayScore();
    }
}
