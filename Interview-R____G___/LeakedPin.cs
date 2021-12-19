using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Main
{
	public static void Main()
	{
		string inputNumber = Console.ReadLine();
        var dict = new Dictionary<int, List<string>>();
        for (int i = 1; i <= Convert.ToInt32(inputNumber); i++)
        {
            var line = Console.ReadLine();
            var data = line.Split(' ').ToList();
            int N = Convert.ToInt32(data[0]);
            int hash = Convert.ToInt32(data[1]);

            List<string> candidate = new List<string>();
            int maxDigit = Convert.ToInt32(Math.Pow(10, N));
            for (int j = 0; j < maxDigit; j++)
            {
                int value = HashFunction(j);
                if (hash == value)
                {
                    StringBuilder val = new StringBuilder();
                    int lengthCandidate = j.ToString().Length;
                    if (lengthCandidate < N)
                    {
                        for (int k = 0; k < N - lengthCandidate; k++)
                        {
                            val.Append("0");
                        }
                        val = val.Append(j);
                    }
                    else
                    {
                        val = val.Append(j);
                    }
                    candidate.Add(val.ToString());
                }
            }
            dict.Add(i, candidate.Count > 0 ? candidate : new List<string> { "Invalid" });
        }

        int count = 1;
        foreach (var kvp in dict) 
        {
            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("Case #" + count++ + ": ");
            sbOut.Append(string.Join(" ", kvp.Value));
            Console.WriteLine(sbOut.ToString());
        }
	}
	
	public static int HashFunction(int k) 
    {
        return (k * (k + 3)) % 1000003;
    }
}
/* 
Sample input
5
1 28
2 18
4 10300
6 10300
1 5

Sample output
Case #1: 4
Case #2: 03
Case #3: 0100
Case #4: 000100 691735
Case #5: Invalid
*/