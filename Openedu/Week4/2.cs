using System;
using System.IO;
using System.Collections.Generic;

namespace ADS.Week4
{
    public class Queue<T>
    {
        private List<T> elements;

        private int removedElements;

        private const int maxRemovedElements = 1000;
        public Queue()
        {
            elements = new List<T>();
            removedElements = 0;
        }
        public void Push(T element)
        {
            elements.Add(element);
        }
        public T Pop()
        {
            T element = elements[removedElements];
            removedElements++;
            if (removedElements >= maxRemovedElements)
            {
                elements.RemoveRange(0, removedElements);
                removedElements = 0;
            }
            return element;
        }
    }
    public class Task2
    {
        public static void Main(string[] args)
        {
            int n;
            Queue<int> queue = new Queue<int>();
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                n = int.Parse(streamReader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    String[] str = streamReader.ReadLine().Split(' ');
                    if ("+".Equals(str[0]))
                    {
                        queue.Push(int.Parse(str[1]));
                    }
                    else
                    {
                        streamWriter.WriteLine(queue.Pop());
                    }
                }
            }
        }
    }
}