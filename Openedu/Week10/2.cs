using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace ADS.Week10
{
    public class Task2
    {
        private static int[] BuildZ(string str)
        {
            int[] z = new int[str.Length];
            int l = 0;
            int r = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (i < r && z[i - l] < r - i)
                {
                    z[i] = z[i - l];
                }
                else
                {
                    int j = (i >= r ? 0 : r - i);
                    while (i + j < str.Length && str[i + j] == str[j])
                    {
                        j++;
                    }
                    l = i;
                    r = i + j;
                    z[i] = j;
                }
            }
            return z;
        }
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                int[] z = BuildZ(streamReader.ReadLine());
                for (int i = 1; i < z.Length; i++)
                    streamWriter.Write("{0} ", z[i]);
            }
        }
    }
}