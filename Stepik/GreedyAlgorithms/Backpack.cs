using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.GreedyAlgorithms
{
    public struct Item
    {
        public int Cost { get; }
        public int Size { get; }

        public double Value { get { return (float)Cost / Size; } }

        public Item(int cost, int size)
        {
            Cost = cost;
            Size = size;
        }
    }

    public class Backpack
    {
        private Item[] items;
        private int maxSize;

        public Backpack(int maxSize, Item[] items)
        {
            this.items = items;
            this.maxSize = maxSize;
        }

        public double Calculate()
        {
            Quicksort(0, items.Length - 1);

            int size = maxSize;
            double cost = 0f;

            for (int i = items.Length - 1; i >= 0 && size > 0; i--)
            {
                if (items[i].Size > size)
                {
                    cost += size * items[i].Value;
                    break;
                }
                else
                {
                    cost += items[i].Cost;
                    size -= items[i].Size;
                }
            }

            return cost;
        }

        private int Partition (int start, int end) 
        {
            Item temp;
            int marker = start;
            for ( int i = start; i <= end; i++ ) 
            {
                if (items[i].Value < items[end].Value)
                {
                    temp = items[marker];
                    items[marker] = items[i];
                    items[i] = temp;
                    marker += 1;
                }
            }
            
            temp = items[marker];
            items[marker] = items[end];
            items[end] = temp; 
            return marker;
        }

        private void Quicksort(int start, int end)
        {
            if ( start >= end ) 
            {
                return;
            }
            int pivot = Partition(start, end);
            Quicksort(start, pivot-1);
            Quicksort(pivot+1, end);
        }
    }

    public class BackpackTask
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = int.Parse(str[0]);
            int size = int.Parse(str[1]);

            Item[] items = new Item[n];

            for (int i = 0; i < n; i++)
            {
                str = Console.ReadLine().Split(' ');
                items[i] = new Item(int.Parse(str[0]), int.Parse(str[1]));
            }

            Backpack backpack = new Backpack(size, items);
            Console.WriteLine(String.Format("{0:0.000}", backpack.Calculate()));
        }
    }
}
