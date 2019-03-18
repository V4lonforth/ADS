using System;
using System.IO;
using System.Text;

namespace ADS.Week3
{
    public class Task2
    {
        private static int[] RadixSort(string[] strings, int n, int m, int k)
        {
            int[] count = new int['z' - 'a' + 1];
            int[] indicies = new int[n];
            int[] newIndicies = new int[n];

            for (int i = 0; i < n; i++)
            {
                indicies[i] = i;
            }

            for (int i = m - 1; i >= m - k ; i--)
            {
                Array.Clear(count, 0, count.Length);
                for (int j = 0; j < n; j++)
                {
                    count[strings[i][j] - 'a']++;
                }
                for (int j = 1; j < count.Length; j++)
                {
                    count[j] += count[j - 1];
                }
                for (int j = n - 1; j >= 0; j--)
                {
                    int radixValue = strings[i][indicies[j]] - 'a';
                    count[radixValue]--;
                    newIndicies[count[radixValue]] = indicies[j];
                }
                int[] buffer = newIndicies;
                newIndicies = indicies;
                indicies = buffer;
            }
            return indicies;
        }
        private static void Main(string[] args)
        {
            int n, m, k;
            string[] strings;
            using (StreamReader streamReader = new StreamReader("input.txt"))
            {
                string[] str = streamReader.ReadLine().Split(' ');
                n = int.Parse(str[0]);
                m = int.Parse(str[1]);
                k = int.Parse(str[2]);
                
                strings = new string[m];
                for (int i = 0; i < m; i++)
                {
                    strings[i] = streamReader.ReadLine();
                }
            }

            int[] result = RadixSort(strings, n, m, k);

            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                for (int i = 0; i < result.Length; i++)
                {
                    streamWriter.Write("{0} ", result[i] + 1);
                }
            }
        }
    }
}