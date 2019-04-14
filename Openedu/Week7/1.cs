using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace ADS.Week7
{

    public class BinaryTree
    {
        private struct Node
        {
            public int Key { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }
            public int Height { get; set; }

            public Node(int key, int left, int right)
            {
                Key = key;
                Left = left;
                Right = right;
                Height = 0;
            }
        }
        private Node[] nodes;
        private int root;
        private int size;

        public BinaryTree(int size)
        {
            nodes = new Node[size];
            root = 0;
            size = 0;
        }
        public void Add(int key, int left, int right)
        {
            nodes[size] = new Node(key, left, right);
            if (nodes[size].Left == root || nodes[size].Right == root)
                root = size;
            size++;
        }

        public void GetHeights()
        {
            List<int> childs = new List<int>(nodes.Length);
            childs.Add(root);
            for (int i = 0; i < childs.Count; i++)
            {
                if (nodes[childs[i]].Left != -1)
                    childs.Add(nodes[childs[i]].Left);
                if (nodes[childs[i]].Right != -1)
                    childs.Add(nodes[childs[i]].Right);
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
    }
    public class Task1
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
                for (int i = 0; i < n; i++)
                {
                    streamWriter.WriteLine(tree.GetBalance(i));
                }
            }
        }
    }
}