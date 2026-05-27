using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services
{
    public static class CalculateService
    {
        //public static void CalculateCalories(UserModel user, MacroModel macro)
        //{
        //    if (user.Gender == Gender.Male)
        //    {
        //        macro.BMR = (10 * user.Weight) + (15.88 * user.HeightInches) - (5 * user.Age) + 5;
        //    }
        //    else
        //    {
        //        macro.BMR = (10 * user.Weight) + (15.88 * user.HeightInches) - (5 * user.Age) - 161;
        //    }

        //    macro.Tdee = user.ActivityLevel switch
        //    {
        //        ActivityLvl.Sedentary => (int)(macro.BMR * 1.2),
        //        ActivityLvl.LightlyActive => (int)(macro.BMR * 1.375),
        //        ActivityLvl.ModeratleyActive => (int)(macro.BMR * 1.55),
        //        ActivityLvl.VeryActive => (int)(macro.BMR * 1.725),
        //        ActivityLvl.ExtraActive => (int)(macro.BMR * 1.9)
        //    };
        //}

        //public static void CalculateRecrommendedMacros(WeightModel weight, MacroModel userMacros)
        //{
        //    userMacros.ProtienGrams = (int)(weight.CurrentWeight * userMacros.ProtienMultiplier);
        //    userMacros.ProtienCal = userMacros.ProtienGrams * 4;


        //}
    }
}
