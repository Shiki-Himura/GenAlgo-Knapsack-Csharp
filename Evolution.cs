using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAlgo___BackpackAlgo
{
    class Evolution
    {
        public Entity[] Population = new Entity[2000];
        public int MaxPopSize { get; set; }



        // methods

        public void Crossover()
        {
            List<Entity> selection_Pool = new();
            Entity[] temp = new Entity[MaxPopSize];

            double oldMin = Population.Min(x => x.Fitness);
            double oldMax = Population.Max(x => x.Fitness);

            double newMin = 1;
            double newMax = 100;

            double oldRange = oldMax - oldMin;
            double newRange = newMax - newMin;

            foreach (var item in Population)
            {
                // inline if statement to check if fitness needs to be 1(fitness < 0) or calculated
                int fit = (int)((((item.Fitness < 0 ? 1 : item.Fitness - oldMin) * newRange) / oldRange) + newMin);

                for (int i = 0; i < fit; i++)
                {
                    selection_Pool.Add(item);
                }
            }

            for (int i = 0; i < MaxPopSize; i++)
            {
                Entity dnaA = selection_Pool[Helper.Rng.Next(0, selection_Pool.Count)];
                Entity dnaB = selection_Pool[Helper.Rng.Next(0, selection_Pool.Count)];

                temp[i] = new Entity(dnaA, dnaB);
            }

            Population = temp;
        }

        //public void CreateRngPopulation(string path, double totalVolume, double totalWeight, double mutRate)
        //{
        //    Gen[] data = LoadData(path, totalVolume, totalWeight);

        //    for (int i = 0; i < MaxPopSize; i++)
        //    {
        //        int[] bitTemp = new int[data.Length];

        //        int lengthTemp = bitTemp.Length;
        //        for (int j = 0; j < lengthTemp; j++)
        //        {
        //            if (Helper.Rng.NextDouble() < 0.1)
        //            {
        //                bitTemp[j] = Helper.Rng.Next(0, 2);
        //            }
        //            else
        //            {
        //                bitTemp[j] = 0;
        //            }
        //        }

        //        Population[i] = new Entity(totalVolume, totalWeight, data, mutRate, bitTemp);

        //    }

        //    Crossover();
        //}

        public void CreatePopulation(Gen[] data, double mutRate)
        {
            for (int i = 0; i < Population.Length; i++)
            {
                Population[i] = new Entity(data, mutRate);
            }
        }

        public void LoadData(string path, double totalVolume, double totalWeight, double mutRate)
        {
            Gen[] data = null;

            data = File.ReadAllLines(path)
                .Select(line => line.Split("\t"))
                .Select((gen, index) => new Gen
                (
                    int.Parse(gen[0]),
                    int.Parse(gen[1]),
                    int.Parse(gen[2]),
                    index + 1,
                    totalVolume,
                    totalWeight
                ))
                .Where(gen => gen.Volume < totalVolume)
                .Where(gen => gen.Weight < totalWeight)
                .ToArray();

            CreatePopulation(data, mutRate);
        }

        // constructor
        public Evolution(string path, double totalVolume, double totalWeight, int popSize, double mutRate)
        {
            MaxPopSize = popSize;
            LoadData(path, totalVolume, totalWeight, mutRate);
        }
    }
}
