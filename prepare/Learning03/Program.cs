using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac = new Fraction();
        Console.WriteLine(frac.GetFractionString());
        Console.WriteLine(frac.GetDecimalValue());

        Fraction frac2 = new Fraction(5);
        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        Fraction frac3 = new Fraction(3, 4);
        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());

        Fraction frac4 = new Fraction(1, 3);
        Console.WriteLine(frac4.GetFractionString());
        Console.WriteLine(frac4.GetDecimalValue());
    }
}