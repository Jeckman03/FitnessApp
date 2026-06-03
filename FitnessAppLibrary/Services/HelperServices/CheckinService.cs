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

        public async Task ProcessWeeklyWeighIn(int userId, double newWeight, bool stuckToMacros)
        {
            double previousWeight = await _dailyLogDataAccess.GetMostRecentWeightAsync(userId);

            var currentPlan = await _planDataAccess.GetPlanAsync(userId);

            if (stuckToMacros)
            {
                switch (currentPlan.Goal)
                {
                    case Goals.Cut:
                        if (newWeight >= previousWeight)
                        {
                            currentPlan.CurrentCalorieTarget -= 100;
                        }
                        break;

                    case Goals.Bulk:
                        if (newWeight <= previousWeight) 
                        {
                            currentPlan.CurrentCalorieTarget += 100;
                        }
                        else if (newWeight > previousWeight + 1)
                        {
                            currentPlan.CurrentCalorieTarget = currentPlan.CurrentCalorieTarget;
                        }
                        break;

                    case Goals.Maintain:
                        if (newWeight > previousWeight + 2)
                        {
                            currentPlan.CurrentCalorieTarget -= 50;
                        }
                        else if (newWeight < previousWeight -2)
                        {
                            currentPlan.CurrentCalorieTarget += 50;
                        }
                        break;
                }

                await _planDataAccess.UpdatePlanAsync(currentPlan);
            }
        }
    }
}
