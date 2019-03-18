using System;
using System.IO;

namespace ADS.Week3
{
    public class Task1
    {
        private static int GetRadixValue(int number, int radixSize, int radixNumber)
        {
            return (number >> (radixSize * radixNumber)) & ((1 << radixSize) - 1);
        }
        private static void RadixSort(int[] array, int radixSize = 8)
        {
            int radixCount = sizeof(int) * 8 / radixSize;
            int[] count = new int[1 << radixSize];
            int[] buffer = new int[array.Length];

            for (int i = 0; i < radixCount; i++)
            {
                Array.Clear(count, 0, count.Length);
                for (int j = 0; j < array.Length; j++)
                {
                    count[GetRadixValue(array[j], radixSize, i)]++;
                }
                for (int j = 1; j < count.Length; j++)
                {
                    count[j] += count[j - 1];
                }
                for (int j = array.Length - 1; j >= 0; j--)
                {
                    int radixValue = GetRadixValue(array[j], radixSize, i);
                    count[radixValue]--;
                    buffer[count[radixValue]] = array[j];
                }
                Array.Copy(buffer, array, array.Length);
            }
        }

        private static void main(string[] args)
        {
            int n, m;
            int[] array1, array2;
            using (StreamReader streamReader = new StreamReader("input.txt"))
            {
                string[] str = streamReader.ReadLine().Split(' ');
                n = int.Parse(str[0]);
                m = int.Parse(str[1]);
                
                array1 = new int[n];
                str = streamReader.ReadLine().Split(' ');
                for (int i = 0; i < n; i++)
                {
                    array1[i] = int.Parse(str[i]);
                }
                array2 = new int[m];
                str = streamReader.ReadLine().Split(' ');
                for (int i = 0; i < m; i++)
                {
                    array2[i] = int.Parse(str[i]);
                }
            }

            int[] array = new int[n * m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i * m + j] = array1[i] * array2[j];
                }
            }

            RadixSort(array);

            long sum = 0;
            for (int i = 0; i < array.Length; i += 10)
            {
                sum += array[i];
            }
            using(StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                streamWriter.Write(sum);
            }
        }
    }
}