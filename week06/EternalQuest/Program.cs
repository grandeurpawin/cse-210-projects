// Added support for additional goal types, including progressive goals that reward incremental progress toward large objectives (e.g., training for a marathon), and negative goals that deduct points for undesirable habits."

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}