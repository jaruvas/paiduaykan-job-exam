using System;
using System.Collections.Generic;
					
public class OptionalTest
{
	public static void Main()
	{
		Console.WriteLine("Input");
		string str = Console.ReadLine();
		Console.WriteLine("Output");
		string[] strArr = str.Split(' ');
		if (strArr.Length == 4) {
			if (int.Parse(strArr[0]) >= 1) {
				int woodLong = int.Parse(strArr[0]);
				List<int> woodList = new List<int>();
				woodList.Add(int.Parse(strArr[1]));
				woodList.Add(int.Parse(strArr[2]));
				woodList.Add(int.Parse(strArr[3]));
				woodList.Sort((a,b) => a - b);
				int i = 0;
				woodList.ForEach(e => {
					if (woodLong >= e && e <= 4000) {
						woodLong -= e;
						i++;
					}
				});
				Console.WriteLine(i);
			}
		}
	}
}