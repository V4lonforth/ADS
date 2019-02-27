using System;
using System.IO;

namespace ADS
{
    class Program
    {
        private static StreamReader streamReader;
        private static StreamWriter streamWriter;
        
        public static void Quicksort(int[] elements, int left, int right, int k1, int k2)
        {
            if (left > k2 - 1 || right < k1 - 1)
                return;

            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(elements, left, j, k1, k2);
            }
            if (i < right)
            {
                Quicksort(elements, i, right, k1, k2);
            }
        }

        static void Main(string[] args)
        {
            streamReader = new StreamReader("input.txt");
            streamWriter = new StreamWriter("output.txt");

            string[] str = streamReader.ReadLine().Split(' ');
            int n = Convert.ToInt32(str[0]);
            int k1 = Convert.ToInt32(str[1]);
            int k2 = Convert.ToInt32(str[2]);

            str = streamReader.ReadLine().Split(' ');
            int A = Convert.ToInt32(str[0]);
            int B = Convert.ToInt32(str[1]);
            int C = Convert.ToInt32(str[2]);

            int[] array = new int[n];
            array[0] = Convert.ToInt32(str[3]);
            array[1] = Convert.ToInt32(str[4]);
            for (int i = 2; i < n; i++)
            {
                array[i] = A * array[i - 2] + B * array[i - 1] + C;
            }

            Quicksort(array, 0, n - 1, k1, k2);
            for (int i = k1; i <= k2; i++)
            {
                streamWriter.Write("{0} ", array[i - 1]);
            }
            streamReader.Close();
            streamWriter.Close();
        }
    }
}
