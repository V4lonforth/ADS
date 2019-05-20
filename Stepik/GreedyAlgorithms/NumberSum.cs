using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.GreedyAlgorithms
{
    public class Number
    {
        private int number;

        public Number(int number)
        {
            this.number = number;
        }

        public List<int> GetSum()
        {
            int sumLeft = number;
            List<int> sum = new List<int>();
            int currentNumber = 1;

            while (sumLeft > 0)
            {
                if (currentNumber * 2 < sumLeft)
                {
                    sumLeft -= currentNumber;
                    sum.Add(currentNumber);
                    currentNumber++;
                }
                else
                {
                    sum.Add(sumLeft);
                    sumLeft = 0;
                }
            }
            return sum;
        }
    }
    public class NumberSumTask
    {
        static void Main(string[] args)
        {
            Number number = new Number(int.Parse(Console.ReadLine()));

            List<int> sum = number.GetSum();
            Console.WriteLine(sum.Count);
            for (int i = 0; i < sum.Count; i++)
                Console.Write("{0} ", sum[i]);
        }
    }
}
