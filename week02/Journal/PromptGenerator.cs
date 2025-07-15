using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I could change one thing about today, what would it be?",
    };

    public string GetRandomPrompt()
    {
        Random promptGenerator = new Random();
        int prompt = promptGenerator.Next(prompts.Count);
        string selectedPrompt = prompts[prompt];
        return selectedPrompt;
    }
}