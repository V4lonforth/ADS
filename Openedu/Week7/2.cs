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
                Height = 0;
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
            size = 0;
        }
        public void Add(int key, int left, int right)
        {
            nodes[size] = new Node(key, left, right);
            if (nodes[size].Left == Root || nodes[size].Right == Root)
                Root = size;
            size++;
        }

        public void GetHeights()
        {
            List<int> childs = new List<int>(nodes.Length);
            childs.Add(Root);
            for (int i = 0; i < childs.Count; i++)
            {
                if (nodes[childs[i]].Left != -1)
                {
                    childs.Add(nodes[childs[i]].Left);
                    nodes[nodes[childs[i]].Left].Parent = childs[i];
                }
                if (nodes[childs[i]].Right != -1)
                {
                    childs.Add(nodes[childs[i]].Right);
                    nodes[nodes[childs[i]].Right].Parent = childs[i];
                }
            }
            for (int i = childs.Count - 1; i >= 0; i--)
            {
                if (nodes[childs[i]].Left == nodes[childs[i]].Right)
                {
                    nodes[childs[i]].Height = 1;
                }
                else
                {
                    if (nodes[childs[i]].Left != -1)
                        nodes[childs[i]].Height = nodes[nodes[childs[i]].Left].Height;
                    if (nodes[childs[i]].Right != -1)
                        nodes[childs[i]].Height = Math.Max(nodes[nodes[childs[i]].Right].Height, nodes[childs[i]].Height);
                    nodes[childs[i]].Height++;
                }
            }
        }
        public int GetBalance(int index)
        {
            int left = nodes[index].Left == -1 ? 0 : nodes[nodes[index].Left].Height;
            int right = nodes[index].Right == -1 ? 0 : nodes[nodes[index].Right].Height;
            return right - left;
        }
        public void Balance()
        {
            if (GetBalance(nodes[Root].Right) == -1)
            {
                int A = Root;
                int B = nodes[A].Right;
                int C = nodes[B].Left;
                nodes[A].Right = nodes[C].Left;
                nodes[B].Left = nodes[C].Right;
                nodes[C].Left = A;
                nodes[C].Right = B;
                Root = C;
            }
            else
            {
                int A = Root;
                int B = nodes[A].Right;
                nodes[A].Right = nodes[B].Left;
                nodes[B].Left = A;
                Root = B;
            }
        }

        public void Print(StreamWriter streamWriter)
        {
            int[] indices = new int[size];
            int currentIndex = 0;
            GetIndices(indices, ref currentIndex, Root);
            Print(indices, Root, streamWriter);
        }

        private void GetIndices(int[] indices, ref int currentIndex, int index)
        {
            if (index == -1)
                return;

            Node node = nodes[index];
            indices[index] = currentIndex;
            currentIndex++;
            GetIndices(indices, ref currentIndex, node.Left);
            GetIndices(indices, ref currentIndex, node.Right);
        }
        private void Print(int[] indices, int index, StreamWriter streamWriter)
        {
            if (index == -1)
                return;
            
            Node node = nodes[index];
            streamWriter.WriteLine("{0} {1} {2}", node.Key, node.Left == -1 ? 0 : indices[node.Left] + 1, node.Right == -1 ? 0 : indices[node.Right] + 1);

            Print(indices, node.Left, streamWriter);
            Print(indices, node.Right, streamWriter);
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
                BinaryTree tree = new BinaryTree(n);
                for (int i = 0; i < n; i++)
                {
                    string[] str = streamReader.ReadLine().Split(' ');
                    tree.Add(int.Parse(str[0]), int.Parse(str[1]) - 1, int.Parse(str[2]) - 1);
                }
                tree.GetHeights();
                tree.Balance();

                streamWriter.WriteLine(n);
                tree.Print(streamWriter);
            }
        }
    }
}