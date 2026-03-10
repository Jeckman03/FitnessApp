using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class WeightModel : BaseModel
    {
        public double StartingWeight { get; set; }
        public double CurrentWeight { get; set; }
        public double WeightDifference { get; set; }
        public double StartingWaist { get; set; }
        public double CurrentWaist { get; set; }
        public double WasitDifference { get; set; }
    }
}
