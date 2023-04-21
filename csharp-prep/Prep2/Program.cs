using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);
        string letter = "";
        string sign = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else {
            letter = "F";
        }

        if (grade >= 70)
        {
            if (grade % 10 >= 7)
            {
                sign = "+";
                if (grade >= 90 || grade < 60)
                {
                    sign = "";
                }
            }
            else {
                sign = "-";
            }

            Console.WriteLine("Congratulations! You've passed! ");
            Console.WriteLine($"{letter}{sign}");
        }
        else {
            Console.WriteLine($"{letter}{sign}");
            Console.WriteLine("Sorry, you've not passed. Try again the next time. ");
        }
    }
}