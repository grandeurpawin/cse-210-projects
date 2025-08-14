using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        {
            Square s1 = new Square("Red", 5);
            shapes.Add(s1);

            Circle s2 = new Circle("Blue", 3);
            shapes.Add(s2);

            Rectangle s3 = new Rectangle("Green", 4, 6);
            shapes.Add(s3);
        };

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shapes has an area of {area}.");
        }
    }
}