using System;
using System.IO;

namespace ADS.Week5
{
    public class Task1
    {
        public static void Main(string[] args)
        {
            int n;
            int[] array;
            using (StreamReader streamReader = new StreamReader("input.txt"))
            {
                n = int.Parse(streamReader.ReadLine());
                array = new int[n];
                string[] str = streamReader.ReadLine().Split(' ');
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(str[i]);
                }
            }
            bool result = true;
            for (int i = n - 1; i > 0; i--)
            {
                if (array[(i + 1) / 2 - 1] > array[i])
                {
                    result = false;
                    break;
                }
            }
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                streamWriter.WriteLine(result ? "YES" : "NO");
            }            
        }
    }
}