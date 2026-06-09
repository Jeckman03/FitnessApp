using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface ICheckinService
    {
        Task<PlanModel> CalculateNewCalorieTarget(int userId, double newWeight, bool stuckToMacros);
    }
}
