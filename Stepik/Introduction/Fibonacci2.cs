using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.Introduction
{
    public class Fibonacci2Task
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int a = 1;
            int b = 1;
            int c = 1;
            for (int i = 2; i < n; i++)
            {
                a = b;
                b = c;
                c = (a + b) % 10;
            }
            Console.WriteLine(c);
        }
    }
}