using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'alternate' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int alternate(string s)
    {
          var uniqueChars = s.Distinct().ToList();
        int maxLength = 0;

        
        for (int i = 0; i < uniqueChars.Count; i++)
        {
            for (int j = i + 1; j < uniqueChars.Count; j++)
            {
                char c1 = uniqueChars[i];
                char c2 = uniqueChars[j];

                
                var filtered = s.Where(c => c == c1 || c == c2).ToList();

                
                bool isValid = true;
                for (int k = 1; k < filtered.Count; k++)
                {
                    if (filtered[k] == filtered[k - 1])
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                    maxLength = Math.Max(maxLength, filtered.Count);
            }
        }

        return maxLength;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int l = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int result = Result.alternate(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
