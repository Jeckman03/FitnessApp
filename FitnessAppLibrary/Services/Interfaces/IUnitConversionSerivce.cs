using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface IUnitConversionSerivce
    {
        public (int Feet, int Inches) ConvertInchesToFeetAndInches(int totalInches);
    }
}
