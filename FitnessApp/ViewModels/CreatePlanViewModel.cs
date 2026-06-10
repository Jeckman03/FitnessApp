using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FitnessAppLibrary.Models;
using FitnessAppLibrary.Models.Enums;
using FitnessAppLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.ViewModels
{
    [QueryProperty(nameof(IncomingUser), "NewUser")]
    public partial class CreatePlanViewModel : BaseViewModel
    {
        private readonly IPlanTrackingService _planTrackingService;
        private readonly IDailyLogService _checkinService;

        [ObservableProperty]
        private UserModel _incomingUser;

        [ObservableProperty]
        private string _goal;

        [ObservableProperty]
        private double _targetWeight;

        [ObservableProperty]
        private double _currentWeight;

        [ObservableProperty]
        private double _currentWaist;

        

        public List<string> AvailableGoals { get; } = new List<string>
        {
            "Cut",
            "Maintain",
            "Bulk"
        };

        public CreatePlanViewModel(IPlanTrackingService planTrackingService, IDailyLogService checkinService)
        {
            _planTrackingService = planTrackingService;
            _checkinService = checkinService;
        }

        [RelayCommand]
        private async Task CreatePlan()
        {
            await _planTrackingService.FinalizeOnboardingAsync(IncomingUser, GetTranslatedGoals(), TargetWeight, CurrentWeight, CurrentWaist);

            await Shell.Current.GoToAsync("//HomeTab");
        }

        private Goals GetTranslatedGoals()
        {
            return Goal switch
            {
                "Cut" => Goals.Cut,
                "Maintain" => Goals.Maintain,
                "Bulk" => Goals.Bulk
            };
        }
    }
}
