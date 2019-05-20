using System;
using System.IO;
using System.Collections.Generic;

namespace Stepik.GreedyAlgorithms
{
    public class PriorityQueue
    {
        public int Size { get { return elements.Count; } }
        private List<int> elements;

        public PriorityQueue(int baseSize = 1000000)
        {
            elements = new List<int>(baseSize);
        }

        public void Enqueue(int value)
        {
            elements.Add(value);
            LiftElement(Size - 1);
        }
        public int Dequeue()
        {
            int value = elements[0];
            Swap(0, Size - 1);
            elements.RemoveAt(Size - 1);
            Heapify(0);
            return value;
        }
        private void LiftElement(int index)
        {
            int parentIndex = (index + 1) / 2 - 1;
            while (index > 0 && elements[parentIndex] < elements[index])
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index + 1) / 2 - 1;
            } 
        }

        private void Heapify(int index)
        {
            int leftIndex = (index + 1) * 2 - 1;
            int rightIndex = leftIndex + 1;
            int minIndex;
            if (leftIndex < elements.Count && elements[leftIndex] > elements[index])
                minIndex = leftIndex;
            else
                minIndex = index;
            if (rightIndex < elements.Count && elements[rightIndex] > elements[minIndex])
                minIndex = rightIndex;
            if (index != minIndex)
            {
                Swap(index, minIndex);
                Heapify(minIndex);
            }
        }

        private void Swap(int index1, int index2)
        {
            int buf = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = buf;
        }
    }
    public class PriorityQueueTask
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PriorityQueue queue = new PriorityQueue(n);
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ');

                switch(cmd[0])
                {
                    case "Insert":
                        queue.Enqueue(int.Parse(cmd[1]));
                        break;
                    case "ExtractMax":
                        if (queue.Size > 0)
                            Console.WriteLine(queue.Dequeue());
                        else
                            Console.WriteLine('*');
                        break;
                }
            }
        }
    }
}