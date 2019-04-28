using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace ADS.Week9
{
    public class Map
    {
        private string str;
        public Map(string s)
        {
            str = s.Replace(" ", string.Empty);
        }

        public long CalculateX()
        {
            List<int>[] indexes = new List<int>[26];
            for (int i = 0; i < indexes.Length; i++)
                indexes[i] = new List<int>();
            for (int i = 0; i < str.Length; i++)
                indexes[str[i] - 'a'].Add(i);

            long count = 0;
            foreach(List<int> letterIndexes in indexes)
                for (int i = 0; i < letterIndexes.Count - 1; i++)
                    count += ((long)letterIndexes[i + 1] - letterIndexes[i]) * (letterIndexes.Count - i - 1) * (i + 1) - (i + 1);
            return count;
        }
    }
    public class Task2
    {
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                Map map = new Map(streamReader.ReadLine());
                streamWriter.WriteLine(map.CalculateX());
            }
        }
    }
}