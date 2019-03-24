using System;
using System.IO;
using System.Collections.Generic;

namespace ADS.Week4
{
    public class Queue<T>
    {
        private class LinkedElement
        {
            public T Value { get; set; }
            public LinkedElement NextElement { get; set; }

            public LinkedElement(T value)
            {
                Value = value;
            }
        }
        private LinkedElement first;
        private LinkedElement last;

        public void Enqueue(T element)
        {
            LinkedElement newElement = new LinkedElement(element);
            if (first != null)
                first.NextElement = newElement;
            else
                last = newElement;
            first = newElement;
        }
        public T Dequeue()
        {
            T value = last.Value;
            last = last.NextElement;
            if (last == null)
                first = null;
            return value;
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
                        queue.Enqueue(int.Parse(str[1]));
                    }
                    else
                    {
                        streamWriter.WriteLine(queue.Dequeue());
                    }
                }
            }
        }
    }
}