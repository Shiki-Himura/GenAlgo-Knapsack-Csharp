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
        private Gen[] RefList { get; set; }
        private double TotalVolume { get; set; }
        private double TotalWeight { get; set; }
        private double MutationRate { get; set; }
        public double Value { get; set; }
        public double Fitness { get; set; }



        // Methods
        private void CalcFitness()
        {
            double volPerc = 0;
            double weightPerc = 0;
            Fitness = 1;

            for (int i = 0; i < DNA.Length; i++)
            {
                if (DNA[i] == 1)
                {
                    volPerc += RefList[i].VolumePercentage;
                    weightPerc += RefList[i].WeightPercentage;
                    Value += RefList[i].Value;
                }
            }

            double nVolumeMultiplier = 20;
            double nWeightMultiplier = 20;

            double pVolumeMultiplier = 1;
            double pWeightMultiplier = 1;

            double valueMultiplier = 1;

            // Initialized variables by inline if statement
            double nVolume = 100 - volPerc < 0 ? (100 - volPerc) * nVolumeMultiplier : 0;
            double nWeight = 100 - weightPerc < 0 ? (100 - weightPerc) * nWeightMultiplier : 0;

            double pVolume = volPerc - 100 <= 0 ? volPerc * pVolumeMultiplier : 100;
            double pWeight = weightPerc - 100 <= 0 ? weightPerc * pWeightMultiplier : 100;

            Fitness = Value * valueMultiplier + nVolume + nWeight + pVolume + pWeight;
        }         

        public Gen[] GetContent()
        {
            throw new NotImplementedException();
        }

        // constructor
        public Entity(Entity entityA, Entity entityB)
        {

            CalcFitness();
            throw new NotImplementedException();
        }

        public Entity(double maxVolume, double maxWeight, Gen[] refList, double mutRate, int[] bitTemp)
        {
            DNA = bitTemp;
            TotalVolume = maxVolume;
            TotalWeight = maxWeight;
            RefList = refList;
            MutationRate = mutRate;
            Fitness = 1;
            CalcFitness();

        }
    }
}
