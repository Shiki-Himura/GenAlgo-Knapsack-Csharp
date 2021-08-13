using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAlgo___BackpackAlgo
{
    class Entity
    {
        public int[] DNA { get; set; }
        public double Fitness { get; set; }
        private double TotalVolume { get; set; }
        private double TotalWeight { get; set; }
        private Gen[] RefList { get; set; }
        private double MutationRate { get; set; }


        // Methods
        private void CalcFitness()
        {
            for (int i = 0; i < DNA.Length; i++)
            {
                if (DNA[i] == 1 && RefList[i].Weight < TotalWeight && RefList[i].Volume < TotalVolume)
                {
                    Fitness += 0.2;
                }
                else
                {
                    Fitness -= 0.1;
                }
            }
        }

        public Gen[] GetContent()
        {
            throw new NotImplementedException();
        }

        // constructor
        public Entity(Entity entityA, Entity entityB)
        {
            throw new NotImplementedException();
        }

        public Entity(double maxVolume, double maxWeight, Gen[] refList, double mutRate, int[] bitTemp)
        {
            DNA = bitTemp;
            TotalVolume = maxVolume;
            TotalWeight = maxWeight;
            RefList = refList;
            MutationRate = mutRate;
            CalcFitness();
        }
    }
}
