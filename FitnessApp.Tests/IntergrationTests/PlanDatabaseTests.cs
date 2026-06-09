using DataAccessLibrary.Services;
using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Tests.IntergrationTests
{
    public class PlanDatabaseTests
    {
        [Fact]
        public async Task ShouldCreateAndReturnTheNewPlan()
        {
            var mockDb = new Mock<IDataAccess>();

            var expectedPlan = new PlanModel
            {
                StartDate = new DateOnly(2026, 06, 09),
                DurationDays = 1,
                Goal = Goals.Cut,
                CurrentCalorieTarget = 1800
            };

            mockDb.Setup(db => db.LoadDataAsync<PlanModel, object>(
                It.IsAny<string>(),
                It.IsAny<object>())).ReturnsAsync(new List<PlanModel> { expectedPlan });

            var planService = new PlanDataAccess(mockDb.Object);

            var planId = await planService.CreatePlanAndGetIdAsync(expectedPlan);

            PlanModel planResult = await planService.GetPlanAsync(planId);

            Assert.NotNull(planResult);
            Assert.Equal(expectedPlan, planResult);
        }
    }
}
