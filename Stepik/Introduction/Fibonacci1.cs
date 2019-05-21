using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik.Introduction
{
    public class Fibonacci1Task
    {
        private static int Fibonacci(int number)
        {
            if (number <= 2)
                return 1;
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(n));
        }
    }
}
