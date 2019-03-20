using System;
using System.IO;
using System.Collections.Generic;

namespace ADS.Week4
{
    public class Stack<T>
    {
        private List<T> elements;

        public int Size
        {
            get 
            {
                return elements.Count;
            }
        }

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
    public class Task3
    {
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                int n = int.Parse(streamReader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Stack<char> stack = new Stack<char>();
                    String sequence = streamReader.ReadLine();
                    bool result = true;
                    for (int j = 0; j < sequence.Length; j++)
                    {
                        switch(sequence[j])
                        {
                            case '(':
                                stack.Push('(');
                                break;
                            case '[':
                                stack.Push('[');
                                break;
                            case ']':
                                if (stack.Pop() != '[')
                                    result = false;
                                break;
                            case ')':
                                if (stack.Pop() != '(')
                                result = false;
                                break;
                        }
                    }
                    streamWriter.WriteLine((result && stack.Size == 0) ? "YES" : "NO");
                }
            }
        }
    }
}