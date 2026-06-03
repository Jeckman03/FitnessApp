using FitnessAppLibrary.Models;
using FitnessAppLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.HelperServices
{
    public class MacroCalculatorService : IMacroCalculatorService
    {
        public int CalculateInitialCalorieTarget(int baseTdee, string goal)
        {
            int startingCalories = baseTdee;

            if (goal.ToLower() == "cut") startingCalories -= 500;
            if (goal.ToLower() == "bulk") startingCalories += 500;

            return startingCalories;
        }

        public MacroTarget CalculateDailyMacros(int currentCalorieTarget, double weightPounds)
        {
            // Calculate protein
            int proteinGrams = (int)weightPounds;
            int proteinCalories = proteinGrams * 4;

            // Calculate fat
            int fatCalories = (int)(currentCalorieTarget * 0.25);
            int fatGrams = fatCalories / 9;

            // Calculate carbs
            int carbCalories = currentCalorieTarget - proteinCalories - fatCalories;
            int carbGrams = carbCalories / 4;

            return new MacroTarget(proteinGrams, carbGrams, fatGrams);
        }
    }
}
