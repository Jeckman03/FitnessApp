using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Services
{
    public class DailyLogDataAccess : IDailyLogDataAccess
    {
        public Task<double> GetMostRecentWeightAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
