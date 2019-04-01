using System;
using System.IO;
using System.Collections.Generic;

namespace ADS.Week5
{
    public class PriorityQueue
    {
        public class Element
        {
            public int Value { get; set; }
            public int Index { get; set; }
            public Element(int value, int index)
            {
                Value = value;
                Index = index;
            }
        }

        public int Size { get => elements.Count; }
        private List<Element> elements;
        private Dictionary<int, Element> operations;

        public PriorityQueue(int baseSize = 1000000)
        {
            elements = new List<Element>(baseSize);
            operations = new Dictionary<int, Element>();
        }

        public void Enqueue(int operationNumber, int value)
        {
            Element element = new Element(value, elements.Count);
            elements.Add(element);
            operations.Add(operationNumber, element);
            LiftElement(Size - 1);
        }
        public int Dequeue()
        {
            int value = elements[0].Value;
            Swap(0, Size - 1);
            elements.RemoveAt(Size - 1);
            Heapify(0);
            return value;
        }
        public void DecreaseValue(int operationNumber, int value)
        {
            Element element = operations[operationNumber];
            element.Value = value;
            LiftElement(element.Index);
        }
        private void LiftElement(int index)
        {
            int parentIndex = (index + 1) / 2 - 1;
            while (index > 0 && elements[parentIndex].Value > elements[index].Value)
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
            if (leftIndex < elements.Count && elements[leftIndex].Value < elements[index].Value)
                minIndex = leftIndex;
            else
                minIndex = index;
            if (rightIndex < elements.Count && elements[rightIndex].Value < elements[minIndex].Value)
                minIndex = rightIndex;
            if (index != minIndex)
            {
                Swap(index, minIndex);
                Heapify(minIndex);
            }
        }

        private void Swap(int index1, int index2)
        {
            elements[index1].Index = index2;
            elements[index2].Index = index1;

            Element buf = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = buf;
        }
    }
    public class Task2
    {
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                int n = int.Parse(streamReader.ReadLine());
                PriorityQueue queue = new PriorityQueue(n);
                for (int i = 0; i < n; i++)
                {
                    string[] cmd = streamReader.ReadLine().Split(' ');

                    switch(cmd[0][0])
                    {
                        case 'A':
                            queue.Enqueue(i + 1, int.Parse(cmd[1]));
                            break;
                        case 'X':
                            if (queue.Size > 0)
                                streamWriter.WriteLine(queue.Dequeue());
                            else
                                streamWriter.WriteLine('*');
                            break;
                        case 'D':
                            queue.DecreaseValue(int.Parse(cmd[1]), int.Parse(cmd[2]));
                            break;
                    }
                }
            }  
        }
    }
}