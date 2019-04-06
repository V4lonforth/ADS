using System;
using System.IO;
using System.Globalization;

namespace ADS.Week6
{
    public class Task2
    {
        private const double precision = 0.000001d;
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                string[] str = streamReader.ReadLine().Split(' ');
                int n = int.Parse(str[0]);
                double first = double.Parse(str[1], CultureInfo.InvariantCulture);
                double min = 0;
                double max = first;
                double answer = 0d;
                bool precisionReached = false;
                while (!precisionReached)
                {
                    double second = (max + min) / 2d;
                    double a = first;
                    double b = second;
                    bool result = true;

                    for (int i = 2; i < n; i++)
                    {
                        double c = 2 * b - a + 2;
                        a = b;
                        b = c;
                        if (c < 0d)
                            result = false;
                    }
                    if (result)
                        max = second;
                    else
                        min = second;
                    if (Math.Abs(answer - b) <= precision)
                    {
                        precisionReached = true;
                    }
                    answer = b;
                }
                streamWriter.WriteLine(answer);
            }
        }
    }
}