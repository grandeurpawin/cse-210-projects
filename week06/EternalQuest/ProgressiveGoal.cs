using System;

public class ProgressiveGoal : Goal
{
    private int _currentProgress;
    private int _target;
    private int _bonus;

    public ProgressiveGoal(string shortName, string description, int pointsPerUnit, int target, int bonus)
        : base(shortName, description, pointsPerUnit)
    {
        _currentProgress = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_currentProgress < _target)
        {
            _currentProgress++;
        }
    }

    public override bool IsComplete()
    {
        return _currentProgress >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Progress: {_currentProgress}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressiveGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_currentProgress}";
    }

    public int GetBonus()
    {
        return _bonus;
    }
}