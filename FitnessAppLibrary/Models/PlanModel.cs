using FitnessAppLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class PlanModel : BaseModel
    {
        public int UserId { get; set; }
        public int DurationDays { get; set; }
        public Goals Goal { get; set; }
        public int CurrentCalorieTarget { get; set; }
    }

}
