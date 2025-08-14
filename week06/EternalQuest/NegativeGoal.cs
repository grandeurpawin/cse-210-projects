using System;

public class NegativeGoal : Goal
{
    private int _penalty;
    private int _occurrences;

    public NegativeGoal(string shortName, string description, int penalty)
        : base(shortName, description, -penalty)
    {
        _penalty = penalty;
        _occurrences = 0;
    }

    public override void RecordEvent()
    {
        _occurrences++;
    }

    public override bool IsComplete()
    {
        return false; // Negative goals are never "complete"
    }

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} ({_description}) -- Occurrences: {_occurrences} | Penalty: -{_penalty} each";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{_shortName}|{_description}|{_penalty}|{_occurrences}";
    }

    public int GetPenalty()
    {
        return _penalty;
    }

    public int GetOccurrences()
    {
        return _occurrences;
    }
}