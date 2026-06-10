using FitnessAppLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class PlanModel : BaseModel
    {
        public int UserId { get; set; }
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int DurationDays { get; set; } = 1;
        public Goals Goal { get; set; }
        public int CurrentCalorieTarget { get; set; }
        public double TargetWeight { get; set; }
    }

}
