using System;
using System.Collections.Generic;
using System.Linq;

public class Main
{
	public static void Main()
	{
        string inputNumber = Console.ReadLine();
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        for (int i = 1; i <= Convert.ToInt32(inputNumber); i++)
        {
            var inputLine1 = Console.ReadLine();
            var firstLine = inputLine1.Split(' ').ToList();
            int L = Convert.ToInt32(firstLine[0]);
            int M = Convert.ToInt32(firstLine[1]);
            int N = Convert.ToInt32(firstLine[2]);

            var inputLine2 = Console.ReadLine();
            var secondLine = inputLine2.Split(' ').ToList();
            secondLine = secondLine.Take(N).ToList();

            int totalL = 0;
            int totalM = 0;
            List<int> numberTemp = new List<int>();
            for (int j = 0; j < N; j++)
            {
                int number = Convert.ToInt32(secondLine[j]);
                numberTemp.Add(number);
                if (j != N - 1)
                {
                    totalL += number;
                    totalM = totalL > M ? totalM + 1 : totalM;
                }
            }
            int check = numberTemp.TakeLast(L).Sum();
            totalM = check > M ? totalM + 1 : totalM;
            dictionary.Add(i, totalM);
        }

        foreach (var kvp in dictionary)
        {
            Console.WriteLine("Case #" + kvp.Key + ": " + kvp.Value);
        }
	}
}

/* 
Sample input
3
7 10 8
6 0 0 1 5 1 1 0
7 10 7
1 1 1 1 1 1 1
3 9 7
3 3 3 4 3 3 3

Sample output
Case #1: 3
Case #2: 0
Case #3: 3
*/