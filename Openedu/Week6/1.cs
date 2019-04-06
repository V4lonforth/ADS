using System;
using System.IO;

namespace ADS.Week6
{
    public class Task1
    {
        public static int BinarySearch(int[] array, int value, int left, int right)
        {
            left--;
            while (left != right - 1)
            {
                int middle = (right + left) / 2;
                if (value > array[middle])
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }
            return right;
        }

        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                int n = int.Parse(streamReader.ReadLine());
                int[] array = new int[n];
                string[] str = streamReader.ReadLine().Split(' ');
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(str[i]);
                }
                int m = int.Parse(streamReader.ReadLine());
                str = streamReader.ReadLine().Split(' ');
                for (int i = 0; i < m; i++)
                {
                    int value = int.Parse(str[i]);
                    int leftIndex = BinarySearch(array, value, 0, array.Length - 1);
                    if (array[leftIndex] == value)
                    {
                        int rightIndex = BinarySearch(array, value + 1, leftIndex, array.Length - 1);
                        if (array[rightIndex] != value)
                        {
                            rightIndex--;
                        }
                        streamWriter.WriteLine("{0} {1}", leftIndex + 1, rightIndex + 1);
                    }
                    else
                    {
                        streamWriter.WriteLine("-1 -1");
                    }
                }
            }
        }
    }
}