using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // First I need to create a list of type "int" to hold the numbers and do the math at the end.
        string loop = "true";
        List<int> numbers = new List<int>();

        do {
            Console.WriteLine();
            Console.WriteLine("Enter a list of numbers, type 0 when finished. ");
            Console.WriteLine("Enter a number: ");
            // At first, the user input will be a "string". I need to convert it to "int" to do the math:
            string input = Console.ReadLine();
            int number = int.Parse(input);

            // As soon as the user don't type "0", the program keeps adding all inputs to the list.
            if (number != 0) {
                numbers.Add(number);
            }
            else {
                // When the user types "0", it's time to do the math and print the results.
                int sum = numbers.Sum();
                double average = numbers.AsQueryable().Average();
                int maxNumber = numbers.Max();
                int closestPositive = numbers
                .Where(n => n >= 0)
                .OrderBy(n => n)
                .FirstOrDefault();
                numbers.Sort();

                // Display the results, sort all numbers, and ends the loop.
                Console.WriteLine();
                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {average}");
                Console.WriteLine($"The largest number is: {maxNumber}");
                Console.WriteLine($"The smallest positive number is: {closestPositive}");
                Console.WriteLine($"The sorted list is: ");
                for (int i = 0; i <numbers.Count; i++)
                {
                    Console.WriteLine(numbers[i]);
                }

                loop = "false";
            }
        } while (loop == "true");
    }
}