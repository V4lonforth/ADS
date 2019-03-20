using System;
using System.IO;
using System.Collections.Generic;

namespace ADS.Week4
{
    public class Stack<T>
    {
        private List<T> elements;

        public Stack()
        {
            elements = new List<T>();
        }
        public void Push(T element)
        {
            elements.Add(element);
        }
        public T Pop()
        {
            T element = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return element;
        }
    }
    public class Task1
    {
        public static void Main(string[] args)
        {
            int n;
            Stack<int> stack = new Stack<int>();
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                n = int.Parse(streamReader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    String[] str = streamReader.ReadLine().Split(' ');
                    if ("+".Equals(str[0]))
                    {
                        stack.Push(int.Parse(str[1]));
                    }
                    else
                    {
                        streamWriter.WriteLine(stack.Pop());
                    }
                }
            }
        }
    }
}