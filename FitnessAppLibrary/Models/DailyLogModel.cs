using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class DailyLogModel : BaseModel
    {
        public int PlanId { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }
        public int Protien { get; set; }
        public double CurrentWeight { get; set; }
        public double Waist { get; set; }
        public bool MetMacros { get; set; }
        public bool WorkedOut { get; set; }
    }
}
