using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        string loop = "true";
        int guesses = 0;

        while (loop == "true")
        {    
            Console.WriteLine("What is your guess? ");
            string input = Console.ReadLine();
            int numberGuess = int.Parse(input);

            if (numberGuess < magicNumber)
            {
                Console.WriteLine();
                Console.WriteLine("Higher. ");
                guesses += 1;
            }
            else if (numberGuess > magicNumber)
            {
                Console.WriteLine();
                Console.WriteLine("Lower. ");
                guesses += 1;
            }
            else
            {
                Console.WriteLine("You guessed it! ");
                Console.WriteLine();
                Console.WriteLine($"You tried {guesses} times. ");
                Console.WriteLine("You want to play again? [y/n] ");
                string response = Console.ReadLine();
                if (response == "y")
                    {
                        Console.WriteLine();
                        loop = "true";
                        magicNumber = randomGenerator.Next(1, 100);
                    }
                else if (response == "n")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Thank you for playing. See you at the next time :)");
                        loop = "false";
                    }
                else
                    {
                        Console.WriteLine("Wrong input, start the program again.");
                        loop = "false";
                    }
            }
        
        }
    }
}