using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.HelperServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Tests.UnitTests
{
    public class BodyMetricServiceTest
    {
        [Fact]
        public void ShouldReturnUserBMI()
        {
            UserModel user = new UserModel
            {
                HeightInches = 70
            };

            var userWeight = 180;

            BodyMetricService bodyMetricService = new();

            var bmiResult = bodyMetricService.CalculateBMI(userWeight, user.HeightInches);

            Assert.Equal(25.8, bmiResult);
        }

        [Fact]
        public void ShouldReturnCorrectTDEE_For_MaleAndFemale()
        {
            UserModel maleUser = new UserModel
            {
                Gender = Gender.Male,
                DateOfBirth = new DateOnly(1984, 03, 20),
                HeightInches = 67,
                ActivityLevel = ActivityLvl.LightlyActive
            };

            UserModel femaleUser = new UserModel
            {
                Gender = Gender.Female,
                DateOfBirth = new DateOnly(1984, 03, 20),
                HeightInches = 67,
                ActivityLevel = ActivityLvl.LightlyActive
            };

            BodyMetricService bodyMetricMale = new();
            BodyMetricService bodyMetricFemale = new();

            var maleTDEEResult = bodyMetricMale.CalculateTDEE(maleUser, 215);
            var femaleTDEEResult = bodyMetricFemale.CalculateTDEE(femaleUser, 215);

            Assert.Equal(4208, maleTDEEResult);
            Assert.Equal(2511, femaleTDEEResult);

            maleUser.ActivityLevel = ActivityLvl.ExtraActive;
            femaleUser.ActivityLevel = ActivityLvl.ExtraActive;

            maleTDEEResult = bodyMetricMale.CalculateTDEE(maleUser, 215);
            femaleTDEEResult = bodyMetricFemale.CalculateTDEE(femaleUser, 215);

            Assert.Equal(5815, maleTDEEResult);
            Assert.Equal(3469, femaleTDEEResult);
        }

    }
}
