using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your second name? ");
        string secondName = Console.ReadLine();

        Console.WriteLine($"Your name is {secondName}, {firstName} {secondName}.");
    }
}