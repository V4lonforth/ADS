using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.DynamicProgramming
{
    public class StairsTask
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = int.Parse(str[i]);
            
            if (n > 1)
                array[1] = Math.Max(array[1], array[0] + array[1]);
            if (n > 2)
                for (int i = 2; i < n; i++)
                    array[i] += Math.Max(array[i - 1], array[i - 2]);

            Console.WriteLine(array[n - 1]);
        }
    }
}
