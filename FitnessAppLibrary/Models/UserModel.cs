using FitnessAppLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int HeightInches { get; set; }
        public Gender Gender { get; set; }
        public ActivityLvl ActivityLevel { get; set; }

        public int Age
        {
            get
            {
                var today = DateOnly.FromDateTime(DateTime.Now);

                int age = today.Year - DateOfBirth.Year;

                if (DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
    }

    
}
