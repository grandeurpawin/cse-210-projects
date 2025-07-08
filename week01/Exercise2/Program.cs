using System;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int percentage = int.Parse(gradePercentage);

        string letter = "";

        string sign = "";
        int last_digit = percentage % 10;

        if (percentage >= 90)
        {
            letter = "A";
        }

        else if (percentage >= 80)
        {
            letter = "B";
        }

        else if (percentage >= 70)
        {
            letter = "C";
        }

        else if (percentage >= 60)
        {
            letter = "D";
        }

        else if (percentage < 60)
        {
            letter = "F";
        }

        else
        {
            Console.WriteLine("Invalid grade percentage entered. ");
        }


        if (last_digit >= 7)
        {
            sign = "+";
        }

        else if (last_digit < 3)
        {
            sign = "-";
        }

        else 
        {
            sign = "";
        }

        if (percentage >= 93)
        {
            sign = "";
        }

        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letter}{sign}.");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }

        else
        {
            Console.WriteLine("Keep going, there is  brighter future ahead. ");
        }
    }
}