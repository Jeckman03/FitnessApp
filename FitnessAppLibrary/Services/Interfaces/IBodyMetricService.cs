using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{

    // Weight, Height, Age
    public interface IBodyMetricService
    {
        public double CalculateBMI(double weight, int height);

        public int CalculateTDEE(UserModel user, double weight);
    }
}
