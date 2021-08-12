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
            double sumWeight = 0;
            double sumVolume = 0;

            for (int i = 0; i < DNA.Length; i++)
            {
                if (DNA[i] == 1)
                {
                    sumWeight += RefList[i].WeightPercentage;
                    sumVolume += RefList[i].VolumePercentage;
                }
            }

            double fitnessA = 0;
            double fitnessB = 0;
            double dnaWeight = 100 - sumWeight;
            double dnaVolume = 100 - sumVolume;
            if (dnaWeight >= 0 && dnaVolume >= 0)
            { // finish calculating fitness 
                fitnessA = ;
                fitnessB = ;
            }
            Fitness = fitnessA + fitnessB;
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
