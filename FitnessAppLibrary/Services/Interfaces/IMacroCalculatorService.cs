using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface IMacroCalculatorService
    {
        

        MacroTarget CalculateDailyMacros(int currentCalorieTarget, double weightPounds);
    }
}
