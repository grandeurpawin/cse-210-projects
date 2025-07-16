// Extra added feature: Mood tracking for journal entries
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        string choice = "";
        while (choice != "5")
        {
            Console.Write("Please select one of the following choices:");
            Console.Write("\n1.Write \n2.Display \n3.Save \n4.Load \n5.Quit\n");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string entryText = Console.ReadLine();
                    Console.Write("What was your mood while writing this entry? ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _promptText = prompt,
                        _entryText = entryText,
                        _mood = mood
                    };
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                default:
                Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }
    }
}