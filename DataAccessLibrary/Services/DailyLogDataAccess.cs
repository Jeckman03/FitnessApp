using FitnessAppLibrary.Models;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Services
{
    public class DailyLogDataAccess : IDailyLogDataAccess
    {
        private readonly IDataAccess _db;

        public DailyLogDataAccess(IDataAccess db)
        {
            _db = db;
        }

        public async Task<int> CreateWeighInAndReturnWeighInIdAsync(DailyLogModel dailyLog)
        {
            var sql = "Insert into DailyLogs (PlanId, LogDate, FatGrams, CarbGrams, ProteinGrams, CurrentWeight, Waist, MetMacros, WorkedOut) Values (@PlanId, @LogDate, @FatGrams, @CarbGrams, @ProteinGrams, @CurrentWeight, @Waist, @MetMacros, @WorkedOut)";

            var logId = await _db.SaveDataAndGetIdAsync(sql, dailyLog);

            return logId;
        }

        public async Task SaveWeighInAsync(DailyLogModel dailyLog)
        {
            var sql = "Insert into DailyLogs (PlanId, LogDate, FatGrams, CarbGrams, ProteinGrams, CurrentWeight, Waist, MetMacros, WorkedOut) Values (@PlanId, @LogDate, @FatGrams, @CarbGrams, @ProteinGrams, @CurrentWeight, @Waist, @MetMacros, @WorkedOut)";

            await _db.SaveDataAsync(sql, dailyLog);
        }

        public async Task<IEnumerable<DailyLogModel>> GetWeighInsByPlanIdAsync(int planId)
        {
            var sql = @"Select * From DailyLog
                        Where PlanId = @PlanId";

            var recentWeighIns = await _db.LoadDataAsync<DailyLogModel, object>(sql, new { Id = planId });

            return recentWeighIns;
        }

        public async Task<IEnumerable<DailyLogModel>> GetWeighInsBetweenDatesAsync(int planId, DateOnly startDate, DateOnly endDate)
        {
            var sql = @"Select * From DailyLogs
                        Where PlanId = @PlanId
                        And LogDate Between @StartDate And @EndDate
                        Order By LogDate ASC";

            var parameters = new { planId, startDate, endDate };

            var dailyLogs = await _db.LoadDataAsync<DailyLogModel, object>(sql, parameters);

            return dailyLogs;
        }

        public async Task<DailyLogModel> GetLastPlanWeighInByIdAsync(int planId)
        {
            var sql = @"Select * From DailyLog
                        Where PlanId = @PlanId
                        Order By LogDate DESC
                        Limit 1";

            var lastWeighIn = await _db.LoadDataAsync<DailyLogModel, object>(sql, new { Id = planId});

            return lastWeighIn.FirstOrDefault();
        }
    }
}
