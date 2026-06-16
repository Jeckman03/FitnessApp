using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.HelperServices
{
    public class BodyMetricService : IBodyMetricService
    {
        public double CalculateBMI(double weight, int height)
        {
            var BMI = (weight * 703) / (height * height);

            BMI = Math.Round(BMI, 1);

            return BMI;
        }

        public int CalculateTDEE(UserModel user, double weight)
        {
            double weightKg = weight / 2.20462;
            double heightCm = user.HeightInches * 2.54;

            double bMR = (10 * weightKg) + (6.25 * heightCm) - (5 * user.Age);

            if (user.Gender == Gender.Male)
            {
                bMR += 5;
            }
            else
            {
                bMR -= 161;
            }

            double activityMultiplier = user.ActivityLevel switch
            {
                ActivityLvl.Sedentary => 1.2,
                ActivityLvl.LightlyActive => 1.375,
                ActivityLvl.ModeratelyActive => 1.55,
                ActivityLvl.VeryActive => 1.725,
                _ => 1.9
            };

            return (int)(bMR * activityMultiplier); 
        }
    }
}
