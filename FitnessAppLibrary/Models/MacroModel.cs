using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class MacroModel : BaseModel
    {
        public int Tdee { get; set; }
        public int StartingCalories { get; set; }
        public int CurrentCalories { get; set; }
        public int Deficit { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }
        public int Protien { get; set; }
    }
}
