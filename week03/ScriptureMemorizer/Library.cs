using System.Collections.Generic;
using System;

public class ScriptureLibrary
{
    private List<Scripture> scriptures;
    private Random random = new Random();

    public ScriptureLibrary()
    {
        scriptures = new List<Scripture>();
    }

    public void AddScripture(Scripture scripture)
    {
        scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        if (scriptures.Count == 0) return null;
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}