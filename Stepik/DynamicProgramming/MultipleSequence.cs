using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.DynamicProgramming
{
    public class SequenceTask
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = int.Parse(str[i]);

            int[] sequences = new int[array.Length];
            for (int i = 0; i < sequences.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[i] % array[j] == 0)
                        sequences[i] = Math.Max(sequences[i], sequences[j] + 1);
                }
            }
            int max = 0;
            for (int i = 1; i < sequences.Length; i++)
                max = Math.Max(max, sequences[i]);
            Console.WriteLine(max + 1);
        }
    }
}
