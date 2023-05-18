using System;
using System.Collections.Generic;

public class Fraction
{
	private int _top = 0;
	private int _bottom = 0;

	public Fraction()
	{
		_top = 1;
		_bottom = 1;
	}

	public Fraction(int wholeNumber)
	{
		_top = wholeNumber;
		_bottom = 1;
	}

	public Fraction(int top, int bottom)
	{
		_top = top;
		_bottom = bottom;
	}

	public string GetFractionString()
	{
		string text = $"{_top}/{_bottom}";
		return text;
	}

	public double GetDecimalValue()
	{
		return (double)_top / (double)_bottom;
	}
}