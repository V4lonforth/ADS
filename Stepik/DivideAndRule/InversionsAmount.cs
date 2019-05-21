using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.DivideAndRule
{
    public class InversionsAmount
    {
        private int[] array;

        public InversionsAmount(int[] array)
        {
            this.array = array;
        }

        private long MergeArrays(int[] bufferArray, int firstArrayBegin, int firstArrayEnd, int secondArrayBegin, int secondArrayEnd)
        {
            int sortedAmount = 0;
            int begin = firstArrayBegin;

            long inversionsAmount = 0;

            while (firstArrayBegin <= firstArrayEnd && secondArrayBegin <= secondArrayEnd)
            {
                if (array[firstArrayBegin] <= array[secondArrayBegin])
                {
                    bufferArray[sortedAmount] = array[firstArrayBegin];
                    firstArrayBegin++;
                }
                else
                {
                    bufferArray[sortedAmount] = array[secondArrayBegin];
                    secondArrayBegin++;
                    inversionsAmount += firstArrayEnd - firstArrayBegin + 1;
                }
                sortedAmount++;
            }
            for (int i = firstArrayBegin; i <= firstArrayEnd; i++)
            {
                bufferArray[sortedAmount] = array[i];
                sortedAmount++;
            }
            for (int i = secondArrayBegin; i <= secondArrayEnd; i++)
            {
                bufferArray[sortedAmount] = array[i];
                sortedAmount++;
            }

            Array.Copy(bufferArray, 0, array, begin, sortedAmount);
            return inversionsAmount;
        }

        public long Sort()
        {
            int[] bufferArray = new int[array.Length];
            long inversionsAmount = 0;
            int sortSize = 2;

            while (sortSize < array.Length * 2)
            {
                int firstArrayBegin = 0;
                while (firstArrayBegin < array.Length)
                {
                    int secondArrayEnd = firstArrayBegin + sortSize - 1;

                    int firstArrayEnd = (firstArrayBegin + secondArrayEnd) / 2 - (firstArrayBegin + secondArrayEnd + 1) % 2;
                    int secondArrayBegin = firstArrayEnd + 1;

                    if (secondArrayBegin < array.Length)
                    {
                        if (secondArrayEnd >= array.Length)
                            secondArrayEnd = array.Length - 1;
                        inversionsAmount += MergeArrays(bufferArray, firstArrayBegin, firstArrayEnd, secondArrayBegin, secondArrayEnd);
                    }
                    firstArrayBegin += sortSize;
                }
                sortSize *= 2;
            }
            return inversionsAmount;
        }
    }

    public class InversionsAmountTask
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            string[] str = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
                array[i] = int.Parse(str[i]);

            InversionsAmount inversionsAmount = new InversionsAmount(array);
            Console.WriteLine(inversionsAmount.Sort());
        }
    }
}
