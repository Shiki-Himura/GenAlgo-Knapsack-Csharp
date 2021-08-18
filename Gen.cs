using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAlgo___BackpackAlgo
{
    class Gen
    {
        public double Volume { get; set; }
        public double Weight { get; set; }
        public int Value { get; set; }
        public int ID { get; set; }
        public double VolumePercentage { get; set; }
        public double WeightPercentage { get; set; }



        // constructor
        public Gen(double volume, double weight, int value, int id,
                   double totalVolume, double totalWeight)
        {
            Volume = volume;
            Weight = weight;
            Value = value;
            ID = id;
            VolumePercentage = (Volume / totalVolume) * 100;
            WeightPercentage = (Weight / totalWeight) * 100;
        }
    }
}
