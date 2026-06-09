using FitnessAppLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.HelperServices
{
    public class UnitConversionService : IUnitConversionSerivce
    {
        public int ConvertFeetAndInchesToInches(int feet, int inches)
        {
            int totalFeetInches = feet * 12;
            int totalInches = inches + totalFeetInches;

            return totalInches;
        }

        public (int Feet, int Inches) ConvertInchesToFeetAndInches(int totalInches)
        {
            int feet = totalInches / 12;
            int inches = totalInches % 12;

            return (feet, inches);
        }
    }
}
