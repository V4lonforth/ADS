using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace ADS.Week7
{

    public class BinaryTree
    {
        public struct Node
        {
            public int Key { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }
            public int Height { get; set; }
            public int Parent { get; set; }

            public Node(int key, int left, int right)
            {
                Key = key;
                Left = left;
                Right = right;
                Height = 1;
                Parent = -1;
            }
        }
        private Node[] nodes;
        public int Root { get; set; }
        private int size;

        public Node this[int index]
        {
            get { return nodes[index]; }
        }

        public BinaryTree(int size)
        {
            nodes = new Node[size];
            Root = 0;
        }
        public void Add(int key, int left, int right)
        {
            nodes[size] = new Node(key, left, right);
            if (nodes[size].Left == Root || nodes[size].Right == Root)
                Root = size;
            size++;
        }

        public int GetBalance(int index)
        {
            int left = nodes[index].Left == -1 ? 0 : nodes[nodes[index].Left].Height;
            int right = nodes[index].Right == -1 ? 0 : nodes[nodes[index].Right].Height;
            return right - left;
        }
        public void Balance(int node)
        {
            int balance = GetBalance(node);
            if (balance == 2)
                LeftBalance(node);
            else if (balance == -2)
                RightBalance(node);
        }
        private void RightBalance(int node)
        {
            if (GetBalance(nodes[node].Left) == 1)
            {
                int A = node;
                int B = nodes[A].Left;
                int C = nodes[B].Right;
                nodes[B].Right = nodes[C].Left;
                nodes[A].Left = nodes[C].Right;
                nodes[C].Left = B;
                nodes[C].Right = A;

                nodes[C].Parent = nodes[A].Parent;
                nodes[A].Parent = C;
                nodes[B].Parent = C;
                if (node == Root)
                    Root = C;
                else
                {
                    if (nodes[nodes[node].Parent].Left == node)
                        nodes[nodes[node].Parent].Left = C;
                    else
                        nodes[nodes[node].Parent].Right = C;
                }
                RecalculateHeights(B);
                RecalculateHeights(C);
            }
            else
            {
                int A = node;
                int B = nodes[A].Left;
                nodes[A].Left = nodes[B].Right;
                nodes[B].Right = A;
                
                nodes[B].Parent = nodes[A].Parent;
                nodes[A].Parent = B;
                if (node == Root)
                    Root = B;
                else
                {
                    if (nodes[nodes[node].Parent].Left == node)
                        nodes[nodes[node].Parent].Left = B;
                    else
                        nodes[nodes[node].Parent].Right = B;
                }
                RecalculateHeights(A);
            }
        }
        private void LeftBalance(int node)
        {
            if (GetBalance(nodes[node].Right) == -1)
            {
                int A = node;
                int B = nodes[A].Right;
                int C = nodes[B].Left;
                nodes[A].Right = nodes[C].Left;
                nodes[B].Left = nodes[C].Right;
                nodes[C].Left = A;
                nodes[C].Right = B;
                nodes[C].Parent = nodes[A].Parent;
                nodes[A].Parent = C;
                nodes[B].Parent = C;
                if (node == Root)
                    Root = C;
                else
                {
                    if (nodes[nodes[node].Parent].Left == node)
                        nodes[nodes[node].Parent].Left = C;
                    else
                        nodes[nodes[node].Parent].Right = C;
                }
                RecalculateHeights(B);
                RecalculateHeights(C);
            }
            else
            {
                int A = node;
                int B = nodes[A].Right;
                nodes[A].Right = nodes[B].Left;
                nodes[B].Left = A;
                nodes[B].Parent = nodes[A].Parent;
                nodes[A].Parent = B;
                if (node == Root)
                    Root = B;
                else
                {
                    if (nodes[nodes[node].Parent].Left == node)
                        nodes[nodes[node].Parent].Left = B;
                    else
                        nodes[nodes[node].Parent].Right = B;
                }
                RecalculateHeights(A);
            }
        }        
        private void RecalculateHeights(int index)
        {
            int height = 1;
            if (nodes[index].Left != -1)
                height = nodes[nodes[index].Left].Height + 1;
            if (nodes[index].Right != -1)
                height = Math.Max(nodes[nodes[index].Right].Height, height) + 1;
            nodes[index].Height = height;
        }
        public void Insert(int key)
        {
            if (size == 0)
            {
                Add(key, -1, -1);
                return;
            }
            int index = Insert(key, Root);
            if (index == -1)
                return;
            if (nodes[index].Left == -1 || nodes[index].Right == -1)
            {
                RecalculateHeights(index);
            }
            Balance(index);
            while (nodes[index].Parent != -1)
            {
                index = nodes[index].Parent;
                Balance(index);
            }
        }
        private int Insert(int key, int node)
        {
            if (key == nodes[node].Key)
                return -1;
            if (key < nodes[node].Key)
            {
                if (nodes[node].Left == -1)
                {
                    nodes[node].Left = size;
                    Add(key, -1, -1);
                    nodes[size - 1].Parent = node;
                    return node;
                }
                else
                    return Insert(key, nodes[node].Left);
            }
            else 
            {
                if (nodes[node].Right == -1)
                {
                    nodes[node].Right = size;
                    Add(key, -1, -1);
                    nodes[size - 1].Parent = node;
                    return node;
                }
                else
                    return Insert(key, nodes[node].Right);
            }
        }

        public void Delete(int key)
        {
            if (size == 1)
            {
                size = 0;
                Root = -1;
                return;
            }
            int node = Find(key, Root);
            if (node == -1)
                return;
            if (nodes[node].Left == -1)
            {
                if (nodes[node].Right == -1)
                {
                    if (nodes[nodes[node].Parent].Left == node)
                        nodes[nodes[node].Parent].Left = -1;
                    else
                        nodes[nodes[node].Parent].Right = -1;
                    BalanceFrom(nodes[node].Parent);
                }
                else
                {
                    int parent = nodes[node].Parent;
                    nodes[node] = nodes[nodes[node].Right];
                    nodes[node].Parent = parent;
                    BalanceFrom(node);
                }
            }
            else
            {
                int max = FindMax(nodes[node].Left);
                nodes[node].Key = nodes[max].Key;

                int newChild = -1;
                if (nodes[max].Left != -1)
                {
                    newChild = nodes[max].Left;
                }
                if (nodes[nodes[max].Parent].Right == max)
                    nodes[nodes[max].Parent].Right = newChild;
                else 
                    nodes[nodes[max].Parent].Left = newChild;
                BalanceFrom(nodes[max].Parent);
            }
        }
        private void BalanceFrom(int index)
        {
            Balance(index);
            while (nodes[index].Parent != -1)
            {
                index = nodes[index].Parent;
                Balance(index);
            }
        }
        public int Find(int key, int node)
        {
            if (node == -1)
                return node;
            if (key < nodes[node].Key)
                return Find(key, nodes[node].Left);
            else if (key > nodes[node].Key)
                return Find(key, nodes[node].Right);
            else 
                return node;
        }
        private int FindMax(int node)
        {
            if (nodes[node].Right == -1)
                return node;
            else
                return FindMax(nodes[node].Right);
        }
    }
    public class Task5
    {
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                int n = int.Parse(streamReader.ReadLine());
                BinaryTree tree = new BinaryTree(n);
                for (int i = 0; i < n; i++)
                {
                    string[] str = streamReader.ReadLine().Split(' ');
                    switch(str[0][0])
                    {
                        case 'A':
                            tree.Insert(int.Parse(str[1]));
                            streamWriter.WriteLine(tree.GetBalance(tree.Root));
                            break;
                        case 'C':
                            streamWriter.WriteLine(tree.Find(int.Parse(str[1]), tree.Root) == -1 ? 'N' : 'Y');
                            break;
                        case 'D':
                            tree.Delete(int.Parse(str[1]));
                            streamWriter.WriteLine(tree.GetBalance(tree.Root));
                            break;
                    }
                }
                
            }
        }
    }
}