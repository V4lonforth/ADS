using System;
using System.IO;
using System.Collections.Generic;

namespace ADS.Week4
{
    public class PriorityQueue : Queue<int>
    {
        private LinkedList<int> minimums;

        public int Minimum { get { return minimums.Last.Value; } }

        public PriorityQueue() : base()
        {
            minimums = new LinkedList<int>();
        }

        new public void Enqueue(int element)
        {
            base.Enqueue(element);
            while (minimums.Count > 0 && minimums.First.Value > element)
            {
                minimums.RemoveFirst();
            }
            minimums.AddFirst(element);
        }
        new public int Dequeue()
        {
            int value = base.Dequeue();
            if (minimums.Last.Value == value)
                minimums.RemoveLast();
            return value;
        }
    }

    public class Task4
    {
        public static void Main(string[] args)
        {
            int n;
            PriorityQueue queue = new PriorityQueue();
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                n = int.Parse(streamReader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    String[] str = streamReader.ReadLine().Split(' ');
                    switch (str[0])
                    {
                        case "+":
                            queue.Enqueue(int.Parse(str[1]));
                            break;
                        case "-":
                            queue.Dequeue();
                            break;
                        case "?":
                            streamWriter.WriteLine(queue.Minimum);
                            break;
                    }
                }
            }
        }
    }
}