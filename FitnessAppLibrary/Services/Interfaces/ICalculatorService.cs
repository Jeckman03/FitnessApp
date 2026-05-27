using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface ICalculatorService
    {
        double CalculateBMI(double height, double weight);
        int CalculateCalories(IUserProfileService user, double bmi);
        DailyLogModel CalculateMacros();
    }
}
