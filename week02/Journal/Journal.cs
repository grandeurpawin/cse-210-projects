// Extra added feature: Mood tracking for journal entries
using System;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText} | {entry._mood}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        entries.Clear();
        using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    Entry entry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _entryText = parts[2],
                        _mood = parts[3]
                    };
                    entries.Add(entry);
                }
            }
        }
    }
}
