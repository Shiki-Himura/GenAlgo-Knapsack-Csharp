using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAlgo___BackpackAlgo
{
    class Evolution
    {
        public Entity[] Population { get; set; }
        public int MaxPopSize { get; set; }



        // Methods
        public void CreateNextGeneration()
        {

        }

        private void CreateRngPopulation(string path, double totalVolume, double totalWeight, double mutRate)
        {
            Gen[] data = LoadData(path, totalVolume, totalWeight);
            Random rng = new();


            int[][] pop = new int[MaxPopSize][];            
            for (int i = 0; i < MaxPopSize; i++)
            {
                int[] bitTemp = new int[200];
                for (int j = 0; j < bitTemp.Length; j++)
                {
                    bitTemp[j] = rng.Next(0, 2);
                }
                Entity entity = new(totalVolume, totalWeight, data, mutRate, bitTemp);
                pop[i] = bitTemp;
            }
        }

        private static Gen[] LoadData(string path, double totalVolume, double totalWeight)
        {
            Gen[] data = null;

            data = File.ReadAllLines(path)
                .Select(x => x.Split("\t"))
                .Select((gen, index) => new Gen
                (
                    int.Parse(gen[0]),
                    int.Parse(gen[1]),
                    int.Parse(gen[2]),
                    index + 1,
                    totalVolume,
                    totalWeight
                )).ToArray();
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
