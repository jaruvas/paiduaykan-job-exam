using System;
					
public class Nrgb
{
	public static void Main()
	{
		Console.WriteLine("Input");
		int n;

		while(!int.TryParse(Console.ReadLine(), out n))
		{
     		Console.Clear();
     		Console.WriteLine("You entered an invalid number");
			Console.WriteLine("Input");
		}
		string str = "";
		str = Console.ReadLine();
     	Console.WriteLine("Output");
		if (str.Length > n) {
			str = str.Substring(0, n);
		}
		int gCount = (str.Length - str.Replace("GG", "").Length) / 2;
		int rCount = (str.Length - str.Replace("RR", "").Length) / 2;
		int bCount = (str.Length - str.Replace("BB", "").Length) / 2;
		Console.WriteLine(gCount + rCount + bCount);
	}
}