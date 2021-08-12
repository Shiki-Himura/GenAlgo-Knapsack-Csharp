using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenAlgo___BackpackAlgo
{
    class Program
    {
        static readonly string FilePath = "C:/Users/CSL/Desktop/data.csv";
        static readonly double TotalVolume = 55.0;
        static readonly double TotalWeight = 78.0;
        static readonly int PopulationSize = 2000;
        static readonly double MutationRate = 1.0;

        static void Main(string[] args)
        {
            Evolution evo = new(FilePath, TotalVolume, TotalWeight, PopulationSize, MutationRate);

            evo.CreateNextGeneration();

        }        
    }
}
