using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.DynamicProgramming
{
    public struct Element
    {
        public int Previous { get; }
        public int Length { get; }

        public Element(int previous, int length)
        {
            Previous = previous;
            Length = length;
        }
    }
    public class CalculatorTask
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Element[] array = new Element[n + 1];

            for (int i = 2; i <= n; i++)
            {
                array[i] = new Element(i - 1, array[i - 1].Length + 1);
                if (i % 2 == 0 && array[i / 2].Length + 1 < array[i].Length)
                    array[i] = new Element(i / 2, array[i / 2].Length + 1);
                if (i % 3 == 0 && array[i / 3].Length + 1 < array[i].Length)
                    array[i] = new Element(i / 3, array[i / 3].Length + 1);
            }
            Console.WriteLine(array[n].Length);
            Stack<int> stack = new Stack<int>();
            while (n > 0)
            {
                stack.Push(n);
                n = array[n].Previous;
            }
            while (stack.Count > 0)
                Console.Write("{0} ", stack.Pop());
        }
    }
}
