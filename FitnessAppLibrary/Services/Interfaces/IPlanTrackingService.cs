using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface IPlanTrackingService
    {
        Task<int> FinalizeOnboardingAsync(UserModel newUser, Goals goal, double targetType, double currentWeight, double currentWaist);

        Task<int> CreatePlanAndReturnIdAsync(PlanModel plan);

        Task SavePlanAsync(PlanModel plan);

        Task<PlanModel> GetPlanByUserIdAsync(int id);

        Task DeletPlanAsync(PlanModel plan);
    }
}
