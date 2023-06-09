using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("◜");
        Thread.Sleep(800);
        Console.Write("\b \b"); // Erase the + character
        Console.Write("◝"); // Replace it with the - character
        Thread.Sleep(800);
        Console.Write("\b \b");
        Console.Write("◞");
        Thread.Sleep(800);
        Console.Write("\b \b");
        Console.Write("◟");

    }
}