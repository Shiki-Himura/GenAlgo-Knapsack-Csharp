using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenAlgo___BackpackAlgo
{
    class Program
    {
        static string FilePath = "C:/Users/CSL/Desktop/data.csv";
        static double TotalVolume = 60.0;
        static double TotalWeight = 60.0;
        static int PopulationSize = 2000;
        static double MutationRate = 0.01;

        static void Main(string[] args)
        {
            Evolution evo = new(FilePath, TotalVolume, TotalWeight, PopulationSize, MutationRate);

            while (true)
            {
                evo.Crossover();
            }

        }
    }
}
