using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface IDailyLogService
    {
        Task<IEnumerable<DailyLogModel>> GetWeighInsByPlanIdAsync(PlanModel planId);

        Task<IEnumerable<DailyLogModel>> GetWeighInsBetweenDates(int planId, DateOnly startDate, DateOnly endDate);

        Task<int> CreateDailyLogAndReturnIdAsync(DailyLogModel dailyLog);

        Task<DailyLogModel> GetLastWeighInByPlanIdAsync(PlanModel planId);

        Task SaveDailyLogAsync(DailyLogModel model);

        Task<PlanModel> CalculateNewCalorieTarget(int userId, double newWeight, bool stuckToMacros);

        int CalculateStartingCalories(int tDEE, Goals goal);
    }
}
