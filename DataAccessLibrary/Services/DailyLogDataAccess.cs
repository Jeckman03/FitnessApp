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

        public async Task<int> CreateWeighInAndReturnWeighInId(DailyLogModel dailyLog)
        {
            var sql = "Insert into DailyLogs (PlanId, LogDate, Fat, Carbs, Protien, CurrentWeight, Waist, MetMacros, WorkedOut) Values (@PlanId, @LogDate, @Fat, @Carbs, @Protien, @CurrentWeight, @Waist, @MetMacros, @WorkedOut)";

            var logId = await _db.SaveDataAndGetIdAsync(sql, dailyLog);

            return logId;
        }

        public async Task SaveWeighIn(DailyLogModel dailyLog)
        {
            var sql = "Insert into DailyLogs (PlanId, LogDate, Fat, Carbs, Protien, CurrentWeight, Waist, MetMacros, WorkedOut) Values (@PlanId, @LogDate, @Fat, @Carbs, @Protien, @CurrentWeight, @Waist, @MetMacros, @WorkedOut)";

            await _db.SaveDataAsync(sql, dailyLog);
        }

        public async Task<IEnumerable<DailyLogModel>> GetWeighInsByPlanIdAsync(int planId)
        {
            var sql = "Select * From DailyLog Limit 1";

            var recentWeighIns = await _db.LoadDataAsync<DailyLogModel, object>(sql, new { Id = planId });

            return recentWeighIns;
        }

        public async Task<IEnumerable<DailyLogModel>> GetWeighIsBetweenDates(int planId, DateOnly startDate, DateOnly endDate)
        {
            var sql = @"Select * From DailyLogs
                        Where PlanId = @PlanId
                        And LogDate Between @StartDate And @EndDate
                        Order By LogDate ASC";

            var parameters = new { planId, startDate, endDate };

            var dailyLogs = await _db.LoadDataAsync<DailyLogModel, object>(sql, parameters);

            return dailyLogs;
        }
    }
}
