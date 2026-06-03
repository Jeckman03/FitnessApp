using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface IMacroCalculatorService
    {
        int CalculateInitialCalorieTarget(int baseTdee, string goal);

        MacroTarget CalculateDailyMacros(int currentCalorieTarget, double weightPounds);
    }
}
