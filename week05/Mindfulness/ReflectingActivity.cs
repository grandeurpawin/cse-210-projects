using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "---Think of a time when you stood up for someone else. --- ",
        "---Think of a time when you did something really difficult. --- ",
        "---Think of a time when you helped someone in need. --- ",
        "---Think of a time when you did something truly selfless. --- "
    };

    private List<string> _questions = new()
    {
        "> Why was this experience meaningful to you? ",
        "> Have you ever done anything like this before? ",
        "> How did you get started? ",
        "> How did you feel when it was complete? ",
        "> What made this time different than other times when you were not successful? ",
        "> What is your favorite thing about this experience? ",
        "> What could you learn from this experience that applies to other situations? ",
        "> What did you learn about yourself? ",
        "> How can you keep this experience in mind in the future? "
    };

    public ReflectingActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognice the power you have and how you can use it in other aspects of your life", 0) { }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        
        List<string> sessionQuestions = new List<string>(_questions);
        Random rand = new();
        int elapsed = 0;

        Console.Clear();
        while (elapsed < GetDuration())
        {
            if (sessionQuestions.Count == 0)
                sessionQuestions = new List<string>(_questions);
            int index = rand.Next(sessionQuestions.Count);
            string question = sessionQuestions[index];
            sessionQuestions.RemoveAt(index);

            Console.Write(question);
            ShowSpinner(6);
            Console.WriteLine();
            elapsed += 6;
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rand = new();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random rand = new();
        return _questions[rand.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.Clear();
    }

    public void DisplayQuestions()
    {
        int elapsed = 0;
        while (elapsed < GetDuration())
        {
            Console.Write(GetRandomQuestion());
            ShowSpinner(8);
            Console.WriteLine();
            elapsed += 8;
        }
    }
}