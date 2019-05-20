using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Stepik.GreedyAlgorithms
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }

        public char Code { get; set; }
        public char Letter { get; set; }

        public void AddLetter(char letter, string code)
        {
            Code = code[0];
            if (code.Length > 1)
            {
                code = code.Substring(1);
                if (code[0] == '0')
                {
                    if (Left == null)
                        Left = new Node();
                    Left.AddLetter(letter, code);
                } 
                else if (code[0] == '1')
                {
                    if (Right == null)
                        Right = new Node();
                    Right.AddLetter(letter, code);
                }
            }
            else
                Letter = letter;
        }
        public char FindLetter(string code, int index, out int resultIndex)
        {
            if (Letter != 0)
            {
                resultIndex = index - 1;
                return Letter;
            }
            
            if (Left != null && Left.Code == code[index])
            {
                return Left.FindLetter(code, index + 1, out resultIndex);
            }
            else
            {
                return Right.FindLetter(code, index + 1, out resultIndex);
            }
        }
    }
    public class ReverseHuffmanTask
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = int.Parse(str[0]);
            Node root = new Node();
            for (int i = 0; i < n; i++)
            {
                str = Console.ReadLine().Split(' ');
                root.AddLetter(str[0][0], " " + str[1]);
            }

            string code = Console.ReadLine();
            int index = 0;
            while (index < code.Length)
            {
                int resultIndex;
                Console.Write(root.FindLetter(code, index, out resultIndex));
                index = resultIndex + 1;
            }
        }
    }
}
