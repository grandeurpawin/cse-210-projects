using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}");
    }

    public void ListGoalName()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The type of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progressive Goal");
        Console.WriteLine("5. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the short name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description it? ");
        string desc = Console.ReadLine();
        Console.Write("What it the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
                case "4":
                Console.Write("What is the target amount to complete this goal? ");
                int progTarget = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for completing it? ");
                int progBonus = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressiveGoal(name, desc, points, progTarget, progBonus));
                break;

            case "5":
                Console.Write("How many points will be deducted for each occurrence? ");
                int penalty = int.Parse(Console.ReadLine());
                _goals.Add(new NegativeGoal(name, desc, penalty));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
    
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();
    
            if (goal is ProgressiveGoal pg)
            {
                _score += pg.GetPoints();
                if (pg.IsComplete())
                {
                    _score += pg.GetBonus();
                }
            }
            else if (goal is NegativeGoal ng)
            {
                _score -= ng.GetPenalty();  // ✅ Penalty applied correctly
            }
            else
            {
                _score += goal.GetPoints();
                if (goal is ChecklistGoal checklist && checklist.IsComplete())
                {
                    _score += checklist.GetBonus();
                }
            }
    
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save your goals (e.g., goals.txt): ");
    string filename = Console.ReadLine();

    try
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving goals: {ex.Message}");
    }

    }

    public void LoadGoals()
{
    Console.Write("Enter the filename to load your goals from (e.g., goals.txt): ");
    string filename = Console.ReadLine();

    if (File.Exists(filename))
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
                switch (type)
                {
                    case "SimpleGoal":
                        var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4])) sg.RecordEvent();
                        _goals.Add(sg);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                        typeof(ChecklistGoal).GetField("_amountCompleted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                            .SetValue(cg, int.Parse(parts[6]));
                        _goals.Add(cg);
                        break;
                    case "ProgressiveGoal":
                        var pg = new ProgressiveGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                        typeof(ProgressiveGoal).GetField("_currentProgress", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                            .SetValue(pg, int.Parse(parts[6]));
                        _goals.Add(pg);
                        break;

                    case "NegativeGoal":
                        var ng = new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]));
                        typeof(NegativeGoal).GetField("_occurrences", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                            .SetValue(ng, int.Parse(parts[4]));
                        _goals.Add(ng);
                        break;
            }
        }
    }
    else
    {
        Console.WriteLine("No saved goals found.");
    }
}
}