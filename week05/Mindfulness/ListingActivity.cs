using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new()
    {
        "--- Who are people that you appreciate? --- ",
        "--- What are personal strengths of yours? --- ",
        "--- Who are people that you have helped this week? --- ",
        "--- When have you felt the Holy Ghost this month? --- ",
        "--- Who are some of your personal heroes? --- "
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0) { }

    public void Run()
{
    DisplayStartingMessage();

    List<string> sessionPrompts = new List<string>(_prompts);
    Random rand = new();
    int index = rand.Next(sessionPrompts.Count);
    string prompt = sessionPrompts[index];
    sessionPrompts.RemoveAt(index);

    Console.WriteLine("\nList as many responses you can to the following prompt:");
    Console.WriteLine(prompt);
    Console.Write("You may begin in: ");
    ShowCountDown(5);

    List<string> items = GetListFromUser();
    Console.WriteLine($"You listed {items.Count} items!");
    DisplayEndingMessage();
}

    public void GetRandomPrompt()
    {
        Random rand = new();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
                items.Add(item);
        }
        return items;
    }
}