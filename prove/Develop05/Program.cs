using System;

using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public abstract int Value { get; }

    public bool Completed { get; set; }

    public Goal(string name)
    {
        Name = name;
        Completed = false;
    }

    public abstract void RecordEvent();
}

public class SimpleGoal : Goal
{
    public override int Value { get; }

    public SimpleGoal(string name, int value) : base(name)
    {
        Value = value;
    }

    public override void RecordEvent()
    {
        Completed = true;
    }
}

public class EternalGoal : Goal
{
    public override int Value { get; }

    public EternalGoal(string name, int value) : base(name)
    {
        Value = value;
    }

    public override void RecordEvent()
    {
        // Eternal goals are never completed
    }
}

public class ChecklistGoal : Goal
{
    public int Target { get; }
    public int Bonus { get; }
    private int _currentCount;

    public override int Value => _currentCount == Target ? Bonus : 0;

    public ChecklistGoal(string name, int target, int bonus) : base(name)
    {
        Target = target;
        Bonus = bonus;
        _currentCount = 0;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        Completed = _currentCount == Target;
    }
}

public class EternalQuest
{
    public List<Goal> Goals { get; private set; }
    public int Score { get; private set; }

    public EternalQuest()
    {
        Goals = new List<Goal>();
        Score = 0;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = Goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            Score += goal.Value;
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {Score}");
    }

    public void ShowGoals()
    {
        Console.WriteLine("Your goals:");
        foreach (Goal goal in Goals)
        {
            Console.Write($"{goal.Name}: ");
            if (goal.Completed)
            {
                Console.Write("[X]");
                if (goal is ChecklistGoal)
                {
                    Console.WriteLine($" Completed {((ChecklistGoal)goal).Value}/{((ChecklistGoal)goal).Target} times");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("[ ]");
            }
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in Goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Completed}");
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            Goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string typeName = parts[0];
                    string name = parts[1];
                    bool completed = bool.Parse(parts[2]);

                    Goal goal;
                    switch (typeName)
                    {
                        case nameof(SimpleGoal):
                            goal = new SimpleGoal(name, 0);
                            break;
                        case nameof(EternalGoal):
                            goal = new EternalGoal(name, 0);
                            break;
                        case nameof(ChecklistGoal):
                            goal = new ChecklistGoal(name, 0, 0);
                            break;
                        default:
                            throw new ArgumentException("Invalid goal type.");
                    }

                    goal.Completed = completed;
                    Goals.Add(goal);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EternalQuest eternalQuest = new EternalQuest();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record events");
            Console.WriteLine("6. Quit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nSelect type of goal:");
                    Console.WriteLine("1. Simple goal");
                    Console.WriteLine("2. Eternal goal");
                    Console.WriteLine("3. Checklist goal");

                    Console.Write("Enter your choice: ");
                    string goalTypeChoice = Console.ReadLine();

                    Console.Write("Enter goal name: ");
                    string goalName = Console.ReadLine();

                    Console.Write("Enter goal value: ");
                    int goalValue = int.Parse(Console.ReadLine());

                    switch (goalTypeChoice)
                    {
                        case "1":
                            eternalQuest.AddGoal(new SimpleGoal(goalName, goalValue));
                            break;
                        case "2":
                            eternalQuest.AddGoal(new EternalGoal(goalName, goalValue));
                            break;
                        case "3":
                            Console.Write("Enter target count: ");
                            int targetCount = int.Parse(Console.ReadLine());

                            Console.Write("Enter bonus value: ");
                            int bonusValue = int.Parse(Console.ReadLine());

                            eternalQuest.AddGoal(new ChecklistGoal(goalName, targetCount, bonusValue));
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;
                case "2":
                    eternalQuest.ShowGoals();
                    break;
                case "3":
                    eternalQuest.SaveGoals("goals.txt");
                    Console.WriteLine("Goals saved successfully.");
                    break;
                case "4":
                    eternalQuest.LoadGoals("goals.txt");
                    Console.WriteLine("Goals loaded successfully.");
                    break;
                case "5":
                    Console.Write("Enter goal name to record event: ");
                    string eventName = Console.ReadLine();
                    eternalQuest.RecordEvent(eventName);
                    break;
                case "6":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
