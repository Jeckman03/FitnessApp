using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int HeightInches { get; set;  }
        public Gender Gender { get; set; }
        public ActivityLvl ActivityLevel { get; set; }


        //private void CalculateAge()
        //{
        //    var userYearBorn = DateOfBirth.Year;
        //    var thisYear = DateTime.Now.Year;
        //    Age = thisYear - userYearBorn;
        //}

        //private void CalculateTotalInches()
        //{
        //    var inchesFromFeet = HeightFeet * 12;
        //    TotalInches = inchesFromFeet + HeightInches;
        //}
    }

    public enum ActivityLvl
    {
        Sedentary, LightlyActive, ModeratleyActive, VeryActive, ExtraActive
    }

    public enum Gender
    {
        Male, Female
    }
}
