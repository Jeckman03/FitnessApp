using DataAccessLibrary.Services;
using DataAccessLibrary.Sqllite;
using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using Microsoft.Data.Sqlite;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FitnessApp.Tests.IntergrationTests
{
    public class UserDatabaseTests
    {
        [Fact]
        public async Task SaveUserAsync_ShoulCreateUserAndReturnUserId()
        {
            var mockDb = new Mock<IDataAccess>();

            var expectedUser = new UserModel
            {
                Name = "Test",
                HeightInches = 73,
                ActivityLevel = ActivityLvl.LightlyActive,
                DateOfBirth = new DateOnly(1984, 3, 20),
                Gender = Gender.Male
            };

            mockDb.Setup(db => db.LoadDataAsync<UserModel, object>(
                It.IsAny<string>(),
                It.IsAny<object>())).ReturnsAsync(new List<UserModel> { expectedUser });

            var userService = new UserDataAccess(mockDb.Object);

            var userId = await userService.CreateUserAndGetId(expectedUser);

            Assert.Equal(0, userId );

        }

        [Fact]
        public async Task SaveUserAsync_ShouldCreateUserAndReturnUser()
        {
            var mockDb = new Mock<IDataAccess>();

            var expectedUser = new UserModel
            {
                Name = "Test",
                HeightInches = 73,
                ActivityLevel = ActivityLvl.LightlyActive,
                DateOfBirth = new DateOnly(1984, 3, 20),
                Gender = Gender.Male
            };

            mockDb.Setup(db => db.LoadDataAsync<UserModel, object>(
                It.IsAny<string>(),
                It.IsAny<object>())).ReturnsAsync(new List<UserModel> { expectedUser });

            var userService = new UserDataAccess(mockDb.Object);

            var userId = await userService.CreateUserAndGetId(expectedUser);
            var user = await userService.GetUserAsync(userId);

            Assert.Equal(0, userId);
            Assert.NotNull(user);
            Assert.Equal("Test", user.Name);
            Assert.Equal(73, user.HeightInches);
            Assert.Equal(Gender.Male, user.Gender);
            Assert.Equal(ActivityLvl.LightlyActive, user.ActivityLevel);
            Assert.Equal(new DateOnly(1984, 3, 20), user.DateOfBirth);
        }
    }
}
