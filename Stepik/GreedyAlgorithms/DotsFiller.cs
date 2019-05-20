using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.GreedyAlgorithms
{
    public struct LineSegment
    {
        public int Left { get; }
        public int Right { get; }

        public LineSegment(int left, int right)
        {
            Left = left;
            Right = right;
        }
    }

    public class DotsFiller
    {
        private LineSegment[] lines;

        public DotsFiller(LineSegment[] lines)
        {
            this.lines = lines;
        }

        public List<int> Fill()
        {
            Sort();

            List<int> dots = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                int dot = lines[i].Right;
                dots.Add(dot);
                while (i < lines.Length && lines[i].Left <= dot)
                    i++;
                i--;
            }
            return dots;
        }

        private void Sort()
        {
			LineSegment t; 
            for (int p = 0; p <= lines.Length - 2; p++)
            {
                for (int i = 0; i <= lines.Length - 2; i++)
                {
                    if (lines[i].Right > lines[i + 1].Right)
                    {
                        t = lines[i + 1];
                        lines[i + 1] = lines[i];
                        lines[i] = t;
                    }
                } 
            }
        }
    }

    public class DotsFillerTask
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            LineSegment[] lines = new LineSegment[n];

            for (int i = 0; i < n; i++)
            {
                string[] str = Console.ReadLine().Split(' ');
                lines[i] = new LineSegment(int.Parse(str[0]), int.Parse(str[1]));
            }

            DotsFiller dotFiller = new DotsFiller(lines);
            List<int> dots = dotFiller.Fill();

            Console.WriteLine(dots.Count);
            for (int i = 0; i < dots.Count; i++)
                Console.Write("{0} ", dots[i]);
        }
    }
}
