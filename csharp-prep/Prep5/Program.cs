using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program!");

        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Please enter your favorite number: ");
        double favNumber = double.Parse(Console.ReadLine());

        double favNumberSqrt = Math.Sqrt(favNumber);

        Console.WriteLine($"Brother {name}, the square root of your favorite number is {favNumberSqrt}");
    }
}
