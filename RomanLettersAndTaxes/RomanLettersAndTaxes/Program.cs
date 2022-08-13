using System;

public static class RomanLettersAndTaxes
{
	public static string NumberToRomanLetters(int num)
	{
		string romanResult = string.Empty;
		string[] romanLetters = {
			"M",
			"CM",
			"D",
			"CD",
			"C",
			"XC",
			"L",
			"XL",
			"X",
			"IX",
			"V",
			"IV",
			"I"
		};
		int[] numbers = {
			1000,
			900,
			500,
			400,
			100,
			90,
			50,
			40,
			10,
			9,
			5,
			4,
			1
		};
		var iterator = 0;
		while (num != 0)
		{
			if (num >= numbers[iterator])
			{
				num -= numbers[iterator];
				romanResult += romanLetters[iterator];
			}
			else
			{
				iterator++;
			}
		}
		return romanResult;
	}

	public static double GetTaxes(double salary)
	{
		double tax = 0;
		double[] paymentThresholds = {
			1.0,
			5071.0,
			8661.0,
			14071.0,
			21241.0,
			40231.0,
		};
		int[] taxes = {
			10,
			14,
			23,
			30,
			33,
			45,
		};
		var lengthOfPaymentThresholds = paymentThresholds.Length;
		for (var thresholdIterator = 1; thresholdIterator < paymentThresholds.Length; thresholdIterator++)
		{
			if (salary >= paymentThresholds[thresholdIterator - 1])
			{
				if (salary > paymentThresholds[thresholdIterator])
				{
					tax += (double)((paymentThresholds[thresholdIterator] - paymentThresholds[thresholdIterator - 1]) * taxes[thresholdIterator - 1] / 100);
				}
				else
				{
					var difference = salary - paymentThresholds[thresholdIterator - 1] + 1;
					tax += (double)(difference * taxes[thresholdIterator - 1] / 100);
				}
			}
		}
		if (paymentThresholds[lengthOfPaymentThresholds - 1] < salary)
		{
			var difference = salary - paymentThresholds[lengthOfPaymentThresholds - 1] + 1;
			tax += (double)(difference * taxes[lengthOfPaymentThresholds - 1] / 100);
			Console.WriteLine(difference);
		}
		return tax;
	}
}
public class Program
{
	public static void Main()
	{
		//Console.WriteLine(RomanLettersAndTaxes.NumberToRomanLetters(2010));
		Console.WriteLine(RomanLettersAndTaxes.GetTaxes(9000).ToString());
	}
}