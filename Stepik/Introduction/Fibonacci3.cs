using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.Introduction
{
    public class Fibonacci3Task
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            long n = long.Parse(str[0]);
            int m = int.Parse(str[1]);

            List<int> list = new List<int>(m) { 0, 1, 1 };
            while (list.Count < n + 1 && !(list[list.Count - 2] == 0 && list[list.Count - 1] == 1))
                list.Add((list[list.Count - 2] + list[list.Count - 1]) % m);

            if (list.Count < n + 1)
            {
                list.RemoveAt(list.Count - 1);
                list.RemoveAt(list.Count - 1);
            }

            Console.WriteLine(list[(int)((n) % list.Count)]);
        }
    }
}
