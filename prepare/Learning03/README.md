# Fraction Program

This program demonstrates the use of the `Fraction` class by creating instances of the class and outputting their string representation and decimal value.

## Classes

The program consists of two classes: `Fraction` and `Program`.

### Fraction

The `Fraction` class represents a fraction with a numerator and denominator. It has three constructors: a default constructor that creates a fraction with numerator and denominator equal to 1, a constructor that takes a whole number as an argument and creates a fraction representing that whole number, and a constructor that takes two arguments representing the numerator and denominator of the fraction.

The class also has two public methods: `GetFractionString` which returns a string representation of the fraction in the form "numerator/denominator", and `GetDecimalValue` which returns the decimal value of the fraction as a double.

### Program

The `Program` class contains the `Main` method which is the entry point of the console application. In this method, several instances of the `Fraction` class are created using different constructors. The `GetFractionString` and `GetDecimalValue` methods are then called on each instance to output their string representation and decimal value.

## Usage

To use the program, compile and run the `Program.cs` file. The program will create instances of the `Fraction` class with different constructors and output their string representation and decimal value.
