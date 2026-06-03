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

        public Task<PlanModel> GetPlanAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlanAsync(PlanModel currentPlan)
        {
            throw new NotImplementedException();
        }
    }
}
