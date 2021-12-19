using System;
using System.Collections.Generic;
using System.Linq;

public class Main
{
	public static void Main()
	{
        string inputNumber = Console.ReadLine();
        Dictionary<int, List<string>> dictionaryTemp = new Dictionary<int, List<string>>();
        for (int i = 1; i <= Convert.ToInt32(inputNumber); i++)
        {
            var inputLine = Console.ReadLine();
            var urlCollection = inputLine.Split(' ').ToList();
            List<string> listTemp = new List<string>();
            for (int j = 0; j < urlCollection.Count; j++)
            {
                var urlDomain = urlCollection[j].Split('/')[0];
                listTemp.Add(urlDomain);
            }
            dictionaryTemp.Add(i, listTemp);
        }

        Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
        foreach (var a in dictionaryTemp)
        {
            dictionary.Add(a.Key, a.Value.Distinct().ToList());
        }

        foreach (var kvp in dictionary)
        {
            Console.WriteLine("Case #" + kvp.Key + ": " + kvp.Value.Count);
        }
	}
}
/* 
Sample Input
2
www.google.com www.google.com/id www.google.co.id www.google.co.id/account www.akademiseru.com/ruangbelajar roboakademi.akademiseru.com roboakademi.akademiseru.com/faq
www.google.com www.google.com/id www.google.com/id/account www.google.com/id/account/reset www.google.com/id/account/forget_password

Sample Output
Case #1: 4
Case #2: 1
*/