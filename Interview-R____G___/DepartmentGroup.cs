using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Test
{
	public static void Main()
	{
        var input = Console.ReadLine();
        var jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(input);
        List<int> distinctNumber = jsonData.GroupBy(x => x.Value.Count).Select(x => x.Key).ToList();
        List<int> orderedDistinctNumber = (from item in distinctNumber orderby item select item).ToList();

        var list = new ArrayList();
        foreach (var alpha in orderedDistinctNumber)
        {
            list.Add(jsonData.Where(x => x.Value.Count == alpha).Select(y => y.Key).ToList());
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < orderedDistinctNumber.Count; i++)
        {
            if (i == 0)
            {
                sb.Append("[");
            }

            sb.Append("[");
            for (int j = 0; j < ((List<string>)list[i]).Count; j++)
            {

                sb.Append("\"" + ((List<string>)list[i])[j] + "\"");
                if (j != ((List<string>)list[i]).Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            if (i == orderedDistinctNumber.Count - 1)
            {
                sb.Append("]");
            }
            else
            {
                sb.Append(", ");
            }
        }
        Console.WriteLine(sb.ToString());
	}
}
/*
Sample Input
{"general": [2, 3, 4], "infra": [3, 5], "humor": [4, 6]}

Sample Output
[["infra", "humor"], ["general"]]
*/