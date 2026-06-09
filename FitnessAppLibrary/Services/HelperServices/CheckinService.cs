using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.Interfaces;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.HelperServices
{
    public class CheckinService : ICheckinService
    {
        private readonly IPlanDataAccess _planDataAccess;
        private readonly IDailyLogDataAccess _dailyLogDataAccess;

        public CheckinService(IPlanDataAccess planDataAccess, IDailyLogDataAccess dailyLogDataAccess)
        {
            _planDataAccess = planDataAccess;
            _dailyLogDataAccess = dailyLogDataAccess;
        }

        // CHECK THIS!!!!
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
    }
}
