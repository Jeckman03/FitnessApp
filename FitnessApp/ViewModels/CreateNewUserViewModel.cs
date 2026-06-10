using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.Interfaces;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.ViewModels
{
    public partial class CreateNewUserViewModel : BaseViewModel
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IUnitConversionSerivce _unitConversionSerivce;
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private DateTime _userDateOfBirth;

        [ObservableProperty]
        private int _heightFeet;

        [ObservableProperty]
        private int _heightInches;

        [ObservableProperty]
        private string _userGender;

        [ObservableProperty]
        private string _userActivityLvl;

        private int TotalInches { get; set; }

        public List<string> AvailableActivityLevels { get; } = new List<string>
        {
            "Sedentary (Desk Job)",
            "Lightly Active (1-3 days/week)",
            "Moderately Active (3-5 days/week)",
            "Very Active (6-7 days/week)",
            "Extra Active (Physical Job)"
        };

        public CreateNewUserViewModel(IUserProfileService userProfileService, IUnitConversionSerivce unitConversionSerivce)
        {
            _userProfileService = userProfileService;
            _unitConversionSerivce = unitConversionSerivce;
        }

        [RelayCommand]
        private async Task SubmitUser(UserModel newUser)
        {
            TotalInches = _unitConversionSerivce.ConvertFeetAndInchesToInches(_heightFeet, _heightInches);
            var dateOnlyDOB = DateOnly.FromDateTime(UserDateOfBirth);

            var createdUser = new UserModel
            {
                Name = UserName,
                DateOfBirth = dateOnlyDOB,
                HeightInches = TotalInches,
                Gender = GetTranslatedGender(),
                ActivityLevel = GetTranslatedActivityLevel()
            };

            var navigationParameters = new Dictionary<string, object>
            {
                { "NewUser", createdUser }
            };

            await Shell.Current.GoToAsync("CreatePlanPage", navigationParameters);
        }

        private ActivityLvl GetTranslatedActivityLevel()
        {
            return UserActivityLvl switch
            {
                "Sedentary (Desk Job)" => ActivityLvl.Sedentary,
                "Lightly Active (1-3 days/week)" => ActivityLvl.LightlyActive,
                "Moderately Active (3-5 days/week)" => ActivityLvl.ModeratelyActive,
                "Very Active (6-7 days/week)" => ActivityLvl.VeryActive,
                "Extra Active (Physical Job)" => ActivityLvl.ExtraActive,
                _ => ActivityLvl.Sedentary
            };
        }

        private Gender GetTranslatedGender()
        {
            return UserGender switch
            {
                "Male" => Gender.Male,
                "Female" => Gender.Female
            };
        }
    }
}
