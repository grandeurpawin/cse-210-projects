// This program works with a library of scriptures rather than a single one.

using System;

class Program
{
    static void Main(string[] args)
    {
        var library = new ScriptureLibrary();

        library.AddScripture(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
        ));

        library.AddScripture(new Scripture(
            new Reference("John", 14, 27),
            "Peace I leave with you, my peace I give unto you: not as the world giveth, give I unto you. Let not your heart be troubled, neither let it be afraid."
        ));

        library.AddScripture(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."
        ));

        Scripture currentScripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());

            Console.WriteLine("Press Enter to continue, or type 'next' for another scripture, or 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit") break;
            if (input == "next")
            {
                 currentScripture = library.GetRandomScripture();
                continue;
            }

            if (!currentScripture.IsCompletelyHidden())
            {
                currentScripture.HideRandomWords();
            }
        }
    }
}