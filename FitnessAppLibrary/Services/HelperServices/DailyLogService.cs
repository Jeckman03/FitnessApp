using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.Interfaces;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.HelperServices
{
    public class DailyLogService : IDailyLogService
    {
        private readonly IPlanDataAccess _planDataAccess;
        private readonly IDailyLogDataAccess _dailyLogDataAccess;

        public DailyLogService(IPlanDataAccess planDataAccess, IDailyLogDataAccess dailyLogDataAccess)
        {
            _planDataAccess = planDataAccess;
            _dailyLogDataAccess = dailyLogDataAccess;
        }

        public async Task<PlanModel> CalculateNewCalorieTarget(int planId, double newWeight, bool stuckToMacros)
        {
            DailyLogModel previousWeight = await _dailyLogDataAccess.GetLastPlanWeighInByIdAsync(planId);

            var currentPlan = await _planDataAccess.GetPlanAsync(planId);

            if (stuckToMacros)
            {
                switch (currentPlan.Goal)
                {
                    case Goals.Cut:
                        if (newWeight >= previousWeight.CurrentWeight)
                        {
                            currentPlan.CurrentCalorieTarget -= 100;
                        }
                        break;

                    case Goals.Bulk:
                        if (newWeight <= previousWeight.CurrentWeight) 
                        {
                            currentPlan.CurrentCalorieTarget += 100;
                        }
                        else if (newWeight > previousWeight.CurrentWeight + 1)
                        {
                            currentPlan.CurrentCalorieTarget = currentPlan.CurrentCalorieTarget;
                        }
                        break;

                    case Goals.Maintain:
                        if (newWeight > previousWeight.CurrentWeight + 2)
                        {
                            currentPlan.CurrentCalorieTarget -= 50;
                        }
                        else if (newWeight < previousWeight.CurrentWeight -2)
                        {
                            currentPlan.CurrentCalorieTarget += 50;
                        }
                        break;
                }

                return currentPlan;
            }
            else
            {
                return currentPlan;
            }
        }

        public int CalculateStartingCalories(int tdee, Goals goal)
        {
            int targetTdee = 0;

            if (goal == Goals.Cut)
            {
                targetTdee -= 500;
            }
            else if (goal == Goals.Bulk)
            {
                targetTdee += 200;
            }
            else
            {
                targetTdee = tdee;
            }

            return targetTdee;

        }

        public async Task<int> CreateDailyLogAndReturnIdAsync(DailyLogModel dailyLog)
        {
            int dailyLogId = await _dailyLogDataAccess.CreateWeighInAndReturnWeighInIdAsync(dailyLog);

            return dailyLogId;
        }

        public async Task<DailyLogModel> GetFirstWeighInByPlanIdAsync(int planId)
        {
            var firstWeighIn = await _dailyLogDataAccess.GetFirstWeighInAsync(planId);

            return firstWeighIn;
        }

        public async Task<DailyLogModel> GetLastWeighInByPlanIdAsync(int planId)
        {
            var dailyLog = await _dailyLogDataAccess.GetLastPlanWeighInByIdAsync(planId);

            return dailyLog;
        }

        public async Task SaveDailyLogAsync(DailyLogModel model)
        {
            await _dailyLogDataAccess.SaveWeighInAsync(model);
        }

        async Task<IEnumerable<DailyLogModel>> IDailyLogService.GetWeighInsBetweenDates(int planId, DateOnly startDate, DateOnly endDate)
        {
            var dailyLogIns = await _dailyLogDataAccess.GetWeighInsBetweenDatesAsync(planId, startDate, endDate);

            return dailyLogIns.ToList();
        }

        async Task<IEnumerable<DailyLogModel>> IDailyLogService.GetWeighInsByPlanIdAsync(PlanModel planId)
        {
            var dailLogs = await _dailyLogDataAccess.GetWeighInsByPlanIdAsync(planId.Id);

            return dailLogs.ToList();
        }
    }
}
