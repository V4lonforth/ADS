using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace ADS.Week9
{
    public class SearchableString
    {
        private string str;

        public int Length { get { return str.Length; } }

        private const int x = 27;
        private const long p = 223372036854775801;

        public SearchableString(string s)
        {
            str = s;
        }

        public List<int> IndexesOf(string s)
        {
            if (s.Length > str.Length)
                return new List<int>();
            
            long hash = GetHash(s);
            List<int> indexes = new List<int>();

            for (int i = 0; i <= str.Length - s.Length; i++)
            {
                string substring = str.Substring(i, s.Length);
                if (hash == GetHash(substring) && substring.Equals(s))
                    indexes.Add(i);
            }
            return indexes;
        }
        private long GetHash(string s)
        {
            long hash = 0;
            for (int i = 0; i < s.Length; i++)
            {
                hash = (hash * x + s[i]) % p;
            }
            return hash;
        }
    }
    public class Task1
    {
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                string substring = streamReader.ReadLine();
                SearchableString str = new SearchableString(streamReader.ReadLine());
                List<int> indexes = str.IndexesOf(substring);
                streamWriter.WriteLine(indexes.Count);
                for (int i = 0; i < indexes.Count; i++)
                    streamWriter.Write("{0} ", indexes[i] + 1);
            }
        }
    }
}