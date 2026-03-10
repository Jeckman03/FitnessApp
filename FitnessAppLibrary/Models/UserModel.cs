using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int HeightFeet { get; set; }
        public int HeightInches { get; set; }
        public Gender Gender { get; set; }
        public string ActivityLevel { get; set; }
        public string Goal { get; set; }
    }

    public enum Gender
    {
        Male, Female
    }
}
