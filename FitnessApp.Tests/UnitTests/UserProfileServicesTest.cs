using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using FitnessAppLibrary.Services.Interfaces;
using FitnessAppLibrary.Models;
using DataAccessLibrary.Services;

namespace FitnessApp.Tests.UnitTests
{
    public class UserProfileServicesTest
    {
        [Fact]
        public async Task GetUserAsync_ShouldReturnCorrectUser_WhenIdExists()
        {
            var mockDb = new Mock<IDataAccess>();

            var expectedUser = new UserModel
            {
                Id = 1,
                Name = "Test",
                HeightInches = 67
            };

            mockDb.Setup(db => db.LoadDataAsync<UserModel, object>(
                It.IsAny<string>(), 
                It.IsAny<object>()))
                .ReturnsAsync(new List<UserModel> { expectedUser });

            var userService = new UserProfileServices(mockDb.Object);

            var actualUser = await userService.GetUserAsync(1);

            Assert.NotNull(actualUser);
            Assert.Equal("Test", actualUser.Name);
            Assert.Equal(67, actualUser.HeightInches);
        }
    }
}
