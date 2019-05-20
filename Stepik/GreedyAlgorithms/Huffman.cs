using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Stepik.GreedyAlgorithms
{
    public class TreeBranch
    {
        public List<LetterCode> Letters { get; set; }
        public int Count { get; set; }

        public TreeBranch(List<LetterCode> lettersCode, int count)
        {
            Letters = lettersCode;
            Count = count;
        }

        public void AddPrefix(char c)
        {
            for (int i = 0; i < Letters.Count; i++)
                Letters[i] = new LetterCode(Letters[i].Letter, c + Letters[i].Code);
        }
    }

    public struct LetterCode
    {
        public char Letter { get; }
        public string Code { get; }

        public LetterCode(char letter, string code)
        {
            Letter = letter;
            Code = code;
        }
    }

    public class Huffman
    {
        private string str;

        public string CodedString { get; private set; }
        public List<LetterCode> LettersCodes { get; private set; }

        public Huffman(string str)
        {
            this.str = str;
        }

        public void CodeString()
        {
            LettersCodes = GetCodes();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
                stringBuilder.Append(GetCode(str[i]));
            CodedString = stringBuilder.ToString();
        }

        private string GetCode(char c)
        {
            for (int i = 0; i < LettersCodes.Count; i++)
                if (LettersCodes[i].Letter == c)
                    return LettersCodes[i].Code;
            return String.Empty;
        }

        private List<LetterCode> GetCodes()
        {
            List<TreeBranch> branches = CountLetters();
            if (branches.Count == 1)
                return new List<LetterCode>() { new LetterCode(branches[0].Letters[0].Letter, "0") };

            while (branches.Count > 1)
            {
                Sort(branches);
                TreeBranch left = branches[1];
                TreeBranch right = branches[0];

                left.AddPrefix('0');
                right.AddPrefix('1');

                List<LetterCode> letters = new List<LetterCode>(left.Letters);
                letters.AddRange(right.Letters);

                branches.RemoveAt(1);
                branches[0] = new TreeBranch(letters, left.Count + right.Count);
            }
            return branches[0].Letters;
        }
        private List<TreeBranch> CountLetters()
        {
            int[] count = new int[65536];
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                int number = str[i] - 'a';
                count[str[i] - 'a']++;
            }

            List<TreeBranch> lettersCount = new List<TreeBranch>();
            for (int i = 0; i < 'z' - 'a'; i++)
                if (count[i] > 0)
                    lettersCount.Add(new TreeBranch( new List<LetterCode>() { new LetterCode((char)('a' + i), "") }, count[i]));

            return lettersCount;
        }
        private void Sort(List<TreeBranch> brenches)
        {
			TreeBranch t; 
            for (int p = 0; p <= brenches.Count - 2; p++)
            {
                for (int i = 0; i <= brenches.Count - 2; i++)
                {
                    if (brenches[i].Count > brenches[i + 1].Count)
                    {
                        t = brenches[i + 1];
                        brenches[i + 1] = brenches[i];
                        brenches[i] = t;
                    }
                } 
            }
        }
    }  
    
    public class HuffmanTask
    {
        static void Main(string[] args)
        {
            Huffman huffman = new Huffman(Console.ReadLine());
            huffman.CodeString();

            Console.WriteLine("{0} {1}", huffman.LettersCodes.Count, huffman.CodedString.Length);
            foreach (LetterCode letterCode in huffman.LettersCodes)
                Console.WriteLine("{0}: {1}", letterCode.Letter, letterCode.Code);
            Console.WriteLine(huffman.CodedString);
        }
    }
}
