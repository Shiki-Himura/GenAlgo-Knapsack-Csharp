using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenAlgo___BackpackAlgo
{
    class Program
    {
        static string FilePath = "C:/Users/CSL/Desktop/data2.csv";
        static double TotalVolume = Helper.Rng.Next(0, 1000);
        static double TotalWeight = Helper.Rng.Next(0, 1000);
        static int PopulationSize = 2000;
        static double MutationRate = 0.01;

        static void Main(string[] args)
        {
            Evolution evo = new(FilePath, TotalVolume, TotalWeight, PopulationSize, MutationRate);


            while (true)
            {
                evo.Crossover();
                var best = evo.Population.OrderByDescending(x => x.Fitness).Take(2).ToArray();

                for (int i = 0; i < best.Length; i++)
                {
                    Console.WriteLine("Volume: " + Math.Round(best[i].TotalVolume) + "%"
                                    + "\tWeight: " + Math.Round(best[i].TotalWeight) + "%"
                                    + "\tFitness: " + Math.Round(best[i].Fitness, 1)
                                    + "\tMaxVolume: " + TotalVolume
                                    + "\tMaxWeight: " + TotalWeight);
                }
            }

        }
    }
}
