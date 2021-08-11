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
        private Gen[] GenList { get; set; }
        private double MutationRate { get; set; }


        // Methods
        private void CalcFitness()
        {

        }

        public Gen[] GetContent()
        {

        }

        // constructor
        public Entity(Entity entityA, Entity entityB)
        {

        }

        public Entity(double maxVolume, double maxWeight, Gen[] genList, double mutRate)
        {
            TotalVolume = maxVolume;
            TotalWeight = maxWeight;
            GenList = genList;
            MutationRate = mutRate;
        }
    }
}
