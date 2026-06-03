using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface ICheckinService
    {
        Task ProcessWeeklyWeighIn(int userId, double newWeight, bool stuckToMacros);
    }
}
