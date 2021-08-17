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
            /* sum of percentages as MAX in range 0 to MAX
               everything above 200% (100% volume, 100% weight) gets punished exponentially harder than if its below
             */
            double sumRatio = 0;
            for (int i = 0; i < DNA.Length; i++)
            {
                if (DNA[i] == 1)
                {
                    sumRatio += RefList[i].Ratio;
                    sumRatio += RefList[i].VolumePercentage;
                    sumRatio += RefList[i].WeightPercentage;
                }
            }
            double result = sumRatio;

            


            Console.WriteLine("Percentage based on 100%: " + Math.Round(result, 2));
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
