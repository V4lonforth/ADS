using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.DynamicProgramming
{
    public class RedactionDistanceTask
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            int[,] table = new int[str2.Length + 1, str1.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
                table[0, i] = i;
            for (int i = 0; i <= str2.Length; i++)
                table[i, 0] = i;

            for (int j = 1; j <= str2.Length; ++j) {
                for (int i = 1; i <= str1.Length; ++i) {
                    int c = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
                    int min = Math.Min(Math.Min(table[j, i - 1] + 1, table[j - 1, i] + 1), table[j - 1, i - 1] + c);
                    table[j, i] = min;
                }
            }
            Console.WriteLine(table[str2.Length, str1.Length]);
        }
    }
}
