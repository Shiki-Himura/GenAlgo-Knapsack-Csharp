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

        private void CreateRngPopulation(string path, double totalVolume, double totalWeight)
        {
            Gen[] data = LoadData(path, totalVolume, totalWeight);
            Random rng = new Random();
            int[][] pop = new int[2000][];
            
            for (int i = 0; i < MaxPopSize; i++)
            {
                int[] temp = new int[200];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = 0;
                    if (rng.Next(0, 2) == 1)
                    {
                        temp[j] = 1;
                    }
                }
                pop[i] = temp;
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
            CreateRngPopulation(path, totalVolume, totalWeight);
        }
    }
}
