using FitnessAppLibrary.Models;
using FitnessAppLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.HelperServices
{
    public class CalculatorService : ICalculatorService
    {
        public double CalculateBMI(double height, double weight)
        {
            throw new NotImplementedException();
        }

        public int CalculateCalories(IUserProfileService user, double bmi)
        {
            throw new NotImplementedException();
        }

        public DailyLogModel CalculateMacros()
        {
            throw new NotImplementedException();
        }
    }
}
