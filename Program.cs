using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenAlgo___BackpackAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Gen> DNA_Pool = GetFileData();

        }
        private static Gen[] CreateGenArray(List<Gen> pool)
        {
            Gen[] temp = new Gen[200];
            Random rand = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = pool[rand.Next(pool.Count)];
            }
            return temp;
        }
        private static List<Gen> GetFileData()
        {
            List<Gen> lines = new();
            lines = File.ReadAllLines("C:/Users/CSL/Desktop/data.csv")
                .Select(x => x.Split("\t"))
                .Select(x => new Gen { Volume = int.Parse(x[0]), Weight = int.Parse(x[1]), Value = int.Parse(x[2]) })
                .ToList();
            return lines;
        }
    }
}
