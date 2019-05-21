using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.Introduction
{
    public class DivisorTask
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int a = int.Parse(str[0]);
            int b = int.Parse(str[1]);

            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            Console.WriteLine(a);
        }
    }
}
