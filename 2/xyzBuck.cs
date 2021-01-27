using System;
					
public class XyzBuck
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
     	Console.WriteLine("Output");
		int result = (n / 20);
		result += (n % 20) / 10;
		result += ((n % 20) % 10) / 5;
		result += (((n % 20) % 10) % 5) / 1;
		Console.WriteLine(result);
	}
}