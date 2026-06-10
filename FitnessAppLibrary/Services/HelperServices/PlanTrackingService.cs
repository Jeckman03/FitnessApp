using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.Interfaces;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.HelperServices
{
    public class PlanTrackingService : IPlanTrackingService
    {
        private readonly IPlanDataAccess _planDataAccess;
        private readonly IUserDataAccess _userDataAccess;
        private readonly IMacroCalculatorService _macroCalculatorService;
        private readonly IDailyLogService _dailyLogService;
        private readonly IBodyMetricService _bodyMetricService;

        public PlanTrackingService(IPlanDataAccess planDataAccess, IUserDataAccess userDataAccess, IMacroCalculatorService macroCalculatorService, IDailyLogService dailyLogService, IBodyMetricService bodyMetricService)
        {
            _planDataAccess = planDataAccess;
            _userDataAccess = userDataAccess;
            _macroCalculatorService = macroCalculatorService;
            _dailyLogService = dailyLogService;
            _bodyMetricService = bodyMetricService;
        }

        public async Task FinalizeOnboardingAsync(UserModel newUser, Goals goal, double targetWeight, double currentWeight, double currentWaist)
        {
            int userId = await _userDataAccess.CreateUserAndGetId(newUser);

            int tDEE = _bodyMetricService.CalculateTDEE(newUser, currentWeight);

            int startingTdee = _dailyLogService.CalculateStartingCalories(tDEE, goal);

            var newPlan = new PlanModel
            {
                UserId = userId,
                Goal = goal,
                TargetWeight = targetWeight,
                CurrentCalorieTarget = startingTdee,
                StartDate = DateOnly.FromDateTime(DateTime.Today)
            };

            int planId = await _planDataAccess.CreatePlanAndGetIdAsync(newPlan);

            MacroTarget macroTarget = _macroCalculatorService.CalculateDailyMacros(startingTdee, currentWeight);

            var initialDailyLog = new DailyLogModel
            {
                PlanId = planId,
                LogDate = DateOnly.FromDateTime(DateTime.Today),
                FatGrams = macroTarget.FatGrams,
                CarbGrams = macroTarget.CarbGrams,
                ProteinGrams = macroTarget.ProteinGrams,
                CurrentWeight = currentWeight,
                Waist = currentWaist,
                MetMacros = true,
                WorkedOut = true
            };

            await _dailyLogService.SaveDailyLogAsync(initialDailyLog);
        }


        public async Task<int> CreatePlanAndReturnIdAsync(PlanModel plan)
        {
            throw new NotImplementedException();
        }

        public async Task SavePlanAsync(PlanModel plan)
        {
            throw new NotImplementedException();
        }

        public async Task DeletPlanAsync(PlanModel plan)
        {
            throw new NotImplementedException();
        }

        public Task<PlanModel> GetPlanByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
