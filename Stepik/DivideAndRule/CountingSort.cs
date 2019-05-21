using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.DivideAndRule
{
    public class CountingSorter
    {
        private int[] array;

        public CountingSorter(int[] array)
        {
            this.array = array;
        }

        public int[] Sort(int max)
        {
            int[] buffer = new int[max + 1];

            for (int i = 0; i < array.Length; i++)
                buffer[array[i]]++;
            
            int currentSize = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                while (buffer[i] > 0)
                {
                    array[currentSize] = i;
                    buffer[i]--;
                    currentSize++;
                }
            }

            return array;
        }
    }

    public class CountingSortTask
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');
            int[] array = new int[n];
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(str[i]);
                max = Math.Max(max, array[i]);
            }

            CountingSorter sorter = new CountingSorter(array);
            array = sorter.Sort(max);

            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array[i]);
        }
    }
}
