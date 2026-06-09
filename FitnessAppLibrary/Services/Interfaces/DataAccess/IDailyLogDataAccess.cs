using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces.DataAccess
{
    public interface IDailyLogDataAccess
    {
        Task<int> CreateWeighInAndReturnWeighInId(DailyLogModel dailyLog);

        Task SaveWeighIn(DailyLogModel dailyLog);

        Task<IEnumerable<DailyLogModel>> GetWeighInsByPlanIdAsync(int planId);

        Task<IEnumerable<DailyLogModel>> GetWeighIsBetweenDates(int planId, DateOnly startDate, DateOnly endDate);
    }
}
