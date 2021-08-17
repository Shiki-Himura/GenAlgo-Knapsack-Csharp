using System;
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



        // Methods
        public void CreateNextGeneration()
        {

        }

        private void CreateRngPopulation(string path, double totalVolume, double totalWeight, double mutRate)
        {
            Gen[] data = LoadData(path, totalVolume, totalWeight);
            Random rng = new();
            double popFitSum = 0;

            for (int i = 0; i < MaxPopSize; i++)
            {
                int[] bitTemp = new int[data.Length];
                for (int j = 0; j < bitTemp.Length; j++)
                {
                    bitTemp[j] = rng.Next(0, 2);
                }
                 
                Population[i] = new Entity(totalVolume, totalWeight, data, mutRate, bitTemp);
                popFitSum += Population[i].Fitness;
            }
        }

        private static Gen[] LoadData(string path, double totalVolume, double totalWeight)
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
            return data;
        }

        // constructor
        public Evolution(string path, double totalVolume, double totalWeight, int popSize, double mutRate)
        {
            MaxPopSize = popSize;            
            CreateRngPopulation(path, totalVolume, totalWeight, mutRate);
        }
    }
}
