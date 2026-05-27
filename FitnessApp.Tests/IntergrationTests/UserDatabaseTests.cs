using DataAccessLibrary.Services;
using DataAccessLibrary.Sqllite;
using FitnessAppLibrary.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FitnessApp.Tests.IntergrationTests
{
    public class UserDatabaseTests
    {
        private const string TestDbName = "TestFitness.db";
        private string _connectionString = $"Data Source={TestDbName}";

        public void Dispose()
        {
            if (File.Exists(TestDbName))
            {
                File.Delete(TestDbName);
            }
        }

        [Fact]
        public async Task SaveUser_ShouldReadBackCorrectData()
        {
            var dataAccess = new SqLiteDataAccess(_connectionString);
            await dataAccess.InitializeDatabase();

            var testUser = new UserModel
            {
                Id = 1,
                Name = "Jeffrey",
                DateOfBirth = new DateOnly(1984, 03, 20),
                Gender = Gender.Male,
                ActivityLevel = ActivityLvl.VeryActive,
                HeightInches = 37
            };

            UserProfileServices userProfile = new(dataAccess);

            await userProfile.SaveUserAsync(testUser);
            var result = await userProfile.GetUserAsync(testUser.Id);


            Assert.NotNull(result);
            Assert.Equal(testUser.Name, result.Name);
            Assert.Equal(37, result.HeightInches);
            Assert.Equal(testUser.DateOfBirth, result.DateOfBirth);
            Assert.Equal(testUser.ActivityLevel, result.ActivityLevel);
        }
    }
}
