using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class DailyLogModel : BaseModel
    {
        public int PlanId { get; set; }
        public DateOnly LogDate { get; set; }
        public int FatGarms { get; set; }
        public int CarbGrams { get; set; }
        public int ProtienGrams { get; set; }
        public double CurrentWeight { get; set; }
        public double Waist { get; set; }
        public bool MetMacros { get; set; }
        public bool WorkedOut { get; set; }
    }
}
