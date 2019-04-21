using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace ADS.Week8
{
    public class HashTable
    {
        private int tableSize;
        private long[] table;
        
        public HashTable(int size)
        {
            tableSize = size;
            table = new long[size];
            for (int i = 0; i < size; i++)
                table[i] = -1;
        }

        public bool TryInsert(long key)
        {
            int hash = GetHash(key);
            int hash2 = GetHash2(key);
            while (table[hash] != -1 && table[hash] != key)
            {
                hash = (hash + hash2) % tableSize;
                hash2++;
            }
            if (table[hash] == key)
                return false;   
            table[hash] = key;
            return true;
        }

        private int GetHash(long key)
        {
            return Math.Abs(unchecked((int)((long)(key * 47))) ^ (int)((key * 31) >> 32)) % tableSize;
        }
        private int GetHash2(long key)
        {
            return Math.Abs(unchecked((int)((long)(key * 113))) ^ (int)((key * 97) >> 32)) % (tableSize - 1) + 1;
        }
    }
    public class Task3
    {
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                string[] str = streamReader.ReadLine().Split(' ');
                int n = int.Parse(str[0]);
                long x = long.Parse(str[1]);
                int a = int.Parse(str[2]);
                long b = long.Parse(str[3]);
                str = streamReader.ReadLine().Split(' ');
                int ac = int.Parse(str[0]);
                long bc = long.Parse(str[1]);
                int ad = int.Parse(str[2]);
                long bd = long.Parse(str[3]);

                HashTable hashTable = new HashTable(n * 2);
                for (int i = 0; i < n; i++)
                {
                    if (hashTable.TryInsert(x))
                    {   
                        a = (a + ad) % 1000;
                        b = (b + bd) % 1000000000000000;
                    }
                    else
                    {
                        a = (a + ac) % 1000;
                        b = (b + bc) % 1000000000000000;
                    }
                    x = (x * a + b) % 1000000000000000;
                }
                streamWriter.WriteLine("{0} {1} {2}", x, a, b);
            }
        }
    }
}