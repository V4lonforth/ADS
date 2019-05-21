using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.DivideAndRule
{
    public class BinarySearch
    {
        private int[] array;

        public BinarySearch(int[] array)
        {
            this.array = array;
        }

        public int Find(int value)
        {
            int left = -1;
            int right = array.Length - 1;
            while (left != right - 1)
            {
                int middle = (right + left) / 2;
                if (value > array[middle])
                    left = middle;
                else
                    right = middle;
            }
            if (array[right] != value)
                return -1;
            return right + 1;
        }
    }

    public class BinarySearchTask
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = int.Parse(str[0]);
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = int.Parse(str[i + 1]);

            BinarySearch BinarySearch = new BinarySearch(array);
            str = Console.ReadLine().Split(' ');
            n = int.Parse(str[0]);
            array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = BinarySearch.Find(int.Parse(str[i + 1]));
            
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", array[i]);
        }
    }
}
