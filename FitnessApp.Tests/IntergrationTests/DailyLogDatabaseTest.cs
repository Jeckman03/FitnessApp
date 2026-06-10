using DataAccessLibrary.Services;
using FitnessAppLibrary.Models;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Tests.IntergrationTests
{
    public class DailyLogDatabaseTest
    {

        [Fact]
        public async Task ShouldSaveThreeLogsAndReturnBothInAList()
        {
            var mockDb = new Mock<IDataAccess>();

            var firstLog = new DailyLogModel
            {
                PlanId = 1,
                LogDate = new DateOnly(2026, 06, 01),
                FatGrams = 50,
                CarbGrams = 50,
                ProteinGrams = 50,
                CurrentWeight = 211,
                Waist = 37,
                MetMacros = true,
                WorkedOut = true
            };

            var secondLog = new DailyLogModel
            {
                PlanId = 1,
                LogDate = new DateOnly(2026, 06, 02),
                FatGrams = 40,
                CarbGrams = 40,
                ProteinGrams = 40,
                CurrentWeight = 209,
                Waist = 36.5,
                MetMacros = true,
                WorkedOut = false
            };

            var thirdLog = new DailyLogModel
            {
                PlanId = 1,
                LogDate = new DateOnly(2026, 06, 03),
                FatGrams = 20,
                CarbGrams = 20,
                ProteinGrams = 20,
                CurrentWeight = 208,
                Waist = 32.2,
                MetMacros = false,
                WorkedOut = false
            };

            mockDb.Setup(db => db.LoadDataAsync<DailyLogModel, object>(
                It.IsAny<string>(),
                It.IsAny<object>())).ReturnsAsync(new List<DailyLogModel> { firstLog, secondLog, thirdLog });

            var dailyLogService = new DailyLogDataAccess(mockDb.Object);

            DateOnly startDate = new DateOnly(2026, 06, 01);
            DateOnly endDate = new DateOnly(2026, 6, 3);

            IEnumerable<DailyLogModel> returnedLogs = await dailyLogService.GetWeighIsBetweenDates(1, startDate, endDate);

            Assert.Collection(returnedLogs,
                log1 =>
                {
                    Assert.Equal(new DateOnly(2026, 6, 1), log1.LogDate);
                    Assert.Equal(211, log1.CurrentWeight);
                    Assert.Equal(true, log1.MetMacros);
                    Assert.Equal(true, log1.WorkedOut);
                },
                log2 =>
                {
                    Assert.Equal(new DateOnly(2026, 6, 2), log2.LogDate);
                    Assert.Equal(209, log2.CurrentWeight);
                    Assert.Equal(true, log2.MetMacros);
                    Assert.Equal(false, log2.WorkedOut);
                },
                log3 =>
                {
                    Assert.Equal(new DateOnly(2026, 6, 3), log3.LogDate);
                    Assert.Equal(208, log3.CurrentWeight);
                    Assert.Equal(false, log3.MetMacros);
                    Assert.Equal(false, log3.WorkedOut);
                });
        }
    }
}
