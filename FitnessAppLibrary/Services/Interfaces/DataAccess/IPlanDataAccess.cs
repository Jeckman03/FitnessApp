using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces.DataAccess
{
    public interface IPlanDataAccess
    {
        Task<PlanModel> GetPlanAsync(int userId);

        Task UpdatePlanAsync(PlanModel currentPlan);
    }
}
