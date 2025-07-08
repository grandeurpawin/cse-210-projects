using System;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a list of numbers, type 0 when finished. \n");

        List<int> seriesNumbers = new List<int>();

        int number = 1;

        while (number != 0)
        {
            Console.Write("Enter  number: ");
            number = int.Parse(Console.ReadLine());



            if (number != 0)
            {
                seriesNumbers.Add(number);
                var result_set = seriesNumbers.OrderBy(num => num);
            }

            foreach (int num in seriesNumbers)
            {

            }
        }

        int sum = 0;

        foreach (int num in seriesNumbers)
        {
            sum += num;
        }
        Console.Write($"The sum is: {sum}");

        float average = (float)sum / seriesNumbers.Count;
        Console.Write($"\nThe average is: {average}");

        int max = seriesNumbers[0];

        foreach (int num in seriesNumbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        int min = int.MaxValue;

        foreach (int num in seriesNumbers)
        {
            if (num > 0 && num < min)
            {
                min = num;
            }
        }

        Console.Write($"\nThe largest number is: {max}");
        Console.Write($"\nThe smallest positive number is: {min}");


        Console.WriteLine("\nThe sorted list is: ");
        foreach (int num in seriesNumbers.OrderBy(n => n))
        {
            Console.WriteLine($"{num} ");
        }
    }
}
