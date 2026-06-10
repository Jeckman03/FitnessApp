using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces.DataAccess
{
    public interface IDailyLogDataAccess
    {
        Task<int> CreateWeighInAndReturnWeighInIdAsync(DailyLogModel dailyLog);

        Task SaveWeighInAsync(DailyLogModel dailyLog);

        Task<IEnumerable<DailyLogModel>> GetWeighInsByPlanIdAsync(int planId);

        Task<DailyLogModel> GetLastPlanWeighInByIdAsync(int planId);

        Task<IEnumerable<DailyLogModel>> GetWeighInsBetweenDatesAsync(int planId, DateOnly startDate, DateOnly endDate);
    }
}
