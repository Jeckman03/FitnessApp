using DataAccessLibrary.SqlStatements;
using FitnessAppLibrary.Models;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Services
{
    public class PlanDataAccess : IPlanDataAccess
    {
        private readonly IDataAccess _dataAccess;

        public PlanDataAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<int> CreatePlanAndGetIdAsync(PlanModel plan)
        {
            var sql = "Insert into Plans (UserId, StartDate, DurationDays, Goal, CurrentCalorieTarget) Values (@UserId, @StartDate, @DurationDays, @Goal, @CurrentCalorieTarget)";

            int newPlanId = await _dataAccess.SaveDataAndGetIdAsync(sql, plan);

            return newPlanId;
        }

        public async Task<PlanModel> GetPlanAsync(int userId)
        {
            var sql = "Select * From Plans limit 1";

            var result = await _dataAccess.LoadDataAsync<PlanModel, object>(sql, new { Id = userId });

            return result.FirstOrDefault();
        }

        public async Task SavePlanAsync(PlanModel currentPlan)
        {
            var sql = "Insert into Plans (UserId, StartDate, DurationDays, Goal, CurrentCalorieTarget) Values (@UserId, @StartDate, @DurationDays, @Goal, @CurrentCalorieTarget)";

            await _dataAccess.SaveDataAsync<PlanModel>(sql, currentPlan);
        }
    }
}
