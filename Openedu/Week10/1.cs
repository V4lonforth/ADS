using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace ADS.Week10
{
    public class Task1
    {
        private static int[] BuildP(string str)
        {
            int[] p = new int[str.Length];
            int i = 1;
            int j = 0;
            while (i < str.Length)
            {
                if (str[i] == str[j])
                {
                    p[i] = j + 1;
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = p[j - 1];
                }
                else
                {
                    p[i] = 0;
                    i++;
                }
            }
            return p;
        }
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                foreach (int number in BuildP(streamReader.ReadLine()))
                    streamWriter.Write("{0} ", number);
            }
        }
    }
}