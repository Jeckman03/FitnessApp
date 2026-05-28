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
            double bMR = 0;
            int tDEE = 0;

            if (user.Gender == Gender.Male)
            {
                bMR = (13.7 * weight) + (5 * user.HeightInches) - (6.8 * user.Age) + 66;
            }
            else
            {
                bMR = (9.6 * weight) + (1.8 * user.HeightInches) - (4.7 * user.Age) - 161;
            }

            if (user.ActivityLevel == ActivityLvl.Sedentary)
            {
                tDEE = (int)(bMR * 1.2);
            }
            else if (user.ActivityLevel == ActivityLvl.LightlyActive)
            {
                tDEE = (int)(bMR * 1.375);
            }
            else if (user.ActivityLevel == ActivityLvl.ModeratleyActive)
            {
                tDEE = (int)(bMR * 1.55);
            }
            else if (user.ActivityLevel == ActivityLvl.VeryActive)
            {
                tDEE = (int)(bMR * 1.725);
            }
            else
            {
                tDEE = (int)(bMR * 1.9);
            }

            return tDEE; 
        }
    }
}
