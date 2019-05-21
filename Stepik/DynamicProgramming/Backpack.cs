using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.DynamicProgramming
{
    public class BackpackTask
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int w = int.Parse(str[0]);
            int n = int.Parse(str[1]);

            str = Console.ReadLine().Split(' ');
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = int.Parse(str[i]);

            int[,] weights = new int[w + 1, n + 1];
            for (int i = 1; i <= n; ++i) 
            {
                for (int j = 1; j <= w; ++j) 
                {
                    if (array[i - 1] > j) 
                        weights[j, i] = weights[j, i - 1];
                    else 
                        weights[j, i] = Math.Max(weights[j, i - 1], weights[j - array[i - 1], i - 1] + array[i - 1]);
                }
            }
            Console.WriteLine(weights[w, n]);
        }
    }
}
