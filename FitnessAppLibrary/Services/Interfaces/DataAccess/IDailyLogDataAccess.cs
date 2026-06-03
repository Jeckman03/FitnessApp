using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces.DataAccess
{
    public interface IDailyLogDataAccess
    {
        Task<double> GetMostRecentWeightAsync(int userId);
    }
}
