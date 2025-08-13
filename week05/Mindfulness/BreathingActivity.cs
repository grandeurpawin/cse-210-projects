using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0) { }

    public void Run()
    {
        DisplayStartingMessage();
        int elapsed = 0;
        while (elapsed < GetDuration())
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            elapsed += 4;
            if (elapsed >= GetDuration()) break;

            Console.Write("Breathe out...");
            ShowCountDown(6);
            elapsed += 6;
        }
        DisplayEndingMessage();
    }
}