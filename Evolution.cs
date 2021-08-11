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

        private void CreateRngPopulation()
        {
            // create array - random index of 200 element array, set value from 0 to 1
            Random rng = new Random();

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
            LoadData(path, totalVolume, totalWeight);

            CreateRngPopulation();
        }
    }
}
