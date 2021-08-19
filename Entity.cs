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
        public Gen[] RefList { get; set; }
        public double TotalVolume { get; set; }
        public double TotalWeight { get; set; }
        public double MutationRate { get; set; }
        public double Score { get; set; }
        public double Fitness { get; set; }



        // methods
        public void CalcFitness()
        {            
            Fitness = 1;

            for (int i = 0; i < DNA.Length; i++)
            {
                Console.Write(DNA[i]);
                
            }
            Console.WriteLine();

            int lengthDNA = DNA.Length;
            for (int i = 0; i < lengthDNA; i++)
            {
                if (DNA[i] == 1)
                {
                    TotalVolume += RefList[i].VolumePercentage;
                    TotalWeight += RefList[i].WeightPercentage;
                    Score += RefList[i].Value;
                }
            }

            // multiplier which influence the behaviour of choosing which DNA is the more favourable
            double nVolumeMultiplier = 20;
            double nWeightMultiplier = 20;

            double pVolumeMultiplier = 1;
            double pWeightMultiplier = 1;

            double valueMultiplier = 1;

            // Initialized variables by inline if statement
            double nVolume = 100 - TotalVolume < 0 ? (100 - TotalVolume) * nVolumeMultiplier : 0;
            double nWeight = 100 - TotalWeight < 0 ? (100 - TotalWeight) * nWeightMultiplier : 0;

            double pVolume = TotalVolume - 100 <= 0 ? TotalVolume * pVolumeMultiplier : 100;
            double pWeight = TotalWeight - 100 <= 0 ? TotalWeight * pWeightMultiplier : 100;

            Fitness = Score * valueMultiplier + nVolume + nWeight + pVolume + pWeight;
        }         

        public Gen[] GetContent()
        {
            throw new NotImplementedException();
        }

        // constructor
        public Entity(Entity dnaA, Entity dnaB)
        {
            RefList = dnaA.RefList;
            MutationRate = dnaA.MutationRate;
            DNA = new int[RefList.Length];
            TotalVolume = 0;
            TotalWeight = 0;
            Fitness = 1;

            int lengthDNA = DNA.Length;
            for (int i = 0; i < lengthDNA; i++)
            {
                double rng = Helper.Rng.NextDouble();

                if (rng < MutationRate / 100)
                {
                    DNA[i] = Helper.Rng.Next(0, 2);
                }
                else if (i < lengthDNA / 2)
                {
                    DNA[i] = dnaA.DNA[i];
                }
                else
                {
                    DNA[i] = dnaB.DNA[i];
                }
            }

            CalcFitness();
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
